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
module LTLCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_LTLCurrency", Description="Create a LTLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LTLCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.LTLCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LTLCurrency>) l

                let source = Helper.sourceFold "Fun.LTLCurrency" 
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
    [<ExcelFunction(Name="_LTLCurrency_code", Description="Create a LTLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LTLCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LTLCurrency",Description = "Reference to LTLCurrency")>] 
         ltlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LTLCurrency = Helper.toCell<LTLCurrency> ltlcurrency "LTLCurrency" true 
                let builder () = withMnemonic mnemonic ((_LTLCurrency.cell :?> LTLCurrencyModel).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LTLCurrency.source + ".Code") 
                                               [| _LTLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LTLCurrency.cell
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
    [<ExcelFunction(Name="_LTLCurrency_empty", Description="Create a LTLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LTLCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LTLCurrency",Description = "Reference to LTLCurrency")>] 
         ltlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LTLCurrency = Helper.toCell<LTLCurrency> ltlcurrency "LTLCurrency" true 
                let builder () = withMnemonic mnemonic ((_LTLCurrency.cell :?> LTLCurrencyModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LTLCurrency.source + ".Empty") 
                                               [| _LTLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LTLCurrency.cell
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
    [<ExcelFunction(Name="_LTLCurrency_Equals", Description="Create a LTLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LTLCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LTLCurrency",Description = "Reference to LTLCurrency")>] 
         ltlcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LTLCurrency = Helper.toCell<LTLCurrency> ltlcurrency "LTLCurrency" true 
                let _o = Helper.toCell<Object> o "o" true
                let builder () = withMnemonic mnemonic ((_LTLCurrency.cell :?> LTLCurrencyModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LTLCurrency.source + ".Equals") 
                                               [| _LTLCurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LTLCurrency.cell
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
    [<ExcelFunction(Name="_LTLCurrency_format", Description="Create a LTLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LTLCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LTLCurrency",Description = "Reference to LTLCurrency")>] 
         ltlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LTLCurrency = Helper.toCell<LTLCurrency> ltlcurrency "LTLCurrency" true 
                let builder () = withMnemonic mnemonic ((_LTLCurrency.cell :?> LTLCurrencyModel).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LTLCurrency.source + ".Format") 
                                               [| _LTLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LTLCurrency.cell
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
    [<ExcelFunction(Name="_LTLCurrency_fractionsPerUnit", Description="Create a LTLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LTLCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LTLCurrency",Description = "Reference to LTLCurrency")>] 
         ltlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LTLCurrency = Helper.toCell<LTLCurrency> ltlcurrency "LTLCurrency" true 
                let builder () = withMnemonic mnemonic ((_LTLCurrency.cell :?> LTLCurrencyModel).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_LTLCurrency.source + ".FractionsPerUnit") 
                                               [| _LTLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LTLCurrency.cell
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
    [<ExcelFunction(Name="_LTLCurrency_fractionSymbol", Description="Create a LTLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LTLCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LTLCurrency",Description = "Reference to LTLCurrency")>] 
         ltlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LTLCurrency = Helper.toCell<LTLCurrency> ltlcurrency "LTLCurrency" true 
                let builder () = withMnemonic mnemonic ((_LTLCurrency.cell :?> LTLCurrencyModel).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LTLCurrency.source + ".FractionSymbol") 
                                               [| _LTLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LTLCurrency.cell
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
    [<ExcelFunction(Name="_LTLCurrency_name", Description="Create a LTLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LTLCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LTLCurrency",Description = "Reference to LTLCurrency")>] 
         ltlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LTLCurrency = Helper.toCell<LTLCurrency> ltlcurrency "LTLCurrency" true 
                let builder () = withMnemonic mnemonic ((_LTLCurrency.cell :?> LTLCurrencyModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LTLCurrency.source + ".Name") 
                                               [| _LTLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LTLCurrency.cell
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
    [<ExcelFunction(Name="_LTLCurrency_numericCode", Description="Create a LTLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LTLCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LTLCurrency",Description = "Reference to LTLCurrency")>] 
         ltlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LTLCurrency = Helper.toCell<LTLCurrency> ltlcurrency "LTLCurrency" true 
                let builder () = withMnemonic mnemonic ((_LTLCurrency.cell :?> LTLCurrencyModel).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_LTLCurrency.source + ".NumericCode") 
                                               [| _LTLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LTLCurrency.cell
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
    [<ExcelFunction(Name="_LTLCurrency_rounding", Description="Create a LTLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LTLCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LTLCurrency",Description = "Reference to LTLCurrency")>] 
         ltlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LTLCurrency = Helper.toCell<LTLCurrency> ltlcurrency "LTLCurrency" true 
                let builder () = withMnemonic mnemonic ((_LTLCurrency.cell :?> LTLCurrencyModel).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source = Helper.sourceFold (_LTLCurrency.source + ".Rounding") 
                                               [| _LTLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LTLCurrency.cell
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
    [<ExcelFunction(Name="_LTLCurrency_symbol", Description="Create a LTLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LTLCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LTLCurrency",Description = "Reference to LTLCurrency")>] 
         ltlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LTLCurrency = Helper.toCell<LTLCurrency> ltlcurrency "LTLCurrency" true 
                let builder () = withMnemonic mnemonic ((_LTLCurrency.cell :?> LTLCurrencyModel).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LTLCurrency.source + ".Symbol") 
                                               [| _LTLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LTLCurrency.cell
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
    [<ExcelFunction(Name="_LTLCurrency_ToString", Description="Create a LTLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LTLCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LTLCurrency",Description = "Reference to LTLCurrency")>] 
         ltlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LTLCurrency = Helper.toCell<LTLCurrency> ltlcurrency "LTLCurrency" true 
                let builder () = withMnemonic mnemonic ((_LTLCurrency.cell :?> LTLCurrencyModel).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LTLCurrency.source + ".ToString") 
                                               [| _LTLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LTLCurrency.cell
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
    [<ExcelFunction(Name="_LTLCurrency_triangulationCurrency", Description="Create a LTLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LTLCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LTLCurrency",Description = "Reference to LTLCurrency")>] 
         ltlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LTLCurrency = Helper.toCell<LTLCurrency> ltlcurrency "LTLCurrency" true 
                let builder () = withMnemonic mnemonic ((_LTLCurrency.cell :?> LTLCurrencyModel).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_LTLCurrency.source + ".TriangulationCurrency") 
                                               [| _LTLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LTLCurrency.cell
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
    [<ExcelFunction(Name="_LTLCurrency_Range", Description="Create a range of LTLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LTLCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the LTLCurrency")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<LTLCurrency> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<LTLCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<LTLCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<LTLCurrency>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"