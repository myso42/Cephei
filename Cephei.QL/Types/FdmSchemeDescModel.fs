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
type FdmSchemeDescModel
    ( Type                                         : ICell<FdmSchemeDesc.FdmSchemeType>
    , theta                                        : ICell<double>
    , mu                                           : ICell<double>
    ) as this =

    inherit Model<FdmSchemeDesc> ()
(*
    Parameters
*)
    let _Type                                      = Type
    let _theta                                     = theta
    let _mu                                        = mu
(*
    Functions
*)
    let mutable
        _FdmSchemeDesc                             = make (fun () -> new FdmSchemeDesc (Type.Value, theta.Value, mu.Value))
    let _CraigSneyd                                = triv _FdmSchemeDesc (fun () -> _FdmSchemeDesc.Value.CraigSneyd())
    let _CrankNicolson                             = triv _FdmSchemeDesc (fun () -> _FdmSchemeDesc.Value.CrankNicolson())
    let _Douglas                                   = triv _FdmSchemeDesc (fun () -> _FdmSchemeDesc.Value.Douglas())
    let _ExplicitEuler                             = triv _FdmSchemeDesc (fun () -> _FdmSchemeDesc.Value.ExplicitEuler())
    let _Hundsdorfer                               = triv _FdmSchemeDesc (fun () -> _FdmSchemeDesc.Value.Hundsdorfer())
    let _ImplicitEuler                             = triv _FdmSchemeDesc (fun () -> _FdmSchemeDesc.Value.ImplicitEuler())
    let _MethodOfLines                             (eps : ICell<double>) (relInitStepSize : ICell<double>)   
                                                   = triv _FdmSchemeDesc (fun () -> _FdmSchemeDesc.Value.MethodOfLines(eps.Value, relInitStepSize.Value))
    let _ModifiedCraigSneyd                        = triv _FdmSchemeDesc (fun () -> _FdmSchemeDesc.Value.ModifiedCraigSneyd())
    let _ModifiedHundsdorfer                       = triv _FdmSchemeDesc (fun () -> _FdmSchemeDesc.Value.ModifiedHundsdorfer())
    let _mu                                        = triv _FdmSchemeDesc (fun () -> _FdmSchemeDesc.Value.mu)
    let _theta                                     = triv _FdmSchemeDesc (fun () -> _FdmSchemeDesc.Value.theta)
    let _TrBDF2                                    = triv _FdmSchemeDesc (fun () -> _FdmSchemeDesc.Value.TrBDF2())
    let _type                                      = triv _FdmSchemeDesc (fun () -> _FdmSchemeDesc.Value.TYPE)
    do this.Bind(_FdmSchemeDesc)
(* 
    casting 
*)
    internal new () = new FdmSchemeDescModel(null,null,null)
    member internal this.Inject v = _FdmSchemeDesc <- v
    static member Cast (p : ICell<FdmSchemeDesc>) = 
        if p :? FdmSchemeDescModel then 
            p :?> FdmSchemeDescModel
        else
            let o = new FdmSchemeDescModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Type                               = _Type 
    member this.theta                              = _theta 
    member this.mu                                 = _mu 
    member this.CraigSneyd                         = _CraigSneyd
    member this.CrankNicolson                      = _CrankNicolson
    member this.Douglas                            = _Douglas
    member this.ExplicitEuler                      = _ExplicitEuler
    member this.Hundsdorfer                        = _Hundsdorfer
    member this.ImplicitEuler                      = _ImplicitEuler
    member this.MethodOfLines                      eps relInitStepSize   
                                                   = _MethodOfLines eps relInitStepSize 
    member this.ModifiedCraigSneyd                 = _ModifiedCraigSneyd
    member this.ModifiedHundsdorfer                = _ModifiedHundsdorfer
    member this.Mu                                 = _mu
    member this.Theta                              = _theta
    member this.TrBDF2                             = _TrBDF2
    member this.Type1                              = _type
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type FdmSchemeDescModel1
    () as this =
    inherit Model<FdmSchemeDesc> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _FdmSchemeDesc                             = make (fun () -> new FdmSchemeDesc ())
    let _CraigSneyd                                = triv _FdmSchemeDesc (fun () -> _FdmSchemeDesc.Value.CraigSneyd())
    let _CrankNicolson                             = triv _FdmSchemeDesc (fun () -> _FdmSchemeDesc.Value.CrankNicolson())
    let _Douglas                                   = triv _FdmSchemeDesc (fun () -> _FdmSchemeDesc.Value.Douglas())
    let _ExplicitEuler                             = triv _FdmSchemeDesc (fun () -> _FdmSchemeDesc.Value.ExplicitEuler())
    let _Hundsdorfer                               = triv _FdmSchemeDesc (fun () -> _FdmSchemeDesc.Value.Hundsdorfer())
    let _ImplicitEuler                             = triv _FdmSchemeDesc (fun () -> _FdmSchemeDesc.Value.ImplicitEuler())
    let _MethodOfLines                             (eps : ICell<double>) (relInitStepSize : ICell<double>)   
                                                   = triv _FdmSchemeDesc (fun () -> _FdmSchemeDesc.Value.MethodOfLines(eps.Value, relInitStepSize.Value))
    let _ModifiedCraigSneyd                        = triv _FdmSchemeDesc (fun () -> _FdmSchemeDesc.Value.ModifiedCraigSneyd())
    let _ModifiedHundsdorfer                       = triv _FdmSchemeDesc (fun () -> _FdmSchemeDesc.Value.ModifiedHundsdorfer())
    let _mu                                        = triv _FdmSchemeDesc (fun () -> _FdmSchemeDesc.Value.mu)
    let _theta                                     = triv _FdmSchemeDesc (fun () -> _FdmSchemeDesc.Value.theta)
    let _TrBDF2                                    = triv _FdmSchemeDesc (fun () -> _FdmSchemeDesc.Value.TrBDF2())
    let _type                                      = triv _FdmSchemeDesc (fun () -> _FdmSchemeDesc.Value.TYPE)
    do this.Bind(_FdmSchemeDesc)
(* 
    casting 
*)
    
    member internal this.Inject v = _FdmSchemeDesc <- v
    static member Cast (p : ICell<FdmSchemeDesc>) = 
        if p :? FdmSchemeDescModel1 then 
            p :?> FdmSchemeDescModel1
        else
            let o = new FdmSchemeDescModel1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.CraigSneyd                         = _CraigSneyd
    member this.CrankNicolson                      = _CrankNicolson
    member this.Douglas                            = _Douglas
    member this.ExplicitEuler                      = _ExplicitEuler
    member this.Hundsdorfer                        = _Hundsdorfer
    member this.ImplicitEuler                      = _ImplicitEuler
    member this.MethodOfLines                      eps relInitStepSize   
                                                   = _MethodOfLines eps relInitStepSize 
    member this.ModifiedCraigSneyd                 = _ModifiedCraigSneyd
    member this.ModifiedHundsdorfer                = _ModifiedHundsdorfer
    member this.Mu                                 = _mu
    member this.Theta                              = _theta
    member this.TrBDF2                             = _TrBDF2
    member this.Type                               = _type
