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
type DiscretizedBarrierOptionModel
    ( args                                         : ICell<BarrierOption.Arguments>
    , Process                                      : ICell<StochasticProcess>
    , grid                                         : ICell<TimeGrid>
    ) as this =

    inherit Model<DiscretizedBarrierOption> ()
(*
    Parameters
*)
    let _args                                      = args
    let _Process                                   = Process
    let _grid                                      = grid
(*
    Functions
*)
    let mutable
        _DiscretizedBarrierOption                  = make (fun () -> new DiscretizedBarrierOption (args.Value, Process.Value, grid.Value))
    let _checkBarrier                              (optvalues : ICell<Vector>) (grid : ICell<Vector>)   
                                                   = triv _DiscretizedBarrierOption (fun () -> _DiscretizedBarrierOption.Value.checkBarrier(optvalues.Value, grid.Value)
                                                                                               _DiscretizedBarrierOption.Value)
    let _mandatoryTimes                            = triv _DiscretizedBarrierOption (fun () -> _DiscretizedBarrierOption.Value.mandatoryTimes())
    let _reset                                     (size : ICell<int>)   
                                                   = triv _DiscretizedBarrierOption (fun () -> _DiscretizedBarrierOption.Value.reset(size.Value)
                                                                                               _DiscretizedBarrierOption.Value)
    let _vanilla                                   = triv _DiscretizedBarrierOption (fun () -> _DiscretizedBarrierOption.Value.vanilla())
    let _adjustValues                              = triv _DiscretizedBarrierOption (fun () -> _DiscretizedBarrierOption.Value.adjustValues()
                                                                                               _DiscretizedBarrierOption.Value)
    let _initialize                                (Method : ICell<Lattice>) (t : ICell<double>)   
                                                   = triv _DiscretizedBarrierOption (fun () -> _DiscretizedBarrierOption.Value.initialize(Method.Value, t.Value)
                                                                                               _DiscretizedBarrierOption.Value)
    let _method                                    = triv _DiscretizedBarrierOption (fun () -> _DiscretizedBarrierOption.Value.METHOD())
    let _partialRollback                           (To : ICell<double>)   
                                                   = triv _DiscretizedBarrierOption (fun () -> _DiscretizedBarrierOption.Value.partialRollback(To.Value)
                                                                                               _DiscretizedBarrierOption.Value)
    let _postAdjustValues                          = triv _DiscretizedBarrierOption (fun () -> _DiscretizedBarrierOption.Value.postAdjustValues()
                                                                                               _DiscretizedBarrierOption.Value)
    let _preAdjustValues                           = triv _DiscretizedBarrierOption (fun () -> _DiscretizedBarrierOption.Value.preAdjustValues()
                                                                                               _DiscretizedBarrierOption.Value)
    let _presentValue                              = triv _DiscretizedBarrierOption (fun () -> _DiscretizedBarrierOption.Value.presentValue())
    let _rollback                                  (To : ICell<double>)   
                                                   = triv _DiscretizedBarrierOption (fun () -> _DiscretizedBarrierOption.Value.rollback(To.Value)
                                                                                               _DiscretizedBarrierOption.Value)
    let _setTime                                   (t : ICell<double>)   
                                                   = triv _DiscretizedBarrierOption (fun () -> _DiscretizedBarrierOption.Value.setTime(t.Value)
                                                                                               _DiscretizedBarrierOption.Value)
    let _setValues                                 (v : ICell<Vector>)   
                                                   = triv _DiscretizedBarrierOption (fun () -> _DiscretizedBarrierOption.Value.setValues(v.Value)
                                                                                               _DiscretizedBarrierOption.Value)
    let _time                                      = triv _DiscretizedBarrierOption (fun () -> _DiscretizedBarrierOption.Value.time())
    let _values                                    = triv _DiscretizedBarrierOption (fun () -> _DiscretizedBarrierOption.Value.values())
    do this.Bind(_DiscretizedBarrierOption)
(* 
    casting 
*)
    internal new () = new DiscretizedBarrierOptionModel(null,null,null)
    member internal this.Inject v = _DiscretizedBarrierOption <- v
    static member Cast (p : ICell<DiscretizedBarrierOption>) = 
        if p :? DiscretizedBarrierOptionModel then 
            p :?> DiscretizedBarrierOptionModel
        else
            let o = new DiscretizedBarrierOptionModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.args                               = _args 
    member this.Process                            = _Process 
    member this.grid                               = _grid 
    member this.CheckBarrier                       optvalues grid   
                                                   = _checkBarrier optvalues grid 
    member this.MandatoryTimes                     = _mandatoryTimes
    member this.Reset                              size   
                                                   = _reset size 
    member this.Vanilla                            = _vanilla
    member this.AdjustValues                       = _adjustValues
    member this.Initialize                         Method t   
                                                   = _initialize Method t 
    member this.Method                             = _method
    member this.PartialRollback                    To   
                                                   = _partialRollback To 
    member this.PostAdjustValues                   = _postAdjustValues
    member this.PreAdjustValues                    = _preAdjustValues
    member this.PresentValue                       = _presentValue
    member this.Rollback                           To   
                                                   = _rollback To 
    member this.SetTime                            t   
                                                   = _setTime t 
    member this.SetValues                          v   
                                                   = _setValues v 
    member this.Time                               = _time
    member this.Values                             = _values
