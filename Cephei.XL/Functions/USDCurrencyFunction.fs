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
  U.S. dollar   The ISO three-letter code is USD; the numeric code is 840. It is divided in 100 cents.  currencies
  </summary> *)
[<AutoSerializable(true)>]
module USDCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_USDCurrency", Description="Create a USDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USDCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = (Fun.USDCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<USDCurrency>) l

                let source () = Helper.sourceFold "Fun.USDCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<USDCurrency> format
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
    [<ExcelFunction(Name="_USDCurrency_code", Description="Create a USDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USDCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDCurrency",Description = "USDCurrency")>] 
         usdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDCurrency = Helper.toModelReference<USDCurrency> usdcurrency "USDCurrency"  
                let builder (current : ICell) = ((USDCurrencyModel.Cast _USDCurrency.cell).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_USDCurrency.source + ".Code") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _USDCurrency.cell
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
    [<ExcelFunction(Name="_USDCurrency_empty", Description="Create a USDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USDCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDCurrency",Description = "USDCurrency")>] 
         usdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDCurrency = Helper.toModelReference<USDCurrency> usdcurrency "USDCurrency"  
                let builder (current : ICell) = ((USDCurrencyModel.Cast _USDCurrency.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_USDCurrency.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _USDCurrency.cell
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
    [<ExcelFunction(Name="_USDCurrency_Equals", Description="Create a USDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USDCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDCurrency",Description = "USDCurrency")>] 
         usdcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDCurrency = Helper.toModelReference<USDCurrency> usdcurrency "USDCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = ((USDCurrencyModel.Cast _USDCurrency.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_USDCurrency.source + ".Equals") 

                                               [| _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDCurrency.cell
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
    [<ExcelFunction(Name="_USDCurrency_format", Description="Create a USDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USDCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDCurrency",Description = "USDCurrency")>] 
         usdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDCurrency = Helper.toModelReference<USDCurrency> usdcurrency "USDCurrency"  
                let builder (current : ICell) = ((USDCurrencyModel.Cast _USDCurrency.cell).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_USDCurrency.source + ".Format") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _USDCurrency.cell
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
    [<ExcelFunction(Name="_USDCurrency_fractionsPerUnit", Description="Create a USDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USDCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDCurrency",Description = "USDCurrency")>] 
         usdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDCurrency = Helper.toModelReference<USDCurrency> usdcurrency "USDCurrency"  
                let builder (current : ICell) = ((USDCurrencyModel.Cast _USDCurrency.cell).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_USDCurrency.source + ".FractionsPerUnit") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _USDCurrency.cell
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
    [<ExcelFunction(Name="_USDCurrency_fractionSymbol", Description="Create a USDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USDCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDCurrency",Description = "USDCurrency")>] 
         usdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDCurrency = Helper.toModelReference<USDCurrency> usdcurrency "USDCurrency"  
                let builder (current : ICell) = ((USDCurrencyModel.Cast _USDCurrency.cell).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_USDCurrency.source + ".FractionSymbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _USDCurrency.cell
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
    [<ExcelFunction(Name="_USDCurrency_name", Description="Create a USDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USDCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDCurrency",Description = "USDCurrency")>] 
         usdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDCurrency = Helper.toModelReference<USDCurrency> usdcurrency "USDCurrency"  
                let builder (current : ICell) = ((USDCurrencyModel.Cast _USDCurrency.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_USDCurrency.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _USDCurrency.cell
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
    [<ExcelFunction(Name="_USDCurrency_numericCode", Description="Create a USDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USDCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDCurrency",Description = "USDCurrency")>] 
         usdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDCurrency = Helper.toModelReference<USDCurrency> usdcurrency "USDCurrency"  
                let builder (current : ICell) = ((USDCurrencyModel.Cast _USDCurrency.cell).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_USDCurrency.source + ".NumericCode") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _USDCurrency.cell
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
    [<ExcelFunction(Name="_USDCurrency_rounding", Description="Create a USDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USDCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDCurrency",Description = "USDCurrency")>] 
         usdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDCurrency = Helper.toModelReference<USDCurrency> usdcurrency "USDCurrency"  
                let builder (current : ICell) = ((USDCurrencyModel.Cast _USDCurrency.cell).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source () = Helper.sourceFold (_USDCurrency.source + ".Rounding") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _USDCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<USDCurrency> format
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
    [<ExcelFunction(Name="_USDCurrency_symbol", Description="Create a USDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USDCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDCurrency",Description = "USDCurrency")>] 
         usdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDCurrency = Helper.toModelReference<USDCurrency> usdcurrency "USDCurrency"  
                let builder (current : ICell) = ((USDCurrencyModel.Cast _USDCurrency.cell).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_USDCurrency.source + ".Symbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _USDCurrency.cell
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
    [<ExcelFunction(Name="_USDCurrency_ToString", Description="Create a USDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USDCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDCurrency",Description = "USDCurrency")>] 
         usdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDCurrency = Helper.toModelReference<USDCurrency> usdcurrency "USDCurrency"  
                let builder (current : ICell) = ((USDCurrencyModel.Cast _USDCurrency.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_USDCurrency.source + ".ToString") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _USDCurrency.cell
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
    [<ExcelFunction(Name="_USDCurrency_triangulationCurrency", Description="Create a USDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USDCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDCurrency",Description = "USDCurrency")>] 
         usdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDCurrency = Helper.toModelReference<USDCurrency> usdcurrency "USDCurrency"  
                let builder (current : ICell) = ((USDCurrencyModel.Cast _USDCurrency.cell).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_USDCurrency.source + ".TriangulationCurrency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _USDCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<USDCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_USDCurrency_Range", Description="Create a range of USDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USDCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<USDCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<USDCurrency> (c)) :> ICell
                let format (i : Cephei.Cell.List<USDCurrency>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<USDCurrency>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
