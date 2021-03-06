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
random number traits
Missing Constructor
  </summary> *)
[<AutoSerializable(true)>]
type GenericPseudoRandomModel<'URNG, 'IC when 'URNG :> IRNGTraits and 'URNG : (new : unit -> 'URNG) and 'IC :> IValue and 'IC : (new : unit -> 'IC)>
    () as this =
    inherit Model<GenericPseudoRandom<'URNG,'IC>> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _GenericPseudoRandom                       = make (fun () -> new GenericPseudoRandom<'URNG,'IC> ())
    let _allowsErrorEstimate                       = triv _GenericPseudoRandom (fun () -> _GenericPseudoRandom.Value.allowsErrorEstimate)
    let _make_sequence_generator                   (dimension : ICell<int>) (seed : ICell<uint64>)   
                                                   = triv _GenericPseudoRandom (fun () -> _GenericPseudoRandom.Value.make_sequence_generator(dimension.Value, seed.Value))
    do this.Bind(_GenericPseudoRandom)

(* 
    Externally visible/bindable properties
*)
    member this.AllowsErrorEstimate                = _allowsErrorEstimate
    member this.Make_sequence_generator            dimension seed   
                                                   = _make_sequence_generator dimension seed 
