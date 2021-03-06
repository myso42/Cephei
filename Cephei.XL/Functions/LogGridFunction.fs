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
module LogGridFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_LogGrid_logGrid", Description="Create a LogGrid",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LogGrid_logGrid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LogGrid",Description = "LogGrid")>] 
         loggrid : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LogGrid = Helper.toModelReference<LogGrid> loggrid "LogGrid"  
                let _i = Helper.toCell<int> i "i" 
                let builder (current : ICell) = ((LogGridModel.Cast _LogGrid.cell).LogGrid
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_LogGrid.source + ".LogGrid") 

                                               [| _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LogGrid.cell
                                ;  _i.cell
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
    [<ExcelFunction(Name="_LogGrid", Description="Create a LogGrid",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LogGrid_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="grid",Description = "Vector")>] 
         grid : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _grid = Helper.toCell<Vector> grid "grid" 
                let builder (current : ICell) = (Fun.LogGrid 
                                                            _grid.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LogGrid>) l

                let source () = Helper.sourceFold "Fun.LogGrid" 
                                               [| _grid.source
                                               |]
                let hash = Helper.hashFold 
                                [| _grid.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LogGrid> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LogGrid_logGridArray", Description="Create a LogGrid",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LogGrid_logGridArray
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LogGrid",Description = "LogGrid")>] 
         loggrid : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LogGrid = Helper.toModelReference<LogGrid> loggrid "LogGrid"  
                let builder (current : ICell) = ((LogGridModel.Cast _LogGrid.cell).LogGridArray
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_LogGrid.source + ".LogGridArray") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LogGrid.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LogGrid> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LogGrid_dx", Description="Create a LogGrid",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LogGrid_dx
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LogGrid",Description = "LogGrid")>] 
         loggrid : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LogGrid = Helper.toModelReference<LogGrid> loggrid "LogGrid"  
                let _i = Helper.toCell<int> i "i" 
                let builder (current : ICell) = ((LogGridModel.Cast _LogGrid.cell).Dx
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_LogGrid.source + ".Dx") 

                                               [| _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LogGrid.cell
                                ;  _i.cell
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
    [<ExcelFunction(Name="_LogGrid_dxArray", Description="Create a LogGrid",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LogGrid_dxArray
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LogGrid",Description = "LogGrid")>] 
         loggrid : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LogGrid = Helper.toModelReference<LogGrid> loggrid "LogGrid"  
                let builder (current : ICell) = ((LogGridModel.Cast _LogGrid.cell).DxArray
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_LogGrid.source + ".DxArray") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LogGrid.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LogGrid> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LogGrid_dxm", Description="Create a LogGrid",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LogGrid_dxm
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LogGrid",Description = "LogGrid")>] 
         loggrid : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LogGrid = Helper.toModelReference<LogGrid> loggrid "LogGrid"  
                let _i = Helper.toCell<int> i "i" 
                let builder (current : ICell) = ((LogGridModel.Cast _LogGrid.cell).Dxm
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_LogGrid.source + ".Dxm") 

                                               [| _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LogGrid.cell
                                ;  _i.cell
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
    [<ExcelFunction(Name="_LogGrid_dxmArray", Description="Create a LogGrid",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LogGrid_dxmArray
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LogGrid",Description = "LogGrid")>] 
         loggrid : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LogGrid = Helper.toModelReference<LogGrid> loggrid "LogGrid"  
                let builder (current : ICell) = ((LogGridModel.Cast _LogGrid.cell).DxmArray
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_LogGrid.source + ".DxmArray") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LogGrid.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LogGrid> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LogGrid_dxp", Description="Create a LogGrid",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LogGrid_dxp
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LogGrid",Description = "LogGrid")>] 
         loggrid : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LogGrid = Helper.toModelReference<LogGrid> loggrid "LogGrid"  
                let _i = Helper.toCell<int> i "i" 
                let builder (current : ICell) = ((LogGridModel.Cast _LogGrid.cell).Dxp
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_LogGrid.source + ".Dxp") 

                                               [| _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LogGrid.cell
                                ;  _i.cell
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
    [<ExcelFunction(Name="_LogGrid_dxpArray", Description="Create a LogGrid",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LogGrid_dxpArray
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LogGrid",Description = "LogGrid")>] 
         loggrid : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LogGrid = Helper.toModelReference<LogGrid> loggrid "LogGrid"  
                let builder (current : ICell) = ((LogGridModel.Cast _LogGrid.cell).DxpArray
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_LogGrid.source + ".DxpArray") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LogGrid.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LogGrid> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LogGrid_grid", Description="Create a LogGrid",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LogGrid_grid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LogGrid",Description = "LogGrid")>] 
         loggrid : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LogGrid = Helper.toModelReference<LogGrid> loggrid "LogGrid"  
                let _i = Helper.toCell<int> i "i" 
                let builder (current : ICell) = ((LogGridModel.Cast _LogGrid.cell).Grid
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_LogGrid.source + ".Grid") 

                                               [| _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LogGrid.cell
                                ;  _i.cell
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
    [<ExcelFunction(Name="_LogGrid_gridArray", Description="Create a LogGrid",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LogGrid_gridArray
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LogGrid",Description = "LogGrid")>] 
         loggrid : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LogGrid = Helper.toModelReference<LogGrid> loggrid "LogGrid"  
                let builder (current : ICell) = ((LogGridModel.Cast _LogGrid.cell).GridArray
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_LogGrid.source + ".GridArray") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LogGrid.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LogGrid> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LogGrid_size", Description="Create a LogGrid",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LogGrid_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LogGrid",Description = "LogGrid")>] 
         loggrid : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LogGrid = Helper.toModelReference<LogGrid> loggrid "LogGrid"  
                let builder (current : ICell) = ((LogGridModel.Cast _LogGrid.cell).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_LogGrid.source + ".Size") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LogGrid.cell
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
    [<ExcelFunction(Name="_LogGrid_transformedGrid", Description="Create a LogGrid",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LogGrid_transformedGrid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LogGrid",Description = "LogGrid")>] 
         loggrid : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LogGrid = Helper.toModelReference<LogGrid> loggrid "LogGrid"  
                let _i = Helper.toCell<int> i "i" 
                let builder (current : ICell) = ((LogGridModel.Cast _LogGrid.cell).TransformedGrid
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_LogGrid.source + ".TransformedGrid") 

                                               [| _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LogGrid.cell
                                ;  _i.cell
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
    [<ExcelFunction(Name="_LogGrid_transformedGridArray", Description="Create a LogGrid",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LogGrid_transformedGridArray
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LogGrid",Description = "LogGrid")>] 
         loggrid : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LogGrid = Helper.toModelReference<LogGrid> loggrid "LogGrid"  
                let builder (current : ICell) = ((LogGridModel.Cast _LogGrid.cell).TransformedGridArray
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_LogGrid.source + ".TransformedGridArray") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LogGrid.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LogGrid> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_LogGrid_Range", Description="Create a range of LogGrid",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LogGrid_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<LogGrid> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<LogGrid> (c)) :> ICell
                let format (i : Cephei.Cell.List<LogGrid>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<LogGrid>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
