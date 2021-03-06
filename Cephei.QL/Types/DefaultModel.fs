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
Integration policies
Missing Constructor
  </summary> *)
[<AutoSerializable(true)>]
type DefaultModel
    () as this =
    inherit Model<Default> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _Default                                   = make (fun () -> new Default ())
    let _integrate                                 (f : ICell<Func<double,double>>) (a : ICell<double>) (b : ICell<double>) (I : ICell<double>) (N : ICell<int>)   
                                                   = triv _Default (fun () -> _Default.Value.integrate(f.Value, a.Value, b.Value, I.Value, N.Value))
    let _nbEvalutions                              = triv _Default (fun () -> _Default.Value.nbEvalutions())
    do this.Bind(_Default)
(* 
    casting 
*)
    
    member internal this.Inject v = _Default <- v
    static member Cast (p : ICell<Default>) = 
        if p :? DefaultModel then 
            p :?> DefaultModel
        else
            let o = new DefaultModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Integrate                          f a b I N   
                                                   = _integrate f a b I N 
    member this.NbEvalutions                       = _nbEvalutions
