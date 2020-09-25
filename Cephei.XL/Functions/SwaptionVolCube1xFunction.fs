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
(*
(* <summary>

  </summary> *)
[<AutoSerializable(true)>]
module SwaptionVolCube1xFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_denseSabrParameters", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_denseSabrParameters
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).DenseSabrParameters
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".DenseSabrParameters") 
                                               [| _SwaptionVolCube1x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube1x_GetInterpolation", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_GetInterpolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="Process",Description = "Reference to Process")>] 
         Process : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" true
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).GetInterpolation
                                                            _Process.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SABRInterpolation>) l

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".GetInterpolation") 
                                               [| _SwaptionVolCube1x.source
                                               ;  _Process.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _Process.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube1x_marketVolCube", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_marketVolCube
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).MarketVolCube
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".MarketVolCube") 
                                               [| _SwaptionVolCube1x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
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
        Other inspectors
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_marketVolCube", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_marketVolCube
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let _i = Helper.toCell<int> i "i" true
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).MarketVolCube1
                                                            _i.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".MarketVolCube") 
                                               [| _SwaptionVolCube1x.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _i.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube1x_recalibration", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_recalibration
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="beta",Description = "Reference to beta")>] 
         beta : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let _beta = Helper.toCell<double> beta "beta" true
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" true
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).Recalibration
                                                            _beta.cell 
                                                            _swapTenor.cell 
                                                       ) :> ICell
                let format (o : SwaptionVolCube1x) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".Recalibration") 
                                               [| _SwaptionVolCube1x.source
                                               ;  _beta.source
                                               ;  _swapTenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _beta.cell
                                ;  _swapTenor.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube1x_recalibration", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_recalibration
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="swapLengths",Description = "Reference to swapLengths")>] 
         swapLengths : obj)
        ([<ExcelArgument(Name="beta",Description = "Reference to beta")>] 
         beta : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let _swapLengths = Helper.toCell<Generic.List<Period>> swapLengths "swapLengths" true
                let _beta = Helper.toCell<Generic.List<double>> beta "beta" true
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" true
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).Recalibration1
                                                            _swapLengths.cell 
                                                            _beta.cell 
                                                            _swapTenor.cell 
                                                       ) :> ICell
                let format (o : SwaptionVolCube1x) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".Recalibration") 
                                               [| _SwaptionVolCube1x.source
                                               ;  _swapLengths.source
                                               ;  _beta.source
                                               ;  _swapTenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _swapLengths.cell
                                ;  _beta.cell
                                ;  _swapTenor.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube1x_recalibration", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_recalibration
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="beta",Description = "Reference to beta")>] 
         beta : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let _beta = Helper.toCell<Generic.List<double>> beta "beta" true
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" true
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).Recalibration2
                                                            _beta.cell 
                                                            _swapTenor.cell 
                                                       ) :> ICell
                let format (o : SwaptionVolCube1x) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".Recalibration") 
                                               [| _SwaptionVolCube1x.source
                                               ;  _beta.source
                                               ;  _swapTenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _beta.cell
                                ;  _swapTenor.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube1x_sabrCalibrationSection", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_sabrCalibrationSection
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="marketVolCube",Description = "Reference to marketVolCube")>] 
         marketVolCube : obj)
        ([<ExcelArgument(Name="parametersCube",Description = "Reference to parametersCube")>] 
         parametersCube : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let _marketVolCube = Helper.toCell<Cube.Cube> marketVolCube "marketVolCube" true
                let _parametersCube = Helper.toCell<Cube.Cube> parametersCube "parametersCube" true
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" true
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).SabrCalibrationSection
                                                            _marketVolCube.cell 
                                                            _parametersCube.cell 
                                                            _swapTenor.cell 
                                                       ) :> ICell
                let format (o : SwaptionVolCube1x) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".SabrCalibrationSection") 
                                               [| _SwaptionVolCube1x.source
                                               ;  _marketVolCube.source
                                               ;  _parametersCube.source
                                               ;  _swapTenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _marketVolCube.cell
                                ;  _parametersCube.cell
                                ;  _swapTenor.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube1x_sparseSabrParameters", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_sparseSabrParameters
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).SparseSabrParameters
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".SparseSabrParameters") 
                                               [| _SwaptionVolCube1x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube1x", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="atmVolStructure",Description = "Reference to atmVolStructure")>] 
         atmVolStructure : obj)
        ([<ExcelArgument(Name="optionTenors",Description = "Reference to optionTenors")>] 
         optionTenors : obj)
        ([<ExcelArgument(Name="swapTenors",Description = "Reference to swapTenors")>] 
         swapTenors : obj)
        ([<ExcelArgument(Name="strikeSpreads",Description = "Reference to strikeSpreads")>] 
         strikeSpreads : obj)
        ([<ExcelArgument(Name="volSpreads",Description = "Reference to volSpreads")>] 
         volSpreads : obj)
        ([<ExcelArgument(Name="swapIndexBase",Description = "Reference to swapIndexBase")>] 
         swapIndexBase : obj)
        ([<ExcelArgument(Name="shortSwapIndexBase",Description = "Reference to shortSwapIndexBase")>] 
         shortSwapIndexBase : obj)
        ([<ExcelArgument(Name="vegaWeightedSmileFit",Description = "Reference to vegaWeightedSmileFit")>] 
         vegaWeightedSmileFit : obj)
        ([<ExcelArgument(Name="parametersGuess",Description = "Reference to parametersGuess")>] 
         parametersGuess : obj)
        ([<ExcelArgument(Name="isParameterFixed",Description = "Reference to isParameterFixed")>] 
         isParameterFixed : obj)
        ([<ExcelArgument(Name="isAtmCalibrated",Description = "Reference to isAtmCalibrated")>] 
         isAtmCalibrated : obj)
        ([<ExcelArgument(Name="endCriteria",Description = "Reference to endCriteria")>] 
         endCriteria : obj)
        ([<ExcelArgument(Name="maxErrorTolerance",Description = "Reference to maxErrorTolerance")>] 
         maxErrorTolerance : obj)
        ([<ExcelArgument(Name="optMethod",Description = "Reference to optMethod")>] 
         optMethod : obj)
        ([<ExcelArgument(Name="errorAccept",Description = "Reference to errorAccept")>] 
         errorAccept : obj)
        ([<ExcelArgument(Name="useMaxError",Description = "Reference to useMaxError")>] 
         useMaxError : obj)
        ([<ExcelArgument(Name="maxGuesses",Description = "Reference to maxGuesses")>] 
         maxGuesses : obj)
        ([<ExcelArgument(Name="backwardFlat",Description = "Reference to backwardFlat")>] 
         backwardFlat : obj)
        ([<ExcelArgument(Name="cutoffStrike",Description = "Reference to cutoffStrike")>] 
         cutoffStrike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _atmVolStructure = Helper.toHandle<SwaptionVolatilityStructure> atmVolStructure "atmVolStructure" 
                let _optionTenors = Helper.toCell<Generic.List<Period>> optionTenors "optionTenors" true
                let _swapTenors = Helper.toCell<Generic.List<Period>> swapTenors "swapTenors" true
                let _strikeSpreads = Helper.toCell<Generic.List<double>> strikeSpreads "strikeSpreads" true
                let _volSpreads = Helper.toCell<Generic.List<Generic.List<Handle<Quote>>>> volSpreads "volSpreads" true
                let _swapIndexBase = Helper.toCell<SwapIndex> swapIndexBase "swapIndexBase" true
                let _shortSwapIndexBase = Helper.toCell<SwapIndex> shortSwapIndexBase "shortSwapIndexBase" true
                let _vegaWeightedSmileFit = Helper.toCell<bool> vegaWeightedSmileFit "vegaWeightedSmileFit" true
                let _parametersGuess = Helper.toCell<Generic.List<Generic.List<Handle<Quote>>>> parametersGuess "parametersGuess" true
                let _isParameterFixed = Helper.toCell<Generic.List<bool>> isParameterFixed "isParameterFixed" true
                let _isAtmCalibrated = Helper.toCell<bool> isAtmCalibrated "isAtmCalibrated" true
                let _endCriteria = Helper.toCell<EndCriteria> endCriteria "endCriteria" true
                let _maxErrorTolerance = Helper.toNullable<double> maxErrorTolerance "maxErrorTolerance"
                let _optMethod = Helper.toCell<OptimizationMethod> optMethod "optMethod" true
                let _errorAccept = Helper.toNullable<double> errorAccept "errorAccept"
                let _useMaxError = Helper.toCell<bool> useMaxError "useMaxError" true
                let _maxGuesses = Helper.toCell<int> maxGuesses "maxGuesses" true
                let _backwardFlat = Helper.toCell<bool> backwardFlat "backwardFlat" true
                let _cutoffStrike = Helper.toCell<double> cutoffStrike "cutoffStrike" true
                let builder () = withMnemonic mnemonic (Fun.SwaptionVolCube1x 
                                                            _atmVolStructure.cell 
                                                            _optionTenors.cell 
                                                            _swapTenors.cell 
                                                            _strikeSpreads.cell 
                                                            _volSpreads.cell 
                                                            _swapIndexBase.cell 
                                                            _shortSwapIndexBase.cell 
                                                            _vegaWeightedSmileFit.cell 
                                                            _parametersGuess.cell 
                                                            _isParameterFixed.cell 
                                                            _isAtmCalibrated.cell 
                                                            _endCriteria.cell 
                                                            _maxErrorTolerance.cell 
                                                            _optMethod.cell 
                                                            _errorAccept.cell 
                                                            _useMaxError.cell 
                                                            _maxGuesses.cell 
                                                            _backwardFlat.cell 
                                                            _cutoffStrike.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwaptionVolCube1x>) l

                let source = Helper.sourceFold "Fun.SwaptionVolCube1x" 
                                               [| _atmVolStructure.source
                                               ;  _optionTenors.source
                                               ;  _swapTenors.source
                                               ;  _strikeSpreads.source
                                               ;  _volSpreads.source
                                               ;  _swapIndexBase.source
                                               ;  _shortSwapIndexBase.source
                                               ;  _vegaWeightedSmileFit.source
                                               ;  _parametersGuess.source
                                               ;  _isParameterFixed.source
                                               ;  _isAtmCalibrated.source
                                               ;  _endCriteria.source
                                               ;  _maxErrorTolerance.source
                                               ;  _optMethod.source
                                               ;  _errorAccept.source
                                               ;  _useMaxError.source
                                               ;  _maxGuesses.source
                                               ;  _backwardFlat.source
                                               ;  _cutoffStrike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _atmVolStructure.cell
                                ;  _optionTenors.cell
                                ;  _swapTenors.cell
                                ;  _strikeSpreads.cell
                                ;  _volSpreads.cell
                                ;  _swapIndexBase.cell
                                ;  _shortSwapIndexBase.cell
                                ;  _vegaWeightedSmileFit.cell
                                ;  _parametersGuess.cell
                                ;  _isParameterFixed.cell
                                ;  _isAtmCalibrated.cell
                                ;  _endCriteria.cell
                                ;  _maxErrorTolerance.cell
                                ;  _optMethod.cell
                                ;  _errorAccept.cell
                                ;  _useMaxError.cell
                                ;  _maxGuesses.cell
                                ;  _backwardFlat.cell
                                ;  _cutoffStrike.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube1x_updateAfterRecalibration", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_updateAfterRecalibration
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).UpdateAfterRecalibration
                                                       ) :> ICell
                let format (o : SwaptionVolCube1x) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".UpdateAfterRecalibration") 
                                               [| _SwaptionVolCube1x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube1x_volCubeAtmCalibrated", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_volCubeAtmCalibrated
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).VolCubeAtmCalibrated
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".VolCubeAtmCalibrated") 
                                               [| _SwaptionVolCube1x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube1x_atmStrike", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_atmStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Reference to optionTenor")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" true
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" true
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).AtmStrike
                                                            _optionTenor.cell 
                                                            _swapTenor.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".AtmStrike") 
                                               [| _SwaptionVolCube1x.source
                                               ;  _optionTenor.source
                                               ;  _swapTenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _optionTenor.cell
                                ;  _swapTenor.cell
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
        Other inspectors
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_atmStrike", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_atmStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Reference to optionDate")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" true
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" true
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).AtmStrike1
                                                            _optionDate.cell 
                                                            _swapTenor.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".AtmStrike") 
                                               [| _SwaptionVolCube1x.source
                                               ;  _optionDate.source
                                               ;  _swapTenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _optionDate.cell
                                ;  _swapTenor.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube1x_atmVol", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_atmVol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).AtmVol
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<SwaptionVolatilityStructure>>) l

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".AtmVol") 
                                               [| _SwaptionVolCube1x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube1x_calendar", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".Calendar") 
                                               [| _SwaptionVolCube1x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
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
        TermStructure interface
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_dayCounter", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".DayCounter") 
                                               [| _SwaptionVolCube1x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube1x_maxDate", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".MaxDate") 
                                               [| _SwaptionVolCube1x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube1x_maxStrike", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_maxStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).MaxStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".MaxStrike") 
                                               [| _SwaptionVolCube1x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
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
        SwaptionVolatilityStructure interface
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_maxSwapTenor", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_maxSwapTenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).MaxSwapTenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".MaxSwapTenor") 
                                               [| _SwaptionVolCube1x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube1x_maxTime", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_maxTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).MaxTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".MaxTime") 
                                               [| _SwaptionVolCube1x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
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
        VolatilityTermStructure interface
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_minStrike", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_minStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).MinStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".MinStrike") 
                                               [| _SwaptionVolCube1x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube1x_referenceDate", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".ReferenceDate") 
                                               [| _SwaptionVolCube1x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube1x_settlementDays", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".SettlementDays") 
                                               [| _SwaptionVolCube1x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube1x_shortSwapIndexBase", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_shortSwapIndexBase
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).ShortSwapIndexBase
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".ShortSwapIndexBase") 
                                               [| _SwaptionVolCube1x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube1x_strikeSpreads", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_strikeSpreads
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).StrikeSpreads
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".StrikeSpreads") 
                                               [| _SwaptionVolCube1x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_SwaptionVolCube1x_swapIndexBase", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_swapIndexBase
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).SwapIndexBase
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".SwapIndexBase") 
                                               [| _SwaptionVolCube1x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube1x_vegaWeightedSmileFit", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_vegaWeightedSmileFit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).VegaWeightedSmileFit
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".VegaWeightedSmileFit") 
                                               [| _SwaptionVolCube1x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube1x_volatilityType", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_volatilityType
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).VolatilityType
                                                       ) :> ICell
                let format (o : VolatilityType) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".VolatilityType") 
                                               [| _SwaptionVolCube1x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube1x_volSpreads", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_volSpreads
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).VolSpreads
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Generic.List<ICell<Handle<Quote>>>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".VolSpreads") 
                                               [| _SwaptionVolCube1x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! additional inspectors
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_optionDateFromTime", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_optionDateFromTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="optionTime",Description = "Reference to optionTime")>] 
         optionTime : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let _optionTime = Helper.toCell<double> optionTime "optionTime" true
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).OptionDateFromTime
                                                            _optionTime.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".OptionDateFromTime") 
                                               [| _SwaptionVolCube1x.source
                                               ;  _optionTime.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _optionTime.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube1x_optionDates", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_optionDates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).OptionDates
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".OptionDates") 
                                               [| _SwaptionVolCube1x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_optionTenors", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_optionTenors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).OptionTenors
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Period>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".OptionTenors") 
                                               [| _SwaptionVolCube1x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_optionTimes", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_optionTimes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).OptionTimes
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".OptionTimes") 
                                               [| _SwaptionVolCube1x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_SwaptionVolCube1x_swapLengths", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_swapLengths
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).SwapLengths
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".SwapLengths") 
                                               [| _SwaptionVolCube1x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_SwaptionVolCube1x_swapTenors", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_swapTenors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).SwapTenors
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Period>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".SwapTenors") 
                                               [| _SwaptionVolCube1x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_update", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).Update
                                                       ) :> ICell
                let format (o : SwaptionVolCube1x) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".Update") 
                                               [| _SwaptionVolCube1x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
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
        ! returns the Black variance for a given option time and swap length
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_blackVariance", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_blackVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="optionTime",Description = "Reference to optionTime")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="swapLength",Description = "Reference to swapLength")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let _optionTime = Helper.toCell<double> optionTime "optionTime" true
                let _swapLength = Helper.toCell<double> swapLength "swapLength" true
                let _strike = Helper.toCell<double> strike "strike" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).BlackVariance
                                                            _optionTime.cell 
                                                            _swapLength.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".BlackVariance") 
                                               [| _SwaptionVolCube1x.source
                                               ;  _optionTime.source
                                               ;  _swapLength.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _optionTime.cell
                                ;  _swapLength.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! returns the Black variance for a given option date and swap length
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_blackVariance", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_blackVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Reference to optionDate")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="swapLength",Description = "Reference to swapLength")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" true
                let _swapLength = Helper.toCell<double> swapLength "swapLength" true
                let _strike = Helper.toCell<double> strike "strike" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).BlackVariance1
                                                            _optionDate.cell 
                                                            _swapLength.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".BlackVariance") 
                                               [| _SwaptionVolCube1x.source
                                               ;  _optionDate.source
                                               ;  _swapLength.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _optionDate.cell
                                ;  _swapLength.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! returns the Black variance for a given option tenor and swap length
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_blackVariance", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_blackVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Reference to optionTenor")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="swapLength",Description = "Reference to swapLength")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" true
                let _swapLength = Helper.toCell<double> swapLength "swapLength" true
                let _strike = Helper.toCell<double> strike "strike" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).BlackVariance2
                                                            _optionTenor.cell 
                                                            _swapLength.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".BlackVariance") 
                                               [| _SwaptionVolCube1x.source
                                               ;  _optionTenor.source
                                               ;  _swapLength.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _optionTenor.cell
                                ;  _swapLength.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! returns the Black variance for a given option time and swap tenor
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_blackVariance", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_blackVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="optionTime",Description = "Reference to optionTime")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let _optionTime = Helper.toCell<double> optionTime "optionTime" true
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" true
                let _strike = Helper.toCell<double> strike "strike" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).BlackVariance3
                                                            _optionTime.cell 
                                                            _swapTenor.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".BlackVariance") 
                                               [| _SwaptionVolCube1x.source
                                               ;  _optionTime.source
                                               ;  _swapTenor.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _optionTime.cell
                                ;  _swapTenor.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! returns the Black variance for a given option date and swap tenor
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_blackVariance", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_blackVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Reference to optionDate")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" true
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" true
                let _strike = Helper.toCell<double> strike "strike" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).BlackVariance4
                                                            _optionDate.cell 
                                                            _swapTenor.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".BlackVariance") 
                                               [| _SwaptionVolCube1x.source
                                               ;  _optionDate.source
                                               ;  _swapTenor.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _optionDate.cell
                                ;  _swapTenor.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! returns the Black variance for a given option tenor and swap tenor
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_blackVariance", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_blackVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Reference to optionTenor")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" true
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" true
                let _strike = Helper.toCell<double> strike "strike" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).BlackVariance5
                                                            _optionTenor.cell 
                                                            _swapTenor.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".BlackVariance") 
                                               [| _SwaptionVolCube1x.source
                                               ;  _optionTenor.source
                                               ;  _swapTenor.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _optionTenor.cell
                                ;  _swapTenor.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! the largest swapLength for which the term structure can return vols
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_maxSwapLength", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_maxSwapLength
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).MaxSwapLength
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".MaxSwapLength") 
                                               [| _SwaptionVolCube1x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
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
        ! returns the shift for a given option time and swap tenor
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_shift", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_shift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="optionTime",Description = "Reference to optionTime")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let _optionTime = Helper.toCell<double> optionTime "optionTime" true
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).Shift
                                                            _optionTime.cell 
                                                            _swapTenor.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".Shift") 
                                               [| _SwaptionVolCube1x.source
                                               ;  _optionTime.source
                                               ;  _swapTenor.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _optionTime.cell
                                ;  _swapTenor.cell
                                ;  _extrapolate.cell
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
        ! returns the shift for a given option date and swap tenor
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_shift", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_shift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Reference to optionDate")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" true
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).Shift1
                                                            _optionDate.cell 
                                                            _swapTenor.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".Shift") 
                                               [| _SwaptionVolCube1x.source
                                               ;  _optionDate.source
                                               ;  _swapTenor.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _optionDate.cell
                                ;  _swapTenor.cell
                                ;  _extrapolate.cell
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
        ! returns the shift for a given option date and swap length
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_shift", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_shift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Reference to optionDate")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="swapLength",Description = "Reference to swapLength")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" true
                let _swapLength = Helper.toCell<double> swapLength "swapLength" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).Shift2
                                                            _optionDate.cell 
                                                            _swapLength.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".Shift") 
                                               [| _SwaptionVolCube1x.source
                                               ;  _optionDate.source
                                               ;  _swapLength.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _optionDate.cell
                                ;  _swapLength.cell
                                ;  _extrapolate.cell
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
        ! returns the shift for a given option time and swap length
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_shift", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_shift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="optionTime",Description = "Reference to optionTime")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="swapLength",Description = "Reference to swapLength")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let _optionTime = Helper.toCell<double> optionTime "optionTime" true
                let _swapLength = Helper.toCell<double> swapLength "swapLength" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).Shift3
                                                            _optionTime.cell 
                                                            _swapLength.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".Shift") 
                                               [| _SwaptionVolCube1x.source
                                               ;  _optionTime.source
                                               ;  _swapLength.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _optionTime.cell
                                ;  _swapLength.cell
                                ;  _extrapolate.cell
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
        ! returns the shift for a given option tenor and swap tenor
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_shift", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_shift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Reference to optionTenor")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" true
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).Shift4
                                                            _optionTenor.cell 
                                                            _swapTenor.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".Shift") 
                                               [| _SwaptionVolCube1x.source
                                               ;  _optionTenor.source
                                               ;  _swapTenor.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _optionTenor.cell
                                ;  _swapTenor.cell
                                ;  _extrapolate.cell
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
        ! returns the shift for a given option tenor and swap length
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_shift", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_shift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Reference to optionTenor")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="swapLength",Description = "Reference to swapLength")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" true
                let _swapLength = Helper.toCell<double> swapLength "swapLength" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).Shift5
                                                            _optionTenor.cell 
                                                            _swapLength.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".Shift") 
                                               [| _SwaptionVolCube1x.source
                                               ;  _optionTenor.source
                                               ;  _swapLength.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _optionTenor.cell
                                ;  _swapLength.cell
                                ;  _extrapolate.cell
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
        ! returns the smile for a given option tenor and swap tenor
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_smileSection", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_smileSection
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Reference to optionTenor")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="extr",Description = "Reference to extr")>] 
         extr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" true
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" true
                let _extr = Helper.toCell<bool> extr "extr" true
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).SmileSection
                                                            _optionTenor.cell 
                                                            _swapTenor.cell 
                                                            _extr.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SmileSection>) l

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".SmileSection") 
                                               [| _SwaptionVolCube1x.source
                                               ;  _optionTenor.source
                                               ;  _swapTenor.source
                                               ;  _extr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _optionTenor.cell
                                ;  _swapTenor.cell
                                ;  _extr.cell
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
        ! returns the smile for a given option time and swap length
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_smileSection", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_smileSection
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="optionTime",Description = "Reference to optionTime")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="swapLength",Description = "Reference to swapLength")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="extr",Description = "Reference to extr")>] 
         extr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let _optionTime = Helper.toCell<double> optionTime "optionTime" true
                let _swapLength = Helper.toCell<double> swapLength "swapLength" true
                let _extr = Helper.toCell<bool> extr "extr" true
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).SmileSection1
                                                            _optionTime.cell 
                                                            _swapLength.cell 
                                                            _extr.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SmileSection>) l

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".SmileSection") 
                                               [| _SwaptionVolCube1x.source
                                               ;  _optionTime.source
                                               ;  _swapLength.source
                                               ;  _extr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _optionTime.cell
                                ;  _swapLength.cell
                                ;  _extr.cell
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
        ! returns the smile for a given option date and swap tenor
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_smileSection", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_smileSection
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Reference to optionDate")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="extr",Description = "Reference to extr")>] 
         extr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" true
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" true
                let _extr = Helper.toCell<bool> extr "extr" true
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).SmileSection2
                                                            _optionDate.cell 
                                                            _swapTenor.cell 
                                                            _extr.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SmileSection>) l

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".SmileSection") 
                                               [| _SwaptionVolCube1x.source
                                               ;  _optionDate.source
                                               ;  _swapTenor.source
                                               ;  _extr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _optionDate.cell
                                ;  _swapTenor.cell
                                ;  _extr.cell
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
        ! implements the conversion between swap dates and swap (time) length
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_swapLength", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_swapLength
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="start",Description = "Reference to start")>] 
         start : obj)
        ([<ExcelArgument(Name="End",Description = "Reference to End")>] 
         End : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let _start = Helper.toCell<Date> start "start" true
                let _End = Helper.toCell<Date> End "End" true
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).SwapLength
                                                            _start.cell 
                                                            _End.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".SwapLength") 
                                               [| _SwaptionVolCube1x.source
                                               ;  _start.source
                                               ;  _End.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _start.cell
                                ;  _End.cell
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
        ! implements the conversion between swap tenor and swap (time) length
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_swapLength", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_swapLength
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" true
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).SwapLength1
                                                            _swapTenor.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".SwapLength") 
                                               [| _SwaptionVolCube1x.source
                                               ;  _swapTenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _swapTenor.cell
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
        ! returns the volatility for a given option date and swap tenor
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_volatility", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Reference to optionDate")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" true
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" true
                let _strike = Helper.toCell<double> strike "strike" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).Volatility
                                                            _optionDate.cell 
                                                            _swapTenor.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".Volatility") 
                                               [| _SwaptionVolCube1x.source
                                               ;  _optionDate.source
                                               ;  _swapTenor.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _optionDate.cell
                                ;  _swapTenor.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! returns the volatility for a given option date and swap length
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_volatility", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Reference to optionDate")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="swapLength",Description = "Reference to swapLength")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" true
                let _swapLength = Helper.toCell<double> swapLength "swapLength" true
                let _strike = Helper.toCell<double> strike "strike" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).Volatility1
                                                            _optionDate.cell 
                                                            _swapLength.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".Volatility") 
                                               [| _SwaptionVolCube1x.source
                                               ;  _optionDate.source
                                               ;  _swapLength.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _optionDate.cell
                                ;  _swapLength.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! returns the volatility for a given option tenor and swap tenor
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_volatility", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Reference to optionTenor")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" true
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" true
                let _strike = Helper.toCell<double> strike "strike" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).Volatility2
                                                            _optionTenor.cell 
                                                            _swapTenor.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".Volatility") 
                                               [| _SwaptionVolCube1x.source
                                               ;  _optionTenor.source
                                               ;  _swapTenor.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _optionTenor.cell
                                ;  _swapTenor.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! returns the volatility for a given option tenor and swap length
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_volatility", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Reference to optionTenor")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="swapLength",Description = "Reference to swapLength")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" true
                let _swapLength = Helper.toCell<double> swapLength "swapLength" true
                let _strike = Helper.toCell<double> strike "strike" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).Volatility3
                                                            _optionTenor.cell 
                                                            _swapLength.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".Volatility") 
                                               [| _SwaptionVolCube1x.source
                                               ;  _optionTenor.source
                                               ;  _swapLength.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _optionTenor.cell
                                ;  _swapLength.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! returns the volatility for a given option time and swap length
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_volatility", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="optionTime",Description = "Reference to optionTime")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="swapLength",Description = "Reference to swapLength")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let _optionTime = Helper.toCell<double> optionTime "optionTime" true
                let _swapLength = Helper.toCell<double> swapLength "swapLength" true
                let _strike = Helper.toCell<double> strike "strike" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).Volatility4
                                                            _optionTime.cell 
                                                            _swapLength.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".Volatility") 
                                               [| _SwaptionVolCube1x.source
                                               ;  _optionTime.source
                                               ;  _swapLength.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _optionTime.cell
                                ;  _swapLength.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! returns the volatility for a given option time and swap tenor
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_volatility", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="optionTime",Description = "Reference to optionTime")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let _optionTime = Helper.toCell<double> optionTime "optionTime" true
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" true
                let _strike = Helper.toCell<double> strike "strike" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).Volatility5
                                                            _optionTime.cell 
                                                            _swapTenor.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".Volatility") 
                                               [| _SwaptionVolCube1x.source
                                               ;  _optionTime.source
                                               ;  _swapTenor.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _optionTime.cell
                                ;  _swapTenor.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! the business day convention used in tenor to date conversion
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_businessDayConvention", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".BusinessDayConvention") 
                                               [| _SwaptionVolCube1x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
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
        ! period/date conversion
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_optionDateFromTenor", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_optionDateFromTenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="p",Description = "Reference to p")>] 
         p : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let _p = Helper.toCell<Period> p "p" true
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).OptionDateFromTenor
                                                            _p.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".OptionDateFromTenor") 
                                               [| _SwaptionVolCube1x.source
                                               ;  _p.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _p.cell
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
        ! date/time conversion
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_timeFromReference", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_timeFromReference
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let _date = Helper.toCell<Date> date "date" true
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).TimeFromReference
                                                            _date.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".TimeFromReference") 
                                               [| _SwaptionVolCube1x.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _date.cell
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
        some extra functionality
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_allowsExtrapolation", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".AllowsExtrapolation") 
                                               [| _SwaptionVolCube1x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
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
        ! enable extrapolation in subsequent calls
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_disableExtrapolation", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let _b = Helper.toCell<bool> b "b" true
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : SwaptionVolCube1x) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".DisableExtrapolation") 
                                               [| _SwaptionVolCube1x.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _b.cell
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
        ! tells whether extrapolation is enabled
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_enableExtrapolation", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let _b = Helper.toCell<bool> b "b" true
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : SwaptionVolCube1x) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".EnableExtrapolation") 
                                               [| _SwaptionVolCube1x.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _b.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube1x_extrapolate", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "Reference to SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x" true 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube1x.cell :?> SwaptionVolCube1xModel).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SwaptionVolCube1x.source + ".Extrapolate") 
                                               [| _SwaptionVolCube1x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube1x_Range", Description="Create a range of SwaptionVolCube1x",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the SwaptionVolCube1x")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SwaptionVolCube1x> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<SwaptionVolCube1x>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<SwaptionVolCube1x>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<SwaptionVolCube1x>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)