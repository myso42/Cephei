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
  The template arguments of this class correspond to available policies for the particular model to be instantiated---i.e., whether it is single- or multi-asset, or whether it should use pseudo-random or low-discrepancy numbers for path generation. Such decisions are grouped in trait classes so as to be orthogonal---see mctraits for examples.  The constructor accepts two safe references, i.e. two smart pointers, one to a path generator and the other to a path pricer.  In case of control variate technique the user should provide the additional control option, namely the option path pricer and the option value.  mcarlo
  </summary> *)
[<AutoSerializable(true)>]
module MonteCarloModelFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_MonteCarloModel_addSamples", Description="Create a MonteCarloModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MonteCarloModel_addSamples
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonteCarloModel",Description = "MonteCarloModel")>] 
         montecarlomodel : obj)
        ([<ExcelArgument(Name="samples",Description = "int")>] 
         samples : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonteCarloModel = Helper.toModelReference<MonteCarloModel> montecarlomodel "MonteCarloModel"  
                let _samples = Helper.toCell<int> samples "samples" 
                let builder (current : ICell) = ((MonteCarloModelModel.Cast _MonteCarloModel.cell).AddSamples
                                                            _samples.cell 
                                                       ) :> ICell
                let format (o : MonteCarloModel) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MonteCarloModel.source + ".AddSamples") 

                                               [| _samples.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MonteCarloModel.cell
                                ;  _samples.cell
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
    [<ExcelFunction(Name="_MonteCarloModel", Description="Create a MonteCarloModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MonteCarloModel_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="pathGenerator",Description = "IRNG")>] 
         pathGenerator : obj)
        ([<ExcelArgument(Name="pathPricer",Description = "IPath")>] 
         pathPricer : obj)
        ([<ExcelArgument(Name="sampleAccumulator",Description = "'S")>] 
         sampleAccumulator : obj)
        ([<ExcelArgument(Name="antitheticVariate",Description = "bool")>] 
         antitheticVariate : obj)
        ([<ExcelArgument(Name="cvPathPricer",Description = "IPath or empty")>] 
         cvPathPricer : obj)
        ([<ExcelArgument(Name="cvOptionValue",Description = "double or empty")>] 
         cvOptionValue : obj)
        ([<ExcelArgument(Name="cvPathGenerator",Description = "IRNG or empty")>] 
         cvPathGenerator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _pathGenerator = Helper.toCell<IPathGenerator<IRNG>> pathGenerator "pathGenerator" 
                let _pathPricer = Helper.toCell<PathPricer<IPath>> pathPricer "pathPricer" 
                let _sampleAccumulator = Helper.toCell<'S> sampleAccumulator "sampleAccumulator" 
                let _antitheticVariate = Helper.toCell<bool> antitheticVariate "antitheticVariate" 
                let _cvPathPricer = Helper.toDefault<PathPricer<IPath>> cvPathPricer "cvPathPricer" null
                let _cvOptionValue = Helper.toDefault<double> cvOptionValue "cvOptionValue" 0
                let _cvPathGenerator = Helper.toDefault<IPathGenerator<IRNG>> cvPathGenerator "cvPathGenerator" null
                let builder (current : ICell) = (Fun.MonteCarloModel 
                                                            _pathGenerator.cell 
                                                            _pathPricer.cell 
                                                            _sampleAccumulator.cell 
                                                            _antitheticVariate.cell 
                                                            _cvPathPricer.cell 
                                                            _cvOptionValue.cell 
                                                            _cvPathGenerator.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<MonteCarloModel>) l

                let source () = Helper.sourceFold "Fun.MonteCarloModel" 
                                               [| _pathGenerator.source
                                               ;  _pathPricer.source
                                               ;  _sampleAccumulator.source
                                               ;  _antitheticVariate.source
                                               ;  _cvPathPricer.source
                                               ;  _cvOptionValue.source
                                               ;  _cvPathGenerator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _pathGenerator.cell
                                ;  _pathPricer.cell
                                ;  _sampleAccumulator.cell
                                ;  _antitheticVariate.cell
                                ;  _cvPathPricer.cell
                                ;  _cvOptionValue.cell
                                ;  _cvPathGenerator.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MonteCarloModel> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_MonteCarloModel_sampleAccumulator", Description="Create a MonteCarloModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MonteCarloModel_sampleAccumulator
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonteCarloModel",Description = "MonteCarloModel")>] 
         montecarlomodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonteCarloModel = Helper.toModelReference<MonteCarloModel> montecarlomodel "MonteCarloModel"  
                let builder (current : ICell) = ((MonteCarloModelModel.Cast _MonteCarloModel.cell).SampleAccumulator
                                                       ) :> ICell
                let format (o : S) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MonteCarloModel.source + ".SampleAccumulator") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MonteCarloModel.cell
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
    [<ExcelFunction(Name="_MonteCarloModel_Range", Description="Create a range of MonteCarloModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MonteCarloModel_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<MonteCarloModel> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<MonteCarloModel> (c)) :> ICell
                let format (i : Cephei.Cell.List<MonteCarloModel>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<MonteCarloModel>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
            *)
