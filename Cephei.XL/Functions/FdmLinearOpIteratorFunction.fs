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
module FdmLinearOpIteratorFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FdmLinearOpIterator_coordinates", Description="Create a FdmLinearOpIterator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmLinearOpIterator_coordinates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmLinearOpIterator",Description = "FdmLinearOpIterator")>] 
         fdmlinearopiterator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmLinearOpIterator = Helper.toModelReference<FdmLinearOpIterator> fdmlinearopiterator "FdmLinearOpIterator"  
                let builder (current : ICell) = ((FdmLinearOpIteratorModel.Cast _FdmLinearOpIterator.cell).Coordinates
                                                       ) :> ICell
                let format (i : Generic.List<int>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_FdmLinearOpIterator.source + ".Coordinates") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FdmLinearOpIterator.cell
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
    [<ExcelFunction(Name="_FdmLinearOpIterator_Equals", Description="Create a FdmLinearOpIterator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmLinearOpIterator_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmLinearOpIterator",Description = "FdmLinearOpIterator")>] 
         fdmlinearopiterator : obj)
        ([<ExcelArgument(Name="obj",Description = "Object")>] 
         obj : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmLinearOpIterator = Helper.toModelReference<FdmLinearOpIterator> fdmlinearopiterator "FdmLinearOpIterator"  
                let _obj = Helper.toCell<Object> obj "obj" 
                let builder (current : ICell) = ((FdmLinearOpIteratorModel.Cast _FdmLinearOpIterator.cell).Equals
                                                            _obj.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FdmLinearOpIterator.source + ".Equals") 

                                               [| _obj.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmLinearOpIterator.cell
                                ;  _obj.cell
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
    [<ExcelFunction(Name="_FdmLinearOpIterator", Description="Create a FdmLinearOpIterator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmLinearOpIterator_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="index",Description = "int or empty")>] 
         index : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _index = Helper.toDefault<int> index "index" 0
                let builder (current : ICell) = (Fun.FdmLinearOpIterator 
                                                            _index.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmLinearOpIterator>) l

                let source () = Helper.sourceFold "Fun.FdmLinearOpIterator" 
                                               [| _index.source
                                               |]
                let hash = Helper.hashFold 
                                [| _index.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmLinearOpIterator> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmLinearOpIterator1", Description="Create a FdmLinearOpIterator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmLinearOpIterator_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="dim",Description = "int range")>] 
         dim : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _dim = Helper.toCell<Generic.List<int>> dim "dim" 
                let builder (current : ICell) = (Fun.FdmLinearOpIterator1 
                                                            _dim.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmLinearOpIterator>) l

                let source () = Helper.sourceFold "Fun.FdmLinearOpIterator1" 
                                               [| _dim.source
                                               |]
                let hash = Helper.hashFold 
                                [| _dim.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmLinearOpIterator> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmLinearOpIterator3", Description="Create a FdmLinearOpIterator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmLinearOpIterator_create3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="iter",Description = "FdmLinearOpIterator")>] 
         iter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _iter = Helper.toCell<FdmLinearOpIterator> iter "iter" 
                let builder (current : ICell) = (Fun.FdmLinearOpIterator3
                                                            _iter.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmLinearOpIterator>) l

                let source () = Helper.sourceFold "Fun.FdmLinearOpIterator3" 
                                               [| _iter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _iter.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmLinearOpIterator> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmLinearOpIterator2", Description="Create a FdmLinearOpIterator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmLinearOpIterator_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="dim",Description = "int range")>] 
         dim : obj)
        ([<ExcelArgument(Name="coordinates",Description = "int range")>] 
         coordinates : obj)
        ([<ExcelArgument(Name="index",Description = "int or empty")>] 
         index : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _dim = Helper.toCell<Generic.List<int>> dim "dim" 
                let _coordinates = Helper.toCell<Generic.List<int>> coordinates "coordinates" 
                let _index = Helper.toDefault<int> index "index" 0
                let builder (current : ICell) = (Fun.FdmLinearOpIterator2
                                                            _dim.cell 
                                                            _coordinates.cell 
                                                            _index.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmLinearOpIterator>) l

                let source () = Helper.sourceFold "Fun.FdmLinearOpIterator2" 
                                               [| _dim.source
                                               ;  _coordinates.source
                                               ;  _index.source
                                               |]
                let hash = Helper.hashFold 
                                [| _dim.cell
                                ;  _coordinates.cell
                                ;  _index.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmLinearOpIterator> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmLinearOpIterator_index", Description="Create a FdmLinearOpIterator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmLinearOpIterator_index
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmLinearOpIterator",Description = "FdmLinearOpIterator")>] 
         fdmlinearopiterator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmLinearOpIterator = Helper.toModelReference<FdmLinearOpIterator> fdmlinearopiterator "FdmLinearOpIterator"  
                let builder (current : ICell) = ((FdmLinearOpIteratorModel.Cast _FdmLinearOpIterator.cell).Index
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FdmLinearOpIterator.source + ".Index") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FdmLinearOpIterator.cell
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
    [<ExcelFunction(Name="_FdmLinearOpIterator_swap", Description="Create a FdmLinearOpIterator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmLinearOpIterator_swap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmLinearOpIterator",Description = "FdmLinearOpIterator")>] 
         fdmlinearopiterator : obj)
        ([<ExcelArgument(Name="iter",Description = "FdmLinearOpIterator")>] 
         iter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmLinearOpIterator = Helper.toModelReference<FdmLinearOpIterator> fdmlinearopiterator "FdmLinearOpIterator"  
                let _iter = Helper.toCell<FdmLinearOpIterator> iter "iter" 
                let builder (current : ICell) = ((FdmLinearOpIteratorModel.Cast _FdmLinearOpIterator.cell).Swap
                                                            _iter.cell 
                                                       ) :> ICell
                let format (o : FdmLinearOpIterator) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FdmLinearOpIterator.source + ".Swap") 

                                               [| _iter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmLinearOpIterator.cell
                                ;  _iter.cell
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
    [<ExcelFunction(Name="_FdmLinearOpIterator_Range", Description="Create a range of FdmLinearOpIterator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmLinearOpIterator_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FdmLinearOpIterator> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<FdmLinearOpIterator> (c)) :> ICell
                let format (i : Cephei.Cell.List<FdmLinearOpIterator>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<FdmLinearOpIterator>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
