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
(*!! omitted
(* <summary>

  </summary> *)
[<AutoSerializable(true)>]
module IndexManagerFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_IndexManager_clearHistories", Description="Create a IndexManager",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IndexManager_clearHistories
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IndexManager",Description = "IndexManager")>] 
         indexmanager : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IndexManager = Helper.toModelReference<IndexManager> indexmanager "IndexManager"  
                let builder (current : ICell) = ((IndexManagerModel.Cast _IndexManager.cell).ClearHistories
                                                       ) :> ICell
                let format (o : IndexManager) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_IndexManager.source + ".ClearHistories") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _IndexManager.cell
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
    [<ExcelFunction(Name="_IndexManager_clearHistory", Description="Create a IndexManager",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IndexManager_clearHistory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IndexManager",Description = "IndexManager")>] 
         indexmanager : obj)
        ([<ExcelArgument(Name="name",Description = "string")>] 
         name : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IndexManager = Helper.toModelReference<IndexManager> indexmanager "IndexManager"  
                let _name = Helper.toCell<string> name "name" 
                let builder (current : ICell) = ((IndexManagerModel.Cast _IndexManager.cell).ClearHistory
                                                            _name.cell 
                                                       ) :> ICell
                let format (o : IndexManager) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_IndexManager.source + ".ClearHistory") 

                                               [| _name.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IndexManager.cell
                                ;  _name.cell
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
    [<ExcelFunction(Name="_IndexManager_getHistory", Description="Create a IndexManager",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IndexManager_getHistory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IndexManager",Description = "IndexManager")>] 
         indexmanager : obj)
        ([<ExcelArgument(Name="name",Description = "string")>] 
         name : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IndexManager = Helper.toModelReference<IndexManager> indexmanager "IndexManager"  
                let _name = Helper.toCell<string> name "name" 
                let builder (current : ICell) = ((IndexManagerModel.Cast _IndexManager.cell).GetHistory
                                                            _name.cell 
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_IndexManager.source + ".GetHistory") 

                                               [| _name.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IndexManager.cell
                                ;  _name.cell
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
    [<ExcelFunction(Name="_IndexManager_hasHistory", Description="Create a IndexManager",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IndexManager_hasHistory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IndexManager",Description = "IndexManager")>] 
         indexmanager : obj)
        ([<ExcelArgument(Name="name",Description = "string")>] 
         name : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IndexManager = Helper.toModelReference<IndexManager> indexmanager "IndexManager"  
                let _name = Helper.toCell<string> name "name" 
                let builder (current : ICell) = ((IndexManagerModel.Cast _IndexManager.cell).HasHistory
                                                            _name.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_IndexManager.source + ".HasHistory") 

                                               [| _name.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IndexManager.cell
                                ;  _name.cell
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
    [<ExcelFunction(Name="_IndexManager_histories", Description="Create a IndexManager",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IndexManager_histories
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IndexManager",Description = "IndexManager")>] 
         indexmanager : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IndexManager = Helper.toModelReference<IndexManager> indexmanager "IndexManager"  
                let builder (current : ICell) = ((IndexManagerModel.Cast _IndexManager.cell).Histories
                                                       ) :> ICell
                let format (i : Generic.List<string>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_IndexManager.source + ".Histories") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _IndexManager.cell
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
    [<ExcelFunction(Name="_IndexManager_notifier", Description="Create a IndexManager",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IndexManager_notifier
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IndexManager",Description = "IndexManager")>] 
         indexmanager : obj)
        ([<ExcelArgument(Name="name",Description = "string")>] 
         name : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IndexManager = Helper.toModelReference<IndexManager> indexmanager "IndexManager"  
                let _name = Helper.toCell<string> name "name" 
                let builder (current : ICell) = ((IndexManagerModel.Cast _IndexManager.cell).Notifier
                                                            _name.cell 
                                                       ) :> ICell
                let format (o : ObservableValue<TimeSeries<Nullable<double>>>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_IndexManager.source + ".Notifier") 

                                               [| _name.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IndexManager.cell
                                ;  _name.cell
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
    [<ExcelFunction(Name="_IndexManager_setHistory", Description="Create a IndexManager",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IndexManager_setHistory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IndexManager",Description = "IndexManager")>] 
         indexmanager : obj)
        ([<ExcelArgument(Name="name",Description = "string")>] 
         name : obj)
        ([<ExcelArgument(Name="history",Description = "double")>] 
         history : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IndexManager = Helper.toModelReference<IndexManager> indexmanager "IndexManager"  
                let _name = Helper.toCell<string> name "name" 
                let _history = Helper.toCell<TimeSeries<Nullable<double>>> history "history" 
                let builder (current : ICell) = ((IndexManagerModel.Cast _IndexManager.cell).SetHistory
                                                            _name.cell 
                                                            _history.cell 
                                                       ) :> ICell
                let format (o : IndexManager) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_IndexManager.source + ".SetHistory") 

                                               [| _name.source
                                               ;  _history.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IndexManager.cell
                                ;  _name.cell
                                ;  _history.cell
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
    [<ExcelFunction(Name="_IndexManager_tryGetHistory", Description="Create a IndexManager",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IndexManager_tryGetHistory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IndexManager",Description = "IndexManager")>] 
         indexmanager : obj)
        ([<ExcelArgument(Name="name",Description = "string")>] 
         name : obj)
        ([<ExcelArgument(Name="history",Description = "double")>] 
         history : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IndexManager = Helper.toModelReference<IndexManager> indexmanager "IndexManager"  
                let _name = Helper.toCell<string> name "name" 
                let _history = Helper.toCell<TimeSeries<Nullable<double>>> history "history" 
                let builder (current : ICell) = ((IndexManagerModel.Cast _IndexManager.cell).TryGetHistory
                                                            _name.cell 
                                                            _history.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_IndexManager.source + ".TryGetHistory") 

                                               [| _name.source
                                               ;  _history.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IndexManager.cell
                                ;  _name.cell
                                ;  _history.cell
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
    [<ExcelFunction(Name="_IndexManager_Range", Description="Create a range of IndexManager",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IndexManager_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<IndexManager> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<IndexManager> (c)) :> ICell
                let format (i : Cephei.Cell.List<IndexManager>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<IndexManager>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
