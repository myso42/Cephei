(*
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
(*!!
(* <summary>
exchange-rate repository test lookup of direct, triangulated, and derived exchange rates is tested
  </summary> *)
[<AutoSerializable(true)>]
module ExchangeRateManagerFunction =

    (*
        
    *)
    (*!! duplicate add function 
    [<ExcelFunction(Name="_ExchangeRateManager_add", Description="Create a ExchangeRateManager",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ExchangeRateManager_add
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ExchangeRateManager",Description = "Reference to ExchangeRateManager")>] 
         exchangeratemanager : obj)
        ([<ExcelArgument(Name="rate",Description = "Reference to rate")>] 
         rate : obj)
        ([<ExcelArgument(Name="startDate",Description = "Reference to startDate")>] 
         startDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ExchangeRateManager = Helper.toCell<ExchangeRateManager> exchangeratemanager "ExchangeRateManager" true 
                let _rate = Helper.toCell<ExchangeRate> rate "rate" true
                let _startDate = Helper.toCell<Date> startDate "startDate" true
                let builder () = withMnemonic mnemonic ((_ExchangeRateManager.cell :?> ExchangeRateManagerModel).Add
                                                            _rate.cell 
                                                            _startDate.cell 
                                                       ) :> ICell
                let format (o : ExchangeRateManager) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ExchangeRateManager.source + ".Add") 
                                               [| _ExchangeRateManager.source
                                               ;  _rate.source
                                               ;  _startDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ExchangeRateManager.cell
                                ;  _rate.cell
                                ;  _startDate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
            *)
    (*
        
    *)
    (*!! duplicate add function
    [<ExcelFunction(Name="_ExchangeRateManager_add", Description="Create a ExchangeRateManager",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ExchangeRateManager_add
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ExchangeRateManager",Description = "Reference to ExchangeRateManager")>] 
         exchangeratemanager : obj)
        ([<ExcelArgument(Name="rate",Description = "Reference to rate")>] 
         rate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ExchangeRateManager = Helper.toCell<ExchangeRateManager> exchangeratemanager "ExchangeRateManager" true 
                let _rate = Helper.toCell<ExchangeRate> rate "rate" true
                let builder () = withMnemonic mnemonic ((_ExchangeRateManager.cell :?> ExchangeRateManagerModel).Add
                                                            _rate.cell 
                                                       ) :> ICell
                let format (o : ExchangeRateManager) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ExchangeRateManager.source + ".Add") 
                                               [| _ExchangeRateManager.source
                                               ;  _rate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ExchangeRateManager.cell
                                ;  _rate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
            *)
    (*
        remove the added exchange rates
    *)
    [<ExcelFunction(Name="_ExchangeRateManager_clear", Description="Create a ExchangeRateManager",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ExchangeRateManager_clear
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ExchangeRateManager",Description = "Reference to ExchangeRateManager")>] 
         exchangeratemanager : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ExchangeRateManager = Helper.toCell<ExchangeRateManager> exchangeratemanager "ExchangeRateManager" true 
                let builder () = withMnemonic mnemonic ((_ExchangeRateManager.cell :?> ExchangeRateManagerModel).Clear
                                                       ) :> ICell
                let format (o : ExchangeRateManager) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ExchangeRateManager.source + ".Clear") 
                                               [| _ExchangeRateManager.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ExchangeRateManager.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
        Lookup the exchange rate between two currencies at a given date.  If the given type is Direct, only direct exchange rates will be returned if available; if Derived, direct rates are still preferred but derived rates are allowed. if two or more exchange-rate chains are possible which allow to specify a requested rate, it is unspecified which one is returned.
    *)
    [<ExcelFunction(Name="_ExchangeRateManager_lookup", Description="Create a ExchangeRateManager",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ExchangeRateManager_lookup
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ExchangeRateManager",Description = "Reference to ExchangeRateManager")>] 
         exchangeratemanager : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="target",Description = "Reference to target")>] 
         target : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ExchangeRateManager = Helper.toCell<ExchangeRateManager> exchangeratemanager "ExchangeRateManager" true 
                let _source = Helper.toCell<Currency> source "source" true
                let _target = Helper.toCell<Currency> target "target" true
                let _date = Helper.toCell<Date> date "date" true
                let _Type = Helper.toCell<ExchangeRate.Type> Type "Type" true
                let builder () = withMnemonic mnemonic ((_ExchangeRateManager.cell :?> ExchangeRateManagerModel).Lookup
                                                            _source.cell 
                                                            _target.cell 
                                                            _date.cell 
                                                            _Type.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ExchangeRate>) l

                let source = Helper.sourceFold (_ExchangeRateManager.source + ".Lookup") 
                                               [| _ExchangeRateManager.source
                                               ;  _source.source
                                               ;  _target.source
                                               ;  _date.source
                                               ;  _Type.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ExchangeRateManager.cell
                                ;  _source.cell
                                ;  _target.cell
                                ;  _date.cell
                                ;  _Type.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ExchangeRateManager_lookup", Description="Create a ExchangeRateManager",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ExchangeRateManager_lookup
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ExchangeRateManager",Description = "Reference to ExchangeRateManager")>] 
         exchangeratemanager : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="target",Description = "Reference to target")>] 
         target : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ExchangeRateManager = Helper.toCell<ExchangeRateManager> exchangeratemanager "ExchangeRateManager" true 
                let _source = Helper.toCell<Currency> source "source" true
                let _target = Helper.toCell<Currency> target "target" true
                let _date = Helper.toCell<Date> date "date" true
                let builder () = withMnemonic mnemonic ((_ExchangeRateManager.cell :?> ExchangeRateManagerModel).Lookup1
                                                            _source.cell 
                                                            _target.cell 
                                                            _date.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ExchangeRate>) l

                let source = Helper.sourceFold (_ExchangeRateManager.source + ".Lookup") 
                                               [| _ExchangeRateManager.source
                                               ;  _source.source
                                               ;  _target.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ExchangeRateManager.cell
                                ;  _source.cell
                                ;  _target.cell
                                ;  _date.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ExchangeRateManager_lookup", Description="Create a ExchangeRateManager",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ExchangeRateManager_lookup
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ExchangeRateManager",Description = "Reference to ExchangeRateManager")>] 
         exchangeratemanager : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="target",Description = "Reference to target")>] 
         target : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ExchangeRateManager = Helper.toCell<ExchangeRateManager> exchangeratemanager "ExchangeRateManager" true 
                let _source = Helper.toCell<Currency> source "source" true
                let _target = Helper.toCell<Currency> target "target" true
                let builder () = withMnemonic mnemonic ((_ExchangeRateManager.cell :?> ExchangeRateManagerModel).Lookup2
                                                            _source.cell 
                                                            _target.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ExchangeRate>) l

                let source = Helper.sourceFold (_ExchangeRateManager.source + ".Lookup") 
                                               [| _ExchangeRateManager.source
                                               ;  _source.source
                                               ;  _target.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ExchangeRateManager.cell
                                ;  _source.cell
                                ;  _target.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_ExchangeRateManager_Range", Description="Create a range of ExchangeRateManager",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ExchangeRateManager_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the ExchangeRateManager")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ExchangeRateManager> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ExchangeRateManager>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<ExchangeRateManager>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<ExchangeRateManager>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)