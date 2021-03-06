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
  Simple stock class

  </summary> *)
[<AutoSerializable(true)>]
type StockModel
    ( quote                                        : ICell<Handle<Quote>>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<Stock> ()
(*
    Parameters
*)
    let _quote                                     = quote
    let mutable
        _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let mutable
        _Stock                                     = make (fun () -> withEngine pricingEngine evaluationDate (new Stock (quote.Value)))
    let _isExpired                                 = triv _Stock (fun () -> (withEvaluationDate _evaluationDate _Stock).isExpired())
    let _CASH                                      = cell _Stock (fun () -> (withEvaluationDate _evaluationDate _Stock).CASH())
    let _errorEstimate                             = triv _Stock (fun () -> (withEvaluationDate _evaluationDate _Stock).errorEstimate())
    let _NPV                                       = cell _Stock (fun () -> (withEvaluationDate _evaluationDate _Stock).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv _Stock (fun () -> (withEvaluationDate _evaluationDate _Stock).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv _Stock (fun () -> (withEvaluationDate _evaluationDate _Stock).setPricingEngine(e.Value)
                                                                            _Stock.Value)
    let _valuationDate                             = triv _Stock (fun () -> (withEvaluationDate _evaluationDate _Stock).valuationDate())
    do this.Bind(_Stock)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new StockModel(null,null,null)
    member internal this.Inject v = _Stock <- v
    static member Cast (p : ICell<Stock>) = 
        if p :? StockModel then 
            p :?> StockModel
        else
            let o = new StockModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.quote                              = _quote 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.IsExpired                          = _isExpired
    member this.CASH                               = _CASH
    member this.ErrorEstimate                      = _errorEstimate
    member this.NPV                                = _NPV
    member this.Result                             tag   
                                                   = _result tag 
    member this.SetPricingEngine                   e   
                                                   = _setPricingEngine e 
    member this.ValuationDate                      = _valuationDate
