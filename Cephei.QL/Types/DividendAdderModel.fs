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
type DividendAdderModel
    ( d                                            : ICell<Dividend>
    ) as this =

    inherit Model<DividendAdder> ()
(*
    Parameters
*)
    let _d                                         = d
(*
    Functions
*)
    let mutable
        _DividendAdder                             = cell (fun () -> new DividendAdder (d.Value))
    let _value                                     (x : ICell<double>)   
                                                   = cell (fun () -> _DividendAdder.Value.value(x.Value))
    do this.Bind(_DividendAdder)
(* 
    casting 
*)
    internal new () = DividendAdderModel(null)
    member internal this.Inject v = _DividendAdder <- v
    static member Cast (p : ICell<DividendAdder>) = 
        if p :? DividendAdderModel then 
            p :?> DividendAdderModel
        else
            let o = new DividendAdderModel ()
            o.Inject p
            o.Bind p
            o
                            
(* 
    casting 
*)
    internal new () = DividendAdderModel(null)
    static member Cast (p : ICell<DividendAdder>) = 
        if p :? DividendAdderModel then 
            p :?> DividendAdderModel
        else
            let o = new DividendAdderModel ()
            o.Value <- p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.d                                  = _d 
    member this.Value                              x   
                                                   = _value x 
