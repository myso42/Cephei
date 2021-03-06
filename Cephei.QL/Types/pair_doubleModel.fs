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
type pair_doubleModel
    ( first                                        : ICell<double>
    , second                                       : ICell<double>
    ) as this =

    inherit Model<pair_double> ()
(*
    Parameters
*)
    let _first                                     = first
    let _second                                    = second
(*
    Functions
*)
    let mutable
        _pair_double                               = make (fun () -> new pair_double (first.Value, second.Value))
    let _CompareTo                                 (other : ICell<Pair<double,double>>)   
                                                   = triv _pair_double (fun () -> _pair_double.Value.CompareTo(other.Value))
    let _first                                     = triv _pair_double (fun () -> _pair_double.Value.first)
    let _second                                    = triv _pair_double (fun () -> _pair_double.Value.second)
    let _set                                       (first : ICell<double>) (second : ICell<double>)   
                                                   = triv _pair_double (fun () -> _pair_double.Value.set(first.Value, second.Value)
                                                                                  _pair_double.Value)
    do this.Bind(_pair_double)
(* 
    casting 
*)
    internal new () = new pair_doubleModel(null,null)
    member internal this.Inject v = _pair_double <- v
    static member Cast (p : ICell<pair_double>) = 
        if p :? pair_doubleModel then 
            p :?> pair_doubleModel
        else
            let o = new pair_doubleModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.first                              = _first 
    member this.second                             = _second 
    member this.CompareTo                          other   
                                                   = _CompareTo other 
    member this.First                              = _first
    member this.Second                             = _second
    member this.Set                                first second   
                                                   = _set first second 
