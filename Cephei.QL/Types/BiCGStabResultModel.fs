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
type BiCGStabResultModel
    ( i                                            : ICell<int>
    , e                                            : ICell<double>
    , xx                                           : ICell<Vector>
    ) as this =

    inherit Model<BiCGStabResult> ()
(*
    Parameters
*)
    let _i                                         = i
    let _e                                         = e
    let _xx                                        = xx
(*
    Functions
*)
    let mutable
        _BiCGStabResult                            = make (fun () -> new BiCGStabResult (i.Value, e.Value, xx.Value))
    let _Error                                     = triv _BiCGStabResult (fun () -> _BiCGStabResult.Value.Error)
    let _Iterations                                = triv _BiCGStabResult (fun () -> _BiCGStabResult.Value.Iterations)
    let _X                                         = triv _BiCGStabResult (fun () -> _BiCGStabResult.Value.X)
    do this.Bind(_BiCGStabResult)
(* 
    casting 
*)
    internal new () = new BiCGStabResultModel(null,null,null)
    member internal this.Inject v = _BiCGStabResult <- v
    static member Cast (p : ICell<BiCGStabResult>) = 
        if p :? BiCGStabResultModel then 
            p :?> BiCGStabResultModel
        else
            let o = new BiCGStabResultModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.i                                  = _i 
    member this.e                                  = _e 
    member this.xx                                 = _xx 
    member this.Error                              = _Error
    member this.Iterations                         = _Iterations
    member this.X                                  = _X
