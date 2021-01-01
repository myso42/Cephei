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
type ChiSquareDistributionModel
    ( df                                           : ICell<double>
    ) as this =

    inherit Model<ChiSquareDistribution> ()
(*
    Parameters
*)
    let _df                                        = df
(*
    Functions
*)
    let mutable
        _ChiSquareDistribution                     = make (fun () -> new ChiSquareDistribution (df.Value))
    let _value                                     (x : ICell<double>)   
                                                   = triv _ChiSquareDistribution (fun () -> _ChiSquareDistribution.Value.value(x.Value))
    do this.Bind(_ChiSquareDistribution)
(* 
    casting 
*)
    internal new () = new ChiSquareDistributionModel(null)
    member internal this.Inject v = _ChiSquareDistribution <- v
    static member Cast (p : ICell<ChiSquareDistribution>) = 
        if p :? ChiSquareDistributionModel then 
            p :?> ChiSquareDistributionModel
        else
            let o = new ChiSquareDistributionModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.df                                 = _df 
    member this.Value                              x   
                                                   = _value x 
