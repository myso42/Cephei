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
  This instrument is an aggregate of other instruments. Its NPV is the sum of the NPVs of its components, each possibly multiplied by a given factor.  Methods that drive the calculation directly (such as recalculate(), freeze() and others) might not work correctly.  instruments
Missing Constructor
  </summary> *)
[<AutoSerializable(true)>]
type CompositeInstrumentModel
    ( pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>) as this =
    inherit Model<CompositeInstrument> ()
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
        _CompositeInstrument                       = make (fun () -> withEngine pricingEngine evaluationDate (new CompositeInstrument ()))
    let _add                                       (instrument : ICell<Instrument>) (multiplier : ICell<double>)   
                                                   = triv _CompositeInstrument (fun () -> (withEvaluationDate _evaluationDate _CompositeInstrument).add(instrument.Value, multiplier.Value)
                                                                                          _CompositeInstrument.Value)
    let _isExpired                                 = triv _CompositeInstrument (fun () -> (withEvaluationDate _evaluationDate _CompositeInstrument).isExpired())
    let _subtract                                  (instrument : ICell<Instrument>) (multiplier : ICell<double>)   
                                                   = triv _CompositeInstrument (fun () -> (withEvaluationDate _evaluationDate _CompositeInstrument).subtract(instrument.Value, multiplier.Value)
                                                                                          _CompositeInstrument.Value)
    let _CASH                                      = cell _CompositeInstrument (fun () -> (withEvaluationDate _evaluationDate _CompositeInstrument).CASH())
    let _errorEstimate                             = triv _CompositeInstrument (fun () -> (withEvaluationDate _evaluationDate _CompositeInstrument).errorEstimate())
    let _NPV                                       = cell _CompositeInstrument (fun () -> (withEvaluationDate _evaluationDate _CompositeInstrument).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv _CompositeInstrument (fun () -> (withEvaluationDate _evaluationDate _CompositeInstrument).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv _CompositeInstrument (fun () -> (withEvaluationDate _evaluationDate _CompositeInstrument).setPricingEngine(e.Value)
                                                                                          _CompositeInstrument.Value)
    let _valuationDate                             = triv _CompositeInstrument (fun () -> (withEvaluationDate _evaluationDate _CompositeInstrument).valuationDate())
    do this.Bind(_CompositeInstrument)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new CompositeInstrumentModel(null,null)
    member internal this.Inject v = _CompositeInstrument <- v
    static member Cast (p : ICell<CompositeInstrument>) = 
        if p :? CompositeInstrumentModel then 
            p :?> CompositeInstrumentModel
        else
            let o = new CompositeInstrumentModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.Add                                instrument multiplier   
                                                   = _add instrument multiplier 
    member this.IsExpired                          = _isExpired
    member this.Subtract                           instrument multiplier   
                                                   = _subtract instrument multiplier 
    member this.CASH                               = _CASH
    member this.ErrorEstimate                      = _errorEstimate
    member this.NPV                                = _NPV
    member this.Result                             tag   
                                                   = _result tag 
    member this.SetPricingEngine                   e   
                                                   = _setPricingEngine e 
    member this.ValuationDate                      = _valuationDate
