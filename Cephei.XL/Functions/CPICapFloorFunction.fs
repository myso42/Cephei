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
  Quoted as a fixed strike rate K  Payoff: P_n(0,T) (N [(1+K)^{T}-1] - N -1 0) where T is the maturity time, P_n(0,t) is the nominal discount factor at time t N is the notional, and I(t) is the inflation index value at time t  Inflation is generally available on every day, including holidays and weekends.  Hence there is a variable to state whether the observe/fix dates for inflation are adjusted or not.  The default is not to adjust.  N.B. a cpi cap or floor is an option, not a cap or floor on a coupon. Thus this is very similar to a ZCIIS and has a single flow, this is as usual for cpi because it is cumulative up to option maturity from base date.  We do not inherit from Option, although this would be reasonable, because we do not have that degree of generality.
  </summary> *)
[<AutoSerializable(true)>]
module CPICapFloorFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_CPICapFloor", Description="Create a CPICapFloor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPICapFloor_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="nominal",Description = "Reference to nominal")>] 
         nominal : obj)
        ([<ExcelArgument(Name="startDate",Description = "Reference to startDate")>] 
         startDate : obj)
        ([<ExcelArgument(Name="baseCPI",Description = "Reference to baseCPI")>] 
         baseCPI : obj)
        ([<ExcelArgument(Name="maturity",Description = "Reference to maturity")>] 
         maturity : obj)
        ([<ExcelArgument(Name="fixCalendar",Description = "Reference to fixCalendar")>] 
         fixCalendar : obj)
        ([<ExcelArgument(Name="fixConvention",Description = "Reference to fixConvention")>] 
         fixConvention : obj)
        ([<ExcelArgument(Name="payCalendar",Description = "Reference to payCalendar")>] 
         payCalendar : obj)
        ([<ExcelArgument(Name="payConvention",Description = "Reference to payConvention")>] 
         payConvention : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="infIndex",Description = "Reference to infIndex")>] 
         infIndex : obj)
        ([<ExcelArgument(Name="observationLag",Description = "Reference to observationLag")>] 
         observationLag : obj)
        ([<ExcelArgument(Name="observationInterpolation",Description = "Reference to observationInterpolation")>] 
         observationInterpolation : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "Reference to Pricing Engine used")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Reference to the date used for evaluation")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Type = Helper.toCell<Option.Type> Type "Type" true
                let _nominal = Helper.toCell<double> nominal "nominal" true
                let _startDate = Helper.toCell<Date> startDate "startDate" true
                let _baseCPI = Helper.toCell<double> baseCPI "baseCPI" true
                let _maturity = Helper.toCell<Date> maturity "maturity" true
                let _fixCalendar = Helper.toCell<Calendar> fixCalendar "fixCalendar" true
                let _fixConvention = Helper.toCell<BusinessDayConvention> fixConvention "fixConvention" true
                let _payCalendar = Helper.toCell<Calendar> payCalendar "payCalendar" true
                let _payConvention = Helper.toCell<BusinessDayConvention> payConvention "payConvention" true
                let _strike = Helper.toCell<double> strike "strike" true
                let _infIndex = Helper.toHandle<ZeroInflationIndex> infIndex "infIndex" 
                let _observationLag = Helper.toCell<Period> observationLag "observationLag" true
                let _observationInterpolation = Helper.toCell<InterpolationType> observationInterpolation "observationInterpolation" true
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine" true 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate" true 
                let builder () = withMnemonic mnemonic (Fun.CPICapFloor 
                                                            _Type.cell 
                                                            _nominal.cell 
                                                            _startDate.cell 
                                                            _baseCPI.cell 
                                                            _maturity.cell 
                                                            _fixCalendar.cell 
                                                            _fixConvention.cell 
                                                            _payCalendar.cell 
                                                            _payConvention.cell 
                                                            _strike.cell 
                                                            _infIndex.cell 
                                                            _observationLag.cell 
                                                            _observationInterpolation.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CPICapFloor>) l

                let source = Helper.sourceFold "Fun.CPICapFloor" 
                                               [| _Type.source
                                               ;  _nominal.source
                                               ;  _startDate.source
                                               ;  _baseCPI.source
                                               ;  _maturity.source
                                               ;  _fixCalendar.source
                                               ;  _fixConvention.source
                                               ;  _payCalendar.source
                                               ;  _payConvention.source
                                               ;  _strike.source
                                               ;  _infIndex.source
                                               ;  _observationLag.source
                                               ;  _observationInterpolation.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Type.cell
                                ;  _nominal.cell
                                ;  _startDate.cell
                                ;  _baseCPI.cell
                                ;  _maturity.cell
                                ;  _fixCalendar.cell
                                ;  _fixConvention.cell
                                ;  _payCalendar.cell
                                ;  _payConvention.cell
                                ;  _strike.cell
                                ;  _infIndex.cell
                                ;  _observationLag.cell
                                ;  _observationInterpolation.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
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
        ! when you fix - but remember that there is an observation interpolation factor as well
    *)
    [<ExcelFunction(Name="_CPICapFloor_fixingDate", Description="Create a CPICapFloor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPICapFloor_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICapFloor",Description = "Reference to CPICapFloor")>] 
         cpicapfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICapFloor = Helper.toCell<CPICapFloor> cpicapfloor "CPICapFloor" true 
                let builder () = withMnemonic mnemonic ((_CPICapFloor.cell :?> CPICapFloorModel).FixingDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CPICapFloor.source + ".FixingDate") 
                                               [| _CPICapFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICapFloor.cell
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
    [<ExcelFunction(Name="_CPICapFloor_inflationIndex", Description="Create a CPICapFloor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPICapFloor_inflationIndex
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICapFloor",Description = "Reference to CPICapFloor")>] 
         cpicapfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICapFloor = Helper.toCell<CPICapFloor> cpicapfloor "CPICapFloor" true 
                let builder () = withMnemonic mnemonic ((_CPICapFloor.cell :?> CPICapFloorModel).InflationIndex
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<ZeroInflationIndex>>) l

                let source = Helper.sourceFold (_CPICapFloor.source + ".InflationIndex") 
                                               [| _CPICapFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICapFloor.cell
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
        Instrument interface
    *)
    [<ExcelFunction(Name="_CPICapFloor_isExpired", Description="Create a CPICapFloor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPICapFloor_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICapFloor",Description = "Reference to CPICapFloor")>] 
         cpicapfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICapFloor = Helper.toCell<CPICapFloor> cpicapfloor "CPICapFloor" true 
                let builder () = withMnemonic mnemonic ((_CPICapFloor.cell :?> CPICapFloorModel).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CPICapFloor.source + ".IsExpired") 
                                               [| _CPICapFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICapFloor.cell
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
    [<ExcelFunction(Name="_CPICapFloor_nominal", Description="Create a CPICapFloor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPICapFloor_nominal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICapFloor",Description = "Reference to CPICapFloor")>] 
         cpicapfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICapFloor = Helper.toCell<CPICapFloor> cpicapfloor "CPICapFloor" true 
                let builder () = withMnemonic mnemonic ((_CPICapFloor.cell :?> CPICapFloorModel).Nominal
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CPICapFloor.source + ".Nominal") 
                                               [| _CPICapFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICapFloor.cell
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
    [<ExcelFunction(Name="_CPICapFloor_observationLag", Description="Create a CPICapFloor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPICapFloor_observationLag
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICapFloor",Description = "Reference to CPICapFloor")>] 
         cpicapfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICapFloor = Helper.toCell<CPICapFloor> cpicapfloor "CPICapFloor" true 
                let builder () = withMnemonic mnemonic ((_CPICapFloor.cell :?> CPICapFloorModel).ObservationLag
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_CPICapFloor.source + ".ObservationLag") 
                                               [| _CPICapFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICapFloor.cell
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
    [<ExcelFunction(Name="_CPICapFloor_payDate", Description="Create a CPICapFloor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPICapFloor_payDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICapFloor",Description = "Reference to CPICapFloor")>] 
         cpicapfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICapFloor = Helper.toCell<CPICapFloor> cpicapfloor "CPICapFloor" true 
                let builder () = withMnemonic mnemonic ((_CPICapFloor.cell :?> CPICapFloorModel).PayDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CPICapFloor.source + ".PayDate") 
                                               [| _CPICapFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICapFloor.cell
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
        ! \f$ K \f$ in the above formula.
    *)
    [<ExcelFunction(Name="_CPICapFloor_strike", Description="Create a CPICapFloor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPICapFloor_strike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICapFloor",Description = "Reference to CPICapFloor")>] 
         cpicapfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICapFloor = Helper.toCell<CPICapFloor> cpicapfloor "CPICapFloor" true 
                let builder () = withMnemonic mnemonic ((_CPICapFloor.cell :?> CPICapFloorModel).Strike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CPICapFloor.source + ".Strike") 
                                               [| _CPICapFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICapFloor.cell
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
        Inspectors
    *)
    [<ExcelFunction(Name="_CPICapFloor_type", Description="Create a CPICapFloor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPICapFloor_type
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICapFloor",Description = "Reference to CPICapFloor")>] 
         cpicapfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICapFloor = Helper.toCell<CPICapFloor> cpicapfloor "CPICapFloor" true 
                let builder () = withMnemonic mnemonic ((_CPICapFloor.cell :?> CPICapFloorModel).Type
                                                       ) :> ICell
                let format (o : Option.Type) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CPICapFloor.source + ".TYPE") 
                                               [| _CPICapFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICapFloor.cell
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
    [<ExcelFunction(Name="_CPICapFloor_CASH", Description="Create a CPICapFloor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPICapFloor_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICapFloor",Description = "Reference to CPICapFloor")>] 
         cpicapfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICapFloor = Helper.toCell<CPICapFloor> cpicapfloor "CPICapFloor" true 
                let builder () = withMnemonic mnemonic ((_CPICapFloor.cell :?> CPICapFloorModel).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CPICapFloor.source + ".CASH") 
                                               [| _CPICapFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICapFloor.cell
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
    [<ExcelFunction(Name="_CPICapFloor_errorEstimate", Description="Create a CPICapFloor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPICapFloor_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICapFloor",Description = "Reference to CPICapFloor")>] 
         cpicapfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICapFloor = Helper.toCell<CPICapFloor> cpicapfloor "CPICapFloor" true 
                let builder () = withMnemonic mnemonic ((_CPICapFloor.cell :?> CPICapFloorModel).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CPICapFloor.source + ".ErrorEstimate") 
                                               [| _CPICapFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICapFloor.cell
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
    [<ExcelFunction(Name="_CPICapFloor_NPV", Description="Create a CPICapFloor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPICapFloor_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICapFloor",Description = "Reference to CPICapFloor")>] 
         cpicapfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICapFloor = Helper.toCell<CPICapFloor> cpicapfloor "CPICapFloor" true 
                let builder () = withMnemonic mnemonic ((_CPICapFloor.cell :?> CPICapFloorModel).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CPICapFloor.source + ".NPV") 
                                               [| _CPICapFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICapFloor.cell
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
        returns any additional result returned by the pricing engine.
    *)
    [<ExcelFunction(Name="_CPICapFloor_result", Description="Create a CPICapFloor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPICapFloor_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICapFloor",Description = "Reference to CPICapFloor")>] 
         cpicapfloor : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICapFloor = Helper.toCell<CPICapFloor> cpicapfloor "CPICapFloor" true 
                let _tag = Helper.toCell<string> tag "tag" true
                let builder () = withMnemonic mnemonic ((_CPICapFloor.cell :?> CPICapFloorModel).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CPICapFloor.source + ".Result") 
                                               [| _CPICapFloor.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICapFloor.cell
                                ;  _tag.cell
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
        ! calling this method will have no effects in case the performCalculation method was overridden in a derived class.
    *)
    [<ExcelFunction(Name="_CPICapFloor_setPricingEngine", Description="Create a CPICapFloor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPICapFloor_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICapFloor",Description = "Reference to CPICapFloor")>] 
         cpicapfloor : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICapFloor = Helper.toCell<CPICapFloor> cpicapfloor "CPICapFloor" true 
                let _e = Helper.toCell<IPricingEngine> e "e" true
                let builder () = withMnemonic mnemonic ((_CPICapFloor.cell :?> CPICapFloorModel).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : CPICapFloor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CPICapFloor.source + ".SetPricingEngine") 
                                               [| _CPICapFloor.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICapFloor.cell
                                ;  _e.cell
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
        ! returns the date the net present value refers to.
    *)
    [<ExcelFunction(Name="_CPICapFloor_valuationDate", Description="Create a CPICapFloor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPICapFloor_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICapFloor",Description = "Reference to CPICapFloor")>] 
         cpicapfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICapFloor = Helper.toCell<CPICapFloor> cpicapfloor "CPICapFloor" true 
                let builder () = withMnemonic mnemonic ((_CPICapFloor.cell :?> CPICapFloorModel).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CPICapFloor.source + ".ValuationDate") 
                                               [| _CPICapFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICapFloor.cell
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
    [<ExcelFunction(Name="_CPICapFloor_Range", Description="Create a range of CPICapFloor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPICapFloor_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the CPICapFloor")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CPICapFloor> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CPICapFloor>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<CPICapFloor>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<CPICapFloor>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"