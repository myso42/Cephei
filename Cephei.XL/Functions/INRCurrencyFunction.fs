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
  The ISO three-letter code is INR; the numeric code is 356. It is divided in 100 paise.  currencies
  </summary> *)
[<AutoSerializable(true)>]
module INRCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_INRCurrency", Description="Create a INRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let INRCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = (Fun.INRCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<INRCurrency>) l

                let source () = Helper.sourceFold "Fun.INRCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<INRCurrency> format
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
    [<ExcelFunction(Name="_INRCurrency_code", Description="Create a INRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let INRCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="INRCurrency",Description = "INRCurrency")>] 
         inrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _INRCurrency = Helper.toModelReference<INRCurrency> inrcurrency "INRCurrency"  
                let builder (current : ICell) = ((INRCurrencyModel.Cast _INRCurrency.cell).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_INRCurrency.source + ".Code") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _INRCurrency.cell
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
    [<ExcelFunction(Name="_INRCurrency_empty", Description="Create a INRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let INRCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="INRCurrency",Description = "INRCurrency")>] 
         inrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _INRCurrency = Helper.toModelReference<INRCurrency> inrcurrency "INRCurrency"  
                let builder (current : ICell) = ((INRCurrencyModel.Cast _INRCurrency.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_INRCurrency.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _INRCurrency.cell
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
    [<ExcelFunction(Name="_INRCurrency_Equals", Description="Create a INRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let INRCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="INRCurrency",Description = "INRCurrency")>] 
         inrcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _INRCurrency = Helper.toModelReference<INRCurrency> inrcurrency "INRCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = ((INRCurrencyModel.Cast _INRCurrency.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_INRCurrency.source + ".Equals") 

                                               [| _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _INRCurrency.cell
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
    [<ExcelFunction(Name="_INRCurrency_format", Description="Create a INRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let INRCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="INRCurrency",Description = "INRCurrency")>] 
         inrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _INRCurrency = Helper.toModelReference<INRCurrency> inrcurrency "INRCurrency"  
                let builder (current : ICell) = ((INRCurrencyModel.Cast _INRCurrency.cell).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_INRCurrency.source + ".Format") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _INRCurrency.cell
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
    [<ExcelFunction(Name="_INRCurrency_fractionsPerUnit", Description="Create a INRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let INRCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="INRCurrency",Description = "INRCurrency")>] 
         inrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _INRCurrency = Helper.toModelReference<INRCurrency> inrcurrency "INRCurrency"  
                let builder (current : ICell) = ((INRCurrencyModel.Cast _INRCurrency.cell).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_INRCurrency.source + ".FractionsPerUnit") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _INRCurrency.cell
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
    [<ExcelFunction(Name="_INRCurrency_fractionSymbol", Description="Create a INRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let INRCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="INRCurrency",Description = "INRCurrency")>] 
         inrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _INRCurrency = Helper.toModelReference<INRCurrency> inrcurrency "INRCurrency"  
                let builder (current : ICell) = ((INRCurrencyModel.Cast _INRCurrency.cell).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_INRCurrency.source + ".FractionSymbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _INRCurrency.cell
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
    [<ExcelFunction(Name="_INRCurrency_name", Description="Create a INRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let INRCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="INRCurrency",Description = "INRCurrency")>] 
         inrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _INRCurrency = Helper.toModelReference<INRCurrency> inrcurrency "INRCurrency"  
                let builder (current : ICell) = ((INRCurrencyModel.Cast _INRCurrency.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_INRCurrency.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _INRCurrency.cell
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
    [<ExcelFunction(Name="_INRCurrency_numericCode", Description="Create a INRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let INRCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="INRCurrency",Description = "INRCurrency")>] 
         inrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _INRCurrency = Helper.toModelReference<INRCurrency> inrcurrency "INRCurrency"  
                let builder (current : ICell) = ((INRCurrencyModel.Cast _INRCurrency.cell).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_INRCurrency.source + ".NumericCode") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _INRCurrency.cell
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
    [<ExcelFunction(Name="_INRCurrency_rounding", Description="Create a INRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let INRCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="INRCurrency",Description = "INRCurrency")>] 
         inrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _INRCurrency = Helper.toModelReference<INRCurrency> inrcurrency "INRCurrency"  
                let builder (current : ICell) = ((INRCurrencyModel.Cast _INRCurrency.cell).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source () = Helper.sourceFold (_INRCurrency.source + ".Rounding") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _INRCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<INRCurrency> format
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
    [<ExcelFunction(Name="_INRCurrency_symbol", Description="Create a INRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let INRCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="INRCurrency",Description = "INRCurrency")>] 
         inrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _INRCurrency = Helper.toModelReference<INRCurrency> inrcurrency "INRCurrency"  
                let builder (current : ICell) = ((INRCurrencyModel.Cast _INRCurrency.cell).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_INRCurrency.source + ".Symbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _INRCurrency.cell
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
    [<ExcelFunction(Name="_INRCurrency_ToString", Description="Create a INRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let INRCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="INRCurrency",Description = "INRCurrency")>] 
         inrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _INRCurrency = Helper.toModelReference<INRCurrency> inrcurrency "INRCurrency"  
                let builder (current : ICell) = ((INRCurrencyModel.Cast _INRCurrency.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_INRCurrency.source + ".ToString") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _INRCurrency.cell
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
    [<ExcelFunction(Name="_INRCurrency_triangulationCurrency", Description="Create a INRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let INRCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="INRCurrency",Description = "INRCurrency")>] 
         inrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _INRCurrency = Helper.toModelReference<INRCurrency> inrcurrency "INRCurrency"  
                let builder (current : ICell) = ((INRCurrencyModel.Cast _INRCurrency.cell).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_INRCurrency.source + ".TriangulationCurrency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _INRCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<INRCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_INRCurrency_Range", Description="Create a range of INRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let INRCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<INRCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<INRCurrency> (c)) :> ICell
                let format (i : Cephei.Cell.List<INRCurrency>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<INRCurrency>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
