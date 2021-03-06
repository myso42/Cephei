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
  base option class

  </summary> *)
[<AutoSerializable(true)>]
type OptionModel
    ( payoff                                       : ICell<Payoff>
    , exercise                                     : ICell<Exercise>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<Option> ()
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
        _Option                                    = make (fun () -> withEngine pricingEngine evaluationDate (new Option (payoff.Value, exercise.Value)))
    let _exercise                                  = cell _Option (fun () -> (withEvaluationDate _evaluationDate _Option).exercise())
    let _payoff                                    = cell _Option (fun () -> (withEvaluationDate _evaluationDate _Option).payoff())
    let _CASH                                      = cell _Option (fun () -> (withEvaluationDate _evaluationDate _Option).CASH())
    let _errorEstimate                             = triv _Option (fun () -> (withEvaluationDate _evaluationDate _Option).errorEstimate())
    let _isExpired                                 = triv _Option (fun () -> (withEvaluationDate _evaluationDate _Option).isExpired())
    let _NPV                                       = cell _Option (fun () -> (withEvaluationDate _evaluationDate _Option).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv _Option (fun () -> (withEvaluationDate _evaluationDate _Option).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv _Option (fun () -> (withEvaluationDate _evaluationDate _Option).setPricingEngine(e.Value)
                                                                             _Option.Value)
    let _valuationDate                             = triv _Option (fun () -> (withEvaluationDate _evaluationDate _Option).valuationDate())
    do this.Bind(_Option)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new OptionModel(null,null,null,null)
    member internal this.Inject v = _Option <- v
    static member Cast (p : ICell<Option>) = 
        if p :? OptionModel then 
            p :?> OptionModel
        else
            let o = new OptionModel ()
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
    member this.Exercise                           = _exercise
    member this.Payoff                             = _payoff
    member this.CASH                               = _CASH
    member this.ErrorEstimate                      = _errorEstimate
    member this.IsExpired                          = _isExpired
    member this.NPV                                = _NPV
    member this.Result                             tag   
                                                   = _result tag 
    member this.SetPricingEngine                   e   
                                                   = _setPricingEngine e 
    member this.ValuationDate                      = _valuationDate
