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
  10-months %EUR %Libor index

  </summary> *)
[<AutoSerializable(true)>]
type EURLibor10MModel
    () as this =
    inherit Model<EURLibor10M> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _EURLibor10M                               = make (fun () -> new EURLibor10M ())
    let _maturityDate                              (valueDate : ICell<Date>)   
                                                   = triv _EURLibor10M (fun () -> _EURLibor10M.Value.maturityDate(valueDate.Value))
    let _valueDate                                 (fixingDate : ICell<Date>)   
                                                   = triv _EURLibor10M (fun () -> _EURLibor10M.Value.valueDate(fixingDate.Value))
    let _businessDayConvention                     = triv _EURLibor10M (fun () -> _EURLibor10M.Value.businessDayConvention())
    let _clone                                     (forwarding : ICell<Handle<YieldTermStructure>>)   
                                                   = triv _EURLibor10M (fun () -> _EURLibor10M.Value.clone(forwarding.Value))
    let _endOfMonth                                = triv _EURLibor10M (fun () -> _EURLibor10M.Value.endOfMonth())
    let _forecastFixing                            (fixingDate : ICell<Date>)   
                                                   = triv _EURLibor10M (fun () -> _EURLibor10M.Value.forecastFixing(fixingDate.Value))
    let _forecastFixing1                           (d1 : ICell<Date>) (d2 : ICell<Date>) (t : ICell<double>)   
                                                   = triv _EURLibor10M (fun () -> _EURLibor10M.Value.forecastFixing(d1.Value, d2.Value, t.Value))
    let _forwardingTermStructure                   = triv _EURLibor10M (fun () -> _EURLibor10M.Value.forwardingTermStructure())
    let _currency                                  = triv _EURLibor10M (fun () -> _EURLibor10M.Value.currency())
    let _dayCounter                                = triv _EURLibor10M (fun () -> _EURLibor10M.Value.dayCounter())
    let _familyName                                = triv _EURLibor10M (fun () -> _EURLibor10M.Value.familyName())
    let _fixing                                    (fixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = triv _EURLibor10M (fun () -> _EURLibor10M.Value.fixing(fixingDate.Value, forecastTodaysFixing.Value))
    let _fixingCalendar                            = triv _EURLibor10M (fun () -> _EURLibor10M.Value.fixingCalendar())
    let _fixingDate                                (valueDate : ICell<Date>)   
                                                   = triv _EURLibor10M (fun () -> _EURLibor10M.Value.fixingDate(valueDate.Value))
    let _fixingDays                                = triv _EURLibor10M (fun () -> _EURLibor10M.Value.fixingDays())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = triv _EURLibor10M (fun () -> _EURLibor10M.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = triv _EURLibor10M (fun () -> _EURLibor10M.Value.name())
    let _pastFixing                                (fixingDate : ICell<Date>)   
                                                   = triv _EURLibor10M (fun () -> _EURLibor10M.Value.pastFixing(fixingDate.Value))
    let _tenor                                     = triv _EURLibor10M (fun () -> _EURLibor10M.Value.tenor())
    let _update                                    = triv _EURLibor10M (fun () -> _EURLibor10M.Value.update()
                                                                                  _EURLibor10M.Value)
    let _addFixing                                 (d : ICell<Date>) (v : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = triv _EURLibor10M (fun () -> _EURLibor10M.Value.addFixing(d.Value, v.Value, forceOverwrite.Value)
                                                                                  _EURLibor10M.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = triv _EURLibor10M (fun () -> _EURLibor10M.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                                  _EURLibor10M.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = triv _EURLibor10M (fun () -> _EURLibor10M.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                                  _EURLibor10M.Value)
    let _allowsNativeFixings                       = triv _EURLibor10M (fun () -> _EURLibor10M.Value.allowsNativeFixings())
    let _clearFixings                              = triv _EURLibor10M (fun () -> _EURLibor10M.Value.clearFixings()
                                                                                  _EURLibor10M.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _EURLibor10M (fun () -> _EURLibor10M.Value.registerWith(handler.Value)
                                                                                  _EURLibor10M.Value)
    let _timeSeries                                = triv _EURLibor10M (fun () -> _EURLibor10M.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _EURLibor10M (fun () -> _EURLibor10M.Value.unregisterWith(handler.Value)
                                                                                  _EURLibor10M.Value)
    do this.Bind(_EURLibor10M)
(* 
    casting 
*)
    
    member internal this.Inject v = _EURLibor10M <- v
    static member Cast (p : ICell<EURLibor10M>) = 
        if p :? EURLibor10MModel then 
            p :?> EURLibor10MModel
        else
            let o = new EURLibor10MModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.MaturityDate                       valueDate   
                                                   = _maturityDate valueDate 
    member this.ValueDate                          fixingDate   
                                                   = _valueDate fixingDate 
    member this.BusinessDayConvention              = _businessDayConvention
    member this.Clone                              forwarding   
                                                   = _clone forwarding 
    member this.EndOfMonth                         = _endOfMonth
    member this.ForecastFixing                     fixingDate   
                                                   = _forecastFixing fixingDate 
    member this.ForecastFixing1                    d1 d2 t   
                                                   = _forecastFixing1 d1 d2 t 
    member this.ForwardingTermStructure            = _forwardingTermStructure
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
(* <summary>
  10-months %EUR %Libor index

  </summary> *)
[<AutoSerializable(true)>]
type EURLibor10MModel1
    ( h                                            : ICell<Handle<YieldTermStructure>>
    ) as this =

    inherit Model<EURLibor10M> ()
(*
    Parameters
*)
    let _h                                         = h
(*
    Functions
*)
    let mutable
        _EURLibor10M                               = make (fun () -> new EURLibor10M (h.Value))
    let _maturityDate                              (valueDate : ICell<Date>)   
                                                   = triv _EURLibor10M (fun () -> _EURLibor10M.Value.maturityDate(valueDate.Value))
    let _valueDate                                 (fixingDate : ICell<Date>)   
                                                   = triv _EURLibor10M (fun () -> _EURLibor10M.Value.valueDate(fixingDate.Value))
    let _businessDayConvention                     = triv _EURLibor10M (fun () -> _EURLibor10M.Value.businessDayConvention())
    let _clone                                     (forwarding : ICell<Handle<YieldTermStructure>>)   
                                                   = triv _EURLibor10M (fun () -> _EURLibor10M.Value.clone(forwarding.Value))
    let _endOfMonth                                = triv _EURLibor10M (fun () -> _EURLibor10M.Value.endOfMonth())
    let _forecastFixing                            (fixingDate : ICell<Date>)   
                                                   = triv _EURLibor10M (fun () -> _EURLibor10M.Value.forecastFixing(fixingDate.Value))
    let _forecastFixing1                           (d1 : ICell<Date>) (d2 : ICell<Date>) (t : ICell<double>)   
                                                   = triv _EURLibor10M (fun () -> _EURLibor10M.Value.forecastFixing(d1.Value, d2.Value, t.Value))
    let _forwardingTermStructure                   = triv _EURLibor10M (fun () -> _EURLibor10M.Value.forwardingTermStructure())
    let _currency                                  = triv _EURLibor10M (fun () -> _EURLibor10M.Value.currency())
    let _dayCounter                                = triv _EURLibor10M (fun () -> _EURLibor10M.Value.dayCounter())
    let _familyName                                = triv _EURLibor10M (fun () -> _EURLibor10M.Value.familyName())
    let _fixing                                    (fixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = triv _EURLibor10M (fun () -> _EURLibor10M.Value.fixing(fixingDate.Value, forecastTodaysFixing.Value))
    let _fixingCalendar                            = triv _EURLibor10M (fun () -> _EURLibor10M.Value.fixingCalendar())
    let _fixingDate                                (valueDate : ICell<Date>)   
                                                   = triv _EURLibor10M (fun () -> _EURLibor10M.Value.fixingDate(valueDate.Value))
    let _fixingDays                                = triv _EURLibor10M (fun () -> _EURLibor10M.Value.fixingDays())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = triv _EURLibor10M (fun () -> _EURLibor10M.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = triv _EURLibor10M (fun () -> _EURLibor10M.Value.name())
    let _pastFixing                                (fixingDate : ICell<Date>)   
                                                   = triv _EURLibor10M (fun () -> _EURLibor10M.Value.pastFixing(fixingDate.Value))
    let _tenor                                     = triv _EURLibor10M (fun () -> _EURLibor10M.Value.tenor())
    let _update                                    = triv _EURLibor10M (fun () -> _EURLibor10M.Value.update()
                                                                                  _EURLibor10M.Value)
    let _addFixing                                 (d : ICell<Date>) (v : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = triv _EURLibor10M (fun () -> _EURLibor10M.Value.addFixing(d.Value, v.Value, forceOverwrite.Value)
                                                                                  _EURLibor10M.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = triv _EURLibor10M (fun () -> _EURLibor10M.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                                  _EURLibor10M.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = triv _EURLibor10M (fun () -> _EURLibor10M.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                                  _EURLibor10M.Value)
    let _allowsNativeFixings                       = triv _EURLibor10M (fun () -> _EURLibor10M.Value.allowsNativeFixings())
    let _clearFixings                              = triv _EURLibor10M (fun () -> _EURLibor10M.Value.clearFixings()
                                                                                  _EURLibor10M.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _EURLibor10M (fun () -> _EURLibor10M.Value.registerWith(handler.Value)
                                                                                  _EURLibor10M.Value)
    let _timeSeries                                = triv _EURLibor10M (fun () -> _EURLibor10M.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _EURLibor10M (fun () -> _EURLibor10M.Value.unregisterWith(handler.Value)
                                                                                  _EURLibor10M.Value)
    do this.Bind(_EURLibor10M)
(* 
    casting 
*)
    internal new () = new EURLibor10MModel1(null)
    member internal this.Inject v = _EURLibor10M <- v
    static member Cast (p : ICell<EURLibor10M>) = 
        if p :? EURLibor10MModel1 then 
            p :?> EURLibor10MModel1
        else
            let o = new EURLibor10MModel1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.h                                  = _h 
    member this.MaturityDate                       valueDate   
                                                   = _maturityDate valueDate 
    member this.ValueDate                          fixingDate   
                                                   = _valueDate fixingDate 
    member this.BusinessDayConvention              = _businessDayConvention
    member this.Clone                              forwarding   
                                                   = _clone forwarding 
    member this.EndOfMonth                         = _endOfMonth
    member this.ForecastFixing                     fixingDate   
                                                   = _forecastFixing fixingDate 
    member this.ForecastFixing1                    d1 d2 t   
                                                   = _forecastFixing1 d1 d2 t 
    member this.ForwardingTermStructure            = _forwardingTermStructure
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
