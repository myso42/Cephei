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
  Essentially a copy of the nominal version but taking a different index and a set of pricers (not just one).  The payoff P of a capped inflation-rate coupon with paysWithin = true is:  P = N T L + b, C).  where N is the notional, T is the accrual time, L is the inflation rate, a is its gearing, b is the spread, and C and F the strikes.  The payoff of a floored inflation-rate coupon is:  P = N T L + b, F).  The payoff of a collared inflation-rate coupon is:  P = N T L + b, F), C).  If paysWithin = false then the inverse is returned (this provides for instrument cap and caplet prices).  They can be decomposed in the following manner.  Decomposition of a capped floating rate coupon when paysWithin = true: R = L + b, C) = (a L + b) + - b - |a| L, 0) where = sgn(a) Then: R = (a L + b) + |a| - b}{|a|} - L, 0)
... or not
  </summary> *)
[<AutoSerializable(true)>]
type CappedFlooredYoYInflationCouponModel
    ( paymentDate                                  : ICell<Date>
    , nominal                                      : ICell<double>
    , startDate                                    : ICell<Date>
    , endDate                                      : ICell<Date>
    , fixingDays                                   : ICell<int>
    , index                                        : ICell<YoYInflationIndex>
    , observationLag                               : ICell<Period>
    , dayCounter                                   : ICell<DayCounter>
    , gearing                                      : ICell<double>
    , spread                                       : ICell<double>
    , cap                                          : ICell<Nullable<double>>
    , floor                                        : ICell<Nullable<double>>
    , refPeriodStart                               : ICell<Date>
    , refPeriodEnd                                 : ICell<Date>
    ) as this =

    inherit Model<CappedFlooredYoYInflationCoupon> ()
(*
    Parameters
*)
    let _paymentDate                               = paymentDate
    let _nominal                                   = nominal
    let _startDate                                 = startDate
    let _endDate                                   = endDate
    let _fixingDays                                = fixingDays
    let _index                                     = index
    let _observationLag                            = observationLag
    let _dayCounter                                = dayCounter
    let _gearing                                   = gearing
    let _spread                                    = spread
    let _cap                                       = cap
    let _floor                                     = floor
    let _refPeriodStart                            = refPeriodStart
    let _refPeriodEnd                              = refPeriodEnd
(*
    Functions
*)
    let mutable
        _CappedFlooredYoYInflationCoupon           = make (fun () -> new CappedFlooredYoYInflationCoupon (paymentDate.Value, nominal.Value, startDate.Value, endDate.Value, fixingDays.Value, index.Value, observationLag.Value, dayCounter.Value, gearing.Value, spread.Value, cap.Value, floor.Value, refPeriodStart.Value, refPeriodEnd.Value))
    let _cap                                       = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.cap())
    let _effectiveCap                              = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.effectiveCap())
    let _effectiveFloor                            = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.effectiveFloor())
    let _floor                                     = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.floor())
    let _isCapped                                  = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.isCapped())
    let _isFloored                                 = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.isFloored())
    let _rate                                      = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.rate())
    let _setPricer                                 (pricer : ICell<YoYInflationCouponPricer>)   
                                                   = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.setPricer(pricer.Value)
                                                                                                      _CappedFlooredYoYInflationCoupon.Value)
    let _adjustedFixing                            = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.adjustedFixing())
    let _gearing                                   = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.gearing())
    let _spread                                    = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.spread())
    let _yoyIndex                                  = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.yoyIndex())
    let _accruedAmount                             (d : ICell<Date>)   
                                                   = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.accruedAmount(d.Value))
    let _amount                                    = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.amount())
    let _dayCounter                                = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.dayCounter())
    let _fixingDate                                = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.fixingDate())
    let _fixingDays                                = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.fixingDays())
    let _index                                     = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.index())
    let _indexFixing                               = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.indexFixing())
    let _observationLag                            = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.observationLag())
    let _price                                     (discountingCurve : ICell<Handle<YieldTermStructure>>)   
                                                   = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.price(discountingCurve.Value))
    let _pricer                                    = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.pricer())
    let _update                                    = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.update()
                                                                                                      _CappedFlooredYoYInflationCoupon.Value)
    let _accrualDays                               = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.accrualDays())
    let _accrualEndDate                            = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.accrualEndDate())
    let _accrualPeriod                             = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.accrualPeriod())
    let _accrualStartDate                          = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.accrualStartDate())
    let _accruedDays                               (d : ICell<Date>)   
                                                   = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.accruedDays(d.Value))
    let _accruedPeriod                             (d : ICell<Date>)   
                                                   = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.accruedPeriod(d.Value))
    let _date                                      = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.date())
    let _exCouponDate                              = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.exCouponDate())
    let _nominal                                   = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.nominal())
    let _referencePeriodEnd                        = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.referencePeriodEnd)
    let _referencePeriodStart                      = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.referencePeriodStart)
    let _CompareTo                                 (cf : ICell<CashFlow>)   
                                                   = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.CompareTo(cf.Value))
    let _Equals                                    (cf : ICell<Object>)   
                                                   = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.Equals(cf.Value))
    let _hasOccurred                               (refDate : ICell<Date>) (includeRefDate : ICell<Nullable<bool>>)   
                                                   = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.hasOccurred(refDate.Value, includeRefDate.Value))
    let _tradingExCoupon                           (refDate : ICell<Date>)   
                                                   = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.tradingExCoupon(refDate.Value))
    let _accept                                    (v : ICell<IAcyclicVisitor>)   
                                                   = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.accept(v.Value)
                                                                                                      _CappedFlooredYoYInflationCoupon.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.registerWith(handler.Value)
                                                                                                      _CappedFlooredYoYInflationCoupon.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.unregisterWith(handler.Value)
                                                                                                      _CappedFlooredYoYInflationCoupon.Value)
    do this.Bind(_CappedFlooredYoYInflationCoupon)
(* 
    casting 
*)
    internal new () = new CappedFlooredYoYInflationCouponModel(null,null,null,null,null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _CappedFlooredYoYInflationCoupon <- v
    static member Cast (p : ICell<CappedFlooredYoYInflationCoupon>) = 
        if p :? CappedFlooredYoYInflationCouponModel then 
            p :?> CappedFlooredYoYInflationCouponModel
        else
            let o = new CappedFlooredYoYInflationCouponModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.paymentDate                        = _paymentDate 
    member this.nominal                            = _nominal 
    member this.startDate                          = _startDate 
    member this.endDate                            = _endDate 
    member this.fixingDays                         = _fixingDays 
    member this.index                              = _index 
    member this.observationLag                     = _observationLag 
    member this.dayCounter                         = _dayCounter 
    member this.gearing                            = _gearing 
    member this.spread                             = _spread 
    member this.cap                                = _cap 
    member this.floor                              = _floor 
    member this.refPeriodStart                     = _refPeriodStart 
    member this.refPeriodEnd                       = _refPeriodEnd 
    member this.Cap                                = _cap
    member this.EffectiveCap                       = _effectiveCap
    member this.EffectiveFloor                     = _effectiveFloor
    member this.Floor                              = _floor
    member this.IsCapped                           = _isCapped
    member this.IsFloored                          = _isFloored
    member this.Rate                               = _rate
    member this.SetPricer                          pricer   
                                                   = _setPricer pricer 
    member this.AdjustedFixing                     = _adjustedFixing
    member this.Gearing                            = _gearing
    member this.Spread                             = _spread
    member this.YoyIndex                           = _yoyIndex
    member this.AccruedAmount                      d   
                                                   = _accruedAmount d 
    member this.Amount                             = _amount
    member this.DayCounter                         = _dayCounter
    member this.FixingDate                         = _fixingDate
    member this.FixingDays                         = _fixingDays
    member this.Index                              = _index
    member this.IndexFixing                        = _indexFixing
    member this.ObservationLag                     = _observationLag
    member this.Price                              discountingCurve   
                                                   = _price discountingCurve 
    member this.Pricer                             = _pricer
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
  Essentially a copy of the nominal version but taking a different index and a set of pricers (not just one).  The payoff P of a capped inflation-rate coupon with paysWithin = true is:  P = N T L + b, C).  where N is the notional, T is the accrual time, L is the inflation rate, a is its gearing, b is the spread, and C and F the strikes.  The payoff of a floored inflation-rate coupon is:  P = N T L + b, F).  The payoff of a collared inflation-rate coupon is:  P = N T L + b, F), C).  If paysWithin = false then the inverse is returned (this provides for instrument cap and caplet prices).  They can be decomposed in the following manner.  Decomposition of a capped floating rate coupon when paysWithin = true: R = L + b, C) = (a L + b) + - b - |a| L, 0) where = sgn(a) Then: R = (a L + b) + |a| - b}{|a|} - L, 0)
we may watch an underlying coupon ...
  </summary> *)
[<AutoSerializable(true)>]
type CappedFlooredYoYInflationCouponModel1
    ( underlying                                   : ICell<YoYInflationCoupon>
    , cap                                          : ICell<Nullable<double>>
    , floor                                        : ICell<Nullable<double>>
    ) as this =

    inherit Model<CappedFlooredYoYInflationCoupon> ()
(*
    Parameters
*)
    let _underlying                                = underlying
    let _cap                                       = cap
    let _floor                                     = floor
(*
    Functions
*)
    let mutable
        _CappedFlooredYoYInflationCoupon           = make (fun () -> new CappedFlooredYoYInflationCoupon (underlying.Value, cap.Value, floor.Value))
    let _cap                                       = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.cap())
    let _effectiveCap                              = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.effectiveCap())
    let _effectiveFloor                            = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.effectiveFloor())
    let _floor                                     = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.floor())
    let _isCapped                                  = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.isCapped())
    let _isFloored                                 = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.isFloored())
    let _rate                                      = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.rate())
    let _setPricer                                 (pricer : ICell<YoYInflationCouponPricer>)   
                                                   = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.setPricer(pricer.Value)
                                                                                                      _CappedFlooredYoYInflationCoupon.Value)
    let _adjustedFixing                            = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.adjustedFixing())
    let _gearing                                   = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.gearing())
    let _spread                                    = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.spread())
    let _yoyIndex                                  = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.yoyIndex())
    let _accruedAmount                             (d : ICell<Date>)   
                                                   = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.accruedAmount(d.Value))
    let _amount                                    = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.amount())
    let _dayCounter                                = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.dayCounter())
    let _fixingDate                                = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.fixingDate())
    let _fixingDays                                = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.fixingDays())
    let _index                                     = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.index())
    let _indexFixing                               = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.indexFixing())
    let _observationLag                            = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.observationLag())
    let _price                                     (discountingCurve : ICell<Handle<YieldTermStructure>>)   
                                                   = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.price(discountingCurve.Value))
    let _pricer                                    = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.pricer())
    let _update                                    = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.update()
                                                                                                      _CappedFlooredYoYInflationCoupon.Value)
    let _accrualDays                               = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.accrualDays())
    let _accrualEndDate                            = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.accrualEndDate())
    let _accrualPeriod                             = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.accrualPeriod())
    let _accrualStartDate                          = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.accrualStartDate())
    let _accruedDays                               (d : ICell<Date>)   
                                                   = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.accruedDays(d.Value))
    let _accruedPeriod                             (d : ICell<Date>)   
                                                   = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.accruedPeriod(d.Value))
    let _date                                      = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.date())
    let _exCouponDate                              = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.exCouponDate())
    let _nominal                                   = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.nominal())
    let _referencePeriodEnd                        = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.referencePeriodEnd)
    let _referencePeriodStart                      = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.referencePeriodStart)
    let _CompareTo                                 (cf : ICell<CashFlow>)   
                                                   = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.CompareTo(cf.Value))
    let _Equals                                    (cf : ICell<Object>)   
                                                   = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.Equals(cf.Value))
    let _hasOccurred                               (refDate : ICell<Date>) (includeRefDate : ICell<Nullable<bool>>)   
                                                   = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.hasOccurred(refDate.Value, includeRefDate.Value))
    let _tradingExCoupon                           (refDate : ICell<Date>)   
                                                   = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.tradingExCoupon(refDate.Value))
    let _accept                                    (v : ICell<IAcyclicVisitor>)   
                                                   = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.accept(v.Value)
                                                                                                      _CappedFlooredYoYInflationCoupon.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.registerWith(handler.Value)
                                                                                                      _CappedFlooredYoYInflationCoupon.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _CappedFlooredYoYInflationCoupon (fun () -> _CappedFlooredYoYInflationCoupon.Value.unregisterWith(handler.Value)
                                                                                                      _CappedFlooredYoYInflationCoupon.Value)
    do this.Bind(_CappedFlooredYoYInflationCoupon)
(* 
    casting 
*)
    internal new () = new CappedFlooredYoYInflationCouponModel1(null,null,null)
    member internal this.Inject v = _CappedFlooredYoYInflationCoupon <- v
    static member Cast (p : ICell<CappedFlooredYoYInflationCoupon>) = 
        if p :? CappedFlooredYoYInflationCouponModel1 then 
            p :?> CappedFlooredYoYInflationCouponModel1
        else
            let o = new CappedFlooredYoYInflationCouponModel1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.underlying                         = _underlying 
    member this.cap                                = _cap 
    member this.floor                              = _floor 
    member this.Cap                                = _cap
    member this.EffectiveCap                       = _effectiveCap
    member this.EffectiveFloor                     = _effectiveFloor
    member this.Floor                              = _floor
    member this.IsCapped                           = _isCapped
    member this.IsFloored                          = _isFloored
    member this.Rate                               = _rate
    member this.SetPricer                          pricer   
                                                   = _setPricer pricer 
    member this.AdjustedFixing                     = _adjustedFixing
    member this.Gearing                            = _gearing
    member this.Spread                             = _spread
    member this.YoyIndex                           = _yoyIndex
    member this.AccruedAmount                      d   
                                                   = _accruedAmount d 
    member this.Amount                             = _amount
    member this.DayCounter                         = _dayCounter
    member this.FixingDate                         = _fixingDate
    member this.FixingDays                         = _fixingDays
    member this.Index                              = _index
    member this.IndexFixing                        = _indexFixing
    member this.ObservationLag                     = _observationLag
    member this.Price                              discountingCurve   
                                                   = _price discountingCurve 
    member this.Pricer                             = _pricer
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
