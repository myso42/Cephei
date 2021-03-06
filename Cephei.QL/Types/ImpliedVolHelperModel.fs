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


  </summary> *)
[<AutoSerializable(true)>]
type ImpliedVolHelperModel
    ( cap                                          : ICell<CapFloor>
    , discountCurve                                : ICell<Handle<YieldTermStructure>>
    , targetValue                                  : ICell<double>
    , displacement                                 : ICell<double>
    , Type                                         : ICell<VolatilityType>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<ImpliedVolHelper> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _cap                                       = cap
    let _discountCurve                             = discountCurve
    let _targetValue                               = targetValue
    let _displacement                              = displacement
    let _Type                                      = Type
(*
    Functions
*)
    let mutable
        _ImpliedVolHelper                          = make (fun () -> (createEvaluationDate _evaluationDate (fun () ->new ImpliedVolHelper (cap.Value, discountCurve.Value, targetValue.Value, displacement.Value, Type.Value))))
    let _derivative                                (x : ICell<double>)   
                                                   = triv _ImpliedVolHelper (fun () -> (curryEvaluationDate _evaluationDate _ImpliedVolHelper).Value.derivative(x.Value))
    let _value                                     (x : ICell<double>)   
                                                   = triv _ImpliedVolHelper (fun () -> (curryEvaluationDate _evaluationDate _ImpliedVolHelper).Value.value(x.Value))
    do this.Bind(_ImpliedVolHelper)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new ImpliedVolHelperModel(null,null,null,null,null,null)
    member internal this.Inject v = _ImpliedVolHelper <- v
    static member Cast (p : ICell<ImpliedVolHelper>) = 
        if p :? ImpliedVolHelperModel then 
            p :?> ImpliedVolHelperModel
        else
            let o = new ImpliedVolHelperModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.cap                                = _cap 
    member this.discountCurve                      = _discountCurve 
    member this.targetValue                        = _targetValue 
    member this.displacement                       = _displacement 
    member this.Type                               = _Type 
    member this.Derivative                         x   
                                                   = _derivative x 
    member this.Value                              x   
                                                   = _value x 
