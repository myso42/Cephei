﻿(*
Copyright (C) 2020 Cepheis Ltd (steve.channell@cepheis.com)

This file is part of Cephei.QL Project https://github.com/channell/Cephei

Cephei.QL is open source software based on QLNet  you can redistribute it and/or modify it
under the terms of the Cephei.QL license.  You should have received a
copy of the license along with this program; if not, license is
available at <https://github.com/channell/Cephei/LICENSE>.

QLNet is a based on QuantLib, a free-software/open-source library
for financial quantitative analysts and developers - http://quantlib.org/
The QuantLib license is available online at http://quantlib.org/license.shtml.

This program is distributed in the hope that it will be useful, but WITHOUT
ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
FOR A PARTICULAR PURPOSE.  See the license for more details.
*)
namespace Cephei.QL

open System
open Cephei.QL.Util
open Cephei.Cell
open Cephei.Cell.Generic
open System.Collections
open System.Collections.Generic
open QLNet
open Cephei.QLNetHelper

(* <summary>

! %Sonia (Sterling Overnight Index Average) rate.
  </summary> *)
[<AutoSerializable(true)>]
type SoniaModel
    ( h                                            : ICell<Handle<YieldTermStructure>>
    ) as this =

    inherit Model<Sonia> ()
(*
    Parameters
*)
    let _h                                         = h
(*
    Functions
*)
    let mutable
        _Sonia                                     = make (fun () -> new Sonia (h.Value))
    let _clone                                     (h : ICell<Handle<YieldTermStructure>>)   
                                                   = triv _Sonia (fun () -> _Sonia.Value.clone(h.Value))
    let _businessDayConvention                     = triv _Sonia (fun () -> _Sonia.Value.businessDayConvention())
    let _endOfMonth                                = triv _Sonia (fun () -> _Sonia.Value.endOfMonth())
    let _forecastFixing                            (fixingDate : ICell<Date>)   
                                                   = triv _Sonia (fun () -> _Sonia.Value.forecastFixing(fixingDate.Value))
    let _forecastFixing1                           (d1 : ICell<Date>) (d2 : ICell<Date>) (t : ICell<double>)   
                                                   = triv _Sonia (fun () -> _Sonia.Value.forecastFixing(d1.Value, d2.Value, t.Value))
    let _forwardingTermStructure                   = triv _Sonia (fun () -> _Sonia.Value.forwardingTermStructure())
    let _maturityDate                              (valueDate : ICell<Date>)   
                                                   = triv _Sonia (fun () -> _Sonia.Value.maturityDate(valueDate.Value))
    let _currency                                  = triv _Sonia (fun () -> _Sonia.Value.currency())
    let _dayCounter                                = triv _Sonia (fun () -> _Sonia.Value.dayCounter())
    let _familyName                                = triv _Sonia (fun () -> _Sonia.Value.familyName())
    let _fixing                                    (fixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = triv _Sonia (fun () -> _Sonia.Value.fixing(fixingDate.Value, forecastTodaysFixing.Value))
    let _fixingCalendar                            = triv _Sonia (fun () -> _Sonia.Value.fixingCalendar())
    let _fixingDate                                (valueDate : ICell<Date>)   
                                                   = triv _Sonia (fun () -> _Sonia.Value.fixingDate(valueDate.Value))
    let _fixingDays                                = triv _Sonia (fun () -> _Sonia.Value.fixingDays())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = triv _Sonia (fun () -> _Sonia.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = triv _Sonia (fun () -> _Sonia.Value.name())
    let _pastFixing                                (fixingDate : ICell<Date>)   
                                                   = triv _Sonia (fun () -> _Sonia.Value.pastFixing(fixingDate.Value))
    let _tenor                                     = triv _Sonia (fun () -> _Sonia.Value.tenor())
    let _update                                    = triv _Sonia (fun () -> _Sonia.Value.update()
                                                                            _Sonia.Value)
    let _valueDate                                 (fixingDate : ICell<Date>)   
                                                   = triv _Sonia (fun () -> _Sonia.Value.valueDate(fixingDate.Value))
    let _addFixing                                 (d : ICell<Date>) (v : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = triv _Sonia (fun () -> _Sonia.Value.addFixing(d.Value, v.Value, forceOverwrite.Value)
                                                                            _Sonia.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = triv _Sonia (fun () -> _Sonia.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                            _Sonia.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = triv _Sonia (fun () -> _Sonia.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                            _Sonia.Value)
    let _allowsNativeFixings                       = triv _Sonia (fun () -> _Sonia.Value.allowsNativeFixings())
    let _clearFixings                              = triv _Sonia (fun () -> _Sonia.Value.clearFixings()
                                                                            _Sonia.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _Sonia (fun () -> _Sonia.Value.registerWith(handler.Value)
                                                                            _Sonia.Value)
    let _timeSeries                                = triv _Sonia (fun () -> _Sonia.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _Sonia (fun () -> _Sonia.Value.unregisterWith(handler.Value)
                                                                            _Sonia.Value)
    do this.Bind(_Sonia)
(* 
    casting 
*)
    internal new () = new SoniaModel(null)
    member internal this.Inject v = _Sonia <- v
    static member Cast (p : ICell<Sonia>) = 
        if p :? SoniaModel then 
            p :?> SoniaModel
        else
            let o = new SoniaModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.h                                  = _h 
    member this.Clone                              h   
                                                   = _clone h 
    member this.BusinessDayConvention              = _businessDayConvention
    member this.EndOfMonth                         = _endOfMonth
    member this.ForecastFixing                     fixingDate   
                                                   = _forecastFixing fixingDate 
    member this.ForecastFixing1                    d1 d2 t   
                                                   = _forecastFixing1 d1 d2 t 
    member this.ForwardingTermStructure            = _forwardingTermStructure
    member this.MaturityDate                       valueDate   
                                                   = _maturityDate valueDate 
    member this.Currency                           = _currency
    member this.DayCounter                         = _dayCounter
    member this.FamilyName                         = _familyName
    member this.Fixing                             fixingDate forecastTodaysFixing   
                                                   = _fixing fixingDate forecastTodaysFixing 
    member this.FixingCalendar                     = _fixingCalendar
    member this.FixingDate                         valueDate   
                                                   = _fixingDate valueDate 
    member this.FixingDays                         = _fixingDays
    member this.IsValidFixingDate                  fixingDate   
                                                   = _isValidFixingDate fixingDate 
    member this.Name                               = _name
    member this.PastFixing                         fixingDate   
                                                   = _pastFixing fixingDate 
    member this.Tenor                              = _tenor
    member this.Update                             = _update
    member this.ValueDate                          fixingDate   
                                                   = _valueDate fixingDate 
    member this.AddFixing                          d v forceOverwrite   
                                                   = _addFixing d v forceOverwrite 
    member this.AddFixings                         d v forceOverwrite   
                                                   = _addFixings d v forceOverwrite 
    member this.AddFixings1                        source forceOverwrite   
                                                   = _addFixings1 source forceOverwrite 
    member this.AllowsNativeFixings                = _allowsNativeFixings
    member this.ClearFixings                       = _clearFixings
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.TimeSeries                         = _timeSeries
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
