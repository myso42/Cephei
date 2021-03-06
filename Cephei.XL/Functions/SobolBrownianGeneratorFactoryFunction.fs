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
module SobolBrownianGeneratorFactoryFunction =

    (*
        
    *)
    (*!! not implemented 
    [<ExcelFunction(Name="_SobolBrownianGeneratorFactory_create", Description="Create a SobolBrownianGeneratorFactory",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SobolBrownianGeneratorFactory_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SobolBrownianGeneratorFactory",Description = "SobolBrownianGeneratorFactory")>] 
         sobolbrowniangeneratorfactory : obj)
        ([<ExcelArgument(Name="factors",Description = "int")>] 
         factors : obj)
        ([<ExcelArgument(Name="steps",Description = "int")>] 
         steps : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SobolBrownianGeneratorFactory = Helper.toCell<SobolBrownianGeneratorFactory> sobolbrowniangeneratorfactory "SobolBrownianGeneratorFactory"  
                let _factors = Helper.toCell<int> factors "factors" 
                let _steps = Helper.toCell<int> steps "steps" 
                let builder (current : ICell) = ((SobolBrownianGeneratorFactoryModel.Cast _SobolBrownianGeneratorFactory.cell).Create
                                                            _factors.cell 
                                                            _steps.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IBrownianGenerator>) l

                let source () = Helper.sourceFold (_SobolBrownianGeneratorFactory.source + ".Create") 

                                               [| _factors.source
                                               ;  _steps.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SobolBrownianGeneratorFactory.cell
                                ;  _factors.cell
                                ;  _steps.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SobolBrownianGeneratorFactory> format
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
    [<ExcelFunction(Name="_SobolBrownianGeneratorFactory", Description="Create a SobolBrownianGeneratorFactory",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SobolBrownianGeneratorFactory_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ordering",Description = "SobolBrownianGenerator.Ordering: Factors, Steps, Diagonal")>] 
         ordering : obj)
        ([<ExcelArgument(Name="seed",Description = "uint64 or empty")>] 
         seed : obj)
        ([<ExcelArgument(Name="integers",Description = "SobolRsg.DirectionIntegers: Unit, Jaeckel, SobolLevitan, SobolLevitanLemieux, JoeKuoD5, JoeKuoD6, JoeKuoD7, Kuo, Kuo2, Kuo3 or empty")>] 
         integers : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ordering = Helper.toCell<SobolBrownianGenerator.Ordering> ordering "ordering" 
                let _seed = Helper.toDefault<uint64> seed "seed" 0UL
                let _integers = Helper.toDefault<SobolRsg.DirectionIntegers> integers "integers" SobolRsg.DirectionIntegers.Jaeckel
                let builder (current : ICell) = (Fun.SobolBrownianGeneratorFactory 
                                                            _ordering.cell 
                                                            _seed.cell 
                                                            _integers.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SobolBrownianGeneratorFactory>) l

                let source () = Helper.sourceFold "Fun.SobolBrownianGeneratorFactory" 
                                               [| _ordering.source
                                               ;  _seed.source
                                               ;  _integers.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ordering.cell
                                ;  _seed.cell
                                ;  _integers.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SobolBrownianGeneratorFactory> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_SobolBrownianGeneratorFactory_Range", Description="Create a range of SobolBrownianGeneratorFactory",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SobolBrownianGeneratorFactory_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SobolBrownianGeneratorFactory> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<SobolBrownianGeneratorFactory> (c)) :> ICell
                let format (i : Cephei.Cell.List<SobolBrownianGeneratorFactory>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<SobolBrownianGeneratorFactory>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
