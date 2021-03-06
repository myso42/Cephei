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
  instruments  calculations are tested by checking results against cached values.

  </summary> *)
[<AutoSerializable(true)>]
type ZeroCouponBondModel
    ( settlementDays                               : ICell<int>
    , calendar                                     : ICell<Calendar>
    , faceAmount                                   : ICell<double>
    , maturityDate                                 : ICell<Date>
    , paymentConvention                            : ICell<BusinessDayConvention>
    , redemption                                   : ICell<double>
    , issueDate                                    : ICell<Date>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<ZeroCouponBond> ()
(*
    Parameters
*)
    let _settlementDays                            = settlementDays
    let _calendar                                  = calendar
    let _faceAmount                                = faceAmount
    let _maturityDate                              = maturityDate
    let _paymentConvention                         = paymentConvention
    let _redemption                                = redemption
    let _issueDate                                 = issueDate
    let mutable
        _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let mutable
        _ZeroCouponBond                            = make (fun () -> withEngine pricingEngine evaluationDate (new ZeroCouponBond (settlementDays.Value, calendar.Value, faceAmount.Value, maturityDate.Value, paymentConvention.Value, redemption.Value, issueDate.Value)))
    let _accruedAmount                             (settlement : ICell<Date>)   
                                                   = triv _ZeroCouponBond (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponBond).accruedAmount(settlement.Value))
    let _calendar                                  = triv _ZeroCouponBond (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponBond).calendar())
    let _cashflows                                 = triv _ZeroCouponBond (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponBond).cashflows())
    let _cleanPrice                                = cell _ZeroCouponBond (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponBond).cleanPrice())
    let _cleanPrice1                               (Yield : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>)   
                                                   = cell _ZeroCouponBond (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponBond).cleanPrice(Yield.Value, dc.Value, comp.Value, freq.Value, settlement.Value))
    let _dirtyPrice                                = cell _ZeroCouponBond (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponBond).dirtyPrice())
    let _dirtyPrice1                               (Yield : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>)   
                                                   = triv _ZeroCouponBond (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponBond).dirtyPrice(Yield.Value, dc.Value, comp.Value, freq.Value, settlement.Value))
    let _isExpired                                 = triv _ZeroCouponBond (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponBond).isExpired())
    let _issueDate                                 = triv _ZeroCouponBond (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponBond).issueDate())
    let _isTradable                                (d : ICell<Date>)   
                                                   = triv _ZeroCouponBond (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponBond).isTradable(d.Value))
    let _maturityDate                              = triv _ZeroCouponBond (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponBond).maturityDate())
    let _nextCashFlowDate                          (settlement : ICell<Date>)   
                                                   = triv _ZeroCouponBond (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponBond).nextCashFlowDate(settlement.Value))
    let _nextCouponRate                            (settlement : ICell<Date>)   
                                                   = triv _ZeroCouponBond (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponBond).nextCouponRate(settlement.Value))
    let _notional                                  (d : ICell<Date>)   
                                                   = triv _ZeroCouponBond (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponBond).notional(d.Value))
    let _notionals                                 = triv _ZeroCouponBond (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponBond).notionals())
    let _previousCashFlowDate                      (settlement : ICell<Date>)   
                                                   = triv _ZeroCouponBond (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponBond).previousCashFlowDate(settlement.Value))
    let _previousCouponRate                        (settlement : ICell<Date>)   
                                                   = triv _ZeroCouponBond (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponBond).previousCouponRate(settlement.Value))
    let _redemption                                = triv _ZeroCouponBond (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponBond).redemption())
    let _redemptions                               = triv _ZeroCouponBond (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponBond).redemptions())
    let _settlementDate                            (date : ICell<Date>)   
                                                   = triv _ZeroCouponBond (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponBond).settlementDate(date.Value))
    let _settlementDays                            = triv _ZeroCouponBond (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponBond).settlementDays())
    let _settlementValue                           (cleanPrice : ICell<double>)   
                                                   = triv _ZeroCouponBond (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponBond).settlementValue(cleanPrice.Value))
    let _settlementValue1                          = triv _ZeroCouponBond (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponBond).settlementValue())
    let _startDate                                 = triv _ZeroCouponBond (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponBond).startDate())
    let _yield                                     (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>)   
                                                   = cell _ZeroCouponBond (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponBond).YIELD(dc.Value, comp.Value, freq.Value, accuracy.Value, maxEvaluations.Value))
    let _yield1                                    (cleanPrice : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>)   
                                                   = cell _ZeroCouponBond (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponBond).YIELD(cleanPrice.Value, dc.Value, comp.Value, freq.Value, settlement.Value, accuracy.Value, maxEvaluations.Value))
    let _CASH                                      = cell _ZeroCouponBond (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponBond).CASH())
    let _errorEstimate                             = triv _ZeroCouponBond (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponBond).errorEstimate())
    let _NPV                                       = cell _ZeroCouponBond (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponBond).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv _ZeroCouponBond (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponBond).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv _ZeroCouponBond (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponBond).setPricingEngine(e.Value)
                                                                                     _ZeroCouponBond.Value)
    let _valuationDate                             = triv _ZeroCouponBond (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponBond).valuationDate())
    do this.Bind(_ZeroCouponBond)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new ZeroCouponBondModel(null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _ZeroCouponBond <- v
    static member Cast (p : ICell<ZeroCouponBond>) = 
        if p :? ZeroCouponBondModel then 
            p :?> ZeroCouponBondModel
        else
            let o = new ZeroCouponBondModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.settlementDays                     = _settlementDays 
    member this.calendar                           = _calendar 
    member this.faceAmount                         = _faceAmount 
    member this.maturityDate                       = _maturityDate 
    member this.paymentConvention                  = _paymentConvention 
    member this.redemption                         = _redemption 
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
