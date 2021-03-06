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
type OdeSolver2Model
    ( func                                         : ICell<Func<double,double>>
    , z                                            : ICell<double>
    ) as this =

    inherit Model<OdeSolver2> ()
(*
    Parameters
*)
    let _func                                      = func
    let _z                                         = z
(*
    Functions
*)
    let mutable
        _OdeSolver2                                = cell (fun () -> new OdeSolver2 (func.Value, z.Value))
    let _value                                     (v : ICell<double>)   
                                                   = cell (fun () -> _OdeSolver2.Value.value(v.Value))
    let _derivative                                (x : ICell<double>)   
                                                   = cell (fun () -> _OdeSolver2.Value.derivative(x.Value))
    do this.Bind(_OdeSolver2)
(* 
    casting 
*)
    internal new () = OdeSolver2Model(null,null)
    member internal this.Inject v = _OdeSolver2 <- v
    static member Cast (p : ICell<OdeSolver2>) = 
        if p :? OdeSolver2Model then 
            p :?> OdeSolver2Model
        else
            let o = new OdeSolver2Model ()
            o.Inject p
            o.Bind p
            o
                            
(* 
    casting 
*)
    internal new () = OdeSolver2Model(null,null)
    static member Cast (p : ICell<OdeSolver2>) = 
        if p :? OdeSolver2Model then 
            p :?> OdeSolver2Model
        else
            let o = new OdeSolver2Model ()
            o.Value <- p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.func                               = _func 
    member this.z                                  = _z 
    member this.Value                              v   
                                                   = _value v 
    member this.Derivative                         x   
                                                   = _derivative x 
