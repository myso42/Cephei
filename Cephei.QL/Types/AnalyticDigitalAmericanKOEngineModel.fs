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
  vanillaengines  add more greeks (as of now only delta and rho available)  - the correctness of the returned value in case of cash-or-nothing at-hit digital payoff is tested by reproducing results available in literature. - the correctness of the returned value in case of asset-or-nothing at-hit digital payoff is tested by reproducing results available in literature. - the correctness of the returned value in case of cash-or-nothing at-expiry digital payoff is tested by reproducing results available in literature. - the correctness of the returned value in case of asset-or-nothing at-expiry digital payoff is tested by reproducing results available in literature. - the correctness of the returned greeks in case of cash-or-nothing at-hit digital payoff is tested by reproducing numerical derivatives.

  </summary> *)
[<AutoSerializable(true)>]
type AnalyticDigitalAmericanKOEngineModel
    ( engine                                       : ICell<GeneralizedBlackScholesProcess>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<AnalyticDigitalAmericanKOEngine> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _engine                                    = engine
(*
    Functions
*)
    let mutable
        _AnalyticDigitalAmericanKOEngine           = make (fun () -> (createEvaluationDate _evaluationDate (fun () ->new AnalyticDigitalAmericanKOEngine (engine.Value))))
    let _knock_in                                  = triv _AnalyticDigitalAmericanKOEngine (fun () -> (curryEvaluationDate _evaluationDate _AnalyticDigitalAmericanKOEngine).Value.knock_in())
    do this.Bind(_AnalyticDigitalAmericanKOEngine)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new AnalyticDigitalAmericanKOEngineModel(null,null)
    member internal this.Inject v = _AnalyticDigitalAmericanKOEngine <- v
    static member Cast (p : ICell<AnalyticDigitalAmericanKOEngine>) = 
        if p :? AnalyticDigitalAmericanKOEngineModel then 
            p :?> AnalyticDigitalAmericanKOEngineModel
        else
            let o = new AnalyticDigitalAmericanKOEngineModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.engine                             = _engine 
    member this.Knock_in                           = _knock_in
