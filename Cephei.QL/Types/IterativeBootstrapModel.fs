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
  Universal piecewise-term-structure boostrapper.

  </summary> *)
[<AutoSerializable(true)>]
type IterativeBootstrapModel<'T, 'U when 'T :> Curve<'U> and 'T : (new : unit -> 'T) and 'U :> TermStructure>
    () as this =
    inherit Model<IterativeBootstrap<'T,'U>> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _IterativeBootstrap                        = make (fun () -> new IterativeBootstrap<'T,'U> ())
    let _setup                                     (ts : ICell<'T>)   
                                                   = triv _IterativeBootstrap (fun () -> _IterativeBootstrap.Value.setup(ts.Value)
                                                                                         _IterativeBootstrap.Value)
    do this.Bind(_IterativeBootstrap)

(* 
    Externally visible/bindable properties
*)
    member this.Setup                              ts   
                                                   = _setup ts 
