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
  helper class building a sequence of capped/floored cms-rate coupons

  </summary> *)
[<AutoSerializable(true)>]
type CmsLegModel
    ( schedule                                     : ICell<Schedule>
    , swapIndex                                    : ICell<SwapIndex>
    ) as this =

    inherit Model<CmsLeg> ()
(*
    Parameters
*)
    let _schedule                                  = schedule
    let _swapIndex                                 = swapIndex
(*
    Functions
*)
    let mutable
        _CmsLeg                                    = cell (fun () -> new CmsLeg (schedule.Value, swapIndex.Value))
    let _value                                     = triv (fun () -> _CmsLeg.Value.value())
    let _inArrears                                 = triv (fun () -> _CmsLeg.Value.inArrears())
    let _inArrears1                                (flag : ICell<bool>)   
                                                   = triv (fun () -> _CmsLeg.Value.inArrears(flag.Value))
    let _withCaps                                  (caps : ICell<Generic.List<Nullable<double>>>)   
                                                   = triv (fun () -> _CmsLeg.Value.withCaps(caps.Value))
    let _withCaps1                                 (cap : ICell<Nullable<double>>)   
                                                   = triv (fun () -> _CmsLeg.Value.withCaps(cap.Value))
    let _withFixingDays                            (fixingDays : ICell<int>)   
                                                   = triv (fun () -> _CmsLeg.Value.withFixingDays(fixingDays.Value))
    let _withFixingDays1                           (fixingDays : ICell<Generic.List<int>>)   
                                                   = triv (fun () -> _CmsLeg.Value.withFixingDays(fixingDays.Value))
    let _withFloors                                (floor : ICell<Nullable<double>>)   
                                                   = triv (fun () -> _CmsLeg.Value.withFloors(floor.Value))
    let _withFloors1                               (floors : ICell<Generic.List<Nullable<double>>>)   
                                                   = triv (fun () -> _CmsLeg.Value.withFloors(floors.Value))
    let _withGearings                              (gearing : ICell<double>)   
                                                   = triv (fun () -> _CmsLeg.Value.withGearings(gearing.Value))
    let _withGearings1                             (gearings : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> _CmsLeg.Value.withGearings(gearings.Value))
    let _withPaymentDayCounter                     (dayCounter : ICell<DayCounter>)   
                                                   = triv (fun () -> _CmsLeg.Value.withPaymentDayCounter(dayCounter.Value))
    let _withSpreads                               (spread : ICell<double>)   
                                                   = triv (fun () -> _CmsLeg.Value.withSpreads(spread.Value))
    let _withSpreads1                              (spreads : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> _CmsLeg.Value.withSpreads(spreads.Value))
    let _withZeroPayments                          = triv (fun () -> _CmsLeg.Value.withZeroPayments())
    let _withZeroPayments1                         (flag : ICell<bool>)   
                                                   = triv (fun () -> _CmsLeg.Value.withZeroPayments(flag.Value))
    let _withNotionals                             (notional : ICell<double>)   
                                                   = triv (fun () -> _CmsLeg.Value.withNotionals(notional.Value))
    let _withNotionals1                            (notionals : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> _CmsLeg.Value.withNotionals(notionals.Value))
    let _withPaymentAdjustment                     (convention : ICell<BusinessDayConvention>)   
                                                   = triv (fun () -> _CmsLeg.Value.withPaymentAdjustment(convention.Value))
    do this.Bind(_CmsLeg)
(* 
    casting 
*)
    internal new () = new CmsLegModel(null,null)
    member internal this.Inject v = _CmsLeg <- v
    static member Cast (p : ICell<CmsLeg>) = 
        if p :? CmsLegModel then 
            p :?> CmsLegModel
        else
            let o = new CmsLegModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.schedule                           = _schedule 
    member this.swapIndex                          = _swapIndex 
    member this.Value                              = _value
    member this.InArrears                          = _inArrears
    member this.InArrears1                         flag   
                                                   = _inArrears1 flag 
    member this.WithCaps                           caps   
                                                   = _withCaps caps 
    member this.WithCaps1                          cap   
                                                   = _withCaps1 cap 
    member this.WithFixingDays                     fixingDays   
                                                   = _withFixingDays fixingDays 
    member this.WithFixingDays1                    fixingDays   
                                                   = _withFixingDays1 fixingDays 
    member this.WithFloors                         floor   
                                                   = _withFloors floor 
    member this.WithFloors1                        floors   
                                                   = _withFloors1 floors 
    member this.WithGearings                       gearing   
                                                   = _withGearings gearing 
    member this.WithGearings1                      gearings   
                                                   = _withGearings1 gearings 
    member this.WithPaymentDayCounter              dayCounter   
                                                   = _withPaymentDayCounter dayCounter 
    member this.WithSpreads                        spread   
                                                   = _withSpreads spread 
    member this.WithSpreads1                       spreads   
                                                   = _withSpreads1 spreads 
    member this.WithZeroPayments                   = _withZeroPayments
    member this.WithZeroPayments1                  flag   
                                                   = _withZeroPayments1 flag 
    member this.WithNotionals                      notional   
                                                   = _withNotionals notional 
    member this.WithNotionals1                     notionals   
                                                   = _withNotionals1 notionals 
    member this.WithPaymentAdjustment              convention   
                                                   = _withPaymentAdjustment convention 
