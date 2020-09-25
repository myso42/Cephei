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
module AbcdCalibrationFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_AbcdCalibration_a", Description="Create a AbcdCalibration",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdCalibration_a
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdCalibration",Description = "Reference to AbcdCalibration")>] 
         abcdcalibration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdCalibration = Helper.toCell<AbcdCalibration> abcdcalibration "AbcdCalibration" true 
                let builder () = withMnemonic mnemonic ((_AbcdCalibration.cell :?> AbcdCalibrationModel).A
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AbcdCalibration.source + ".A") 
                                               [| _AbcdCalibration.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdCalibration.cell
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
    [<ExcelFunction(Name="_AbcdCalibration_abcdBlackVolatility", Description="Create a AbcdCalibration",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdCalibration_abcdBlackVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdCalibration",Description = "Reference to AbcdCalibration")>] 
         abcdcalibration : obj)
        ([<ExcelArgument(Name="u",Description = "Reference to u")>] 
         u : obj)
        ([<ExcelArgument(Name="a",Description = "Reference to a")>] 
         a : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdCalibration = Helper.toCell<AbcdCalibration> abcdcalibration "AbcdCalibration" true 
                let _u = Helper.toCell<double> u "u" true
                let _a = Helper.toCell<double> a "a" true
                let _b = Helper.toCell<double> b "b" true
                let _c = Helper.toCell<double> c "c" true
                let _d = Helper.toCell<double> d "d" true
                let builder () = withMnemonic mnemonic ((_AbcdCalibration.cell :?> AbcdCalibrationModel).AbcdBlackVolatility
                                                            _u.cell 
                                                            _a.cell 
                                                            _b.cell 
                                                            _c.cell 
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AbcdCalibration.source + ".AbcdBlackVolatility") 
                                               [| _AbcdCalibration.source
                                               ;  _u.source
                                               ;  _a.source
                                               ;  _b.source
                                               ;  _c.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdCalibration.cell
                                ;  _u.cell
                                ;  _a.cell
                                ;  _b.cell
                                ;  _c.cell
                                ;  _d.cell
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
        to constrained <- from unconstrained
    *)
    [<ExcelFunction(Name="_AbcdCalibration1", Description="Create a AbcdCalibration",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdCalibration_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="blackVols",Description = "Reference to blackVols")>] 
         blackVols : obj)
        ([<ExcelArgument(Name="aGuess",Description = "Reference to aGuess")>] 
         aGuess : obj)
        ([<ExcelArgument(Name="bGuess",Description = "Reference to bGuess")>] 
         bGuess : obj)
        ([<ExcelArgument(Name="cGuess",Description = "Reference to cGuess")>] 
         cGuess : obj)
        ([<ExcelArgument(Name="dGuess",Description = "Reference to dGuess")>] 
         dGuess : obj)
        ([<ExcelArgument(Name="aIsFixed",Description = "Reference to aIsFixed")>] 
         aIsFixed : obj)
        ([<ExcelArgument(Name="bIsFixed",Description = "Reference to bIsFixed")>] 
         bIsFixed : obj)
        ([<ExcelArgument(Name="cIsFixed",Description = "Reference to cIsFixed")>] 
         cIsFixed : obj)
        ([<ExcelArgument(Name="dIsFixed",Description = "Reference to dIsFixed")>] 
         dIsFixed : obj)
        ([<ExcelArgument(Name="vegaWeighted",Description = "Reference to vegaWeighted")>] 
         vegaWeighted : obj)
        ([<ExcelArgument(Name="endCriteria",Description = "Reference to endCriteria")>] 
         endCriteria : obj)
        ([<ExcelArgument(Name="Method",Description = "Reference to Method")>] 
         Method : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _t = Helper.toCell<Generic.List<double>> t "t" true
                let _blackVols = Helper.toCell<Generic.List<double>> blackVols "blackVols" true
                let _aGuess = Helper.toCell<double> aGuess "aGuess" true
                let _bGuess = Helper.toCell<double> bGuess "bGuess" true
                let _cGuess = Helper.toCell<double> cGuess "cGuess" true
                let _dGuess = Helper.toCell<double> dGuess "dGuess" true
                let _aIsFixed = Helper.toCell<bool> aIsFixed "aIsFixed" true
                let _bIsFixed = Helper.toCell<bool> bIsFixed "bIsFixed" true
                let _cIsFixed = Helper.toCell<bool> cIsFixed "cIsFixed" true
                let _dIsFixed = Helper.toCell<bool> dIsFixed "dIsFixed" true
                let _vegaWeighted = Helper.toCell<bool> vegaWeighted "vegaWeighted" true
                let _endCriteria = Helper.toCell<EndCriteria> endCriteria "endCriteria" true
                let _Method = Helper.toCell<OptimizationMethod> Method "Method" true
                let builder () = withMnemonic mnemonic (Fun.AbcdCalibration1
                                                            _t.cell 
                                                            _blackVols.cell 
                                                            _aGuess.cell 
                                                            _bGuess.cell 
                                                            _cGuess.cell 
                                                            _dGuess.cell 
                                                            _aIsFixed.cell 
                                                            _bIsFixed.cell 
                                                            _cIsFixed.cell 
                                                            _dIsFixed.cell 
                                                            _vegaWeighted.cell 
                                                            _endCriteria.cell 
                                                            _Method.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AbcdCalibration>) l

                let source = Helper.sourceFold "Fun.AbcdCalibration1" 
                                               [| _t.source
                                               ;  _blackVols.source
                                               ;  _aGuess.source
                                               ;  _bGuess.source
                                               ;  _cGuess.source
                                               ;  _dGuess.source
                                               ;  _aIsFixed.source
                                               ;  _bIsFixed.source
                                               ;  _cIsFixed.source
                                               ;  _dIsFixed.source
                                               ;  _vegaWeighted.source
                                               ;  _endCriteria.source
                                               ;  _Method.source
                                               |]
                let hash = Helper.hashFold 
                                [| _t.cell
                                ;  _blackVols.cell
                                ;  _aGuess.cell
                                ;  _bGuess.cell
                                ;  _cGuess.cell
                                ;  _dGuess.cell
                                ;  _aIsFixed.cell
                                ;  _bIsFixed.cell
                                ;  _cIsFixed.cell
                                ;  _dIsFixed.cell
                                ;  _vegaWeighted.cell
                                ;  _endCriteria.cell
                                ;  _Method.cell
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
    [<ExcelFunction(Name="_AbcdCalibration", Description="Create a AbcdCalibration",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdCalibration_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.AbcdCalibration ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AbcdCalibration>) l

                let source = Helper.sourceFold "Fun.AbcdCalibration" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
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
    [<ExcelFunction(Name="_AbcdCalibration_aIsFixed_", Description="Create a AbcdCalibration",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdCalibration_aIsFixed_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdCalibration",Description = "Reference to AbcdCalibration")>] 
         abcdcalibration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdCalibration = Helper.toCell<AbcdCalibration> abcdcalibration "AbcdCalibration" true 
                let builder () = withMnemonic mnemonic ((_AbcdCalibration.cell :?> AbcdCalibrationModel).AIsFixed_
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AbcdCalibration.source + ".AIsFixed_") 
                                               [| _AbcdCalibration.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdCalibration.cell
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
    [<ExcelFunction(Name="_AbcdCalibration_b", Description="Create a AbcdCalibration",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdCalibration_b
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdCalibration",Description = "Reference to AbcdCalibration")>] 
         abcdcalibration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdCalibration = Helper.toCell<AbcdCalibration> abcdcalibration "AbcdCalibration" true 
                let builder () = withMnemonic mnemonic ((_AbcdCalibration.cell :?> AbcdCalibrationModel).B
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AbcdCalibration.source + ".B") 
                                               [| _AbcdCalibration.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdCalibration.cell
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
    [<ExcelFunction(Name="_AbcdCalibration_bIsFixed_", Description="Create a AbcdCalibration",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdCalibration_bIsFixed_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdCalibration",Description = "Reference to AbcdCalibration")>] 
         abcdcalibration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdCalibration = Helper.toCell<AbcdCalibration> abcdcalibration "AbcdCalibration" true 
                let builder () = withMnemonic mnemonic ((_AbcdCalibration.cell :?> AbcdCalibrationModel).BIsFixed_
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AbcdCalibration.source + ".BIsFixed_") 
                                               [| _AbcdCalibration.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdCalibration.cell
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
    [<ExcelFunction(Name="_AbcdCalibration_c", Description="Create a AbcdCalibration",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdCalibration_c
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdCalibration",Description = "Reference to AbcdCalibration")>] 
         abcdcalibration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdCalibration = Helper.toCell<AbcdCalibration> abcdcalibration "AbcdCalibration" true 
                let builder () = withMnemonic mnemonic ((_AbcdCalibration.cell :?> AbcdCalibrationModel).C
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AbcdCalibration.source + ".C") 
                                               [| _AbcdCalibration.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdCalibration.cell
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
    [<ExcelFunction(Name="_AbcdCalibration_cIsFixed_", Description="Create a AbcdCalibration",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdCalibration_cIsFixed_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdCalibration",Description = "Reference to AbcdCalibration")>] 
         abcdcalibration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdCalibration = Helper.toCell<AbcdCalibration> abcdcalibration "AbcdCalibration" true 
                let builder () = withMnemonic mnemonic ((_AbcdCalibration.cell :?> AbcdCalibrationModel).CIsFixed_
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AbcdCalibration.source + ".CIsFixed_") 
                                               [| _AbcdCalibration.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdCalibration.cell
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
    [<ExcelFunction(Name="_AbcdCalibration_compute", Description="Create a AbcdCalibration",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdCalibration_compute
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdCalibration",Description = "Reference to AbcdCalibration")>] 
         abcdcalibration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdCalibration = Helper.toCell<AbcdCalibration> abcdcalibration "AbcdCalibration" true 
                let builder () = withMnemonic mnemonic ((_AbcdCalibration.cell :?> AbcdCalibrationModel).Compute
                                                       ) :> ICell
                let format (o : AbcdCalibration) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AbcdCalibration.source + ".Compute") 
                                               [| _AbcdCalibration.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdCalibration.cell
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
    [<ExcelFunction(Name="_AbcdCalibration_d", Description="Create a AbcdCalibration",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdCalibration_d
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdCalibration",Description = "Reference to AbcdCalibration")>] 
         abcdcalibration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdCalibration = Helper.toCell<AbcdCalibration> abcdcalibration "AbcdCalibration" true 
                let builder () = withMnemonic mnemonic ((_AbcdCalibration.cell :?> AbcdCalibrationModel).D
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AbcdCalibration.source + ".D") 
                                               [| _AbcdCalibration.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdCalibration.cell
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
    [<ExcelFunction(Name="_AbcdCalibration_dIsFixed_", Description="Create a AbcdCalibration",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdCalibration_dIsFixed_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdCalibration",Description = "Reference to AbcdCalibration")>] 
         abcdcalibration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdCalibration = Helper.toCell<AbcdCalibration> abcdcalibration "AbcdCalibration" true 
                let builder () = withMnemonic mnemonic ((_AbcdCalibration.cell :?> AbcdCalibrationModel).DIsFixed_
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AbcdCalibration.source + ".DIsFixed_") 
                                               [| _AbcdCalibration.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdCalibration.cell
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
    [<ExcelFunction(Name="_AbcdCalibration_endCriteria", Description="Create a AbcdCalibration",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdCalibration_endCriteria
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdCalibration",Description = "Reference to AbcdCalibration")>] 
         abcdcalibration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdCalibration = Helper.toCell<AbcdCalibration> abcdcalibration "AbcdCalibration" true 
                let builder () = withMnemonic mnemonic ((_AbcdCalibration.cell :?> AbcdCalibrationModel).EndCriteria
                                                       ) :> ICell
                let format (o : EndCriteria.Type) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AbcdCalibration.source + ".EndCriteria") 
                                               [| _AbcdCalibration.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdCalibration.cell
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
    [<ExcelFunction(Name="_AbcdCalibration_error", Description="Create a AbcdCalibration",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdCalibration_error
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdCalibration",Description = "Reference to AbcdCalibration")>] 
         abcdcalibration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdCalibration = Helper.toCell<AbcdCalibration> abcdcalibration "AbcdCalibration" true 
                let builder () = withMnemonic mnemonic ((_AbcdCalibration.cell :?> AbcdCalibrationModel).Error
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AbcdCalibration.source + ".Error") 
                                               [| _AbcdCalibration.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdCalibration.cell
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
    [<ExcelFunction(Name="_AbcdCalibration_errors", Description="Create a AbcdCalibration",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdCalibration_errors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdCalibration",Description = "Reference to AbcdCalibration")>] 
         abcdcalibration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdCalibration = Helper.toCell<AbcdCalibration> abcdcalibration "AbcdCalibration" true 
                let builder () = withMnemonic mnemonic ((_AbcdCalibration.cell :?> AbcdCalibrationModel).Errors
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_AbcdCalibration.source + ".Errors") 
                                               [| _AbcdCalibration.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdCalibration.cell
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
        ! adjustment factors needed to match Black vols
    *)
    [<ExcelFunction(Name="_AbcdCalibration_k", Description="Create a AbcdCalibration",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdCalibration_k
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdCalibration",Description = "Reference to AbcdCalibration")>] 
         abcdcalibration : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="blackVols",Description = "Reference to blackVols")>] 
         blackVols : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdCalibration = Helper.toCell<AbcdCalibration> abcdcalibration "AbcdCalibration" true 
                let _t = Helper.toCell<Generic.List<double>> t "t" true
                let _blackVols = Helper.toCell<Generic.List<double>> blackVols "blackVols" true
                let builder () = withMnemonic mnemonic ((_AbcdCalibration.cell :?> AbcdCalibrationModel).K
                                                            _t.cell 
                                                            _blackVols.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_AbcdCalibration.source + ".K") 
                                               [| _AbcdCalibration.source
                                               ;  _t.source
                                               ;  _blackVols.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdCalibration.cell
                                ;  _t.cell
                                ;  _blackVols.cell
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
    [<ExcelFunction(Name="_AbcdCalibration_maxError", Description="Create a AbcdCalibration",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdCalibration_maxError
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdCalibration",Description = "Reference to AbcdCalibration")>] 
         abcdcalibration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdCalibration = Helper.toCell<AbcdCalibration> abcdcalibration "AbcdCalibration" true 
                let builder () = withMnemonic mnemonic ((_AbcdCalibration.cell :?> AbcdCalibrationModel).MaxError
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AbcdCalibration.source + ".MaxError") 
                                               [| _AbcdCalibration.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdCalibration.cell
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
    [<ExcelFunction(Name="_AbcdCalibration_transformation_", Description="Create a AbcdCalibration",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdCalibration_transformation_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdCalibration",Description = "Reference to AbcdCalibration")>] 
         abcdcalibration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdCalibration = Helper.toCell<AbcdCalibration> abcdcalibration "AbcdCalibration" true 
                let builder () = withMnemonic mnemonic ((_AbcdCalibration.cell :?> AbcdCalibrationModel).Transformation_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IParametersTransformation>) l

                let source = Helper.sourceFold (_AbcdCalibration.source + ".Transformation_") 
                                               [| _AbcdCalibration.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdCalibration.cell
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
        calibration results
    *)
    [<ExcelFunction(Name="_AbcdCalibration_value", Description="Create a AbcdCalibration",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdCalibration_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdCalibration",Description = "Reference to AbcdCalibration")>] 
         abcdcalibration : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdCalibration = Helper.toCell<AbcdCalibration> abcdcalibration "AbcdCalibration" true 
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_AbcdCalibration.cell :?> AbcdCalibrationModel).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AbcdCalibration.source + ".Value") 
                                               [| _AbcdCalibration.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdCalibration.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_AbcdCalibration_Range", Description="Create a range of AbcdCalibration",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdCalibration_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the AbcdCalibration")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<AbcdCalibration> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<AbcdCalibration>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<AbcdCalibration>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<AbcdCalibration>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"