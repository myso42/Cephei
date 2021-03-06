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
  Incremental Brownian generator using a Sobol generator, inverse-cumulative Gaussian method, and Brownian bridging.
  </summary> *)
[<AutoSerializable(true)>]
module SobolBrownianGeneratorFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SobolBrownianGenerator_nextPath", Description="Create a SobolBrownianGenerator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SobolBrownianGenerator_nextPath
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SobolBrownianGenerator",Description = "SobolBrownianGenerator")>] 
         sobolbrowniangenerator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SobolBrownianGenerator = Helper.toModelReference<SobolBrownianGenerator> sobolbrowniangenerator "SobolBrownianGenerator"  
                let builder (current : ICell) = ((SobolBrownianGeneratorModel.Cast _SobolBrownianGenerator.cell).NextPath
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SobolBrownianGenerator.source + ".NextPath") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SobolBrownianGenerator.cell
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
    [<ExcelFunction(Name="_SobolBrownianGenerator_nextStep", Description="Create a SobolBrownianGenerator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SobolBrownianGenerator_nextStep
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SobolBrownianGenerator",Description = "SobolBrownianGenerator")>] 
         sobolbrowniangenerator : obj)
        ([<ExcelArgument(Name="output",Description = "double range")>] 
         output : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SobolBrownianGenerator = Helper.toModelReference<SobolBrownianGenerator> sobolbrowniangenerator "SobolBrownianGenerator"  
                let _output = Helper.toCell<Generic.List<double>> output "output" 
                let builder (current : ICell) = ((SobolBrownianGeneratorModel.Cast _SobolBrownianGenerator.cell).NextStep
                                                            _output.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SobolBrownianGenerator.source + ".NextStep") 

                                               [| _output.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SobolBrownianGenerator.cell
                                ;  _output.cell
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
    [<ExcelFunction(Name="_SobolBrownianGenerator_numberOfFactors", Description="Create a SobolBrownianGenerator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SobolBrownianGenerator_numberOfFactors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SobolBrownianGenerator",Description = "SobolBrownianGenerator")>] 
         sobolbrowniangenerator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SobolBrownianGenerator = Helper.toModelReference<SobolBrownianGenerator> sobolbrowniangenerator "SobolBrownianGenerator"  
                let builder (current : ICell) = ((SobolBrownianGeneratorModel.Cast _SobolBrownianGenerator.cell).NumberOfFactors
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SobolBrownianGenerator.source + ".NumberOfFactors") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SobolBrownianGenerator.cell
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
    [<ExcelFunction(Name="_SobolBrownianGenerator_numberOfSteps", Description="Create a SobolBrownianGenerator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SobolBrownianGenerator_numberOfSteps
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SobolBrownianGenerator",Description = "SobolBrownianGenerator")>] 
         sobolbrowniangenerator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SobolBrownianGenerator = Helper.toModelReference<SobolBrownianGenerator> sobolbrowniangenerator "SobolBrownianGenerator"  
                let builder (current : ICell) = ((SobolBrownianGeneratorModel.Cast _SobolBrownianGenerator.cell).NumberOfSteps
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SobolBrownianGenerator.source + ".NumberOfSteps") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SobolBrownianGenerator.cell
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
        test interface
    *)
    [<ExcelFunction(Name="_SobolBrownianGenerator_orderedIndices", Description="Create a SobolBrownianGenerator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SobolBrownianGenerator_orderedIndices
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SobolBrownianGenerator",Description = "SobolBrownianGenerator")>] 
         sobolbrowniangenerator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SobolBrownianGenerator = Helper.toModelReference<SobolBrownianGenerator> sobolbrowniangenerator "SobolBrownianGenerator"  
                let builder (current : ICell) = ((SobolBrownianGeneratorModel.Cast _SobolBrownianGenerator.cell).OrderedIndices
                                                       ) :> ICell
                let format (i : Generic.List<Generic.List<int>>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_SobolBrownianGenerator.source + ".OrderedIndices") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SobolBrownianGenerator.cell
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
    (*
        
    *)
    [<ExcelFunction(Name="_SobolBrownianGenerator", Description="Create a SobolBrownianGenerator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SobolBrownianGenerator_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="factors",Description = "int")>] 
         factors : obj)
        ([<ExcelArgument(Name="steps",Description = "int")>] 
         steps : obj)
        ([<ExcelArgument(Name="ordering",Description = "SobolBrownianGenerator.Ordering: Factors, Steps, Diagonal")>] 
         ordering : obj)
        ([<ExcelArgument(Name="seed",Description = "uint64 or empty")>] 
         seed : obj)
        ([<ExcelArgument(Name="directionIntegers",Description = "SobolRsg.DirectionIntegers: Unit, Jaeckel, SobolLevitan, SobolLevitanLemieux, JoeKuoD5, JoeKuoD6, JoeKuoD7, Kuo, Kuo2, Kuo3 or empty")>] 
         directionIntegers : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _factors = Helper.toCell<int> factors "factors" 
                let _steps = Helper.toCell<int> steps "steps" 
                let _ordering = Helper.toCell<SobolBrownianGenerator.Ordering> ordering "ordering" 
                let _seed = Helper.toDefault<uint64> seed "seed" 0UL
                let _directionIntegers = Helper.toDefault<SobolRsg.DirectionIntegers> directionIntegers "directionIntegers" SobolRsg.DirectionIntegers.Jaeckel
                let builder (current : ICell) = (Fun.SobolBrownianGenerator 
                                                            _factors.cell 
                                                            _steps.cell 
                                                            _ordering.cell 
                                                            _seed.cell 
                                                            _directionIntegers.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SobolBrownianGenerator>) l

                let source () = Helper.sourceFold "Fun.SobolBrownianGenerator" 
                                               [| _factors.source
                                               ;  _steps.source
                                               ;  _ordering.source
                                               ;  _seed.source
                                               ;  _directionIntegers.source
                                               |]
                let hash = Helper.hashFold 
                                [| _factors.cell
                                ;  _steps.cell
                                ;  _ordering.cell
                                ;  _seed.cell
                                ;  _directionIntegers.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SobolBrownianGenerator> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SobolBrownianGenerator_transform", Description="Create a SobolBrownianGenerator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SobolBrownianGenerator_transform
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SobolBrownianGenerator",Description = "SobolBrownianGenerator")>] 
         sobolbrowniangenerator : obj)
        ([<ExcelArgument(Name="variates",Description = "double range")>] 
         variates : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SobolBrownianGenerator = Helper.toModelReference<SobolBrownianGenerator> sobolbrowniangenerator "SobolBrownianGenerator"  
                let _variates = Helper.toCell<Generic.List<Generic.List<double>>> variates "variates" 
                let builder (current : ICell) = ((SobolBrownianGeneratorModel.Cast _SobolBrownianGenerator.cell).Transform
                                                            _variates.cell 
                                                       ) :> ICell
                let format (i : Generic.List<Generic.List<double>>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_SobolBrownianGenerator.source + ".Transform") 

                                               [| _variates.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SobolBrownianGenerator.cell
                                ;  _variates.cell
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
    [<ExcelFunction(Name="_SobolBrownianGenerator_Range", Description="Create a range of SobolBrownianGenerator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SobolBrownianGenerator_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SobolBrownianGenerator> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<SobolBrownianGenerator> (c)) :> ICell
                let format (i : Cephei.Cell.List<SobolBrownianGenerator>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<SobolBrownianGenerator>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
