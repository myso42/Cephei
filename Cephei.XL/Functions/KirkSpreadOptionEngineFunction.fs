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
module KirkSpreadOptionEngineFunction =


    (*
        
    *)
    [<ExcelFunction(Name="_KirkSpreadOptionEngine", Description="Create a KirkSpreadOptionEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KirkSpreadOptionEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="process1",Description = "BlackProcess")>] 
         process1 : obj)
        ([<ExcelArgument(Name="process2",Description = "BlackProcess")>] 
         process2 : obj)
        ([<ExcelArgument(Name="correlation",Description = "Quote")>] 
         correlation : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _process1 = Helper.toCell<BlackProcess> process1 "process1" 
                let _process2 = Helper.toCell<BlackProcess> process2 "process2" 
                let _correlation = Helper.toHandle<Quote> correlation "correlation" 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = (Fun.KirkSpreadOptionEngine 
                                                            _process1.cell 
                                                            _process2.cell 
                                                            _correlation.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<KirkSpreadOptionEngine>) l

                let source () = Helper.sourceFold "Fun.KirkSpreadOptionEngine" 
                                               [| _process1.source
                                               ;  _process2.source
                                               ;  _correlation.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _process1.cell
                                ;  _process2.cell
                                ;  _correlation.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<KirkSpreadOptionEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_KirkSpreadOptionEngine_Range", Description="Create a range of KirkSpreadOptionEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KirkSpreadOptionEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<KirkSpreadOptionEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<KirkSpreadOptionEngine> (c)) :> ICell
                let format (i : Cephei.Cell.List<KirkSpreadOptionEngine>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<KirkSpreadOptionEngine>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
