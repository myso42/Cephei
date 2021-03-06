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
  Basket option on a number of assets   instruments

  </summary> *)
[<AutoSerializable(true)>]
type BasketOptionModel
    ( payoff                                       : ICell<BasketPayoff>
    , exercise                                     : ICell<Exercise>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<BasketOption> ()
(*
    Parameters
*)
    let _payoff                                    = payoff
    let _exercise                                  = exercise
    let mutable
        _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let mutable
        _BasketOption                              = make (fun () -> withEngine pricingEngine evaluationDate (new BasketOption (payoff.Value, exercise.Value)))
    let _delta                                     = triv _BasketOption (fun () -> (withEvaluationDate _evaluationDate _BasketOption).delta())
    let _dividendRho                               = triv _BasketOption (fun () -> (withEvaluationDate _evaluationDate _BasketOption).dividendRho())
    let _gamma                                     = triv _BasketOption (fun () -> (withEvaluationDate _evaluationDate _BasketOption).gamma())
    let _isExpired                                 = triv _BasketOption (fun () -> (withEvaluationDate _evaluationDate _BasketOption).isExpired())
    let _rho                                       = triv _BasketOption (fun () -> (withEvaluationDate _evaluationDate _BasketOption).rho())
    let _theta                                     = triv _BasketOption (fun () -> (withEvaluationDate _evaluationDate _BasketOption).theta())
    let _vega                                      = triv _BasketOption (fun () -> (withEvaluationDate _evaluationDate _BasketOption).vega())
    let _exercise                                  = cell _BasketOption (fun () -> (withEvaluationDate _evaluationDate _BasketOption).exercise())
    let _payoff                                    = cell _BasketOption (fun () -> (withEvaluationDate _evaluationDate _BasketOption).payoff())
    let _CASH                                      = cell _BasketOption (fun () -> (withEvaluationDate _evaluationDate _BasketOption).CASH())
    let _errorEstimate                             = triv _BasketOption (fun () -> (withEvaluationDate _evaluationDate _BasketOption).errorEstimate())
    let _NPV                                       = cell _BasketOption (fun () -> (withEvaluationDate _evaluationDate _BasketOption).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv _BasketOption (fun () -> (withEvaluationDate _evaluationDate _BasketOption).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv _BasketOption (fun () -> (withEvaluationDate _evaluationDate _BasketOption).setPricingEngine(e.Value)
                                                                                   _BasketOption.Value)
    let _valuationDate                             = triv _BasketOption (fun () -> (withEvaluationDate _evaluationDate _BasketOption).valuationDate())
    do this.Bind(_BasketOption)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new BasketOptionModel(null,null,null,null)
    member internal this.Inject v = _BasketOption <- v
    static member Cast (p : ICell<BasketOption>) = 
        if p :? BasketOptionModel then 
            p :?> BasketOptionModel
        else
            let o = new BasketOptionModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.payoff                             = _payoff 
    member this.exercise                           = _exercise 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.Delta                              = _delta
    member this.DividendRho                        = _dividendRho
    member this.Gamma                              = _gamma
    member this.IsExpired                          = _isExpired
    member this.Rho                                = _rho
    member this.Theta                              = _theta
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
