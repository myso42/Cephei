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
  The ISO three-letter code is RUB; the numeric code is 643. It is divided in 100 kopeyki.  currencies
  </summary> *)
[<AutoSerializable(true)>]
module RUBCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_RUBCurrency", Description="Create a RUBCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RUBCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = (Fun.RUBCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RUBCurrency>) l

                let source () = Helper.sourceFold "Fun.RUBCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<RUBCurrency> format
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
    [<ExcelFunction(Name="_RUBCurrency_code", Description="Create a RUBCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RUBCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RUBCurrency",Description = "RUBCurrency")>] 
         rubcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RUBCurrency = Helper.toModelReference<RUBCurrency> rubcurrency "RUBCurrency"  
                let builder (current : ICell) = ((RUBCurrencyModel.Cast _RUBCurrency.cell).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_RUBCurrency.source + ".Code") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _RUBCurrency.cell
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
    [<ExcelFunction(Name="_RUBCurrency_empty", Description="Create a RUBCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RUBCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RUBCurrency",Description = "RUBCurrency")>] 
         rubcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RUBCurrency = Helper.toModelReference<RUBCurrency> rubcurrency "RUBCurrency"  
                let builder (current : ICell) = ((RUBCurrencyModel.Cast _RUBCurrency.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_RUBCurrency.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _RUBCurrency.cell
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
    [<ExcelFunction(Name="_RUBCurrency_Equals", Description="Create a RUBCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RUBCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RUBCurrency",Description = "RUBCurrency")>] 
         rubcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RUBCurrency = Helper.toModelReference<RUBCurrency> rubcurrency "RUBCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = ((RUBCurrencyModel.Cast _RUBCurrency.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_RUBCurrency.source + ".Equals") 

                                               [| _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RUBCurrency.cell
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
    [<ExcelFunction(Name="_RUBCurrency_format", Description="Create a RUBCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RUBCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RUBCurrency",Description = "RUBCurrency")>] 
         rubcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RUBCurrency = Helper.toModelReference<RUBCurrency> rubcurrency "RUBCurrency"  
                let builder (current : ICell) = ((RUBCurrencyModel.Cast _RUBCurrency.cell).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_RUBCurrency.source + ".Format") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _RUBCurrency.cell
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
    [<ExcelFunction(Name="_RUBCurrency_fractionsPerUnit", Description="Create a RUBCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RUBCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RUBCurrency",Description = "RUBCurrency")>] 
         rubcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RUBCurrency = Helper.toModelReference<RUBCurrency> rubcurrency "RUBCurrency"  
                let builder (current : ICell) = ((RUBCurrencyModel.Cast _RUBCurrency.cell).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RUBCurrency.source + ".FractionsPerUnit") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _RUBCurrency.cell
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
    [<ExcelFunction(Name="_RUBCurrency_fractionSymbol", Description="Create a RUBCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RUBCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RUBCurrency",Description = "RUBCurrency")>] 
         rubcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RUBCurrency = Helper.toModelReference<RUBCurrency> rubcurrency "RUBCurrency"  
                let builder (current : ICell) = ((RUBCurrencyModel.Cast _RUBCurrency.cell).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_RUBCurrency.source + ".FractionSymbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _RUBCurrency.cell
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
    [<ExcelFunction(Name="_RUBCurrency_name", Description="Create a RUBCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RUBCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RUBCurrency",Description = "RUBCurrency")>] 
         rubcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RUBCurrency = Helper.toModelReference<RUBCurrency> rubcurrency "RUBCurrency"  
                let builder (current : ICell) = ((RUBCurrencyModel.Cast _RUBCurrency.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_RUBCurrency.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _RUBCurrency.cell
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
    [<ExcelFunction(Name="_RUBCurrency_numericCode", Description="Create a RUBCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RUBCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RUBCurrency",Description = "RUBCurrency")>] 
         rubcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RUBCurrency = Helper.toModelReference<RUBCurrency> rubcurrency "RUBCurrency"  
                let builder (current : ICell) = ((RUBCurrencyModel.Cast _RUBCurrency.cell).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RUBCurrency.source + ".NumericCode") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _RUBCurrency.cell
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
    [<ExcelFunction(Name="_RUBCurrency_rounding", Description="Create a RUBCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RUBCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RUBCurrency",Description = "RUBCurrency")>] 
         rubcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RUBCurrency = Helper.toModelReference<RUBCurrency> rubcurrency "RUBCurrency"  
                let builder (current : ICell) = ((RUBCurrencyModel.Cast _RUBCurrency.cell).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source () = Helper.sourceFold (_RUBCurrency.source + ".Rounding") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _RUBCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<RUBCurrency> format
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
    [<ExcelFunction(Name="_RUBCurrency_symbol", Description="Create a RUBCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RUBCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RUBCurrency",Description = "RUBCurrency")>] 
         rubcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RUBCurrency = Helper.toModelReference<RUBCurrency> rubcurrency "RUBCurrency"  
                let builder (current : ICell) = ((RUBCurrencyModel.Cast _RUBCurrency.cell).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_RUBCurrency.source + ".Symbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _RUBCurrency.cell
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
    [<ExcelFunction(Name="_RUBCurrency_ToString", Description="Create a RUBCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RUBCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RUBCurrency",Description = "RUBCurrency")>] 
         rubcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RUBCurrency = Helper.toModelReference<RUBCurrency> rubcurrency "RUBCurrency"  
                let builder (current : ICell) = ((RUBCurrencyModel.Cast _RUBCurrency.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_RUBCurrency.source + ".ToString") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _RUBCurrency.cell
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
    [<ExcelFunction(Name="_RUBCurrency_triangulationCurrency", Description="Create a RUBCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RUBCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RUBCurrency",Description = "RUBCurrency")>] 
         rubcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RUBCurrency = Helper.toModelReference<RUBCurrency> rubcurrency "RUBCurrency"  
                let builder (current : ICell) = ((RUBCurrencyModel.Cast _RUBCurrency.cell).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_RUBCurrency.source + ".TriangulationCurrency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _RUBCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<RUBCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_RUBCurrency_Range", Description="Create a range of RUBCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RUBCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<RUBCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<RUBCurrency> (c)) :> ICell
                let format (i : Cephei.Cell.List<RUBCurrency>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<RUBCurrency>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
