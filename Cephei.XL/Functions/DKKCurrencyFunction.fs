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

(* <summary>

  </summary> *)
[<AutoSerializable(true)>]
module DKKCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_DKKCurrency", Description="Create a DKKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DKKCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.DKKCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DKKCurrency>) l

                let source = Helper.sourceFold "Fun.DKKCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
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
        ! currency name, e.g, "U.S. Dollar"
    *)
    [<ExcelFunction(Name="_DKKCurrency_code", Description="Create a DKKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DKKCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DKKCurrency",Description = "Reference to DKKCurrency")>] 
         dkkcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DKKCurrency = Helper.toCell<DKKCurrency> dkkcurrency "DKKCurrency" true 
                let builder () = withMnemonic mnemonic ((_DKKCurrency.cell :?> DKKCurrencyModel).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DKKCurrency.source + ".Code") 
                                               [| _DKKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DKKCurrency.cell
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
        ! Other information ! is this a usable instance?
    *)
    [<ExcelFunction(Name="_DKKCurrency_empty", Description="Create a DKKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DKKCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DKKCurrency",Description = "Reference to DKKCurrency")>] 
         dkkcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DKKCurrency = Helper.toCell<DKKCurrency> dkkcurrency "DKKCurrency" true 
                let builder () = withMnemonic mnemonic ((_DKKCurrency.cell :?> DKKCurrencyModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DKKCurrency.source + ".Empty") 
                                               [| _DKKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DKKCurrency.cell
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
        
    *)
    [<ExcelFunction(Name="_DKKCurrency_Equals", Description="Create a DKKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DKKCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DKKCurrency",Description = "Reference to DKKCurrency")>] 
         dkkcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DKKCurrency = Helper.toCell<DKKCurrency> dkkcurrency "DKKCurrency" true 
                let _o = Helper.toCell<Object> o "o" true
                let builder () = withMnemonic mnemonic ((_DKKCurrency.cell :?> DKKCurrencyModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DKKCurrency.source + ".Equals") 
                                               [| _DKKCurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DKKCurrency.cell
                                ;  _o.cell
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
        ! currency used for triangulated exchange when required output format The format will be fed three positional parameters, namely, value, code, and symbol, in this order.
    *)
    [<ExcelFunction(Name="_DKKCurrency_format", Description="Create a DKKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DKKCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DKKCurrency",Description = "Reference to DKKCurrency")>] 
         dkkcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DKKCurrency = Helper.toCell<DKKCurrency> dkkcurrency "DKKCurrency" true 
                let builder () = withMnemonic mnemonic ((_DKKCurrency.cell :?> DKKCurrencyModel).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DKKCurrency.source + ".Format") 
                                               [| _DKKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DKKCurrency.cell
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
        ! fraction symbol, e.g, "Â¢"
    *)
    [<ExcelFunction(Name="_DKKCurrency_fractionsPerUnit", Description="Create a DKKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DKKCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DKKCurrency",Description = "Reference to DKKCurrency")>] 
         dkkcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DKKCurrency = Helper.toCell<DKKCurrency> dkkcurrency "DKKCurrency" true 
                let builder () = withMnemonic mnemonic ((_DKKCurrency.cell :?> DKKCurrencyModel).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_DKKCurrency.source + ".FractionsPerUnit") 
                                               [| _DKKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DKKCurrency.cell
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
        ! symbol, e.g, "$"
    *)
    [<ExcelFunction(Name="_DKKCurrency_fractionSymbol", Description="Create a DKKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DKKCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DKKCurrency",Description = "Reference to DKKCurrency")>] 
         dkkcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DKKCurrency = Helper.toCell<DKKCurrency> dkkcurrency "DKKCurrency" true 
                let builder () = withMnemonic mnemonic ((_DKKCurrency.cell :?> DKKCurrencyModel).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DKKCurrency.source + ".FractionSymbol") 
                                               [| _DKKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DKKCurrency.cell
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
        Inspectors
    *)
    [<ExcelFunction(Name="_DKKCurrency_name", Description="Create a DKKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DKKCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DKKCurrency",Description = "Reference to DKKCurrency")>] 
         dkkcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DKKCurrency = Helper.toCell<DKKCurrency> dkkcurrency "DKKCurrency" true 
                let builder () = withMnemonic mnemonic ((_DKKCurrency.cell :?> DKKCurrencyModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DKKCurrency.source + ".Name") 
                                               [| _DKKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DKKCurrency.cell
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
        ! ISO 4217 three-letter code, e.g, "USD"
    *)
    [<ExcelFunction(Name="_DKKCurrency_numericCode", Description="Create a DKKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DKKCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DKKCurrency",Description = "Reference to DKKCurrency")>] 
         dkkcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DKKCurrency = Helper.toCell<DKKCurrency> dkkcurrency "DKKCurrency" true 
                let builder () = withMnemonic mnemonic ((_DKKCurrency.cell :?> DKKCurrencyModel).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_DKKCurrency.source + ".NumericCode") 
                                               [| _DKKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DKKCurrency.cell
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
        ! number of fractionary parts in a unit, e.g, 100
    *)
    [<ExcelFunction(Name="_DKKCurrency_rounding", Description="Create a DKKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DKKCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DKKCurrency",Description = "Reference to DKKCurrency")>] 
         dkkcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DKKCurrency = Helper.toCell<DKKCurrency> dkkcurrency "DKKCurrency" true 
                let builder () = withMnemonic mnemonic ((_DKKCurrency.cell :?> DKKCurrencyModel).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source = Helper.sourceFold (_DKKCurrency.source + ".Rounding") 
                                               [| _DKKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DKKCurrency.cell
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
        ! ISO 4217 numeric code, e.g, "840"
    *)
    [<ExcelFunction(Name="_DKKCurrency_symbol", Description="Create a DKKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DKKCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DKKCurrency",Description = "Reference to DKKCurrency")>] 
         dkkcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DKKCurrency = Helper.toCell<DKKCurrency> dkkcurrency "DKKCurrency" true 
                let builder () = withMnemonic mnemonic ((_DKKCurrency.cell :?> DKKCurrencyModel).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DKKCurrency.source + ".Symbol") 
                                               [| _DKKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DKKCurrency.cell
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
        
    *)
    [<ExcelFunction(Name="_DKKCurrency_ToString", Description="Create a DKKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DKKCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DKKCurrency",Description = "Reference to DKKCurrency")>] 
         dkkcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DKKCurrency = Helper.toCell<DKKCurrency> dkkcurrency "DKKCurrency" true 
                let builder () = withMnemonic mnemonic ((_DKKCurrency.cell :?> DKKCurrencyModel).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DKKCurrency.source + ".ToString") 
                                               [| _DKKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DKKCurrency.cell
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
        ! rounding convention
    *)
    [<ExcelFunction(Name="_DKKCurrency_triangulationCurrency", Description="Create a DKKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DKKCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DKKCurrency",Description = "Reference to DKKCurrency")>] 
         dkkcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DKKCurrency = Helper.toCell<DKKCurrency> dkkcurrency "DKKCurrency" true 
                let builder () = withMnemonic mnemonic ((_DKKCurrency.cell :?> DKKCurrencyModel).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_DKKCurrency.source + ".TriangulationCurrency") 
                                               [| _DKKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DKKCurrency.cell
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
    [<ExcelFunction(Name="_DKKCurrency_Range", Description="Create a range of DKKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DKKCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the DKKCurrency")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DKKCurrency> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<DKKCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<DKKCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<DKKCurrency>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"