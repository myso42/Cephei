using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Cephei.Cell.Generic
{
    /// <summary>
    /// CellFast is a specialization of Cell for scenarios where the dependencies are
    /// known in advance, or the Formula is captured from a closure that only contains
    /// references to the dependencies used for a calculation.
    /// 
    /// Specific closures can be created by using builder functions such as
    ///    <font color="#0000ff">let</font> sc = Cell.CreateValue 1I
    ///    <font color="#0000ff">let</font> ts =
    ///        <font color="#0000ff">let</font> build (r : ICell<'t>) =
    ///            Cell.CreateFast (<font color="#0000ff">fun</font> () <font
    /// color="#0000ff">-></font> fac r.Value)
    ///        build sc
    /// In this example the closure to build <i>ts</i> is bound to <i>sc</i>.  For
    /// these scenarios the factory function can infer the dependencies by reflecting
    /// over the closure to deduce the values referenced.
    /// 
    /// This version of cell avoids additional logic to check for profiling or to
    /// rebind when a dependency changes.
    /// 
    /// CellFacst<> should not be used for values unless <b>every </b>dependant is know
    /// to use fast closures
    /// </summary>
    public class CellFast<T> : ICell<T>, IFast
    {
        private FSharpFunc<Unit, T> _func;
        private SpinLock _spinLock = new SpinLock(true);
        private volatile ManualResetEvent _event = new ManualResetEvent(false);

        private volatile int _state = (int)CellState.Dirty;
        private Thread _lockHolder = null;
        //private volatile CellState _state = CellState.Dirty;
        private T _value;
        private Exception _lastException = null;
        private DateTime _epoch;
        private bool _disposd = false;
        // number of pending calculations
        volatile int _pending;
        public ICell Mutex { get; set; }

        public string Mnemonic { get; set; }
        private ICell _parent;
        public ICell Parent
        {
            get
            {
                return _parent;
            }
            set
            {
                if (_parent == null || _parent.Parent != value)
                    _parent = value;
            }
        }

        public CellFast(FSharpFunc<Unit, T> func, ICell[] dependencies)
        {
            _func = func;
            if (!Cell.Lazy)
                Cell.Dispatch(() =>
                {
                    try
                    {
                        Calculate(DateTime.Now, 0);
                    }
                    catch (Exception e)
                    {
                        Serilog.Log.Error(e, e.Message);
                    }
                });

            foreach (var d in dependencies)
                d.Notify(this);
        }
        public CellFast(FSharpFunc<Unit, T> func, ICell[] dependencies, ICell mutex) : this (func, dependencies)
        {
            Mutex = mutex;
        }

        public CellFast(FSharpFunc<Unit, T> func)
        {
            var dependencies = Cell.Profile(func);
            _func = func;
            if (!Cell.Lazy)
                Cell.Dispatch(() =>
                {
                    try
                    {
                        Calculate(DateTime.Now, 0);
                    }
                    catch (Exception e)
                    {
                        Serilog.Log.Error(e, e.Message);
                    }
                });

            foreach (var d in dependencies)
                d.Notify(this);
        }
        public CellFast(FSharpFunc<Unit, T> func, ICell mutex) : this(func)
        {
            Mutex = mutex;
        }

        public CellFast(T value)
        {
            _value = value;
            _state = (int)CellState.Clean;
        }
#if !DEBUG
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        private T Calculate(DateTime epoch, int recurse, ISession session = null)
        {
            if (recurse > 60) throw new LockRecursionException();
            bool taken = false;
            try
            {
                _spinLock.Enter(ref taken);
                if (taken)
                {
                    if (_state == (int)CellState.Clean && session == null || (_epoch > epoch && session == null))
                        return _value;      // don't recalculate for read
                    SetState(CellState.Calculating);
                    _spinLock.Exit(true);
                    taken = false;

                    T t;
                    if (_func != null)
                    {
                        if (Mutex == null)
                            t = _func.Invoke(null);
                        else
                        {
                            lock (Mutex)
                            {
                                t = _func.Invoke(null);
                            }
                        }
                    }
                    else
                        t = _value;

                    if (session != null)
                        session.SetValue<T>(this, t);

                    while (taken == false)
                    {
                        // sleep through massive contention
                        _spinLock.Enter(ref taken);
                        if (!taken)
                        {
                            Thread.Sleep(recurse++ * 100);
                            return Calculate(epoch, recurse, session);
                        }
                    }
                    if (epoch >= _epoch)
                    {
                        _epoch = epoch;
                        _value = t;
                    }
                    SetState(CellState.Clean);
                    if (_pending > 0)
                    {
                        if (session != null)
                            _pending--;
                    }
                    return t;
                }
                else
                {
                    Thread.Sleep(recurse * 100);
                    return Calculate(epoch, recurse + 1, session);     // edge case retry lock
                }
            }
            catch (Exception e)
            {
                Serilog.Log.Error(e, "Calculation failed for {0} with error {1}", Mnemonic, e.Message);
                _lastException = new CalculationException(e);
                SetState(CellState.Error);
                RaiseChange(CellEvent.Error, this, this, epoch, null);

                throw;
            }
            finally
            {
                if (taken) _spinLock.Exit(true);
            }
        }
        public T GetValue(int recurse)
        {
            if (recurse > 60) throw new LockRecursionException();
            bool taken = false;
            try
            {
                _spinLock.Enter(ref taken);
                if (!taken)
                {
                    Thread.Sleep(recurse * 100);
                    return GetValue(recurse + 1);                   // edge case lock failed
                }
                if (_pending > 0)
                    if (Interlocked.Exchange(ref _state, (int)CellState.Dirty) == (int)CellState.Blocking)
                        if (Interlocked.Exchange(ref _state, (int)CellState.Blocking) == (int)CellState.Clean)
                            SetState(CellState.Dirty);

                switch (_state)
                {
                    case (int)CellState.Clean:
                        var v = _value;
                        _spinLock.Exit(true);
                        taken = false;
                        if (v == null && _lastException == null)
                        {
                            SetState(CellState.Dirty);
                            return GetValue(recurse + 1);
                        }
                        var ses = Session.Current;
                        if (ses != null && ses.HasJoined(this))
                        {
                            if (ses.GetValue<T>(this, ref v))
                                return v;
                            else
                                return Calculate(DateTime.Now, recurse + 1);     // edge case for read before write
                        }
                        return (v);

                    case (int)CellState.Calculating:
                    case (int)CellState.Blocking:
                        Interlocked.Exchange(ref _state, (int)CellState.Blocking);
                        _spinLock.Exit(true);
                        taken = false;
                        for (int c = 0; c < 60000; c += 100)
                        {
                            //                            if (_event == null) _event = new ManualResetEvent(false);
                            if (_event.WaitOne(c) || _state != (int)CellState.Blocking || _lockHolder == null || !_lockHolder.IsAlive || _lockHolder == Thread.CurrentThread)
                                break;
                        }
                         if (_state != (int)CellState.Clean)
                            return Calculate(DateTime.Now, recurse + 1);
                        else
                            return GetValue(recurse + 1);           // re-read through lock

                    case (int)CellState.Dirty:
                        SetState(CellState.Calculating);
                        _spinLock.Exit(true);
                        taken = false;
                        return Calculate(DateTime.Now, recurse + 1);

                    case (int)CellState.Error:
                        throw _lastException;

                    default:
                        return GetValue(recurse + 1);           // edge case
                }
            }
            finally
            {
                if (taken) _spinLock.Exit(true);
            }
        }
        public T Value
        {
            get
            {
                return GetValue(0);
            }
            set
            {
                bool taken = false;
                try
                {
                    _spinLock.Enter(ref taken);
                    if (taken)
                    {
                        SetState(CellState.Clean);
                        var ses = Session.Current;
                        _value = value;
                        _state = (int)CellState.Clean;
                        _epoch = DateTime.Now;
                        _spinLock.Exit(true);
                        taken = false;
                        if (ses != null)
                        {
                            ses.SetValue<T>(this, value);
                            RaiseChange(CellEvent.JoinSession, this, this, DateTime.Now, ses);

                        }
                        else
                            RaiseChange(CellEvent.Calculate, this, this, _epoch, ses);

                    }
                }
                finally
                {
                    if (taken) _spinLock.Exit(true);
                }
            }
        }

        public IEnumerable<ICellEvent> Dependants
        {
            get
            {
                if (Change != null)
                {
                    bool taken = false;
                    ICellEvent[] r = null;
                    while (taken == false)
                    {
                        try
                        {
                            _spinLock.Enter(ref taken);
                            if (taken)
                            {
                                var l = Change.GetInvocationList();
                                r = new ICellEvent[l.Length];
                                for (int c = 0; c < l.Length; ++c)
                                {
                                    r[c] = l[c].Target as ICellEvent;
                                }
                            }
                            else
                                Thread.Sleep(100);
                        }
                        catch
                        {
                            return new ICellEvent[0];
                        }
                        finally
                        {
                            if (taken) _spinLock.Exit();
                        }

                    }
                    return r;
                }
                else
                    return new ICellEvent[0];
            }
        }

        public event CellChange Change;

        public void Dispose()
        {
            _disposd = true;
            RaiseChange(CellEvent.Delete, this, this, DateTime.Now, null);

            Change = delegate { };
        }

        private void PoolCalculate(DateTime epoch, ISession session)
        {
            if (Change != null || !Cell.Lazy)
            {
                var lastsession = Session.Current;
                Session.Current = session;
                Calculate(epoch, 0, session);
                RaiseChange(CellEvent.Calculate, this, this, epoch, session);
                Session.Current = lastsession;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void RaiseChange(CellEvent eventType, ICellEvent root, ICellEvent sender, DateTime epoch, ISession session)
        {
            if (Change != null)
                Change(eventType, root, this, epoch, session);
            if (Parent != null)
                Parent.OnChange(eventType, root, this, epoch, session);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Cephei.Cell.CellState SetState(CellState value)
        {
            if (value == CellState.Calculating)
            {
                _lockHolder = Thread.CurrentThread;
            }
            else if (value == CellState.Clean)
            {
                _lockHolder = null;
            }
            var s = (CellState)Interlocked.Exchange(ref _state, (int)value);
            if (s == CellState.Blocking)
            {
                _event.Set();
                _event.Reset();
            }
            return s;
        }

        public virtual void OnChange(CellEvent eventType, ICellEvent root,  ICellEvent sender,  DateTime epoch, ISession session)
        {
            if (_disposd && root != this && eventType != CellEvent.Delete) sender.OnChange(CellEvent.Delete, this, this, epoch, session);
            switch (eventType)
            {
                case CellEvent.Calculate:
                    if (session != null && session.State == SessionState.Open)
                        _pending++;
                    else if (epoch > _epoch)
                    {
                        _epoch = epoch;
                        OnChange(CellEvent.Invalidate, root, this, epoch, session);
                        Cell.Dispatch(() =>
                            {
                                try
                                {
                                    PoolCalculate(epoch, session);
                                }
                                catch (Exception e)
                                {
                                    Serilog.Log.Error(e, e.Message);
                                }
                            });
                    }
                    break;
                case CellEvent.Delete:
                    Change -= sender.OnChange;
                    break;
                case CellEvent.Invalidate:
                    var lastState = (CellState)Interlocked.Exchange(ref _state, (int)CellState.Dirty);
                    if (lastState == CellState.Calculating || lastState == CellState.Blocking)
                        lastState = (CellState)Interlocked.Exchange(ref _state, (int)lastState);
                    else
                        RaiseChange(eventType, root, this, epoch, session);
                    break;

                case CellEvent.JoinSession:
                    session.Join(this);
                    RaiseChange(eventType, root, this, epoch, session);
                    break;

                case CellEvent.Error:
                    bool taken = false;
                    _spinLock.Enter(ref taken);
                    while (!taken)
                    {
                        Thread.Yield();
                        _spinLock.Enter(ref taken);
                    }
                    SetState(CellState.Error);
                    _spinLock.Exit();
                    break;

                case CellEvent.Link:
                    if (Parent != null && Parent is Model m && _func != null)
                        if (Cell.Relink(_func, m))
                            SetState(CellState.Dirty);
                    RaiseChange(eventType, root, this, epoch, session);
                    break;

                case CellEvent.CyclicCheck:
                    if (root == this) 
                        throw new CyclicDependencyException();
                    else
                        RaiseChange(eventType, root, this, epoch, session);
                    break;

                default:
                    break;
            }
        }

        /// <see cref="ICell.HasFunction"/>
        public bool HasFunction => _func != null;
        /// <see cref="ICell.HasValue"/>
        public bool HasValue => true;

        /// <see cref="ICell.Box"/>
        public object Box
        {
            get
            {
                return Value;
            }
            set
            {
                Value = (T)Value;
            }
        }
        public FSharpFunc<Unit, T> Function
        {
            get
            {
                return _func;
            }
            set
            {
                _func = value;
            }
        }

        public void Merge(ICell source, Model model)
        {
            if (source != this)
            {
                var c = (ICell<T>)source;
                var f = _func;
                _func = c.Function;
                c.Function = f;
                Parent = c.Parent;
                _state = (int)CellState.Dirty;
            }

            // handle update of current while this cell is being constructed
            if (Parent is Model m)
            {
                ICell cur;
                if (m.TryGetValue(this.Mnemonic, out cur))
                {
                    if (cur != this && cur != null && cur.GetType() == this.GetType())
                        cur.Merge(this, model);
                }
            }
            RaiseChange(CellEvent.CyclicCheck, this, this, DateTime.Now, null);
            RaiseChange(CellEvent.Calculate, this, this, DateTime.Now, null);
        }

        #region observable
        public IDisposable Subscribe(IObserver<T> observer)
        {
            return new CellObserver<T>(this, observer);
        }

        public IDisposable Subscribe(IObserver<KeyValuePair<ISession, KeyValuePair<string, T>>> observer)
        {
            return new SessionObserver<T>(this, observer);
        }

        public IDisposable Subscribe(IObserver<Tuple<ISession, Generic.ICell<T>, CellEvent, ICell, DateTime>> observer)
        {
            return new TraceObserver<T>(this, observer);
        }
        #endregion
        #region observer
        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
            _lastException = error;
            SetState(CellState.Error);
        }

        public void OnNext(T value)
        {
            Value = value;
        }
        #endregion
        public void Notify(ICell listener)
        {
            if (listener == this) return;
            foreach (var v in Dependants)
                if (v == listener)
                    return;
            if (listener != null)
                Change += listener.OnChange;
        }

        public void UnNotify(ICell listener)
        {
            if (listener != null)
                Change -= listener.OnChange;
        }
        public object GetFunction()
        {
            return _func;
        }
        public bool ValueIs<Base>()
        {
            return typeof(Base).IsAssignableFrom(typeof(T)) ||
                   typeof(T).IsSubclassOf(typeof(Base));
        }
        public CellState State => (CellState)_state;
        public Exception Error => _lastException;
    }
}
