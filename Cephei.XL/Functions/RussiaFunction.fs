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
  Public holidays (see <http://www.cbr.ru/eng/>:):
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year holidays and Christmas, January 1st to 8th</li>
<li>Defender of the Fatherland Day, February 23rd (possibly moved to Monday)</li>
<li>International Women's Day, March 8th (possibly moved to Monday)</li>
<li>Labour Day, May 1st (possibly moved to Monday)</li>
<li>Victory Day, May 9th (possibly moved to Monday)</li>
<li>Russia Day, June 12th (possibly moved to Monday)</li>
<li>Unity Day, November 4th (possibly moved to Monday)</li>
</ul>  Holidays for the Moscow Exchange (MOEX) taken from
<http://moex.com/s726> and related pages.  These holidays are
<em>not</em> consistent year-to-year, may or may not correlate to public holidays, and are only available for dates since the introduction of the MOEX 'brand' (a merger of the stock and futures markets).  calendars
  </summary> *)
[<AutoSerializable(true)>]
module RussiaFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Russia", Description="Create a Russia",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Russia_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="m",Description = "Russia.Market: Settlement, MOEX")>] 
         m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _m = Helper.toCell<Russia.Market> m "m" 
                let builder (current : ICell) = (Fun.Russia 
                                                            _m.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Russia>) l

                let source () = Helper.sourceFold "Fun.Russia" 
                                               [| _m.source
                                               |]
                let hash = Helper.hashFold 
                                [| _m.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Russia> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Russia1", Description="Create a Russia",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Russia_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = (Fun.Russia1 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Russia>) l

                let source () = Helper.sourceFold "Fun.Russia1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Russia> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Russia_addedHolidays", Description="Create a Russia",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Russia_addedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Russia",Description = "Russia")>] 
         russia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Russia = Helper.toModelReference<Russia> russia "Russia"  
                let builder (current : ICell) = ((RussiaModel.Cast _Russia.cell).AddedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<Date>) (l : string) = Helper.Range.fromList i l

                let source () = Helper.sourceFold (_Russia.source + ".AddedHolidays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Russia.cell
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
    [<ExcelFunction(Name="_Russia_addHoliday", Description="Create a Russia",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Russia_addHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Russia",Description = "Russia")>] 
         russia : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Russia = Helper.toModelReference<Russia> russia "Russia"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = ((RussiaModel.Cast _Russia.cell).AddHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : Russia) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Russia.source + ".AddHoliday") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Russia.cell
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
        
    *)
    [<ExcelFunction(Name="_Russia_adjust", Description="Create a Russia",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Russia_adjust
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Russia",Description = "Russia")>] 
         russia : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="c",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Russia = Helper.toModelReference<Russia> russia "Russia"  
                let _d = Helper.toCell<Date> d "d" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let builder (current : ICell) = ((RussiaModel.Cast _Russia.cell).Adjust
                                                            _d.cell 
                                                            _c.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Russia.source + ".Adjust") 

                                               [| _d.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Russia.cell
                                ;  _d.cell
                                ;  _c.cell
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
    [<ExcelFunction(Name="_Russia_advance1", Description="Create a Russia",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Russia_advance1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Russia",Description = "Russia")>] 
         russia : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="n",Description = "int")>] 
         n : obj)
        ([<ExcelArgument(Name="unit",Description = "TimeUnit: Days, Weeks, Months, Years")>] 
         unit : obj)
        ([<ExcelArgument(Name="c",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         c : obj)
        ([<ExcelArgument(Name="endOfMonth",Description = "bool")>] 
         endOfMonth : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Russia = Helper.toModelReference<Russia> russia "Russia"  
                let _d = Helper.toCell<Date> d "d" 
                let _n = Helper.toCell<int> n "n" 
                let _unit = Helper.toCell<TimeUnit> unit "unit" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" 
                let builder (current : ICell) = ((RussiaModel.Cast _Russia.cell).Advance1
                                                            _d.cell 
                                                            _n.cell 
                                                            _unit.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Russia.source + ".Advance1") 

                                               [| _d.source
                                               ;  _n.source
                                               ;  _unit.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Russia.cell
                                ;  _d.cell
                                ;  _n.cell
                                ;  _unit.cell
                                ;  _c.cell
                                ;  _endOfMonth.cell
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
    [<ExcelFunction(Name="_Russia_advance", Description="Create a Russia",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Russia_advance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Russia",Description = "Russia")>] 
         russia : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="p",Description = "Period")>] 
         p : obj)
        ([<ExcelArgument(Name="c",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         c : obj)
        ([<ExcelArgument(Name="endOfMonth",Description = "bool")>] 
         endOfMonth : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Russia = Helper.toModelReference<Russia> russia "Russia"  
                let _d = Helper.toCell<Date> d "d" 
                let _p = Helper.toCell<Period> p "p" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" 
                let builder (current : ICell) = ((RussiaModel.Cast _Russia.cell).Advance
                                                            _d.cell 
                                                            _p.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Russia.source + ".Advance") 

                                               [| _d.source
                                               ;  _p.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Russia.cell
                                ;  _d.cell
                                ;  _p.cell
                                ;  _c.cell
                                ;  _endOfMonth.cell
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
    [<ExcelFunction(Name="_Russia_businessDaysBetween", Description="Create a Russia",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Russia_businessDaysBetween
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Russia",Description = "Russia")>] 
         russia : obj)
        ([<ExcelArgument(Name="from",Description = "Date")>] 
         from : obj)
        ([<ExcelArgument(Name="To",Description = "Date")>] 
         To : obj)
        ([<ExcelArgument(Name="includeFirst",Description = "bool")>] 
         includeFirst : obj)
        ([<ExcelArgument(Name="includeLast",Description = "bool")>] 
         includeLast : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Russia = Helper.toModelReference<Russia> russia "Russia"  
                let _from = Helper.toCell<Date> from "from" 
                let _To = Helper.toCell<Date> To "To" 
                let _includeFirst = Helper.toCell<bool> includeFirst "includeFirst" 
                let _includeLast = Helper.toCell<bool> includeLast "includeLast" 
                let builder (current : ICell) = ((RussiaModel.Cast _Russia.cell).BusinessDaysBetween
                                                            _from.cell 
                                                            _To.cell 
                                                            _includeFirst.cell 
                                                            _includeLast.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Russia.source + ".BusinessDaysBetween") 

                                               [| _from.source
                                               ;  _To.source
                                               ;  _includeFirst.source
                                               ;  _includeLast.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Russia.cell
                                ;  _from.cell
                                ;  _To.cell
                                ;  _includeFirst.cell
                                ;  _includeLast.cell
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
    [<ExcelFunction(Name="_Russia_calendar", Description="Create a Russia",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Russia_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Russia",Description = "Russia")>] 
         russia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Russia = Helper.toModelReference<Russia> russia "Russia"  
                let builder (current : ICell) = ((RussiaModel.Cast _Russia.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_Russia.source + ".Calendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Russia.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Russia> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Returns whether or not the calendar is initialized
    *)
    [<ExcelFunction(Name="_Russia_empty", Description="Create a Russia",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Russia_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Russia",Description = "Russia")>] 
         russia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Russia = Helper.toModelReference<Russia> russia "Russia"  
                let builder (current : ICell) = ((RussiaModel.Cast _Russia.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Russia.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Russia.cell
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
    [<ExcelFunction(Name="_Russia_endOfMonth", Description="Create a Russia",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Russia_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Russia",Description = "Russia")>] 
         russia : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Russia = Helper.toModelReference<Russia> russia "Russia"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = ((RussiaModel.Cast _Russia.cell).EndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Russia.source + ".EndOfMonth") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Russia.cell
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
        
    *)
    [<ExcelFunction(Name="_Russia_Equals", Description="Create a Russia",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Russia_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Russia",Description = "Russia")>] 
         russia : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Russia = Helper.toModelReference<Russia> russia "Russia"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = ((RussiaModel.Cast _Russia.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Russia.source + ".Equals") 

                                               [| _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Russia.cell
                                ;  _o.cell
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
        @returns Returns <tt>true</tt> iff the date is a business day for the given market.
    *)
    [<ExcelFunction(Name="_Russia_isBusinessDay", Description="Create a Russia",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Russia_isBusinessDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Russia",Description = "Russia")>] 
         russia : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Russia = Helper.toModelReference<Russia> russia "Russia"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = ((RussiaModel.Cast _Russia.cell).IsBusinessDay
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Russia.source + ".IsBusinessDay") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Russia.cell
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
        
    *)
    [<ExcelFunction(Name="_Russia_isEndOfMonth", Description="Create a Russia",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Russia_isEndOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Russia",Description = "Russia")>] 
         russia : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Russia = Helper.toModelReference<Russia> russia "Russia"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = ((RussiaModel.Cast _Russia.cell).IsEndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Russia.source + ".IsEndOfMonth") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Russia.cell
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
        Returns <tt>true</tt> iff the date is a holiday for the given market.
    *)
    [<ExcelFunction(Name="_Russia_isHoliday", Description="Create a Russia",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Russia_isHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Russia",Description = "Russia")>] 
         russia : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Russia = Helper.toModelReference<Russia> russia "Russia"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = ((RussiaModel.Cast _Russia.cell).IsHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Russia.source + ".IsHoliday") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Russia.cell
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
        Returns <tt>true</tt> iff the weekday is part of the weekend for the given market.
    *)
    [<ExcelFunction(Name="_Russia_isWeekend", Description="Create a Russia",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Russia_isWeekend
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Russia",Description = "Russia")>] 
         russia : obj)
        ([<ExcelArgument(Name="w",Description = "DayOfWeek")>] 
         w : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Russia = Helper.toModelReference<Russia> russia "Russia"  
                let _w = Helper.toCell<DayOfWeek> w "w" 
                let builder (current : ICell) = ((RussiaModel.Cast _Russia.cell).IsWeekend
                                                            _w.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Russia.source + ".IsWeekend") 

                                               [| _w.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Russia.cell
                                ;  _w.cell
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
        This method is used for output and comparison between calendars. It is <b>not</b> meant to be used for writing switch-on-type code.

@returns The name of the calendar.
    *)
    [<ExcelFunction(Name="_Russia_name", Description="Create a Russia",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Russia_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Russia",Description = "Russia")>] 
         russia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Russia = Helper.toModelReference<Russia> russia "Russia"  
                let builder (current : ICell) = ((RussiaModel.Cast _Russia.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Russia.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Russia.cell
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
    [<ExcelFunction(Name="_Russia_removedHolidays", Description="Create a Russia",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Russia_removedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Russia",Description = "Russia")>] 
         russia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Russia = Helper.toModelReference<Russia> russia "Russia"  
                let builder (current : ICell) = ((RussiaModel.Cast _Russia.cell).RemovedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<Date>) (l : string) = Helper.Range.fromList i l

                let source () = Helper.sourceFold (_Russia.source + ".RemovedHolidays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Russia.cell
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
    [<ExcelFunction(Name="_Russia_removeHoliday", Description="Create a Russia",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Russia_removeHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Russia",Description = "Russia")>] 
         russia : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Russia = Helper.toModelReference<Russia> russia "Russia"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = ((RussiaModel.Cast _Russia.cell).RemoveHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : Russia) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Russia.source + ".RemoveHoliday") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Russia.cell
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
    [<ExcelFunction(Name="_Russia_Range", Description="Create a range of Russia",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Russia_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Russia> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<Russia> (c)) :> ICell
                let format (i : Cephei.Cell.List<Russia>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<Russia>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
