(*
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
type FDDividendEuropeanEngineModel
    () as this =
    inherit Model<FDDividendEuropeanEngine> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _FDDividendEuropeanEngine                  = cell (fun () -> new FDDividendEuropeanEngine ())
    let _factory                                   (Process : ICell<GeneralizedBlackScholesProcess>) (timeSteps : ICell<int>) (gridPoints : ICell<int>)   
                                                   = triv (fun () -> _FDDividendEuropeanEngine.Value.factory(Process.Value, timeSteps.Value, gridPoints.Value))
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _FDDividendEuropeanEngine.Value.registerWith(handler.Value)
                                                                     _FDDividendEuropeanEngine.Value)
    let _reset                                     = triv (fun () -> _FDDividendEuropeanEngine.Value.reset()
                                                                     _FDDividendEuropeanEngine.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _FDDividendEuropeanEngine.Value.unregisterWith(handler.Value)
                                                                     _FDDividendEuropeanEngine.Value)
    let _update                                    = triv (fun () -> _FDDividendEuropeanEngine.Value.update()
                                                                     _FDDividendEuropeanEngine.Value)
    let _ensureStrikeInGrid                        = triv (fun () -> _FDDividendEuropeanEngine.Value.ensureStrikeInGrid()
                                                                     _FDDividendEuropeanEngine.Value)
    let _getResidualTime                           = triv (fun () -> _FDDividendEuropeanEngine.Value.getResidualTime())
    let _grid                                      = triv (fun () -> _FDDividendEuropeanEngine.Value.grid())
    let _intrinsicValues_                          = triv (fun () -> _FDDividendEuropeanEngine.Value.intrinsicValues_)
    do this.Bind(_FDDividendEuropeanEngine)

(* 
    Externally visible/bindable properties
*)
    member this.Factory                            Process timeSteps gridPoints   
                                                   = _factory Process timeSteps gridPoints 
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.Reset                              = _reset
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Update                             = _update
    member this.EnsureStrikeInGrid                 = _ensureStrikeInGrid
    member this.GetResidualTime                    = _getResidualTime
    member this.Grid                               = _grid
    member this.IntrinsicValues_                   = _intrinsicValues_
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type FDDividendEuropeanEngineModel1
    ( Process                                      : ICell<GeneralizedBlackScholesProcess>
    , timeSteps                                    : ICell<int>
    , gridPoints                                   : ICell<int>
    , timeDependent                                : ICell<bool>
    ) as this =

    inherit Model<FDDividendEuropeanEngine> ()
(*
    Parameters
*)
    let _Process                                   = Process
    let _timeSteps                                 = timeSteps
    let _gridPoints                                = gridPoints
    let _timeDependent                             = timeDependent
(*
    Functions
*)
    let _FDDividendEuropeanEngine                  = cell (fun () -> new FDDividendEuropeanEngine (Process.Value, timeSteps.Value, gridPoints.Value, timeDependent.Value))
    let _factory                                   (Process : ICell<GeneralizedBlackScholesProcess>) (timeSteps : ICell<int>) (gridPoints : ICell<int>)   
                                                   = triv (fun () -> _FDDividendEuropeanEngine.Value.factory(Process.Value, timeSteps.Value, gridPoints.Value))
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _FDDividendEuropeanEngine.Value.registerWith(handler.Value)
                                                                     _FDDividendEuropeanEngine.Value)
    let _reset                                     = triv (fun () -> _FDDividendEuropeanEngine.Value.reset()
                                                                     _FDDividendEuropeanEngine.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _FDDividendEuropeanEngine.Value.unregisterWith(handler.Value)
                                                                     _FDDividendEuropeanEngine.Value)
    let _update                                    = triv (fun () -> _FDDividendEuropeanEngine.Value.update()
                                                                     _FDDividendEuropeanEngine.Value)
    let _ensureStrikeInGrid                        = triv (fun () -> _FDDividendEuropeanEngine.Value.ensureStrikeInGrid()
                                                                     _FDDividendEuropeanEngine.Value)
    let _getResidualTime                           = triv (fun () -> _FDDividendEuropeanEngine.Value.getResidualTime())
    let _grid                                      = triv (fun () -> _FDDividendEuropeanEngine.Value.grid())
    let _intrinsicValues_                          = triv (fun () -> _FDDividendEuropeanEngine.Value.intrinsicValues_)
    do this.Bind(_FDDividendEuropeanEngine)

(* 
    Externally visible/bindable properties
*)
    member this.Process                            = _Process 
    member this.timeSteps                          = _timeSteps 
    member this.gridPoints                         = _gridPoints 
    member this.timeDependent                      = _timeDependent 
    member this.Factory                            Process timeSteps gridPoints   
                                                   = _factory Process timeSteps gridPoints 
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.Reset                              = _reset
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Update                             = _update
    member this.EnsureStrikeInGrid                 = _ensureStrikeInGrid
    member this.GetResidualTime                    = _getResidualTime
    member this.Grid                               = _grid
    member this.IntrinsicValues_                   = _intrinsicValues_