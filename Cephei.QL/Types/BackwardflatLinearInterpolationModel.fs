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

! \pre the \f$ x \f$ and \f$ y \f$ values must be sorted.
  </summary> *)
[<AutoSerializable(true)>]
type BackwardflatLinearInterpolationModel
    ( xBegin                                       : ICell<Generic.List<double>>
    , xEnd                                         : ICell<int>
    , yBegin                                       : ICell<Generic.List<double>>
    , yEnd                                         : ICell<int>
    , zData                                        : ICell<Matrix>
    ) as this =

    inherit Model<BackwardflatLinearInterpolation> ()
(*
    Parameters
*)
    let _xBegin                                    = xBegin
    let _xEnd                                      = xEnd
    let _yBegin                                    = yBegin
    let _yEnd                                      = yEnd
    let _zData                                     = zData
(*
    Functions
*)
    let mutable
        _BackwardflatLinearInterpolation           = make (fun () -> new BackwardflatLinearInterpolation (xBegin.Value, xEnd.Value, yBegin.Value, yEnd.Value, zData.Value))
    let _isInRange                                 (x : ICell<double>) (y : ICell<double>)   
                                                   = triv _BackwardflatLinearInterpolation (fun () -> _BackwardflatLinearInterpolation.Value.isInRange(x.Value, y.Value))
    let _locateX                                   (x : ICell<double>)   
                                                   = triv _BackwardflatLinearInterpolation (fun () -> _BackwardflatLinearInterpolation.Value.locateX(x.Value))
    let _locateY                                   (y : ICell<double>)   
                                                   = triv _BackwardflatLinearInterpolation (fun () -> _BackwardflatLinearInterpolation.Value.locateY(y.Value))
    let _update                                    = triv _BackwardflatLinearInterpolation (fun () -> _BackwardflatLinearInterpolation.Value.update()
                                                                                                      _BackwardflatLinearInterpolation.Value)
    let _value                                     (x : ICell<double>) (y : ICell<double>) (allowExtrapolation : ICell<bool>)   
                                                   = triv _BackwardflatLinearInterpolation (fun () -> _BackwardflatLinearInterpolation.Value.value(x.Value, y.Value, allowExtrapolation.Value))
    let _value1                                    (x : ICell<double>) (y : ICell<double>)   
                                                   = triv _BackwardflatLinearInterpolation (fun () -> _BackwardflatLinearInterpolation.Value.value(x.Value, y.Value))
    let _xMax                                      = triv _BackwardflatLinearInterpolation (fun () -> _BackwardflatLinearInterpolation.Value.xMax())
    let _xMin                                      = triv _BackwardflatLinearInterpolation (fun () -> _BackwardflatLinearInterpolation.Value.xMin())
    let _xValues                                   = triv _BackwardflatLinearInterpolation (fun () -> _BackwardflatLinearInterpolation.Value.xValues())
    let _yMax                                      = triv _BackwardflatLinearInterpolation (fun () -> _BackwardflatLinearInterpolation.Value.yMax())
    let _yMin                                      = triv _BackwardflatLinearInterpolation (fun () -> _BackwardflatLinearInterpolation.Value.yMin())
    let _yValues                                   = triv _BackwardflatLinearInterpolation (fun () -> _BackwardflatLinearInterpolation.Value.yValues())
    let _zData                                     = triv _BackwardflatLinearInterpolation (fun () -> _BackwardflatLinearInterpolation.Value.zData())
    let _allowsExtrapolation                       = triv _BackwardflatLinearInterpolation (fun () -> _BackwardflatLinearInterpolation.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv _BackwardflatLinearInterpolation (fun () -> _BackwardflatLinearInterpolation.Value.disableExtrapolation(b.Value)
                                                                                                      _BackwardflatLinearInterpolation.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv _BackwardflatLinearInterpolation (fun () -> _BackwardflatLinearInterpolation.Value.enableExtrapolation(b.Value)
                                                                                                      _BackwardflatLinearInterpolation.Value)
    let _extrapolate                               = triv _BackwardflatLinearInterpolation (fun () -> _BackwardflatLinearInterpolation.Value.extrapolate)
    do this.Bind(_BackwardflatLinearInterpolation)
(* 
    casting 
*)
    internal new () = new BackwardflatLinearInterpolationModel(null,null,null,null,null)
    member internal this.Inject v = _BackwardflatLinearInterpolation <- v
    static member Cast (p : ICell<BackwardflatLinearInterpolation>) = 
        if p :? BackwardflatLinearInterpolationModel then 
            p :?> BackwardflatLinearInterpolationModel
        else
            let o = new BackwardflatLinearInterpolationModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.xBegin                             = _xBegin 
    member this.xEnd                               = _xEnd 
    member this.yBegin                             = _yBegin 
    member this.yEnd                               = _yEnd 
    member this.zData                              = _zData 
    member this.IsInRange                          x y   
                                                   = _isInRange x y 
    member this.LocateX                            x   
                                                   = _locateX x 
    member this.LocateY                            y   
                                                   = _locateY y 
    member this.Update                             = _update
    member this.Value                              x y allowExtrapolation   
                                                   = _value x y allowExtrapolation 
    member this.Value1                             x y   
                                                   = _value1 x y 
    member this.XMax                               = _xMax
    member this.XMin                               = _xMin
    member this.XValues                            = _xValues
    member this.YMax                               = _yMax
    member this.YMin                               = _yMin
    member this.YValues                            = _yValues
    member this.ZData                              = _zData
    member this.AllowsExtrapolation                = _allowsExtrapolation
    member this.DisableExtrapolation               b   
                                                   = _disableExtrapolation b 
    member this.EnableExtrapolation                b   
                                                   = _enableExtrapolation b 
    member this.Extrapolate                        = _extrapolate
