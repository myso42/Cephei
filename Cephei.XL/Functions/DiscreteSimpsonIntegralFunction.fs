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
module DiscreteSimpsonIntegralFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_DiscreteSimpsonIntegral_value", Description="Create a DiscreteSimpsonIntegral",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscreteSimpsonIntegral_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscreteSimpsonIntegral",Description = "DiscreteSimpsonIntegral")>] 
         discretesimpsonintegral : obj)
        ([<ExcelArgument(Name="x",Description = "Vector")>] 
         x : obj)
        ([<ExcelArgument(Name="f",Description = "Vector")>] 
         f : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscreteSimpsonIntegral = Helper.toModelReference<DiscreteSimpsonIntegral> discretesimpsonintegral "DiscreteSimpsonIntegral"  
                let _x = Helper.toCell<Vector> x "x" 
                let _f = Helper.toCell<Vector> f "f" 
                let builder (current : ICell) = ((DiscreteSimpsonIntegralModel.Cast _DiscreteSimpsonIntegral.cell).Value
                                                            _x.cell 
                                                            _f.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DiscreteSimpsonIntegral.source + ".Value") 

                                               [| _x.source
                                               ;  _f.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscreteSimpsonIntegral.cell
                                ;  _x.cell
                                ;  _f.cell
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
    [<ExcelFunction(Name="_DiscreteSimpsonIntegral_Range", Description="Create a range of DiscreteSimpsonIntegral",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscreteSimpsonIntegral_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DiscreteSimpsonIntegral> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<DiscreteSimpsonIntegral> (c)) :> ICell
                let format (i : Cephei.Cell.List<DiscreteSimpsonIntegral>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<DiscreteSimpsonIntegral>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
