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
  Public holidays (data from http://www.dti.gov.uk/er/bankhol.htm):
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st (possibly moved to Monday)</li>
<li>Good Friday</li>
<li>Easter Monday</li>
<li>Early May Bank Holiday, first Monday of May</li>
<li>Spring Bank Holiday, last Monday of May</li>
<li>Summer Bank Holiday, last Monday of August</li>
<li>Christmas Day, December 25th (possibly moved to Monday or Tuesday)</li>
<li>Boxing Day, December 26th (possibly moved to Monday or Tuesday)</li>
</ul>  Holidays for the stock exchange:
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st (possibly moved to Monday)</li>
<li>Good Friday</li>
<li>Easter Monday</li>
<li>Early May Bank Holiday, first Monday of May</li>
<li>Spring Bank Holiday, last Monday of May</li>
<li>Summer Bank Holiday, last Monday of August</li>
<li>Christmas Day, December 25th (possibly moved to Monday or Tuesday)</li>
<li>Boxing Day, December 26th (possibly moved to Monday or Tuesday)</li>
</ul>  Holidays for the metals exchange:
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st (possibly moved to Monday)</li>
<li>Good Friday</li>
<li>Easter Monday</li>
<li>Early May Bank Holiday, first Monday of May</li>
<li>Spring Bank Holiday, last Monday of May</li>
<li>Summer Bank Holiday, last Monday of August</li>
<li>Christmas Day, December 25th (possibly moved to Monday or Tuesday)</li>
<li>Boxing Day, December 26th (possibly moved to Monday or Tuesday)</li>
</ul>  add LIFFE the correctness of the returned results is tested  against a list of known holidays.

  </summary> *)
[<AutoSerializable(true)>]
type UnitedKingdomModel
    () as this =
    inherit Model<UnitedKingdom> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _UnitedKingdom                             = make (fun () -> new UnitedKingdom ())
    let _addedHolidays                             = triv _UnitedKingdom (fun () -> _UnitedKingdom.Value.addedHolidays)
    let _addHoliday                                (d : ICell<Date>)   
                                                   = triv _UnitedKingdom (fun () -> _UnitedKingdom.Value.addHoliday(d.Value)
                                                                                    _UnitedKingdom.Value)
    let _adjust                                    (d : ICell<Date>) (c : ICell<BusinessDayConvention>)   
                                                   = triv _UnitedKingdom (fun () -> _UnitedKingdom.Value.adjust(d.Value, c.Value))
    let _advance                                   (d : ICell<Date>) (p : ICell<Period>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = triv _UnitedKingdom (fun () -> _UnitedKingdom.Value.advance(d.Value, p.Value, c.Value, endOfMonth.Value))
    let _advance1                                  (d : ICell<Date>) (n : ICell<int>) (unit : ICell<TimeUnit>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = triv _UnitedKingdom (fun () -> _UnitedKingdom.Value.advance(d.Value, n.Value, unit.Value, c.Value, endOfMonth.Value))
    let _businessDaysBetween                       (from : ICell<Date>) (To : ICell<Date>) (includeFirst : ICell<bool>) (includeLast : ICell<bool>)   
                                                   = triv _UnitedKingdom (fun () -> _UnitedKingdom.Value.businessDaysBetween(from.Value, To.Value, includeFirst.Value, includeLast.Value))
    let _calendar                                  = triv _UnitedKingdom (fun () -> _UnitedKingdom.Value.calendar)
    let _empty                                     = triv _UnitedKingdom (fun () -> _UnitedKingdom.Value.empty())
    let _endOfMonth                                (d : ICell<Date>)   
                                                   = triv _UnitedKingdom (fun () -> _UnitedKingdom.Value.endOfMonth(d.Value))
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv _UnitedKingdom (fun () -> _UnitedKingdom.Value.Equals(o.Value))
    let _isBusinessDay                             (d : ICell<Date>)   
                                                   = triv _UnitedKingdom (fun () -> _UnitedKingdom.Value.isBusinessDay(d.Value))
    let _isEndOfMonth                              (d : ICell<Date>)   
                                                   = triv _UnitedKingdom (fun () -> _UnitedKingdom.Value.isEndOfMonth(d.Value))
    let _isHoliday                                 (d : ICell<Date>)   
                                                   = triv _UnitedKingdom (fun () -> _UnitedKingdom.Value.isHoliday(d.Value))
    let _isWeekend                                 (w : ICell<DayOfWeek>)   
                                                   = triv _UnitedKingdom (fun () -> _UnitedKingdom.Value.isWeekend(w.Value))
    let _name                                      = triv _UnitedKingdom (fun () -> _UnitedKingdom.Value.name())
    let _removedHolidays                           = triv _UnitedKingdom (fun () -> _UnitedKingdom.Value.removedHolidays)
    let _removeHoliday                             (d : ICell<Date>)   
                                                   = triv _UnitedKingdom (fun () -> _UnitedKingdom.Value.removeHoliday(d.Value)
                                                                                    _UnitedKingdom.Value)
    do this.Bind(_UnitedKingdom)
(* 
    casting 
*)
    
    member internal this.Inject v = _UnitedKingdom <- v
    static member Cast (p : ICell<UnitedKingdom>) = 
        if p :? UnitedKingdomModel then 
            p :?> UnitedKingdomModel
        else
            let o = new UnitedKingdomModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
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
    member this.Name                               = _name
    member this.RemovedHolidays                    = _removedHolidays
    member this.RemoveHoliday                      d   
                                                   = _removeHoliday d 
(* <summary>
  Public holidays (data from http://www.dti.gov.uk/er/bankhol.htm):
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st (possibly moved to Monday)</li>
<li>Good Friday</li>
<li>Easter Monday</li>
<li>Early May Bank Holiday, first Monday of May</li>
<li>Spring Bank Holiday, last Monday of May</li>
<li>Summer Bank Holiday, last Monday of August</li>
<li>Christmas Day, December 25th (possibly moved to Monday or Tuesday)</li>
<li>Boxing Day, December 26th (possibly moved to Monday or Tuesday)</li>
</ul>  Holidays for the stock exchange:
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st (possibly moved to Monday)</li>
<li>Good Friday</li>
<li>Easter Monday</li>
<li>Early May Bank Holiday, first Monday of May</li>
<li>Spring Bank Holiday, last Monday of May</li>
<li>Summer Bank Holiday, last Monday of August</li>
<li>Christmas Day, December 25th (possibly moved to Monday or Tuesday)</li>
<li>Boxing Day, December 26th (possibly moved to Monday or Tuesday)</li>
</ul>  Holidays for the metals exchange:
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st (possibly moved to Monday)</li>
<li>Good Friday</li>
<li>Easter Monday</li>
<li>Early May Bank Holiday, first Monday of May</li>
<li>Spring Bank Holiday, last Monday of May</li>
<li>Summer Bank Holiday, last Monday of August</li>
<li>Christmas Day, December 25th (possibly moved to Monday or Tuesday)</li>
<li>Boxing Day, December 26th (possibly moved to Monday or Tuesday)</li>
</ul>  add LIFFE the correctness of the returned results is tested  against a list of known holidays.

  </summary> *)
[<AutoSerializable(true)>]
type UnitedKingdomModel1
    ( m                                            : ICell<UnitedKingdom.Market>
    ) as this =

    inherit Model<UnitedKingdom> ()
(*
    Parameters
*)
    let _m                                         = m
(*
    Functions
*)
    let mutable
        _UnitedKingdom                             = make (fun () -> new UnitedKingdom (m.Value))
    let _addedHolidays                             = triv _UnitedKingdom (fun () -> _UnitedKingdom.Value.addedHolidays)
    let _addHoliday                                (d : ICell<Date>)   
                                                   = triv _UnitedKingdom (fun () -> _UnitedKingdom.Value.addHoliday(d.Value)
                                                                                    _UnitedKingdom.Value)
    let _adjust                                    (d : ICell<Date>) (c : ICell<BusinessDayConvention>)   
                                                   = triv _UnitedKingdom (fun () -> _UnitedKingdom.Value.adjust(d.Value, c.Value))
    let _advance                                   (d : ICell<Date>) (p : ICell<Period>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = triv _UnitedKingdom (fun () -> _UnitedKingdom.Value.advance(d.Value, p.Value, c.Value, endOfMonth.Value))
    let _advance1                                  (d : ICell<Date>) (n : ICell<int>) (unit : ICell<TimeUnit>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = triv _UnitedKingdom (fun () -> _UnitedKingdom.Value.advance(d.Value, n.Value, unit.Value, c.Value, endOfMonth.Value))
    let _businessDaysBetween                       (from : ICell<Date>) (To : ICell<Date>) (includeFirst : ICell<bool>) (includeLast : ICell<bool>)   
                                                   = triv _UnitedKingdom (fun () -> _UnitedKingdom.Value.businessDaysBetween(from.Value, To.Value, includeFirst.Value, includeLast.Value))
    let _calendar                                  = triv _UnitedKingdom (fun () -> _UnitedKingdom.Value.calendar)
    let _empty                                     = triv _UnitedKingdom (fun () -> _UnitedKingdom.Value.empty())
    let _endOfMonth                                (d : ICell<Date>)   
                                                   = triv _UnitedKingdom (fun () -> _UnitedKingdom.Value.endOfMonth(d.Value))
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv _UnitedKingdom (fun () -> _UnitedKingdom.Value.Equals(o.Value))
    let _isBusinessDay                             (d : ICell<Date>)   
                                                   = triv _UnitedKingdom (fun () -> _UnitedKingdom.Value.isBusinessDay(d.Value))
    let _isEndOfMonth                              (d : ICell<Date>)   
                                                   = triv _UnitedKingdom (fun () -> _UnitedKingdom.Value.isEndOfMonth(d.Value))
    let _isHoliday                                 (d : ICell<Date>)   
                                                   = triv _UnitedKingdom (fun () -> _UnitedKingdom.Value.isHoliday(d.Value))
    let _isWeekend                                 (w : ICell<DayOfWeek>)   
                                                   = triv _UnitedKingdom (fun () -> _UnitedKingdom.Value.isWeekend(w.Value))
    let _name                                      = triv _UnitedKingdom (fun () -> _UnitedKingdom.Value.name())
    let _removedHolidays                           = triv _UnitedKingdom (fun () -> _UnitedKingdom.Value.removedHolidays)
    let _removeHoliday                             (d : ICell<Date>)   
                                                   = triv _UnitedKingdom (fun () -> _UnitedKingdom.Value.removeHoliday(d.Value)
                                                                                    _UnitedKingdom.Value)
    do this.Bind(_UnitedKingdom)
(* 
    casting 
*)
    internal new () = new UnitedKingdomModel1(null)
    member internal this.Inject v = _UnitedKingdom <- v
    static member Cast (p : ICell<UnitedKingdom>) = 
        if p :? UnitedKingdomModel1 then 
            p :?> UnitedKingdomModel1
        else
            let o = new UnitedKingdomModel1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.m                                  = _m 
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
    member this.Name                               = _name
    member this.RemovedHolidays                    = _removedHolidays
    member this.RemoveHoliday                      d   
                                                   = _removeHoliday d 
