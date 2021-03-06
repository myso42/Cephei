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
  vanillaengines  - the correctness of the returned value is tested by reproducing results available in literature. - the correctness of the returned greeks is tested by reproducing numerical derivatives.
  </summary> *)
[<AutoSerializable(true)>]
module FDAmericanEngineFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FDAmericanEngine_factory", Description="Create a FDAmericanEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDAmericanEngine_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDAmericanEngine",Description = "FDAmericanEngine")>] 
         fdamericanengine : obj)
        ([<ExcelArgument(Name="Process",Description = "GeneralizedBlackScholesProcess")>] 
         Process : obj)
        ([<ExcelArgument(Name="timeSteps",Description = "int or empty")>] 
         timeSteps : obj)
        ([<ExcelArgument(Name="gridPoints",Description = "int or empty")>] 
         gridPoints : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDAmericanEngine = Helper.toModelReference<FDAmericanEngine> fdamericanengine "FDAmericanEngine"  
                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let _timeSteps = Helper.toDefault<int> timeSteps "timeSteps" 100
                let _gridPoints = Helper.toDefault<int> gridPoints "gridPoints" 100
                let builder (current : ICell) = ((FDAmericanEngineModel.Cast _FDAmericanEngine.cell).Factory
                                                            _Process.cell 
                                                            _timeSteps.cell 
                                                            _gridPoints.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IFDEngine>) l

                let source () = Helper.sourceFold (_FDAmericanEngine.source + ".Factory") 

                                               [| _Process.source
                                               ;  _timeSteps.source
                                               ;  _gridPoints.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDAmericanEngine.cell
                                ;  _Process.cell
                                ;  _timeSteps.cell
                                ;  _gridPoints.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDAmericanEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FDAmericanEngine1", Description="Create a FDAmericanEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDAmericanEngine_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Process",Description = "GeneralizedBlackScholesProcess")>] 
         Process : obj)
        ([<ExcelArgument(Name="timeSteps",Description = "int or empty")>] 
         timeSteps : obj)
        ([<ExcelArgument(Name="gridPoints",Description = "int or empty")>] 
         gridPoints : obj)
        ([<ExcelArgument(Name="timeDependent",Description = "bool or empty")>] 
         timeDependent : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let _timeSteps = Helper.toDefault<int> timeSteps "timeSteps" 100
                let _gridPoints = Helper.toDefault<int> gridPoints "gridPoints" 100
                let _timeDependent = Helper.toDefault<bool> timeDependent "timeDependent" false
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = (Fun.FDAmericanEngine1 
                                                            _Process.cell 
                                                            _timeSteps.cell 
                                                            _gridPoints.cell 
                                                            _timeDependent.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FDAmericanEngine>) l

                let source () = Helper.sourceFold "Fun.FDAmericanEngine1" 
                                               [| _Process.source
                                               ;  _timeSteps.source
                                               ;  _gridPoints.source
                                               ;  _timeDependent.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Process.cell
                                ;  _timeSteps.cell
                                ;  _gridPoints.cell
                                ;  _timeDependent.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDAmericanEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        required for generics
    *)
    [<ExcelFunction(Name="_FDAmericanEngine", Description="Create a FDAmericanEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDAmericanEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = (Fun.FDAmericanEngine
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FDAmericanEngine>) l

                let source () = Helper.sourceFold "Fun.FDAmericanEngine1" 
                                               [|  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [|  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDAmericanEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"

    (*
        
    *)
    [<ExcelFunction(Name="_FDAmericanEngine_registerWith", Description="Create a FDAmericanEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDAmericanEngine_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDAmericanEngine",Description = "FDAmericanEngine")>] 
         fdamericanengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDAmericanEngine = Helper.toModelReference<FDAmericanEngine> fdamericanengine "FDAmericanEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((FDAmericanEngineModel.Cast _FDAmericanEngine.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : FDAmericanEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FDAmericanEngine.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDAmericanEngine.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_FDAmericanEngine_reset", Description="Create a FDAmericanEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDAmericanEngine_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDAmericanEngine",Description = "FDAmericanEngine")>] 
         fdamericanengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDAmericanEngine = Helper.toModelReference<FDAmericanEngine> fdamericanengine "FDAmericanEngine"  
                let builder (current : ICell) = ((FDAmericanEngineModel.Cast _FDAmericanEngine.cell).Reset
                                                       ) :> ICell
                let format (o : FDAmericanEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FDAmericanEngine.source + ".Reset") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FDAmericanEngine.cell
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
    [<ExcelFunction(Name="_FDAmericanEngine_unregisterWith", Description="Create a FDAmericanEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDAmericanEngine_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDAmericanEngine",Description = "FDAmericanEngine")>] 
         fdamericanengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDAmericanEngine = Helper.toModelReference<FDAmericanEngine> fdamericanengine "FDAmericanEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((FDAmericanEngineModel.Cast _FDAmericanEngine.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : FDAmericanEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FDAmericanEngine.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDAmericanEngine.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_FDAmericanEngine_update", Description="Create a FDAmericanEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDAmericanEngine_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDAmericanEngine",Description = "FDAmericanEngine")>] 
         fdamericanengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDAmericanEngine = Helper.toModelReference<FDAmericanEngine> fdamericanengine "FDAmericanEngine"  
                let builder (current : ICell) = ((FDAmericanEngineModel.Cast _FDAmericanEngine.cell).Update
                                                       ) :> ICell
                let format (o : FDAmericanEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FDAmericanEngine.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FDAmericanEngine.cell
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
    [<ExcelFunction(Name="_FDAmericanEngine_ensureStrikeInGrid", Description="Create a FDAmericanEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDAmericanEngine_ensureStrikeInGrid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDAmericanEngine",Description = "FDAmericanEngine")>] 
         fdamericanengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDAmericanEngine = Helper.toModelReference<FDAmericanEngine> fdamericanengine "FDAmericanEngine"  
                let builder (current : ICell) = ((FDAmericanEngineModel.Cast _FDAmericanEngine.cell).EnsureStrikeInGrid
                                                       ) :> ICell
                let format (o : FDAmericanEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FDAmericanEngine.source + ".EnsureStrikeInGrid") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FDAmericanEngine.cell
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
    [<ExcelFunction(Name="_FDAmericanEngine_getResidualTime", Description="Create a FDAmericanEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDAmericanEngine_getResidualTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDAmericanEngine",Description = "FDAmericanEngine")>] 
         fdamericanengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDAmericanEngine = Helper.toModelReference<FDAmericanEngine> fdamericanengine "FDAmericanEngine"  
                let builder (current : ICell) = ((FDAmericanEngineModel.Cast _FDAmericanEngine.cell).GetResidualTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FDAmericanEngine.source + ".GetResidualTime") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FDAmericanEngine.cell
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
    [<ExcelFunction(Name="_FDAmericanEngine_grid", Description="Create a FDAmericanEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDAmericanEngine_grid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDAmericanEngine",Description = "FDAmericanEngine")>] 
         fdamericanengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDAmericanEngine = Helper.toModelReference<FDAmericanEngine> fdamericanengine "FDAmericanEngine"  
                let builder (current : ICell) = ((FDAmericanEngineModel.Cast _FDAmericanEngine.cell).Grid
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_FDAmericanEngine.source + ".Grid") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FDAmericanEngine.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDAmericanEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FDAmericanEngine_intrinsicValues_", Description="Create a FDAmericanEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDAmericanEngine_intrinsicValues_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDAmericanEngine",Description = "FDAmericanEngine")>] 
         fdamericanengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDAmericanEngine = Helper.toModelReference<FDAmericanEngine> fdamericanengine "FDAmericanEngine"  
                let builder (current : ICell) = ((FDAmericanEngineModel.Cast _FDAmericanEngine.cell).IntrinsicValues_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SampledCurve>) l

                let source () = Helper.sourceFold (_FDAmericanEngine.source + ".IntrinsicValues_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FDAmericanEngine.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDAmericanEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_FDAmericanEngine_Range", Description="Create a range of FDAmericanEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDAmericanEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FDAmericanEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<FDAmericanEngine> (c)) :> ICell
                let format (i : Cephei.Cell.List<FDAmericanEngine>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<FDAmericanEngine>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
