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
module FdmStepConditionCompositeFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FdmStepConditionComposite_applyTo", Description="Create a FdmStepConditionComposite",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmStepConditionComposite_applyTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmStepConditionComposite",Description = "FdmStepConditionComposite")>] 
         fdmstepconditioncomposite : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmStepConditionComposite = Helper.toModelReference<FdmStepConditionComposite> fdmstepconditioncomposite "FdmStepConditionComposite"  
                let _o = Helper.toCell<Object> o "o" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = ((FdmStepConditionCompositeModel.Cast _FdmStepConditionComposite.cell).ApplyTo
                                                            _o.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : FdmStepConditionComposite) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FdmStepConditionComposite.source + ".ApplyTo") 

                                               [| _o.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmStepConditionComposite.cell
                                ;  _o.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_FdmStepConditionComposite_conditions", Description="Create a FdmStepConditionComposite",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmStepConditionComposite_conditions
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmStepConditionComposite",Description = "FdmStepConditionComposite")>] 
         fdmstepconditioncomposite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmStepConditionComposite = Helper.toModelReference<FdmStepConditionComposite> fdmstepconditioncomposite "FdmStepConditionComposite"  
                let builder (current : ICell) = ((FdmStepConditionCompositeModel.Cast _FdmStepConditionComposite.cell).Conditions
                                                       ) :> ICell
                let format (i : Generic.List<IStepCondition<Vector>>) (l : string) = Helper.Range.fromList i l

                let source () = Helper.sourceFold (_FdmStepConditionComposite.source + ".Conditions") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FdmStepConditionComposite.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmStepConditionComposite1", Description="Create a FdmStepConditionComposite",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmStepConditionComposite_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="stoppingTimes",Description = "double range")>] 
         stoppingTimes : obj)
        ([<ExcelArgument(Name="conditions",Description = "Vector range")>] 
         conditions : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _stoppingTimes = Helper.toCell<Generic.List<Generic.List<double>>> stoppingTimes "stoppingTimes" 
                let _conditions = Helper.toCell<Generic.List<IStepCondition<Vector>>> conditions "conditions" 
                let builder (current : ICell) = (Fun.FdmStepConditionComposite1 
                                                            _stoppingTimes.cell 
                                                            _conditions.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmStepConditionComposite>) l

                let source () = Helper.sourceFold "Fun.FdmStepConditionComposite1" 
                                               [| _stoppingTimes.source
                                               ;  _conditions.source
                                               |]
                let hash = Helper.hashFold 
                                [| _stoppingTimes.cell
                                ;  _conditions.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmStepConditionComposite> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmStepConditionComposite", Description="Create a FdmStepConditionComposite",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmStepConditionComposite_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = (Fun.FdmStepConditionComposite ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmStepConditionComposite>) l

                let source () = Helper.sourceFold "Fun.FdmStepConditionComposite" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmStepConditionComposite> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmStepConditionComposite_stoppingTimes", Description="Create a FdmStepConditionComposite",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmStepConditionComposite_stoppingTimes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmStepConditionComposite",Description = "FdmStepConditionComposite")>] 
         fdmstepconditioncomposite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmStepConditionComposite = Helper.toModelReference<FdmStepConditionComposite> fdmstepconditioncomposite "FdmStepConditionComposite"  
                let builder (current : ICell) = ((FdmStepConditionCompositeModel.Cast _FdmStepConditionComposite.cell).StoppingTimes
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_FdmStepConditionComposite.source + ".StoppingTimes") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FdmStepConditionComposite.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_FdmStepConditionComposite_Range", Description="Create a range of FdmStepConditionComposite",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmStepConditionComposite_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FdmStepConditionComposite> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<FdmStepConditionComposite> (c)) :> ICell
                let format (i : Cephei.Cell.List<FdmStepConditionComposite>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<FdmStepConditionComposite>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
