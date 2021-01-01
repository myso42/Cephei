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
namespace Cephei.QL

open System
open Cephei.QL.Util
open Cephei.Cell
open Cephei.Cell.Generic
open System.Collections
open System.Collections.Generic
open QLNet
open Cephei.QLNetHelper

(* <summary>
  This calendar has no predefined set of business days. Holidays and weekdays can be defined by means of the provided interface. Instances constructed by copying remain linked to the original one; adding a new holiday or weekday will affect all linked instances.  calendars

  </summary> *)
[<AutoSerializable(true)>]
type BespokeCalendarModel
    ( name                                         : ICell<string>
    ) as this =

    inherit Model<BespokeCalendar> ()
(*
    Parameters
*)
    let _name                                      = name
(*
    Functions
*)
    let mutable
        _BespokeCalendar                           = make (fun () -> new BespokeCalendar (name.Value))
    let _addWeekend                                (w : ICell<DayOfWeek>)   
                                                   = triv _BespokeCalendar (fun () -> _BespokeCalendar.Value.addWeekend(w.Value)
                                                                                      _BespokeCalendar.Value)
    let _name                                      = triv _BespokeCalendar (fun () -> _BespokeCalendar.Value.name())
    let _addedHolidays                             = triv _BespokeCalendar (fun () -> _BespokeCalendar.Value.addedHolidays)
    let _addHoliday                                (d : ICell<Date>)   
                                                   = triv _BespokeCalendar (fun () -> _BespokeCalendar.Value.addHoliday(d.Value)
                                                                                      _BespokeCalendar.Value)
    let _adjust                                    (d : ICell<Date>) (c : ICell<BusinessDayConvention>)   
                                                   = triv _BespokeCalendar (fun () -> _BespokeCalendar.Value.adjust(d.Value, c.Value))
    let _advance                                   (d : ICell<Date>) (p : ICell<Period>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = triv _BespokeCalendar (fun () -> _BespokeCalendar.Value.advance(d.Value, p.Value, c.Value, endOfMonth.Value))
    let _advance1                                  (d : ICell<Date>) (n : ICell<int>) (unit : ICell<TimeUnit>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = triv _BespokeCalendar (fun () -> _BespokeCalendar.Value.advance(d.Value, n.Value, unit.Value, c.Value, endOfMonth.Value))
    let _businessDaysBetween                       (from : ICell<Date>) (To : ICell<Date>) (includeFirst : ICell<bool>) (includeLast : ICell<bool>)   
                                                   = triv _BespokeCalendar (fun () -> _BespokeCalendar.Value.businessDaysBetween(from.Value, To.Value, includeFirst.Value, includeLast.Value))
    let _calendar                                  = triv _BespokeCalendar (fun () -> _BespokeCalendar.Value.calendar)
    let _empty                                     = triv _BespokeCalendar (fun () -> _BespokeCalendar.Value.empty())
    let _endOfMonth                                (d : ICell<Date>)   
                                                   = triv _BespokeCalendar (fun () -> _BespokeCalendar.Value.endOfMonth(d.Value))
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv _BespokeCalendar (fun () -> _BespokeCalendar.Value.Equals(o.Value))
    let _isBusinessDay                             (d : ICell<Date>)   
                                                   = triv _BespokeCalendar (fun () -> _BespokeCalendar.Value.isBusinessDay(d.Value))
    let _isEndOfMonth                              (d : ICell<Date>)   
                                                   = triv _BespokeCalendar (fun () -> _BespokeCalendar.Value.isEndOfMonth(d.Value))
    let _isHoliday                                 (d : ICell<Date>)   
                                                   = triv _BespokeCalendar (fun () -> _BespokeCalendar.Value.isHoliday(d.Value))
    let _isWeekend                                 (w : ICell<DayOfWeek>)   
                                                   = triv _BespokeCalendar (fun () -> _BespokeCalendar.Value.isWeekend(w.Value))
    let _removedHolidays                           = triv _BespokeCalendar (fun () -> _BespokeCalendar.Value.removedHolidays)
    let _removeHoliday                             (d : ICell<Date>)   
                                                   = triv _BespokeCalendar (fun () -> _BespokeCalendar.Value.removeHoliday(d.Value)
                                                                                      _BespokeCalendar.Value)
    do this.Bind(_BespokeCalendar)
(* 
    casting 
*)
    internal new () = new BespokeCalendarModel(null)
    member internal this.Inject v = _BespokeCalendar <- v
    static member Cast (p : ICell<BespokeCalendar>) = 
        if p :? BespokeCalendarModel then 
            p :?> BespokeCalendarModel
        else
            let o = new BespokeCalendarModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.name                               = _name 
    member this.AddWeekend                         w   
                                                   = _addWeekend w 
    member this.Name                               = _name
    member this.AddedHolidays                      = _addedHolidays
    member this.AddHoliday                         d   
                                                   = _addHoliday d 
    member this.Adjust                             d c   
                                                   = _adjust d c 
    member this.Advance                            d p c endOfMonth   
                                                   = _advance d p c endOfMonth 
    member this.Advance1                           d n unit c endOfMonth   
                                                   = _advance1 d n unit c endOfMonth 
    member this.BusinessDaysBetween                from To includeFirst includeLast   
                                                   = _businessDaysBetween from To includeFirst includeLast 
    member this.Calendar                           = _calendar
    member this.Empty                              = _empty
    member this.EndOfMonth                         d   
                                                   = _endOfMonth d 
    member this.Equals                             o   
                                                   = _Equals o 
    member this.IsBusinessDay                      d   
                                                   = _isBusinessDay d 
    member this.IsEndOfMonth                       d   
                                                   = _isEndOfMonth d 
    member this.IsHoliday                          d   
                                                   = _isHoliday d 
    member this.IsWeekend                          w   
                                                   = _isWeekend w 
    member this.RemovedHolidays                    = _removedHolidays
    member this.RemoveHoliday                      d   
                                                   = _removeHoliday d 
(* <summary>
  This calendar has no predefined set of business days. Holidays and weekdays can be defined by means of the provided interface. Instances constructed by copying remain linked to the original one; adding a new holiday or weekday will affect all linked instances.  calendars
! \warning different bespoke calendars created with the same name (or different bespoke calendars created with no name) will compare as equal.
  </summary> *)
[<AutoSerializable(true)>]
type BespokeCalendarModel1
    () as this =
    inherit Model<BespokeCalendar> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _BespokeCalendar                           = make (fun () -> new BespokeCalendar ())
    let _addWeekend                                (w : ICell<DayOfWeek>)   
                                                   = triv _BespokeCalendar (fun () -> _BespokeCalendar.Value.addWeekend(w.Value)
                                                                                      _BespokeCalendar.Value)
    let _name                                      = triv _BespokeCalendar (fun () -> _BespokeCalendar.Value.name())
    let _addedHolidays                             = triv _BespokeCalendar (fun () -> _BespokeCalendar.Value.addedHolidays)
    let _addHoliday                                (d : ICell<Date>)   
                                                   = triv _BespokeCalendar (fun () -> _BespokeCalendar.Value.addHoliday(d.Value)
                                                                                      _BespokeCalendar.Value)
    let _adjust                                    (d : ICell<Date>) (c : ICell<BusinessDayConvention>)   
                                                   = triv _BespokeCalendar (fun () -> _BespokeCalendar.Value.adjust(d.Value, c.Value))
    let _advance                                   (d : ICell<Date>) (p : ICell<Period>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = triv _BespokeCalendar (fun () -> _BespokeCalendar.Value.advance(d.Value, p.Value, c.Value, endOfMonth.Value))
    let _advance1                                  (d : ICell<Date>) (n : ICell<int>) (unit : ICell<TimeUnit>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = triv _BespokeCalendar (fun () -> _BespokeCalendar.Value.advance(d.Value, n.Value, unit.Value, c.Value, endOfMonth.Value))
    let _businessDaysBetween                       (from : ICell<Date>) (To : ICell<Date>) (includeFirst : ICell<bool>) (includeLast : ICell<bool>)   
                                                   = triv _BespokeCalendar (fun () -> _BespokeCalendar.Value.businessDaysBetween(from.Value, To.Value, includeFirst.Value, includeLast.Value))
    let _calendar                                  = triv _BespokeCalendar (fun () -> _BespokeCalendar.Value.calendar)
    let _empty                                     = triv _BespokeCalendar (fun () -> _BespokeCalendar.Value.empty())
    let _endOfMonth                                (d : ICell<Date>)   
                                                   = triv _BespokeCalendar (fun () -> _BespokeCalendar.Value.endOfMonth(d.Value))
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv _BespokeCalendar (fun () -> _BespokeCalendar.Value.Equals(o.Value))
    let _isBusinessDay                             (d : ICell<Date>)   
                                                   = triv _BespokeCalendar (fun () -> _BespokeCalendar.Value.isBusinessDay(d.Value))
    let _isEndOfMonth                              (d : ICell<Date>)   
                                                   = triv _BespokeCalendar (fun () -> _BespokeCalendar.Value.isEndOfMonth(d.Value))
    let _isHoliday                                 (d : ICell<Date>)   
                                                   = triv _BespokeCalendar (fun () -> _BespokeCalendar.Value.isHoliday(d.Value))
    let _isWeekend                                 (w : ICell<DayOfWeek>)   
                                                   = triv _BespokeCalendar (fun () -> _BespokeCalendar.Value.isWeekend(w.Value))
    let _removedHolidays                           = triv _BespokeCalendar (fun () -> _BespokeCalendar.Value.removedHolidays)
    let _removeHoliday                             (d : ICell<Date>)   
                                                   = triv _BespokeCalendar (fun () -> _BespokeCalendar.Value.removeHoliday(d.Value)
                                                                                      _BespokeCalendar.Value)
    do this.Bind(_BespokeCalendar)
(* 
    casting 
*)
    
    member internal this.Inject v = _BespokeCalendar <- v
    static member Cast (p : ICell<BespokeCalendar>) = 
        if p :? BespokeCalendarModel1 then 
            p :?> BespokeCalendarModel1
        else
            let o = new BespokeCalendarModel1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.AddWeekend                         w   
                                                   = _addWeekend w 
    member this.Name                               = _name
    member this.AddedHolidays                      = _addedHolidays
    member this.AddHoliday                         d   
                                                   = _addHoliday d 
    member this.Adjust                             d c   
                                                   = _adjust d c 
    member this.Advance                            d p c endOfMonth   
                                                   = _advance d p c endOfMonth 
    member this.Advance1                           d n unit c endOfMonth   
                                                   = _advance1 d n unit c endOfMonth 
    member this.BusinessDaysBetween                from To includeFirst includeLast   
                                                   = _businessDaysBetween from To includeFirst includeLast 
    member this.Calendar                           = _calendar
    member this.Empty                              = _empty
    member this.EndOfMonth                         d   
                                                   = _endOfMonth d 
    member this.Equals                             o   
                                                   = _Equals o 
    member this.IsBusinessDay                      d   
                                                   = _isBusinessDay d 
    member this.IsEndOfMonth                       d   
                                                   = _isEndOfMonth d 
    member this.IsHoliday                          d   
                                                   = _isHoliday d 
    member this.IsWeekend                          w   
                                                   = _isWeekend w 
    member this.RemovedHolidays                    = _removedHolidays
    member this.RemoveHoliday                      d   
                                                   = _removeHoliday d 
