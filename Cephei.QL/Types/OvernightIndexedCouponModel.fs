(*
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


  </summary> *)
[<AutoSerializable(true)>]
type OvernightIndexedCouponModel
    ( paymentDate                                  : ICell<Date>
    , nominal                                      : ICell<double>
    , startDate                                    : ICell<Date>
    , endDate                                      : ICell<Date>
    , overnightIndex                               : ICell<OvernightIndex>
    , gearing                                      : ICell<double>
    , spread                                       : ICell<double>
    , refPeriodStart                               : ICell<Date>
    , refPeriodEnd                                 : ICell<Date>
    , dayCounter                                   : ICell<DayCounter>
    ) as this =

    inherit Model<OvernightIndexedCoupon> ()
(*
    Parameters
*)
    let _paymentDate                               = paymentDate
    let _nominal                                   = nominal
    let _startDate                                 = startDate
    let _endDate                                   = endDate
    let _overnightIndex                            = overnightIndex
    let _gearing                                   = gearing
    let _spread                                    = spread
    let _refPeriodStart                            = refPeriodStart
    let _refPeriodEnd                              = refPeriodEnd
    let _dayCounter                                = dayCounter
(*
    Functions
*)
    let _OvernightIndexedCoupon                    = cell (fun () -> new OvernightIndexedCoupon (paymentDate.Value, nominal.Value, startDate.Value, endDate.Value, overnightIndex.Value, gearing.Value, spread.Value, refPeriodStart.Value, refPeriodEnd.Value, dayCounter.Value))
    let _dt                                        = triv (fun () -> _OvernightIndexedCoupon.Value.dt())
    let _fixingDates                               = triv (fun () -> _OvernightIndexedCoupon.Value.fixingDates())
    let _indexFixings                              = triv (fun () -> _OvernightIndexedCoupon.Value.indexFixings())
    let _valueDates                                = triv (fun () -> _OvernightIndexedCoupon.Value.valueDates())
    let _accruedAmount                             (d : ICell<Date>)   
                                                   = triv (fun () -> _OvernightIndexedCoupon.Value.accruedAmount(d.Value))
    let _adjustedFixing                            = triv (fun () -> _OvernightIndexedCoupon.Value.adjustedFixing)
    let _amount                                    = triv (fun () -> _OvernightIndexedCoupon.Value.amount())
    let _convexityAdjustment                       = triv (fun () -> _OvernightIndexedCoupon.Value.convexityAdjustment())
    let _dayCounter                                = triv (fun () -> _OvernightIndexedCoupon.Value.dayCounter())
    let _factory                                   (nominal : ICell<double>) (paymentDate : ICell<Date>) (startDate : ICell<Date>) (endDate : ICell<Date>) (fixingDays : ICell<int>) (index : ICell<InterestRateIndex>) (gearing : ICell<double>) (spread : ICell<double>) (refPeriodStart : ICell<Date>) (refPeriodEnd : ICell<Date>) (dayCounter : ICell<DayCounter>) (isInArrears : ICell<bool>)   
                                                   = triv (fun () -> _OvernightIndexedCoupon.Value.factory(nominal.Value, paymentDate.Value, startDate.Value, endDate.Value, fixingDays.Value, index.Value, gearing.Value, spread.Value, refPeriodStart.Value, refPeriodEnd.Value, dayCounter.Value, isInArrears.Value))
    let _fixingDate                                = triv (fun () -> _OvernightIndexedCoupon.Value.fixingDate())
    let _fixingDays                                = triv (fun () -> _OvernightIndexedCoupon.Value.fixingDays)
    let _gearing                                   = triv (fun () -> _OvernightIndexedCoupon.Value.gearing())
    let _index                                     = triv (fun () -> _OvernightIndexedCoupon.Value.index())
    let _indexFixing                               = triv (fun () -> _OvernightIndexedCoupon.Value.indexFixing())
    let _isInArrears                               = triv (fun () -> _OvernightIndexedCoupon.Value.isInArrears())
    let _price                                     (yts : ICell<YieldTermStructure>)   
                                                   = triv (fun () -> _OvernightIndexedCoupon.Value.price(yts.Value))
    let _pricer                                    = triv (fun () -> _OvernightIndexedCoupon.Value.pricer())
    let _rate                                      = triv (fun () -> _OvernightIndexedCoupon.Value.rate())
    let _setPricer                                 (pricer : ICell<FloatingRateCouponPricer>)   
                                                   = triv (fun () -> _OvernightIndexedCoupon.Value.setPricer(pricer.Value)
                                                                     _OvernightIndexedCoupon.Value)
    let _spread                                    = triv (fun () -> _OvernightIndexedCoupon.Value.spread())
    let _update                                    = triv (fun () -> _OvernightIndexedCoupon.Value.update()
                                                                     _OvernightIndexedCoupon.Value)
    let _accrualDays                               = triv (fun () -> _OvernightIndexedCoupon.Value.accrualDays())
    let _accrualEndDate                            = triv (fun () -> _OvernightIndexedCoupon.Value.accrualEndDate())
    let _accrualPeriod                             = triv (fun () -> _OvernightIndexedCoupon.Value.accrualPeriod())
    let _accrualStartDate                          = triv (fun () -> _OvernightIndexedCoupon.Value.accrualStartDate())
    let _accruedDays                               (d : ICell<Date>)   
                                                   = triv (fun () -> _OvernightIndexedCoupon.Value.accruedDays(d.Value))
    let _accruedPeriod                             (d : ICell<Date>)   
                                                   = triv (fun () -> _OvernightIndexedCoupon.Value.accruedPeriod(d.Value))
    let _date                                      = triv (fun () -> _OvernightIndexedCoupon.Value.date())
    let _exCouponDate                              = triv (fun () -> _OvernightIndexedCoupon.Value.exCouponDate())
    let _nominal                                   = triv (fun () -> _OvernightIndexedCoupon.Value.nominal())
    let _referencePeriodEnd                        = triv (fun () -> _OvernightIndexedCoupon.Value.referencePeriodEnd)
    let _referencePeriodStart                      = triv (fun () -> _OvernightIndexedCoupon.Value.referencePeriodStart)
    let _CompareTo                                 (cf : ICell<CashFlow>)   
                                                   = triv (fun () -> _OvernightIndexedCoupon.Value.CompareTo(cf.Value))
    let _Equals                                    (cf : ICell<Object>)   
                                                   = triv (fun () -> _OvernightIndexedCoupon.Value.Equals(cf.Value))
    let _hasOccurred                               (refDate : ICell<Date>) (includeRefDate : ICell<Nullable<bool>>)   
                                                   = triv (fun () -> _OvernightIndexedCoupon.Value.hasOccurred(refDate.Value, includeRefDate.Value))
    let _tradingExCoupon                           (refDate : ICell<Date>)   
                                                   = triv (fun () -> _OvernightIndexedCoupon.Value.tradingExCoupon(refDate.Value))
    let _accept                                    (v : ICell<IAcyclicVisitor>)   
                                                   = triv (fun () -> _OvernightIndexedCoupon.Value.accept(v.Value)
                                                                     _OvernightIndexedCoupon.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _OvernightIndexedCoupon.Value.registerWith(handler.Value)
                                                                     _OvernightIndexedCoupon.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _OvernightIndexedCoupon.Value.unregisterWith(handler.Value)
                                                                     _OvernightIndexedCoupon.Value)
    do this.Bind(_OvernightIndexedCoupon)

(* 
    Externally visible/bindable properties
*)
    member this.paymentDate                        = _paymentDate 
    member this.nominal                            = _nominal 
    member this.startDate                          = _startDate 
    member this.endDate                            = _endDate 
    member this.overnightIndex                     = _overnightIndex 
    member this.gearing                            = _gearing 
    member this.spread                             = _spread 
    member this.refPeriodStart                     = _refPeriodStart 
    member this.refPeriodEnd                       = _refPeriodEnd 
    member this.dayCounter                         = _dayCounter 
    member this.Dt                                 = _dt
    member this.FixingDates                        = _fixingDates
    member this.IndexFixings                       = _indexFixings
    member this.ValueDates                         = _valueDates
    member this.AccruedAmount                      d   
                                                   = _accruedAmount d 
    member this.AdjustedFixing                     = _adjustedFixing
    member this.Amount                             = _amount
    member this.ConvexityAdjustment                = _convexityAdjustment
    member this.DayCounter                         = _dayCounter
    member this.Factory                            nominal paymentDate startDate endDate fixingDays index gearing spread refPeriodStart refPeriodEnd dayCounter isInArrears   
                                                   = _factory nominal paymentDate startDate endDate fixingDays index gearing spread refPeriodStart refPeriodEnd dayCounter isInArrears 
    member this.FixingDate                         = _fixingDate
    member this.FixingDays                         = _fixingDays
    member this.Gearing                            = _gearing
    member this.Index                              = _index
    member this.IndexFixing                        = _indexFixing
    member this.IsInArrears                        = _isInArrears
    member this.Price                              yts   
                                                   = _price yts 
    member this.Pricer                             = _pricer
    member this.Rate                               = _rate
    member this.SetPricer                          pricer   
                                                   = _setPricer pricer 
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