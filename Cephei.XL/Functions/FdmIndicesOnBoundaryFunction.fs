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
module FdmIndicesOnBoundaryFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FdmIndicesOnBoundary", Description="Create a FdmIndicesOnBoundary",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmIndicesOnBoundary_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="layout",Description = "FdmLinearOpLayout")>] 
         layout : obj)
        ([<ExcelArgument(Name="direction",Description = "int")>] 
         direction : obj)
        ([<ExcelArgument(Name="side",Description = ".Side")>] 
         side : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _layout = Helper.toCell<FdmLinearOpLayout> layout "layout" 
                let _direction = Helper.toCell<int> direction "direction" 
                let _side = Helper.toCell<BoundaryCondition<FdmLinearOp>.Side> side "side" 
                let builder (current : ICell) = (Fun.FdmIndicesOnBoundary 
                                                            _layout.cell 
                                                            _direction.cell 
                                                            _side.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmIndicesOnBoundary>) l

                let source () = Helper.sourceFold "Fun.FdmIndicesOnBoundary" 
                                               [| _layout.source
                                               ;  _direction.source
                                               ;  _side.source
                                               |]
                let hash = Helper.hashFold 
                                [| _layout.cell
                                ;  _direction.cell
                                ;  _side.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmIndicesOnBoundary> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmIndicesOnBoundary_getIndices", Description="Create a FdmIndicesOnBoundary",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmIndicesOnBoundary_getIndices
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmIndicesOnBoundary",Description = "FdmIndicesOnBoundary")>] 
         fdmindicesonboundary : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmIndicesOnBoundary = Helper.toModelReference<FdmIndicesOnBoundary> fdmindicesonboundary "FdmIndicesOnBoundary"  
                let builder (current : ICell) = ((FdmIndicesOnBoundaryModel.Cast _FdmIndicesOnBoundary.cell).GetIndices
                                                       ) :> ICell
                let format (i : Generic.List<int>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_FdmIndicesOnBoundary.source + ".GetIndices") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FdmIndicesOnBoundary.cell
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
    [<ExcelFunction(Name="_FdmIndicesOnBoundary_Range", Description="Create a range of FdmIndicesOnBoundary",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmIndicesOnBoundary_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FdmIndicesOnBoundary> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<FdmIndicesOnBoundary> (c)) :> ICell
                let format (i : Cephei.Cell.List<FdmIndicesOnBoundary>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<FdmIndicesOnBoundary>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
