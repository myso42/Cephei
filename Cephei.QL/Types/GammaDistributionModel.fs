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
type GammaDistributionModel
    ( a                                            : ICell<double>
    ) as this =

    inherit Model<GammaDistribution> ()
(*
    Parameters
*)
    let _a                                         = a
(*
    Functions
*)
    let mutable
        _GammaDistribution                         = make (fun () -> new GammaDistribution (a.Value))
    let _value                                     (x : ICell<double>)   
                                                   = triv _GammaDistribution (fun () -> _GammaDistribution.Value.value(x.Value))
    do this.Bind(_GammaDistribution)
(* 
    casting 
*)
    internal new () = new GammaDistributionModel(null)
    member internal this.Inject v = _GammaDistribution <- v
    static member Cast (p : ICell<GammaDistribution>) = 
        if p :? GammaDistributionModel then 
            p :?> GammaDistributionModel
        else
            let o = new GammaDistributionModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.a                                  = _a 
    member this.Value                              x   
                                                   = _value x 
