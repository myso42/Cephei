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
  Digital-payoff coupon   Implementation of a floating-rate coupon with digital call/put option. Payoffs: - Coupon with cash-or-nothing Digital Call rate + csi * payoffRate * Heaviside(rate-strike) - Coupon with cash-or-nothing Digital Put rate + csi * payoffRate * Heaviside(strike-rate) where csi=+1 or csi=-1. - Coupon with asset-or-nothing Digital Call rate + csi * rate * Heaviside(rate-strike) - Coupon with asset-or-nothing Digital Put rate + csi * rate * Heaviside(strike-rate) where csi=+1 or csi=-1. The evaluation of the coupon is made using the call/put spread replication method.    instruments  - the correctness of the returned value in case of Asset-or-nothing embedded option is tested by pricing the digital option with Cox-Rubinstein formula. - the correctness of the returned value in case of deep-in-the-money Asset-or-nothing embedded option is tested vs the expected values of coupon and option. - the correctness of the returned value in case of deep-out-of-the-money Asset-or-nothing embedded option is tested vs the expected values of coupon and option. - the correctness of the returned value in case of Cash-or-nothing embedded option is tested by pricing the digital option with Reiner-Rubinstein formula. - the correctness of the returned value in case of deep-in-the-money Cash-or-nothing embedded option is tested vs the expected values of coupon and option. - the correctness of the returned value in case of deep-out-of-the-money Cash-or-nothing embedded option is tested vs the expected values of coupon and option. - the correctness of the returned value is tested checking the correctness of the call-put parity relation. - the correctness of the returned value is tested by the relationship between prices in case of different replication types.
! Constructors ! general constructor
  </summary> *)
[<AutoSerializable(true)>]
type DigitalCouponModel
    ( underlying                                   : ICell<FloatingRateCoupon>
    , callStrike                                   : ICell<Nullable<double>>
    , callPosition                                 : ICell<Position.Type>
    , isCallATMIncluded                            : ICell<bool>
    , callDigitalPayoff                            : ICell<Nullable<double>>
    , putStrike                                    : ICell<Nullable<double>>
    , putPosition                                  : ICell<Position.Type>
    , isPutATMIncluded                             : ICell<bool>
    , putDigitalPayoff                             : ICell<Nullable<double>>
    , replication                                  : ICell<DigitalReplication>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<DigitalCoupon> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _underlying                                = underlying
    let _callStrike                                = callStrike
    let _callPosition                              = callPosition
    let _isCallATMIncluded                         = isCallATMIncluded
    let _callDigitalPayoff                         = callDigitalPayoff
    let _putStrike                                 = putStrike
    let _putPosition                               = putPosition
    let _isPutATMIncluded                          = isPutATMIncluded
    let _putDigitalPayoff                          = putDigitalPayoff
    let _replication                               = replication
(*
    Functions
*)
    let mutable
        _DigitalCoupon                             = make (fun () -> (createEvaluationDate _evaluationDate (fun () ->new DigitalCoupon (underlying.Value, callStrike.Value, callPosition.Value, isCallATMIncluded.Value, callDigitalPayoff.Value, putStrike.Value, putPosition.Value, isPutATMIncluded.Value, putDigitalPayoff.Value, replication.Value))))
    let _callDigitalPayoff                         = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.callDigitalPayoff())
    let _callOptionRate                            = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.callOptionRate())
    let _callStrike                                = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.callStrike())
    let _convexityAdjustment                       = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.convexityAdjustment())
    let _factory                                   (underlying : ICell<FloatingRateCoupon>) (callStrike : ICell<Nullable<double>>) (callPosition : ICell<Position.Type>) (isCallATMIncluded : ICell<bool>) (callDigitalPayoff : ICell<Nullable<double>>) (putStrike : ICell<Nullable<double>>) (putPosition : ICell<Position.Type>) (isPutATMIncluded : ICell<bool>) (putDigitalPayoff : ICell<Nullable<double>>) (replication : ICell<DigitalReplication>)   
                                                   = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.factory(underlying.Value, callStrike.Value, callPosition.Value, isCallATMIncluded.Value, callDigitalPayoff.Value, putStrike.Value, putPosition.Value, isPutATMIncluded.Value, putDigitalPayoff.Value, replication.Value))
    let _hasCall                                   = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.hasCall())
    let _hasCollar                                 = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.hasCollar())
    let _hasPut                                    = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.hasPut())
    let _isLongCall                                = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.isLongCall())
    let _isLongPut                                 = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.isLongPut())
    let _putDigitalPayoff                          = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.putDigitalPayoff())
    let _putOptionRate                             = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.putOptionRate())
    let _putStrike                                 = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.putStrike())
    let _rate                                      = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.rate())
    let _setPricer                                 (pricer : ICell<FloatingRateCouponPricer>)   
                                                   = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.setPricer(pricer.Value)
                                                                                    _DigitalCoupon.Value)
    let _underlying                                = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.underlying())
    let _accruedAmount                             (d : ICell<Date>)   
                                                   = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.accruedAmount(d.Value))
    let _adjustedFixing                            = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.adjustedFixing)
    let _amount                                    = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.amount())
    let _dayCounter                                = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.dayCounter())
    let _fixingDate                                = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.fixingDate())
    let _fixingDays                                = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.fixingDays)
    let _gearing                                   = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.gearing())
    let _index                                     = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.index())
    let _indexFixing                               = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.indexFixing())
    let _isInArrears                               = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.isInArrears())
    let _price                                     (yts : ICell<YieldTermStructure>)   
                                                   = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.price(yts.Value))
    let _pricer                                    = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.pricer())
    let _spread                                    = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.spread())
    let _update                                    = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.update()
                                                                                    _DigitalCoupon.Value)
    let _accrualDays                               = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.accrualDays())
    let _accrualEndDate                            = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.accrualEndDate())
    let _accrualPeriod                             = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.accrualPeriod())
    let _accrualStartDate                          = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.accrualStartDate())
    let _accruedDays                               (d : ICell<Date>)   
                                                   = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.accruedDays(d.Value))
    let _accruedPeriod                             (d : ICell<Date>)   
                                                   = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.accruedPeriod(d.Value))
    let _date                                      = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.date())
    let _exCouponDate                              = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.exCouponDate())
    let _nominal                                   = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.nominal())
    let _referencePeriodEnd                        = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.referencePeriodEnd)
    let _referencePeriodStart                      = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.referencePeriodStart)
    let _CompareTo                                 (cf : ICell<CashFlow>)   
                                                   = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.CompareTo(cf.Value))
    let _Equals                                    (cf : ICell<Object>)   
                                                   = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.Equals(cf.Value))
    let _hasOccurred                               (refDate : ICell<Date>) (includeRefDate : ICell<Nullable<bool>>)   
                                                   = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.hasOccurred(refDate.Value, includeRefDate.Value))
    let _tradingExCoupon                           (refDate : ICell<Date>)   
                                                   = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.tradingExCoupon(refDate.Value))
    let _accept                                    (v : ICell<IAcyclicVisitor>)   
                                                   = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.accept(v.Value)
                                                                                    _DigitalCoupon.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.registerWith(handler.Value)
                                                                                    _DigitalCoupon.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.unregisterWith(handler.Value)
                                                                                    _DigitalCoupon.Value)
    do this.Bind(_DigitalCoupon)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new DigitalCouponModel(null,null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _DigitalCoupon <- v
    static member Cast (p : ICell<DigitalCoupon>) = 
        if p :? DigitalCouponModel then 
            p :?> DigitalCouponModel
        else
            let o = new DigitalCouponModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.underlying                         = _underlying 
    member this.callStrike                         = _callStrike 
    member this.callPosition                       = _callPosition 
    member this.isCallATMIncluded                  = _isCallATMIncluded 
    member this.callDigitalPayoff                  = _callDigitalPayoff 
    member this.putStrike                          = _putStrike 
    member this.putPosition                        = _putPosition 
    member this.isPutATMIncluded                   = _isPutATMIncluded 
    member this.putDigitalPayoff                   = _putDigitalPayoff 
    member this.replication                        = _replication 
    member this.CallDigitalPayoff                  = _callDigitalPayoff
    member this.CallOptionRate                     = _callOptionRate
    member this.CallStrike                         = _callStrike
    member this.ConvexityAdjustment                = _convexityAdjustment
    member this.Factory                            underlying callStrike callPosition isCallATMIncluded callDigitalPayoff putStrike putPosition isPutATMIncluded putDigitalPayoff replication   
                                                   = _factory underlying callStrike callPosition isCallATMIncluded callDigitalPayoff putStrike putPosition isPutATMIncluded putDigitalPayoff replication 
    member this.HasCall                            = _hasCall
    member this.HasCollar                          = _hasCollar
    member this.HasPut                             = _hasPut
    member this.IsLongCall                         = _isLongCall
    member this.IsLongPut                          = _isLongPut
    member this.PutDigitalPayoff                   = _putDigitalPayoff
    member this.PutOptionRate                      = _putOptionRate
    member this.PutStrike                          = _putStrike
    member this.Rate                               = _rate
    member this.SetPricer                          pricer   
                                                   = _setPricer pricer 
    member this.Underlying                         = _underlying
    member this.AccruedAmount                      d   
                                                   = _accruedAmount d 
    member this.AdjustedFixing                     = _adjustedFixing
    member this.Amount                             = _amount
    member this.DayCounter                         = _dayCounter
    member this.FixingDate                         = _fixingDate
    member this.FixingDays                         = _fixingDays
    member this.Gearing                            = _gearing
    member this.Index                              = _index
    member this.IndexFixing                        = _indexFixing
    member this.IsInArrears                        = _isInArrears
    member this.Price                              yts   
                                                   = _price yts 
    member this.Pricer                             = _pricer
    member this.Spread                             = _spread
    member this.Update                             = _update
    member this.AccrualDays                        = _accrualDays
    member this.AccrualEndDate                     = _accrualEndDate
    member this.AccrualPeriod                      = _accrualPeriod
    member this.AccrualStartDate                   = _accrualStartDate
    member this.AccruedDays                        d   
                                                   = _accruedDays d 
    member this.AccruedPeriod                      d   
                                                   = _accruedPeriod d 
    member this.Date                               = _date
    member this.ExCouponDate                       = _exCouponDate
    member this.Nominal                            = _nominal
    member this.ReferencePeriodEnd                 = _referencePeriodEnd
    member this.ReferencePeriodStart               = _referencePeriodStart
    member this.CompareTo                          cf   
                                                   = _CompareTo cf 
    member this.Equals                             cf   
                                                   = _Equals cf 
    member this.HasOccurred                        refDate includeRefDate   
                                                   = _hasOccurred refDate includeRefDate 
    member this.TradingExCoupon                    refDate   
                                                   = _tradingExCoupon refDate 
    member this.Accept                             v   
                                                   = _accept v 
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
(* <summary>
  Digital-payoff coupon   Implementation of a floating-rate coupon with digital call/put option. Payoffs: - Coupon with cash-or-nothing Digital Call rate + csi * payoffRate * Heaviside(rate-strike) - Coupon with cash-or-nothing Digital Put rate + csi * payoffRate * Heaviside(strike-rate) where csi=+1 or csi=-1. - Coupon with asset-or-nothing Digital Call rate + csi * rate * Heaviside(rate-strike) - Coupon with asset-or-nothing Digital Put rate + csi * rate * Heaviside(strike-rate) where csi=+1 or csi=-1. The evaluation of the coupon is made using the call/put spread replication method.    instruments  - the correctness of the returned value in case of Asset-or-nothing embedded option is tested by pricing the digital option with Cox-Rubinstein formula. - the correctness of the returned value in case of deep-in-the-money Asset-or-nothing embedded option is tested vs the expected values of coupon and option. - the correctness of the returned value in case of deep-out-of-the-money Asset-or-nothing embedded option is tested vs the expected values of coupon and option. - the correctness of the returned value in case of Cash-or-nothing embedded option is tested by pricing the digital option with Reiner-Rubinstein formula. - the correctness of the returned value in case of deep-in-the-money Cash-or-nothing embedded option is tested vs the expected values of coupon and option. - the correctness of the returned value in case of deep-out-of-the-money Cash-or-nothing embedded option is tested vs the expected values of coupon and option. - the correctness of the returned value is tested checking the correctness of the call-put parity relation. - the correctness of the returned value is tested by the relationship between prices in case of different replication types.
need by CashFlowVectors
  </summary> *)
[<AutoSerializable(true)>]
type DigitalCouponModel1
    ( evaluationDate                               : ICell<Date>
    ) as this =
    inherit Model<DigitalCoupon> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
(*
    Functions
*)
    let mutable
        _DigitalCoupon                             = make (fun () -> (createEvaluationDate _evaluationDate (fun () ->new DigitalCoupon ())))
    let _callDigitalPayoff                         = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.callDigitalPayoff())
    let _callOptionRate                            = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.callOptionRate())
    let _callStrike                                = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.callStrike())
    let _convexityAdjustment                       = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.convexityAdjustment())
    let _factory                                   (underlying : ICell<FloatingRateCoupon>) (callStrike : ICell<Nullable<double>>) (callPosition : ICell<Position.Type>) (isCallATMIncluded : ICell<bool>) (callDigitalPayoff : ICell<Nullable<double>>) (putStrike : ICell<Nullable<double>>) (putPosition : ICell<Position.Type>) (isPutATMIncluded : ICell<bool>) (putDigitalPayoff : ICell<Nullable<double>>) (replication : ICell<DigitalReplication>)   
                                                   = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.factory(underlying.Value, callStrike.Value, callPosition.Value, isCallATMIncluded.Value, callDigitalPayoff.Value, putStrike.Value, putPosition.Value, isPutATMIncluded.Value, putDigitalPayoff.Value, replication.Value))
    let _hasCall                                   = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.hasCall())
    let _hasCollar                                 = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.hasCollar())
    let _hasPut                                    = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.hasPut())
    let _isLongCall                                = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.isLongCall())
    let _isLongPut                                 = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.isLongPut())
    let _putDigitalPayoff                          = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.putDigitalPayoff())
    let _putOptionRate                             = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.putOptionRate())
    let _putStrike                                 = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.putStrike())
    let _rate                                      = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.rate())
    let _setPricer                                 (pricer : ICell<FloatingRateCouponPricer>)   
                                                   = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.setPricer(pricer.Value)
                                                                                    _DigitalCoupon.Value)
    let _underlying                                = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.underlying())
    let _accruedAmount                             (d : ICell<Date>)   
                                                   = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.accruedAmount(d.Value))
    let _adjustedFixing                            = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.adjustedFixing)
    let _amount                                    = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.amount())
    let _dayCounter                                = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.dayCounter())
    let _fixingDate                                = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.fixingDate())
    let _fixingDays                                = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.fixingDays)
    let _gearing                                   = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.gearing())
    let _index                                     = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.index())
    let _indexFixing                               = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.indexFixing())
    let _isInArrears                               = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.isInArrears())
    let _price                                     (yts : ICell<YieldTermStructure>)   
                                                   = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.price(yts.Value))
    let _pricer                                    = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.pricer())
    let _spread                                    = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.spread())
    let _update                                    = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.update()
                                                                                    _DigitalCoupon.Value)
    let _accrualDays                               = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.accrualDays())
    let _accrualEndDate                            = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.accrualEndDate())
    let _accrualPeriod                             = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.accrualPeriod())
    let _accrualStartDate                          = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.accrualStartDate())
    let _accruedDays                               (d : ICell<Date>)   
                                                   = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.accruedDays(d.Value))
    let _accruedPeriod                             (d : ICell<Date>)   
                                                   = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.accruedPeriod(d.Value))
    let _date                                      = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.date())
    let _exCouponDate                              = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.exCouponDate())
    let _nominal                                   = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.nominal())
    let _referencePeriodEnd                        = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.referencePeriodEnd)
    let _referencePeriodStart                      = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.referencePeriodStart)
    let _CompareTo                                 (cf : ICell<CashFlow>)   
                                                   = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.CompareTo(cf.Value))
    let _Equals                                    (cf : ICell<Object>)   
                                                   = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.Equals(cf.Value))
    let _hasOccurred                               (refDate : ICell<Date>) (includeRefDate : ICell<Nullable<bool>>)   
                                                   = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.hasOccurred(refDate.Value, includeRefDate.Value))
    let _tradingExCoupon                           (refDate : ICell<Date>)   
                                                   = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.tradingExCoupon(refDate.Value))
    let _accept                                    (v : ICell<IAcyclicVisitor>)   
                                                   = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.accept(v.Value)
                                                                                    _DigitalCoupon.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.registerWith(handler.Value)
                                                                                    _DigitalCoupon.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _DigitalCoupon (fun () -> (curryEvaluationDate _evaluationDate _DigitalCoupon).Value.unregisterWith(handler.Value)
                                                                                    _DigitalCoupon.Value)
    do this.Bind(_DigitalCoupon)
(* 
    casting 
*)
    
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new DigitalCouponModel1(null)
    member internal this.Inject v = _DigitalCoupon <- v
    static member Cast (p : ICell<DigitalCoupon>) = 
        if p :? DigitalCouponModel1 then 
            p :?> DigitalCouponModel1
        else
            let o = new DigitalCouponModel1 ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.CallDigitalPayoff                  = _callDigitalPayoff
    member this.CallOptionRate                     = _callOptionRate
    member this.CallStrike                         = _callStrike
    member this.ConvexityAdjustment                = _convexityAdjustment
    member this.Factory                            underlying callStrike callPosition isCallATMIncluded callDigitalPayoff putStrike putPosition isPutATMIncluded putDigitalPayoff replication   
                                                   = _factory underlying callStrike callPosition isCallATMIncluded callDigitalPayoff putStrike putPosition isPutATMIncluded putDigitalPayoff replication 
    member this.HasCall                            = _hasCall
    member this.HasCollar                          = _hasCollar
    member this.HasPut                             = _hasPut
    member this.IsLongCall                         = _isLongCall
    member this.IsLongPut                          = _isLongPut
    member this.PutDigitalPayoff                   = _putDigitalPayoff
    member this.PutOptionRate                      = _putOptionRate
    member this.PutStrike                          = _putStrike
    member this.Rate                               = _rate
    member this.SetPricer                          pricer   
                                                   = _setPricer pricer 
    member this.Underlying                         = _underlying
    member this.AccruedAmount                      d   
                                                   = _accruedAmount d 
    member this.AdjustedFixing                     = _adjustedFixing
    member this.Amount                             = _amount
    member this.DayCounter                         = _dayCounter
    member this.FixingDate                         = _fixingDate
    member this.FixingDays                         = _fixingDays
    member this.Gearing                            = _gearing
    member this.Index                              = _index
    member this.IndexFixing                        = _indexFixing
    member this.IsInArrears                        = _isInArrears
    member this.Price                              yts   
                                                   = _price yts 
    member this.Pricer                             = _pricer
    member this.Spread                             = _spread
    member this.Update                             = _update
    member this.AccrualDays                        = _accrualDays
    member this.AccrualEndDate                     = _accrualEndDate
    member this.AccrualPeriod                      = _accrualPeriod
    member this.AccrualStartDate                   = _accrualStartDate
    member this.AccruedDays                        d   
                                                   = _accruedDays d 
    member this.AccruedPeriod                      d   
                                                   = _accruedPeriod d 
    member this.Date                               = _date
    member this.ExCouponDate                       = _exCouponDate
    member this.Nominal                            = _nominal
    member this.ReferencePeriodEnd                 = _referencePeriodEnd
    member this.ReferencePeriodStart               = _referencePeriodStart
    member this.CompareTo                          cf   
                                                   = _CompareTo cf 
    member this.Equals                             cf   
                                                   = _Equals cf 
    member this.HasOccurred                        refDate includeRefDate   
                                                   = _hasOccurred refDate includeRefDate 
    member this.TradingExCoupon                    refDate   
                                                   = _tradingExCoupon refDate 
    member this.Accept                             v   
                                                   = _accept v 
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
