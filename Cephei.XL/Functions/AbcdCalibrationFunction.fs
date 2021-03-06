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
module AbcdCalibrationFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_AbcdCalibration_a", Description="Create a AbcdCalibration",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AbcdCalibration_a
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdCalibration",Description = "AbcdCalibration")>] 
         abcdcalibration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdCalibration = Helper.toModelReference<AbcdCalibration> abcdcalibration "AbcdCalibration"  
                let builder (current : ICell) = ((AbcdCalibrationModel.Cast _AbcdCalibration.cell).A
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AbcdCalibration.source + ".A") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AbcdCalibration.cell
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
    [<ExcelFunction(Name="_AbcdCalibration_abcdBlackVolatility", Description="Create a AbcdCalibration",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AbcdCalibration_abcdBlackVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdCalibration",Description = "AbcdCalibration")>] 
         abcdcalibration : obj)
        ([<ExcelArgument(Name="u",Description = "double")>] 
         u : obj)
        ([<ExcelArgument(Name="a",Description = "double")>] 
         a : obj)
        ([<ExcelArgument(Name="b",Description = "double")>] 
         b : obj)
        ([<ExcelArgument(Name="c",Description = "double")>] 
         c : obj)
        ([<ExcelArgument(Name="d",Description = "double")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdCalibration = Helper.toModelReference<AbcdCalibration> abcdcalibration "AbcdCalibration"  
                let _u = Helper.toCell<double> u "u" 
                let _a = Helper.toCell<double> a "a" 
                let _b = Helper.toCell<double> b "b" 
                let _c = Helper.toCell<double> c "c" 
                let _d = Helper.toCell<double> d "d" 
                let builder (current : ICell) = ((AbcdCalibrationModel.Cast _AbcdCalibration.cell).AbcdBlackVolatility
                                                            _u.cell 
                                                            _a.cell 
                                                            _b.cell 
                                                            _c.cell 
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AbcdCalibration.source + ".AbcdBlackVolatility") 

                                               [| _u.source
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
        to constrained <- from unconstrained
    *)
    [<ExcelFunction(Name="_AbcdCalibration1", Description="Create a AbcdCalibration",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AbcdCalibration_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="t",Description = "double range")>] 
         t : obj)
        ([<ExcelArgument(Name="blackVols",Description = "double range")>] 
         blackVols : obj)
        ([<ExcelArgument(Name="aGuess",Description = "double or empty")>] 
         aGuess : obj)
        ([<ExcelArgument(Name="bGuess",Description = "double or empty")>] 
         bGuess : obj)
        ([<ExcelArgument(Name="cGuess",Description = "double or empty")>] 
         cGuess : obj)
        ([<ExcelArgument(Name="dGuess",Description = "double or empty")>] 
         dGuess : obj)
        ([<ExcelArgument(Name="aIsFixed",Description = "bool or empty")>] 
         aIsFixed : obj)
        ([<ExcelArgument(Name="bIsFixed",Description = "bool or empty")>] 
         bIsFixed : obj)
        ([<ExcelArgument(Name="cIsFixed",Description = "bool or empty")>] 
         cIsFixed : obj)
        ([<ExcelArgument(Name="dIsFixed",Description = "bool or empty")>] 
         dIsFixed : obj)
        ([<ExcelArgument(Name="vegaWeighted",Description = "bool or empty")>] 
         vegaWeighted : obj)
        ([<ExcelArgument(Name="endCriteria",Description = "EndCriteria or empty")>] 
         endCriteria : obj)
        ([<ExcelArgument(Name="Method",Description = "OptimizationMethod")>] 
         Method : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _t = Helper.toCell<Generic.List<double>> t "t" 
                let _blackVols = Helper.toCell<Generic.List<double>> blackVols "blackVols" 
                let _aGuess = Helper.toDefault<double> aGuess "aGuess" -0.06
                let _bGuess = Helper.toDefault<double> bGuess "bGuess" 0.17
                let _cGuess = Helper.toDefault<double> cGuess "cGuess" 0.54
                let _dGuess = Helper.toDefault<double> dGuess "dGuess" 0.17
                let _aIsFixed = Helper.toDefault<bool> aIsFixed "aIsFixed" false
                let _bIsFixed = Helper.toDefault<bool> bIsFixed "bIsFixed" false
                let _cIsFixed = Helper.toDefault<bool> cIsFixed "cIsFixed" false
                let _dIsFixed = Helper.toDefault<bool> dIsFixed "dIsFixed" false
                let _vegaWeighted = Helper.toDefault<bool> vegaWeighted "vegaWeighted" false
                let _endCriteria = Helper.toDefault<EndCriteria> endCriteria "endCriteria" null
                let _Method = Helper.toCell<OptimizationMethod> Method "Method" 
                let builder (current : ICell) = (Fun.AbcdCalibration1
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

                let source () = Helper.sourceFold "Fun.AbcdCalibration1" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AbcdCalibration> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AbcdCalibration", Description="Create a AbcdCalibration",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AbcdCalibration_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = (Fun.AbcdCalibration ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AbcdCalibration>) l

                let source () = Helper.sourceFold "Fun.AbcdCalibration" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AbcdCalibration> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AbcdCalibration_aIsFixed_", Description="Create a AbcdCalibration",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AbcdCalibration_aIsFixed_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdCalibration",Description = "AbcdCalibration")>] 
         abcdcalibration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdCalibration = Helper.toModelReference<AbcdCalibration> abcdcalibration "AbcdCalibration"  
                let builder (current : ICell) = ((AbcdCalibrationModel.Cast _AbcdCalibration.cell).AIsFixed_
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AbcdCalibration.source + ".AIsFixed_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AbcdCalibration.cell
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
    [<ExcelFunction(Name="_AbcdCalibration_b", Description="Create a AbcdCalibration",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AbcdCalibration_b
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdCalibration",Description = "AbcdCalibration")>] 
         abcdcalibration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdCalibration = Helper.toModelReference<AbcdCalibration> abcdcalibration "AbcdCalibration"  
                let builder (current : ICell) = ((AbcdCalibrationModel.Cast _AbcdCalibration.cell).B
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AbcdCalibration.source + ".B") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AbcdCalibration.cell
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
    [<ExcelFunction(Name="_AbcdCalibration_bIsFixed_", Description="Create a AbcdCalibration",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AbcdCalibration_bIsFixed_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdCalibration",Description = "AbcdCalibration")>] 
         abcdcalibration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdCalibration = Helper.toModelReference<AbcdCalibration> abcdcalibration "AbcdCalibration"  
                let builder (current : ICell) = ((AbcdCalibrationModel.Cast _AbcdCalibration.cell).BIsFixed_
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AbcdCalibration.source + ".BIsFixed_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AbcdCalibration.cell
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
    [<ExcelFunction(Name="_AbcdCalibration_c", Description="Create a AbcdCalibration",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AbcdCalibration_c
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdCalibration",Description = "AbcdCalibration")>] 
         abcdcalibration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdCalibration = Helper.toModelReference<AbcdCalibration> abcdcalibration "AbcdCalibration"  
                let builder (current : ICell) = ((AbcdCalibrationModel.Cast _AbcdCalibration.cell).C
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AbcdCalibration.source + ".C") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AbcdCalibration.cell
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
    [<ExcelFunction(Name="_AbcdCalibration_cIsFixed_", Description="Create a AbcdCalibration",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AbcdCalibration_cIsFixed_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdCalibration",Description = "AbcdCalibration")>] 
         abcdcalibration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdCalibration = Helper.toModelReference<AbcdCalibration> abcdcalibration "AbcdCalibration"  
                let builder (current : ICell) = ((AbcdCalibrationModel.Cast _AbcdCalibration.cell).CIsFixed_
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AbcdCalibration.source + ".CIsFixed_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AbcdCalibration.cell
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
    [<ExcelFunction(Name="_AbcdCalibration_compute", Description="Create a AbcdCalibration",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AbcdCalibration_compute
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdCalibration",Description = "AbcdCalibration")>] 
         abcdcalibration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdCalibration = Helper.toModelReference<AbcdCalibration> abcdcalibration "AbcdCalibration"  
                let builder (current : ICell) = ((AbcdCalibrationModel.Cast _AbcdCalibration.cell).Compute
                                                       ) :> ICell
                let format (o : AbcdCalibration) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AbcdCalibration.source + ".Compute") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AbcdCalibration.cell
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
    [<ExcelFunction(Name="_AbcdCalibration_d", Description="Create a AbcdCalibration",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AbcdCalibration_d
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdCalibration",Description = "AbcdCalibration")>] 
         abcdcalibration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdCalibration = Helper.toModelReference<AbcdCalibration> abcdcalibration "AbcdCalibration"  
                let builder (current : ICell) = ((AbcdCalibrationModel.Cast _AbcdCalibration.cell).D
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AbcdCalibration.source + ".D") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AbcdCalibration.cell
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
    [<ExcelFunction(Name="_AbcdCalibration_dIsFixed_", Description="Create a AbcdCalibration",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AbcdCalibration_dIsFixed_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdCalibration",Description = "AbcdCalibration")>] 
         abcdcalibration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdCalibration = Helper.toModelReference<AbcdCalibration> abcdcalibration "AbcdCalibration"  
                let builder (current : ICell) = ((AbcdCalibrationModel.Cast _AbcdCalibration.cell).DIsFixed_
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AbcdCalibration.source + ".DIsFixed_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AbcdCalibration.cell
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
    [<ExcelFunction(Name="_AbcdCalibration_endCriteria", Description="Create a AbcdCalibration",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AbcdCalibration_endCriteria
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdCalibration",Description = "AbcdCalibration")>] 
         abcdcalibration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdCalibration = Helper.toModelReference<AbcdCalibration> abcdcalibration "AbcdCalibration"  
                let builder (current : ICell) = ((AbcdCalibrationModel.Cast _AbcdCalibration.cell).EndCriteria
                                                       ) :> ICell
                let format (o : EndCriteria.Type) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AbcdCalibration.source + ".EndCriteria") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AbcdCalibration.cell
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
    [<ExcelFunction(Name="_AbcdCalibration_error", Description="Create a AbcdCalibration",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AbcdCalibration_error
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdCalibration",Description = "AbcdCalibration")>] 
         abcdcalibration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdCalibration = Helper.toModelReference<AbcdCalibration> abcdcalibration "AbcdCalibration"  
                let builder (current : ICell) = ((AbcdCalibrationModel.Cast _AbcdCalibration.cell).Error
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AbcdCalibration.source + ".Error") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AbcdCalibration.cell
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
    [<ExcelFunction(Name="_AbcdCalibration_errors", Description="Create a AbcdCalibration",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AbcdCalibration_errors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdCalibration",Description = "AbcdCalibration")>] 
         abcdcalibration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdCalibration = Helper.toModelReference<AbcdCalibration> abcdcalibration "AbcdCalibration"  
                let builder (current : ICell) = ((AbcdCalibrationModel.Cast _AbcdCalibration.cell).Errors
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_AbcdCalibration.source + ".Errors") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AbcdCalibration.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AbcdCalibration> format
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
    [<ExcelFunction(Name="_AbcdCalibration_k", Description="Create a AbcdCalibration",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AbcdCalibration_k
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdCalibration",Description = "AbcdCalibration")>] 
         abcdcalibration : obj)
        ([<ExcelArgument(Name="t",Description = "double range")>] 
         t : obj)
        ([<ExcelArgument(Name="blackVols",Description = "double range")>] 
         blackVols : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdCalibration = Helper.toModelReference<AbcdCalibration> abcdcalibration "AbcdCalibration"  
                let _t = Helper.toCell<Generic.List<double>> t "t" 
                let _blackVols = Helper.toCell<Generic.List<double>> blackVols "blackVols" 
                let builder (current : ICell) = ((AbcdCalibrationModel.Cast _AbcdCalibration.cell).K
                                                            _t.cell 
                                                            _blackVols.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_AbcdCalibration.source + ".K") 

                                               [| _t.source
                                               ;  _blackVols.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdCalibration.cell
                                ;  _t.cell
                                ;  _blackVols.cell
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
    [<ExcelFunction(Name="_AbcdCalibration_maxError", Description="Create a AbcdCalibration",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AbcdCalibration_maxError
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdCalibration",Description = "AbcdCalibration")>] 
         abcdcalibration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdCalibration = Helper.toModelReference<AbcdCalibration> abcdcalibration "AbcdCalibration"  
                let builder (current : ICell) = ((AbcdCalibrationModel.Cast _AbcdCalibration.cell).MaxError
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AbcdCalibration.source + ".MaxError") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AbcdCalibration.cell
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
    [<ExcelFunction(Name="_AbcdCalibration_transformation_", Description="Create a AbcdCalibration",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AbcdCalibration_transformation_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdCalibration",Description = "AbcdCalibration")>] 
         abcdcalibration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdCalibration = Helper.toModelReference<AbcdCalibration> abcdcalibration "AbcdCalibration"  
                let builder (current : ICell) = ((AbcdCalibrationModel.Cast _AbcdCalibration.cell).Transformation_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IParametersTransformation>) l

                let source () = Helper.sourceFold (_AbcdCalibration.source + ".Transformation_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AbcdCalibration.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AbcdCalibration> format
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
    [<ExcelFunction(Name="_AbcdCalibration_value", Description="Create a AbcdCalibration",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AbcdCalibration_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdCalibration",Description = "AbcdCalibration")>] 
         abcdcalibration : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdCalibration = Helper.toModelReference<AbcdCalibration> abcdcalibration "AbcdCalibration"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = ((AbcdCalibrationModel.Cast _AbcdCalibration.cell).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AbcdCalibration.source + ".Value") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdCalibration.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_AbcdCalibration_Range", Description="Create a range of AbcdCalibration",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AbcdCalibration_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<AbcdCalibration> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<AbcdCalibration> (c)) :> ICell
                let format (i : Cephei.Cell.List<AbcdCalibration>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<AbcdCalibration>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
