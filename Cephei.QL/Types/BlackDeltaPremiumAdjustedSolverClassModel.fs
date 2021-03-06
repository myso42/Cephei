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
type BlackDeltaPremiumAdjustedSolverClassModel
    ( ot                                           : ICell<Option.Type>
    , dt                                           : ICell<DeltaVolQuote.DeltaType>
    , spot                                         : ICell<double>
    , dDiscount                                    : ICell<double>
    , fDiscount                                    : ICell<double>
    , stdDev                                       : ICell<double>
    , delta                                        : ICell<double>
    ) as this =

    inherit Model<BlackDeltaPremiumAdjustedSolverClass> ()
(*
    Parameters
*)
    let _ot                                        = ot
    let _dt                                        = dt
    let _spot                                      = spot
    let _dDiscount                                 = dDiscount
    let _fDiscount                                 = fDiscount
    let _stdDev                                    = stdDev
    let _delta                                     = delta
(*
    Functions
*)
    let mutable
        _BlackDeltaPremiumAdjustedSolverClass      = make (fun () -> new BlackDeltaPremiumAdjustedSolverClass (ot.Value, dt.Value, spot.Value, dDiscount.Value, fDiscount.Value, stdDev.Value, delta.Value))
    let _value                                     (strike : ICell<double>)   
                                                   = triv _BlackDeltaPremiumAdjustedSolverClass (fun () -> _BlackDeltaPremiumAdjustedSolverClass.Value.value(strike.Value))
    let _derivative                                (x : ICell<double>)   
                                                   = triv _BlackDeltaPremiumAdjustedSolverClass (fun () -> _BlackDeltaPremiumAdjustedSolverClass.Value.derivative(x.Value))
    do this.Bind(_BlackDeltaPremiumAdjustedSolverClass)
(* 
    casting 
*)
    internal new () = new BlackDeltaPremiumAdjustedSolverClassModel(null,null,null,null,null,null,null)
    member internal this.Inject v = _BlackDeltaPremiumAdjustedSolverClass <- v
    static member Cast (p : ICell<BlackDeltaPremiumAdjustedSolverClass>) = 
        if p :? BlackDeltaPremiumAdjustedSolverClassModel then 
            p :?> BlackDeltaPremiumAdjustedSolverClassModel
        else
            let o = new BlackDeltaPremiumAdjustedSolverClassModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.ot                                 = _ot 
    member this.dt                                 = _dt 
    member this.spot                               = _spot 
    member this.dDiscount                          = _dDiscount 
    member this.fDiscount                          = _fDiscount 
    member this.stdDev                             = _stdDev 
    member this.delta                              = _delta 
    member this.Value                              strike   
                                                   = _value strike 
    member this.Derivative                         x   
                                                   = _derivative x 
