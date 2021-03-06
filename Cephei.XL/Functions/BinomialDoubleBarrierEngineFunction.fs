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
  barrierengines  This engine requires a the discretized option classes. By default uses a standard binomial implementation, but it can also work with DiscretizedDermanKaniDoubleBarrierOption to implement a Derman-Kani optimization.  the correctness of the returned values is tested by checking it against analytic results.
  </summary> *)
[<AutoSerializable(true)>]
module BinomialDoubleBarrierEngineFunction =

    (*
        ! \param maxTimeSteps is used to limit timeSteps when using Boyle-Lau optimization. If zero (the default) the maximum number of steps is calculated by an heuristic: anything when < 1000, otherwise no more than 5*timeSteps. If maxTimeSteps is equal to timeSteps Boyle-Lau is disabled. Likewise if the lattice is not CoxRossRubinstein Boyle-Lau is disabled and maxTimeSteps ignored.
    *)
    [<ExcelFunction(Name="_BinomialDoubleBarrierEngine", Description="Create a BinomialDoubleBarrierEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BinomialDoubleBarrierEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="getTree",Description = "BinomialDoubleBarrierEngine.GetTree")>] 
         getTree : obj)
        ([<ExcelArgument(Name="getAsset",Description = "BinomialDoubleBarrierEngine.GetAsset")>] 
         getAsset : obj)
        ([<ExcelArgument(Name="Process",Description = "GeneralizedBlackScholesProcess")>] 
         Process : obj)
        ([<ExcelArgument(Name="timeSteps",Description = "int")>] 
         timeSteps : obj)
        ([<ExcelArgument(Name="maxTimeSteps",Description = "int or empty")>] 
         maxTimeSteps : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _getTree = Helper.toCell<BinomialDoubleBarrierEngine.GetTree> getTree "getTree" 
                let _getAsset = Helper.toCell<BinomialDoubleBarrierEngine.GetAsset> getAsset "getAsset" 
                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let _timeSteps = Helper.toCell<int> timeSteps "timeSteps" 
                let _maxTimeSteps = Helper.toDefault<int> maxTimeSteps "maxTimeSteps" 0
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = (Fun.BinomialDoubleBarrierEngine 
                                                            _getTree.cell 
                                                            _getAsset.cell 
                                                            _Process.cell 
                                                            _timeSteps.cell 
                                                            _maxTimeSteps.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BinomialDoubleBarrierEngine>) l

                let source () = Helper.sourceFold "Fun.BinomialDoubleBarrierEngine" 
                                               [| _getTree.source
                                               ;  _getAsset.source
                                               ;  _Process.source
                                               ;  _timeSteps.source
                                               ;  _maxTimeSteps.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _getTree.cell
                                ;  _getAsset.cell
                                ;  _Process.cell
                                ;  _timeSteps.cell
                                ;  _maxTimeSteps.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BinomialDoubleBarrierEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"

    (*
        
    *)
    (*!!
    [<ExcelFunction(Name="_BinomialDoubleBarrierEngine_getAsset", Description="Create a BinomialDoubleBarrierEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BinomialDoubleBarrierEngine_getAsset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BinomialDoubleBarrierEngine",Description = "BinomialDoubleBarrierEngine")>] 
         binomialdoublebarrierengine : obj)
        ([<ExcelArgument(Name="args",Description = "DoubleBarrierOption.Arguments")>] 
         args : obj)
        ([<ExcelArgument(Name="Process",Description = "StochasticProcess")>] 
         Process : obj)
        ([<ExcelArgument(Name="grid",Description = "TimeGrid or empty")>] 
         grid : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BinomialDoubleBarrierEngine = Helper.toModelReference<BinomialDoubleBarrierEngine> binomialdoublebarrierengine "BinomialDoubleBarrierEngine"  
                let _args = Helper.toCell<DoubleBarrierOption.Arguments> args "args" 
                let _Process = Helper.toCell<StochasticProcess> Process "Process" 
                let _grid = Helper.toDefault<TimeGrid> grid "grid" null
                let builder (current : ICell) = ((BinomialDoubleBarrierEngineModel.Cast _BinomialDoubleBarrierEngine.cell).getAsset
                                                            _args.cell 
                                                            _Process.cell 
                                                            _grid.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DiscretizedAsset>) l

                let source () = Helper.sourceFold (_BinomialDoubleBarrierEngine.source + ".getAsset") 

                                               [| _args.source
                                               ;  _Process.source
                                               ;  _grid.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BinomialDoubleBarrierEngine.cell
                                ;  _args.cell
                                ;  _Process.cell
                                ;  _grid.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BinomialDoubleBarrierEngine> format
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
    (*!!
    [<ExcelFunction(Name="_BinomialDoubleBarrierEngine_GetTree", Description="Create a BinomialDoubleBarrierEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BinomialDoubleBarrierEngine_GetTree
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BinomialDoubleBarrierEngine",Description = "BinomialDoubleBarrierEngine")>] 
         binomialdoublebarrierengine : obj)
        ([<ExcelArgument(Name="Process",Description = "StochasticProcess1D")>] 
         Process : obj)
        ([<ExcelArgument(Name="End",Description = "double")>] 
         End : obj)
        ([<ExcelArgument(Name="steps",Description = "int")>] 
         steps : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BinomialDoubleBarrierEngine = Helper.toModelReference<BinomialDoubleBarrierEngine> binomialdoublebarrierengine "BinomialDoubleBarrierEngine"  
                let _Process = Helper.toCell<StochasticProcess1D> Process "Process" 
                let _End = Helper.toCell<double> End "End" 
                let _steps = Helper.toCell<int> steps "steps" 
                let _strike = Helper.toCell<double> strike "strike" 
                let builder (current : ICell) = ((BinomialDoubleBarrierEngineModel.Cast _BinomialDoubleBarrierEngine.cell).GetTree
                                                            _Process.cell 
                                                            _End.cell 
                                                            _steps.cell 
                                                            _strike.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ITree>) l

                let source () = Helper.sourceFold (_BinomialDoubleBarrierEngine.source + ".GetTree") 

                                               [| _Process.source
                                               ;  _End.source
                                               ;  _steps.source
                                               ;  _strike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BinomialDoubleBarrierEngine.cell
                                ;  _Process.cell
                                ;  _End.cell
                                ;  _steps.cell
                                ;  _strike.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BinomialDoubleBarrierEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
            *)
    [<ExcelFunction(Name="_BinomialDoubleBarrierEngine_Range", Description="Create a range of BinomialDoubleBarrierEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BinomialDoubleBarrierEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BinomialDoubleBarrierEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<BinomialDoubleBarrierEngine> (c)) :> ICell
                let format (i : Cephei.Cell.List<BinomialDoubleBarrierEngine>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<BinomialDoubleBarrierEngine>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
