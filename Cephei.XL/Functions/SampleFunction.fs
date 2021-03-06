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
(*!! generic
(* <summary>
todo check for Sample for value types and Sample for obj types to take care of proper obj copying
  </summary> *)
[<AutoSerializable(true)>]
module SampleFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Sample", Description="Create a Sample",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sample_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="value_",Description = "'T")>] 
         value_ : obj)
        ([<ExcelArgument(Name="weight_",Description = "double")>] 
         weight_ : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _value_ = Helper.toCell<'T> value_ "value_" 
                let _weight_ = Helper.toCell<double> weight_ "weight_" 
                let builder (current : ICell) = (Fun.Sample 
                                                            _value_.cell 
                                                            _weight_.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Sample>) l

                let source () = Helper.sourceFold "Fun.Sample" 
                                               [| _value_.source
                                               ;  _weight_.source
                                               |]
                let hash = Helper.hashFold 
                                [| _value_.cell
                                ;  _weight_.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Sample> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Sample_value", Description="Create a Sample",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sample_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sample",Description = "Sample")>] 
         sample : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Sample = Helper.toModelReference<Sample> sample "Sample"  
                let builder (current : ICell) = ((SampleModel.Cast _Sample.cell).Value
                                                       ) :> ICell
                let format (o : T) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Sample.source + ".Value") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Sample.cell
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
    [<ExcelFunction(Name="_Sample_weight", Description="Create a Sample",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sample_weight
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sample",Description = "Sample")>] 
         sample : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Sample = Helper.toModelReference<Sample> sample "Sample"  
                let builder (current : ICell) = ((SampleModel.Cast _Sample.cell).Weight
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Sample.source + ".Weight") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Sample.cell
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
    [<ExcelFunction(Name="_Sample_Range", Description="Create a range of Sample",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sample_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Sample> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<Sample> (c)) :> ICell
                let format (i : Cephei.Cell.List<Sample>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<Sample>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
