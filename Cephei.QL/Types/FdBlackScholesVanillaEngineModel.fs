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


  </summary> *)
[<AutoSerializable(true)>]
type FdBlackScholesVanillaEngineModel
    ( Process                                      : ICell<GeneralizedBlackScholesProcess>
    , tGrid                                        : ICell<int>
    , xGrid                                        : ICell<int>
    , dampingSteps                                 : ICell<int>
    , schemeDesc                                   : ICell<FdmSchemeDesc>
    , localVol                                     : ICell<bool>
    , illegalLocalVolOverwrite                     : ICell<Nullable<double>>
    , cashDividendModel                            : ICell<FdBlackScholesVanillaEngine.CashDividendModel>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<FdBlackScholesVanillaEngine> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _Process                                   = Process
    let _tGrid                                     = tGrid
    let _xGrid                                     = xGrid
    let _dampingSteps                              = dampingSteps
    let _schemeDesc                                = schemeDesc
    let _localVol                                  = localVol
    let _illegalLocalVolOverwrite                  = illegalLocalVolOverwrite
    let _cashDividendModel                         = cashDividendModel
(*
    Functions
*)
    let mutable
        _FdBlackScholesVanillaEngine               = make (fun () -> (createEvaluationDate _evaluationDate (fun () ->new FdBlackScholesVanillaEngine (Process.Value, tGrid.Value, xGrid.Value, dampingSteps.Value, schemeDesc.Value, localVol.Value, illegalLocalVolOverwrite.Value, cashDividendModel.Value))))
    do this.Bind(_FdBlackScholesVanillaEngine)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new FdBlackScholesVanillaEngineModel(null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _FdBlackScholesVanillaEngine <- v
    static member Cast (p : ICell<FdBlackScholesVanillaEngine>) = 
        if p :? FdBlackScholesVanillaEngineModel then 
            p :?> FdBlackScholesVanillaEngineModel
        else
            let o = new FdBlackScholesVanillaEngineModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Process                            = _Process 
    member this.tGrid                              = _tGrid 
    member this.xGrid                              = _xGrid 
    member this.dampingSteps                       = _dampingSteps 
    member this.schemeDesc                         = _schemeDesc 
    member this.localVol                           = _localVol 
    member this.illegalLocalVolOverwrite           = _illegalLocalVolOverwrite 
    member this.cashDividendModel                  = _cashDividendModel 
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type FdBlackScholesVanillaEngineModel1
    ( Process                                      : ICell<GeneralizedBlackScholesProcess>
    , quantoHelper                                 : ICell<FdmQuantoHelper>
    , tGrid                                        : ICell<int>
    , xGrid                                        : ICell<int>
    , dampingSteps                                 : ICell<int>
    , schemeDesc                                   : ICell<FdmSchemeDesc>
    , localVol                                     : ICell<bool>
    , illegalLocalVolOverwrite                     : ICell<Nullable<double>>
    , cashDividendModel                            : ICell<FdBlackScholesVanillaEngine.CashDividendModel>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<FdBlackScholesVanillaEngine> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _Process                                   = Process
    let _quantoHelper                              = quantoHelper
    let _tGrid                                     = tGrid
    let _xGrid                                     = xGrid
    let _dampingSteps                              = dampingSteps
    let _schemeDesc                                = schemeDesc
    let _localVol                                  = localVol
    let _illegalLocalVolOverwrite                  = illegalLocalVolOverwrite
    let _cashDividendModel                         = cashDividendModel
(*
    Functions
*)
    let mutable
        _FdBlackScholesVanillaEngine               = make (fun () -> (createEvaluationDate _evaluationDate (fun () ->new FdBlackScholesVanillaEngine (Process.Value, quantoHelper.Value, tGrid.Value, xGrid.Value, dampingSteps.Value, schemeDesc.Value, localVol.Value, illegalLocalVolOverwrite.Value, cashDividendModel.Value))))
    do this.Bind(_FdBlackScholesVanillaEngine)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new FdBlackScholesVanillaEngineModel1(null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _FdBlackScholesVanillaEngine <- v
    static member Cast (p : ICell<FdBlackScholesVanillaEngine>) = 
        if p :? FdBlackScholesVanillaEngineModel1 then 
            p :?> FdBlackScholesVanillaEngineModel1
        else
            let o = new FdBlackScholesVanillaEngineModel1 ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Process                            = _Process 
    member this.quantoHelper                       = _quantoHelper 
    member this.tGrid                              = _tGrid 
    member this.xGrid                              = _xGrid 
    member this.dampingSteps                       = _dampingSteps 
    member this.schemeDesc                         = _schemeDesc 
    member this.localVol                           = _localVol 
    member this.illegalLocalVolOverwrite           = _illegalLocalVolOverwrite 
    member this.cashDividendModel                  = _cashDividendModel 
