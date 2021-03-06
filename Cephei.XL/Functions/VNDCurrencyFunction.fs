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
  The ISO three-letter code is VND; the numeric code is 704. It was divided in 100 xu.  currencies
  </summary> *)
[<AutoSerializable(true)>]
module VNDCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_VNDCurrency", Description="Create a VNDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VNDCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = (Fun.VNDCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<VNDCurrency>) l

                let source () = Helper.sourceFold "Fun.VNDCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<VNDCurrency> format
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
    [<ExcelFunction(Name="_VNDCurrency_code", Description="Create a VNDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VNDCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VNDCurrency",Description = "VNDCurrency")>] 
         vndcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VNDCurrency = Helper.toModelReference<VNDCurrency> vndcurrency "VNDCurrency"  
                let builder (current : ICell) = ((VNDCurrencyModel.Cast _VNDCurrency.cell).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_VNDCurrency.source + ".Code") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _VNDCurrency.cell
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
    [<ExcelFunction(Name="_VNDCurrency_empty", Description="Create a VNDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VNDCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VNDCurrency",Description = "VNDCurrency")>] 
         vndcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VNDCurrency = Helper.toModelReference<VNDCurrency> vndcurrency "VNDCurrency"  
                let builder (current : ICell) = ((VNDCurrencyModel.Cast _VNDCurrency.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_VNDCurrency.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _VNDCurrency.cell
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
    [<ExcelFunction(Name="_VNDCurrency_Equals", Description="Create a VNDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VNDCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VNDCurrency",Description = "VNDCurrency")>] 
         vndcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VNDCurrency = Helper.toModelReference<VNDCurrency> vndcurrency "VNDCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = ((VNDCurrencyModel.Cast _VNDCurrency.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_VNDCurrency.source + ".Equals") 

                                               [| _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VNDCurrency.cell
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
    [<ExcelFunction(Name="_VNDCurrency_format", Description="Create a VNDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VNDCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VNDCurrency",Description = "VNDCurrency")>] 
         vndcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VNDCurrency = Helper.toModelReference<VNDCurrency> vndcurrency "VNDCurrency"  
                let builder (current : ICell) = ((VNDCurrencyModel.Cast _VNDCurrency.cell).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_VNDCurrency.source + ".Format") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _VNDCurrency.cell
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
    [<ExcelFunction(Name="_VNDCurrency_fractionsPerUnit", Description="Create a VNDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VNDCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VNDCurrency",Description = "VNDCurrency")>] 
         vndcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VNDCurrency = Helper.toModelReference<VNDCurrency> vndcurrency "VNDCurrency"  
                let builder (current : ICell) = ((VNDCurrencyModel.Cast _VNDCurrency.cell).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_VNDCurrency.source + ".FractionsPerUnit") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _VNDCurrency.cell
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
    [<ExcelFunction(Name="_VNDCurrency_fractionSymbol", Description="Create a VNDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VNDCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VNDCurrency",Description = "VNDCurrency")>] 
         vndcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VNDCurrency = Helper.toModelReference<VNDCurrency> vndcurrency "VNDCurrency"  
                let builder (current : ICell) = ((VNDCurrencyModel.Cast _VNDCurrency.cell).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_VNDCurrency.source + ".FractionSymbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _VNDCurrency.cell
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
    [<ExcelFunction(Name="_VNDCurrency_name", Description="Create a VNDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VNDCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VNDCurrency",Description = "VNDCurrency")>] 
         vndcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VNDCurrency = Helper.toModelReference<VNDCurrency> vndcurrency "VNDCurrency"  
                let builder (current : ICell) = ((VNDCurrencyModel.Cast _VNDCurrency.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_VNDCurrency.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _VNDCurrency.cell
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
    [<ExcelFunction(Name="_VNDCurrency_numericCode", Description="Create a VNDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VNDCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VNDCurrency",Description = "VNDCurrency")>] 
         vndcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VNDCurrency = Helper.toModelReference<VNDCurrency> vndcurrency "VNDCurrency"  
                let builder (current : ICell) = ((VNDCurrencyModel.Cast _VNDCurrency.cell).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_VNDCurrency.source + ".NumericCode") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _VNDCurrency.cell
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
    [<ExcelFunction(Name="_VNDCurrency_rounding", Description="Create a VNDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VNDCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VNDCurrency",Description = "VNDCurrency")>] 
         vndcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VNDCurrency = Helper.toModelReference<VNDCurrency> vndcurrency "VNDCurrency"  
                let builder (current : ICell) = ((VNDCurrencyModel.Cast _VNDCurrency.cell).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source () = Helper.sourceFold (_VNDCurrency.source + ".Rounding") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _VNDCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<VNDCurrency> format
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
    [<ExcelFunction(Name="_VNDCurrency_symbol", Description="Create a VNDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VNDCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VNDCurrency",Description = "VNDCurrency")>] 
         vndcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VNDCurrency = Helper.toModelReference<VNDCurrency> vndcurrency "VNDCurrency"  
                let builder (current : ICell) = ((VNDCurrencyModel.Cast _VNDCurrency.cell).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_VNDCurrency.source + ".Symbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _VNDCurrency.cell
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
    [<ExcelFunction(Name="_VNDCurrency_ToString", Description="Create a VNDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VNDCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VNDCurrency",Description = "VNDCurrency")>] 
         vndcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VNDCurrency = Helper.toModelReference<VNDCurrency> vndcurrency "VNDCurrency"  
                let builder (current : ICell) = ((VNDCurrencyModel.Cast _VNDCurrency.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_VNDCurrency.source + ".ToString") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _VNDCurrency.cell
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
    [<ExcelFunction(Name="_VNDCurrency_triangulationCurrency", Description="Create a VNDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VNDCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VNDCurrency",Description = "VNDCurrency")>] 
         vndcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VNDCurrency = Helper.toModelReference<VNDCurrency> vndcurrency "VNDCurrency"  
                let builder (current : ICell) = ((VNDCurrencyModel.Cast _VNDCurrency.cell).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_VNDCurrency.source + ".TriangulationCurrency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _VNDCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<VNDCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_VNDCurrency_Range", Description="Create a range of VNDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VNDCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<VNDCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<VNDCurrency> (c)) :> ICell
                let format (i : Cephei.Cell.List<VNDCurrency>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<VNDCurrency>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
