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
  this pricer can already do swaplets but to get volatility-dependent coupons you need to implement the descendents.

  </summary> *)
[<AutoSerializable(true)>]
type CPICouponPricerModel
    ( capletVol                                    : ICell<Handle<CPIVolatilitySurface>>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<CPICouponPricer> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _capletVol                                 = capletVol
(*
    Functions
*)
    let mutable
        _CPICouponPricer                           = make (fun () -> (createEvaluationDate _evaluationDate (fun () ->new CPICouponPricer (capletVol.Value))))
    let _capletPrice                               (effectiveCap : ICell<double>)   
                                                   = triv _CPICouponPricer (fun () -> (curryEvaluationDate _evaluationDate _CPICouponPricer).Value.capletPrice(effectiveCap.Value))
    let _capletRate                                (effectiveCap : ICell<double>)   
                                                   = triv _CPICouponPricer (fun () -> (curryEvaluationDate _evaluationDate _CPICouponPricer).Value.capletRate(effectiveCap.Value))
    let _capletVolatility                          = triv _CPICouponPricer (fun () -> (curryEvaluationDate _evaluationDate _CPICouponPricer).Value.capletVolatility())
    let _floorletPrice                             (effectiveFloor : ICell<double>)   
                                                   = triv _CPICouponPricer (fun () -> (curryEvaluationDate _evaluationDate _CPICouponPricer).Value.floorletPrice(effectiveFloor.Value))
    let _floorletRate                              (effectiveFloor : ICell<double>)   
                                                   = triv _CPICouponPricer (fun () -> (curryEvaluationDate _evaluationDate _CPICouponPricer).Value.floorletRate(effectiveFloor.Value))
    let _initialize                                (coupon : ICell<InflationCoupon>)   
                                                   = triv _CPICouponPricer (fun () -> (curryEvaluationDate _evaluationDate _CPICouponPricer).Value.initialize(coupon.Value)
                                                                                      _CPICouponPricer.Value)
    let _setCapletVolatility                       (capletVol : ICell<Handle<CPIVolatilitySurface>>)   
                                                   = triv _CPICouponPricer (fun () -> (curryEvaluationDate _evaluationDate _CPICouponPricer).Value.setCapletVolatility(capletVol.Value)
                                                                                      _CPICouponPricer.Value)
    let _swapletPrice                              = triv _CPICouponPricer (fun () -> (curryEvaluationDate _evaluationDate _CPICouponPricer).Value.swapletPrice())
    let _swapletRate                               = triv _CPICouponPricer (fun () -> (curryEvaluationDate _evaluationDate _CPICouponPricer).Value.swapletRate())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _CPICouponPricer (fun () -> (curryEvaluationDate _evaluationDate _CPICouponPricer).Value.registerWith(handler.Value)
                                                                                      _CPICouponPricer.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _CPICouponPricer (fun () -> (curryEvaluationDate _evaluationDate _CPICouponPricer).Value.unregisterWith(handler.Value)
                                                                                      _CPICouponPricer.Value)
    let _update                                    = triv _CPICouponPricer (fun () -> (curryEvaluationDate _evaluationDate _CPICouponPricer).Value.update()
                                                                                      _CPICouponPricer.Value)
    do this.Bind(_CPICouponPricer)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new CPICouponPricerModel(null,null)
    member internal this.Inject v = _CPICouponPricer <- v
    static member Cast (p : ICell<CPICouponPricer>) = 
        if p :? CPICouponPricerModel then 
            p :?> CPICouponPricerModel
        else
            let o = new CPICouponPricerModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.capletVol                          = _capletVol 
    member this.CapletPrice                        effectiveCap   
                                                   = _capletPrice effectiveCap 
    member this.CapletRate                         effectiveCap   
                                                   = _capletRate effectiveCap 
    member this.CapletVolatility                   = _capletVolatility
    member this.FloorletPrice                      effectiveFloor   
                                                   = _floorletPrice effectiveFloor 
    member this.FloorletRate                       effectiveFloor   
                                                   = _floorletRate effectiveFloor 
    member this.Initialize                         coupon   
                                                   = _initialize coupon 
    member this.SetCapletVolatility                capletVol   
                                                   = _setCapletVolatility capletVol 
    member this.SwapletPrice                       = _swapletPrice
    member this.SwapletRate                        = _swapletRate
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Update                             = _update
