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
module SEKCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SEKCurrency", Description="Create a SEKCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SEKCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = (Fun.SEKCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SEKCurrency>) l

                let source () = Helper.sourceFold "Fun.SEKCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SEKCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! currency name, e.g, "U.S. Dollar"
    *)
    [<ExcelFunction(Name="_SEKCurrency_code", Description="Create a SEKCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SEKCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SEKCurrency",Description = "SEKCurrency")>] 
         sekcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SEKCurrency = Helper.toModelReference<SEKCurrency> sekcurrency "SEKCurrency"  
                let builder (current : ICell) = ((SEKCurrencyModel.Cast _SEKCurrency.cell).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SEKCurrency.source + ".Code") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SEKCurrency.cell
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
        ! Other information ! is this a usable instance?
    *)
    [<ExcelFunction(Name="_SEKCurrency_empty", Description="Create a SEKCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SEKCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SEKCurrency",Description = "SEKCurrency")>] 
         sekcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SEKCurrency = Helper.toModelReference<SEKCurrency> sekcurrency "SEKCurrency"  
                let builder (current : ICell) = ((SEKCurrencyModel.Cast _SEKCurrency.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SEKCurrency.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SEKCurrency.cell
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
    [<ExcelFunction(Name="_SEKCurrency_Equals", Description="Create a SEKCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SEKCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SEKCurrency",Description = "SEKCurrency")>] 
         sekcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SEKCurrency = Helper.toModelReference<SEKCurrency> sekcurrency "SEKCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = ((SEKCurrencyModel.Cast _SEKCurrency.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SEKCurrency.source + ".Equals") 

                                               [| _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SEKCurrency.cell
                                ;  _o.cell
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
        ! currency used for triangulated exchange when required output format The format will be fed three positional parameters, namely, value, code, and symbol, in this order.
    *)
    [<ExcelFunction(Name="_SEKCurrency_format", Description="Create a SEKCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SEKCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SEKCurrency",Description = "SEKCurrency")>] 
         sekcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SEKCurrency = Helper.toModelReference<SEKCurrency> sekcurrency "SEKCurrency"  
                let builder (current : ICell) = ((SEKCurrencyModel.Cast _SEKCurrency.cell).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SEKCurrency.source + ".Format") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SEKCurrency.cell
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
        ! fraction symbol, e.g, "Â¢"
    *)
    [<ExcelFunction(Name="_SEKCurrency_fractionsPerUnit", Description="Create a SEKCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SEKCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SEKCurrency",Description = "SEKCurrency")>] 
         sekcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SEKCurrency = Helper.toModelReference<SEKCurrency> sekcurrency "SEKCurrency"  
                let builder (current : ICell) = ((SEKCurrencyModel.Cast _SEKCurrency.cell).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SEKCurrency.source + ".FractionsPerUnit") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SEKCurrency.cell
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
        ! symbol, e.g, "$"
    *)
    [<ExcelFunction(Name="_SEKCurrency_fractionSymbol", Description="Create a SEKCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SEKCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SEKCurrency",Description = "SEKCurrency")>] 
         sekcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SEKCurrency = Helper.toModelReference<SEKCurrency> sekcurrency "SEKCurrency"  
                let builder (current : ICell) = ((SEKCurrencyModel.Cast _SEKCurrency.cell).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SEKCurrency.source + ".FractionSymbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SEKCurrency.cell
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
        Inspectors
    *)
    [<ExcelFunction(Name="_SEKCurrency_name", Description="Create a SEKCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SEKCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SEKCurrency",Description = "SEKCurrency")>] 
         sekcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SEKCurrency = Helper.toModelReference<SEKCurrency> sekcurrency "SEKCurrency"  
                let builder (current : ICell) = ((SEKCurrencyModel.Cast _SEKCurrency.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SEKCurrency.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SEKCurrency.cell
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
        ! ISO 4217 three-letter code, e.g, "USD"
    *)
    [<ExcelFunction(Name="_SEKCurrency_numericCode", Description="Create a SEKCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SEKCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SEKCurrency",Description = "SEKCurrency")>] 
         sekcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SEKCurrency = Helper.toModelReference<SEKCurrency> sekcurrency "SEKCurrency"  
                let builder (current : ICell) = ((SEKCurrencyModel.Cast _SEKCurrency.cell).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SEKCurrency.source + ".NumericCode") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SEKCurrency.cell
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
        ! number of fractionary parts in a unit, e.g, 100
    *)
    [<ExcelFunction(Name="_SEKCurrency_rounding", Description="Create a SEKCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SEKCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SEKCurrency",Description = "SEKCurrency")>] 
         sekcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SEKCurrency = Helper.toModelReference<SEKCurrency> sekcurrency "SEKCurrency"  
                let builder (current : ICell) = ((SEKCurrencyModel.Cast _SEKCurrency.cell).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source () = Helper.sourceFold (_SEKCurrency.source + ".Rounding") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SEKCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SEKCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! ISO 4217 numeric code, e.g, "840"
    *)
    [<ExcelFunction(Name="_SEKCurrency_symbol", Description="Create a SEKCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SEKCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SEKCurrency",Description = "SEKCurrency")>] 
         sekcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SEKCurrency = Helper.toModelReference<SEKCurrency> sekcurrency "SEKCurrency"  
                let builder (current : ICell) = ((SEKCurrencyModel.Cast _SEKCurrency.cell).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SEKCurrency.source + ".Symbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SEKCurrency.cell
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
    [<ExcelFunction(Name="_SEKCurrency_ToString", Description="Create a SEKCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SEKCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SEKCurrency",Description = "SEKCurrency")>] 
         sekcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SEKCurrency = Helper.toModelReference<SEKCurrency> sekcurrency "SEKCurrency"  
                let builder (current : ICell) = ((SEKCurrencyModel.Cast _SEKCurrency.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SEKCurrency.source + ".ToString") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SEKCurrency.cell
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
        ! rounding convention
    *)
    [<ExcelFunction(Name="_SEKCurrency_triangulationCurrency", Description="Create a SEKCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SEKCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SEKCurrency",Description = "SEKCurrency")>] 
         sekcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SEKCurrency = Helper.toModelReference<SEKCurrency> sekcurrency "SEKCurrency"  
                let builder (current : ICell) = ((SEKCurrencyModel.Cast _SEKCurrency.cell).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_SEKCurrency.source + ".TriangulationCurrency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SEKCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SEKCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_SEKCurrency_Range", Description="Create a range of SEKCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SEKCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SEKCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<SEKCurrency> (c)) :> ICell
                let format (i : Cephei.Cell.List<SEKCurrency>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<SEKCurrency>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
