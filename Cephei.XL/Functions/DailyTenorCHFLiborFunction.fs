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
  base class for the one day deposit BBA %CHF %LIBOR indexes
  </summary> *)
[<AutoSerializable(true)>]
module DailyTenorCHFLiborFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_DailyTenorCHFLibor", Description="Create a DailyTenorCHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorCHFLibor_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" true
                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let builder () = withMnemonic mnemonic (Fun.DailyTenorCHFLibor 
                                                            _settlementDays.cell 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DailyTenorCHFLibor>) l

                let source = Helper.sourceFold "Fun.DailyTenorCHFLibor" 
                                               [| _settlementDays.source
                                               ;  _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _h.cell
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
        Inspectors
    *)
    [<ExcelFunction(Name="_DailyTenorCHFLibor_businessDayConvention", Description="Create a DailyTenorCHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorCHFLibor_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorCHFLibor",Description = "Reference to DailyTenorCHFLibor")>] 
         dailytenorchflibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorCHFLibor = Helper.toCell<DailyTenorCHFLibor> dailytenorchflibor "DailyTenorCHFLibor" true 
                let builder () = withMnemonic mnemonic ((_DailyTenorCHFLibor.cell :?> DailyTenorCHFLiborModel).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DailyTenorCHFLibor.source + ".BusinessDayConvention") 
                                               [| _DailyTenorCHFLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorCHFLibor.cell
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
        Other methods returns a copy of itself linked to a different forwarding curve
    *)
    [<ExcelFunction(Name="_DailyTenorCHFLibor_clone", Description="Create a DailyTenorCHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorCHFLibor_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorCHFLibor",Description = "Reference to DailyTenorCHFLibor")>] 
         dailytenorchflibor : obj)
        ([<ExcelArgument(Name="forwarding",Description = "Reference to forwarding")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorCHFLibor = Helper.toCell<DailyTenorCHFLibor> dailytenorchflibor "DailyTenorCHFLibor" true 
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let builder () = withMnemonic mnemonic ((_DailyTenorCHFLibor.cell :?> DailyTenorCHFLiborModel).Clone
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source = Helper.sourceFold (_DailyTenorCHFLibor.source + ".Clone") 
                                               [| _DailyTenorCHFLibor.source
                                               ;  _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorCHFLibor.cell
                                ;  _forwarding.cell
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
    [<ExcelFunction(Name="_DailyTenorCHFLibor_endOfMonth", Description="Create a DailyTenorCHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorCHFLibor_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorCHFLibor",Description = "Reference to DailyTenorCHFLibor")>] 
         dailytenorchflibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorCHFLibor = Helper.toCell<DailyTenorCHFLibor> dailytenorchflibor "DailyTenorCHFLibor" true 
                let builder () = withMnemonic mnemonic ((_DailyTenorCHFLibor.cell :?> DailyTenorCHFLiborModel).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DailyTenorCHFLibor.source + ".EndOfMonth") 
                                               [| _DailyTenorCHFLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorCHFLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorCHFLibor_forecastFixing1", Description="Create a DailyTenorCHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorCHFLibor_forecastFixing1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorCHFLibor",Description = "Reference to DailyTenorCHFLibor")>] 
         dailytenorchflibor : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorCHFLibor = Helper.toCell<DailyTenorCHFLibor> dailytenorchflibor "DailyTenorCHFLibor" true 
                let _d1 = Helper.toCell<Date> d1 "d1" true
                let _d2 = Helper.toCell<Date> d2 "d2" true
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_DailyTenorCHFLibor.cell :?> DailyTenorCHFLiborModel).ForecastFixing1
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DailyTenorCHFLibor.source + ".ForecastFixing1") 
                                               [| _DailyTenorCHFLibor.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorCHFLibor.cell
                                ;  _d1.cell
                                ;  _d2.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_DailyTenorCHFLibor_forecastFixing", Description="Create a DailyTenorCHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorCHFLibor_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorCHFLibor",Description = "Reference to DailyTenorCHFLibor")>] 
         dailytenorchflibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorCHFLibor = Helper.toCell<DailyTenorCHFLibor> dailytenorchflibor "DailyTenorCHFLibor" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_DailyTenorCHFLibor.cell :?> DailyTenorCHFLiborModel).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DailyTenorCHFLibor.source + ".ForecastFixing") 
                                               [| _DailyTenorCHFLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorCHFLibor.cell
                                ;  _fixingDate.cell
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
        the curve used to forecast fixings
    *)
    [<ExcelFunction(Name="_DailyTenorCHFLibor_forwardingTermStructure", Description="Create a DailyTenorCHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorCHFLibor_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorCHFLibor",Description = "Reference to DailyTenorCHFLibor")>] 
         dailytenorchflibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorCHFLibor = Helper.toCell<DailyTenorCHFLibor> dailytenorchflibor "DailyTenorCHFLibor" true 
                let builder () = withMnemonic mnemonic ((_DailyTenorCHFLibor.cell :?> DailyTenorCHFLiborModel).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_DailyTenorCHFLibor.source + ".ForwardingTermStructure") 
                                               [| _DailyTenorCHFLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorCHFLibor.cell
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
        InterestRateIndex interface
    *)
    [<ExcelFunction(Name="_DailyTenorCHFLibor_maturityDate", Description="Create a DailyTenorCHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorCHFLibor_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorCHFLibor",Description = "Reference to DailyTenorCHFLibor")>] 
         dailytenorchflibor : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorCHFLibor = Helper.toCell<DailyTenorCHFLibor> dailytenorchflibor "DailyTenorCHFLibor" true 
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" true
                let builder () = withMnemonic mnemonic ((_DailyTenorCHFLibor.cell :?> DailyTenorCHFLiborModel).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_DailyTenorCHFLibor.source + ".MaturityDate") 
                                               [| _DailyTenorCHFLibor.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorCHFLibor.cell
                                ;  _valueDate.cell
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
    [<ExcelFunction(Name="_DailyTenorCHFLibor_currency", Description="Create a DailyTenorCHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorCHFLibor_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorCHFLibor",Description = "Reference to DailyTenorCHFLibor")>] 
         dailytenorchflibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorCHFLibor = Helper.toCell<DailyTenorCHFLibor> dailytenorchflibor "DailyTenorCHFLibor" true 
                let builder () = withMnemonic mnemonic ((_DailyTenorCHFLibor.cell :?> DailyTenorCHFLiborModel).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_DailyTenorCHFLibor.source + ".Currency") 
                                               [| _DailyTenorCHFLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorCHFLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorCHFLibor_dayCounter", Description="Create a DailyTenorCHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorCHFLibor_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorCHFLibor",Description = "Reference to DailyTenorCHFLibor")>] 
         dailytenorchflibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorCHFLibor = Helper.toCell<DailyTenorCHFLibor> dailytenorchflibor "DailyTenorCHFLibor" true 
                let builder () = withMnemonic mnemonic ((_DailyTenorCHFLibor.cell :?> DailyTenorCHFLiborModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_DailyTenorCHFLibor.source + ".DayCounter") 
                                               [| _DailyTenorCHFLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorCHFLibor.cell
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
        Inspectors
    *)
    [<ExcelFunction(Name="_DailyTenorCHFLibor_familyName", Description="Create a DailyTenorCHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorCHFLibor_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorCHFLibor",Description = "Reference to DailyTenorCHFLibor")>] 
         dailytenorchflibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorCHFLibor = Helper.toCell<DailyTenorCHFLibor> dailytenorchflibor "DailyTenorCHFLibor" true 
                let builder () = withMnemonic mnemonic ((_DailyTenorCHFLibor.cell :?> DailyTenorCHFLiborModel).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DailyTenorCHFLibor.source + ".FamilyName") 
                                               [| _DailyTenorCHFLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorCHFLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorCHFLibor_fixing", Description="Create a DailyTenorCHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorCHFLibor_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorCHFLibor",Description = "Reference to DailyTenorCHFLibor")>] 
         dailytenorchflibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorCHFLibor = Helper.toCell<DailyTenorCHFLibor> dailytenorchflibor "DailyTenorCHFLibor" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" true
                let builder () = withMnemonic mnemonic ((_DailyTenorCHFLibor.cell :?> DailyTenorCHFLiborModel).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DailyTenorCHFLibor.source + ".Fixing") 
                                               [| _DailyTenorCHFLibor.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorCHFLibor.cell
                                ;  _fixingDate.cell
                                ;  _forecastTodaysFixing.cell
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
    [<ExcelFunction(Name="_DailyTenorCHFLibor_fixingCalendar", Description="Create a DailyTenorCHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorCHFLibor_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorCHFLibor",Description = "Reference to DailyTenorCHFLibor")>] 
         dailytenorchflibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorCHFLibor = Helper.toCell<DailyTenorCHFLibor> dailytenorchflibor "DailyTenorCHFLibor" true 
                let builder () = withMnemonic mnemonic ((_DailyTenorCHFLibor.cell :?> DailyTenorCHFLiborModel).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_DailyTenorCHFLibor.source + ".FixingCalendar") 
                                               [| _DailyTenorCHFLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorCHFLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorCHFLibor_fixingDate", Description="Create a DailyTenorCHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorCHFLibor_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorCHFLibor",Description = "Reference to DailyTenorCHFLibor")>] 
         dailytenorchflibor : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorCHFLibor = Helper.toCell<DailyTenorCHFLibor> dailytenorchflibor "DailyTenorCHFLibor" true 
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" true
                let builder () = withMnemonic mnemonic ((_DailyTenorCHFLibor.cell :?> DailyTenorCHFLiborModel).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_DailyTenorCHFLibor.source + ".FixingDate") 
                                               [| _DailyTenorCHFLibor.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorCHFLibor.cell
                                ;  _valueDate.cell
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
    [<ExcelFunction(Name="_DailyTenorCHFLibor_fixingDays", Description="Create a DailyTenorCHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorCHFLibor_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorCHFLibor",Description = "Reference to DailyTenorCHFLibor")>] 
         dailytenorchflibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorCHFLibor = Helper.toCell<DailyTenorCHFLibor> dailytenorchflibor "DailyTenorCHFLibor" true 
                let builder () = withMnemonic mnemonic ((_DailyTenorCHFLibor.cell :?> DailyTenorCHFLiborModel).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_DailyTenorCHFLibor.source + ".FixingDays") 
                                               [| _DailyTenorCHFLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorCHFLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorCHFLibor_isValidFixingDate", Description="Create a DailyTenorCHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorCHFLibor_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorCHFLibor",Description = "Reference to DailyTenorCHFLibor")>] 
         dailytenorchflibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorCHFLibor = Helper.toCell<DailyTenorCHFLibor> dailytenorchflibor "DailyTenorCHFLibor" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_DailyTenorCHFLibor.cell :?> DailyTenorCHFLiborModel).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DailyTenorCHFLibor.source + ".IsValidFixingDate") 
                                               [| _DailyTenorCHFLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorCHFLibor.cell
                                ;  _fixingDate.cell
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
        Index interface
    *)
    [<ExcelFunction(Name="_DailyTenorCHFLibor_name", Description="Create a DailyTenorCHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorCHFLibor_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorCHFLibor",Description = "Reference to DailyTenorCHFLibor")>] 
         dailytenorchflibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorCHFLibor = Helper.toCell<DailyTenorCHFLibor> dailytenorchflibor "DailyTenorCHFLibor" true 
                let builder () = withMnemonic mnemonic ((_DailyTenorCHFLibor.cell :?> DailyTenorCHFLiborModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DailyTenorCHFLibor.source + ".Name") 
                                               [| _DailyTenorCHFLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorCHFLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorCHFLibor_pastFixing", Description="Create a DailyTenorCHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorCHFLibor_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorCHFLibor",Description = "Reference to DailyTenorCHFLibor")>] 
         dailytenorchflibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorCHFLibor = Helper.toCell<DailyTenorCHFLibor> dailytenorchflibor "DailyTenorCHFLibor" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_DailyTenorCHFLibor.cell :?> DailyTenorCHFLiborModel).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DailyTenorCHFLibor.source + ".PastFixing") 
                                               [| _DailyTenorCHFLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorCHFLibor.cell
                                ;  _fixingDate.cell
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
    [<ExcelFunction(Name="_DailyTenorCHFLibor_tenor", Description="Create a DailyTenorCHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorCHFLibor_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorCHFLibor",Description = "Reference to DailyTenorCHFLibor")>] 
         dailytenorchflibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorCHFLibor = Helper.toCell<DailyTenorCHFLibor> dailytenorchflibor "DailyTenorCHFLibor" true 
                let builder () = withMnemonic mnemonic ((_DailyTenorCHFLibor.cell :?> DailyTenorCHFLiborModel).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_DailyTenorCHFLibor.source + ".Tenor") 
                                               [| _DailyTenorCHFLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorCHFLibor.cell
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
        Observer interface
    *)
    [<ExcelFunction(Name="_DailyTenorCHFLibor_update", Description="Create a DailyTenorCHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorCHFLibor_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorCHFLibor",Description = "Reference to DailyTenorCHFLibor")>] 
         dailytenorchflibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorCHFLibor = Helper.toCell<DailyTenorCHFLibor> dailytenorchflibor "DailyTenorCHFLibor" true 
                let builder () = withMnemonic mnemonic ((_DailyTenorCHFLibor.cell :?> DailyTenorCHFLiborModel).Update
                                                       ) :> ICell
                let format (o : DailyTenorCHFLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DailyTenorCHFLibor.source + ".Update") 
                                               [| _DailyTenorCHFLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorCHFLibor.cell
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
        Date calculations These methods can be overridden to implement particular conventions (e.g. EurLibor)
    *)
    [<ExcelFunction(Name="_DailyTenorCHFLibor_valueDate", Description="Create a DailyTenorCHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorCHFLibor_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorCHFLibor",Description = "Reference to DailyTenorCHFLibor")>] 
         dailytenorchflibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorCHFLibor = Helper.toCell<DailyTenorCHFLibor> dailytenorchflibor "DailyTenorCHFLibor" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_DailyTenorCHFLibor.cell :?> DailyTenorCHFLiborModel).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_DailyTenorCHFLibor.source + ".ValueDate") 
                                               [| _DailyTenorCHFLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorCHFLibor.cell
                                ;  _fixingDate.cell
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
        Stores the historical fixing at the given date The date passed as arguments must be the actual calendar date of the fixing; no settlement days must be used.
    *)
    [<ExcelFunction(Name="_DailyTenorCHFLibor_addFixing", Description="Create a DailyTenorCHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorCHFLibor_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorCHFLibor",Description = "Reference to DailyTenorCHFLibor")>] 
         dailytenorchflibor : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorCHFLibor = Helper.toCell<DailyTenorCHFLibor> dailytenorchflibor "DailyTenorCHFLibor" true 
                let _d = Helper.toCell<Date> d "d" true
                let _v = Helper.toCell<double> v "v" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_DailyTenorCHFLibor.cell :?> DailyTenorCHFLiborModel).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : DailyTenorCHFLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DailyTenorCHFLibor.source + ".AddFixing") 
                                               [| _DailyTenorCHFLibor.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorCHFLibor.cell
                                ;  _d.cell
                                ;  _v.cell
                                ;  _forceOverwrite.cell
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
        Stores historical fixings at the given dates The dates passed as arguments must be the actual calendar dates of the fixings; no settlement days must be used.
    *)
    [<ExcelFunction(Name="_DailyTenorCHFLibor_addFixings", Description="Create a DailyTenorCHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorCHFLibor_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorCHFLibor",Description = "Reference to DailyTenorCHFLibor")>] 
         dailytenorchflibor : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorCHFLibor = Helper.toCell<DailyTenorCHFLibor> dailytenorchflibor "DailyTenorCHFLibor" true 
                let _d = Helper.toCell<Generic.List<Date>> d "d" true
                let _v = Helper.toCell<Generic.List<double>> v "v" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_DailyTenorCHFLibor.cell :?> DailyTenorCHFLiborModel).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : DailyTenorCHFLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DailyTenorCHFLibor.source + ".AddFixings") 
                                               [| _DailyTenorCHFLibor.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorCHFLibor.cell
                                ;  _d.cell
                                ;  _v.cell
                                ;  _forceOverwrite.cell
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
        Stores historical fixings from a TimeSeries The dates in the TimeSeries must be the actual calendar dates of the fixings; no settlement days must be used.
    *)
    [<ExcelFunction(Name="_DailyTenorCHFLibor_addFixings1", Description="Create a DailyTenorCHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorCHFLibor_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorCHFLibor",Description = "Reference to DailyTenorCHFLibor")>] 
         dailytenorchflibor : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorCHFLibor = Helper.toCell<DailyTenorCHFLibor> dailytenorchflibor "DailyTenorCHFLibor" true 
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_DailyTenorCHFLibor.cell :?> DailyTenorCHFLiborModel).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : DailyTenorCHFLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DailyTenorCHFLibor.source + ".AddFixings1") 
                                               [| _DailyTenorCHFLibor.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorCHFLibor.cell
                                ;  _source.cell
                                ;  _forceOverwrite.cell
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
        Check if index allows for native fixings. If this returns false, calls to addFixing and similar methods will raise an exception.
    *)
    [<ExcelFunction(Name="_DailyTenorCHFLibor_allowsNativeFixings", Description="Create a DailyTenorCHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorCHFLibor_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorCHFLibor",Description = "Reference to DailyTenorCHFLibor")>] 
         dailytenorchflibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorCHFLibor = Helper.toCell<DailyTenorCHFLibor> dailytenorchflibor "DailyTenorCHFLibor" true 
                let builder () = withMnemonic mnemonic ((_DailyTenorCHFLibor.cell :?> DailyTenorCHFLiborModel).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DailyTenorCHFLibor.source + ".AllowsNativeFixings") 
                                               [| _DailyTenorCHFLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorCHFLibor.cell
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
        Clears all stored historical fixings
    *)
    [<ExcelFunction(Name="_DailyTenorCHFLibor_clearFixings", Description="Create a DailyTenorCHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorCHFLibor_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorCHFLibor",Description = "Reference to DailyTenorCHFLibor")>] 
         dailytenorchflibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorCHFLibor = Helper.toCell<DailyTenorCHFLibor> dailytenorchflibor "DailyTenorCHFLibor" true 
                let builder () = withMnemonic mnemonic ((_DailyTenorCHFLibor.cell :?> DailyTenorCHFLiborModel).ClearFixings
                                                       ) :> ICell
                let format (o : DailyTenorCHFLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DailyTenorCHFLibor.source + ".ClearFixings") 
                                               [| _DailyTenorCHFLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorCHFLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorCHFLibor_registerWith", Description="Create a DailyTenorCHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorCHFLibor_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorCHFLibor",Description = "Reference to DailyTenorCHFLibor")>] 
         dailytenorchflibor : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorCHFLibor = Helper.toCell<DailyTenorCHFLibor> dailytenorchflibor "DailyTenorCHFLibor" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_DailyTenorCHFLibor.cell :?> DailyTenorCHFLiborModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : DailyTenorCHFLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DailyTenorCHFLibor.source + ".RegisterWith") 
                                               [| _DailyTenorCHFLibor.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorCHFLibor.cell
                                ;  _handler.cell
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
        Returns the fixing TimeSeries
    *)
    [<ExcelFunction(Name="_DailyTenorCHFLibor_timeSeries", Description="Create a DailyTenorCHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorCHFLibor_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorCHFLibor",Description = "Reference to DailyTenorCHFLibor")>] 
         dailytenorchflibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorCHFLibor = Helper.toCell<DailyTenorCHFLibor> dailytenorchflibor "DailyTenorCHFLibor" true 
                let builder () = withMnemonic mnemonic ((_DailyTenorCHFLibor.cell :?> DailyTenorCHFLiborModel).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DailyTenorCHFLibor.source + ".TimeSeries") 
                                               [| _DailyTenorCHFLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorCHFLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorCHFLibor_unregisterWith", Description="Create a DailyTenorCHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorCHFLibor_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorCHFLibor",Description = "Reference to DailyTenorCHFLibor")>] 
         dailytenorchflibor : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorCHFLibor = Helper.toCell<DailyTenorCHFLibor> dailytenorchflibor "DailyTenorCHFLibor" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_DailyTenorCHFLibor.cell :?> DailyTenorCHFLiborModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : DailyTenorCHFLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DailyTenorCHFLibor.source + ".UnregisterWith") 
                                               [| _DailyTenorCHFLibor.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorCHFLibor.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_DailyTenorCHFLibor_Range", Description="Create a range of DailyTenorCHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorCHFLibor_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the DailyTenorCHFLibor")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DailyTenorCHFLibor> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<DailyTenorCHFLibor>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<DailyTenorCHFLibor>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<DailyTenorCHFLibor>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"