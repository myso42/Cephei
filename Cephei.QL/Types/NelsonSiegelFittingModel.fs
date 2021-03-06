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
  Fits a discount function to the form d(t) = t}, where the zero rate is defined as r c_0 + (c_0 + c_1)*(1 - exp^{ t) - c_2 exp^{ - t}. See: Nelson, C. and A. Siegel (1985): "Parsimonious modeling of yield curves for US Treasury bills." NBER Working Paper Series, no 1594.

  </summary> *)
[<AutoSerializable(true)>]
type NelsonSiegelFittingModel
    ( weights                                      : ICell<Vector>
    , optimizationMethod                           : ICell<OptimizationMethod>
    ) as this =

    inherit Model<NelsonSiegelFitting> ()
(*
    Parameters
*)
    let _weights                                   = weights
    let _optimizationMethod                        = optimizationMethod
(*
    Functions
*)
    let mutable
        _NelsonSiegelFitting                       = make (fun () -> new NelsonSiegelFitting (weights.Value, optimizationMethod.Value))
    let _clone                                     = triv _NelsonSiegelFitting (fun () -> _NelsonSiegelFitting.Value.clone())
    let _size                                      = triv _NelsonSiegelFitting (fun () -> _NelsonSiegelFitting.Value.size())
    let _constrainAtZero                           = triv _NelsonSiegelFitting (fun () -> _NelsonSiegelFitting.Value.constrainAtZero())
    let _discount                                  (x : ICell<Vector>) (t : ICell<double>)   
                                                   = triv _NelsonSiegelFitting (fun () -> _NelsonSiegelFitting.Value.discount(x.Value, t.Value))
    let _minimumCostValue                          = triv _NelsonSiegelFitting (fun () -> _NelsonSiegelFitting.Value.minimumCostValue())
    let _numberOfIterations                        = triv _NelsonSiegelFitting (fun () -> _NelsonSiegelFitting.Value.numberOfIterations())
    let _optimizationMethod                        = triv _NelsonSiegelFitting (fun () -> _NelsonSiegelFitting.Value.optimizationMethod())
    let _solution                                  = triv _NelsonSiegelFitting (fun () -> _NelsonSiegelFitting.Value.solution())
    let _weights                                   = triv _NelsonSiegelFitting (fun () -> _NelsonSiegelFitting.Value.weights())
    do this.Bind(_NelsonSiegelFitting)
(* 
    casting 
*)
    internal new () = new NelsonSiegelFittingModel(null,null)
    member internal this.Inject v = _NelsonSiegelFitting <- v
    static member Cast (p : ICell<NelsonSiegelFitting>) = 
        if p :? NelsonSiegelFittingModel then 
            p :?> NelsonSiegelFittingModel
        else
            let o = new NelsonSiegelFittingModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.weights                            = _weights 
    member this.optimizationMethod                 = _optimizationMethod 
    member this.Clone                              = _clone
    member this.Size                               = _size
    member this.ConstrainAtZero                    = _constrainAtZero
    member this.Discount                           x t   
                                                   = _discount x t 
    member this.MinimumCostValue                   = _minimumCostValue
    member this.NumberOfIterations                 = _numberOfIterations
    member this.OptimizationMethod                 = _optimizationMethod
    member this.Solution                           = _solution
    member this.Weights                            = _weights
