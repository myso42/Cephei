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
Abstract instrument class. It defines the interface of concrete instruments
Missing Constructor
  </summary> *)
[<AutoSerializable(true)>]
type InstrumentModel
    ( pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>) as this =
    inherit Model<Instrument> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let mutable
        _Instrument                                = make (fun () -> withEngine pricingEngine evaluationDate (new Instrument ()))
    let _CASH                                      = cell _Instrument (fun () -> (withEvaluationDate _evaluationDate _Instrument).CASH())
    let _errorEstimate                             = triv _Instrument (fun () -> (withEvaluationDate _evaluationDate _Instrument).errorEstimate())
    let _isExpired                                 = triv _Instrument (fun () -> (withEvaluationDate _evaluationDate _Instrument).isExpired())
    let _NPV                                       = cell _Instrument (fun () -> (withEvaluationDate _evaluationDate _Instrument).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv _Instrument (fun () -> (withEvaluationDate _evaluationDate _Instrument).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv _Instrument (fun () -> (withEvaluationDate _evaluationDate _Instrument).setPricingEngine(e.Value)
                                                                                 _Instrument.Value)
    let _valuationDate                             = triv _Instrument (fun () -> (withEvaluationDate _evaluationDate _Instrument).valuationDate())
    do this.Bind(_Instrument)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d
        

    internal new () = new InstrumentModel(null,null)
    member internal this.Inject v = _Instrument <- v
    static member Cast (p : ICell<Instrument>) = 
        if p :? InstrumentModel then 
            p :?> InstrumentModel
        else
            let o = new InstrumentModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o

(* 
    Externally visible/bindable properties
*)
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.CASH                               = _CASH
    member this.ErrorEstimate                      = _errorEstimate
    member this.IsExpired                          = _isExpired
    member this.NPV                                = _NPV
    member this.Result                             tag   
                                                   = _result tag 
    member this.SetPricingEngine                   e   
                                                   = _setPricingEngine e 
    member this.ValuationDate                      = _valuationDate
