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
module ROLCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ROLCurrency", Description="Create a ROLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ROLCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.ROLCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ROLCurrency>) l

                let source = Helper.sourceFold "Fun.ROLCurrency" 
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
    [<ExcelFunction(Name="_ROLCurrency_code", Description="Create a ROLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ROLCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ROLCurrency",Description = "Reference to ROLCurrency")>] 
         rolcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ROLCurrency = Helper.toCell<ROLCurrency> rolcurrency "ROLCurrency" true 
                let builder () = withMnemonic mnemonic ((_ROLCurrency.cell :?> ROLCurrencyModel).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ROLCurrency.source + ".Code") 
                                               [| _ROLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ROLCurrency.cell
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
    [<ExcelFunction(Name="_ROLCurrency_empty", Description="Create a ROLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ROLCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ROLCurrency",Description = "Reference to ROLCurrency")>] 
         rolcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ROLCurrency = Helper.toCell<ROLCurrency> rolcurrency "ROLCurrency" true 
                let builder () = withMnemonic mnemonic ((_ROLCurrency.cell :?> ROLCurrencyModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ROLCurrency.source + ".Empty") 
                                               [| _ROLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ROLCurrency.cell
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
    [<ExcelFunction(Name="_ROLCurrency_Equals", Description="Create a ROLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ROLCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ROLCurrency",Description = "Reference to ROLCurrency")>] 
         rolcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ROLCurrency = Helper.toCell<ROLCurrency> rolcurrency "ROLCurrency" true 
                let _o = Helper.toCell<Object> o "o" true
                let builder () = withMnemonic mnemonic ((_ROLCurrency.cell :?> ROLCurrencyModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ROLCurrency.source + ".Equals") 
                                               [| _ROLCurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ROLCurrency.cell
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
    [<ExcelFunction(Name="_ROLCurrency_format", Description="Create a ROLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ROLCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ROLCurrency",Description = "Reference to ROLCurrency")>] 
         rolcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ROLCurrency = Helper.toCell<ROLCurrency> rolcurrency "ROLCurrency" true 
                let builder () = withMnemonic mnemonic ((_ROLCurrency.cell :?> ROLCurrencyModel).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ROLCurrency.source + ".Format") 
                                               [| _ROLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ROLCurrency.cell
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
    [<ExcelFunction(Name="_ROLCurrency_fractionsPerUnit", Description="Create a ROLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ROLCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ROLCurrency",Description = "Reference to ROLCurrency")>] 
         rolcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ROLCurrency = Helper.toCell<ROLCurrency> rolcurrency "ROLCurrency" true 
                let builder () = withMnemonic mnemonic ((_ROLCurrency.cell :?> ROLCurrencyModel).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_ROLCurrency.source + ".FractionsPerUnit") 
                                               [| _ROLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ROLCurrency.cell
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
    [<ExcelFunction(Name="_ROLCurrency_fractionSymbol", Description="Create a ROLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ROLCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ROLCurrency",Description = "Reference to ROLCurrency")>] 
         rolcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ROLCurrency = Helper.toCell<ROLCurrency> rolcurrency "ROLCurrency" true 
                let builder () = withMnemonic mnemonic ((_ROLCurrency.cell :?> ROLCurrencyModel).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ROLCurrency.source + ".FractionSymbol") 
                                               [| _ROLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ROLCurrency.cell
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
    [<ExcelFunction(Name="_ROLCurrency_name", Description="Create a ROLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ROLCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ROLCurrency",Description = "Reference to ROLCurrency")>] 
         rolcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ROLCurrency = Helper.toCell<ROLCurrency> rolcurrency "ROLCurrency" true 
                let builder () = withMnemonic mnemonic ((_ROLCurrency.cell :?> ROLCurrencyModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ROLCurrency.source + ".Name") 
                                               [| _ROLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ROLCurrency.cell
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
    [<ExcelFunction(Name="_ROLCurrency_numericCode", Description="Create a ROLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ROLCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ROLCurrency",Description = "Reference to ROLCurrency")>] 
         rolcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ROLCurrency = Helper.toCell<ROLCurrency> rolcurrency "ROLCurrency" true 
                let builder () = withMnemonic mnemonic ((_ROLCurrency.cell :?> ROLCurrencyModel).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_ROLCurrency.source + ".NumericCode") 
                                               [| _ROLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ROLCurrency.cell
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
    [<ExcelFunction(Name="_ROLCurrency_rounding", Description="Create a ROLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ROLCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ROLCurrency",Description = "Reference to ROLCurrency")>] 
         rolcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ROLCurrency = Helper.toCell<ROLCurrency> rolcurrency "ROLCurrency" true 
                let builder () = withMnemonic mnemonic ((_ROLCurrency.cell :?> ROLCurrencyModel).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source = Helper.sourceFold (_ROLCurrency.source + ".Rounding") 
                                               [| _ROLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ROLCurrency.cell
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
    [<ExcelFunction(Name="_ROLCurrency_symbol", Description="Create a ROLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ROLCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ROLCurrency",Description = "Reference to ROLCurrency")>] 
         rolcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ROLCurrency = Helper.toCell<ROLCurrency> rolcurrency "ROLCurrency" true 
                let builder () = withMnemonic mnemonic ((_ROLCurrency.cell :?> ROLCurrencyModel).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ROLCurrency.source + ".Symbol") 
                                               [| _ROLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ROLCurrency.cell
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
    [<ExcelFunction(Name="_ROLCurrency_ToString", Description="Create a ROLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ROLCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ROLCurrency",Description = "Reference to ROLCurrency")>] 
         rolcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ROLCurrency = Helper.toCell<ROLCurrency> rolcurrency "ROLCurrency" true 
                let builder () = withMnemonic mnemonic ((_ROLCurrency.cell :?> ROLCurrencyModel).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ROLCurrency.source + ".ToString") 
                                               [| _ROLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ROLCurrency.cell
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
    [<ExcelFunction(Name="_ROLCurrency_triangulationCurrency", Description="Create a ROLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ROLCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ROLCurrency",Description = "Reference to ROLCurrency")>] 
         rolcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ROLCurrency = Helper.toCell<ROLCurrency> rolcurrency "ROLCurrency" true 
                let builder () = withMnemonic mnemonic ((_ROLCurrency.cell :?> ROLCurrencyModel).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_ROLCurrency.source + ".TriangulationCurrency") 
                                               [| _ROLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ROLCurrency.cell
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
    [<ExcelFunction(Name="_ROLCurrency_Range", Description="Create a range of ROLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ROLCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the ROLCurrency")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ROLCurrency> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ROLCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<ROLCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<ROLCurrency>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"