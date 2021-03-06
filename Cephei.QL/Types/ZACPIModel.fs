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
  South African CPI index

  </summary> *)
[<AutoSerializable(true)>]
type ZACPIModel
    ( interpolated                                 : ICell<bool>
    ) as this =

    inherit Model<ZACPI> ()
(*
    Parameters
*)
    let _interpolated                              = interpolated
(*
    Functions
*)
    let mutable
        _ZACPI                                     = make (fun () -> new ZACPI (interpolated.Value))
    let _clone                                     (h : ICell<Handle<ZeroInflationTermStructure>>)   
                                                   = triv _ZACPI (fun () -> _ZACPI.Value.clone(h.Value))
    let _fixing                                    (aFixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = triv _ZACPI (fun () -> _ZACPI.Value.fixing(aFixingDate.Value, forecastTodaysFixing.Value))
    let _zeroInflationTermStructure                = triv _ZACPI (fun () -> _ZACPI.Value.zeroInflationTermStructure())
    let _addFixing                                 (fixingDate : ICell<Date>) (fixing : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = triv _ZACPI (fun () -> _ZACPI.Value.addFixing(fixingDate.Value, fixing.Value, forceOverwrite.Value)
                                                                            _ZACPI.Value)
    let _availabilityLag                           = triv _ZACPI (fun () -> _ZACPI.Value.availabilityLag())
    let _currency                                  = triv _ZACPI (fun () -> _ZACPI.Value.currency())
    let _familyName                                = triv _ZACPI (fun () -> _ZACPI.Value.familyName())
    let _fixingCalendar                            = triv _ZACPI (fun () -> _ZACPI.Value.fixingCalendar())
    let _frequency                                 = triv _ZACPI (fun () -> _ZACPI.Value.frequency())
    let _interpolated                              = triv _ZACPI (fun () -> _ZACPI.Value.interpolated())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = triv _ZACPI (fun () -> _ZACPI.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = triv _ZACPI (fun () -> _ZACPI.Value.name())
    let _region                                    = triv _ZACPI (fun () -> _ZACPI.Value.region())
    let _revised                                   = triv _ZACPI (fun () -> _ZACPI.Value.revised())
    let _update                                    = triv _ZACPI (fun () -> _ZACPI.Value.update()
                                                                            _ZACPI.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = triv _ZACPI (fun () -> _ZACPI.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                            _ZACPI.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = triv _ZACPI (fun () -> _ZACPI.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                            _ZACPI.Value)
    let _allowsNativeFixings                       = triv _ZACPI (fun () -> _ZACPI.Value.allowsNativeFixings())
    let _clearFixings                              = triv _ZACPI (fun () -> _ZACPI.Value.clearFixings()
                                                                            _ZACPI.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _ZACPI (fun () -> _ZACPI.Value.registerWith(handler.Value)
                                                                            _ZACPI.Value)
    let _timeSeries                                = triv _ZACPI (fun () -> _ZACPI.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _ZACPI (fun () -> _ZACPI.Value.unregisterWith(handler.Value)
                                                                            _ZACPI.Value)
    do this.Bind(_ZACPI)
(* 
    casting 
*)
    internal new () = new ZACPIModel(null)
    member internal this.Inject v = _ZACPI <- v
    static member Cast (p : ICell<ZACPI>) = 
        if p :? ZACPIModel then 
            p :?> ZACPIModel
        else
            let o = new ZACPIModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.interpolated                       = _interpolated 
    member this.Clone                              h   
                                                   = _clone h 
    member this.Fixing                             aFixingDate forecastTodaysFixing   
                                                   = _fixing aFixingDate forecastTodaysFixing 
    member this.ZeroInflationTermStructure         = _zeroInflationTermStructure
    member this.AddFixing                          fixingDate fixing forceOverwrite   
                                                   = _addFixing fixingDate fixing forceOverwrite 
    member this.AvailabilityLag                    = _availabilityLag
    member this.Currency                           = _currency
    member this.FamilyName                         = _familyName
    member this.FixingCalendar                     = _fixingCalendar
    member this.Frequency                          = _frequency
    member this.Interpolated                       = _interpolated
    member this.IsValidFixingDate                  fixingDate   
                                                   = _isValidFixingDate fixingDate 
    member this.Name                               = _name
    member this.Region                             = _region
    member this.Revised                            = _revised
    member this.Update                             = _update
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
  South African CPI index

  </summary> *)
[<AutoSerializable(true)>]
type ZACPIModel1
    ( interpolated                                 : ICell<bool>
    , ts                                           : ICell<Handle<ZeroInflationTermStructure>>
    ) as this =

    inherit Model<ZACPI> ()
(*
    Parameters
*)
    let _interpolated                              = interpolated
    let _ts                                        = ts
(*
    Functions
*)
    let mutable
        _ZACPI                                     = make (fun () -> new ZACPI (interpolated.Value, ts.Value))
    let _clone                                     (h : ICell<Handle<ZeroInflationTermStructure>>)   
                                                   = triv _ZACPI (fun () -> _ZACPI.Value.clone(h.Value))
    let _fixing                                    (aFixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = triv _ZACPI (fun () -> _ZACPI.Value.fixing(aFixingDate.Value, forecastTodaysFixing.Value))
    let _zeroInflationTermStructure                = triv _ZACPI (fun () -> _ZACPI.Value.zeroInflationTermStructure())
    let _addFixing                                 (fixingDate : ICell<Date>) (fixing : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = triv _ZACPI (fun () -> _ZACPI.Value.addFixing(fixingDate.Value, fixing.Value, forceOverwrite.Value)
                                                                            _ZACPI.Value)
    let _availabilityLag                           = triv _ZACPI (fun () -> _ZACPI.Value.availabilityLag())
    let _currency                                  = triv _ZACPI (fun () -> _ZACPI.Value.currency())
    let _familyName                                = triv _ZACPI (fun () -> _ZACPI.Value.familyName())
    let _fixingCalendar                            = triv _ZACPI (fun () -> _ZACPI.Value.fixingCalendar())
    let _frequency                                 = triv _ZACPI (fun () -> _ZACPI.Value.frequency())
    let _interpolated                              = triv _ZACPI (fun () -> _ZACPI.Value.interpolated())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = triv _ZACPI (fun () -> _ZACPI.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = triv _ZACPI (fun () -> _ZACPI.Value.name())
    let _region                                    = triv _ZACPI (fun () -> _ZACPI.Value.region())
    let _revised                                   = triv _ZACPI (fun () -> _ZACPI.Value.revised())
    let _update                                    = triv _ZACPI (fun () -> _ZACPI.Value.update()
                                                                            _ZACPI.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = triv _ZACPI (fun () -> _ZACPI.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                            _ZACPI.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = triv _ZACPI (fun () -> _ZACPI.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                            _ZACPI.Value)
    let _allowsNativeFixings                       = triv _ZACPI (fun () -> _ZACPI.Value.allowsNativeFixings())
    let _clearFixings                              = triv _ZACPI (fun () -> _ZACPI.Value.clearFixings()
                                                                            _ZACPI.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _ZACPI (fun () -> _ZACPI.Value.registerWith(handler.Value)
                                                                            _ZACPI.Value)
    let _timeSeries                                = triv _ZACPI (fun () -> _ZACPI.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _ZACPI (fun () -> _ZACPI.Value.unregisterWith(handler.Value)
                                                                            _ZACPI.Value)
    do this.Bind(_ZACPI)
(* 
    casting 
*)
    internal new () = new ZACPIModel1(null,null)
    member internal this.Inject v = _ZACPI <- v
    static member Cast (p : ICell<ZACPI>) = 
        if p :? ZACPIModel1 then 
            p :?> ZACPIModel1
        else
            let o = new ZACPIModel1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.interpolated                       = _interpolated 
    member this.ts                                 = _ts 
    member this.Clone                              h   
                                                   = _clone h 
    member this.Fixing                             aFixingDate forecastTodaysFixing   
                                                   = _fixing aFixingDate forecastTodaysFixing 
    member this.ZeroInflationTermStructure         = _zeroInflationTermStructure
    member this.AddFixing                          fixingDate fixing forceOverwrite   
                                                   = _addFixing fixingDate fixing forceOverwrite 
    member this.AvailabilityLag                    = _availabilityLag
    member this.Currency                           = _currency
    member this.FamilyName                         = _familyName
    member this.FixingCalendar                     = _fixingCalendar
    member this.Frequency                          = _frequency
    member this.Interpolated                       = _interpolated
    member this.IsValidFixingDate                  fixingDate   
                                                   = _isValidFixingDate fixingDate 
    member this.Name                               = _name
    member this.Region                             = _region
    member this.Revised                            = _revised
    member this.Update                             = _update
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
