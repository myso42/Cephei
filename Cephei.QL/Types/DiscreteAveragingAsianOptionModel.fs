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
  Discrete-averaging Asian option   instruments

  </summary> *)
[<AutoSerializable(true)>]
type DiscreteAveragingAsianOptionModel
    ( averageType                                  : ICell<Average.Type>
    , runningAccumulator                           : ICell<Nullable<double>>
    , pastFixings                                  : ICell<Nullable<int>>
    , fixingDates                                  : ICell<Generic.List<Date>>
    , payoff                                       : ICell<StrikedTypePayoff>
    , exercise                                     : ICell<Exercise>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<DiscreteAveragingAsianOption> ()
(*
    Parameters
*)
    let _averageType                               = averageType
    let _runningAccumulator                        = runningAccumulator
    let _pastFixings                               = pastFixings
    let _fixingDates                               = fixingDates
    let _payoff                                    = payoff
    let _exercise                                  = exercise
    let mutable
        _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let mutable
        _DiscreteAveragingAsianOption              = make (fun () -> withEngine pricingEngine evaluationDate (new DiscreteAveragingAsianOption (averageType.Value, runningAccumulator.Value, pastFixings.Value, fixingDates.Value, payoff.Value, exercise.Value)))
    let _delta                                     = triv _DiscreteAveragingAsianOption (fun () -> (withEvaluationDate _evaluationDate _DiscreteAveragingAsianOption).delta())
    let _deltaForward                              = triv _DiscreteAveragingAsianOption (fun () -> (withEvaluationDate _evaluationDate _DiscreteAveragingAsianOption).deltaForward())
    let _dividendRho                               = triv _DiscreteAveragingAsianOption (fun () -> (withEvaluationDate _evaluationDate _DiscreteAveragingAsianOption).dividendRho())
    let _elasticity                                = triv _DiscreteAveragingAsianOption (fun () -> (withEvaluationDate _evaluationDate _DiscreteAveragingAsianOption).elasticity())
    let _gamma                                     = triv _DiscreteAveragingAsianOption (fun () -> (withEvaluationDate _evaluationDate _DiscreteAveragingAsianOption).gamma())
    let _isExpired                                 = triv _DiscreteAveragingAsianOption (fun () -> (withEvaluationDate _evaluationDate _DiscreteAveragingAsianOption).isExpired())
    let _itmCashProbability                        = triv _DiscreteAveragingAsianOption (fun () -> (withEvaluationDate _evaluationDate _DiscreteAveragingAsianOption).itmCashProbability())
    let _rho                                       = triv _DiscreteAveragingAsianOption (fun () -> (withEvaluationDate _evaluationDate _DiscreteAveragingAsianOption).rho())
    let _strikeSensitivity                         = triv _DiscreteAveragingAsianOption (fun () -> (withEvaluationDate _evaluationDate _DiscreteAveragingAsianOption).strikeSensitivity())
    let _theta                                     = triv _DiscreteAveragingAsianOption (fun () -> (withEvaluationDate _evaluationDate _DiscreteAveragingAsianOption).theta())
    let _thetaPerDay                               = triv _DiscreteAveragingAsianOption (fun () -> (withEvaluationDate _evaluationDate _DiscreteAveragingAsianOption).thetaPerDay())
    let _vega                                      = triv _DiscreteAveragingAsianOption (fun () -> (withEvaluationDate _evaluationDate _DiscreteAveragingAsianOption).vega())
    let _exercise                                  = cell _DiscreteAveragingAsianOption (fun () -> (withEvaluationDate _evaluationDate _DiscreteAveragingAsianOption).exercise())
    let _payoff                                    = cell _DiscreteAveragingAsianOption (fun () -> (withEvaluationDate _evaluationDate _DiscreteAveragingAsianOption).payoff())
    let _CASH                                      = cell _DiscreteAveragingAsianOption (fun () -> (withEvaluationDate _evaluationDate _DiscreteAveragingAsianOption).CASH())
    let _errorEstimate                             = triv _DiscreteAveragingAsianOption (fun () -> (withEvaluationDate _evaluationDate _DiscreteAveragingAsianOption).errorEstimate())
    let _NPV                                       = cell _DiscreteAveragingAsianOption (fun () -> (withEvaluationDate _evaluationDate _DiscreteAveragingAsianOption).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv _DiscreteAveragingAsianOption (fun () -> (withEvaluationDate _evaluationDate _DiscreteAveragingAsianOption).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv _DiscreteAveragingAsianOption (fun () -> (withEvaluationDate _evaluationDate _DiscreteAveragingAsianOption).setPricingEngine(e.Value)
                                                                                                   _DiscreteAveragingAsianOption.Value)
    let _valuationDate                             = triv _DiscreteAveragingAsianOption (fun () -> (withEvaluationDate _evaluationDate _DiscreteAveragingAsianOption).valuationDate())
    do this.Bind(_DiscreteAveragingAsianOption)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new DiscreteAveragingAsianOptionModel(null,null,null,null,null,null,null,null)
    member internal this.Inject v = _DiscreteAveragingAsianOption <- v
    static member Cast (p : ICell<DiscreteAveragingAsianOption>) = 
        if p :? DiscreteAveragingAsianOptionModel then 
            p :?> DiscreteAveragingAsianOptionModel
        else
            let o = new DiscreteAveragingAsianOptionModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.averageType                        = _averageType 
    member this.runningAccumulator                 = _runningAccumulator 
    member this.pastFixings                        = _pastFixings 
    member this.fixingDates                        = _fixingDates 
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
