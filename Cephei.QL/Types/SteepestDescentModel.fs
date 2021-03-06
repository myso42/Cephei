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
  User has to provide line-search method and optimization end criteria  search direction = - f'(x)

  </summary> *)
[<AutoSerializable(true)>]
type SteepestDescentModel
    ( lineSearch                                   : ICell<LineSearch>
    ) as this =

    inherit Model<SteepestDescent> ()
(*
    Parameters
*)
    let _lineSearch                                = lineSearch
(*
    Functions
*)
    let mutable
        _SteepestDescent                           = make (fun () -> new SteepestDescent (lineSearch.Value))
    let _minimize                                  (P : ICell<Problem>) (endCriteria : ICell<EndCriteria>)   
                                                   = triv _SteepestDescent (fun () -> _SteepestDescent.Value.minimize(P.Value, endCriteria.Value))
    do this.Bind(_SteepestDescent)
(* 
    casting 
*)
    internal new () = new SteepestDescentModel(null)
    member internal this.Inject v = _SteepestDescent <- v
    static member Cast (p : ICell<SteepestDescent>) = 
        if p :? SteepestDescentModel then 
            p :?> SteepestDescentModel
        else
            let o = new SteepestDescentModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.lineSearch                         = _lineSearch 
    member this.Minimize                           P endCriteria   
                                                   = _minimize P endCriteria 
