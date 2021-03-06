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
  RendistatoCalculator equivalent swap lenth Quote adapter
  </summary> *)
[<AutoSerializable(true)>]
module RendistatoEquivalentSwapLengthQuoteFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_RendistatoEquivalentSwapLengthQuote_isValid", Description="Create a RendistatoEquivalentSwapLengthQuote",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RendistatoEquivalentSwapLengthQuote_isValid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RendistatoEquivalentSwapLengthQuote",Description = "RendistatoEquivalentSwapLengthQuote")>] 
         rendistatoequivalentswaplengthquote : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RendistatoEquivalentSwapLengthQuote = Helper.toModelReference<RendistatoEquivalentSwapLengthQuote> rendistatoequivalentswaplengthquote "RendistatoEquivalentSwapLengthQuote"  
                let builder (current : ICell) = ((RendistatoEquivalentSwapLengthQuoteModel.Cast _RendistatoEquivalentSwapLengthQuote.cell).IsValid
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_RendistatoEquivalentSwapLengthQuote.source + ".IsValid") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _RendistatoEquivalentSwapLengthQuote.cell
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
    [<ExcelFunction(Name="_RendistatoEquivalentSwapLengthQuote", Description="Create a RendistatoEquivalentSwapLengthQuote",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RendistatoEquivalentSwapLengthQuote_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="r",Description = "RendistatoCalculator")>] 
         r : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _r = Helper.toCell<RendistatoCalculator> r "r" 
                let builder (current : ICell) = (Fun.RendistatoEquivalentSwapLengthQuote 
                                                            _r.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RendistatoEquivalentSwapLengthQuote>) l

                let source () = Helper.sourceFold "Fun.RendistatoEquivalentSwapLengthQuote" 
                                               [| _r.source
                                               |]
                let hash = Helper.hashFold 
                                [| _r.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<RendistatoEquivalentSwapLengthQuote> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_RendistatoEquivalentSwapLengthQuote_value", Description="Create a RendistatoEquivalentSwapLengthQuote",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RendistatoEquivalentSwapLengthQuote_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RendistatoEquivalentSwapLengthQuote",Description = "RendistatoEquivalentSwapLengthQuote")>] 
         rendistatoequivalentswaplengthquote : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RendistatoEquivalentSwapLengthQuote = Helper.toModelReference<RendistatoEquivalentSwapLengthQuote> rendistatoequivalentswaplengthquote "RendistatoEquivalentSwapLengthQuote"  
                let builder (current : ICell) = ((RendistatoEquivalentSwapLengthQuoteModel.Cast _RendistatoEquivalentSwapLengthQuote.cell).Value
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RendistatoEquivalentSwapLengthQuote.source + ".Value") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _RendistatoEquivalentSwapLengthQuote.cell
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
    [<ExcelFunction(Name="_RendistatoEquivalentSwapLengthQuote_registerWith", Description="Create a RendistatoEquivalentSwapLengthQuote",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RendistatoEquivalentSwapLengthQuote_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RendistatoEquivalentSwapLengthQuote",Description = "RendistatoEquivalentSwapLengthQuote")>] 
         rendistatoequivalentswaplengthquote : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RendistatoEquivalentSwapLengthQuote = Helper.toModelReference<RendistatoEquivalentSwapLengthQuote> rendistatoequivalentswaplengthquote "RendistatoEquivalentSwapLengthQuote"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((RendistatoEquivalentSwapLengthQuoteModel.Cast _RendistatoEquivalentSwapLengthQuote.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : RendistatoEquivalentSwapLengthQuote) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_RendistatoEquivalentSwapLengthQuote.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RendistatoEquivalentSwapLengthQuote.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_RendistatoEquivalentSwapLengthQuote_unregisterWith", Description="Create a RendistatoEquivalentSwapLengthQuote",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RendistatoEquivalentSwapLengthQuote_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RendistatoEquivalentSwapLengthQuote",Description = "RendistatoEquivalentSwapLengthQuote")>] 
         rendistatoequivalentswaplengthquote : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RendistatoEquivalentSwapLengthQuote = Helper.toModelReference<RendistatoEquivalentSwapLengthQuote> rendistatoequivalentswaplengthquote "RendistatoEquivalentSwapLengthQuote"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((RendistatoEquivalentSwapLengthQuoteModel.Cast _RendistatoEquivalentSwapLengthQuote.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : RendistatoEquivalentSwapLengthQuote) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_RendistatoEquivalentSwapLengthQuote.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RendistatoEquivalentSwapLengthQuote.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_RendistatoEquivalentSwapLengthQuote_Range", Description="Create a range of RendistatoEquivalentSwapLengthQuote",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RendistatoEquivalentSwapLengthQuote_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<RendistatoEquivalentSwapLengthQuote> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<RendistatoEquivalentSwapLengthQuote> (c)) :> ICell
                let format (i : Cephei.Cell.List<RendistatoEquivalentSwapLengthQuote>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<RendistatoEquivalentSwapLengthQuote>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
