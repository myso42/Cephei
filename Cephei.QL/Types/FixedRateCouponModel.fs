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
  %Coupon paying a fixed interest rate

  </summary> *)
[<AutoSerializable(true)>]
type FixedRateCouponModel
    ( paymentDate                                  : ICell<Date>
    , nominal                                      : ICell<double>
    , interestRate                                 : ICell<InterestRate>
    , accrualStartDate                             : ICell<Date>
    , accrualEndDate                               : ICell<Date>
    , refPeriodStart                               : ICell<Date>
    , refPeriodEnd                                 : ICell<Date>
    , exCouponDate                                 : ICell<Date>
    , amount                                       : ICell<Nullable<double>>
    ) as this =

    inherit Model<FixedRateCoupon> ()
(*
    Parameters
*)
    let _paymentDate                               = paymentDate
    let _nominal                                   = nominal
    let _interestRate                              = interestRate
    let _accrualStartDate                          = accrualStartDate
    let _accrualEndDate                            = accrualEndDate
    let _refPeriodStart                            = refPeriodStart
    let _refPeriodEnd                              = refPeriodEnd
    let _exCouponDate                              = exCouponDate
    let _amount                                    = amount
(*
    Functions
*)
    let mutable
        _FixedRateCoupon                           = make (fun () -> new FixedRateCoupon (paymentDate.Value, nominal.Value, interestRate.Value, accrualStartDate.Value, accrualEndDate.Value, refPeriodStart.Value, refPeriodEnd.Value, exCouponDate.Value, amount.Value))
    let _accruedAmount                             (d : ICell<Date>)   
                                                   = triv _FixedRateCoupon (fun () -> _FixedRateCoupon.Value.accruedAmount(d.Value))
    let _amount                                    = triv _FixedRateCoupon (fun () -> _FixedRateCoupon.Value.amount())
    let _dayCounter                                = triv _FixedRateCoupon (fun () -> _FixedRateCoupon.Value.dayCounter())
    let _interestRate                              = triv _FixedRateCoupon (fun () -> _FixedRateCoupon.Value.interestRate())
    let _rate                                      = triv _FixedRateCoupon (fun () -> _FixedRateCoupon.Value.rate())
    let _accrualDays                               = triv _FixedRateCoupon (fun () -> _FixedRateCoupon.Value.accrualDays())
    let _accrualEndDate                            = triv _FixedRateCoupon (fun () -> _FixedRateCoupon.Value.accrualEndDate())
    let _accrualPeriod                             = triv _FixedRateCoupon (fun () -> _FixedRateCoupon.Value.accrualPeriod())
    let _accrualStartDate                          = triv _FixedRateCoupon (fun () -> _FixedRateCoupon.Value.accrualStartDate())
    let _accruedDays                               (d : ICell<Date>)   
                                                   = triv _FixedRateCoupon (fun () -> _FixedRateCoupon.Value.accruedDays(d.Value))
    let _accruedPeriod                             (d : ICell<Date>)   
                                                   = triv _FixedRateCoupon (fun () -> _FixedRateCoupon.Value.accruedPeriod(d.Value))
    let _date                                      = triv _FixedRateCoupon (fun () -> _FixedRateCoupon.Value.date())
    let _exCouponDate                              = triv _FixedRateCoupon (fun () -> _FixedRateCoupon.Value.exCouponDate())
    let _nominal                                   = triv _FixedRateCoupon (fun () -> _FixedRateCoupon.Value.nominal())
    let _referencePeriodEnd                        = triv _FixedRateCoupon (fun () -> _FixedRateCoupon.Value.referencePeriodEnd)
    let _referencePeriodStart                      = triv _FixedRateCoupon (fun () -> _FixedRateCoupon.Value.referencePeriodStart)
    let _CompareTo                                 (cf : ICell<CashFlow>)   
                                                   = triv _FixedRateCoupon (fun () -> _FixedRateCoupon.Value.CompareTo(cf.Value))
    let _Equals                                    (cf : ICell<Object>)   
                                                   = triv _FixedRateCoupon (fun () -> _FixedRateCoupon.Value.Equals(cf.Value))
    let _hasOccurred                               (refDate : ICell<Date>) (includeRefDate : ICell<Nullable<bool>>)   
                                                   = triv _FixedRateCoupon (fun () -> _FixedRateCoupon.Value.hasOccurred(refDate.Value, includeRefDate.Value))
    let _tradingExCoupon                           (refDate : ICell<Date>)   
                                                   = triv _FixedRateCoupon (fun () -> _FixedRateCoupon.Value.tradingExCoupon(refDate.Value))
    let _accept                                    (v : ICell<IAcyclicVisitor>)   
                                                   = triv _FixedRateCoupon (fun () -> _FixedRateCoupon.Value.accept(v.Value)
                                                                                      _FixedRateCoupon.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _FixedRateCoupon (fun () -> _FixedRateCoupon.Value.registerWith(handler.Value)
                                                                                      _FixedRateCoupon.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _FixedRateCoupon (fun () -> _FixedRateCoupon.Value.unregisterWith(handler.Value)
                                                                                      _FixedRateCoupon.Value)
    do this.Bind(_FixedRateCoupon)
(* 
    casting 
*)
    internal new () = new FixedRateCouponModel(null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _FixedRateCoupon <- v
    static member Cast (p : ICell<FixedRateCoupon>) = 
        if p :? FixedRateCouponModel then 
            p :?> FixedRateCouponModel
        else
            let o = new FixedRateCouponModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.paymentDate                        = _paymentDate 
    member this.nominal                            = _nominal 
    member this.interestRate                       = _interestRate 
    member this.accrualStartDate                   = _accrualStartDate 
    member this.accrualEndDate                     = _accrualEndDate 
    member this.refPeriodStart                     = _refPeriodStart 
    member this.refPeriodEnd                       = _refPeriodEnd 
    member this.exCouponDate                       = _exCouponDate 
    member this.amount                             = _amount 
    member this.AccruedAmount                      d   
                                                   = _accruedAmount d 
    member this.Amount                             = _amount
    member this.DayCounter                         = _dayCounter
    member this.InterestRate                       = _interestRate
    member this.Rate                               = _rate
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
  %Coupon paying a fixed interest rate
constructors
  </summary> *)
[<AutoSerializable(true)>]
type FixedRateCouponModel1
    ( paymentDate                                  : ICell<Date>
    , nominal                                      : ICell<double>
    , rate                                         : ICell<double>
    , dayCounter                                   : ICell<DayCounter>
    , accrualStartDate                             : ICell<Date>
    , accrualEndDate                               : ICell<Date>
    , refPeriodStart                               : ICell<Date>
    , refPeriodEnd                                 : ICell<Date>
    , exCouponDate                                 : ICell<Date>
    ) as this =

    inherit Model<FixedRateCoupon> ()
(*
    Parameters
*)
    let _paymentDate                               = paymentDate
    let _nominal                                   = nominal
    let _rate                                      = rate
    let _dayCounter                                = dayCounter
    let _accrualStartDate                          = accrualStartDate
    let _accrualEndDate                            = accrualEndDate
    let _refPeriodStart                            = refPeriodStart
    let _refPeriodEnd                              = refPeriodEnd
    let _exCouponDate                              = exCouponDate
(*
    Functions
*)
    let mutable
        _FixedRateCoupon                           = make (fun () -> new FixedRateCoupon (paymentDate.Value, nominal.Value, rate.Value, dayCounter.Value, accrualStartDate.Value, accrualEndDate.Value, refPeriodStart.Value, refPeriodEnd.Value, exCouponDate.Value))
    let _accruedAmount                             (d : ICell<Date>)   
                                                   = triv _FixedRateCoupon (fun () -> _FixedRateCoupon.Value.accruedAmount(d.Value))
    let _amount                                    = triv _FixedRateCoupon (fun () -> _FixedRateCoupon.Value.amount())
    let _dayCounter                                = triv _FixedRateCoupon (fun () -> _FixedRateCoupon.Value.dayCounter())
    let _interestRate                              = triv _FixedRateCoupon (fun () -> _FixedRateCoupon.Value.interestRate())
    let _rate                                      = triv _FixedRateCoupon (fun () -> _FixedRateCoupon.Value.rate())
    let _accrualDays                               = triv _FixedRateCoupon (fun () -> _FixedRateCoupon.Value.accrualDays())
    let _accrualEndDate                            = triv _FixedRateCoupon (fun () -> _FixedRateCoupon.Value.accrualEndDate())
    let _accrualPeriod                             = triv _FixedRateCoupon (fun () -> _FixedRateCoupon.Value.accrualPeriod())
    let _accrualStartDate                          = triv _FixedRateCoupon (fun () -> _FixedRateCoupon.Value.accrualStartDate())
    let _accruedDays                               (d : ICell<Date>)   
                                                   = triv _FixedRateCoupon (fun () -> _FixedRateCoupon.Value.accruedDays(d.Value))
    let _accruedPeriod                             (d : ICell<Date>)   
                                                   = triv _FixedRateCoupon (fun () -> _FixedRateCoupon.Value.accruedPeriod(d.Value))
    let _date                                      = triv _FixedRateCoupon (fun () -> _FixedRateCoupon.Value.date())
    let _exCouponDate                              = triv _FixedRateCoupon (fun () -> _FixedRateCoupon.Value.exCouponDate())
    let _nominal                                   = triv _FixedRateCoupon (fun () -> _FixedRateCoupon.Value.nominal())
    let _referencePeriodEnd                        = triv _FixedRateCoupon (fun () -> _FixedRateCoupon.Value.referencePeriodEnd)
    let _referencePeriodStart                      = triv _FixedRateCoupon (fun () -> _FixedRateCoupon.Value.referencePeriodStart)
    let _CompareTo                                 (cf : ICell<CashFlow>)   
                                                   = triv _FixedRateCoupon (fun () -> _FixedRateCoupon.Value.CompareTo(cf.Value))
    let _Equals                                    (cf : ICell<Object>)   
                                                   = triv _FixedRateCoupon (fun () -> _FixedRateCoupon.Value.Equals(cf.Value))
    let _hasOccurred                               (refDate : ICell<Date>) (includeRefDate : ICell<Nullable<bool>>)   
                                                   = triv _FixedRateCoupon (fun () -> _FixedRateCoupon.Value.hasOccurred(refDate.Value, includeRefDate.Value))
    let _tradingExCoupon                           (refDate : ICell<Date>)   
                                                   = triv _FixedRateCoupon (fun () -> _FixedRateCoupon.Value.tradingExCoupon(refDate.Value))
    let _accept                                    (v : ICell<IAcyclicVisitor>)   
                                                   = triv _FixedRateCoupon (fun () -> _FixedRateCoupon.Value.accept(v.Value)
                                                                                      _FixedRateCoupon.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _FixedRateCoupon (fun () -> _FixedRateCoupon.Value.registerWith(handler.Value)
                                                                                      _FixedRateCoupon.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _FixedRateCoupon (fun () -> _FixedRateCoupon.Value.unregisterWith(handler.Value)
                                                                                      _FixedRateCoupon.Value)
    do this.Bind(_FixedRateCoupon)
(* 
    casting 
*)
    internal new () = new FixedRateCouponModel1(null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _FixedRateCoupon <- v
    static member Cast (p : ICell<FixedRateCoupon>) = 
        if p :? FixedRateCouponModel1 then 
            p :?> FixedRateCouponModel1
        else
            let o = new FixedRateCouponModel1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.paymentDate                        = _paymentDate 
    member this.nominal                            = _nominal 
    member this.rate                               = _rate 
    member this.dayCounter                         = _dayCounter 
    member this.accrualStartDate                   = _accrualStartDate 
    member this.accrualEndDate                     = _accrualEndDate 
    member this.refPeriodStart                     = _refPeriodStart 
    member this.refPeriodEnd                       = _refPeriodEnd 
    member this.exCouponDate                       = _exCouponDate 
    member this.AccruedAmount                      d   
                                                   = _accruedAmount d 
    member this.Amount                             = _amount
    member this.DayCounter                         = _dayCounter
    member this.InterestRate                       = _interestRate
    member this.Rate                               = _rate
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
