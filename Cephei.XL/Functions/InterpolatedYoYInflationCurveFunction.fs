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

(*!! generic

(* <summary>
  The provided rates are not YY inflation-swap quotes. inflationtermstructures
  </summary> *)
[<AutoSerializable(true)>]
module InterpolatedYoYInflationCurveFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_baseDate", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_baseDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "Reference to InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedYoYInflationCurve.cell :?> InterpolatedYoYInflationCurveModel).BaseDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".BaseDate") 
                                               [| _InterpolatedYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_Clone", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_Clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "Reference to InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedYoYInflationCurve.cell :?> InterpolatedYoYInflationCurveModel).Clone
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".Clone") 
                                               [| _InterpolatedYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_data", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_data
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "Reference to InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedYoYInflationCurve.cell :?> InterpolatedYoYInflationCurveModel).Data
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".Data") 
                                               [| _InterpolatedYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_data_", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_data_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "Reference to InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedYoYInflationCurve.cell :?> InterpolatedYoYInflationCurveModel).Data_
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".Data_") 
                                               [| _InterpolatedYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_dates", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_dates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "Reference to InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedYoYInflationCurve.cell :?> InterpolatedYoYInflationCurveModel).Dates
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".Dates") 
                                               [| _InterpolatedYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_dates_", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_dates_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "Reference to InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedYoYInflationCurve.cell :?> InterpolatedYoYInflationCurveModel).Dates_
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".Dates_") 
                                               [| _InterpolatedYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_forwards", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_forwards
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "Reference to InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedYoYInflationCurve.cell :?> InterpolatedYoYInflationCurveModel).Forwards
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".Forwards") 
                                               [| _InterpolatedYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="referenceDate",Description = "Reference to referenceDate")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="calendar",Description = "Reference to calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="lag",Description = "Reference to lag")>] 
         lag : obj)
        ([<ExcelArgument(Name="frequency",Description = "Reference to frequency")>] 
         frequency : obj)
        ([<ExcelArgument(Name="indexIsInterpolated",Description = "Reference to indexIsInterpolated")>] 
         indexIsInterpolated : obj)
        ([<ExcelArgument(Name="yTS",Description = "Reference to yTS")>] 
         yTS : obj)
        ([<ExcelArgument(Name="dates",Description = "Reference to dates")>] 
         dates : obj)
        ([<ExcelArgument(Name="rates",Description = "Reference to rates")>] 
         rates : obj)
        ([<ExcelArgument(Name="interpolator",Description = "Reference to interpolator")>] 
         interpolator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _referenceDate = Helper.toCell<Date> referenceDate "referenceDate" true
                let _calendar = Helper.toCell<Calendar> calendar "calendar" true
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" true
                let _lag = Helper.toCell<Period> lag "lag" true
                let _frequency = Helper.toCell<Frequency> frequency "frequency" true
                let _indexIsInterpolated = Helper.toCell<bool> indexIsInterpolated "indexIsInterpolated" true
                let _yTS = Helper.toHandle<YieldTermStructure> yTS "yTS" 
                let _dates = Helper.toCell<Generic.List<Date>> dates "dates" true
                let _rates = Helper.toCell<Generic.List<double>> rates "rates" true
                let _interpolator = Helper.toCell<'Interpolator> interpolator "interpolator" true
                let builder () = withMnemonic mnemonic (Fun.InterpolatedYoYInflationCurve 
                                                            _referenceDate.cell 
                                                            _calendar.cell 
                                                            _dayCounter.cell 
                                                            _lag.cell 
                                                            _frequency.cell 
                                                            _indexIsInterpolated.cell 
                                                            _yTS.cell 
                                                            _dates.cell 
                                                            _rates.cell 
                                                            _interpolator.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterpolatedYoYInflationCurve>) l

                let source = Helper.sourceFold "Fun.InterpolatedYoYInflationCurve" 
                                               [| _referenceDate.source
                                               ;  _calendar.source
                                               ;  _dayCounter.source
                                               ;  _lag.source
                                               ;  _frequency.source
                                               ;  _indexIsInterpolated.source
                                               ;  _yTS.source
                                               ;  _dates.source
                                               ;  _rates.source
                                               ;  _interpolator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _referenceDate.cell
                                ;  _calendar.cell
                                ;  _dayCounter.cell
                                ;  _lag.cell
                                ;  _frequency.cell
                                ;  _indexIsInterpolated.cell
                                ;  _yTS.cell
                                ;  _dates.cell
                                ;  _rates.cell
                                ;  _interpolator.cell
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve1", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="referenceDate",Description = "Reference to referenceDate")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="calendar",Description = "Reference to calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="lag",Description = "Reference to lag")>] 
         lag : obj)
        ([<ExcelArgument(Name="frequency",Description = "Reference to frequency")>] 
         frequency : obj)
        ([<ExcelArgument(Name="indexIsInterpolated",Description = "Reference to indexIsInterpolated")>] 
         indexIsInterpolated : obj)
        ([<ExcelArgument(Name="yTS",Description = "Reference to yTS")>] 
         yTS : obj)
        ([<ExcelArgument(Name="dates",Description = "Reference to dates")>] 
         dates : obj)
        ([<ExcelArgument(Name="rates",Description = "Reference to rates")>] 
         rates : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _referenceDate = Helper.toCell<Date> referenceDate "referenceDate" true
                let _calendar = Helper.toCell<Calendar> calendar "calendar" true
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" true
                let _lag = Helper.toCell<Period> lag "lag" true
                let _frequency = Helper.toCell<Frequency> frequency "frequency" true
                let _indexIsInterpolated = Helper.toCell<bool> indexIsInterpolated "indexIsInterpolated" true
                let _yTS = Helper.toHandle<YieldTermStructure> yTS "yTS" 
                let _dates = Helper.toCell<Generic.List<Date>> dates "dates" true
                let _rates = Helper.toCell<Generic.List<double>> rates "rates" true
                let builder () = withMnemonic mnemonic (Fun.InterpolatedYoYInflationCurve1 
                                                            _referenceDate.cell 
                                                            _calendar.cell 
                                                            _dayCounter.cell 
                                                            _lag.cell 
                                                            _frequency.cell 
                                                            _indexIsInterpolated.cell 
                                                            _yTS.cell 
                                                            _dates.cell 
                                                            _rates.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterpolatedYoYInflationCurve>) l

                let source = Helper.sourceFold "Fun.InterpolatedYoYInflationCurve1" 
                                               [| _referenceDate.source
                                               ;  _calendar.source
                                               ;  _dayCounter.source
                                               ;  _lag.source
                                               ;  _frequency.source
                                               ;  _indexIsInterpolated.source
                                               ;  _yTS.source
                                               ;  _dates.source
                                               ;  _rates.source
                                               |]
                let hash = Helper.hashFold 
                                [| _referenceDate.cell
                                ;  _calendar.cell
                                ;  _dayCounter.cell
                                ;  _lag.cell
                                ;  _frequency.cell
                                ;  _indexIsInterpolated.cell
                                ;  _yTS.cell
                                ;  _dates.cell
                                ;  _rates.cell
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_interpolation_", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_interpolation_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "Reference to InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedYoYInflationCurve.cell :?> InterpolatedYoYInflationCurveModel).Interpolation_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Interpolation>) l

                let source = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".Interpolation_") 
                                               [| _InterpolatedYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_interpolator_", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_interpolator_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "Reference to InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedYoYInflationCurve.cell :?> InterpolatedYoYInflationCurveModel).Interpolator_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IInterpolationFactory>) l

                let source = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".Interpolator_") 
                                               [| _InterpolatedYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_maxDate", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "Reference to InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedYoYInflationCurve.cell :?> InterpolatedYoYInflationCurveModel).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".MaxDate") 
                                               [| _InterpolatedYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_maxDate_", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_maxDate_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "Reference to InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedYoYInflationCurve.cell :?> InterpolatedYoYInflationCurveModel).MaxDate_
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".MaxDate_") 
                                               [| _InterpolatedYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_nodes", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_nodes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "Reference to InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedYoYInflationCurve.cell :?> InterpolatedYoYInflationCurveModel).Nodes
                                                       ) :> ICell
                let format (o : Dictionary<Date,double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".Nodes") 
                                               [| _InterpolatedYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_rates", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_rates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "Reference to InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedYoYInflationCurve.cell :?> InterpolatedYoYInflationCurveModel).Rates
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".Rates") 
                                               [| _InterpolatedYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_setupInterpolation", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_setupInterpolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "Reference to InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedYoYInflationCurve.cell :?> InterpolatedYoYInflationCurveModel).SetupInterpolation
                                                       ) :> ICell
                let format (o : InterpolatedYoYInflationCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".SetupInterpolation") 
                                               [| _InterpolatedYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_times", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_times
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "Reference to InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedYoYInflationCurve.cell :?> InterpolatedYoYInflationCurveModel).Times
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".Times") 
                                               [| _InterpolatedYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_times_", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_times_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "Reference to InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedYoYInflationCurve.cell :?> InterpolatedYoYInflationCurveModel).Times_
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".Times_") 
                                               [| _InterpolatedYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_yoyRate", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_yoyRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "Reference to InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="instObsLag",Description = "Reference to instObsLag")>] 
         instObsLag : obj)
        ([<ExcelArgument(Name="forceLinearInterpolation",Description = "Reference to forceLinearInterpolation")>] 
         forceLinearInterpolation : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve" true 
                let _d = Helper.toCell<Date> d "d" true
                let _instObsLag = Helper.toCell<Period> instObsLag "instObsLag" true
                let _forceLinearInterpolation = Helper.toCell<bool> forceLinearInterpolation "forceLinearInterpolation" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_InterpolatedYoYInflationCurve.cell :?> InterpolatedYoYInflationCurveModel).YoyRate
                                                            _d.cell 
                                                            _instObsLag.cell 
                                                            _forceLinearInterpolation.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".YoyRate") 
                                               [| _InterpolatedYoYInflationCurve.source
                                               ;  _d.source
                                               ;  _instObsLag.source
                                               ;  _forceLinearInterpolation.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
                                ;  _d.cell
                                ;  _instObsLag.cell
                                ;  _forceLinearInterpolation.cell
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
        
    *)
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_yoyRate", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_yoyRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "Reference to InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="instObsLag",Description = "Reference to instObsLag")>] 
         instObsLag : obj)
        ([<ExcelArgument(Name="forceLinearInterpolation",Description = "Reference to forceLinearInterpolation")>] 
         forceLinearInterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve" true 
                let _d = Helper.toCell<Date> d "d" true
                let _instObsLag = Helper.toCell<Period> instObsLag "instObsLag" true
                let _forceLinearInterpolation = Helper.toCell<bool> forceLinearInterpolation "forceLinearInterpolation" true
                let builder () = withMnemonic mnemonic ((_InterpolatedYoYInflationCurve.cell :?> InterpolatedYoYInflationCurveModel).YoyRate1
                                                            _d.cell 
                                                            _instObsLag.cell 
                                                            _forceLinearInterpolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".YoyRate") 
                                               [| _InterpolatedYoYInflationCurve.source
                                               ;  _d.source
                                               ;  _instObsLag.source
                                               ;  _forceLinearInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
                                ;  _d.cell
                                ;  _instObsLag.cell
                                ;  _forceLinearInterpolation.cell
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_yoyRate", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_yoyRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "Reference to InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="instObsLag",Description = "Reference to instObsLag")>] 
         instObsLag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve" true 
                let _d = Helper.toCell<Date> d "d" true
                let _instObsLag = Helper.toCell<Period> instObsLag "instObsLag" true
                let builder () = withMnemonic mnemonic ((_InterpolatedYoYInflationCurve.cell :?> InterpolatedYoYInflationCurveModel).YoyRate2
                                                            _d.cell 
                                                            _instObsLag.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".YoyRate") 
                                               [| _InterpolatedYoYInflationCurve.source
                                               ;  _d.source
                                               ;  _instObsLag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
                                ;  _d.cell
                                ;  _instObsLag.cell
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
        ! \note this is not the year-on-year swap (YYIIS) rate.
    *)
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_yoyRate", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_yoyRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "Reference to InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_InterpolatedYoYInflationCurve.cell :?> InterpolatedYoYInflationCurveModel).YoyRate3
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".YoyRate") 
                                               [| _InterpolatedYoYInflationCurve.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
        
    *)
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_baseRate", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_baseRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "Reference to InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedYoYInflationCurve.cell :?> InterpolatedYoYInflationCurveModel).BaseRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".BaseRate") 
                                               [| _InterpolatedYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_frequency", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_frequency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "Reference to InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedYoYInflationCurve.cell :?> InterpolatedYoYInflationCurveModel).Frequency
                                                       ) :> ICell
                let format (o : Frequency) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".Frequency") 
                                               [| _InterpolatedYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_hasSeasonality", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_hasSeasonality
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "Reference to InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedYoYInflationCurve.cell :?> InterpolatedYoYInflationCurveModel).HasSeasonality
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".HasSeasonality") 
                                               [| _InterpolatedYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_indexIsInterpolated", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_indexIsInterpolated
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "Reference to InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedYoYInflationCurve.cell :?> InterpolatedYoYInflationCurveModel).IndexIsInterpolated
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".IndexIsInterpolated") 
                                               [| _InterpolatedYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_nominalTermStructure", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_nominalTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "Reference to InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedYoYInflationCurve.cell :?> InterpolatedYoYInflationCurveModel).NominalTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".NominalTermStructure") 
                                               [| _InterpolatedYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
        Inflation interface ! The TS observes with a lag that is usually different from the ! availability lag of the index.  An inflation rate is given, ! by default, for the maturity requested assuming this lag.
    *)
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_observationLag", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_observationLag
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "Reference to InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedYoYInflationCurve.cell :?> InterpolatedYoYInflationCurveModel).ObservationLag
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".ObservationLag") 
                                               [| _InterpolatedYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_seasonality", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_seasonality
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "Reference to InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedYoYInflationCurve.cell :?> InterpolatedYoYInflationCurveModel).Seasonality
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Seasonality>) l

                let source = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".Seasonality") 
                                               [| _InterpolatedYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
        ! Calling setSeasonality with no arguments means unsetting as the default is used to choose unsetting.
    *)
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_setSeasonality", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_setSeasonality
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "Reference to InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        ([<ExcelArgument(Name="seasonality",Description = "Reference to seasonality")>] 
         seasonality : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve" true 
                let _seasonality = Helper.toCell<Seasonality> seasonality "seasonality" true
                let builder () = withMnemonic mnemonic ((_InterpolatedYoYInflationCurve.cell :?> InterpolatedYoYInflationCurveModel).SetSeasonality
                                                            _seasonality.cell 
                                                       ) :> ICell
                let format (o : InterpolatedYoYInflationCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".SetSeasonality") 
                                               [| _InterpolatedYoYInflationCurve.source
                                               ;  _seasonality.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
                                ;  _seasonality.cell
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
        ! the calendar used for reference and/or option date calculation
    *)
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_calendar", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "Reference to InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedYoYInflationCurve.cell :?> InterpolatedYoYInflationCurveModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".Calendar") 
                                               [| _InterpolatedYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
        ! the day counter used for date/time conversion
    *)
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_dayCounter", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "Reference to InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedYoYInflationCurve.cell :?> InterpolatedYoYInflationCurveModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".DayCounter") 
                                               [| _InterpolatedYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
        ! the latest time for which the curve can return values
    *)
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_maxTime", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_maxTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "Reference to InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedYoYInflationCurve.cell :?> InterpolatedYoYInflationCurveModel).MaxTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".MaxTime") 
                                               [| _InterpolatedYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
        ! the date at which discount = 1.0 and/or variance = 0.0
    *)
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_referenceDate", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "Reference to InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedYoYInflationCurve.cell :?> InterpolatedYoYInflationCurveModel).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".ReferenceDate") 
                                               [| _InterpolatedYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
        ! the settlementDays used for reference date calculation
    *)
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_settlementDays", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "Reference to InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedYoYInflationCurve.cell :?> InterpolatedYoYInflationCurveModel).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".SettlementDays") 
                                               [| _InterpolatedYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_timeFromReference", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_timeFromReference
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "Reference to InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve" true 
                let _date = Helper.toCell<Date> date "date" true
                let builder () = withMnemonic mnemonic ((_InterpolatedYoYInflationCurve.cell :?> InterpolatedYoYInflationCurveModel).TimeFromReference
                                                            _date.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".TimeFromReference") 
                                               [| _InterpolatedYoYInflationCurve.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
        observer interface
    *)
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_update", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "Reference to InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedYoYInflationCurve.cell :?> InterpolatedYoYInflationCurveModel).Update
                                                       ) :> ICell
                let format (o : InterpolatedYoYInflationCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".Update") 
                                               [| _InterpolatedYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_allowsExtrapolation", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "Reference to InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedYoYInflationCurve.cell :?> InterpolatedYoYInflationCurveModel).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".AllowsExtrapolation") 
                                               [| _InterpolatedYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_disableExtrapolation", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "Reference to InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve" true 
                let _b = Helper.toCell<bool> b "b" true
                let builder () = withMnemonic mnemonic ((_InterpolatedYoYInflationCurve.cell :?> InterpolatedYoYInflationCurveModel).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : InterpolatedYoYInflationCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".DisableExtrapolation") 
                                               [| _InterpolatedYoYInflationCurve.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_enableExtrapolation", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "Reference to InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve" true 
                let _b = Helper.toCell<bool> b "b" true
                let builder () = withMnemonic mnemonic ((_InterpolatedYoYInflationCurve.cell :?> InterpolatedYoYInflationCurveModel).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : InterpolatedYoYInflationCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".EnableExtrapolation") 
                                               [| _InterpolatedYoYInflationCurve.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_extrapolate", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "Reference to InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedYoYInflationCurve.cell :?> InterpolatedYoYInflationCurveModel).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".Extrapolate") 
                                               [| _InterpolatedYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_Range", Description="Create a range of InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the InterpolatedYoYInflationCurve")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<InterpolatedYoYInflationCurve> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<InterpolatedYoYInflationCurve>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<InterpolatedYoYInflationCurve>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<InterpolatedYoYInflationCurve>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)