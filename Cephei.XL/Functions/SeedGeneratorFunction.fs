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
(*!! ommitted 
(* <summary>
  Random number generator used for automatic generation of initialization seeds.
  </summary> *)
[<AutoSerializable(true)>]
module SeedGeneratorFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SeedGenerator_get", Description="Create a SeedGenerator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SeedGenerator_get
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SeedGenerator",Description = "SeedGenerator")>] 
         seedgenerator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SeedGenerator = Helper.toModelReference<SeedGenerator> seedgenerator "SeedGenerator"  
                let builder (current : ICell) = ((SeedGeneratorModel.Cast _SeedGenerator.cell).Get
                                                       ) :> ICell
                let format (o : ulong) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SeedGenerator.source + ".Get") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SeedGenerator.cell
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
    [<ExcelFunction(Name="_SeedGenerator_Range", Description="Create a range of SeedGenerator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SeedGenerator_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SeedGenerator> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<SeedGenerator> (c)) :> ICell
                let format (i : Cephei.Cell.List<SeedGenerator>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<SeedGenerator>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
