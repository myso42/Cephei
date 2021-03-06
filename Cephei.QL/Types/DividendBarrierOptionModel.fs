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
  instruments

  </summary> *)
[<AutoSerializable(true)>]
type DividendBarrierOptionModel
    ( barrierType                                  : ICell<Barrier.Type>
    , barrier                                      : ICell<double>
    , rebate                                       : ICell<double>
    , payoff                                       : ICell<StrikedTypePayoff>
    , exercise                                     : ICell<Exercise>
    , dividendDates                                : ICell<Generic.List<Date>>
    , dividends                                    : ICell<Generic.List<double>>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<DividendBarrierOption> ()
(*
    Parameters
*)
    let _barrierType                               = barrierType
    let _barrier                                   = barrier
    let _rebate                                    = rebate
    let _payoff                                    = payoff
    let _exercise                                  = exercise
    let _dividendDates                             = dividendDates
    let _dividends                                 = dividends
    let mutable
        _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let mutable
        _DividendBarrierOption                     = make (fun () -> withEngine pricingEngine evaluationDate (new DividendBarrierOption (barrierType.Value, barrier.Value, rebate.Value, payoff.Value, exercise.Value, dividendDates.Value, dividends.Value)))
    let _impliedVolatility                         (targetValue : ICell<double>) (Process : ICell<GeneralizedBlackScholesProcess>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>) (minVol : ICell<double>) (maxVol : ICell<double>)   
                                                   = triv _DividendBarrierOption (fun () -> (withEvaluationDate _evaluationDate _DividendBarrierOption).impliedVolatility(targetValue.Value, Process.Value, accuracy.Value, maxEvaluations.Value, minVol.Value, maxVol.Value))
    let _delta                                     = triv _DividendBarrierOption (fun () -> (withEvaluationDate _evaluationDate _DividendBarrierOption).delta())
    let _deltaForward                              = triv _DividendBarrierOption (fun () -> (withEvaluationDate _evaluationDate _DividendBarrierOption).deltaForward())
    let _dividendRho                               = triv _DividendBarrierOption (fun () -> (withEvaluationDate _evaluationDate _DividendBarrierOption).dividendRho())
    let _elasticity                                = triv _DividendBarrierOption (fun () -> (withEvaluationDate _evaluationDate _DividendBarrierOption).elasticity())
    let _gamma                                     = triv _DividendBarrierOption (fun () -> (withEvaluationDate _evaluationDate _DividendBarrierOption).gamma())
    let _isExpired                                 = triv _DividendBarrierOption (fun () -> (withEvaluationDate _evaluationDate _DividendBarrierOption).isExpired())
    let _itmCashProbability                        = triv _DividendBarrierOption (fun () -> (withEvaluationDate _evaluationDate _DividendBarrierOption).itmCashProbability())
    let _rho                                       = triv _DividendBarrierOption (fun () -> (withEvaluationDate _evaluationDate _DividendBarrierOption).rho())
    let _strikeSensitivity                         = triv _DividendBarrierOption (fun () -> (withEvaluationDate _evaluationDate _DividendBarrierOption).strikeSensitivity())
    let _theta                                     = triv _DividendBarrierOption (fun () -> (withEvaluationDate _evaluationDate _DividendBarrierOption).theta())
    let _thetaPerDay                               = triv _DividendBarrierOption (fun () -> (withEvaluationDate _evaluationDate _DividendBarrierOption).thetaPerDay())
    let _vega                                      = triv _DividendBarrierOption (fun () -> (withEvaluationDate _evaluationDate _DividendBarrierOption).vega())
    let _exercise                                  = cell _DividendBarrierOption (fun () -> (withEvaluationDate _evaluationDate _DividendBarrierOption).exercise())
    let _payoff                                    = cell _DividendBarrierOption (fun () -> (withEvaluationDate _evaluationDate _DividendBarrierOption).payoff())
    let _CASH                                      = cell _DividendBarrierOption (fun () -> (withEvaluationDate _evaluationDate _DividendBarrierOption).CASH())
    let _errorEstimate                             = triv _DividendBarrierOption (fun () -> (withEvaluationDate _evaluationDate _DividendBarrierOption).errorEstimate())
    let _NPV                                       = cell _DividendBarrierOption (fun () -> (withEvaluationDate _evaluationDate _DividendBarrierOption).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv _DividendBarrierOption (fun () -> (withEvaluationDate _evaluationDate _DividendBarrierOption).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv _DividendBarrierOption (fun () -> (withEvaluationDate _evaluationDate _DividendBarrierOption).setPricingEngine(e.Value)
                                                                                            _DividendBarrierOption.Value)
    let _valuationDate                             = triv _DividendBarrierOption (fun () -> (withEvaluationDate _evaluationDate _DividendBarrierOption).valuationDate())
    do this.Bind(_DividendBarrierOption)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new DividendBarrierOptionModel(null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _DividendBarrierOption <- v
    static member Cast (p : ICell<DividendBarrierOption>) = 
        if p :? DividendBarrierOptionModel then 
            p :?> DividendBarrierOptionModel
        else
            let o = new DividendBarrierOptionModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.barrierType                        = _barrierType 
    member this.barrier                            = _barrier 
    member this.rebate                             = _rebate 
    member this.payoff                             = _payoff 
    member this.exercise                           = _exercise 
    member this.dividendDates                      = _dividendDates 
    member this.dividends                          = _dividends 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.ImpliedVolatility                  targetValue Process accuracy maxEvaluations minVol maxVol   
                                                   = _impliedVolatility targetValue Process accuracy maxEvaluations minVol maxVol 
    member this.Delta                              = _delta
    member this.DeltaForward                       = _deltaForward
    member this.DividendRho                        = _dividendRho
    member this.Elasticity                         = _elasticity
    member this.Gamma                              = _gamma
    member this.IsExpired                          = _isExpired
    member this.ItmCashProbability                 = _itmCashProbability
    member this.Rho                                = _rho
    member this.StrikeSensitivity                  = _strikeSensitivity
    member this.Theta                              = _theta
    member this.ThetaPerDay                        = _thetaPerDay
    member this.Vega                               = _vega
    member this.Exercise                           = _exercise
    member this.Payoff                             = _payoff
    member this.CASH                               = _CASH
    member this.ErrorEstimate                      = _errorEstimate
    member this.NPV                                = _NPV
    member this.Result                             tag   
                                                   = _result tag 
    member this.SetPricingEngine                   e   
                                                   = _setPricingEngine e 
    member this.ValuationDate                      = _valuationDate
