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
module UniformGridMesherFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_UniformGridMesher_dminus", Description="Create a UniformGridMesher",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UniformGridMesher_dminus
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UniformGridMesher",Description = "UniformGridMesher")>] 
         uniformgridmesher : obj)
        ([<ExcelArgument(Name="iter",Description = "FdmLinearOpIterator")>] 
         iter : obj)
        ([<ExcelArgument(Name="direction",Description = "int")>] 
         direction : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UniformGridMesher = Helper.toModelReference<UniformGridMesher> uniformgridmesher "UniformGridMesher"  
                let _iter = Helper.toCell<FdmLinearOpIterator> iter "iter" 
                let _direction = Helper.toCell<int> direction "direction" 
                let builder (current : ICell) = ((UniformGridMesherModel.Cast _UniformGridMesher.cell).Dminus
                                                            _iter.cell 
                                                            _direction.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UniformGridMesher.source + ".Dminus") 

                                               [| _iter.source
                                               ;  _direction.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UniformGridMesher.cell
                                ;  _iter.cell
                                ;  _direction.cell
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
    [<ExcelFunction(Name="_UniformGridMesher_dplus", Description="Create a UniformGridMesher",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UniformGridMesher_dplus
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UniformGridMesher",Description = "UniformGridMesher")>] 
         uniformgridmesher : obj)
        ([<ExcelArgument(Name="iter",Description = "FdmLinearOpIterator")>] 
         iter : obj)
        ([<ExcelArgument(Name="direction",Description = "int")>] 
         direction : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UniformGridMesher = Helper.toModelReference<UniformGridMesher> uniformgridmesher "UniformGridMesher"  
                let _iter = Helper.toCell<FdmLinearOpIterator> iter "iter" 
                let _direction = Helper.toCell<int> direction "direction" 
                let builder (current : ICell) = ((UniformGridMesherModel.Cast _UniformGridMesher.cell).Dplus
                                                            _iter.cell 
                                                            _direction.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UniformGridMesher.source + ".Dplus") 

                                               [| _iter.source
                                               ;  _direction.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UniformGridMesher.cell
                                ;  _iter.cell
                                ;  _direction.cell
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
    [<ExcelFunction(Name="_UniformGridMesher_location", Description="Create a UniformGridMesher",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UniformGridMesher_location
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UniformGridMesher",Description = "UniformGridMesher")>] 
         uniformgridmesher : obj)
        ([<ExcelArgument(Name="iter",Description = "FdmLinearOpIterator")>] 
         iter : obj)
        ([<ExcelArgument(Name="direction",Description = "int")>] 
         direction : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UniformGridMesher = Helper.toModelReference<UniformGridMesher> uniformgridmesher "UniformGridMesher"  
                let _iter = Helper.toCell<FdmLinearOpIterator> iter "iter" 
                let _direction = Helper.toCell<int> direction "direction" 
                let builder (current : ICell) = ((UniformGridMesherModel.Cast _UniformGridMesher.cell).Location
                                                            _iter.cell 
                                                            _direction.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_UniformGridMesher.source + ".Location") 

                                               [| _iter.source
                                               ;  _direction.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UniformGridMesher.cell
                                ;  _iter.cell
                                ;  _direction.cell
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
    [<ExcelFunction(Name="_UniformGridMesher_locations", Description="Create a UniformGridMesher",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UniformGridMesher_locations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UniformGridMesher",Description = "UniformGridMesher")>] 
         uniformgridmesher : obj)
        ([<ExcelArgument(Name="direction",Description = "int")>] 
         direction : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UniformGridMesher = Helper.toModelReference<UniformGridMesher> uniformgridmesher "UniformGridMesher"  
                let _direction = Helper.toCell<int> direction "direction" 
                let builder (current : ICell) = ((UniformGridMesherModel.Cast _UniformGridMesher.cell).Locations
                                                            _direction.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_UniformGridMesher.source + ".Locations") 

                                               [| _direction.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UniformGridMesher.cell
                                ;  _direction.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<UniformGridMesher> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_UniformGridMesher", Description="Create a UniformGridMesher",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UniformGridMesher_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="layout",Description = "FdmLinearOpLayout")>] 
         layout : obj)
        ([<ExcelArgument(Name="boundaries",Description = "double range")>] 
         boundaries : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _layout = Helper.toCell<FdmLinearOpLayout> layout "layout" 
                let _boundaries = Helper.toCell<Generic.List<Pair<Nullable<double>,Nullable<double>>>> boundaries "boundaries" 
                let builder (current : ICell) = (Fun.UniformGridMesher 
                                                            _layout.cell 
                                                            _boundaries.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<UniformGridMesher>) l

                let source () = Helper.sourceFold "Fun.UniformGridMesher" 
                                               [| _layout.source
                                               ;  _boundaries.source
                                               |]
                let hash = Helper.hashFold 
                                [| _layout.cell
                                ;  _boundaries.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<UniformGridMesher> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_UniformGridMesher_layout", Description="Create a UniformGridMesher",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UniformGridMesher_layout
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UniformGridMesher",Description = "UniformGridMesher")>] 
         uniformgridmesher : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UniformGridMesher = Helper.toModelReference<UniformGridMesher> uniformgridmesher "UniformGridMesher"  
                let builder (current : ICell) = ((UniformGridMesherModel.Cast _UniformGridMesher.cell).Layout
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmLinearOpLayout>) l

                let source () = Helper.sourceFold (_UniformGridMesher.source + ".Layout") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _UniformGridMesher.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<UniformGridMesher> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_UniformGridMesher_Range", Description="Create a range of UniformGridMesher",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UniformGridMesher_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<UniformGridMesher> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<UniformGridMesher> (c)) :> ICell
                let format (i : Cephei.Cell.List<UniformGridMesher>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<UniformGridMesher>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
