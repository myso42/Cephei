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
type ExplicitEulerSchemeModel
    ( map                                          : ICell<FdmLinearOpComposite>
    , bcSet                                        : ICell<Generic.List<BoundaryCondition<FdmLinearOp>>>
    ) as this =

    inherit Model<ExplicitEulerScheme> ()
(*
    Parameters
*)
    let _map                                       = map
    let _bcSet                                     = bcSet
(*
    Functions
*)
    let mutable
        _ExplicitEulerScheme                       = make (fun () -> new ExplicitEulerScheme (map.Value, bcSet.Value))
    let _factory                                   (L : ICell<Object>) (bcs : ICell<Object>) (additionalInputs : ICell<Object[]>)   
                                                   = triv _ExplicitEulerScheme (fun () -> _ExplicitEulerScheme.Value.factory(L.Value, bcs.Value, additionalInputs.Value))
    let _setStep                                   (dt : ICell<double>)   
                                                   = triv _ExplicitEulerScheme (fun () -> _ExplicitEulerScheme.Value.setStep(dt.Value)
                                                                                          _ExplicitEulerScheme.Value)
    let _step                                      (a : ICell<Object>) (t : ICell<double>) (theta : ICell<double>)   
                                                   = triv _ExplicitEulerScheme (fun () -> _ExplicitEulerScheme.Value.step(ref a.Value, t.Value, theta.Value)
                                                                                          _ExplicitEulerScheme.Value)
    do this.Bind(_ExplicitEulerScheme)
(* 
    casting 
*)
    internal new () = new ExplicitEulerSchemeModel(null,null)
    member internal this.Inject v = _ExplicitEulerScheme <- v
    static member Cast (p : ICell<ExplicitEulerScheme>) = 
        if p :? ExplicitEulerSchemeModel then 
            p :?> ExplicitEulerSchemeModel
        else
            let o = new ExplicitEulerSchemeModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.map                                = _map 
    member this.bcSet                              = _bcSet 
    member this.Factory                            L bcs additionalInputs   
                                                   = _factory L bcs additionalInputs 
    member this.SetStep                            dt   
                                                   = _setStep dt 
    member this.Step                               a t theta   
                                                   = _step a t theta 
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type ExplicitEulerSchemeModel1
    () as this =
    inherit Model<ExplicitEulerScheme> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _ExplicitEulerScheme                       = make (fun () -> new ExplicitEulerScheme ())
    let _factory                                   (L : ICell<Object>) (bcs : ICell<Object>) (additionalInputs : ICell<Object[]>)   
                                                   = triv _ExplicitEulerScheme (fun () -> _ExplicitEulerScheme.Value.factory(L.Value, bcs.Value, additionalInputs.Value))
    let _setStep                                   (dt : ICell<double>)   
                                                   = triv _ExplicitEulerScheme (fun () -> _ExplicitEulerScheme.Value.setStep(dt.Value)
                                                                                          _ExplicitEulerScheme.Value)
    let _step                                      (a : ICell<Object>) (t : ICell<double>) (theta : ICell<double>)   
                                                   = triv _ExplicitEulerScheme (fun () -> _ExplicitEulerScheme.Value.step(ref a.Value, t.Value, theta.Value)
                                                                                          _ExplicitEulerScheme.Value)
    do this.Bind(_ExplicitEulerScheme)
(* 
    casting 
*)
    
    member internal this.Inject v = _ExplicitEulerScheme <- v
    static member Cast (p : ICell<ExplicitEulerScheme>) = 
        if p :? ExplicitEulerSchemeModel1 then 
            p :?> ExplicitEulerSchemeModel1
        else
            let o = new ExplicitEulerSchemeModel1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Factory                            L bcs additionalInputs   
                                                   = _factory L bcs additionalInputs 
    member this.SetStep                            dt   
                                                   = _setStep dt 
    member this.Step                               a t theta   
                                                   = _step a t theta 
