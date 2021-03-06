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
module CADLiborONFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_CADLiborON", Description="Create a CADLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CADLiborON_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="h",Description = "YieldTermStructure")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let builder (current : ICell) = (Fun.CADLiborON 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CADLiborON>) l

                let source () = Helper.sourceFold "Fun.CADLiborON" 
                                               [| _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _h.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CADLiborON> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CADLiborON1", Description="Create a CADLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CADLiborON_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = (Fun.CADLiborON1 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CADLiborON>) l

                let source () = Helper.sourceFold "Fun.CADLiborON1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CADLiborON> format
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
    [<ExcelFunction(Name="_CADLiborON_businessDayConvention", Description="Create a CADLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CADLiborON_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLiborON",Description = "CADLiborON")>] 
         cadliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLiborON = Helper.toModelReference<CADLiborON> cadliboron "CADLiborON"  
                let builder (current : ICell) = ((CADLiborONModel.Cast _CADLiborON.cell).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CADLiborON.source + ".BusinessDayConvention") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CADLiborON.cell
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
        Other methods returns a copy of itself linked to a different forwarding curve
    *)
    [<ExcelFunction(Name="_CADLiborON_clone", Description="Create a CADLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CADLiborON_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLiborON",Description = "CADLiborON")>] 
         cadliboron : obj)
        ([<ExcelArgument(Name="forwarding",Description = "YieldTermStructure")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLiborON = Helper.toModelReference<CADLiborON> cadliboron "CADLiborON"  
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let builder (current : ICell) = ((CADLiborONModel.Cast _CADLiborON.cell).Clone
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source () = Helper.sourceFold (_CADLiborON.source + ".Clone") 

                                               [| _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CADLiborON.cell
                                ;  _forwarding.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CADLiborON> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CADLiborON_endOfMonth", Description="Create a CADLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CADLiborON_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLiborON",Description = "CADLiborON")>] 
         cadliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLiborON = Helper.toModelReference<CADLiborON> cadliboron "CADLiborON"  
                let builder (current : ICell) = ((CADLiborONModel.Cast _CADLiborON.cell).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CADLiborON.source + ".EndOfMonth") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CADLiborON.cell
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
    [<ExcelFunction(Name="_CADLiborON_forecastFixing1", Description="Create a CADLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CADLiborON_forecastFixing1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLiborON",Description = "CADLiborON")>] 
         cadliboron : obj)
        ([<ExcelArgument(Name="d1",Description = "Date")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Date")>] 
         d2 : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLiborON = Helper.toModelReference<CADLiborON> cadliboron "CADLiborON"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = ((CADLiborONModel.Cast _CADLiborON.cell).ForecastFixing1
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CADLiborON.source + ".ForecastFixing1") 

                                               [| _d1.source
                                               ;  _d2.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CADLiborON.cell
                                ;  _d1.cell
                                ;  _d2.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_CADLiborON_forecastFixing", Description="Create a CADLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CADLiborON_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLiborON",Description = "CADLiborON")>] 
         cadliboron : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLiborON = Helper.toModelReference<CADLiborON> cadliboron "CADLiborON"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = ((CADLiborONModel.Cast _CADLiborON.cell).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CADLiborON.source + ".ForecastFixing") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CADLiborON.cell
                                ;  _fixingDate.cell
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
        the curve used to forecast fixings
    *)
    [<ExcelFunction(Name="_CADLiborON_forwardingTermStructure", Description="Create a CADLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CADLiborON_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLiborON",Description = "CADLiborON")>] 
         cadliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLiborON = Helper.toModelReference<CADLiborON> cadliboron "CADLiborON"  
                let builder (current : ICell) = ((CADLiborONModel.Cast _CADLiborON.cell).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_CADLiborON.source + ".ForwardingTermStructure") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CADLiborON.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CADLiborON> format
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
    [<ExcelFunction(Name="_CADLiborON_maturityDate", Description="Create a CADLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CADLiborON_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLiborON",Description = "CADLiborON")>] 
         cadliboron : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Date")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLiborON = Helper.toModelReference<CADLiborON> cadliboron "CADLiborON"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = ((CADLiborONModel.Cast _CADLiborON.cell).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CADLiborON.source + ".MaturityDate") 

                                               [| _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CADLiborON.cell
                                ;  _valueDate.cell
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
    [<ExcelFunction(Name="_CADLiborON_currency", Description="Create a CADLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CADLiborON_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLiborON",Description = "CADLiborON")>] 
         cadliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLiborON = Helper.toModelReference<CADLiborON> cadliboron "CADLiborON"  
                let builder (current : ICell) = ((CADLiborONModel.Cast _CADLiborON.cell).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_CADLiborON.source + ".Currency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CADLiborON.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CADLiborON> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CADLiborON_dayCounter", Description="Create a CADLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CADLiborON_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLiborON",Description = "CADLiborON")>] 
         cadliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLiborON = Helper.toModelReference<CADLiborON> cadliboron "CADLiborON"  
                let builder (current : ICell) = ((CADLiborONModel.Cast _CADLiborON.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_CADLiborON.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CADLiborON.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CADLiborON> format
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
    [<ExcelFunction(Name="_CADLiborON_familyName", Description="Create a CADLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CADLiborON_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLiborON",Description = "CADLiborON")>] 
         cadliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLiborON = Helper.toModelReference<CADLiborON> cadliboron "CADLiborON"  
                let builder (current : ICell) = ((CADLiborONModel.Cast _CADLiborON.cell).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CADLiborON.source + ".FamilyName") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CADLiborON.cell
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
    [<ExcelFunction(Name="_CADLiborON_fixing", Description="Create a CADLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CADLiborON_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLiborON",Description = "CADLiborON")>] 
         cadliboron : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "bool")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLiborON = Helper.toModelReference<CADLiborON> cadliboron "CADLiborON"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder (current : ICell) = ((CADLiborONModel.Cast _CADLiborON.cell).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CADLiborON.source + ".Fixing") 

                                               [| _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CADLiborON.cell
                                ;  _fixingDate.cell
                                ;  _forecastTodaysFixing.cell
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
    [<ExcelFunction(Name="_CADLiborON_fixingCalendar", Description="Create a CADLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CADLiborON_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLiborON",Description = "CADLiborON")>] 
         cadliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLiborON = Helper.toModelReference<CADLiborON> cadliboron "CADLiborON"  
                let builder (current : ICell) = ((CADLiborONModel.Cast _CADLiborON.cell).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_CADLiborON.source + ".FixingCalendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CADLiborON.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CADLiborON> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CADLiborON_fixingDate", Description="Create a CADLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CADLiborON_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLiborON",Description = "CADLiborON")>] 
         cadliboron : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Date")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLiborON = Helper.toModelReference<CADLiborON> cadliboron "CADLiborON"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = ((CADLiborONModel.Cast _CADLiborON.cell).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CADLiborON.source + ".FixingDate") 

                                               [| _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CADLiborON.cell
                                ;  _valueDate.cell
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
    [<ExcelFunction(Name="_CADLiborON_fixingDays", Description="Create a CADLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CADLiborON_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLiborON",Description = "CADLiborON")>] 
         cadliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLiborON = Helper.toModelReference<CADLiborON> cadliboron "CADLiborON"  
                let builder (current : ICell) = ((CADLiborONModel.Cast _CADLiborON.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CADLiborON.source + ".FixingDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CADLiborON.cell
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
    [<ExcelFunction(Name="_CADLiborON_isValidFixingDate", Description="Create a CADLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CADLiborON_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLiborON",Description = "CADLiborON")>] 
         cadliboron : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLiborON = Helper.toModelReference<CADLiborON> cadliboron "CADLiborON"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = ((CADLiborONModel.Cast _CADLiborON.cell).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CADLiborON.source + ".IsValidFixingDate") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CADLiborON.cell
                                ;  _fixingDate.cell
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
        Index interface
    *)
    [<ExcelFunction(Name="_CADLiborON_name", Description="Create a CADLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CADLiborON_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLiborON",Description = "CADLiborON")>] 
         cadliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLiborON = Helper.toModelReference<CADLiborON> cadliboron "CADLiborON"  
                let builder (current : ICell) = ((CADLiborONModel.Cast _CADLiborON.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CADLiborON.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CADLiborON.cell
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
    [<ExcelFunction(Name="_CADLiborON_pastFixing", Description="Create a CADLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CADLiborON_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLiborON",Description = "CADLiborON")>] 
         cadliboron : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLiborON = Helper.toModelReference<CADLiborON> cadliboron "CADLiborON"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = ((CADLiborONModel.Cast _CADLiborON.cell).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CADLiborON.source + ".PastFixing") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CADLiborON.cell
                                ;  _fixingDate.cell
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
    [<ExcelFunction(Name="_CADLiborON_tenor", Description="Create a CADLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CADLiborON_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLiborON",Description = "CADLiborON")>] 
         cadliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLiborON = Helper.toModelReference<CADLiborON> cadliboron "CADLiborON"  
                let builder (current : ICell) = ((CADLiborONModel.Cast _CADLiborON.cell).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_CADLiborON.source + ".Tenor") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CADLiborON.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CADLiborON> format
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
    [<ExcelFunction(Name="_CADLiborON_update", Description="Create a CADLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CADLiborON_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLiborON",Description = "CADLiborON")>] 
         cadliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLiborON = Helper.toModelReference<CADLiborON> cadliboron "CADLiborON"  
                let builder (current : ICell) = ((CADLiborONModel.Cast _CADLiborON.cell).Update
                                                       ) :> ICell
                let format (o : CADLiborON) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CADLiborON.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CADLiborON.cell
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
        Date calculations These methods can be overridden to implement particular conventions (e.g. EurLibor)
    *)
    [<ExcelFunction(Name="_CADLiborON_valueDate", Description="Create a CADLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CADLiborON_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLiborON",Description = "CADLiborON")>] 
         cadliboron : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLiborON = Helper.toModelReference<CADLiborON> cadliboron "CADLiborON"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = ((CADLiborONModel.Cast _CADLiborON.cell).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CADLiborON.source + ".ValueDate") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CADLiborON.cell
                                ;  _fixingDate.cell
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
        Stores the historical fixing at the given date The date passed as arguments must be the actual calendar date of the fixing; no settlement days must be used.
    *)
    [<ExcelFunction(Name="_CADLiborON_addFixing", Description="Create a CADLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CADLiborON_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLiborON",Description = "CADLiborON")>] 
         cadliboron : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "double")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLiborON = Helper.toModelReference<CADLiborON> cadliboron "CADLiborON"  
                let _d = Helper.toCell<Date> d "d" 
                let _v = Helper.toCell<double> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = ((CADLiborONModel.Cast _CADLiborON.cell).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : CADLiborON) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CADLiborON.source + ".AddFixing") 

                                               [| _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CADLiborON.cell
                                ;  _d.cell
                                ;  _v.cell
                                ;  _forceOverwrite.cell
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
        Stores historical fixings at the given dates The dates passed as arguments must be the actual calendar dates of the fixings; no settlement days must be used.
    *)
    [<ExcelFunction(Name="_CADLiborON_addFixings", Description="Create a CADLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CADLiborON_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLiborON",Description = "CADLiborON")>] 
         cadliboron : obj)
        ([<ExcelArgument(Name="d",Description = "Date range")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "double range")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLiborON = Helper.toModelReference<CADLiborON> cadliboron "CADLiborON"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = ((CADLiborONModel.Cast _CADLiborON.cell).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : CADLiborON) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CADLiborON.source + ".AddFixings") 

                                               [| _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CADLiborON.cell
                                ;  _d.cell
                                ;  _v.cell
                                ;  _forceOverwrite.cell
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
        Stores historical fixings from a TimeSeries The dates in the TimeSeries must be the actual calendar dates of the fixings; no settlement days must be used.
    *)
    [<ExcelFunction(Name="_CADLiborON_addFixings1", Description="Create a CADLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CADLiborON_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLiborON",Description = "CADLiborON")>] 
         cadliboron : obj)
        ([<ExcelArgument(Name="source",Description = "double")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLiborON = Helper.toModelReference<CADLiborON> cadliboron "CADLiborON"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = ((CADLiborONModel.Cast _CADLiborON.cell).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : CADLiborON) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CADLiborON.source + ".AddFixings1") 

                                               [| _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CADLiborON.cell
                                ;  _source.cell
                                ;  _forceOverwrite.cell
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
        Check if index allows for native fixings. If this returns false, calls to addFixing and similar methods will raise an exception.
    *)
    [<ExcelFunction(Name="_CADLiborON_allowsNativeFixings", Description="Create a CADLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CADLiborON_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLiborON",Description = "CADLiborON")>] 
         cadliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLiborON = Helper.toModelReference<CADLiborON> cadliboron "CADLiborON"  
                let builder (current : ICell) = ((CADLiborONModel.Cast _CADLiborON.cell).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CADLiborON.source + ".AllowsNativeFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CADLiborON.cell
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
        Clears all stored historical fixings
    *)
    [<ExcelFunction(Name="_CADLiborON_clearFixings", Description="Create a CADLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CADLiborON_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLiborON",Description = "CADLiborON")>] 
         cadliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLiborON = Helper.toModelReference<CADLiborON> cadliboron "CADLiborON"  
                let builder (current : ICell) = ((CADLiborONModel.Cast _CADLiborON.cell).ClearFixings
                                                       ) :> ICell
                let format (o : CADLiborON) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CADLiborON.source + ".ClearFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CADLiborON.cell
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
    [<ExcelFunction(Name="_CADLiborON_registerWith", Description="Create a CADLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CADLiborON_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLiborON",Description = "CADLiborON")>] 
         cadliboron : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLiborON = Helper.toModelReference<CADLiborON> cadliboron "CADLiborON"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((CADLiborONModel.Cast _CADLiborON.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : CADLiborON) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CADLiborON.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CADLiborON.cell
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
        Returns the fixing TimeSeries
    *)
    [<ExcelFunction(Name="_CADLiborON_timeSeries", Description="Create a CADLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CADLiborON_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLiborON",Description = "CADLiborON")>] 
         cadliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLiborON = Helper.toModelReference<CADLiborON> cadliboron "CADLiborON"  
                let builder (current : ICell) = ((CADLiborONModel.Cast _CADLiborON.cell).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CADLiborON.source + ".TimeSeries") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CADLiborON.cell
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
    [<ExcelFunction(Name="_CADLiborON_unregisterWith", Description="Create a CADLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CADLiborON_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLiborON",Description = "CADLiborON")>] 
         cadliboron : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLiborON = Helper.toModelReference<CADLiborON> cadliboron "CADLiborON"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((CADLiborONModel.Cast _CADLiborON.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : CADLiborON) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CADLiborON.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CADLiborON.cell
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
    [<ExcelFunction(Name="_CADLiborON_Range", Description="Create a range of CADLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CADLiborON_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CADLiborON> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<CADLiborON> (c)) :> ICell
                let format (i : Cephei.Cell.List<CADLiborON>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<CADLiborON>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
