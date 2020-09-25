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
  Holidays:
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st (possibly moved to Monday)</li>
<li>Good Friday</li>
<li>Easter Monday</li>
<li>Labor Day, May 1st (possibly moved to Monday)</li>
<li>SAR Establishment Day, July 1st (possibly moved to Monday)</li>
<li>National Day, October 1st (possibly moved to Monday)</li>
<li>Christmas, December 25th</li>
<li>Boxing Day, December 26th</li>
</ul>  Other holidays for which no rule is given (data available for 2004-2013 only:)
<ul>
<li>Lunar New Year</li>
<li>Chinese New Year</li>
<li>Ching Ming Festival</li>
<li>Buddha's birthday</li>
<li>Tuen NG Festival</li>
<li>Mid-autumn Festival</li>
<li>Chung Yeung Festival</li>
</ul>  Data from <http://www.hkex.com.hk>  calendars
  </summary> *)
[<AutoSerializable(true)>]
module HongKongFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_HongKong", Description="Create a HongKong",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HongKong_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.HongKong ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<HongKong>) l

                let source = Helper.sourceFold "Fun.HongKong" 
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
    [<ExcelFunction(Name="_HongKong_addedHolidays", Description="Create a HongKong",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HongKong_addedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HongKong",Description = "Reference to HongKong")>] 
         hongkong : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HongKong = Helper.toCell<HongKong> hongkong "HongKong" true 
                let builder () = withMnemonic mnemonic ((_HongKong.cell :?> HongKongModel).AddedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_HongKong.source + ".AddedHolidays") 
                                               [| _HongKong.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HongKong.cell
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
    [<ExcelFunction(Name="_HongKong_addHoliday", Description="Create a HongKong",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HongKong_addHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HongKong",Description = "Reference to HongKong")>] 
         hongkong : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HongKong = Helper.toCell<HongKong> hongkong "HongKong" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_HongKong.cell :?> HongKongModel).AddHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : HongKong) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_HongKong.source + ".AddHoliday") 
                                               [| _HongKong.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HongKong.cell
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
    [<ExcelFunction(Name="_HongKong_adjust", Description="Create a HongKong",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HongKong_adjust
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HongKong",Description = "Reference to HongKong")>] 
         hongkong : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HongKong = Helper.toCell<HongKong> hongkong "HongKong" true 
                let _d = Helper.toCell<Date> d "d" true
                let _c = Helper.toCell<BusinessDayConvention> c "c" true
                let builder () = withMnemonic mnemonic ((_HongKong.cell :?> HongKongModel).Adjust
                                                            _d.cell 
                                                            _c.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_HongKong.source + ".Adjust") 
                                               [| _HongKong.source
                                               ;  _d.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HongKong.cell
                                ;  _d.cell
                                ;  _c.cell
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
    [<ExcelFunction(Name="_HongKong_advance1", Description="Create a HongKong",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HongKong_advance1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HongKong",Description = "Reference to HongKong")>] 
         hongkong : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="n",Description = "Reference to n")>] 
         n : obj)
        ([<ExcelArgument(Name="unit",Description = "Reference to unit")>] 
         unit : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        ([<ExcelArgument(Name="endOfMonth",Description = "Reference to endOfMonth")>] 
         endOfMonth : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HongKong = Helper.toCell<HongKong> hongkong "HongKong" true 
                let _d = Helper.toCell<Date> d "d" true
                let _n = Helper.toCell<int> n "n" true
                let _unit = Helper.toCell<TimeUnit> unit "unit" true
                let _c = Helper.toCell<BusinessDayConvention> c "c" true
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" true
                let builder () = withMnemonic mnemonic ((_HongKong.cell :?> HongKongModel).Advance1
                                                            _d.cell 
                                                            _n.cell 
                                                            _unit.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_HongKong.source + ".Advance1") 
                                               [| _HongKong.source
                                               ;  _d.source
                                               ;  _n.source
                                               ;  _unit.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HongKong.cell
                                ;  _d.cell
                                ;  _n.cell
                                ;  _unit.cell
                                ;  _c.cell
                                ;  _endOfMonth.cell
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
    [<ExcelFunction(Name="_HongKong_advance", Description="Create a HongKong",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HongKong_advance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HongKong",Description = "Reference to HongKong")>] 
         hongkong : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="p",Description = "Reference to p")>] 
         p : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        ([<ExcelArgument(Name="endOfMonth",Description = "Reference to endOfMonth")>] 
         endOfMonth : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HongKong = Helper.toCell<HongKong> hongkong "HongKong" true 
                let _d = Helper.toCell<Date> d "d" true
                let _p = Helper.toCell<Period> p "p" true
                let _c = Helper.toCell<BusinessDayConvention> c "c" true
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" true
                let builder () = withMnemonic mnemonic ((_HongKong.cell :?> HongKongModel).Advance
                                                            _d.cell 
                                                            _p.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_HongKong.source + ".Advance") 
                                               [| _HongKong.source
                                               ;  _d.source
                                               ;  _p.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HongKong.cell
                                ;  _d.cell
                                ;  _p.cell
                                ;  _c.cell
                                ;  _endOfMonth.cell
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
    [<ExcelFunction(Name="_HongKong_businessDaysBetween", Description="Create a HongKong",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HongKong_businessDaysBetween
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HongKong",Description = "Reference to HongKong")>] 
         hongkong : obj)
        ([<ExcelArgument(Name="from",Description = "Reference to from")>] 
         from : obj)
        ([<ExcelArgument(Name="To",Description = "Reference to To")>] 
         To : obj)
        ([<ExcelArgument(Name="includeFirst",Description = "Reference to includeFirst")>] 
         includeFirst : obj)
        ([<ExcelArgument(Name="includeLast",Description = "Reference to includeLast")>] 
         includeLast : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HongKong = Helper.toCell<HongKong> hongkong "HongKong" true 
                let _from = Helper.toCell<Date> from "from" true
                let _To = Helper.toCell<Date> To "To" true
                let _includeFirst = Helper.toCell<bool> includeFirst "includeFirst" true
                let _includeLast = Helper.toCell<bool> includeLast "includeLast" true
                let builder () = withMnemonic mnemonic ((_HongKong.cell :?> HongKongModel).BusinessDaysBetween
                                                            _from.cell 
                                                            _To.cell 
                                                            _includeFirst.cell 
                                                            _includeLast.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_HongKong.source + ".BusinessDaysBetween") 
                                               [| _HongKong.source
                                               ;  _from.source
                                               ;  _To.source
                                               ;  _includeFirst.source
                                               ;  _includeLast.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HongKong.cell
                                ;  _from.cell
                                ;  _To.cell
                                ;  _includeFirst.cell
                                ;  _includeLast.cell
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
    [<ExcelFunction(Name="_HongKong_calendar", Description="Create a HongKong",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HongKong_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HongKong",Description = "Reference to HongKong")>] 
         hongkong : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HongKong = Helper.toCell<HongKong> hongkong "HongKong" true 
                let builder () = withMnemonic mnemonic ((_HongKong.cell :?> HongKongModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_HongKong.source + ".Calendar") 
                                               [| _HongKong.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HongKong.cell
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
        Returns whether or not the calendar is initialized
    *)
    [<ExcelFunction(Name="_HongKong_empty", Description="Create a HongKong",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HongKong_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HongKong",Description = "Reference to HongKong")>] 
         hongkong : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HongKong = Helper.toCell<HongKong> hongkong "HongKong" true 
                let builder () = withMnemonic mnemonic ((_HongKong.cell :?> HongKongModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_HongKong.source + ".Empty") 
                                               [| _HongKong.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HongKong.cell
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
    [<ExcelFunction(Name="_HongKong_endOfMonth", Description="Create a HongKong",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HongKong_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HongKong",Description = "Reference to HongKong")>] 
         hongkong : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HongKong = Helper.toCell<HongKong> hongkong "HongKong" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_HongKong.cell :?> HongKongModel).EndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_HongKong.source + ".EndOfMonth") 
                                               [| _HongKong.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HongKong.cell
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
    [<ExcelFunction(Name="_HongKong_Equals", Description="Create a HongKong",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HongKong_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HongKong",Description = "Reference to HongKong")>] 
         hongkong : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HongKong = Helper.toCell<HongKong> hongkong "HongKong" true 
                let _o = Helper.toCell<Object> o "o" true
                let builder () = withMnemonic mnemonic ((_HongKong.cell :?> HongKongModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_HongKong.source + ".Equals") 
                                               [| _HongKong.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HongKong.cell
                                ;  _o.cell
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
        @returns Returns <tt>true</tt> iff the date is a business day for the given market.
    *)
    [<ExcelFunction(Name="_HongKong_isBusinessDay", Description="Create a HongKong",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HongKong_isBusinessDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HongKong",Description = "Reference to HongKong")>] 
         hongkong : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HongKong = Helper.toCell<HongKong> hongkong "HongKong" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_HongKong.cell :?> HongKongModel).IsBusinessDay
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_HongKong.source + ".IsBusinessDay") 
                                               [| _HongKong.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HongKong.cell
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
    [<ExcelFunction(Name="_HongKong_isEndOfMonth", Description="Create a HongKong",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HongKong_isEndOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HongKong",Description = "Reference to HongKong")>] 
         hongkong : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HongKong = Helper.toCell<HongKong> hongkong "HongKong" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_HongKong.cell :?> HongKongModel).IsEndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_HongKong.source + ".IsEndOfMonth") 
                                               [| _HongKong.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HongKong.cell
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
        Returns <tt>true</tt> iff the date is a holiday for the given market.
    *)
    [<ExcelFunction(Name="_HongKong_isHoliday", Description="Create a HongKong",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HongKong_isHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HongKong",Description = "Reference to HongKong")>] 
         hongkong : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HongKong = Helper.toCell<HongKong> hongkong "HongKong" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_HongKong.cell :?> HongKongModel).IsHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_HongKong.source + ".IsHoliday") 
                                               [| _HongKong.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HongKong.cell
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
        Returns <tt>true</tt> iff the weekday is part of the weekend for the given market.
    *)
    [<ExcelFunction(Name="_HongKong_isWeekend", Description="Create a HongKong",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HongKong_isWeekend
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HongKong",Description = "Reference to HongKong")>] 
         hongkong : obj)
        ([<ExcelArgument(Name="w",Description = "Reference to w")>] 
         w : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HongKong = Helper.toCell<HongKong> hongkong "HongKong" true 
                let _w = Helper.toCell<DayOfWeek> w "w" true
                let builder () = withMnemonic mnemonic ((_HongKong.cell :?> HongKongModel).IsWeekend
                                                            _w.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_HongKong.source + ".IsWeekend") 
                                               [| _HongKong.source
                                               ;  _w.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HongKong.cell
                                ;  _w.cell
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
        This method is used for output and comparison between calendars. It is <b>not</b> meant to be used for writing switch-on-type code.

@returns The name of the calendar.
    *)
    [<ExcelFunction(Name="_HongKong_name", Description="Create a HongKong",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HongKong_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HongKong",Description = "Reference to HongKong")>] 
         hongkong : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HongKong = Helper.toCell<HongKong> hongkong "HongKong" true 
                let builder () = withMnemonic mnemonic ((_HongKong.cell :?> HongKongModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_HongKong.source + ".Name") 
                                               [| _HongKong.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HongKong.cell
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
    [<ExcelFunction(Name="_HongKong_removedHolidays", Description="Create a HongKong",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HongKong_removedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HongKong",Description = "Reference to HongKong")>] 
         hongkong : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HongKong = Helper.toCell<HongKong> hongkong "HongKong" true 
                let builder () = withMnemonic mnemonic ((_HongKong.cell :?> HongKongModel).RemovedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_HongKong.source + ".RemovedHolidays") 
                                               [| _HongKong.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HongKong.cell
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
    [<ExcelFunction(Name="_HongKong_removeHoliday", Description="Create a HongKong",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HongKong_removeHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HongKong",Description = "Reference to HongKong")>] 
         hongkong : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HongKong = Helper.toCell<HongKong> hongkong "HongKong" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_HongKong.cell :?> HongKongModel).RemoveHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : HongKong) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_HongKong.source + ".RemoveHoliday") 
                                               [| _HongKong.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HongKong.cell
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
    [<ExcelFunction(Name="_HongKong_Range", Description="Create a range of HongKong",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HongKong_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the HongKong")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<HongKong> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<HongKong>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<HongKong>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<HongKong>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"