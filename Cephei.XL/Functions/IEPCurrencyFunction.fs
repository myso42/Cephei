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
module IEPCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_IEPCurrency", Description="Create a IEPCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IEPCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.IEPCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IEPCurrency>) l

                let source = Helper.sourceFold "Fun.IEPCurrency" 
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
    [<ExcelFunction(Name="_IEPCurrency_code", Description="Create a IEPCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IEPCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IEPCurrency",Description = "Reference to IEPCurrency")>] 
         iepcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IEPCurrency = Helper.toCell<IEPCurrency> iepcurrency "IEPCurrency" true 
                let builder () = withMnemonic mnemonic ((_IEPCurrency.cell :?> IEPCurrencyModel).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IEPCurrency.source + ".Code") 
                                               [| _IEPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IEPCurrency.cell
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
    [<ExcelFunction(Name="_IEPCurrency_empty", Description="Create a IEPCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IEPCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IEPCurrency",Description = "Reference to IEPCurrency")>] 
         iepcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IEPCurrency = Helper.toCell<IEPCurrency> iepcurrency "IEPCurrency" true 
                let builder () = withMnemonic mnemonic ((_IEPCurrency.cell :?> IEPCurrencyModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IEPCurrency.source + ".Empty") 
                                               [| _IEPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IEPCurrency.cell
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
    [<ExcelFunction(Name="_IEPCurrency_Equals", Description="Create a IEPCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IEPCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IEPCurrency",Description = "Reference to IEPCurrency")>] 
         iepcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IEPCurrency = Helper.toCell<IEPCurrency> iepcurrency "IEPCurrency" true 
                let _o = Helper.toCell<Object> o "o" true
                let builder () = withMnemonic mnemonic ((_IEPCurrency.cell :?> IEPCurrencyModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IEPCurrency.source + ".Equals") 
                                               [| _IEPCurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IEPCurrency.cell
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
    [<ExcelFunction(Name="_IEPCurrency_format", Description="Create a IEPCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IEPCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IEPCurrency",Description = "Reference to IEPCurrency")>] 
         iepcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IEPCurrency = Helper.toCell<IEPCurrency> iepcurrency "IEPCurrency" true 
                let builder () = withMnemonic mnemonic ((_IEPCurrency.cell :?> IEPCurrencyModel).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IEPCurrency.source + ".Format") 
                                               [| _IEPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IEPCurrency.cell
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
    [<ExcelFunction(Name="_IEPCurrency_fractionsPerUnit", Description="Create a IEPCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IEPCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IEPCurrency",Description = "Reference to IEPCurrency")>] 
         iepcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IEPCurrency = Helper.toCell<IEPCurrency> iepcurrency "IEPCurrency" true 
                let builder () = withMnemonic mnemonic ((_IEPCurrency.cell :?> IEPCurrencyModel).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_IEPCurrency.source + ".FractionsPerUnit") 
                                               [| _IEPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IEPCurrency.cell
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
    [<ExcelFunction(Name="_IEPCurrency_fractionSymbol", Description="Create a IEPCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IEPCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IEPCurrency",Description = "Reference to IEPCurrency")>] 
         iepcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IEPCurrency = Helper.toCell<IEPCurrency> iepcurrency "IEPCurrency" true 
                let builder () = withMnemonic mnemonic ((_IEPCurrency.cell :?> IEPCurrencyModel).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IEPCurrency.source + ".FractionSymbol") 
                                               [| _IEPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IEPCurrency.cell
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
    [<ExcelFunction(Name="_IEPCurrency_name", Description="Create a IEPCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IEPCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IEPCurrency",Description = "Reference to IEPCurrency")>] 
         iepcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IEPCurrency = Helper.toCell<IEPCurrency> iepcurrency "IEPCurrency" true 
                let builder () = withMnemonic mnemonic ((_IEPCurrency.cell :?> IEPCurrencyModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IEPCurrency.source + ".Name") 
                                               [| _IEPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IEPCurrency.cell
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
    [<ExcelFunction(Name="_IEPCurrency_numericCode", Description="Create a IEPCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IEPCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IEPCurrency",Description = "Reference to IEPCurrency")>] 
         iepcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IEPCurrency = Helper.toCell<IEPCurrency> iepcurrency "IEPCurrency" true 
                let builder () = withMnemonic mnemonic ((_IEPCurrency.cell :?> IEPCurrencyModel).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_IEPCurrency.source + ".NumericCode") 
                                               [| _IEPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IEPCurrency.cell
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
    [<ExcelFunction(Name="_IEPCurrency_rounding", Description="Create a IEPCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IEPCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IEPCurrency",Description = "Reference to IEPCurrency")>] 
         iepcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IEPCurrency = Helper.toCell<IEPCurrency> iepcurrency "IEPCurrency" true 
                let builder () = withMnemonic mnemonic ((_IEPCurrency.cell :?> IEPCurrencyModel).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source = Helper.sourceFold (_IEPCurrency.source + ".Rounding") 
                                               [| _IEPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IEPCurrency.cell
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
    [<ExcelFunction(Name="_IEPCurrency_symbol", Description="Create a IEPCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IEPCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IEPCurrency",Description = "Reference to IEPCurrency")>] 
         iepcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IEPCurrency = Helper.toCell<IEPCurrency> iepcurrency "IEPCurrency" true 
                let builder () = withMnemonic mnemonic ((_IEPCurrency.cell :?> IEPCurrencyModel).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IEPCurrency.source + ".Symbol") 
                                               [| _IEPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IEPCurrency.cell
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
    [<ExcelFunction(Name="_IEPCurrency_ToString", Description="Create a IEPCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IEPCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IEPCurrency",Description = "Reference to IEPCurrency")>] 
         iepcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IEPCurrency = Helper.toCell<IEPCurrency> iepcurrency "IEPCurrency" true 
                let builder () = withMnemonic mnemonic ((_IEPCurrency.cell :?> IEPCurrencyModel).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IEPCurrency.source + ".ToString") 
                                               [| _IEPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IEPCurrency.cell
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
    [<ExcelFunction(Name="_IEPCurrency_triangulationCurrency", Description="Create a IEPCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IEPCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IEPCurrency",Description = "Reference to IEPCurrency")>] 
         iepcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IEPCurrency = Helper.toCell<IEPCurrency> iepcurrency "IEPCurrency" true 
                let builder () = withMnemonic mnemonic ((_IEPCurrency.cell :?> IEPCurrencyModel).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_IEPCurrency.source + ".TriangulationCurrency") 
                                               [| _IEPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IEPCurrency.cell
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
    [<ExcelFunction(Name="_IEPCurrency_Range", Description="Create a range of IEPCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IEPCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the IEPCurrency")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<IEPCurrency> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<IEPCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<IEPCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<IEPCurrency>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"