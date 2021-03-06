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
using Serilog;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Cephei.Cell
{
    internal class ModelObserver : IDisposable, ICellEvent
    {
        Model  _source;
        IObserver<ICell> _target;
        internal ModelObserver(Model source, IObserver<ICell> target)
        {
            _source = source;
            _target = target;

            source.Listen += OnChange;
        }

        public void OnChange(CellEvent eventType, ICellEvent root, ICellEvent sender, DateTime epoch, ISession session)
        {
            switch (eventType)
            {
                case CellEvent.Calculate:
                case CellEvent.CalculateLogging:
                    _target.OnNext((ICell)root);
                    break;

                case CellEvent.Delete:
                case CellEvent.DeleteLogging:
                    _target.OnCompleted();
                    break;

                case CellEvent.Error:
                case CellEvent.ErrorLogging:
                    try
                    {
                        _target.OnNext((ICell)root);
                    }
                    catch (Exception e)
                    {
                        _target.OnError(e);
                    }
                    break;
                default:
                    break;
            }
        }

        public void Dispose()
        {
            _source.Listen -= OnChange;
        }
        public ICell Parent 
        { 
            get
            {
                return null;
            }
            set
            {

            }
        }

    }
    internal class ModelCellObserver<T> : IDisposable
    {
        Model _source;
        IObserver<KeyValuePair<string, T>> _target;
        internal ModelCellObserver(Model source, IObserver<KeyValuePair<string, T>> target)
        {
            _source = source;
            _target = target;

            source.Listen += OnChange;
        }

        private void OnChange(CellEvent eventType, ICellEvent root, ICellEvent sender, DateTime epoch, ISession session)
        {
            var c = root as Generic.ICell<T>;
            if (c != null)
            {
                switch (eventType)
                {
                    case CellEvent.Calculate:
                    case CellEvent.CalculateLogging:
                        _target.OnNext(new KeyValuePair<string, T>(c.Mnemonic, c.Value));
                        break;

                    case CellEvent.Delete:
                    case CellEvent.DeleteLogging:
                        _target.OnCompleted();
                        break;

                    case CellEvent.Error:
                    case CellEvent.ErrorLogging:
                        try
                        {
                            _target.OnNext(new KeyValuePair<string, T>(c.Mnemonic, c.Value));
                        }
                        catch (Exception e)
                        {
                            _target.OnError(e);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public void Dispose()
        {
            _source.Listen -= OnChange;
        }
    }


    internal class ModelSessionObserver : IDisposable
    {
        Model _source;
        IObserver<KeyValuePair<ISession, KeyValuePair<string, ICell>>> _target;
        internal ModelSessionObserver(Model source, IObserver<KeyValuePair<ISession, KeyValuePair<string,ICell>>> target)
        {
            _source = source;
            _target = target;

            source.Listen += OnChange;
        }

        private void OnChange(CellEvent eventType, ICellEvent root, ICellEvent sender, DateTime epoch, ISession session)
        {
            switch (eventType)
            {
                case CellEvent.Calculate:
                case CellEvent.CalculateLogging:
                    var lastsession = Session.Current;
                    Session.Current = session;
                    ICell c = ((ICell)root).Parent;
                    string n = ((ICell)root).Mnemonic;
                    while (c != null)
                    {
                        n = c.Mnemonic + "|" + n;
                        c = c.Parent;
                    }
                    _target.OnNext(new KeyValuePair<ISession, KeyValuePair<string,ICell>>(session, new KeyValuePair<string, ICell>(n,(ICell)sender)));
                    Session.Current = lastsession;
                    break;

                case CellEvent.Delete:
                case CellEvent.DeleteLogging:
                    _target.OnCompleted();
                    break;

                case CellEvent.Error:
                case CellEvent.ErrorLogging:
                    try
                    {
                        c = ((ICell)sender).Parent;
                        n = ((ICell)sender).Mnemonic;
                        while (c != null)
                        {
                            n = c.Mnemonic + "|" + n;
                            c = c.Parent;
                        }
                        _target.OnNext(new KeyValuePair<ISession, KeyValuePair<string, ICell>>(session, new KeyValuePair<string, ICell>(n, (ICell)sender)));
                    }
                    catch (Exception e)
                    {
                        _target.OnError(e);
                    }
                    break;
                default:
                    break;
            }
        }

        public void Dispose()
        {
            _source.Change -= OnChange;
        }
    }

    internal class ModelTraceObserver : IDisposable
    {
        Model _source;
        IObserver<Tuple<ISession, Model, CellEvent, ICell, DateTime>> _target;
        internal ModelTraceObserver(Model source, IObserver<Tuple<ISession, Model, CellEvent, ICell, DateTime>> target)
        {
            _source = source;
            _target = target;

            source.Listen += OnChange;
        }

        private void OnChange(CellEvent eventType, ICellEvent root, ICellEvent sender, DateTime epoch, ISession session)
        {
            switch (eventType)
            {
                case CellEvent.Invalidate:
                case CellEvent.Delete:
                case CellEvent.JoinSession:
                case CellEvent.Link:
                case CellEvent.Calculate:
                case CellEvent.InvalidateLogging:
                case CellEvent.DeleteLogging:
                case CellEvent.JoinSessionLogging:
                case CellEvent.LinkLogging:
                case CellEvent.CalculateLogging:
                    _target.OnNext(new Tuple<ISession, Model, CellEvent, ICell, DateTime>(session, _source, eventType, (ICell)root, epoch));
                    break;

                case CellEvent.Error:
                case CellEvent.ErrorLogging:
                    try
                    {
                        _target.OnNext(new Tuple<ISession, Model, CellEvent, ICell, DateTime>(session, _source, eventType, (ICell)root, epoch));
                    }
                    catch (Exception e)
                    {
                        _target.OnError(e);
                    }
                    break;
                default:
                    break;
            }
        }

        public void Dispose()
        {
            _source.Listen -= OnChange;
        }
    }

    public class ModelTraceSubscriber : IObserver<Tuple<ISession, Model, CellEvent, ICell, DateTime>>, IDisposable
    {
        IDisposable listener;
        string printline;
        FSharpFunc<ICell, string> _formater;
        public ModelTraceSubscriber(Model source, FSharpFunc<ICell, string> formater, string prefix = "")
        {
            listener = source.Subscribe(this);
            printline = "Observed " + prefix + source.Mnemonic + " : {0}";
            _formater = formater;
        }
        
        public void OnCompleted()
        {
            Log.Verbose("{0} Complete", printline);
        }

        public void OnError(Exception error)
        {
            Log.Error(error, "{0} Error {1}", error.Message);
        }

        public void OnNext(Tuple<ISession, Model, CellEvent, ICell, DateTime> value)
        {
            Log.Verbose("Session {0} Cell {1} Value {2} Event {3} Source {4} Epoch {5}", value.Item1, value.Item2.Mnemonic, _formater.Invoke(value.Item4), value.Item3, value.Item4, value.Item5);
        }

        public void Dispose()
        {
            listener.Dispose();
            GC.SuppressFinalize(this);
        }
        ~ModelTraceSubscriber()
        {
            listener.Dispose();
        }
    }
}
