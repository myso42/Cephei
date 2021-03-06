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
===========================================================================// NumericHaganPricer                    // ===========================================================================//   Prices a cms coupon via static replication as in Hagan's "Conundrums..." article via numerical integration based on prices of vanilla swaptions
  </summary> *)
[<AutoSerializable(true)>]
module NumericHaganPricerFunction =
(*!!
    (*
        
    *)
    [<ExcelFunction(Name="_NumericHaganPricer_integrate", Description="Create a NumericHaganPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NumericHaganPricer_integrate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NumericHaganPricer",Description = "NumericHaganPricer")>] 
         numerichaganpricer : obj)
        ([<ExcelArgument(Name="a",Description = "double")>] 
         a : obj)
        ([<ExcelArgument(Name="b",Description = "double")>] 
         b : obj)
        ([<ExcelArgument(Name="integrand",Description = "ConundrumIntegrand.ConundrumIntegrand")>] 
         integrand : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NumericHaganPricer = Helper.toModelReference<NumericHaganPricer> numerichaganpricer "NumericHaganPricer"  
                let _a = Helper.toCell<double> a "a" 
                let _b = Helper.toCell<double> b "b" 
                let _integrand = Helper.toCell<ConundrumIntegrand.ConundrumIntegrand> integrand "integrand" 
                let builder (current : ICell) = ((NumericHaganPricerModel.Cast _NumericHaganPricer.cell).Integrate
                                                            _a.cell 
                                                            _b.cell 
                                                            _integrand.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_NumericHaganPricer.source + ".Integrate") 

                                               [| _a.source
                                               ;  _b.source
                                               ;  _integrand.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NumericHaganPricer.cell
                                ;  _a.cell
                                ;  _b.cell
                                ;  _integrand.cell
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
            *)
    (*
        
    *)
    [<ExcelFunction(Name="_NumericHaganPricer", Description="Create a NumericHaganPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NumericHaganPricer_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swaptionVol",Description = "SwaptionVolatilityStructure")>] 
         swaptionVol : obj)
        ([<ExcelArgument(Name="modelOfYieldCurve",Description = "GFunctionFactory.YieldCurveModel: Standard, ExactYield, ParallelShifts, NonParallelShifts")>] 
         modelOfYieldCurve : obj)
        ([<ExcelArgument(Name="meanReversion",Description = "Quote")>] 
         meanReversion : obj)
        ([<ExcelArgument(Name="lowerLimit",Description = "double or empty")>] 
         lowerLimit : obj)
        ([<ExcelArgument(Name="upperLimit",Description = "double or empty")>] 
         upperLimit : obj)
        ([<ExcelArgument(Name="precision",Description = "double or empty")>] 
         precision : obj)
        ([<ExcelArgument(Name="hardUpperLimit",Description = "double or empty")>] 
         hardUpperLimit : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _swaptionVol = Helper.toHandle<SwaptionVolatilityStructure> swaptionVol "swaptionVol" 
                let _modelOfYieldCurve = Helper.toCell<GFunctionFactory.YieldCurveModel> modelOfYieldCurve "modelOfYieldCurve" 
                let _meanReversion = Helper.toHandle<Quote> meanReversion "meanReversion" 
                let _lowerLimit = Helper.toDefault<double> lowerLimit "lowerLimit" 0.0
                let _upperLimit = Helper.toDefault<double> upperLimit "upperLimit" 1.0
                let _precision = Helper.toDefault<double> precision "precision" 1.0e-6
                let _hardUpperLimit = Helper.toDefault<double> hardUpperLimit "hardUpperLimit" Double.MaxValue
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = (Fun.NumericHaganPricer 
                                                            _swaptionVol.cell 
                                                            _modelOfYieldCurve.cell 
                                                            _meanReversion.cell 
                                                            _lowerLimit.cell 
                                                            _upperLimit.cell 
                                                            _precision.cell 
                                                            _hardUpperLimit.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<NumericHaganPricer>) l

                let source () = Helper.sourceFold "Fun.NumericHaganPricer" 
                                               [| _swaptionVol.source
                                               ;  _modelOfYieldCurve.source
                                               ;  _meanReversion.source
                                               ;  _lowerLimit.source
                                               ;  _upperLimit.source
                                               ;  _precision.source
                                               ;  _hardUpperLimit.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _swaptionVol.cell
                                ;  _modelOfYieldCurve.cell
                                ;  _meanReversion.cell
                                ;  _lowerLimit.cell
                                ;  _upperLimit.cell
                                ;  _precision.cell
                                ;  _hardUpperLimit.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NumericHaganPricer> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_NumericHaganPricer_refineIntegration", Description="Create a NumericHaganPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NumericHaganPricer_refineIntegration
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NumericHaganPricer",Description = "NumericHaganPricer")>] 
         numerichaganpricer : obj)
        ([<ExcelArgument(Name="integralValue",Description = "double")>] 
         integralValue : obj)
        ([<ExcelArgument(Name="integrand",Description = "NumericHaganPricer.ConundrumIntegrand")>] 
         integrand : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NumericHaganPricer = Helper.toModelReference<NumericHaganPricer> numerichaganpricer "NumericHaganPricer"  
                let _integralValue = Helper.toCell<double> integralValue "integralValue" 
                let _integrand = Helper.toCell<NumericHaganPricer.ConundrumIntegrand> integrand "integrand" 
                let builder (current : ICell) = ((NumericHaganPricerModel.Cast _NumericHaganPricer.cell).RefineIntegration
                                                            _integralValue.cell 
                                                            _integrand.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_NumericHaganPricer.source + ".RefineIntegration") 

                                               [| _integralValue.source
                                               ;  _integrand.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NumericHaganPricer.cell
                                ;  _integralValue.cell
                                ;  _integrand.cell
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
    [<ExcelFunction(Name="_NumericHaganPricer_resetUpperLimit", Description="Create a NumericHaganPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NumericHaganPricer_resetUpperLimit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NumericHaganPricer",Description = "NumericHaganPricer")>] 
         numerichaganpricer : obj)
        ([<ExcelArgument(Name="stdDeviationsForUpperLimit",Description = "double")>] 
         stdDeviationsForUpperLimit : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NumericHaganPricer = Helper.toModelReference<NumericHaganPricer> numerichaganpricer "NumericHaganPricer"  
                let _stdDeviationsForUpperLimit = Helper.toCell<double> stdDeviationsForUpperLimit "stdDeviationsForUpperLimit" 
                let builder (current : ICell) = ((NumericHaganPricerModel.Cast _NumericHaganPricer.cell).ResetUpperLimit
                                                            _stdDeviationsForUpperLimit.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_NumericHaganPricer.source + ".ResetUpperLimit") 

                                               [| _stdDeviationsForUpperLimit.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NumericHaganPricer.cell
                                ;  _stdDeviationsForUpperLimit.cell
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
    [<ExcelFunction(Name="_NumericHaganPricer_stdDeviations", Description="Create a NumericHaganPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NumericHaganPricer_stdDeviations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NumericHaganPricer",Description = "NumericHaganPricer")>] 
         numerichaganpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NumericHaganPricer = Helper.toModelReference<NumericHaganPricer> numerichaganpricer "NumericHaganPricer"  
                let builder (current : ICell) = ((NumericHaganPricerModel.Cast _NumericHaganPricer.cell).StdDeviations
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_NumericHaganPricer.source + ".StdDeviations") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NumericHaganPricer.cell
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
    [<ExcelFunction(Name="_NumericHaganPricer_swapletPrice", Description="Create a NumericHaganPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NumericHaganPricer_swapletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NumericHaganPricer",Description = "NumericHaganPricer")>] 
         numerichaganpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NumericHaganPricer = Helper.toModelReference<NumericHaganPricer> numerichaganpricer "NumericHaganPricer"  
                let builder (current : ICell) = ((NumericHaganPricerModel.Cast _NumericHaganPricer.cell).SwapletPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_NumericHaganPricer.source + ".SwapletPrice") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NumericHaganPricer.cell
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
    [<ExcelFunction(Name="_NumericHaganPricer_upperLimit", Description="Create a NumericHaganPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NumericHaganPricer_upperLimit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NumericHaganPricer",Description = "NumericHaganPricer")>] 
         numerichaganpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NumericHaganPricer = Helper.toModelReference<NumericHaganPricer> numerichaganpricer "NumericHaganPricer"  
                let builder (current : ICell) = ((NumericHaganPricerModel.Cast _NumericHaganPricer.cell).UpperLimit
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_NumericHaganPricer.source + ".UpperLimit") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NumericHaganPricer.cell
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
    [<ExcelFunction(Name="_NumericHaganPricer_capletPrice", Description="Create a NumericHaganPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NumericHaganPricer_capletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NumericHaganPricer",Description = "NumericHaganPricer")>] 
         numerichaganpricer : obj)
        ([<ExcelArgument(Name="effectiveCap",Description = "double")>] 
         effectiveCap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NumericHaganPricer = Helper.toModelReference<NumericHaganPricer> numerichaganpricer "NumericHaganPricer"  
                let _effectiveCap = Helper.toCell<double> effectiveCap "effectiveCap" 
                let builder (current : ICell) = ((NumericHaganPricerModel.Cast _NumericHaganPricer.cell).CapletPrice
                                                            _effectiveCap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_NumericHaganPricer.source + ".CapletPrice") 

                                               [| _effectiveCap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NumericHaganPricer.cell
                                ;  _effectiveCap.cell
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
    [<ExcelFunction(Name="_NumericHaganPricer_capletRate", Description="Create a NumericHaganPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NumericHaganPricer_capletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NumericHaganPricer",Description = "NumericHaganPricer")>] 
         numerichaganpricer : obj)
        ([<ExcelArgument(Name="effectiveCap",Description = "double")>] 
         effectiveCap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NumericHaganPricer = Helper.toModelReference<NumericHaganPricer> numerichaganpricer "NumericHaganPricer"  
                let _effectiveCap = Helper.toCell<double> effectiveCap "effectiveCap" 
                let builder (current : ICell) = ((NumericHaganPricerModel.Cast _NumericHaganPricer.cell).CapletRate
                                                            _effectiveCap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_NumericHaganPricer.source + ".CapletRate") 

                                               [| _effectiveCap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NumericHaganPricer.cell
                                ;  _effectiveCap.cell
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
    [<ExcelFunction(Name="_NumericHaganPricer_floorletPrice", Description="Create a NumericHaganPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NumericHaganPricer_floorletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NumericHaganPricer",Description = "NumericHaganPricer")>] 
         numerichaganpricer : obj)
        ([<ExcelArgument(Name="effectiveFloor",Description = "double")>] 
         effectiveFloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NumericHaganPricer = Helper.toModelReference<NumericHaganPricer> numerichaganpricer "NumericHaganPricer"  
                let _effectiveFloor = Helper.toCell<double> effectiveFloor "effectiveFloor" 
                let builder (current : ICell) = ((NumericHaganPricerModel.Cast _NumericHaganPricer.cell).FloorletPrice
                                                            _effectiveFloor.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_NumericHaganPricer.source + ".FloorletPrice") 

                                               [| _effectiveFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NumericHaganPricer.cell
                                ;  _effectiveFloor.cell
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
    [<ExcelFunction(Name="_NumericHaganPricer_floorletRate", Description="Create a NumericHaganPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NumericHaganPricer_floorletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NumericHaganPricer",Description = "NumericHaganPricer")>] 
         numerichaganpricer : obj)
        ([<ExcelArgument(Name="effectiveFloor",Description = "double")>] 
         effectiveFloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NumericHaganPricer = Helper.toModelReference<NumericHaganPricer> numerichaganpricer "NumericHaganPricer"  
                let _effectiveFloor = Helper.toCell<double> effectiveFloor "effectiveFloor" 
                let builder (current : ICell) = ((NumericHaganPricerModel.Cast _NumericHaganPricer.cell).FloorletRate
                                                            _effectiveFloor.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_NumericHaganPricer.source + ".FloorletRate") 

                                               [| _effectiveFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NumericHaganPricer.cell
                                ;  _effectiveFloor.cell
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
    [<ExcelFunction(Name="_NumericHaganPricer_initialize", Description="Create a NumericHaganPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NumericHaganPricer_initialize
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NumericHaganPricer",Description = "NumericHaganPricer")>] 
         numerichaganpricer : obj)
        ([<ExcelArgument(Name="coupon",Description = "FloatingRateCoupon")>] 
         coupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NumericHaganPricer = Helper.toModelReference<NumericHaganPricer> numerichaganpricer "NumericHaganPricer"  
                let _coupon = Helper.toCell<FloatingRateCoupon> coupon "coupon" 
                let builder (current : ICell) = ((NumericHaganPricerModel.Cast _NumericHaganPricer.cell).Initialize
                                                            _coupon.cell 
                                                       ) :> ICell
                let format (o : NumericHaganPricer) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NumericHaganPricer.source + ".Initialize") 

                                               [| _coupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NumericHaganPricer.cell
                                ;  _coupon.cell
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
    [<ExcelFunction(Name="_NumericHaganPricer_meanReversion", Description="Create a NumericHaganPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NumericHaganPricer_meanReversion
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NumericHaganPricer",Description = "NumericHaganPricer")>] 
         numerichaganpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NumericHaganPricer = Helper.toModelReference<NumericHaganPricer> numerichaganpricer "NumericHaganPricer"  
                let builder (current : ICell) = ((NumericHaganPricerModel.Cast _NumericHaganPricer.cell).MeanReversion
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_NumericHaganPricer.source + ".MeanReversion") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NumericHaganPricer.cell
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
    [<ExcelFunction(Name="_NumericHaganPricer_setMeanReversion", Description="Create a NumericHaganPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NumericHaganPricer_setMeanReversion
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NumericHaganPricer",Description = "NumericHaganPricer")>] 
         numerichaganpricer : obj)
        ([<ExcelArgument(Name="meanReversion",Description = "Quote")>] 
         meanReversion : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NumericHaganPricer = Helper.toModelReference<NumericHaganPricer> numerichaganpricer "NumericHaganPricer"  
                let _meanReversion = Helper.toHandle<Quote> meanReversion "meanReversion" 
                let builder (current : ICell) = ((NumericHaganPricerModel.Cast _NumericHaganPricer.cell).SetMeanReversion
                                                            _meanReversion.cell 
                                                       ) :> ICell
                let format (o : NumericHaganPricer) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NumericHaganPricer.source + ".SetMeanReversion") 

                                               [| _meanReversion.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NumericHaganPricer.cell
                                ;  _meanReversion.cell
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
    [<ExcelFunction(Name="_NumericHaganPricer_swapletRate", Description="Create a NumericHaganPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NumericHaganPricer_swapletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NumericHaganPricer",Description = "NumericHaganPricer")>] 
         numerichaganpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NumericHaganPricer = Helper.toModelReference<NumericHaganPricer> numerichaganpricer "NumericHaganPricer"  
                let builder (current : ICell) = ((NumericHaganPricerModel.Cast _NumericHaganPricer.cell).SwapletRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_NumericHaganPricer.source + ".SwapletRate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NumericHaganPricer.cell
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
    [<ExcelFunction(Name="_NumericHaganPricer_setSwaptionVolatility", Description="Create a NumericHaganPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NumericHaganPricer_setSwaptionVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NumericHaganPricer",Description = "NumericHaganPricer")>] 
         numerichaganpricer : obj)
        ([<ExcelArgument(Name="v",Description = "SwaptionVolatilityStructure")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NumericHaganPricer = Helper.toModelReference<NumericHaganPricer> numerichaganpricer "NumericHaganPricer"  
                let _v = Helper.toHandle<SwaptionVolatilityStructure> v "v" 
                let builder (current : ICell) = ((NumericHaganPricerModel.Cast _NumericHaganPricer.cell).SetSwaptionVolatility
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : NumericHaganPricer) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NumericHaganPricer.source + ".SetSwaptionVolatility") 

                                               [| _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NumericHaganPricer.cell
                                ;  _v.cell
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
    [<ExcelFunction(Name="_NumericHaganPricer_swaptionVolatility", Description="Create a NumericHaganPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NumericHaganPricer_swaptionVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NumericHaganPricer",Description = "NumericHaganPricer")>] 
         numerichaganpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NumericHaganPricer = Helper.toModelReference<NumericHaganPricer> numerichaganpricer "NumericHaganPricer"  
                let builder (current : ICell) = ((NumericHaganPricerModel.Cast _NumericHaganPricer.cell).SwaptionVolatility
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<SwaptionVolatilityStructure>>) l

                let source () = Helper.sourceFold (_NumericHaganPricer.source + ".SwaptionVolatility") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NumericHaganPricer.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NumericHaganPricer> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_NumericHaganPricer_registerWith", Description="Create a NumericHaganPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NumericHaganPricer_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NumericHaganPricer",Description = "NumericHaganPricer")>] 
         numerichaganpricer : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NumericHaganPricer = Helper.toModelReference<NumericHaganPricer> numerichaganpricer "NumericHaganPricer"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((NumericHaganPricerModel.Cast _NumericHaganPricer.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : NumericHaganPricer) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NumericHaganPricer.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NumericHaganPricer.cell
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
    [<ExcelFunction(Name="_NumericHaganPricer_unregisterWith", Description="Create a NumericHaganPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NumericHaganPricer_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NumericHaganPricer",Description = "NumericHaganPricer")>] 
         numerichaganpricer : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NumericHaganPricer = Helper.toModelReference<NumericHaganPricer> numerichaganpricer "NumericHaganPricer"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((NumericHaganPricerModel.Cast _NumericHaganPricer.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : NumericHaganPricer) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NumericHaganPricer.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NumericHaganPricer.cell
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
        observer interface
    *)
    [<ExcelFunction(Name="_NumericHaganPricer_update", Description="Create a NumericHaganPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NumericHaganPricer_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NumericHaganPricer",Description = "NumericHaganPricer")>] 
         numerichaganpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NumericHaganPricer = Helper.toModelReference<NumericHaganPricer> numerichaganpricer "NumericHaganPricer"  
                let builder (current : ICell) = ((NumericHaganPricerModel.Cast _NumericHaganPricer.cell).Update
                                                       ) :> ICell
                let format (o : NumericHaganPricer) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NumericHaganPricer.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NumericHaganPricer.cell
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
    [<ExcelFunction(Name="_NumericHaganPricer_Range", Description="Create a range of NumericHaganPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NumericHaganPricer_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<NumericHaganPricer> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<NumericHaganPricer> (c)) :> ICell
                let format (i : Cephei.Cell.List<NumericHaganPricer>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<NumericHaganPricer>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
