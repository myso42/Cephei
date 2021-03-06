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
used to create an Event instance. to be replaced with specific events as soon as we find out which.

  </summary> *)
[<AutoSerializable(true)>]
type simple_eventModel
    ( date                                         : ICell<Date>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<simple_event> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _date                                      = date
(*
    Functions
*)
    let mutable
        _simple_event                              = make (fun () -> (createEvaluationDate _evaluationDate (fun () ->new simple_event (date.Value))))
    let _date                                      = triv _simple_event (fun () -> (curryEvaluationDate _evaluationDate _simple_event).Value.date())
    let _accept                                    (v : ICell<IAcyclicVisitor>)   
                                                   = triv _simple_event (fun () -> (curryEvaluationDate _evaluationDate _simple_event).Value.accept(v.Value)
                                                                                   _simple_event.Value)
    let _hasOccurred                               (d : ICell<Date>) (includeRefDate : ICell<Nullable<bool>>)   
                                                   = triv _simple_event (fun () -> (curryEvaluationDate _evaluationDate _simple_event).Value.hasOccurred(d.Value, includeRefDate.Value))
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _simple_event (fun () -> (curryEvaluationDate _evaluationDate _simple_event).Value.registerWith(handler.Value)
                                                                                   _simple_event.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _simple_event (fun () -> (curryEvaluationDate _evaluationDate _simple_event).Value.unregisterWith(handler.Value)
                                                                                   _simple_event.Value)
    do this.Bind(_simple_event)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new simple_eventModel(null,null)
    member internal this.Inject v = _simple_event <- v
    static member Cast (p : ICell<simple_event>) = 
        if p :? simple_eventModel then 
            p :?> simple_eventModel
        else
            let o = new simple_eventModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.date                               = _date 
    member this.Date                               = _date
    member this.Accept                             v   
                                                   = _accept v 
    member this.HasOccurred                        d includeRefDate   
                                                   = _hasOccurred d includeRefDate 
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
