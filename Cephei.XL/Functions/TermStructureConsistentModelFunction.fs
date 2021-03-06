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
TermStructureConsistentModel used in analyticcapfloorengine.cs
  </summary> *)
[<AutoSerializable(true)>]
module TermStructureConsistentModelFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_TermStructureConsistentModel_registerWith", Description="Create a TermStructureConsistentModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TermStructureConsistentModel_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TermStructureConsistentModel",Description = "TermStructureConsistentModel")>] 
         termstructureconsistentmodel : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TermStructureConsistentModel = Helper.toModelReference<TermStructureConsistentModel> termstructureconsistentmodel "TermStructureConsistentModel"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((TermStructureConsistentModelModel.Cast _TermStructureConsistentModel.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : TermStructureConsistentModel) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TermStructureConsistentModel.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TermStructureConsistentModel.cell
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
    [<ExcelFunction(Name="_TermStructureConsistentModel_termStructure", Description="Create a TermStructureConsistentModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TermStructureConsistentModel_termStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TermStructureConsistentModel",Description = "TermStructureConsistentModel")>] 
         termstructureconsistentmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TermStructureConsistentModel = Helper.toModelReference<TermStructureConsistentModel> termstructureconsistentmodel "TermStructureConsistentModel"  
                let builder (current : ICell) = ((TermStructureConsistentModelModel.Cast _TermStructureConsistentModel.cell).TermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_TermStructureConsistentModel.source + ".TermStructure") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _TermStructureConsistentModel.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TermStructureConsistentModel> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TermStructureConsistentModel", Description="Create a TermStructureConsistentModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TermStructureConsistentModel_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="termStructure",Description = "YieldTermStructure")>] 
         termStructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _termStructure = Helper.toHandle<YieldTermStructure> termStructure "termStructure" 
                let builder (current : ICell) = (Fun.TermStructureConsistentModel 
                                                            _termStructure.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TermStructureConsistentModel>) l

                let source () = Helper.sourceFold "Fun.TermStructureConsistentModel" 
                                               [| _termStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _termStructure.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TermStructureConsistentModel> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TermStructureConsistentModel_unregisterWith", Description="Create a TermStructureConsistentModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TermStructureConsistentModel_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TermStructureConsistentModel",Description = "TermStructureConsistentModel")>] 
         termstructureconsistentmodel : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TermStructureConsistentModel = Helper.toModelReference<TermStructureConsistentModel> termstructureconsistentmodel "TermStructureConsistentModel"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((TermStructureConsistentModelModel.Cast _TermStructureConsistentModel.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : TermStructureConsistentModel) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TermStructureConsistentModel.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TermStructureConsistentModel.cell
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
    [<ExcelFunction(Name="_TermStructureConsistentModel_Range", Description="Create a range of TermStructureConsistentModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TermStructureConsistentModel_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<TermStructureConsistentModel> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<TermStructureConsistentModel> (c)) :> ICell
                let format (i : Cephei.Cell.List<TermStructureConsistentModel>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<TermStructureConsistentModel>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
