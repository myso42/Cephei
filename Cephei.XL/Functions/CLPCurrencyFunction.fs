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
  Chilean peso   The ISO three-letter code is CLP; the numeric code is 152. It is divided in 100 centavos.  currencies
  </summary> *)
[<AutoSerializable(true)>]
module CLPCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_CLPCurrency", Description="Create a CLPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CLPCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = (Fun.CLPCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CLPCurrency>) l

                let source () = Helper.sourceFold "Fun.CLPCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CLPCurrency> format
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
    [<ExcelFunction(Name="_CLPCurrency_code", Description="Create a CLPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CLPCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CLPCurrency",Description = "CLPCurrency")>] 
         clpcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CLPCurrency = Helper.toModelReference<CLPCurrency> clpcurrency "CLPCurrency"  
                let builder (current : ICell) = ((CLPCurrencyModel.Cast _CLPCurrency.cell).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CLPCurrency.source + ".Code") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CLPCurrency.cell
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
    [<ExcelFunction(Name="_CLPCurrency_empty", Description="Create a CLPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CLPCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CLPCurrency",Description = "CLPCurrency")>] 
         clpcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CLPCurrency = Helper.toModelReference<CLPCurrency> clpcurrency "CLPCurrency"  
                let builder (current : ICell) = ((CLPCurrencyModel.Cast _CLPCurrency.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CLPCurrency.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CLPCurrency.cell
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
    [<ExcelFunction(Name="_CLPCurrency_Equals", Description="Create a CLPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CLPCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CLPCurrency",Description = "CLPCurrency")>] 
         clpcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CLPCurrency = Helper.toModelReference<CLPCurrency> clpcurrency "CLPCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = ((CLPCurrencyModel.Cast _CLPCurrency.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CLPCurrency.source + ".Equals") 

                                               [| _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CLPCurrency.cell
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
    [<ExcelFunction(Name="_CLPCurrency_format", Description="Create a CLPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CLPCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CLPCurrency",Description = "CLPCurrency")>] 
         clpcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CLPCurrency = Helper.toModelReference<CLPCurrency> clpcurrency "CLPCurrency"  
                let builder (current : ICell) = ((CLPCurrencyModel.Cast _CLPCurrency.cell).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CLPCurrency.source + ".Format") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CLPCurrency.cell
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
    [<ExcelFunction(Name="_CLPCurrency_fractionsPerUnit", Description="Create a CLPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CLPCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CLPCurrency",Description = "CLPCurrency")>] 
         clpcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CLPCurrency = Helper.toModelReference<CLPCurrency> clpcurrency "CLPCurrency"  
                let builder (current : ICell) = ((CLPCurrencyModel.Cast _CLPCurrency.cell).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CLPCurrency.source + ".FractionsPerUnit") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CLPCurrency.cell
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
    [<ExcelFunction(Name="_CLPCurrency_fractionSymbol", Description="Create a CLPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CLPCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CLPCurrency",Description = "CLPCurrency")>] 
         clpcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CLPCurrency = Helper.toModelReference<CLPCurrency> clpcurrency "CLPCurrency"  
                let builder (current : ICell) = ((CLPCurrencyModel.Cast _CLPCurrency.cell).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CLPCurrency.source + ".FractionSymbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CLPCurrency.cell
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
    [<ExcelFunction(Name="_CLPCurrency_name", Description="Create a CLPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CLPCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CLPCurrency",Description = "CLPCurrency")>] 
         clpcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CLPCurrency = Helper.toModelReference<CLPCurrency> clpcurrency "CLPCurrency"  
                let builder (current : ICell) = ((CLPCurrencyModel.Cast _CLPCurrency.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CLPCurrency.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CLPCurrency.cell
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
    [<ExcelFunction(Name="_CLPCurrency_numericCode", Description="Create a CLPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CLPCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CLPCurrency",Description = "CLPCurrency")>] 
         clpcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CLPCurrency = Helper.toModelReference<CLPCurrency> clpcurrency "CLPCurrency"  
                let builder (current : ICell) = ((CLPCurrencyModel.Cast _CLPCurrency.cell).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CLPCurrency.source + ".NumericCode") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CLPCurrency.cell
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
    [<ExcelFunction(Name="_CLPCurrency_rounding", Description="Create a CLPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CLPCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CLPCurrency",Description = "CLPCurrency")>] 
         clpcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CLPCurrency = Helper.toModelReference<CLPCurrency> clpcurrency "CLPCurrency"  
                let builder (current : ICell) = ((CLPCurrencyModel.Cast _CLPCurrency.cell).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source () = Helper.sourceFold (_CLPCurrency.source + ".Rounding") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CLPCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CLPCurrency> format
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
    [<ExcelFunction(Name="_CLPCurrency_symbol", Description="Create a CLPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CLPCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CLPCurrency",Description = "CLPCurrency")>] 
         clpcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CLPCurrency = Helper.toModelReference<CLPCurrency> clpcurrency "CLPCurrency"  
                let builder (current : ICell) = ((CLPCurrencyModel.Cast _CLPCurrency.cell).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CLPCurrency.source + ".Symbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CLPCurrency.cell
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
    [<ExcelFunction(Name="_CLPCurrency_ToString", Description="Create a CLPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CLPCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CLPCurrency",Description = "CLPCurrency")>] 
         clpcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CLPCurrency = Helper.toModelReference<CLPCurrency> clpcurrency "CLPCurrency"  
                let builder (current : ICell) = ((CLPCurrencyModel.Cast _CLPCurrency.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CLPCurrency.source + ".ToString") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CLPCurrency.cell
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
    [<ExcelFunction(Name="_CLPCurrency_triangulationCurrency", Description="Create a CLPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CLPCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CLPCurrency",Description = "CLPCurrency")>] 
         clpcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CLPCurrency = Helper.toModelReference<CLPCurrency> clpcurrency "CLPCurrency"  
                let builder (current : ICell) = ((CLPCurrencyModel.Cast _CLPCurrency.cell).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_CLPCurrency.source + ".TriangulationCurrency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CLPCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CLPCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_CLPCurrency_Range", Description="Create a range of CLPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CLPCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CLPCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<CLPCurrency> (c)) :> ICell
                let format (i : Cephei.Cell.List<CLPCurrency>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<CLPCurrency>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
