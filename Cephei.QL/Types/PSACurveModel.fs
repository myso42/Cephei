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
type PSACurveModel
    ( startdate                                    : ICell<Date>
    , multiplier                                   : ICell<double>
    ) as this =

    inherit Model<PSACurve> ()
(*
    Parameters
*)
    let _startdate                                 = startdate
    let _multiplier                                = multiplier
(*
    Functions
*)
    let mutable
        _PSACurve                                  = make (fun () -> new PSACurve (startdate.Value, multiplier.Value))
    let _getCPR                                    (valDate : ICell<Date>)   
                                                   = triv _PSACurve (fun () -> _PSACurve.Value.getCPR(valDate.Value))
    let _getSMM                                    (valDate : ICell<Date>)   
                                                   = triv _PSACurve (fun () -> _PSACurve.Value.getSMM(valDate.Value))
    do this.Bind(_PSACurve)
(* 
    casting 
*)
    internal new () = new PSACurveModel(null,null)
    member internal this.Inject v = _PSACurve <- v
    static member Cast (p : ICell<PSACurve>) = 
        if p :? PSACurveModel then 
            p :?> PSACurveModel
        else
            let o = new PSACurveModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.startdate                          = _startdate 
    member this.multiplier                         = _multiplier 
    member this.GetCPR                             valDate   
                                                   = _getCPR valDate 
    member this.GetSMM                             valDate   
                                                   = _getSMM valDate 
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type PSACurveModel1
    ( startdate                                    : ICell<Date>
    ) as this =

    inherit Model<PSACurve> ()
(*
    Parameters
*)
    let _startdate                                 = startdate
(*
    Functions
*)
    let mutable
        _PSACurve                                  = make (fun () -> new PSACurve (startdate.Value))
    let _getCPR                                    (valDate : ICell<Date>)   
                                                   = triv _PSACurve (fun () -> _PSACurve.Value.getCPR(valDate.Value))
    let _getSMM                                    (valDate : ICell<Date>)   
                                                   = triv _PSACurve (fun () -> _PSACurve.Value.getSMM(valDate.Value))
    do this.Bind(_PSACurve)
(* 
    casting 
*)
    internal new () = new PSACurveModel1(null)
    member internal this.Inject v = _PSACurve <- v
    static member Cast (p : ICell<PSACurve>) = 
        if p :? PSACurveModel1 then 
            p :?> PSACurveModel1
        else
            let o = new PSACurveModel1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.startdate                          = _startdate 
    member this.GetCPR                             valDate   
                                                   = _getCPR valDate 
    member this.GetSMM                             valDate   
                                                   = _getSMM valDate 
