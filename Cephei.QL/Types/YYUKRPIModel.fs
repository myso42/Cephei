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
  Genuine year-on-year UK RPI (i.e. not a ratio of UK RPI)

  </summary> *)
[<AutoSerializable(true)>]
type YYUKRPIModel
    ( interpolated                                 : ICell<bool>
    , ts                                           : ICell<Handle<YoYInflationTermStructure>>
    ) as this =

    inherit Model<YYUKRPI> ()
(*
    Parameters
*)
    let _interpolated                              = interpolated
    let _ts                                        = ts
(*
    Functions
*)
    let mutable
        _YYUKRPI                                   = make (fun () -> new YYUKRPI (interpolated.Value, ts.Value))
    let _clone                                     (h : ICell<Handle<YoYInflationTermStructure>>)   
                                                   = triv _YYUKRPI (fun () -> _YYUKRPI.Value.clone(h.Value))
    let _fixing                                    (fixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = triv _YYUKRPI (fun () -> _YYUKRPI.Value.fixing(fixingDate.Value, forecastTodaysFixing.Value))
    let _ratio                                     = triv _YYUKRPI (fun () -> _YYUKRPI.Value.ratio())
    let _yoyInflationTermStructure                 = triv _YYUKRPI (fun () -> _YYUKRPI.Value.yoyInflationTermStructure())
    let _addFixing                                 (fixingDate : ICell<Date>) (fixing : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = triv _YYUKRPI (fun () -> _YYUKRPI.Value.addFixing(fixingDate.Value, fixing.Value, forceOverwrite.Value)
                                                                              _YYUKRPI.Value)
    let _availabilityLag                           = triv _YYUKRPI (fun () -> _YYUKRPI.Value.availabilityLag())
    let _currency                                  = triv _YYUKRPI (fun () -> _YYUKRPI.Value.currency())
    let _familyName                                = triv _YYUKRPI (fun () -> _YYUKRPI.Value.familyName())
    let _fixingCalendar                            = triv _YYUKRPI (fun () -> _YYUKRPI.Value.fixingCalendar())
    let _frequency                                 = triv _YYUKRPI (fun () -> _YYUKRPI.Value.frequency())
    let _interpolated                              = triv _YYUKRPI (fun () -> _YYUKRPI.Value.interpolated())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = triv _YYUKRPI (fun () -> _YYUKRPI.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = triv _YYUKRPI (fun () -> _YYUKRPI.Value.name())
    let _region                                    = triv _YYUKRPI (fun () -> _YYUKRPI.Value.region())
    let _revised                                   = triv _YYUKRPI (fun () -> _YYUKRPI.Value.revised())
    let _update                                    = triv _YYUKRPI (fun () -> _YYUKRPI.Value.update()
                                                                              _YYUKRPI.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = triv _YYUKRPI (fun () -> _YYUKRPI.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                              _YYUKRPI.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = triv _YYUKRPI (fun () -> _YYUKRPI.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                              _YYUKRPI.Value)
    let _allowsNativeFixings                       = triv _YYUKRPI (fun () -> _YYUKRPI.Value.allowsNativeFixings())
    let _clearFixings                              = triv _YYUKRPI (fun () -> _YYUKRPI.Value.clearFixings()
                                                                              _YYUKRPI.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _YYUKRPI (fun () -> _YYUKRPI.Value.registerWith(handler.Value)
                                                                              _YYUKRPI.Value)
    let _timeSeries                                = triv _YYUKRPI (fun () -> _YYUKRPI.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _YYUKRPI (fun () -> _YYUKRPI.Value.unregisterWith(handler.Value)
                                                                              _YYUKRPI.Value)
    do this.Bind(_YYUKRPI)
(* 
    casting 
*)
    internal new () = new YYUKRPIModel(null,null)
    member internal this.Inject v = _YYUKRPI <- v
    static member Cast (p : ICell<YYUKRPI>) = 
        if p :? YYUKRPIModel then 
            p :?> YYUKRPIModel
        else
            let o = new YYUKRPIModel ()
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
(* <summary>
  Genuine year-on-year UK RPI (i.e. not a ratio of UK RPI)

  </summary> *)
[<AutoSerializable(true)>]
type YYUKRPIModel1
    ( interpolated                                 : ICell<bool>
    ) as this =

    inherit Model<YYUKRPI> ()
(*
    Parameters
*)
    let _interpolated                              = interpolated
(*
    Functions
*)
    let mutable
        _YYUKRPI                                   = make (fun () -> new YYUKRPI (interpolated.Value))
    let _clone                                     (h : ICell<Handle<YoYInflationTermStructure>>)   
                                                   = triv _YYUKRPI (fun () -> _YYUKRPI.Value.clone(h.Value))
    let _fixing                                    (fixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = triv _YYUKRPI (fun () -> _YYUKRPI.Value.fixing(fixingDate.Value, forecastTodaysFixing.Value))
    let _ratio                                     = triv _YYUKRPI (fun () -> _YYUKRPI.Value.ratio())
    let _yoyInflationTermStructure                 = triv _YYUKRPI (fun () -> _YYUKRPI.Value.yoyInflationTermStructure())
    let _addFixing                                 (fixingDate : ICell<Date>) (fixing : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = triv _YYUKRPI (fun () -> _YYUKRPI.Value.addFixing(fixingDate.Value, fixing.Value, forceOverwrite.Value)
                                                                              _YYUKRPI.Value)
    let _availabilityLag                           = triv _YYUKRPI (fun () -> _YYUKRPI.Value.availabilityLag())
    let _currency                                  = triv _YYUKRPI (fun () -> _YYUKRPI.Value.currency())
    let _familyName                                = triv _YYUKRPI (fun () -> _YYUKRPI.Value.familyName())
    let _fixingCalendar                            = triv _YYUKRPI (fun () -> _YYUKRPI.Value.fixingCalendar())
    let _frequency                                 = triv _YYUKRPI (fun () -> _YYUKRPI.Value.frequency())
    let _interpolated                              = triv _YYUKRPI (fun () -> _YYUKRPI.Value.interpolated())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = triv _YYUKRPI (fun () -> _YYUKRPI.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = triv _YYUKRPI (fun () -> _YYUKRPI.Value.name())
    let _region                                    = triv _YYUKRPI (fun () -> _YYUKRPI.Value.region())
    let _revised                                   = triv _YYUKRPI (fun () -> _YYUKRPI.Value.revised())
    let _update                                    = triv _YYUKRPI (fun () -> _YYUKRPI.Value.update()
                                                                              _YYUKRPI.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = triv _YYUKRPI (fun () -> _YYUKRPI.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                              _YYUKRPI.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = triv _YYUKRPI (fun () -> _YYUKRPI.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                              _YYUKRPI.Value)
    let _allowsNativeFixings                       = triv _YYUKRPI (fun () -> _YYUKRPI.Value.allowsNativeFixings())
    let _clearFixings                              = triv _YYUKRPI (fun () -> _YYUKRPI.Value.clearFixings()
                                                                              _YYUKRPI.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _YYUKRPI (fun () -> _YYUKRPI.Value.registerWith(handler.Value)
                                                                              _YYUKRPI.Value)
    let _timeSeries                                = triv _YYUKRPI (fun () -> _YYUKRPI.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _YYUKRPI (fun () -> _YYUKRPI.Value.unregisterWith(handler.Value)
                                                                              _YYUKRPI.Value)
    do this.Bind(_YYUKRPI)
(* 
    casting 
*)
    internal new () = new YYUKRPIModel1(null)
    member internal this.Inject v = _YYUKRPI <- v
    static member Cast (p : ICell<YYUKRPI>) = 
        if p :? YYUKRPIModel1 then 
            p :?> YYUKRPIModel1
        else
            let o = new YYUKRPIModel1 ()
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
