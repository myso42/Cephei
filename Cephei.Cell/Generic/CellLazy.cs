﻿/*
 * Copyright(C) 2020 Cepheis Ltd(steve.channell@cepheis.com)
 * All rights reserved
 * 
 * This file is part of Cephei Project https://github.com/channell/Cephei
 * 
 * Cephei is open source software, you can redistribute it and/or modify it
 * under the terms of the Cephei license.  You should have received a
 * copy of the license along with this program; if not, license is
 * available at < https://github.com/channell/Cephei/LICENSE>.
 * 
 * This program is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
 * FOR A PARTICULAR PURPOSE.  See the license for more details.
 */
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
    /// CellLazy is a specialization of CellFast that always performs lazy evaluation, 
    /// irespective of the policy set by Cell.Lazy.
    /// 
    /// CellLazy is designed to be used in conjunction with with Cell fast where a number of cells depend on the result of 
    /// a long running calculation
    /// 
    /// This version of cell avoids additional logic to check for profiling or to
    /// rebind when a dependency changes.
    /// 
    /// CellFacst<> should not be used for values unless <b>every </b>dependant is know
    /// to use fast closures
    /// </summary>
    public class CellLazy<T> : ICell<T>, IFast
    {
        private FSharpFunc<Unit, T> _func;
        private SpinLock _spinLock = new SpinLock(true);
        private Lazy<ManualResetEvent> _event = new Lazy<ManualResetEvent>(() => new ManualResetEvent(false));

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

        public CellLazy(FSharpFunc<Unit, T> func)
        {
            _func = func;
            Task.Run(() =>
            {
                var dependencies = Cell.Profile(func);
                foreach (var d in dependencies)
                    if (d != this)
                        d.Notify(this);
            });
        }
        public CellLazy(FSharpFunc<Unit, T> func, ICell mutex) : this(func)
        {
            Mutex = mutex;
        }

        public CellLazy(T value)
        {
            _value = value;
            _state = (int)CellState.Clean;
        }
        /// <summary>
        /// Create a cell from C# function
        /// </summary>
        /// <param name="func">C# function</param>
        public CellLazy(Func<T> func) : this(FuncConvert.FromFunc<T>(func))
        { }
        /// <summary>
        /// Create a cell from C# function
        /// </summary>
        /// <param name="func">C# function</param>
        public CellLazy(Func<T> func, ICell mutex) : this(FuncConvert.FromFunc<T>(func), mutex)
        { }
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
                    SetState(CellState.Calculating, ref taken);

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
                    SetState(CellState.Clean, ref taken);
                    if (_pending > 0)
                    {
                        if (session != null)
                            _pending--;
                    }
                    return t;
                }
                else
                {
                    Thread.Sleep(100);
                    return Calculate(epoch, recurse + 1, session);     // edge case retry lock
                }
            }
            catch (LockRecursionException e)
            {
                Serilog.Log.Error(e, "LockRecursionException for {0} with error {1} at {2}", Mnemonic, e.Message, e.StackTrace);
                if (!taken) _spinLock.Enter(ref taken);
                SetState(CellState.Dirty, ref taken);
                throw;
            }
            catch (Exception e)
            {
                Serilog.Log.Error(e, "Calculation failed for {0} with error {1}", Mnemonic, e.Message);
                _lastException = new CalculationException(e);
                if (!taken) _spinLock.Enter(ref taken);
                SetState(CellState.Error, ref taken);
                RaiseChange(CellEvent.Error, this, null, epoch, null);

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
                            SetState(CellState.Dirty, ref taken);

                switch (_state)
                {
                    case (int)CellState.Clean:
                        var v = _value;
                        if (v == null && _lastException == null)
                        {
                            SetState(CellState.Dirty, ref taken);
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
                    case (int)CellState.Dirty:
                        _spinLock.Exit();
                        taken = false;
                        return Calculate(DateTime.Now, recurse + 1);

                    case (int)CellState.Error:
                        throw _lastException;

                    default:
                        _spinLock.Exit(true);
                        taken = false;
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
                        var ses = Session.Current;
                        _value = value;
                        _epoch = DateTime.Now;
                        SetState(CellState.Clean, ref taken);
                        if (ses != null)
                        {
                            ses.SetValue<T>(this, value);
                            RaiseChange(CellEvent.JoinSession, this, null, DateTime.Now, ses);

                        }
                        else
                            RaiseChange(CellEvent.Calculate, this, null, _epoch, ses);
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
            RaiseChange(CellEvent.Delete, this, null, DateTime.Now, null);

            Change = delegate { };
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void RaiseChange(CellEvent eventType, ICellEvent root, ICellEvent sender, DateTime epoch, ISession session)
        {
            if (sender == this) return;
            if (Change != null)
                Change(eventType, root, this, epoch, session);
            if (Parent != null && sender != this && eventType != CellEvent.CyclicCheck)
                Parent.OnChange(eventType | CellEvent.Logging, root, this, epoch, session);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Cephei.Cell.CellState SetState(CellState value, ref bool taken)
        {
            // prevent blocking on forground thread
            if (value == CellState.Dirty && !Thread.CurrentThread.IsBackground)
            {
                Task.Run(() =>
                {
                    bool taken = false;
                    SetState(CellState.Dirty, ref taken);
                });
                return CellState.Dirty;
            }
        retry: // used to enable AggressiveInlining
            var was = (CellState)Interlocked.Exchange(ref _state, (int)value);
            switch (was)
            {
                case CellState.Blocking:
                    switch (value)
                    {
                        case CellState.Clean:
                        case CellState.Error:
                            _lockHolder = null;
                            _event.Value.Set();
                            _event.Value.Reset();
                            break;
                        case CellState.Dirty:
                        case CellState.DirtyIfClean:
                        case CellState.Calculating:
                        case CellState.Blocking:
                            Interlocked.Exchange(ref _state, (int)CellState.Blocking);
                            int cnt = 0;
                            if (taken)
                            {
                                _spinLock.Exit();
                                taken = false;
                            }
                            while (_lockHolder != null && _lockHolder != Thread.CurrentThread && _lockHolder.IsAlive && _state == (int)CellState.Blocking)
                            {
                                _event.Value.WaitOne(2000);
                                if (!Cell.IO && ++cnt > 5 && _lockHolder.ThreadState == System.Threading.ThreadState.WaitSleepJoin)
                                    _lockHolder.Interrupt();
                                else
                                    cnt = 0;
                            }
                            if (_lockHolder != null)
                                goto retry; // used to enable AggressiveInlining
                            break;
                    }
                    break;
                case CellState.Calculating:
                    switch (value)
                    {
                        case CellState.Clean:
                        case CellState.Error:
                        case CellState.Dirty:
                            _lockHolder = null;
                            break;
                        case CellState.DirtyIfClean:
                        case CellState.Calculating:
                        case CellState.Blocking:
                            Interlocked.Exchange(ref _state, (int)CellState.Blocking);
                            int cnt = 0;
                            if (taken)
                            {
                                _spinLock.Exit();
                                taken = false;
                            }
                            while (_lockHolder != null && _lockHolder != Thread.CurrentThread && _lockHolder.IsAlive && _state == (int)CellState.Blocking)
                            {
                                _event.Value.WaitOne(2000);
                                if (!Cell.IO && ++cnt > 5 && _lockHolder.ThreadState == System.Threading.ThreadState.WaitSleepJoin)
                                    _lockHolder.Interrupt();
                                else
                                    cnt = 0;
                            }
                            if (_lockHolder != null)
                                goto retry; // used to enable AggressiveInlining
                            break;
                    }
                    break;
                case CellState.Clean:
                    switch (value)
                    {
                        case CellState.Clean:
                        case CellState.Error:
                        case CellState.Dirty:
                        case CellState.DirtyIfClean:
                            _lockHolder = null;
                            break;
                        case CellState.Calculating:
                        case CellState.Blocking:
                            _lockHolder = Thread.CurrentThread;
                            break;
                    }
                    break;

                case CellState.Dirty:
                    switch (value)
                    {
                        case CellState.Clean:
                        case CellState.Error:
                        case CellState.Dirty:
                            _lockHolder = null;
                            break;
                        case CellState.DirtyIfClean:
                            Interlocked.Exchange(ref _state, (int)CellState.Dirty);
                            break;

                        case CellState.Calculating:
                        case CellState.Blocking:
                            _lockHolder = Thread.CurrentThread;
                            break;
                    }
                    break;

                case CellState.Error:
                    switch (value)
                    {
                        case CellState.Clean:
                        case CellState.Error:
                        case CellState.Dirty:
                        case CellState.DirtyIfClean:
                            _lockHolder = null;
                            break;

                        case CellState.Calculating:
                        case CellState.Blocking:
                            _lockHolder = Thread.CurrentThread;
                            break;
                    }
                    break;
            }
            if (taken)
            {
                taken = false;
                _spinLock.Exit();
            }
            return was;
        }

        public virtual void OnChange(CellEvent eventType, ICellEvent root, ICellEvent sender, DateTime epoch, ISession session)
        {
            if (_disposd && root != this && eventType != CellEvent.Delete) sender.OnChange(CellEvent.Delete, this, this, epoch, session);
            bool taken = false;
            try
            {
                _spinLock.Enter(ref taken);
                if (!taken)
                {
                    Thread.Sleep(100);
                    Task.Run(() => this.OnChange(eventType, root, sender, epoch, session));
                }
                else
                {
                    switch (eventType)
                    {
                        case CellEvent.Calculate:
                            if (session != null && session.State == SessionState.Open)
                                _pending++;
                            else if (epoch > _epoch)
                            {
                                _epoch = epoch;
                                SetState(CellState.Dirty, ref taken);
                                OnChange(CellEvent.Invalidate, root, this, epoch, session);
                            }
                            break;
                        case CellEvent.Delete:
                            Change -= sender.OnChange;
                            break;
                        case CellEvent.Invalidate:
                            SetState(CellState.Dirty, ref taken);
                            RaiseChange(eventType, root, sender, epoch, session);
                            break;

                        case CellEvent.JoinSession:
                            session.Join(this);
                            _spinLock.Exit();
                            taken = false;
                            RaiseChange(eventType, root, sender, epoch, session);
                            break;

                        case CellEvent.Error:
                            SetState(CellState.Error, ref taken);
                            break;

                        case CellEvent.Link:
                            var changed = false;
                            if (Parent != null && Parent is Model m && _func != null)
                                if (Cell.Relink(_func, m, root))
                                    changed = true;
                            SetState(CellState.Dirty, ref taken);
                            if (changed)
                                RaiseChange(eventType, root, sender, epoch, session);
                            break;

                        case CellEvent.CyclicCheck:
                            _spinLock.Exit();
                            taken = false;
                            if (root == this)
                                throw new CyclicDependencyException();
                            else
                                RaiseChange(eventType, root, sender, epoch, session);
                            break;

                        default:
                            break;
                    }
                }
            }
            finally
            {
                if (taken)
                    _spinLock.Exit();
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
            bool isCurrent = true;
            bool taken = false;
            try
            {
                _spinLock.Enter(ref taken);

                if (source != this)
                {
                    var c = (ICell<T>)source;
                    var f = _func;
                    _func = c.Function;
                    c.Function = f;
                    Parent = c.Parent;
                    if (Thread.CurrentThread.IsBackground)
                        SetState(CellState.Dirty, ref taken);
                    else
                        Task.Run(() =>
                        {
                            bool taken = false;
                            SetState(CellState.Dirty, ref taken);
                        });
                }

                // handle update of current while this cell is being constructed
                if (Parent is Model m)
                {
                    ICell cur;
                    if (m.TryGetValue(this.Mnemonic, out cur))
                    {
                        if (cur != this && cur != null && cur.GetType() == this.GetType())
                        {
                            isCurrent = false;
                            cur.Merge(this, model);
                        }
                    }
                }
            }
            finally
            {
                if (taken)
                    _spinLock.Exit();
            }
            if (isCurrent)
            {
                RaiseChange(CellEvent.CyclicCheck, this, null, DateTime.Now, null);
                Task.Run(() => RaiseChange(CellEvent.Calculate, this, null, DateTime.Now, null));
            }
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
            bool taken = false;
            SetState(CellState.Error, ref taken);
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

            bool taken = false;
            try
            {
                _spinLock.Enter(ref taken);
                if (listener != null)
                    Change += listener.OnChange;
            }
            finally
            {
                _spinLock.Exit();
            }
        }

        public void UnNotify(ICell listener)
        {
            bool taken = false;
            try
            {
                _spinLock.Enter(ref taken);
                if (listener != null)
                    Change -= listener.OnChange;
            }
            finally
            {
                if (taken) _spinLock.Exit();
            }
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
