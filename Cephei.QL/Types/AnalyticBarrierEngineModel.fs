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
  Pricing Engine for barrier options using analytical formulae   The formulas are taken from "Option pricing formulas", E.G. Haug, McGraw-Hill, p.69 and following.  barrierengines  the correctness of the returned value is tested by reproducing results available in literature.

  </summary> *)
[<AutoSerializable(true)>]
type AnalyticBarrierEngineModel
    ( Process                                      : ICell<GeneralizedBlackScholesProcess>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<AnalyticBarrierEngine> ()
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
        _AnalyticBarrierEngine                     = make (fun () -> (createEvaluationDate _evaluationDate (fun () -> (new AnalyticBarrierEngine (Process.Value)))))
    do this.Bind(_AnalyticBarrierEngine)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new AnalyticBarrierEngineModel(null,null)
    member internal this.Inject v = _AnalyticBarrierEngine <- v
    static member Cast (p : ICell<AnalyticBarrierEngine>) = 
        if p :? AnalyticBarrierEngineModel then 
            p :?> AnalyticBarrierEngineModel
        else
            let o = new AnalyticBarrierEngineModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Process                            = _Process 
