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
module NLGCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_NLGCurrency", Description="Create a NLGCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NLGCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = (Fun.NLGCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<NLGCurrency>) l

                let source () = Helper.sourceFold "Fun.NLGCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NLGCurrency> format
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
    [<ExcelFunction(Name="_NLGCurrency_code", Description="Create a NLGCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NLGCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NLGCurrency",Description = "NLGCurrency")>] 
         nlgcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NLGCurrency = Helper.toModelReference<NLGCurrency> nlgcurrency "NLGCurrency"  
                let builder (current : ICell) = ((NLGCurrencyModel.Cast _NLGCurrency.cell).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NLGCurrency.source + ".Code") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NLGCurrency.cell
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
    [<ExcelFunction(Name="_NLGCurrency_empty", Description="Create a NLGCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NLGCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NLGCurrency",Description = "NLGCurrency")>] 
         nlgcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NLGCurrency = Helper.toModelReference<NLGCurrency> nlgcurrency "NLGCurrency"  
                let builder (current : ICell) = ((NLGCurrencyModel.Cast _NLGCurrency.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NLGCurrency.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NLGCurrency.cell
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
    [<ExcelFunction(Name="_NLGCurrency_Equals", Description="Create a NLGCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NLGCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NLGCurrency",Description = "NLGCurrency")>] 
         nlgcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NLGCurrency = Helper.toModelReference<NLGCurrency> nlgcurrency "NLGCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = ((NLGCurrencyModel.Cast _NLGCurrency.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NLGCurrency.source + ".Equals") 

                                               [| _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NLGCurrency.cell
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
    [<ExcelFunction(Name="_NLGCurrency_format", Description="Create a NLGCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NLGCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NLGCurrency",Description = "NLGCurrency")>] 
         nlgcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NLGCurrency = Helper.toModelReference<NLGCurrency> nlgcurrency "NLGCurrency"  
                let builder (current : ICell) = ((NLGCurrencyModel.Cast _NLGCurrency.cell).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NLGCurrency.source + ".Format") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NLGCurrency.cell
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
    [<ExcelFunction(Name="_NLGCurrency_fractionsPerUnit", Description="Create a NLGCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NLGCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NLGCurrency",Description = "NLGCurrency")>] 
         nlgcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NLGCurrency = Helper.toModelReference<NLGCurrency> nlgcurrency "NLGCurrency"  
                let builder (current : ICell) = ((NLGCurrencyModel.Cast _NLGCurrency.cell).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_NLGCurrency.source + ".FractionsPerUnit") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NLGCurrency.cell
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
    [<ExcelFunction(Name="_NLGCurrency_fractionSymbol", Description="Create a NLGCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NLGCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NLGCurrency",Description = "NLGCurrency")>] 
         nlgcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NLGCurrency = Helper.toModelReference<NLGCurrency> nlgcurrency "NLGCurrency"  
                let builder (current : ICell) = ((NLGCurrencyModel.Cast _NLGCurrency.cell).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NLGCurrency.source + ".FractionSymbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NLGCurrency.cell
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
    [<ExcelFunction(Name="_NLGCurrency_name", Description="Create a NLGCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NLGCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NLGCurrency",Description = "NLGCurrency")>] 
         nlgcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NLGCurrency = Helper.toModelReference<NLGCurrency> nlgcurrency "NLGCurrency"  
                let builder (current : ICell) = ((NLGCurrencyModel.Cast _NLGCurrency.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NLGCurrency.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NLGCurrency.cell
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
    [<ExcelFunction(Name="_NLGCurrency_numericCode", Description="Create a NLGCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NLGCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NLGCurrency",Description = "NLGCurrency")>] 
         nlgcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NLGCurrency = Helper.toModelReference<NLGCurrency> nlgcurrency "NLGCurrency"  
                let builder (current : ICell) = ((NLGCurrencyModel.Cast _NLGCurrency.cell).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_NLGCurrency.source + ".NumericCode") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NLGCurrency.cell
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
    [<ExcelFunction(Name="_NLGCurrency_rounding", Description="Create a NLGCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NLGCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NLGCurrency",Description = "NLGCurrency")>] 
         nlgcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NLGCurrency = Helper.toModelReference<NLGCurrency> nlgcurrency "NLGCurrency"  
                let builder (current : ICell) = ((NLGCurrencyModel.Cast _NLGCurrency.cell).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source () = Helper.sourceFold (_NLGCurrency.source + ".Rounding") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NLGCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NLGCurrency> format
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
    [<ExcelFunction(Name="_NLGCurrency_symbol", Description="Create a NLGCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NLGCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NLGCurrency",Description = "NLGCurrency")>] 
         nlgcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NLGCurrency = Helper.toModelReference<NLGCurrency> nlgcurrency "NLGCurrency"  
                let builder (current : ICell) = ((NLGCurrencyModel.Cast _NLGCurrency.cell).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NLGCurrency.source + ".Symbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NLGCurrency.cell
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
    [<ExcelFunction(Name="_NLGCurrency_ToString", Description="Create a NLGCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NLGCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NLGCurrency",Description = "NLGCurrency")>] 
         nlgcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NLGCurrency = Helper.toModelReference<NLGCurrency> nlgcurrency "NLGCurrency"  
                let builder (current : ICell) = ((NLGCurrencyModel.Cast _NLGCurrency.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NLGCurrency.source + ".ToString") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NLGCurrency.cell
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
    [<ExcelFunction(Name="_NLGCurrency_triangulationCurrency", Description="Create a NLGCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NLGCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NLGCurrency",Description = "NLGCurrency")>] 
         nlgcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NLGCurrency = Helper.toModelReference<NLGCurrency> nlgcurrency "NLGCurrency"  
                let builder (current : ICell) = ((NLGCurrencyModel.Cast _NLGCurrency.cell).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_NLGCurrency.source + ".TriangulationCurrency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NLGCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NLGCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_NLGCurrency_Range", Description="Create a range of NLGCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NLGCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<NLGCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<NLGCurrency> (c)) :> ICell
                let format (i : Cephei.Cell.List<NLGCurrency>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<NLGCurrency>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
