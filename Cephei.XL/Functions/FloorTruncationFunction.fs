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
module FloorTruncationFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FloorTruncation", Description="Create a FloorTruncation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloorTruncation_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="precision",Description = "Reference to precision")>] 
         precision : obj)
        ([<ExcelArgument(Name="digit",Description = "Reference to digit")>] 
         digit : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _precision = Helper.toCell<int> precision "precision" true
                let _digit = Helper.toCell<int> digit "digit" true
                let builder () = withMnemonic mnemonic (Fun.FloorTruncation 
                                                            _precision.cell 
                                                            _digit.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloorTruncation>) l

                let source = Helper.sourceFold "Fun.FloorTruncation" 
                                               [| _precision.source
                                               ;  _digit.source
                                               |]
                let hash = Helper.hashFold 
                                [| _precision.cell
                                ;  _digit.cell
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
        
    *)
    [<ExcelFunction(Name="_FloorTruncation1", Description="Create a FloorTruncation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloorTruncation_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="precision",Description = "Reference to precision")>] 
         precision : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _precision = Helper.toCell<int> precision "precision" true
                let builder () = withMnemonic mnemonic (Fun.FloorTruncation1 
                                                            _precision.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloorTruncation>) l

                let source = Helper.sourceFold "Fun.FloorTruncation1" 
                                               [| _precision.source
                                               |]
                let hash = Helper.hashFold 
                                [| _precision.cell
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
        
    *)
    [<ExcelFunction(Name="_FloorTruncation_Digit", Description="Create a FloorTruncation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloorTruncation_Digit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloorTruncation",Description = "Reference to FloorTruncation")>] 
         floortruncation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloorTruncation = Helper.toCell<FloorTruncation> floortruncation "FloorTruncation" true 
                let builder () = withMnemonic mnemonic ((_FloorTruncation.cell :?> FloorTruncationModel).Digit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloorTruncation.source + ".Digit") 
                                               [| _FloorTruncation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloorTruncation.cell
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
    [<ExcelFunction(Name="_FloorTruncation_getType", Description="Create a FloorTruncation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloorTruncation_getType
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloorTruncation",Description = "Reference to FloorTruncation")>] 
         floortruncation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloorTruncation = Helper.toCell<FloorTruncation> floortruncation "FloorTruncation" true 
                let builder () = withMnemonic mnemonic ((_FloorTruncation.cell :?> FloorTruncationModel).GetType
                                                       ) :> ICell
                let format (o : Type) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FloorTruncation.source + ".GetType") 
                                               [| _FloorTruncation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloorTruncation.cell
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
    [<ExcelFunction(Name="_FloorTruncation_Precision", Description="Create a FloorTruncation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloorTruncation_Precision
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloorTruncation",Description = "Reference to FloorTruncation")>] 
         floortruncation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloorTruncation = Helper.toCell<FloorTruncation> floortruncation "FloorTruncation" true 
                let builder () = withMnemonic mnemonic ((_FloorTruncation.cell :?> FloorTruncationModel).Precision
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloorTruncation.source + ".Precision") 
                                               [| _FloorTruncation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloorTruncation.cell
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
    [<ExcelFunction(Name="_FloorTruncation_Round", Description="Create a FloorTruncation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloorTruncation_Round
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloorTruncation",Description = "Reference to FloorTruncation")>] 
         floortruncation : obj)
        ([<ExcelArgument(Name="value",Description = "Reference to value")>] 
         value : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloorTruncation = Helper.toCell<FloorTruncation> floortruncation "FloorTruncation" true 
                let _value = Helper.toCell<double> value "value" true
                let builder () = withMnemonic mnemonic ((_FloorTruncation.cell :?> FloorTruncationModel).Round
                                                            _value.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloorTruncation.source + ".Round") 
                                               [| _FloorTruncation.source
                                               ;  _value.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloorTruncation.cell
                                ;  _value.cell
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
    [<ExcelFunction(Name="_FloorTruncation_Range", Description="Create a range of FloorTruncation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloorTruncation_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the FloorTruncation")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FloorTruncation> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FloorTruncation>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<FloorTruncation>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<FloorTruncation>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"