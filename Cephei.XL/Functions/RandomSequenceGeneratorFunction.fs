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
  Random sequence generator based on a pseudo-random number generator RNG. Do not use with low-discrepancy sequence generator.
  </summary> *)
[<AutoSerializable(true)>]
module RandomSequenceGeneratorFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_RandomSequenceGenerator_dimension", Description="Create a RandomSequenceGenerator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RandomSequenceGenerator_dimension
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RandomSequenceGenerator",Description = "RandomSequenceGenerator")>] 
         randomsequencegenerator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RandomSequenceGenerator = Helper.toModelReference<RandomSequenceGenerator> randomsequencegenerator "RandomSequenceGenerator"  
                let builder (current : ICell) = ((RandomSequenceGeneratorModel.Cast _RandomSequenceGenerator.cell).Dimension
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RandomSequenceGenerator.source + ".Dimension") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _RandomSequenceGenerator.cell
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
    [<ExcelFunction(Name="_RandomSequenceGenerator_factory", Description="Create a RandomSequenceGenerator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RandomSequenceGenerator_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RandomSequenceGenerator",Description = "RandomSequenceGenerator")>] 
         randomsequencegenerator : obj)
        ([<ExcelArgument(Name="dimensionality",Description = "int")>] 
         dimensionality : obj)
        ([<ExcelArgument(Name="seed",Description = "uint64")>] 
         seed : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RandomSequenceGenerator = Helper.toModelReference<RandomSequenceGenerator> randomsequencegenerator "RandomSequenceGenerator"  
                let _dimensionality = Helper.toCell<int> dimensionality "dimensionality" 
                let _seed = Helper.toCell<uint64> seed "seed" 
                let builder (current : ICell) = ((RandomSequenceGeneratorModel.Cast _RandomSequenceGenerator.cell).Factory
                                                            _dimensionality.cell 
                                                            _seed.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IRNG>) l

                let source () = Helper.sourceFold (_RandomSequenceGenerator.source + ".Factory") 

                                               [| _dimensionality.source
                                               ;  _seed.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RandomSequenceGenerator.cell
                                ;  _dimensionality.cell
                                ;  _seed.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<RandomSequenceGenerator> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_RandomSequenceGenerator_lastSequence", Description="Create a RandomSequenceGenerator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RandomSequenceGenerator_lastSequence
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RandomSequenceGenerator",Description = "RandomSequenceGenerator")>] 
         randomsequencegenerator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RandomSequenceGenerator = Helper.toModelReference<RandomSequenceGenerator> randomsequencegenerator "RandomSequenceGenerator"  
                let builder (current : ICell) = ((RandomSequenceGeneratorModel.Cast _RandomSequenceGenerator.cell).LastSequence
                                                       ) :> ICell
                let format (i : Sample<Generic.List<double>>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_RandomSequenceGenerator.source + ".LastSequence") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _RandomSequenceGenerator.cell
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
    [<ExcelFunction(Name="_RandomSequenceGenerator_nextInt32Sequence", Description="Create a RandomSequenceGenerator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RandomSequenceGenerator_nextInt32Sequence
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RandomSequenceGenerator",Description = "RandomSequenceGenerator")>] 
         randomsequencegenerator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RandomSequenceGenerator = Helper.toModelReference<RandomSequenceGenerator> randomsequencegenerator "RandomSequenceGenerator"  
                let builder (current : ICell) = ((RandomSequenceGeneratorModel.Cast _RandomSequenceGenerator.cell).NextInt32Sequence
                                                       ) :> ICell
                let format (i : Generic.List<ulong>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_RandomSequenceGenerator.source + ".NextInt32Sequence") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _RandomSequenceGenerator.cell
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
    [<ExcelFunction(Name="_RandomSequenceGenerator_nextSequence", Description="Create a RandomSequenceGenerator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RandomSequenceGenerator_nextSequence
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RandomSequenceGenerator",Description = "RandomSequenceGenerator")>] 
         randomsequencegenerator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RandomSequenceGenerator = Helper.toModelReference<RandomSequenceGenerator> randomsequencegenerator "RandomSequenceGenerator"  
                let builder (current : ICell) = ((RandomSequenceGeneratorModel.Cast _RandomSequenceGenerator.cell).NextSequence
                                                       ) :> ICell
                let format (i : Sample<Generic.List<double>>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_RandomSequenceGenerator.source + ".NextSequence") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _RandomSequenceGenerator.cell
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
    [<ExcelFunction(Name="_RandomSequenceGenerator", Description="Create a RandomSequenceGenerator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RandomSequenceGenerator_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="dimensionality",Description = "int")>] 
         dimensionality : obj)
        ([<ExcelArgument(Name="seed",Description = "uint64")>] 
         seed : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _dimensionality = Helper.toCell<int> dimensionality "dimensionality" 
                let _seed = Helper.toCell<uint64> seed "seed" 
                let builder (current : ICell) = (Fun.RandomSequenceGenerator 
                                                            _dimensionality.cell 
                                                            _seed.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RandomSequenceGenerator>) l

                let source () = Helper.sourceFold "Fun.RandomSequenceGenerator" 
                                               [| _dimensionality.source
                                               ;  _seed.source
                                               |]
                let hash = Helper.hashFold 
                                [| _dimensionality.cell
                                ;  _seed.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<RandomSequenceGenerator> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_RandomSequenceGenerator1", Description="Create a RandomSequenceGenerator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RandomSequenceGenerator_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="dimensionality",Description = "int")>] 
         dimensionality : obj)
        ([<ExcelArgument(Name="rng",Description = "'RNG")>] 
         rng : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _dimensionality = Helper.toCell<int> dimensionality "dimensionality" 
                let _rng = Helper.toCell<'RNG> rng "rng" 
                let builder (current : ICell) = (Fun.RandomSequenceGenerator1 
                                                            _dimensionality.cell 
                                                            _rng.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RandomSequenceGenerator>) l

                let source () = Helper.sourceFold "Fun.RandomSequenceGenerator1" 
                                               [| _dimensionality.source
                                               ;  _rng.source
                                               |]
                let hash = Helper.hashFold 
                                [| _dimensionality.cell
                                ;  _rng.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<RandomSequenceGenerator> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_RandomSequenceGenerator_Range", Description="Create a range of RandomSequenceGenerator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RandomSequenceGenerator_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<RandomSequenceGenerator> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<RandomSequenceGenerator> (c)) :> ICell
                let format (i : Cephei.Cell.List<RandomSequenceGenerator>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<RandomSequenceGenerator>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
            *)
