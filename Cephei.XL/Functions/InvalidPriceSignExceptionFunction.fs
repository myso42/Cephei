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
(*!! not required 
(* <summary>

  </summary> *)
[<AutoSerializable(true)>]
module InvalidPriceSignExceptionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_InvalidPriceSignException", Description="Create a InvalidPriceSignException",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InvalidPriceSignException_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="message",Description = "string")>] 
         message : obj)
        ([<ExcelArgument(Name="inner",Description = "Exception")>] 
         inner : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _message = Helper.toCell<string> message "message" 
                let _inner = Helper.toCell<Exception> inner "inner" 
                let builder (current : ICell) = (Fun.InvalidPriceSignException 
                                                            _message.cell 
                                                            _inner.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InvalidPriceSignException>) l

                let source () = Helper.sourceFold "Fun.InvalidPriceSignException" 
                                               [| _message.source
                                               ;  _inner.source
                                               |]
                let hash = Helper.hashFold 
                                [| _message.cell
                                ;  _inner.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InvalidPriceSignException> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InvalidPriceSignException1", Description="Create a InvalidPriceSignException",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InvalidPriceSignException_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="message",Description = "string")>] 
         message : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _message = Helper.toCell<string> message "message" 
                let builder (current : ICell) = (Fun.InvalidPriceSignException1 
                                                            _message.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InvalidPriceSignException>) l

                let source () = Helper.sourceFold "Fun.InvalidPriceSignException1" 
                                               [| _message.source
                                               |]
                let hash = Helper.hashFold 
                                [| _message.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InvalidPriceSignException> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InvalidPriceSignException2", Description="Create a InvalidPriceSignException",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InvalidPriceSignException_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = (Fun.InvalidPriceSignException2 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InvalidPriceSignException>) l

                let source () = Helper.sourceFold "Fun.InvalidPriceSignException2" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InvalidPriceSignException> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_InvalidPriceSignException_Range", Description="Create a range of InvalidPriceSignException",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InvalidPriceSignException_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<InvalidPriceSignException> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<InvalidPriceSignException> (c)) :> ICell
                let format (i : Cephei.Cell.List<InvalidPriceSignException>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<InvalidPriceSignException>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
