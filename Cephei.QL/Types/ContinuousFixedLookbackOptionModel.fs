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
  Continuous-fixed lookback option

  </summary> *)
[<AutoSerializable(true)>]
type ContinuousFixedLookbackOptionModel
    ( minmax                                       : ICell<double>
    , payoff                                       : ICell<StrikedTypePayoff>
    , exercise                                     : ICell<Exercise>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<ContinuousFixedLookbackOption> ()
(*
    Parameters
*)
    let _minmax                                    = minmax
    let _payoff                                    = payoff
    let _exercise                                  = exercise
    let mutable
        _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let mutable
        _ContinuousFixedLookbackOption             = make (fun () -> withEngine pricingEngine evaluationDate (new ContinuousFixedLookbackOption (minmax.Value, payoff.Value, exercise.Value)))
    let _delta                                     = triv _ContinuousFixedLookbackOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousFixedLookbackOption).delta())
    let _deltaForward                              = triv _ContinuousFixedLookbackOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousFixedLookbackOption).deltaForward())
    let _dividendRho                               = triv _ContinuousFixedLookbackOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousFixedLookbackOption).dividendRho())
    let _elasticity                                = triv _ContinuousFixedLookbackOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousFixedLookbackOption).elasticity())
    let _gamma                                     = triv _ContinuousFixedLookbackOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousFixedLookbackOption).gamma())
    let _isExpired                                 = triv _ContinuousFixedLookbackOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousFixedLookbackOption).isExpired())
    let _itmCashProbability                        = triv _ContinuousFixedLookbackOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousFixedLookbackOption).itmCashProbability())
    let _rho                                       = triv _ContinuousFixedLookbackOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousFixedLookbackOption).rho())
    let _strikeSensitivity                         = triv _ContinuousFixedLookbackOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousFixedLookbackOption).strikeSensitivity())
    let _theta                                     = triv _ContinuousFixedLookbackOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousFixedLookbackOption).theta())
    let _thetaPerDay                               = triv _ContinuousFixedLookbackOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousFixedLookbackOption).thetaPerDay())
    let _vega                                      = triv _ContinuousFixedLookbackOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousFixedLookbackOption).vega())
    let _exercise                                  = cell _ContinuousFixedLookbackOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousFixedLookbackOption).exercise())
    let _payoff                                    = cell _ContinuousFixedLookbackOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousFixedLookbackOption).payoff())
    let _CASH                                      = cell _ContinuousFixedLookbackOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousFixedLookbackOption).CASH())
    let _errorEstimate                             = triv _ContinuousFixedLookbackOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousFixedLookbackOption).errorEstimate())
    let _NPV                                       = cell _ContinuousFixedLookbackOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousFixedLookbackOption).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv _ContinuousFixedLookbackOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousFixedLookbackOption).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv _ContinuousFixedLookbackOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousFixedLookbackOption).setPricingEngine(e.Value)
                                                                                                    _ContinuousFixedLookbackOption.Value)
    let _valuationDate                             = triv _ContinuousFixedLookbackOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousFixedLookbackOption).valuationDate())
    do this.Bind(_ContinuousFixedLookbackOption)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new ContinuousFixedLookbackOptionModel(null,null,null,null,null)
    member internal this.Inject v = _ContinuousFixedLookbackOption <- v
    static member Cast (p : ICell<ContinuousFixedLookbackOption>) = 
        if p :? ContinuousFixedLookbackOptionModel then 
            p :?> ContinuousFixedLookbackOptionModel
        else
            let o = new ContinuousFixedLookbackOptionModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.minmax                             = _minmax 
    member this.payoff                             = _payoff 
    member this.exercise                           = _exercise 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
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
