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
  A cliquet option, also known as Ratchet option, is a series of forward-starting (a.k.a. deferred strike) options where the strike for each forward start option is set equal to a fixed percentage of the spot price at the beginning of each period.  - add local/global caps/floors - add accrued coupon and last fixing  instruments

  </summary> *)
[<AutoSerializable(true)>]
type CliquetOptionModel
    ( payoff                                       : ICell<PercentageStrikePayoff>
    , maturity                                     : ICell<EuropeanExercise>
    , resetDates                                   : ICell<Generic.List<Date>>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<CliquetOption> ()
(*
    Parameters
*)
    let _payoff                                    = payoff
    let _maturity                                  = maturity
    let _resetDates                                = resetDates
    let mutable
        _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let mutable
        _CliquetOption                             = make (fun () -> withEngine pricingEngine evaluationDate (new CliquetOption (payoff.Value, maturity.Value, resetDates.Value)))
    let _delta                                     = triv _CliquetOption (fun () -> (withEvaluationDate _evaluationDate _CliquetOption).delta())
    let _deltaForward                              = triv _CliquetOption (fun () -> (withEvaluationDate _evaluationDate _CliquetOption).deltaForward())
    let _dividendRho                               = triv _CliquetOption (fun () -> (withEvaluationDate _evaluationDate _CliquetOption).dividendRho())
    let _elasticity                                = triv _CliquetOption (fun () -> (withEvaluationDate _evaluationDate _CliquetOption).elasticity())
    let _gamma                                     = triv _CliquetOption (fun () -> (withEvaluationDate _evaluationDate _CliquetOption).gamma())
    let _isExpired                                 = triv _CliquetOption (fun () -> (withEvaluationDate _evaluationDate _CliquetOption).isExpired())
    let _itmCashProbability                        = triv _CliquetOption (fun () -> (withEvaluationDate _evaluationDate _CliquetOption).itmCashProbability())
    let _rho                                       = triv _CliquetOption (fun () -> (withEvaluationDate _evaluationDate _CliquetOption).rho())
    let _strikeSensitivity                         = triv _CliquetOption (fun () -> (withEvaluationDate _evaluationDate _CliquetOption).strikeSensitivity())
    let _theta                                     = triv _CliquetOption (fun () -> (withEvaluationDate _evaluationDate _CliquetOption).theta())
    let _thetaPerDay                               = triv _CliquetOption (fun () -> (withEvaluationDate _evaluationDate _CliquetOption).thetaPerDay())
    let _vega                                      = triv _CliquetOption (fun () -> (withEvaluationDate _evaluationDate _CliquetOption).vega())
    let _exercise                                  = cell _CliquetOption (fun () -> (withEvaluationDate _evaluationDate _CliquetOption).exercise())
    let _payoff                                    = cell _CliquetOption (fun () -> (withEvaluationDate _evaluationDate _CliquetOption).payoff())
    let _CASH                                      = cell _CliquetOption (fun () -> (withEvaluationDate _evaluationDate _CliquetOption).CASH())
    let _errorEstimate                             = triv _CliquetOption (fun () -> (withEvaluationDate _evaluationDate _CliquetOption).errorEstimate())
    let _NPV                                       = cell _CliquetOption (fun () -> (withEvaluationDate _evaluationDate _CliquetOption).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv _CliquetOption (fun () -> (withEvaluationDate _evaluationDate _CliquetOption).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv _CliquetOption (fun () -> (withEvaluationDate _evaluationDate _CliquetOption).setPricingEngine(e.Value)
                                                                                    _CliquetOption.Value)
    let _valuationDate                             = triv _CliquetOption (fun () -> (withEvaluationDate _evaluationDate _CliquetOption).valuationDate())
    do this.Bind(_CliquetOption)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new CliquetOptionModel(null,null,null,null,null)
    member internal this.Inject v = _CliquetOption <- v
    static member Cast (p : ICell<CliquetOption>) = 
        if p :? CliquetOptionModel then 
            p :?> CliquetOptionModel
        else
            let o = new CliquetOptionModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.payoff                             = _payoff 
    member this.maturity                           = _maturity 
    member this.resetDates                         = _resetDates 
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
