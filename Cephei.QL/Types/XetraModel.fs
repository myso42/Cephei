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

Missing Constructor
  </summary> *)
[<AutoSerializable(true)>]
type XetraModel
    () as this =
    inherit Model<Xetra> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _Xetra                                     = cell (fun () -> new Xetra ())
    let _isBusinessDay                             (date : ICell<Date>)   
                                                   = cell (fun () -> _Xetra.Value.isBusinessDay(date.Value))
    let _name                                      = cell (fun () -> _Xetra.Value.name())
    do this.Bind(_Xetra)
(* 
    casting 
*)
    
    member internal this.Inject v = _Xetra <- v
    static member Cast (p : ICell<Xetra>) = 
        if p :? XetraModel then 
            p :?> XetraModel
        else
            let o = new XetraModel ()
            o.Inject p
            o.Bind p
            o
                            
(* 
    casting 
*)
    
    static member Cast (p : ICell<Xetra>) = 
        if p :? XetraModel then 
            p :?> XetraModel
        else
            let o = new XetraModel ()
            o.Value <- p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.IsBusinessDay                      date   
                                                   = _isBusinessDay date 
    member this.Name                               = _name
