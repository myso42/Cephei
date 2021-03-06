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
  Lorig Pagliarani Pascucci expansion of order-3 for the Heston model. During calibration, it can be initialized once per expiry, and called many times with different strikes.  The formula is also available in the Mathematica notebook from the authors at http://explicitsolutions.wordpress.com/

  </summary> *)
[<AutoSerializable(true)>]
type LPP3HestonExpansionModel
    ( kappa                                        : ICell<double>
    , theta                                        : ICell<double>
    , sigma                                        : ICell<double>
    , v0                                           : ICell<double>
    , rho                                          : ICell<double>
    , term                                         : ICell<double>
    ) as this =

    inherit Model<LPP3HestonExpansion> ()
(*
    Parameters
*)
    let _kappa                                     = kappa
    let _theta                                     = theta
    let _sigma                                     = sigma
    let _v0                                        = v0
    let _rho                                       = rho
    let _term                                      = term
(*
    Functions
*)
    let mutable
        _LPP3HestonExpansion                       = make (fun () -> new LPP3HestonExpansion (kappa.Value, theta.Value, sigma.Value, v0.Value, rho.Value, term.Value))
    let _impliedVolatility                         (strike : ICell<double>) (forward : ICell<double>)   
                                                   = triv _LPP3HestonExpansion (fun () -> _LPP3HestonExpansion.Value.impliedVolatility(strike.Value, forward.Value))
    do this.Bind(_LPP3HestonExpansion)
(* 
    casting 
*)
    internal new () = new LPP3HestonExpansionModel(null,null,null,null,null,null)
    member internal this.Inject v = _LPP3HestonExpansion <- v
    static member Cast (p : ICell<LPP3HestonExpansion>) = 
        if p :? LPP3HestonExpansionModel then 
            p :?> LPP3HestonExpansionModel
        else
            let o = new LPP3HestonExpansionModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.kappa                              = _kappa 
    member this.theta                              = _theta 
    member this.sigma                              = _sigma 
    member this.v0                                 = _v0 
    member this.rho                                = _rho 
    member this.term                               = _term 
    member this.ImpliedVolatility                  strike forward   
                                                   = _impliedVolatility strike forward 
