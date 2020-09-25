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
  Overnight %GBP %Libor index
  </summary> *)
[<AutoSerializable(true)>]
module GBPLiborONFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_GBPLiborON", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLiborON_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let builder () = withMnemonic mnemonic (Fun.GBPLiborON 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GBPLiborON>) l

                let source = Helper.sourceFold "Fun.GBPLiborON" 
                                               [| _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _h.cell
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
    [<ExcelFunction(Name="_GBPLiborON_businessDayConvention", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLiborON_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "Reference to GBPLiborON")>] 
         gbpliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON" true 
                let builder () = withMnemonic mnemonic ((_GBPLiborON.cell :?> GBPLiborONModel).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GBPLiborON.source + ".BusinessDayConvention") 
                                               [| _GBPLiborON.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
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
    [<ExcelFunction(Name="_GBPLiborON_clone", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLiborON_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "Reference to GBPLiborON")>] 
         gbpliboron : obj)
        ([<ExcelArgument(Name="forwarding",Description = "Reference to forwarding")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON" true 
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let builder () = withMnemonic mnemonic ((_GBPLiborON.cell :?> GBPLiborONModel).Clone
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source = Helper.sourceFold (_GBPLiborON.source + ".Clone") 
                                               [| _GBPLiborON.source
                                               ;  _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
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
    [<ExcelFunction(Name="_GBPLiborON_endOfMonth", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLiborON_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "Reference to GBPLiborON")>] 
         gbpliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON" true 
                let builder () = withMnemonic mnemonic ((_GBPLiborON.cell :?> GBPLiborONModel).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GBPLiborON.source + ".EndOfMonth") 
                                               [| _GBPLiborON.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
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
    [<ExcelFunction(Name="_GBPLiborON_forecastFixing1", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLiborON_forecastFixing1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "Reference to GBPLiborON")>] 
         gbpliboron : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON" true 
                let _d1 = Helper.toCell<Date> d1 "d1" true
                let _d2 = Helper.toCell<Date> d2 "d2" true
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_GBPLiborON.cell :?> GBPLiborONModel).ForecastFixing1
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GBPLiborON.source + ".ForecastFixing1") 
                                               [| _GBPLiborON.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
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
    [<ExcelFunction(Name="_GBPLiborON_forecastFixing", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLiborON_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "Reference to GBPLiborON")>] 
         gbpliboron : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_GBPLiborON.cell :?> GBPLiborONModel).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GBPLiborON.source + ".ForecastFixing") 
                                               [| _GBPLiborON.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
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
    [<ExcelFunction(Name="_GBPLiborON_forwardingTermStructure", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLiborON_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "Reference to GBPLiborON")>] 
         gbpliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON" true 
                let builder () = withMnemonic mnemonic ((_GBPLiborON.cell :?> GBPLiborONModel).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_GBPLiborON.source + ".ForwardingTermStructure") 
                                               [| _GBPLiborON.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
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
    [<ExcelFunction(Name="_GBPLiborON_maturityDate", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLiborON_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "Reference to GBPLiborON")>] 
         gbpliboron : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON" true 
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" true
                let builder () = withMnemonic mnemonic ((_GBPLiborON.cell :?> GBPLiborONModel).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_GBPLiborON.source + ".MaturityDate") 
                                               [| _GBPLiborON.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
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
    [<ExcelFunction(Name="_GBPLiborON_currency", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLiborON_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "Reference to GBPLiborON")>] 
         gbpliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON" true 
                let builder () = withMnemonic mnemonic ((_GBPLiborON.cell :?> GBPLiborONModel).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_GBPLiborON.source + ".Currency") 
                                               [| _GBPLiborON.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
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
    [<ExcelFunction(Name="_GBPLiborON_dayCounter", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLiborON_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "Reference to GBPLiborON")>] 
         gbpliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON" true 
                let builder () = withMnemonic mnemonic ((_GBPLiborON.cell :?> GBPLiborONModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_GBPLiborON.source + ".DayCounter") 
                                               [| _GBPLiborON.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
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
    [<ExcelFunction(Name="_GBPLiborON_familyName", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLiborON_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "Reference to GBPLiborON")>] 
         gbpliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON" true 
                let builder () = withMnemonic mnemonic ((_GBPLiborON.cell :?> GBPLiborONModel).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GBPLiborON.source + ".FamilyName") 
                                               [| _GBPLiborON.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
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
    [<ExcelFunction(Name="_GBPLiborON_fixing", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLiborON_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "Reference to GBPLiborON")>] 
         gbpliboron : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" true
                let builder () = withMnemonic mnemonic ((_GBPLiborON.cell :?> GBPLiborONModel).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GBPLiborON.source + ".Fixing") 
                                               [| _GBPLiborON.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
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
    [<ExcelFunction(Name="_GBPLiborON_fixingCalendar", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLiborON_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "Reference to GBPLiborON")>] 
         gbpliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON" true 
                let builder () = withMnemonic mnemonic ((_GBPLiborON.cell :?> GBPLiborONModel).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_GBPLiborON.source + ".FixingCalendar") 
                                               [| _GBPLiborON.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
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
    [<ExcelFunction(Name="_GBPLiborON_fixingDate", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLiborON_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "Reference to GBPLiborON")>] 
         gbpliboron : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON" true 
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" true
                let builder () = withMnemonic mnemonic ((_GBPLiborON.cell :?> GBPLiborONModel).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_GBPLiborON.source + ".FixingDate") 
                                               [| _GBPLiborON.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
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
    [<ExcelFunction(Name="_GBPLiborON_fixingDays", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLiborON_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "Reference to GBPLiborON")>] 
         gbpliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON" true 
                let builder () = withMnemonic mnemonic ((_GBPLiborON.cell :?> GBPLiborONModel).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_GBPLiborON.source + ".FixingDays") 
                                               [| _GBPLiborON.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
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
    [<ExcelFunction(Name="_GBPLiborON_isValidFixingDate", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLiborON_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "Reference to GBPLiborON")>] 
         gbpliboron : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_GBPLiborON.cell :?> GBPLiborONModel).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GBPLiborON.source + ".IsValidFixingDate") 
                                               [| _GBPLiborON.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
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
    [<ExcelFunction(Name="_GBPLiborON_name", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLiborON_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "Reference to GBPLiborON")>] 
         gbpliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON" true 
                let builder () = withMnemonic mnemonic ((_GBPLiborON.cell :?> GBPLiborONModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GBPLiborON.source + ".Name") 
                                               [| _GBPLiborON.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
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
    [<ExcelFunction(Name="_GBPLiborON_pastFixing", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLiborON_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "Reference to GBPLiborON")>] 
         gbpliboron : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_GBPLiborON.cell :?> GBPLiborONModel).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GBPLiborON.source + ".PastFixing") 
                                               [| _GBPLiborON.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
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
    [<ExcelFunction(Name="_GBPLiborON_tenor", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLiborON_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "Reference to GBPLiborON")>] 
         gbpliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON" true 
                let builder () = withMnemonic mnemonic ((_GBPLiborON.cell :?> GBPLiborONModel).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_GBPLiborON.source + ".Tenor") 
                                               [| _GBPLiborON.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
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
    [<ExcelFunction(Name="_GBPLiborON_update", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLiborON_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "Reference to GBPLiborON")>] 
         gbpliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON" true 
                let builder () = withMnemonic mnemonic ((_GBPLiborON.cell :?> GBPLiborONModel).Update
                                                       ) :> ICell
                let format (o : GBPLiborON) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GBPLiborON.source + ".Update") 
                                               [| _GBPLiborON.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
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
    [<ExcelFunction(Name="_GBPLiborON_valueDate", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLiborON_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "Reference to GBPLiborON")>] 
         gbpliboron : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_GBPLiborON.cell :?> GBPLiborONModel).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_GBPLiborON.source + ".ValueDate") 
                                               [| _GBPLiborON.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
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
    [<ExcelFunction(Name="_GBPLiborON_addFixing", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLiborON_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "Reference to GBPLiborON")>] 
         gbpliboron : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON" true 
                let _d = Helper.toCell<Date> d "d" true
                let _v = Helper.toCell<double> v "v" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_GBPLiborON.cell :?> GBPLiborONModel).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : GBPLiborON) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GBPLiborON.source + ".AddFixing") 
                                               [| _GBPLiborON.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
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
    [<ExcelFunction(Name="_GBPLiborON_addFixings", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLiborON_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "Reference to GBPLiborON")>] 
         gbpliboron : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON" true 
                let _d = Helper.toCell<Generic.List<Date>> d "d" true
                let _v = Helper.toCell<Generic.List<double>> v "v" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_GBPLiborON.cell :?> GBPLiborONModel).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : GBPLiborON) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GBPLiborON.source + ".AddFixings") 
                                               [| _GBPLiborON.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
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
    [<ExcelFunction(Name="_GBPLiborON_addFixings1", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLiborON_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "Reference to GBPLiborON")>] 
         gbpliboron : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON" true 
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_GBPLiborON.cell :?> GBPLiborONModel).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : GBPLiborON) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GBPLiborON.source + ".AddFixings1") 
                                               [| _GBPLiborON.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
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
    [<ExcelFunction(Name="_GBPLiborON_allowsNativeFixings", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLiborON_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "Reference to GBPLiborON")>] 
         gbpliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON" true 
                let builder () = withMnemonic mnemonic ((_GBPLiborON.cell :?> GBPLiborONModel).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GBPLiborON.source + ".AllowsNativeFixings") 
                                               [| _GBPLiborON.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
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
    [<ExcelFunction(Name="_GBPLiborON_clearFixings", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLiborON_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "Reference to GBPLiborON")>] 
         gbpliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON" true 
                let builder () = withMnemonic mnemonic ((_GBPLiborON.cell :?> GBPLiborONModel).ClearFixings
                                                       ) :> ICell
                let format (o : GBPLiborON) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GBPLiborON.source + ".ClearFixings") 
                                               [| _GBPLiborON.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
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
    [<ExcelFunction(Name="_GBPLiborON_registerWith", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLiborON_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "Reference to GBPLiborON")>] 
         gbpliboron : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_GBPLiborON.cell :?> GBPLiborONModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : GBPLiborON) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GBPLiborON.source + ".RegisterWith") 
                                               [| _GBPLiborON.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
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
    [<ExcelFunction(Name="_GBPLiborON_timeSeries", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLiborON_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "Reference to GBPLiborON")>] 
         gbpliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON" true 
                let builder () = withMnemonic mnemonic ((_GBPLiborON.cell :?> GBPLiborONModel).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GBPLiborON.source + ".TimeSeries") 
                                               [| _GBPLiborON.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
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
    [<ExcelFunction(Name="_GBPLiborON_unregisterWith", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLiborON_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "Reference to GBPLiborON")>] 
         gbpliboron : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_GBPLiborON.cell :?> GBPLiborONModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : GBPLiborON) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GBPLiborON.source + ".UnregisterWith") 
                                               [| _GBPLiborON.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
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
    [<ExcelFunction(Name="_GBPLiborON_Range", Description="Create a range of GBPLiborON",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLiborON_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the GBPLiborON")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<GBPLiborON> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<GBPLiborON>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<GBPLiborON>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<GBPLiborON>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"