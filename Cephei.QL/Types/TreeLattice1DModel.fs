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
  One-dimensional tree-based lattice.

  </summary> *)
[<AutoSerializable(true)>]
type TreeLattice1DModel<'T when 'T :> IGenericLattice>
    ( timeGrid                                     : ICell<TimeGrid>
    , n                                            : ICell<int>
    ) as this =

    inherit Model<TreeLattice1D<'T>> ()
(*
    Parameters
*)
    let _timeGrid                                  = timeGrid
    let _n                                         = n
(*
    Functions
*)
    let mutable
        _TreeLattice1D                             = make (fun () -> new TreeLattice1D<'T> (timeGrid.Value, n.Value))
    let _grid                                      (t : ICell<double>)   
                                                   = triv _TreeLattice1D (fun () -> _TreeLattice1D.Value.grid(t.Value))
    let _underlying                                (i : ICell<int>) (index : ICell<int>)   
                                                   = triv _TreeLattice1D (fun () -> _TreeLattice1D.Value.underlying(i.Value, index.Value))
    let _initialize                                (asset : ICell<DiscretizedAsset>) (t : ICell<double>)   
                                                   = triv _TreeLattice1D (fun () -> _TreeLattice1D.Value.initialize(asset.Value, t.Value)
                                                                                    _TreeLattice1D.Value)
    let _partialRollback                           (asset : ICell<DiscretizedAsset>) (To : ICell<double>)   
                                                   = triv _TreeLattice1D (fun () -> _TreeLattice1D.Value.partialRollback(asset.Value, To.Value)
                                                                                    _TreeLattice1D.Value)
    let _presentValue                              (asset : ICell<DiscretizedAsset>)   
                                                   = triv _TreeLattice1D (fun () -> _TreeLattice1D.Value.presentValue(asset.Value))
    let _rollback                                  (asset : ICell<DiscretizedAsset>) (To : ICell<double>)   
                                                   = triv _TreeLattice1D (fun () -> _TreeLattice1D.Value.rollback(asset.Value, To.Value)
                                                                                    _TreeLattice1D.Value)
    let _statePrices                               (i : ICell<int>)   
                                                   = triv _TreeLattice1D (fun () -> _TreeLattice1D.Value.statePrices(i.Value))
    let _stepback                                  (i : ICell<int>) (values : ICell<Vector>) (newValues : ICell<Vector>)   
                                                   = triv _TreeLattice1D (fun () -> _TreeLattice1D.Value.stepback(i.Value, values.Value, newValues.Value)
                                                                                    _TreeLattice1D.Value)
    let _timeGrid                                  = triv _TreeLattice1D (fun () -> _TreeLattice1D.Value.timeGrid())
    do this.Bind(_TreeLattice1D)

(* 
    Externally visible/bindable properties
*)
    member this.timeGrid                           = _timeGrid 
    member this.n                                  = _n 
    member this.Grid                               t   
                                                   = _grid t 
    member this.Underlying                         i index   
                                                   = _underlying i index 
    member this.Initialize                         asset t   
                                                   = _initialize asset t 
    member this.PartialRollback                    asset To   
                                                   = _partialRollback asset To 
    member this.PresentValue                       asset   
                                                   = _presentValue asset 
    member this.Rollback                           asset To   
                                                   = _rollback asset To 
    member this.StatePrices                        i   
                                                   = _statePrices i 
    member this.Stepback                           i values newValues   
                                                   = _stepback i values newValues 
    member this.TimeGrid                           = _timeGrid
