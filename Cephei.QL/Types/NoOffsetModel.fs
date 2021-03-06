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

Missing Constructor
  </summary> *)
[<AutoSerializable(true)>]
type NoOffsetModel
    () as this =
    inherit Model<NoOffset> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _NoOffset                                  = make (fun () -> new NoOffset ())
    let _paymentDate                               (eventDate : ICell<Date>)   
                                                   = triv _NoOffset (fun () -> _NoOffset.Value.paymentDate(eventDate.Value))
    do this.Bind(_NoOffset)
(* 
    casting 
*)
    
    member internal this.Inject v = _NoOffset <- v
    static member Cast (p : ICell<NoOffset>) = 
        if p :? NoOffsetModel then 
            p :?> NoOffsetModel
        else
            let o = new NoOffsetModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.PaymentDate                        eventDate   
                                                   = _paymentDate eventDate 
