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
convenience classes
! \pre the \f$ x \f$ values must be sorted.
  </summary> *)
[<AutoSerializable(true)>]
type MixedLinearCubicNaturalSplineModel
    ( xBegin                                       : ICell<Generic.List<double>>
    , xEnd                                         : ICell<int>
    , yBegin                                       : ICell<Generic.List<double>>
    , n                                            : ICell<int>
    , behavior                                     : ICell<Behavior>
    ) as this =

    inherit Model<MixedLinearCubicNaturalSpline> ()
(*
    Parameters
*)
    let _xBegin                                    = xBegin
    let _xEnd                                      = xEnd
    let _yBegin                                    = yBegin
    let _n                                         = n
    let _behavior                                  = behavior
(*
    Functions
*)
    let mutable
        _MixedLinearCubicNaturalSpline             = make (fun () -> new MixedLinearCubicNaturalSpline (xBegin.Value, xEnd.Value, yBegin.Value, n.Value, behavior.Value))
    let _derivative                                (x : ICell<double>) (allowExtrapolation : ICell<bool>)   
                                                   = triv _MixedLinearCubicNaturalSpline (fun () -> _MixedLinearCubicNaturalSpline.Value.derivative(x.Value, allowExtrapolation.Value))
    let _empty                                     = triv _MixedLinearCubicNaturalSpline (fun () -> _MixedLinearCubicNaturalSpline.Value.empty())
    let _primitive                                 (x : ICell<double>) (allowExtrapolation : ICell<bool>)   
                                                   = triv _MixedLinearCubicNaturalSpline (fun () -> _MixedLinearCubicNaturalSpline.Value.primitive(x.Value, allowExtrapolation.Value))
    let _secondDerivative                          (x : ICell<double>) (allowExtrapolation : ICell<bool>)   
                                                   = triv _MixedLinearCubicNaturalSpline (fun () -> _MixedLinearCubicNaturalSpline.Value.secondDerivative(x.Value, allowExtrapolation.Value))
    let _update                                    = triv _MixedLinearCubicNaturalSpline (fun () -> _MixedLinearCubicNaturalSpline.Value.update()
                                                                                                    _MixedLinearCubicNaturalSpline.Value)
    let _value                                     (x : ICell<double>)   
                                                   = triv _MixedLinearCubicNaturalSpline (fun () -> _MixedLinearCubicNaturalSpline.Value.value(x.Value))
    let _value1                                    (x : ICell<double>) (allowExtrapolation : ICell<bool>)   
                                                   = triv _MixedLinearCubicNaturalSpline (fun () -> _MixedLinearCubicNaturalSpline.Value.value(x.Value, allowExtrapolation.Value))
    let _xMax                                      = triv _MixedLinearCubicNaturalSpline (fun () -> _MixedLinearCubicNaturalSpline.Value.xMax())
    let _xMin                                      = triv _MixedLinearCubicNaturalSpline (fun () -> _MixedLinearCubicNaturalSpline.Value.xMin())
    let _allowsExtrapolation                       = triv _MixedLinearCubicNaturalSpline (fun () -> _MixedLinearCubicNaturalSpline.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv _MixedLinearCubicNaturalSpline (fun () -> _MixedLinearCubicNaturalSpline.Value.disableExtrapolation(b.Value)
                                                                                                    _MixedLinearCubicNaturalSpline.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv _MixedLinearCubicNaturalSpline (fun () -> _MixedLinearCubicNaturalSpline.Value.enableExtrapolation(b.Value)
                                                                                                    _MixedLinearCubicNaturalSpline.Value)
    let _extrapolate                               = triv _MixedLinearCubicNaturalSpline (fun () -> _MixedLinearCubicNaturalSpline.Value.extrapolate)
    do this.Bind(_MixedLinearCubicNaturalSpline)
(* 
    casting 
*)
    internal new () = new MixedLinearCubicNaturalSplineModel(null,null,null,null,null)
    member internal this.Inject v = _MixedLinearCubicNaturalSpline <- v
    static member Cast (p : ICell<MixedLinearCubicNaturalSpline>) = 
        if p :? MixedLinearCubicNaturalSplineModel then 
            p :?> MixedLinearCubicNaturalSplineModel
        else
            let o = new MixedLinearCubicNaturalSplineModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.xBegin                             = _xBegin 
    member this.xEnd                               = _xEnd 
    member this.yBegin                             = _yBegin 
    member this.n                                  = _n 
    member this.behavior                           = _behavior 
    member this.Derivative                         x allowExtrapolation   
                                                   = _derivative x allowExtrapolation 
    member this.Empty                              = _empty
    member this.Primitive                          x allowExtrapolation   
                                                   = _primitive x allowExtrapolation 
    member this.SecondDerivative                   x allowExtrapolation   
                                                   = _secondDerivative x allowExtrapolation 
    member this.Update                             = _update
    member this.Value                              x   
                                                   = _value x 
    member this.Value1                             x allowExtrapolation   
                                                   = _value1 x allowExtrapolation 
    member this.XMax                               = _xMax
    member this.XMin                               = _xMin
    member this.AllowsExtrapolation                = _allowsExtrapolation
    member this.DisableExtrapolation               b   
                                                   = _disableExtrapolation b 
    member this.EnableExtrapolation                b   
                                                   = _enableExtrapolation b 
    member this.Extrapolate                        = _extrapolate
