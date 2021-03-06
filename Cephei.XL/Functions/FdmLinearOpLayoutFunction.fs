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
module FdmLinearOpLayoutFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FdmLinearOpLayout_begin", Description="Create a FdmLinearOpLayout",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmLinearOpLayout_begin
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmLinearOpLayout",Description = "FdmLinearOpLayout")>] 
         fdmlinearoplayout : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmLinearOpLayout = Helper.toModelReference<FdmLinearOpLayout> fdmlinearoplayout "FdmLinearOpLayout"  
                let builder (current : ICell) = ((FdmLinearOpLayoutModel.Cast _FdmLinearOpLayout.cell).Begin
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmLinearOpIterator>) l

                let source () = Helper.sourceFold (_FdmLinearOpLayout.source + ".BEGIN") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FdmLinearOpLayout.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmLinearOpLayout> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmLinearOpLayout_dim", Description="Create a FdmLinearOpLayout",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmLinearOpLayout_dim
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmLinearOpLayout",Description = "FdmLinearOpLayout")>] 
         fdmlinearoplayout : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmLinearOpLayout = Helper.toModelReference<FdmLinearOpLayout> fdmlinearoplayout "FdmLinearOpLayout"  
                let builder (current : ICell) = ((FdmLinearOpLayoutModel.Cast _FdmLinearOpLayout.cell).Dim
                                                       ) :> ICell
                let format (i : Generic.List<int>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_FdmLinearOpLayout.source + ".Dim") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FdmLinearOpLayout.cell
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
    [<ExcelFunction(Name="_FdmLinearOpLayout_end", Description="Create a FdmLinearOpLayout",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmLinearOpLayout_end
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmLinearOpLayout",Description = "FdmLinearOpLayout")>] 
         fdmlinearoplayout : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmLinearOpLayout = Helper.toModelReference<FdmLinearOpLayout> fdmlinearoplayout "FdmLinearOpLayout"  
                let builder (current : ICell) = ((FdmLinearOpLayoutModel.Cast _FdmLinearOpLayout.cell).End
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmLinearOpIterator>) l

                let source () = Helper.sourceFold (_FdmLinearOpLayout.source + ".END") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FdmLinearOpLayout.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmLinearOpLayout> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmLinearOpLayout", Description="Create a FdmLinearOpLayout",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmLinearOpLayout_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="dim",Description = "int range")>] 
         dim : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _dim = Helper.toCell<Generic.List<int>> dim "dim" 
                let builder (current : ICell) = (Fun.FdmLinearOpLayout 
                                                            _dim.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmLinearOpLayout>) l

                let source () = Helper.sourceFold "Fun.FdmLinearOpLayout" 
                                               [| _dim.source
                                               |]
                let hash = Helper.hashFold 
                                [| _dim.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmLinearOpLayout> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmLinearOpLayout_index", Description="Create a FdmLinearOpLayout",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmLinearOpLayout_index
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmLinearOpLayout",Description = "FdmLinearOpLayout")>] 
         fdmlinearoplayout : obj)
        ([<ExcelArgument(Name="coordinates",Description = "int range")>] 
         coordinates : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmLinearOpLayout = Helper.toModelReference<FdmLinearOpLayout> fdmlinearoplayout "FdmLinearOpLayout"  
                let _coordinates = Helper.toCell<Generic.List<int>> coordinates "coordinates" 
                let builder (current : ICell) = ((FdmLinearOpLayoutModel.Cast _FdmLinearOpLayout.cell).Index
                                                            _coordinates.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FdmLinearOpLayout.source + ".Index") 

                                               [| _coordinates.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmLinearOpLayout.cell
                                ;  _coordinates.cell
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
    [<ExcelFunction(Name="_FdmLinearOpLayout_iter_neighbourhood", Description="Create a FdmLinearOpLayout",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmLinearOpLayout_iter_neighbourhood
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmLinearOpLayout",Description = "FdmLinearOpLayout")>] 
         fdmlinearoplayout : obj)
        ([<ExcelArgument(Name="iterator",Description = "FdmLinearOpIterator")>] 
         iterator : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        ([<ExcelArgument(Name="offset",Description = "int")>] 
         offset : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmLinearOpLayout = Helper.toModelReference<FdmLinearOpLayout> fdmlinearoplayout "FdmLinearOpLayout"  
                let _iterator = Helper.toCell<FdmLinearOpIterator> iterator "iterator" 
                let _i = Helper.toCell<int> i "i" 
                let _offset = Helper.toCell<int> offset "offset" 
                let builder (current : ICell) = ((FdmLinearOpLayoutModel.Cast _FdmLinearOpLayout.cell).Iter_neighbourhood
                                                            _iterator.cell 
                                                            _i.cell 
                                                            _offset.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmLinearOpIterator>) l

                let source () = Helper.sourceFold (_FdmLinearOpLayout.source + ".Iter_neighbourhood") 

                                               [| _iterator.source
                                               ;  _i.source
                                               ;  _offset.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmLinearOpLayout.cell
                                ;  _iterator.cell
                                ;  _i.cell
                                ;  _offset.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmLinearOpLayout> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmLinearOpLayout_neighbourhood", Description="Create a FdmLinearOpLayout",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmLinearOpLayout_neighbourhood
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmLinearOpLayout",Description = "FdmLinearOpLayout")>] 
         fdmlinearoplayout : obj)
        ([<ExcelArgument(Name="iterator",Description = "FdmLinearOpIterator")>] 
         iterator : obj)
        ([<ExcelArgument(Name="i1",Description = "int")>] 
         i1 : obj)
        ([<ExcelArgument(Name="offset1",Description = "int")>] 
         offset1 : obj)
        ([<ExcelArgument(Name="i2",Description = "int")>] 
         i2 : obj)
        ([<ExcelArgument(Name="offset2",Description = "int")>] 
         offset2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmLinearOpLayout = Helper.toModelReference<FdmLinearOpLayout> fdmlinearoplayout "FdmLinearOpLayout"  
                let _iterator = Helper.toCell<FdmLinearOpIterator> iterator "iterator" 
                let _i1 = Helper.toCell<int> i1 "i1" 
                let _offset1 = Helper.toCell<int> offset1 "offset1" 
                let _i2 = Helper.toCell<int> i2 "i2" 
                let _offset2 = Helper.toCell<int> offset2 "offset2" 
                let builder (current : ICell) = ((FdmLinearOpLayoutModel.Cast _FdmLinearOpLayout.cell).Neighbourhood
                                                            _iterator.cell 
                                                            _i1.cell 
                                                            _offset1.cell 
                                                            _i2.cell 
                                                            _offset2.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FdmLinearOpLayout.source + ".Neighbourhood") 

                                               [| _iterator.source
                                               ;  _i1.source
                                               ;  _offset1.source
                                               ;  _i2.source
                                               ;  _offset2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmLinearOpLayout.cell
                                ;  _iterator.cell
                                ;  _i1.cell
                                ;  _offset1.cell
                                ;  _i2.cell
                                ;  _offset2.cell
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
    [<ExcelFunction(Name="_FdmLinearOpLayout_neighbourhood1", Description="Create a FdmLinearOpLayout",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmLinearOpLayout_neighbourhood1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmLinearOpLayout",Description = "FdmLinearOpLayout")>] 
         fdmlinearoplayout : obj)
        ([<ExcelArgument(Name="iterator",Description = "FdmLinearOpIterator")>] 
         iterator : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        ([<ExcelArgument(Name="offset",Description = "int")>] 
         offset : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmLinearOpLayout = Helper.toModelReference<FdmLinearOpLayout> fdmlinearoplayout "FdmLinearOpLayout"  
                let _iterator = Helper.toCell<FdmLinearOpIterator> iterator "iterator" 
                let _i = Helper.toCell<int> i "i" 
                let _offset = Helper.toCell<int> offset "offset" 
                let builder (current : ICell) = ((FdmLinearOpLayoutModel.Cast _FdmLinearOpLayout.cell).Neighbourhood1
                                                            _iterator.cell 
                                                            _i.cell 
                                                            _offset.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FdmLinearOpLayout.source + ".Neighbourhood1") 

                                               [| _iterator.source
                                               ;  _i.source
                                               ;  _offset.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmLinearOpLayout.cell
                                ;  _iterator.cell
                                ;  _i.cell
                                ;  _offset.cell
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
    [<ExcelFunction(Name="_FdmLinearOpLayout_size", Description="Create a FdmLinearOpLayout",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmLinearOpLayout_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmLinearOpLayout",Description = "FdmLinearOpLayout")>] 
         fdmlinearoplayout : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmLinearOpLayout = Helper.toModelReference<FdmLinearOpLayout> fdmlinearoplayout "FdmLinearOpLayout"  
                let builder (current : ICell) = ((FdmLinearOpLayoutModel.Cast _FdmLinearOpLayout.cell).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FdmLinearOpLayout.source + ".Size") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FdmLinearOpLayout.cell
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
    [<ExcelFunction(Name="_FdmLinearOpLayout_spacing", Description="Create a FdmLinearOpLayout",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmLinearOpLayout_spacing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmLinearOpLayout",Description = "FdmLinearOpLayout")>] 
         fdmlinearoplayout : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmLinearOpLayout = Helper.toModelReference<FdmLinearOpLayout> fdmlinearoplayout "FdmLinearOpLayout"  
                let builder (current : ICell) = ((FdmLinearOpLayoutModel.Cast _FdmLinearOpLayout.cell).Spacing
                                                       ) :> ICell
                let format (i : Generic.List<int>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_FdmLinearOpLayout.source + ".Spacing") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FdmLinearOpLayout.cell
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
    [<ExcelFunction(Name="_FdmLinearOpLayout_Range", Description="Create a range of FdmLinearOpLayout",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmLinearOpLayout_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FdmLinearOpLayout> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<FdmLinearOpLayout> (c)) :> ICell
                let format (i : Cephei.Cell.List<FdmLinearOpLayout>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<FdmLinearOpLayout>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
