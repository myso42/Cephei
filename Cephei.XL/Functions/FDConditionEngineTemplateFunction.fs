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
this is template version to serve as base for FDStepConditionEngine and FDMultiPeriodEngine
  </summary> *)
[<AutoSerializable(true)>]
module FDConditionEngineTemplateFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FDConditionEngineTemplate1", Description="Create a FDConditionEngineTemplate",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDConditionEngineTemplate_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
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

                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let _timeSteps = Helper.toCell<int> timeSteps "timeSteps" 
                let _gridPoints = Helper.toCell<int> gridPoints "gridPoints" 
                let _timeDependent = Helper.toCell<bool> timeDependent "timeDependent" 
                let builder (current : ICell) = (Fun.FDConditionEngineTemplate1 
                                                            _Process.cell 
                                                            _timeSteps.cell 
                                                            _gridPoints.cell 
                                                            _timeDependent.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FDConditionEngineTemplate>) l

                let source () = Helper.sourceFold "Fun.FDConditionEngineTemplate" 
                                               [| _Process.source
                                               ;  _timeSteps.source
                                               ;  _gridPoints.source
                                               ;  _timeDependent.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Process.cell
                                ;  _timeSteps.cell
                                ;  _gridPoints.cell
                                ;  _timeDependent.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDConditionEngineTemplate> format
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
    [<ExcelFunction(Name="_FDConditionEngineTemplate", Description="Create a FDConditionEngineTemplate",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDConditionEngineTemplate_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = (Fun.FDConditionEngineTemplate ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FDConditionEngineTemplate>) l

                let source () = Helper.sourceFold "Fun.FDConditionEngineTemplate1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDConditionEngineTemplate> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FDConditionEngineTemplate_setStepCondition", Description="Create a FDConditionEngineTemplate",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDConditionEngineTemplate_setStepCondition
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDConditionEngineTemplate",Description = "FDConditionEngineTemplate")>] 
         fdconditionenginetemplate : obj)
        ([<ExcelArgument(Name="impl",Description = "Vector")>] 
         impl : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDConditionEngineTemplate = Helper.toModelReference<FDConditionEngineTemplate> fdconditionenginetemplate "FDConditionEngineTemplate"  
                let _impl = Helper.toCell<Func<IStepCondition<Vector>>> impl "impl" 
                let builder (current : ICell) = ((FDConditionEngineTemplateModel.Cast _FDConditionEngineTemplate.cell).SetStepCondition
                                                            _impl.cell 
                                                       ) :> ICell
                let format (o : FDConditionEngineTemplate) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FDConditionEngineTemplate.source + ".SetStepCondition") 

                                               [| _impl.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDConditionEngineTemplate.cell
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
    [<ExcelFunction(Name="_FDConditionEngineTemplate_ensureStrikeInGrid", Description="Create a FDConditionEngineTemplate",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDConditionEngineTemplate_ensureStrikeInGrid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDConditionEngineTemplate",Description = "FDConditionEngineTemplate")>] 
         fdconditionenginetemplate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDConditionEngineTemplate = Helper.toModelReference<FDConditionEngineTemplate> fdconditionenginetemplate "FDConditionEngineTemplate"  
                let builder (current : ICell) = ((FDConditionEngineTemplateModel.Cast _FDConditionEngineTemplate.cell).EnsureStrikeInGrid
                                                       ) :> ICell
                let format (o : FDConditionEngineTemplate) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FDConditionEngineTemplate.source + ".EnsureStrikeInGrid") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FDConditionEngineTemplate.cell
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
    [<ExcelFunction(Name="_FDConditionEngineTemplate_factory", Description="Create a FDConditionEngineTemplate",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDConditionEngineTemplate_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDConditionEngineTemplate",Description = "FDConditionEngineTemplate")>] 
         fdconditionenginetemplate : obj)
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

                let _FDConditionEngineTemplate = Helper.toModelReference<FDConditionEngineTemplate> fdconditionenginetemplate "FDConditionEngineTemplate"  
                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let _timeSteps = Helper.toCell<int> timeSteps "timeSteps" 
                let _gridPoints = Helper.toCell<int> gridPoints "gridPoints" 
                let _timeDependent = Helper.toCell<bool> timeDependent "timeDependent" 
                let builder (current : ICell) = ((FDConditionEngineTemplateModel.Cast _FDConditionEngineTemplate.cell).Factory
                                                            _Process.cell 
                                                            _timeSteps.cell 
                                                            _gridPoints.cell 
                                                            _timeDependent.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FDVanillaEngine>) l

                let source () = Helper.sourceFold (_FDConditionEngineTemplate.source + ".Factory") 

                                               [| _Process.source
                                               ;  _timeSteps.source
                                               ;  _gridPoints.source
                                               ;  _timeDependent.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDConditionEngineTemplate.cell
                                ;  _Process.cell
                                ;  _timeSteps.cell
                                ;  _gridPoints.cell
                                ;  _timeDependent.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDConditionEngineTemplate> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FDConditionEngineTemplate_getResidualTime", Description="Create a FDConditionEngineTemplate",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDConditionEngineTemplate_getResidualTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDConditionEngineTemplate",Description = "FDConditionEngineTemplate")>] 
         fdconditionenginetemplate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDConditionEngineTemplate = Helper.toModelReference<FDConditionEngineTemplate> fdconditionenginetemplate "FDConditionEngineTemplate"  
                let builder (current : ICell) = ((FDConditionEngineTemplateModel.Cast _FDConditionEngineTemplate.cell).GetResidualTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FDConditionEngineTemplate.source + ".GetResidualTime") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FDConditionEngineTemplate.cell
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
    [<ExcelFunction(Name="_FDConditionEngineTemplate_grid", Description="Create a FDConditionEngineTemplate",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDConditionEngineTemplate_grid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDConditionEngineTemplate",Description = "FDConditionEngineTemplate")>] 
         fdconditionenginetemplate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDConditionEngineTemplate = Helper.toModelReference<FDConditionEngineTemplate> fdconditionenginetemplate "FDConditionEngineTemplate"  
                let builder (current : ICell) = ((FDConditionEngineTemplateModel.Cast _FDConditionEngineTemplate.cell).Grid
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_FDConditionEngineTemplate.source + ".Grid") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FDConditionEngineTemplate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDConditionEngineTemplate> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FDConditionEngineTemplate_intrinsicValues_", Description="Create a FDConditionEngineTemplate",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDConditionEngineTemplate_intrinsicValues_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDConditionEngineTemplate",Description = "FDConditionEngineTemplate")>] 
         fdconditionenginetemplate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDConditionEngineTemplate = Helper.toModelReference<FDConditionEngineTemplate> fdconditionenginetemplate "FDConditionEngineTemplate"  
                let builder (current : ICell) = ((FDConditionEngineTemplateModel.Cast _FDConditionEngineTemplate.cell).IntrinsicValues_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SampledCurve>) l

                let source () = Helper.sourceFold (_FDConditionEngineTemplate.source + ".IntrinsicValues_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FDConditionEngineTemplate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDConditionEngineTemplate> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_FDConditionEngineTemplate_Range", Description="Create a range of FDConditionEngineTemplate",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDConditionEngineTemplate_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FDConditionEngineTemplate> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<FDConditionEngineTemplate> (c)) :> ICell
                let format (i : Cephei.Cell.List<FDConditionEngineTemplate>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<FDConditionEngineTemplate>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
