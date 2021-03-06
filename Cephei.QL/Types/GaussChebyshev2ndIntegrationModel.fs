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
  Gauss-Chebyshev integration (second kind) This class performs a 1-dimensional Gauss-Chebyshev integration.

  </summary> *)
[<AutoSerializable(true)>]
type GaussChebyshev2ndIntegrationModel
    ( n                                            : ICell<int>
    ) as this =

    inherit Model<GaussChebyshev2ndIntegration> ()
(*
    Parameters
*)
    let _n                                         = n
(*
    Functions
*)
    let mutable
        _GaussChebyshev2ndIntegration              = make (fun () -> new GaussChebyshev2ndIntegration (n.Value))
    let _order                                     = triv _GaussChebyshev2ndIntegration (fun () -> _GaussChebyshev2ndIntegration.Value.order())
    let _value                                     (f : ICell<Func<double,double>>)   
                                                   = triv _GaussChebyshev2ndIntegration (fun () -> _GaussChebyshev2ndIntegration.Value.value(f.Value))
    let _weights                                   = triv _GaussChebyshev2ndIntegration (fun () -> _GaussChebyshev2ndIntegration.Value.weights())
    let _x                                         = triv _GaussChebyshev2ndIntegration (fun () -> _GaussChebyshev2ndIntegration.Value.x())
    do this.Bind(_GaussChebyshev2ndIntegration)
(* 
    casting 
*)
    internal new () = new GaussChebyshev2ndIntegrationModel(null)
    member internal this.Inject v = _GaussChebyshev2ndIntegration <- v
    static member Cast (p : ICell<GaussChebyshev2ndIntegration>) = 
        if p :? GaussChebyshev2ndIntegrationModel then 
            p :?> GaussChebyshev2ndIntegrationModel
        else
            let o = new GaussChebyshev2ndIntegrationModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.n                                  = _n 
    member this.Order                              = _order
    member this.Value                              f   
                                                   = _value f 
    member this.Weights                            = _weights
    member this.X                                  = _x
