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
module ChiSquareDistributionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ChiSquareDistribution", Description="Create a ChiSquareDistribution",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ChiSquareDistribution_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="df",Description = "double")>] 
         df : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _df = Helper.toCell<double> df "df" 
                let builder (current : ICell) = (Fun.ChiSquareDistribution 
                                                            _df.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ChiSquareDistribution>) l

                let source () = Helper.sourceFold "Fun.ChiSquareDistribution" 
                                               [| _df.source
                                               |]
                let hash = Helper.hashFold 
                                [| _df.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ChiSquareDistribution> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ChiSquareDistribution_value", Description="Create a ChiSquareDistribution",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ChiSquareDistribution_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChiSquareDistribution",Description = "ChiSquareDistribution")>] 
         chisquaredistribution : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChiSquareDistribution = Helper.toModelReference<ChiSquareDistribution> chisquaredistribution "ChiSquareDistribution"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = ((ChiSquareDistributionModel.Cast _ChiSquareDistribution.cell).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ChiSquareDistribution.source + ".Value") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ChiSquareDistribution.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_ChiSquareDistribution_Range", Description="Create a range of ChiSquareDistribution",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ChiSquareDistribution_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ChiSquareDistribution> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<ChiSquareDistribution> (c)) :> ICell
                let format (i : Cephei.Cell.List<ChiSquareDistribution>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<ChiSquareDistribution>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
