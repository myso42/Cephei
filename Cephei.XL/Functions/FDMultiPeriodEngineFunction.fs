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
namespace Cephei.XL

open ExcelDna.Integration
open Cephei.Cell
open Cephei.Cell.Generic
open Cephei.QL
open System.Collections
open System
open System.Linq
open QLNet
open Cephei.XL.Helper

(* <summary>

  </summary> *)
[<AutoSerializable(true)>]
module FDMultiPeriodEngineFunction =


    (*
        required for generics
    *)
    [<ExcelFunction(Name="_FDMultiPeriodEngine", Description="Create a FDMultiPeriodEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDMultiPeriodEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = (Fun.FDMultiPeriodEngine
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FDMultiPeriodEngine>) l

                let source () = Helper.sourceFold "Fun.FDMultiPeriodEngine" 
                                               [| _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [|  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDMultiPeriodEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FDMultiPeriodEngine_setStepCondition", Description="Create a FDMultiPeriodEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDMultiPeriodEngine_setStepCondition
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDMultiPeriodEngine",Description = "FDMultiPeriodEngine")>] 
         fdmultiperiodengine : obj)
        ([<ExcelArgument(Name="impl",Description = "Vector")>] 
         impl : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDMultiPeriodEngine = Helper.toModelReference<FDMultiPeriodEngine> fdmultiperiodengine "FDMultiPeriodEngine"  
                let _impl = Helper.toCell<Func<IStepCondition<Vector>>> impl "impl" 
                let builder (current : ICell) = ((FDMultiPeriodEngineModel.Cast _FDMultiPeriodEngine.cell).SetStepCondition
                                                            _impl.cell 
                                                       ) :> ICell
                let format (o : FDMultiPeriodEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FDMultiPeriodEngine.source + ".SetStepCondition") 

                                               [| _impl.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDMultiPeriodEngine.cell
                                ;  _impl.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FDMultiPeriodEngine_ensureStrikeInGrid", Description="Create a FDMultiPeriodEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDMultiPeriodEngine_ensureStrikeInGrid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDMultiPeriodEngine",Description = "FDMultiPeriodEngine")>] 
         fdmultiperiodengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDMultiPeriodEngine = Helper.toModelReference<FDMultiPeriodEngine> fdmultiperiodengine "FDMultiPeriodEngine"  
                let builder (current : ICell) = ((FDMultiPeriodEngineModel.Cast _FDMultiPeriodEngine.cell).EnsureStrikeInGrid
                                                       ) :> ICell
                let format (o : FDMultiPeriodEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FDMultiPeriodEngine.source + ".EnsureStrikeInGrid") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FDMultiPeriodEngine.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        this should be defined as new in each deriving class which use template iheritance in order to return a proper class to wrap
    *)
    [<ExcelFunction(Name="_FDMultiPeriodEngine_factory", Description="Create a FDMultiPeriodEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDMultiPeriodEngine_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDMultiPeriodEngine",Description = "FDMultiPeriodEngine")>] 
         fdmultiperiodengine : obj)
        ([<ExcelArgument(Name="Process",Description = "GeneralizedBlackScholesProcess")>] 
         Process : obj)
        ([<ExcelArgument(Name="timeSteps",Description = "int")>] 
         timeSteps : obj)
        ([<ExcelArgument(Name="gridPoints",Description = "int")>] 
         gridPoints : obj)
        ([<ExcelArgument(Name="timeDependent",Description = "bool")>] 
         timeDependent : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDMultiPeriodEngine = Helper.toModelReference<FDMultiPeriodEngine> fdmultiperiodengine "FDMultiPeriodEngine"  
                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let _timeSteps = Helper.toCell<int> timeSteps "timeSteps" 
                let _gridPoints = Helper.toCell<int> gridPoints "gridPoints" 
                let _timeDependent = Helper.toCell<bool> timeDependent "timeDependent" 
                let builder (current : ICell) = ((FDMultiPeriodEngineModel.Cast _FDMultiPeriodEngine.cell).Factory
                                                            _Process.cell 
                                                            _timeSteps.cell 
                                                            _gridPoints.cell 
                                                            _timeDependent.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FDVanillaEngine>) l

                let source () = Helper.sourceFold (_FDMultiPeriodEngine.source + ".Factory") 

                                               [| _Process.source
                                               ;  _timeSteps.source
                                               ;  _gridPoints.source
                                               ;  _timeDependent.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDMultiPeriodEngine.cell
                                ;  _Process.cell
                                ;  _timeSteps.cell
                                ;  _gridPoints.cell
                                ;  _timeDependent.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDMultiPeriodEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FDMultiPeriodEngine_getResidualTime", Description="Create a FDMultiPeriodEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDMultiPeriodEngine_getResidualTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDMultiPeriodEngine",Description = "FDMultiPeriodEngine")>] 
         fdmultiperiodengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDMultiPeriodEngine = Helper.toModelReference<FDMultiPeriodEngine> fdmultiperiodengine "FDMultiPeriodEngine"  
                let builder (current : ICell) = ((FDMultiPeriodEngineModel.Cast _FDMultiPeriodEngine.cell).GetResidualTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FDMultiPeriodEngine.source + ".GetResidualTime") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FDMultiPeriodEngine.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FDMultiPeriodEngine_grid", Description="Create a FDMultiPeriodEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDMultiPeriodEngine_grid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDMultiPeriodEngine",Description = "FDMultiPeriodEngine")>] 
         fdmultiperiodengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDMultiPeriodEngine = Helper.toModelReference<FDMultiPeriodEngine> fdmultiperiodengine "FDMultiPeriodEngine"  
                let builder (current : ICell) = ((FDMultiPeriodEngineModel.Cast _FDMultiPeriodEngine.cell).Grid
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_FDMultiPeriodEngine.source + ".Grid") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FDMultiPeriodEngine.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDMultiPeriodEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FDMultiPeriodEngine_intrinsicValues_", Description="Create a FDMultiPeriodEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDMultiPeriodEngine_intrinsicValues_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDMultiPeriodEngine",Description = "FDMultiPeriodEngine")>] 
         fdmultiperiodengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDMultiPeriodEngine = Helper.toModelReference<FDMultiPeriodEngine> fdmultiperiodengine "FDMultiPeriodEngine"  
                let builder (current : ICell) = ((FDMultiPeriodEngineModel.Cast _FDMultiPeriodEngine.cell).IntrinsicValues_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SampledCurve>) l

                let source () = Helper.sourceFold (_FDMultiPeriodEngine.source + ".IntrinsicValues_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FDMultiPeriodEngine.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDMultiPeriodEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_FDMultiPeriodEngine_Range", Description="Create a range of FDMultiPeriodEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDMultiPeriodEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FDMultiPeriodEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<FDMultiPeriodEngine> (c)) :> ICell
                let format (i : Cephei.Cell.List<FDMultiPeriodEngine>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<FDMultiPeriodEngine>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
