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
  The analytic pricing engine will be used if none if passed.  instruments

  </summary> *)
[<AutoSerializable(true)>]
type DoubleBarrierOptionModel
    ( barrierType                                  : ICell<DoubleBarrier.Type>
    , barrier_lo                                   : ICell<double>
    , barrier_hi                                   : ICell<double>
    , rebate                                       : ICell<double>
    , payoff                                       : ICell<StrikedTypePayoff>
    , exercise                                     : ICell<Exercise>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<DoubleBarrierOption> ()
(*
    Parameters
*)
    let _barrierType                               = barrierType
    let _barrier_lo                                = barrier_lo
    let _barrier_hi                                = barrier_hi
    let _rebate                                    = rebate
    let _payoff                                    = payoff
    let _exercise                                  = exercise
    let mutable
        _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let mutable
        _DoubleBarrierOption                       = make (fun () -> withEngine pricingEngine evaluationDate (new DoubleBarrierOption (barrierType.Value, barrier_lo.Value, barrier_hi.Value, rebate.Value, payoff.Value, exercise.Value)))
    let _impliedVolatility                         (targetValue : ICell<double>) (Process : ICell<GeneralizedBlackScholesProcess>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>) (minVol : ICell<double>) (maxVol : ICell<double>)   
                                                   = triv _DoubleBarrierOption (fun () -> (withEvaluationDate _evaluationDate _DoubleBarrierOption).impliedVolatility(targetValue.Value, Process.Value, accuracy.Value, maxEvaluations.Value, minVol.Value, maxVol.Value))
    let _delta                                     = triv _DoubleBarrierOption (fun () -> (withEvaluationDate _evaluationDate _DoubleBarrierOption).delta())
    let _deltaForward                              = triv _DoubleBarrierOption (fun () -> (withEvaluationDate _evaluationDate _DoubleBarrierOption).deltaForward())
    let _dividendRho                               = triv _DoubleBarrierOption (fun () -> (withEvaluationDate _evaluationDate _DoubleBarrierOption).dividendRho())
    let _elasticity                                = triv _DoubleBarrierOption (fun () -> (withEvaluationDate _evaluationDate _DoubleBarrierOption).elasticity())
    let _gamma                                     = triv _DoubleBarrierOption (fun () -> (withEvaluationDate _evaluationDate _DoubleBarrierOption).gamma())
    let _isExpired                                 = triv _DoubleBarrierOption (fun () -> (withEvaluationDate _evaluationDate _DoubleBarrierOption).isExpired())
    let _itmCashProbability                        = triv _DoubleBarrierOption (fun () -> (withEvaluationDate _evaluationDate _DoubleBarrierOption).itmCashProbability())
    let _rho                                       = triv _DoubleBarrierOption (fun () -> (withEvaluationDate _evaluationDate _DoubleBarrierOption).rho())
    let _strikeSensitivity                         = triv _DoubleBarrierOption (fun () -> (withEvaluationDate _evaluationDate _DoubleBarrierOption).strikeSensitivity())
    let _theta                                     = triv _DoubleBarrierOption (fun () -> (withEvaluationDate _evaluationDate _DoubleBarrierOption).theta())
    let _thetaPerDay                               = triv _DoubleBarrierOption (fun () -> (withEvaluationDate _evaluationDate _DoubleBarrierOption).thetaPerDay())
    let _vega                                      = triv _DoubleBarrierOption (fun () -> (withEvaluationDate _evaluationDate _DoubleBarrierOption).vega())
    let _exercise                                  = cell _DoubleBarrierOption (fun () -> (withEvaluationDate _evaluationDate _DoubleBarrierOption).exercise())
    let _payoff                                    = cell _DoubleBarrierOption (fun () -> (withEvaluationDate _evaluationDate _DoubleBarrierOption).payoff())
    let _CASH                                      = cell _DoubleBarrierOption (fun () -> (withEvaluationDate _evaluationDate _DoubleBarrierOption).CASH())
    let _errorEstimate                             = triv _DoubleBarrierOption (fun () -> (withEvaluationDate _evaluationDate _DoubleBarrierOption).errorEstimate())
    let _NPV                                       = cell _DoubleBarrierOption (fun () -> (withEvaluationDate _evaluationDate _DoubleBarrierOption).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv _DoubleBarrierOption (fun () -> (withEvaluationDate _evaluationDate _DoubleBarrierOption).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv _DoubleBarrierOption (fun () -> (withEvaluationDate _evaluationDate _DoubleBarrierOption).setPricingEngine(e.Value)
                                                                                          _DoubleBarrierOption.Value)
    let _valuationDate                             = triv _DoubleBarrierOption (fun () -> (withEvaluationDate _evaluationDate _DoubleBarrierOption).valuationDate())
    do this.Bind(_DoubleBarrierOption)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new DoubleBarrierOptionModel(null,null,null,null,null,null,null,null)
    member internal this.Inject v = _DoubleBarrierOption <- v
    static member Cast (p : ICell<DoubleBarrierOption>) = 
        if p :? DoubleBarrierOptionModel then 
            p :?> DoubleBarrierOptionModel
        else
            let o = new DoubleBarrierOptionModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.barrierType                        = _barrierType 
    member this.barrier_lo                         = _barrier_lo 
    member this.barrier_hi                         = _barrier_hi 
    member this.rebate                             = _rebate 
    member this.payoff                             = _payoff 
    member this.exercise                           = _exercise 
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
