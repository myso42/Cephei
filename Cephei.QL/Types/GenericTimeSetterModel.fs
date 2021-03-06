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
type GenericTimeSetterModel<'PdeClass when 'PdeClass :> PdeSecondOrderParabolic and 'PdeClass : (new : unit -> 'PdeClass)>
    ( grid                                         : ICell<Vector>
    , Process                                      : ICell<GeneralizedBlackScholesProcess>
    ) as this =

    inherit Model<GenericTimeSetter<'PdeClass>> ()
(*
    Parameters
*)
    let _grid                                      = grid
    let _Process                                   = Process
(*
    Functions
*)
    let mutable
        _GenericTimeSetter                         = make (fun () -> new GenericTimeSetter<'PdeClass> (grid.Value, Process.Value))
    let _setTime                                   (t : ICell<double>) (L : ICell<IOperator>)   
                                                   = triv _GenericTimeSetter (fun () -> _GenericTimeSetter.Value.setTime(t.Value, L.Value)
                                                                                        _GenericTimeSetter.Value)
    do this.Bind(_GenericTimeSetter)

(* 
    Externally visible/bindable properties
*)
    member this.grid                               = _grid 
    member this.Process                            = _Process 
    member this.SetTime                            t L   
                                                   = _setTime t L 
