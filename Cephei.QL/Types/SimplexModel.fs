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
  Multi-dimensional simplex class
! Constructor taking as input the characteristic length
  </summary> *)
[<AutoSerializable(true)>]
type SimplexModel
    ( lambda                                       : ICell<double>
    ) as this =

    inherit Model<Simplex> ()
(*
    Parameters
*)
    let _lambda                                    = lambda
(*
    Functions
*)
    let mutable
        _Simplex                                   = make (fun () -> new Simplex (lambda.Value))
    let _minimize                                  (P : ICell<Problem>) (endCriteria : ICell<EndCriteria>)   
                                                   = triv _Simplex (fun () -> _Simplex.Value.minimize(P.Value, endCriteria.Value))
    do this.Bind(_Simplex)
(* 
    casting 
*)
    internal new () = new SimplexModel(null)
    member internal this.Inject v = _Simplex <- v
    static member Cast (p : ICell<Simplex>) = 
        if p :? SimplexModel then 
            p :?> SimplexModel
        else
            let o = new SimplexModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.lambda                             = _lambda 
    member this.Minimize                           P endCriteria   
                                                   = _minimize P endCriteria 
