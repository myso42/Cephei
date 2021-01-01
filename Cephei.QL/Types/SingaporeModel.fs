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
  Holidays for the Singapore exchange (data from <http://www.sgx.com/wps/portal/sgxweb/home/trading/securities/trading_hours_calendar>):
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's day, January 1st</li>
<li>Good Friday</li>
<li>Labour Day, May 1st</li>
<li>National Day, August 9th</li>
<li>Christmas, December 25th </li>
</ul>  Other holidays for which no rule is given (data available for 2004-2010, 2012-2013 only:)
<ul>
<li>Chinese New Year</li>
<li>Hari Raya Haji</li>
<li>Vesak Poya Day</li>
<li>Deepavali</li>
<li>Diwali</li>
<li>Hari Raya Puasa</li>
</ul>  calendars

  </summary> *)
[<AutoSerializable(true)>]
type SingaporeModel
    () as this =
    inherit Model<Singapore> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _Singapore                                 = make (fun () -> new Singapore ())
    let _addedHolidays                             = triv _Singapore (fun () -> _Singapore.Value.addedHolidays)
    let _addHoliday                                (d : ICell<Date>)   
                                                   = triv _Singapore (fun () -> _Singapore.Value.addHoliday(d.Value)
                                                                                _Singapore.Value)
    let _adjust                                    (d : ICell<Date>) (c : ICell<BusinessDayConvention>)   
                                                   = triv _Singapore (fun () -> _Singapore.Value.adjust(d.Value, c.Value))
    let _advance                                   (d : ICell<Date>) (p : ICell<Period>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = triv _Singapore (fun () -> _Singapore.Value.advance(d.Value, p.Value, c.Value, endOfMonth.Value))
    let _advance1                                  (d : ICell<Date>) (n : ICell<int>) (unit : ICell<TimeUnit>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = triv _Singapore (fun () -> _Singapore.Value.advance(d.Value, n.Value, unit.Value, c.Value, endOfMonth.Value))
    let _businessDaysBetween                       (from : ICell<Date>) (To : ICell<Date>) (includeFirst : ICell<bool>) (includeLast : ICell<bool>)   
                                                   = triv _Singapore (fun () -> _Singapore.Value.businessDaysBetween(from.Value, To.Value, includeFirst.Value, includeLast.Value))
    let _calendar                                  = triv _Singapore (fun () -> _Singapore.Value.calendar)
    let _empty                                     = triv _Singapore (fun () -> _Singapore.Value.empty())
    let _endOfMonth                                (d : ICell<Date>)   
                                                   = triv _Singapore (fun () -> _Singapore.Value.endOfMonth(d.Value))
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv _Singapore (fun () -> _Singapore.Value.Equals(o.Value))
    let _isBusinessDay                             (d : ICell<Date>)   
                                                   = triv _Singapore (fun () -> _Singapore.Value.isBusinessDay(d.Value))
    let _isEndOfMonth                              (d : ICell<Date>)   
                                                   = triv _Singapore (fun () -> _Singapore.Value.isEndOfMonth(d.Value))
    let _isHoliday                                 (d : ICell<Date>)   
                                                   = triv _Singapore (fun () -> _Singapore.Value.isHoliday(d.Value))
    let _isWeekend                                 (w : ICell<DayOfWeek>)   
                                                   = triv _Singapore (fun () -> _Singapore.Value.isWeekend(w.Value))
    let _name                                      = triv _Singapore (fun () -> _Singapore.Value.name())
    let _removedHolidays                           = triv _Singapore (fun () -> _Singapore.Value.removedHolidays)
    let _removeHoliday                             (d : ICell<Date>)   
                                                   = triv _Singapore (fun () -> _Singapore.Value.removeHoliday(d.Value)
                                                                                _Singapore.Value)
    do this.Bind(_Singapore)
(* 
    casting 
*)
    
    member internal this.Inject v = _Singapore <- v
    static member Cast (p : ICell<Singapore>) = 
        if p :? SingaporeModel then 
            p :?> SingaporeModel
        else
            let o = new SingaporeModel ()
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
