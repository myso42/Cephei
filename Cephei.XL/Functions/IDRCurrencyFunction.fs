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
  The ISO three-letter code is IDR; the numeric code is 360. It is divided in 100 sen.  currencies
  </summary> *)
[<AutoSerializable(true)>]
module IDRCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_IDRCurrency", Description="Create a IDRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IDRCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = (Fun.IDRCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IDRCurrency>) l

                let source () = Helper.sourceFold "Fun.IDRCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<IDRCurrency> format
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
    [<ExcelFunction(Name="_IDRCurrency_code", Description="Create a IDRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IDRCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IDRCurrency",Description = "IDRCurrency")>] 
         idrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IDRCurrency = Helper.toModelReference<IDRCurrency> idrcurrency "IDRCurrency"  
                let builder (current : ICell) = ((IDRCurrencyModel.Cast _IDRCurrency.cell).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_IDRCurrency.source + ".Code") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _IDRCurrency.cell
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
    [<ExcelFunction(Name="_IDRCurrency_empty", Description="Create a IDRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IDRCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IDRCurrency",Description = "IDRCurrency")>] 
         idrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IDRCurrency = Helper.toModelReference<IDRCurrency> idrcurrency "IDRCurrency"  
                let builder (current : ICell) = ((IDRCurrencyModel.Cast _IDRCurrency.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_IDRCurrency.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _IDRCurrency.cell
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
    [<ExcelFunction(Name="_IDRCurrency_Equals", Description="Create a IDRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IDRCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IDRCurrency",Description = "IDRCurrency")>] 
         idrcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IDRCurrency = Helper.toModelReference<IDRCurrency> idrcurrency "IDRCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = ((IDRCurrencyModel.Cast _IDRCurrency.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_IDRCurrency.source + ".Equals") 

                                               [| _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IDRCurrency.cell
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
    [<ExcelFunction(Name="_IDRCurrency_format", Description="Create a IDRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IDRCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IDRCurrency",Description = "IDRCurrency")>] 
         idrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IDRCurrency = Helper.toModelReference<IDRCurrency> idrcurrency "IDRCurrency"  
                let builder (current : ICell) = ((IDRCurrencyModel.Cast _IDRCurrency.cell).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_IDRCurrency.source + ".Format") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _IDRCurrency.cell
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
    [<ExcelFunction(Name="_IDRCurrency_fractionsPerUnit", Description="Create a IDRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IDRCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IDRCurrency",Description = "IDRCurrency")>] 
         idrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IDRCurrency = Helper.toModelReference<IDRCurrency> idrcurrency "IDRCurrency"  
                let builder (current : ICell) = ((IDRCurrencyModel.Cast _IDRCurrency.cell).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_IDRCurrency.source + ".FractionsPerUnit") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _IDRCurrency.cell
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
    [<ExcelFunction(Name="_IDRCurrency_fractionSymbol", Description="Create a IDRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IDRCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IDRCurrency",Description = "IDRCurrency")>] 
         idrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IDRCurrency = Helper.toModelReference<IDRCurrency> idrcurrency "IDRCurrency"  
                let builder (current : ICell) = ((IDRCurrencyModel.Cast _IDRCurrency.cell).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_IDRCurrency.source + ".FractionSymbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _IDRCurrency.cell
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
    [<ExcelFunction(Name="_IDRCurrency_name", Description="Create a IDRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IDRCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IDRCurrency",Description = "IDRCurrency")>] 
         idrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IDRCurrency = Helper.toModelReference<IDRCurrency> idrcurrency "IDRCurrency"  
                let builder (current : ICell) = ((IDRCurrencyModel.Cast _IDRCurrency.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_IDRCurrency.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _IDRCurrency.cell
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
    [<ExcelFunction(Name="_IDRCurrency_numericCode", Description="Create a IDRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IDRCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IDRCurrency",Description = "IDRCurrency")>] 
         idrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IDRCurrency = Helper.toModelReference<IDRCurrency> idrcurrency "IDRCurrency"  
                let builder (current : ICell) = ((IDRCurrencyModel.Cast _IDRCurrency.cell).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_IDRCurrency.source + ".NumericCode") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _IDRCurrency.cell
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
    [<ExcelFunction(Name="_IDRCurrency_rounding", Description="Create a IDRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IDRCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IDRCurrency",Description = "IDRCurrency")>] 
         idrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IDRCurrency = Helper.toModelReference<IDRCurrency> idrcurrency "IDRCurrency"  
                let builder (current : ICell) = ((IDRCurrencyModel.Cast _IDRCurrency.cell).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source () = Helper.sourceFold (_IDRCurrency.source + ".Rounding") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _IDRCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<IDRCurrency> format
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
    [<ExcelFunction(Name="_IDRCurrency_symbol", Description="Create a IDRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IDRCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IDRCurrency",Description = "IDRCurrency")>] 
         idrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IDRCurrency = Helper.toModelReference<IDRCurrency> idrcurrency "IDRCurrency"  
                let builder (current : ICell) = ((IDRCurrencyModel.Cast _IDRCurrency.cell).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_IDRCurrency.source + ".Symbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _IDRCurrency.cell
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
    [<ExcelFunction(Name="_IDRCurrency_ToString", Description="Create a IDRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IDRCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IDRCurrency",Description = "IDRCurrency")>] 
         idrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IDRCurrency = Helper.toModelReference<IDRCurrency> idrcurrency "IDRCurrency"  
                let builder (current : ICell) = ((IDRCurrencyModel.Cast _IDRCurrency.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_IDRCurrency.source + ".ToString") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _IDRCurrency.cell
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
    [<ExcelFunction(Name="_IDRCurrency_triangulationCurrency", Description="Create a IDRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IDRCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IDRCurrency",Description = "IDRCurrency")>] 
         idrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IDRCurrency = Helper.toModelReference<IDRCurrency> idrcurrency "IDRCurrency"  
                let builder (current : ICell) = ((IDRCurrencyModel.Cast _IDRCurrency.cell).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_IDRCurrency.source + ".TriangulationCurrency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _IDRCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<IDRCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_IDRCurrency_Range", Description="Create a range of IDRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IDRCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<IDRCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<IDRCurrency> (c)) :> ICell
                let format (i : Cephei.Cell.List<IDRCurrency>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<IDRCurrency>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
