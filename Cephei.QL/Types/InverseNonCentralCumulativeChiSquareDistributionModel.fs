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
type InverseNonCentralCumulativeChiSquareDistributionModel
    ( df                                           : ICell<double>
    , ncp                                          : ICell<double>
    , maxEvaluations                               : ICell<int>
    , accuracy                                     : ICell<double>
    ) as this =

    inherit Model<InverseNonCentralCumulativeChiSquareDistribution> ()
(*
    Parameters
*)
    let _df                                        = df
    let _ncp                                       = ncp
    let _maxEvaluations                            = maxEvaluations
    let _accuracy                                  = accuracy
(*
    Functions
*)
    let mutable
        _InverseNonCentralCumulativeChiSquareDistribution = make (fun () -> new InverseNonCentralCumulativeChiSquareDistribution (df.Value, ncp.Value, maxEvaluations.Value, accuracy.Value))
    let _value                                     (x : ICell<double>)   
                                                   = triv _InverseNonCentralCumulativeChiSquareDistribution (fun () -> _InverseNonCentralCumulativeChiSquareDistribution.Value.value(x.Value))
    do this.Bind(_InverseNonCentralCumulativeChiSquareDistribution)
(* 
    casting 
*)
    internal new () = new InverseNonCentralCumulativeChiSquareDistributionModel(null,null,null,null)
    member internal this.Inject v = _InverseNonCentralCumulativeChiSquareDistribution <- v
    static member Cast (p : ICell<InverseNonCentralCumulativeChiSquareDistribution>) = 
        if p :? InverseNonCentralCumulativeChiSquareDistributionModel then 
            p :?> InverseNonCentralCumulativeChiSquareDistributionModel
        else
            let o = new InverseNonCentralCumulativeChiSquareDistributionModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.df                                 = _df 
    member this.ncp                                = _ncp 
    member this.maxEvaluations                     = _maxEvaluations 
    member this.accuracy                           = _accuracy 
    member this.Value                              x   
                                                   = _value x 
