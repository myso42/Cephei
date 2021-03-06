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
  Halton algorithm for low-discrepancy sequence.  For more details see chapter 8, paragraph 2 of "Monte Carlo Methods in Finance", by Peter Jäckel  - the correctness of the returned values is tested by reproducing known good values. - the correctness of the returned values is tested by checking their discrepancy against known good values.
  </summary> *)
[<AutoSerializable(true)>]
module HaltonRsgFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_HaltonRsg_dimension", Description="Create a HaltonRsg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HaltonRsg_dimension
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HaltonRsg",Description = "HaltonRsg")>] 
         haltonrsg : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HaltonRsg = Helper.toModelReference<HaltonRsg> haltonrsg "HaltonRsg"  
                let builder (current : ICell) = ((HaltonRsgModel.Cast _HaltonRsg.cell).Dimension
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_HaltonRsg.source + ".Dimension") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _HaltonRsg.cell
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
    [<ExcelFunction(Name="_HaltonRsg_factory", Description="Create a HaltonRsg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HaltonRsg_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HaltonRsg",Description = "HaltonRsg")>] 
         haltonrsg : obj)
        ([<ExcelArgument(Name="dimensionality",Description = "int")>] 
         dimensionality : obj)
        ([<ExcelArgument(Name="seed",Description = "uint64 or empty")>] 
         seed : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HaltonRsg = Helper.toModelReference<HaltonRsg> haltonrsg "HaltonRsg"  
                let _dimensionality = Helper.toCell<int> dimensionality "dimensionality" 
                let _seed = Helper.toDefault<uint64> seed "seed" 0UL
                let builder (current : ICell) = ((HaltonRsgModel.Cast _HaltonRsg.cell).Factory
                                                            _dimensionality.cell 
                                                            _seed.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IRNG>) l

                let source () = Helper.sourceFold (_HaltonRsg.source + ".Factory") 

                                               [| _dimensionality.source
                                               ;  _seed.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HaltonRsg.cell
                                ;  _dimensionality.cell
                                ;  _seed.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HaltonRsg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_HaltonRsg", Description="Create a HaltonRsg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HaltonRsg_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="dimensionality",Description = "int")>] 
         dimensionality : obj)
        ([<ExcelArgument(Name="seed",Description = "uint64 or empty")>] 
         seed : obj)
        ([<ExcelArgument(Name="randomStart",Description = "bool or empty")>] 
         randomStart : obj)
        ([<ExcelArgument(Name="randomShift",Description = "bool or empty")>] 
         randomShift : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _dimensionality = Helper.toCell<int> dimensionality "dimensionality" 
                let _seed = Helper.toDefault<uint64> seed "seed" 0UL
                let _randomStart = Helper.toDefault<bool> randomStart "randomStart" true
                let _randomShift = Helper.toDefault<bool> randomShift "randomShift" false
                let builder (current : ICell) = (Fun.HaltonRsg 
                                                            _dimensionality.cell 
                                                            _seed.cell 
                                                            _randomStart.cell 
                                                            _randomShift.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<HaltonRsg>) l

                let source () = Helper.sourceFold "Fun.HaltonRsg" 
                                               [| _dimensionality.source
                                               ;  _seed.source
                                               ;  _randomStart.source
                                               ;  _randomShift.source
                                               |]
                let hash = Helper.hashFold 
                                [| _dimensionality.cell
                                ;  _seed.cell
                                ;  _randomStart.cell
                                ;  _randomShift.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HaltonRsg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    (*!! sample not supported by Helper
    [<ExcelFunction(Name="_HaltonRsg_lastSequence", Description="Create a HaltonRsg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HaltonRsg_lastSequence
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HaltonRsg",Description = "HaltonRsg")>] 
         haltonrsg : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HaltonRsg = Helper.toModelReference<HaltonRsg> haltonrsg "HaltonRsg"  
                let builder (current : ICell) = ((HaltonRsgModel.Cast _HaltonRsg.cell).LastSequence
                                                       ) :> ICell
                let format (i : Sample<Generic.List<double>>) (l : string) = (Helper.Range.fromArray (i.value.ToArray()) l)

                let source () = Helper.sourceFold (_HaltonRsg.source + ".LastSequence") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _HaltonRsg.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
            *)
    (*
        
    *)
    (*!! sample not supported by Helper
    [<ExcelFunction(Name="_HaltonRsg_nextSequence", Description="Create a HaltonRsg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HaltonRsg_nextSequence
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HaltonRsg",Description = "HaltonRsg")>] 
         haltonrsg : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HaltonRsg = Helper.toModelReference<HaltonRsg> haltonrsg "HaltonRsg"  
                let builder (current : ICell) = ((HaltonRsgModel.Cast _HaltonRsg.cell).NextSequence
                                                       ) :> ICell
                let format (i : Sample<Generic.List<double>>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_HaltonRsg.source + ".NextSequence") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _HaltonRsg.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
            *)
    [<ExcelFunction(Name="_HaltonRsg_Range", Description="Create a range of HaltonRsg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HaltonRsg_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<HaltonRsg> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<HaltonRsg> (c)) :> ICell
                let format (i : Cephei.Cell.List<HaltonRsg>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<HaltonRsg>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
