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
type ConstantCPRModel
    ( cpr                                          : ICell<double>
    ) as this =

    inherit Model<ConstantCPR> ()
(*
    Parameters
*)
    let _cpr                                       = cpr
(*
    Functions
*)
    let mutable
        _ConstantCPR                               = make (fun () -> new ConstantCPR (cpr.Value))
    let _getCPR                                    (valDate : ICell<Date>)   
                                                   = triv _ConstantCPR (fun () -> _ConstantCPR.Value.getCPR(valDate.Value))
    let _getSMM                                    (valDate : ICell<Date>)   
                                                   = triv _ConstantCPR (fun () -> _ConstantCPR.Value.getSMM(valDate.Value))
    do this.Bind(_ConstantCPR)
(* 
    casting 
*)
    internal new () = new ConstantCPRModel(null)
    member internal this.Inject v = _ConstantCPR <- v
    static member Cast (p : ICell<ConstantCPR>) = 
        if p :? ConstantCPRModel then 
            p :?> ConstantCPRModel
        else
            let o = new ConstantCPRModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.cpr                                = _cpr 
    member this.GetCPR                             valDate   
                                                   = _getCPR valDate 
    member this.GetSMM                             valDate   
                                                   = _getSMM valDate 
