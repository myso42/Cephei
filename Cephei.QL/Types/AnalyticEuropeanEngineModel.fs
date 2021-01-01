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
  vanillaengines  - the correctness of the returned value is tested by reproducing results available in literature. - the correctness of the returned greeks is tested by reproducing results available in literature. - the correctness of the returned greeks is tested by reproducing numerical derivatives. - the correctness of the returned implied volatility is tested by using it for reproducing the target value. - the implied-volatility calculation is tested by checking that it does not modify the option. - the correctness of the returned value in case of cash-or-nothing digital payoff is tested by reproducing results available in literature. - the correctness of the returned value in case of asset-or-nothing digital payoff is tested by reproducing results available in literature. - the correctness of the returned value in case of gap digital payoff is tested by reproducing results available in literature. - the correctness of the returned greeks in case of cash-or-nothing digital payoff is tested by reproducing numerical derivatives.

  </summary> *)
[<AutoSerializable(true)>]
type AnalyticEuropeanEngineModel
    ( Process                                      : ICell<GeneralizedBlackScholesProcess>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<AnalyticEuropeanEngine> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _Process                                   = Process
(*
    Functions
*)
    let mutable
        _AnalyticEuropeanEngine                    = make (fun () -> (createEvaluationDate _evaluationDate (fun () ->new AnalyticEuropeanEngine (Process.Value))))
    do this.Bind(_AnalyticEuropeanEngine)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new AnalyticEuropeanEngineModel(null,null)
    member internal this.Inject v = _AnalyticEuropeanEngine <- v
    static member Cast (p : ICell<AnalyticEuropeanEngine>) = 
        if p :? AnalyticEuropeanEngineModel then 
            p :?> AnalyticEuropeanEngineModel
        else
            let o = new AnalyticEuropeanEngineModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Process                            = _Process 
