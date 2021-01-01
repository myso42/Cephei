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
  Continuous-floating lookback option

  </summary> *)
[<AutoSerializable(true)>]
type ContinuousFloatingLookbackOptionModel
    ( minmax                                       : ICell<double>
    , payoff                                       : ICell<TypePayoff>
    , exercise                                     : ICell<Exercise>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<ContinuousFloatingLookbackOption> ()
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
        _ContinuousFloatingLookbackOption          = make (fun () -> withEngine pricingEngine evaluationDate (new ContinuousFloatingLookbackOption (minmax.Value, payoff.Value, exercise.Value)))
    let _delta                                     = triv _ContinuousFloatingLookbackOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousFloatingLookbackOption).delta())
    let _deltaForward                              = triv _ContinuousFloatingLookbackOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousFloatingLookbackOption).deltaForward())
    let _dividendRho                               = triv _ContinuousFloatingLookbackOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousFloatingLookbackOption).dividendRho())
    let _elasticity                                = triv _ContinuousFloatingLookbackOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousFloatingLookbackOption).elasticity())
    let _gamma                                     = triv _ContinuousFloatingLookbackOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousFloatingLookbackOption).gamma())
    let _isExpired                                 = triv _ContinuousFloatingLookbackOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousFloatingLookbackOption).isExpired())
    let _itmCashProbability                        = triv _ContinuousFloatingLookbackOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousFloatingLookbackOption).itmCashProbability())
    let _rho                                       = triv _ContinuousFloatingLookbackOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousFloatingLookbackOption).rho())
    let _strikeSensitivity                         = triv _ContinuousFloatingLookbackOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousFloatingLookbackOption).strikeSensitivity())
    let _theta                                     = triv _ContinuousFloatingLookbackOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousFloatingLookbackOption).theta())
    let _thetaPerDay                               = triv _ContinuousFloatingLookbackOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousFloatingLookbackOption).thetaPerDay())
    let _vega                                      = triv _ContinuousFloatingLookbackOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousFloatingLookbackOption).vega())
    let _exercise                                  = cell _ContinuousFloatingLookbackOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousFloatingLookbackOption).exercise())
    let _payoff                                    = cell _ContinuousFloatingLookbackOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousFloatingLookbackOption).payoff())
    let _CASH                                      = cell _ContinuousFloatingLookbackOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousFloatingLookbackOption).CASH())
    let _errorEstimate                             = triv _ContinuousFloatingLookbackOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousFloatingLookbackOption).errorEstimate())
    let _NPV                                       = cell _ContinuousFloatingLookbackOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousFloatingLookbackOption).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv _ContinuousFloatingLookbackOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousFloatingLookbackOption).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv _ContinuousFloatingLookbackOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousFloatingLookbackOption).setPricingEngine(e.Value)
                                                                                                       _ContinuousFloatingLookbackOption.Value)
    let _valuationDate                             = triv _ContinuousFloatingLookbackOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousFloatingLookbackOption).valuationDate())
    do this.Bind(_ContinuousFloatingLookbackOption)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new ContinuousFloatingLookbackOptionModel(null,null,null,null,null)
    member internal this.Inject v = _ContinuousFloatingLookbackOption <- v
    static member Cast (p : ICell<ContinuousFloatingLookbackOption>) = 
        if p :? ContinuousFloatingLookbackOptionModel then 
            p :?> ContinuousFloatingLookbackOptionModel
        else
            let o = new ContinuousFloatingLookbackOptionModel ()
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
