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
  Fake year-on-year UK RPI (i.e. a ratio of UK RPI)

  </summary> *)
[<AutoSerializable(true)>]
type YYUKRPIrModel
    ( interpolated                                 : ICell<bool>
    ) as this =

    inherit Model<YYUKRPIr> ()
(*
    Parameters
*)
    let _interpolated                              = interpolated
(*
    Functions
*)
    let mutable
        _YYUKRPIr                                  = make (fun () -> new YYUKRPIr (interpolated.Value))
    let _clone                                     (h : ICell<Handle<YoYInflationTermStructure>>)   
                                                   = triv _YYUKRPIr (fun () -> _YYUKRPIr.Value.clone(h.Value))
    let _fixing                                    (fixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = triv _YYUKRPIr (fun () -> _YYUKRPIr.Value.fixing(fixingDate.Value, forecastTodaysFixing.Value))
    let _ratio                                     = triv _YYUKRPIr (fun () -> _YYUKRPIr.Value.ratio())
    let _yoyInflationTermStructure                 = triv _YYUKRPIr (fun () -> _YYUKRPIr.Value.yoyInflationTermStructure())
    let _addFixing                                 (fixingDate : ICell<Date>) (fixing : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = triv _YYUKRPIr (fun () -> _YYUKRPIr.Value.addFixing(fixingDate.Value, fixing.Value, forceOverwrite.Value)
                                                                               _YYUKRPIr.Value)
    let _availabilityLag                           = triv _YYUKRPIr (fun () -> _YYUKRPIr.Value.availabilityLag())
    let _currency                                  = triv _YYUKRPIr (fun () -> _YYUKRPIr.Value.currency())
    let _familyName                                = triv _YYUKRPIr (fun () -> _YYUKRPIr.Value.familyName())
    let _fixingCalendar                            = triv _YYUKRPIr (fun () -> _YYUKRPIr.Value.fixingCalendar())
    let _frequency                                 = triv _YYUKRPIr (fun () -> _YYUKRPIr.Value.frequency())
    let _interpolated                              = triv _YYUKRPIr (fun () -> _YYUKRPIr.Value.interpolated())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = triv _YYUKRPIr (fun () -> _YYUKRPIr.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = triv _YYUKRPIr (fun () -> _YYUKRPIr.Value.name())
    let _region                                    = triv _YYUKRPIr (fun () -> _YYUKRPIr.Value.region())
    let _revised                                   = triv _YYUKRPIr (fun () -> _YYUKRPIr.Value.revised())
    let _update                                    = triv _YYUKRPIr (fun () -> _YYUKRPIr.Value.update()
                                                                               _YYUKRPIr.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = triv _YYUKRPIr (fun () -> _YYUKRPIr.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                               _YYUKRPIr.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = triv _YYUKRPIr (fun () -> _YYUKRPIr.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                               _YYUKRPIr.Value)
    let _allowsNativeFixings                       = triv _YYUKRPIr (fun () -> _YYUKRPIr.Value.allowsNativeFixings())
    let _clearFixings                              = triv _YYUKRPIr (fun () -> _YYUKRPIr.Value.clearFixings()
                                                                               _YYUKRPIr.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _YYUKRPIr (fun () -> _YYUKRPIr.Value.registerWith(handler.Value)
                                                                               _YYUKRPIr.Value)
    let _timeSeries                                = triv _YYUKRPIr (fun () -> _YYUKRPIr.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _YYUKRPIr (fun () -> _YYUKRPIr.Value.unregisterWith(handler.Value)
                                                                               _YYUKRPIr.Value)
    do this.Bind(_YYUKRPIr)
(* 
    casting 
*)
    internal new () = new YYUKRPIrModel(null)
    member internal this.Inject v = _YYUKRPIr <- v
    static member Cast (p : ICell<YYUKRPIr>) = 
        if p :? YYUKRPIrModel then 
            p :?> YYUKRPIrModel
        else
            let o = new YYUKRPIrModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.interpolated                       = _interpolated 
    member this.Clone                              h   
                                                   = _clone h 
    member this.Fixing                             fixingDate forecastTodaysFixing   
                                                   = _fixing fixingDate forecastTodaysFixing 
    member this.Ratio                              = _ratio
    member this.YoyInflationTermStructure          = _yoyInflationTermStructure
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
  Fake year-on-year UK RPI (i.e. a ratio of UK RPI)

  </summary> *)
[<AutoSerializable(true)>]
type YYUKRPIrModel1
    ( interpolated                                 : ICell<bool>
    , ts                                           : ICell<Handle<YoYInflationTermStructure>>
    ) as this =

    inherit Model<YYUKRPIr> ()
(*
    Parameters
*)
    let _interpolated                              = interpolated
    let _ts                                        = ts
(*
    Functions
*)
    let mutable
        _YYUKRPIr                                  = make (fun () -> new YYUKRPIr (interpolated.Value, ts.Value))
    let _clone                                     (h : ICell<Handle<YoYInflationTermStructure>>)   
                                                   = triv _YYUKRPIr (fun () -> _YYUKRPIr.Value.clone(h.Value))
    let _fixing                                    (fixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = triv _YYUKRPIr (fun () -> _YYUKRPIr.Value.fixing(fixingDate.Value, forecastTodaysFixing.Value))
    let _ratio                                     = triv _YYUKRPIr (fun () -> _YYUKRPIr.Value.ratio())
    let _yoyInflationTermStructure                 = triv _YYUKRPIr (fun () -> _YYUKRPIr.Value.yoyInflationTermStructure())
    let _addFixing                                 (fixingDate : ICell<Date>) (fixing : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = triv _YYUKRPIr (fun () -> _YYUKRPIr.Value.addFixing(fixingDate.Value, fixing.Value, forceOverwrite.Value)
                                                                               _YYUKRPIr.Value)
    let _availabilityLag                           = triv _YYUKRPIr (fun () -> _YYUKRPIr.Value.availabilityLag())
    let _currency                                  = triv _YYUKRPIr (fun () -> _YYUKRPIr.Value.currency())
    let _familyName                                = triv _YYUKRPIr (fun () -> _YYUKRPIr.Value.familyName())
    let _fixingCalendar                            = triv _YYUKRPIr (fun () -> _YYUKRPIr.Value.fixingCalendar())
    let _frequency                                 = triv _YYUKRPIr (fun () -> _YYUKRPIr.Value.frequency())
    let _interpolated                              = triv _YYUKRPIr (fun () -> _YYUKRPIr.Value.interpolated())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = triv _YYUKRPIr (fun () -> _YYUKRPIr.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = triv _YYUKRPIr (fun () -> _YYUKRPIr.Value.name())
    let _region                                    = triv _YYUKRPIr (fun () -> _YYUKRPIr.Value.region())
    let _revised                                   = triv _YYUKRPIr (fun () -> _YYUKRPIr.Value.revised())
    let _update                                    = triv _YYUKRPIr (fun () -> _YYUKRPIr.Value.update()
                                                                               _YYUKRPIr.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = triv _YYUKRPIr (fun () -> _YYUKRPIr.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                               _YYUKRPIr.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = triv _YYUKRPIr (fun () -> _YYUKRPIr.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                               _YYUKRPIr.Value)
    let _allowsNativeFixings                       = triv _YYUKRPIr (fun () -> _YYUKRPIr.Value.allowsNativeFixings())
    let _clearFixings                              = triv _YYUKRPIr (fun () -> _YYUKRPIr.Value.clearFixings()
                                                                               _YYUKRPIr.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _YYUKRPIr (fun () -> _YYUKRPIr.Value.registerWith(handler.Value)
                                                                               _YYUKRPIr.Value)
    let _timeSeries                                = triv _YYUKRPIr (fun () -> _YYUKRPIr.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _YYUKRPIr (fun () -> _YYUKRPIr.Value.unregisterWith(handler.Value)
                                                                               _YYUKRPIr.Value)
    do this.Bind(_YYUKRPIr)
(* 
    casting 
*)
    internal new () = new YYUKRPIrModel1(null,null)
    member internal this.Inject v = _YYUKRPIr <- v
    static member Cast (p : ICell<YYUKRPIr>) = 
        if p :? YYUKRPIrModel1 then 
            p :?> YYUKRPIrModel1
        else
            let o = new YYUKRPIrModel1 ()
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
    member this.Fixing                             fixingDate forecastTodaysFixing   
                                                   = _fixing fixingDate forecastTodaysFixing 
    member this.Ratio                              = _ratio
    member this.YoyInflationTermStructure          = _yoyInflationTermStructure
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
