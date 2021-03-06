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
  amortizing floating-rate bond (possibly capped and/or floored)

  </summary> *)
[<AutoSerializable(true)>]
type AmortizingFloatingRateBondModel
    ( settlementDays                               : ICell<int>
    , notionals                                    : ICell<Generic.List<double>>
    , schedule                                     : ICell<Schedule>
    , index                                        : ICell<IborIndex>
    , accrualDayCounter                            : ICell<DayCounter>
    , paymentConvention                            : ICell<BusinessDayConvention>
    , fixingDays                                   : ICell<int>
    , gearings                                     : ICell<Generic.List<double>>
    , spreads                                      : ICell<Generic.List<double>>
    , caps                                         : ICell<Generic.List<Nullable<double>>>
    , floors                                       : ICell<Generic.List<Nullable<double>>>
    , inArrears                                    : ICell<bool>
    , issueDate                                    : ICell<Date>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<AmortizingFloatingRateBond> ()
(*
    Parameters
*)
    let _settlementDays                            = settlementDays
    let _notionals                                 = notionals
    let _schedule                                  = schedule
    let _index                                     = index
    let _accrualDayCounter                         = accrualDayCounter
    let _paymentConvention                         = paymentConvention
    let _fixingDays                                = fixingDays
    let _gearings                                  = gearings
    let _spreads                                   = spreads
    let _caps                                      = caps
    let _floors                                    = floors
    let _inArrears                                 = inArrears
    let _issueDate                                 = issueDate
    let mutable
        _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let mutable
        _AmortizingFloatingRateBond                = make (fun () -> withEngine pricingEngine evaluationDate (new AmortizingFloatingRateBond (settlementDays.Value, notionals.Value, schedule.Value, index.Value, accrualDayCounter.Value, paymentConvention.Value, fixingDays.Value, gearings.Value, spreads.Value, caps.Value, floors.Value, inArrears.Value, issueDate.Value)))
    let _accruedAmount                             (settlement : ICell<Date>)   
                                                   = triv _AmortizingFloatingRateBond (fun () -> (withEvaluationDate _evaluationDate _AmortizingFloatingRateBond).accruedAmount(settlement.Value))
    let _calendar                                  = triv _AmortizingFloatingRateBond (fun () -> (withEvaluationDate _evaluationDate _AmortizingFloatingRateBond).calendar())
    let _cashflows                                 = triv _AmortizingFloatingRateBond (fun () -> (withEvaluationDate _evaluationDate _AmortizingFloatingRateBond).cashflows())
    let _cleanPrice                                = cell _AmortizingFloatingRateBond (fun () -> (withEvaluationDate _evaluationDate _AmortizingFloatingRateBond).cleanPrice())
    let _cleanPrice1                               (Yield : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>)   
                                                   = cell _AmortizingFloatingRateBond (fun () -> (withEvaluationDate _evaluationDate _AmortizingFloatingRateBond).cleanPrice(Yield.Value, dc.Value, comp.Value, freq.Value, settlement.Value))
    let _dirtyPrice                                = cell _AmortizingFloatingRateBond (fun () -> (withEvaluationDate _evaluationDate _AmortizingFloatingRateBond).dirtyPrice())
    let _dirtyPrice1                               (Yield : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>)   
                                                   = triv _AmortizingFloatingRateBond (fun () -> (withEvaluationDate _evaluationDate _AmortizingFloatingRateBond).dirtyPrice(Yield.Value, dc.Value, comp.Value, freq.Value, settlement.Value))
    let _isExpired                                 = triv _AmortizingFloatingRateBond (fun () -> (withEvaluationDate _evaluationDate _AmortizingFloatingRateBond).isExpired())
    let _issueDate                                 = triv _AmortizingFloatingRateBond (fun () -> (withEvaluationDate _evaluationDate _AmortizingFloatingRateBond).issueDate())
    let _isTradable                                (d : ICell<Date>)   
                                                   = triv _AmortizingFloatingRateBond (fun () -> (withEvaluationDate _evaluationDate _AmortizingFloatingRateBond).isTradable(d.Value))
    let _maturityDate                              = triv _AmortizingFloatingRateBond (fun () -> (withEvaluationDate _evaluationDate _AmortizingFloatingRateBond).maturityDate())
    let _nextCashFlowDate                          (settlement : ICell<Date>)   
                                                   = triv _AmortizingFloatingRateBond (fun () -> (withEvaluationDate _evaluationDate _AmortizingFloatingRateBond).nextCashFlowDate(settlement.Value))
    let _nextCouponRate                            (settlement : ICell<Date>)   
                                                   = triv _AmortizingFloatingRateBond (fun () -> (withEvaluationDate _evaluationDate _AmortizingFloatingRateBond).nextCouponRate(settlement.Value))
    let _notional                                  (d : ICell<Date>)   
                                                   = triv _AmortizingFloatingRateBond (fun () -> (withEvaluationDate _evaluationDate _AmortizingFloatingRateBond).notional(d.Value))
    let _notionals                                 = triv _AmortizingFloatingRateBond (fun () -> (withEvaluationDate _evaluationDate _AmortizingFloatingRateBond).notionals())
    let _previousCashFlowDate                      (settlement : ICell<Date>)   
                                                   = triv _AmortizingFloatingRateBond (fun () -> (withEvaluationDate _evaluationDate _AmortizingFloatingRateBond).previousCashFlowDate(settlement.Value))
    let _previousCouponRate                        (settlement : ICell<Date>)   
                                                   = triv _AmortizingFloatingRateBond (fun () -> (withEvaluationDate _evaluationDate _AmortizingFloatingRateBond).previousCouponRate(settlement.Value))
    let _redemption                                = triv _AmortizingFloatingRateBond (fun () -> (withEvaluationDate _evaluationDate _AmortizingFloatingRateBond).redemption())
    let _redemptions                               = triv _AmortizingFloatingRateBond (fun () -> (withEvaluationDate _evaluationDate _AmortizingFloatingRateBond).redemptions())
    let _settlementDate                            (date : ICell<Date>)   
                                                   = triv _AmortizingFloatingRateBond (fun () -> (withEvaluationDate _evaluationDate _AmortizingFloatingRateBond).settlementDate(date.Value))
    let _settlementDays                            = triv _AmortizingFloatingRateBond (fun () -> (withEvaluationDate _evaluationDate _AmortizingFloatingRateBond).settlementDays())
    let _settlementValue                           (cleanPrice : ICell<double>)   
                                                   = triv _AmortizingFloatingRateBond (fun () -> (withEvaluationDate _evaluationDate _AmortizingFloatingRateBond).settlementValue(cleanPrice.Value))
    let _settlementValue1                          = triv _AmortizingFloatingRateBond (fun () -> (withEvaluationDate _evaluationDate _AmortizingFloatingRateBond).settlementValue())
    let _startDate                                 = triv _AmortizingFloatingRateBond (fun () -> (withEvaluationDate _evaluationDate _AmortizingFloatingRateBond).startDate())
    let _yield                                     (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>)   
                                                   = cell _AmortizingFloatingRateBond (fun () -> (withEvaluationDate _evaluationDate _AmortizingFloatingRateBond).YIELD(dc.Value, comp.Value, freq.Value, accuracy.Value, maxEvaluations.Value))
    let _yield1                                    (cleanPrice : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>)   
                                                   = triv _AmortizingFloatingRateBond (fun () -> (withEvaluationDate _evaluationDate _AmortizingFloatingRateBond).YIELD(cleanPrice.Value, dc.Value, comp.Value, freq.Value, settlement.Value, accuracy.Value, maxEvaluations.Value))
    let _CASH                                      = cell _AmortizingFloatingRateBond (fun () -> (withEvaluationDate _evaluationDate _AmortizingFloatingRateBond).CASH())
    let _errorEstimate                             = triv _AmortizingFloatingRateBond (fun () -> (withEvaluationDate _evaluationDate _AmortizingFloatingRateBond).errorEstimate())
    let _NPV                                       = cell _AmortizingFloatingRateBond (fun () -> (withEvaluationDate _evaluationDate _AmortizingFloatingRateBond).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv _AmortizingFloatingRateBond (fun () -> (withEvaluationDate _evaluationDate _AmortizingFloatingRateBond).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv _AmortizingFloatingRateBond (fun () -> (withEvaluationDate _evaluationDate _AmortizingFloatingRateBond).setPricingEngine(e.Value)
                                                                                                 _AmortizingFloatingRateBond.Value)
    let _valuationDate                             = triv _AmortizingFloatingRateBond (fun () -> (withEvaluationDate _evaluationDate _AmortizingFloatingRateBond).valuationDate())
    do this.Bind(_AmortizingFloatingRateBond)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new AmortizingFloatingRateBondModel(null,null,null,null,null,null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _AmortizingFloatingRateBond <- v
    static member Cast (p : ICell<AmortizingFloatingRateBond>) = 
        if p :? AmortizingFloatingRateBondModel then 
            p :?> AmortizingFloatingRateBondModel
        else
            let o = new AmortizingFloatingRateBondModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.settlementDays                     = _settlementDays 
    member this.notionals                          = _notionals 
    member this.schedule                           = _schedule 
    member this.index                              = _index 
    member this.accrualDayCounter                  = _accrualDayCounter 
    member this.paymentConvention                  = _paymentConvention 
    member this.fixingDays                         = _fixingDays 
    member this.gearings                           = _gearings 
    member this.spreads                            = _spreads 
    member this.caps                               = _caps 
    member this.floors                             = _floors 
    member this.inArrears                          = _inArrears 
    member this.issueDate                          = _issueDate 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.AccruedAmount                      settlement   
                                                   = _accruedAmount settlement 
    member this.Calendar                           = _calendar
    member this.Cashflows                          = _cashflows
    member this.CleanPrice                         = _cleanPrice
    member this.CleanPrice1                        Yield dc comp freq settlement   
                                                   = _cleanPrice1 Yield dc comp freq settlement 
    member this.DirtyPrice                         = _dirtyPrice
    member this.DirtyPrice1                        Yield dc comp freq settlement   
                                                   = _dirtyPrice1 Yield dc comp freq settlement 
    member this.IsExpired                          = _isExpired
    member this.IssueDate                          = _issueDate
    member this.IsTradable                         d   
                                                   = _isTradable d 
    member this.MaturityDate                       = _maturityDate
    member this.NextCashFlowDate                   settlement   
                                                   = _nextCashFlowDate settlement 
    member this.NextCouponRate                     settlement   
                                                   = _nextCouponRate settlement 
    member this.Notional                           d   
                                                   = _notional d 
    member this.Notionals                          = _notionals
    member this.PreviousCashFlowDate               settlement   
                                                   = _previousCashFlowDate settlement 
    member this.PreviousCouponRate                 settlement   
                                                   = _previousCouponRate settlement 
    member this.Redemption                         = _redemption
    member this.Redemptions                        = _redemptions
    member this.SettlementDate                     date   
                                                   = _settlementDate date 
    member this.SettlementDays                     = _settlementDays
    member this.SettlementValue                    cleanPrice   
                                                   = _settlementValue cleanPrice 
    member this.SettlementValue1                   = _settlementValue1
    member this.StartDate                          = _startDate
    member this.Yield                              dc comp freq accuracy maxEvaluations   
                                                   = _yield dc comp freq accuracy maxEvaluations 
    member this.Yield1                             cleanPrice dc comp freq settlement accuracy maxEvaluations   
                                                   = _yield1 cleanPrice dc comp freq settlement accuracy maxEvaluations 
    member this.CASH                               = _CASH
    member this.ErrorEstimate                      = _errorEstimate
    member this.NPV                                = _NPV
    member this.Result                             tag   
                                                   = _result tag 
    member this.SetPricingEngine                   e   
                                                   = _setPricingEngine e 
    member this.ValuationDate                      = _valuationDate
