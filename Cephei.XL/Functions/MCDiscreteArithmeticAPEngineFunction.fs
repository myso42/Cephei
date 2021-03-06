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
(*!!
(* <summary>
template <class RNG = PseudoRandom, class S = Statistics>
  </summary> *)
[<AutoSerializable(true)>]
module MCDiscreteArithmeticAPEngineFunction =

    (*
        constructor
    *)
    [<ExcelFunction(Name="_MCDiscreteArithmeticAPEngine", Description="Create a MCDiscreteArithmeticAPEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MCDiscreteArithmeticAPEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Process",Description = "GeneralizedBlackScholesProcess")>] 
         Process : obj)
        ([<ExcelArgument(Name="maxTimeStepPerYear",Description = "int")>] 
         maxTimeStepPerYear : obj)
        ([<ExcelArgument(Name="brownianBridge",Description = "bool")>] 
         brownianBridge : obj)
        ([<ExcelArgument(Name="antitheticVariate",Description = "bool")>] 
         antitheticVariate : obj)
        ([<ExcelArgument(Name="controlVariate",Description = "bool")>] 
         controlVariate : obj)
        ([<ExcelArgument(Name="requiredSamples",Description = "int")>] 
         requiredSamples : obj)
        ([<ExcelArgument(Name="requiredTolerance",Description = "double")>] 
         requiredTolerance : obj)
        ([<ExcelArgument(Name="maxSamples",Description = "int")>] 
         maxSamples : obj)
        ([<ExcelArgument(Name="seed",Description = "uint64")>] 
         seed : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let _maxTimeStepPerYear = Helper.toCell<int> maxTimeStepPerYear "maxTimeStepPerYear" 
                let _brownianBridge = Helper.toCell<bool> brownianBridge "brownianBridge" 
                let _antitheticVariate = Helper.toCell<bool> antitheticVariate "antitheticVariate" 
                let _controlVariate = Helper.toCell<bool> controlVariate "controlVariate" 
                let _requiredSamples = Helper.toCell<int> requiredSamples "requiredSamples" 
                let _requiredTolerance = Helper.toCell<double> requiredTolerance "requiredTolerance" 
                let _maxSamples = Helper.toCell<int> maxSamples "maxSamples" 
                let _seed = Helper.toCell<uint64> seed "seed" 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = (Fun.MCDiscreteArithmeticAPEngine 
                                                            _Process.cell 
                                                            _maxTimeStepPerYear.cell 
                                                            _brownianBridge.cell 
                                                            _antitheticVariate.cell 
                                                            _controlVariate.cell 
                                                            _requiredSamples.cell 
                                                            _requiredTolerance.cell 
                                                            _maxSamples.cell 
                                                            _seed.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<MCDiscreteArithmeticAPEngine>) l

                let source () = Helper.sourceFold "Fun.MCDiscreteArithmeticAPEngine" 
                                               [| _Process.source
                                               ;  _maxTimeStepPerYear.source
                                               ;  _brownianBridge.source
                                               ;  _antitheticVariate.source
                                               ;  _controlVariate.source
                                               ;  _requiredSamples.source
                                               ;  _requiredTolerance.source
                                               ;  _maxSamples.source
                                               ;  _seed.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Process.cell
                                ;  _maxTimeStepPerYear.cell
                                ;  _brownianBridge.cell
                                ;  _antitheticVariate.cell
                                ;  _controlVariate.cell
                                ;  _requiredSamples.cell
                                ;  _requiredTolerance.cell
                                ;  _maxSamples.cell
                                ;  _seed.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MCDiscreteArithmeticAPEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"

    (*
        
    *)
    [<ExcelFunction(Name="_MCDiscreteArithmeticAPEngine_registerWith", Description="Create a MCDiscreteArithmeticAPEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MCDiscreteArithmeticAPEngine_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MCDiscreteArithmeticAPEngine",Description = "MCDiscreteArithmeticAPEngine")>] 
         mcdiscretearithmeticapengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MCDiscreteArithmeticAPEngine = Helper.toModelReference<MCDiscreteArithmeticAPEngine> mcdiscretearithmeticapengine "MCDiscreteArithmeticAPEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((MCDiscreteArithmeticAPEngineModel.Cast _MCDiscreteArithmeticAPEngine.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : MCDiscreteArithmeticAPEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MCDiscreteArithmeticAPEngine.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MCDiscreteArithmeticAPEngine.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_MCDiscreteArithmeticAPEngine_reset", Description="Create a MCDiscreteArithmeticAPEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MCDiscreteArithmeticAPEngine_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MCDiscreteArithmeticAPEngine",Description = "MCDiscreteArithmeticAPEngine")>] 
         mcdiscretearithmeticapengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MCDiscreteArithmeticAPEngine = Helper.toModelReference<MCDiscreteArithmeticAPEngine> mcdiscretearithmeticapengine "MCDiscreteArithmeticAPEngine"  
                let builder (current : ICell) = ((MCDiscreteArithmeticAPEngineModel.Cast _MCDiscreteArithmeticAPEngine.cell).Reset
                                                       ) :> ICell
                let format (o : MCDiscreteArithmeticAPEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MCDiscreteArithmeticAPEngine.source + ".Reset") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MCDiscreteArithmeticAPEngine.cell
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
    [<ExcelFunction(Name="_MCDiscreteArithmeticAPEngine_unregisterWith", Description="Create a MCDiscreteArithmeticAPEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MCDiscreteArithmeticAPEngine_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MCDiscreteArithmeticAPEngine",Description = "MCDiscreteArithmeticAPEngine")>] 
         mcdiscretearithmeticapengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MCDiscreteArithmeticAPEngine = Helper.toModelReference<MCDiscreteArithmeticAPEngine> mcdiscretearithmeticapengine "MCDiscreteArithmeticAPEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((MCDiscreteArithmeticAPEngineModel.Cast _MCDiscreteArithmeticAPEngine.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : MCDiscreteArithmeticAPEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MCDiscreteArithmeticAPEngine.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MCDiscreteArithmeticAPEngine.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_MCDiscreteArithmeticAPEngine_update", Description="Create a MCDiscreteArithmeticAPEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MCDiscreteArithmeticAPEngine_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MCDiscreteArithmeticAPEngine",Description = "MCDiscreteArithmeticAPEngine")>] 
         mcdiscretearithmeticapengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MCDiscreteArithmeticAPEngine = Helper.toModelReference<MCDiscreteArithmeticAPEngine> mcdiscretearithmeticapengine "MCDiscreteArithmeticAPEngine"  
                let builder (current : ICell) = ((MCDiscreteArithmeticAPEngineModel.Cast _MCDiscreteArithmeticAPEngine.cell).Update
                                                       ) :> ICell
                let format (o : MCDiscreteArithmeticAPEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MCDiscreteArithmeticAPEngine.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MCDiscreteArithmeticAPEngine.cell
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
        ! error estimated using the samples simulated so far
    *)
    [<ExcelFunction(Name="_MCDiscreteArithmeticAPEngine_errorEstimate", Description="Create a MCDiscreteArithmeticAPEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MCDiscreteArithmeticAPEngine_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MCDiscreteArithmeticAPEngine",Description = "MCDiscreteArithmeticAPEngine")>] 
         mcdiscretearithmeticapengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MCDiscreteArithmeticAPEngine = Helper.toModelReference<MCDiscreteArithmeticAPEngine> mcdiscretearithmeticapengine "MCDiscreteArithmeticAPEngine"  
                let builder (current : ICell) = ((MCDiscreteArithmeticAPEngineModel.Cast _MCDiscreteArithmeticAPEngine.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MCDiscreteArithmeticAPEngine.source + ".ErrorEstimate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MCDiscreteArithmeticAPEngine.cell
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
        ! access to the sample accumulator for richer statistics
    *)
    [<ExcelFunction(Name="_MCDiscreteArithmeticAPEngine_sampleAccumulator", Description="Create a MCDiscreteArithmeticAPEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MCDiscreteArithmeticAPEngine_sampleAccumulator
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MCDiscreteArithmeticAPEngine",Description = "MCDiscreteArithmeticAPEngine")>] 
         mcdiscretearithmeticapengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MCDiscreteArithmeticAPEngine = Helper.toModelReference<MCDiscreteArithmeticAPEngine> mcdiscretearithmeticapengine "MCDiscreteArithmeticAPEngine"  
                let builder (current : ICell) = ((MCDiscreteArithmeticAPEngineModel.Cast _MCDiscreteArithmeticAPEngine.cell).SampleAccumulator
                                                       ) :> ICell
                let format (o : S) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MCDiscreteArithmeticAPEngine.source + ".SampleAccumulator") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MCDiscreteArithmeticAPEngine.cell
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
        ! add samples until the required absolute tolerance is reached
    *)
    [<ExcelFunction(Name="_MCDiscreteArithmeticAPEngine_value", Description="Create a MCDiscreteArithmeticAPEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MCDiscreteArithmeticAPEngine_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MCDiscreteArithmeticAPEngine",Description = "MCDiscreteArithmeticAPEngine")>] 
         mcdiscretearithmeticapengine : obj)
        ([<ExcelArgument(Name="tolerance",Description = "double")>] 
         tolerance : obj)
        ([<ExcelArgument(Name="maxSamples",Description = "int")>] 
         maxSamples : obj)
        ([<ExcelArgument(Name="minSamples",Description = "int")>] 
         minSamples : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MCDiscreteArithmeticAPEngine = Helper.toModelReference<MCDiscreteArithmeticAPEngine> mcdiscretearithmeticapengine "MCDiscreteArithmeticAPEngine"  
                let _tolerance = Helper.toCell<double> tolerance "tolerance" 
                let _maxSamples = Helper.toCell<int> maxSamples "maxSamples" 
                let _minSamples = Helper.toCell<int> minSamples "minSamples" 
                let builder (current : ICell) = ((MCDiscreteArithmeticAPEngineModel.Cast _MCDiscreteArithmeticAPEngine.cell).Value
                                                            _tolerance.cell 
                                                            _maxSamples.cell 
                                                            _minSamples.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MCDiscreteArithmeticAPEngine.source + ".Value") 

                                               [| _tolerance.source
                                               ;  _maxSamples.source
                                               ;  _minSamples.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MCDiscreteArithmeticAPEngine.cell
                                ;  _tolerance.cell
                                ;  _maxSamples.cell
                                ;  _minSamples.cell
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
        ! simulate a fixed number of samples
    *)
    [<ExcelFunction(Name="_MCDiscreteArithmeticAPEngine_valueWithSamples", Description="Create a MCDiscreteArithmeticAPEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MCDiscreteArithmeticAPEngine_valueWithSamples
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MCDiscreteArithmeticAPEngine",Description = "MCDiscreteArithmeticAPEngine")>] 
         mcdiscretearithmeticapengine : obj)
        ([<ExcelArgument(Name="samples",Description = "int")>] 
         samples : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MCDiscreteArithmeticAPEngine = Helper.toModelReference<MCDiscreteArithmeticAPEngine> mcdiscretearithmeticapengine "MCDiscreteArithmeticAPEngine"  
                let _samples = Helper.toCell<int> samples "samples" 
                let builder (current : ICell) = ((MCDiscreteArithmeticAPEngineModel.Cast _MCDiscreteArithmeticAPEngine.cell).ValueWithSamples
                                                            _samples.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MCDiscreteArithmeticAPEngine.source + ".ValueWithSamples") 

                                               [| _samples.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MCDiscreteArithmeticAPEngine.cell
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
    [<ExcelFunction(Name="_MCDiscreteArithmeticAPEngine_Range", Description="Create a range of MCDiscreteArithmeticAPEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MCDiscreteArithmeticAPEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<MCDiscreteArithmeticAPEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<MCDiscreteArithmeticAPEngine> (c)) :> ICell
                let format (i : Cephei.Cell.List<MCDiscreteArithmeticAPEngine>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<MCDiscreteArithmeticAPEngine>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
