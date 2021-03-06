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
type DiscretizedVanillaOptionModel
    ( args                                         : ICell<Option.Arguments>
    , Process                                      : ICell<StochasticProcess>
    , grid                                         : ICell<TimeGrid>
    ) as this =

    inherit Model<DiscretizedVanillaOption> ()
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
        _DiscretizedVanillaOption                  = make (fun () -> new DiscretizedVanillaOption (args.Value, Process.Value, grid.Value))
    let _mandatoryTimes                            = triv _DiscretizedVanillaOption (fun () -> _DiscretizedVanillaOption.Value.mandatoryTimes())
    let _reset                                     (size : ICell<int>)   
                                                   = triv _DiscretizedVanillaOption (fun () -> _DiscretizedVanillaOption.Value.reset(size.Value)
                                                                                               _DiscretizedVanillaOption.Value)
    let _adjustValues                              = triv _DiscretizedVanillaOption (fun () -> _DiscretizedVanillaOption.Value.adjustValues()
                                                                                               _DiscretizedVanillaOption.Value)
    let _initialize                                (Method : ICell<Lattice>) (t : ICell<double>)   
                                                   = triv _DiscretizedVanillaOption (fun () -> _DiscretizedVanillaOption.Value.initialize(Method.Value, t.Value)
                                                                                               _DiscretizedVanillaOption.Value)
    let _method                                    = triv _DiscretizedVanillaOption (fun () -> _DiscretizedVanillaOption.Value.METHOD())
    let _partialRollback                           (To : ICell<double>)   
                                                   = triv _DiscretizedVanillaOption (fun () -> _DiscretizedVanillaOption.Value.partialRollback(To.Value)
                                                                                               _DiscretizedVanillaOption.Value)
    let _postAdjustValues                          = triv _DiscretizedVanillaOption (fun () -> _DiscretizedVanillaOption.Value.postAdjustValues()
                                                                                               _DiscretizedVanillaOption.Value)
    let _preAdjustValues                           = triv _DiscretizedVanillaOption (fun () -> _DiscretizedVanillaOption.Value.preAdjustValues()
                                                                                               _DiscretizedVanillaOption.Value)
    let _presentValue                              = triv _DiscretizedVanillaOption (fun () -> _DiscretizedVanillaOption.Value.presentValue())
    let _rollback                                  (To : ICell<double>)   
                                                   = triv _DiscretizedVanillaOption (fun () -> _DiscretizedVanillaOption.Value.rollback(To.Value)
                                                                                               _DiscretizedVanillaOption.Value)
    let _setTime                                   (t : ICell<double>)   
                                                   = triv _DiscretizedVanillaOption (fun () -> _DiscretizedVanillaOption.Value.setTime(t.Value)
                                                                                               _DiscretizedVanillaOption.Value)
    let _setValues                                 (v : ICell<Vector>)   
                                                   = triv _DiscretizedVanillaOption (fun () -> _DiscretizedVanillaOption.Value.setValues(v.Value)
                                                                                               _DiscretizedVanillaOption.Value)
    let _time                                      = triv _DiscretizedVanillaOption (fun () -> _DiscretizedVanillaOption.Value.time())
    let _values                                    = triv _DiscretizedVanillaOption (fun () -> _DiscretizedVanillaOption.Value.values())
    do this.Bind(_DiscretizedVanillaOption)
(* 
    casting 
*)
    internal new () = new DiscretizedVanillaOptionModel(null,null,null)
    member internal this.Inject v = _DiscretizedVanillaOption <- v
    static member Cast (p : ICell<DiscretizedVanillaOption>) = 
        if p :? DiscretizedVanillaOptionModel then 
            p :?> DiscretizedVanillaOptionModel
        else
            let o = new DiscretizedVanillaOptionModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.args                               = _args 
    member this.Process                            = _Process 
    member this.grid                               = _grid 
    member this.MandatoryTimes                     = _mandatoryTimes
    member this.Reset                              size   
                                                   = _reset size 
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
