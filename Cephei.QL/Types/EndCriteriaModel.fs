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
  Criteria to end optimization process:   - maximum number of iterations AND minimum number of iterations around stationary point - x (independent variable) stationary point - y=f(x) (dependent variable) stationary point - stationary gradient
! Initialization constructor
  </summary> *)
[<AutoSerializable(true)>]
type EndCriteriaModel
    ( maxIterations                                : ICell<int>
    , maxStationaryStateIterations                 : ICell<Nullable<int>>
    , rootEpsilon                                  : ICell<double>
    , functionEpsilon                              : ICell<double>
    , gradientNormEpsilon                          : ICell<Nullable<double>>
    ) as this =

    inherit Model<EndCriteria> ()
(*
    Parameters
*)
    let _maxIterations                             = maxIterations
    let _maxStationaryStateIterations              = maxStationaryStateIterations
    let _rootEpsilon                               = rootEpsilon
    let _functionEpsilon                           = functionEpsilon
    let _gradientNormEpsilon                       = gradientNormEpsilon
(*
    Functions
*)
    let mutable
        _EndCriteria                               = make (fun () -> new EndCriteria (maxIterations.Value, maxStationaryStateIterations.Value, rootEpsilon.Value, functionEpsilon.Value, gradientNormEpsilon.Value))
    let _checkMaxIterations                        (iteration : ICell<int>) (ecType : ICell<EndCriteria.Type>)   
                                                   = triv _EndCriteria (fun () -> _EndCriteria.Value.checkMaxIterations(iteration.Value, ref ecType.Value))
    let _checkStationaryFunctionAccuracy           (f : ICell<double>) (positiveOptimization : ICell<bool>) (ecType : ICell<EndCriteria.Type>)   
                                                   = triv _EndCriteria (fun () -> _EndCriteria.Value.checkStationaryFunctionAccuracy(f.Value, positiveOptimization.Value, ref ecType.Value))
    let _checkStationaryFunctionValue              (fxOld : ICell<double>) (fxNew : ICell<double>) (statStateIterations : ICell<int>) (ecType : ICell<EndCriteria.Type>)   
                                                   = cell _EndCriteria (fun () -> _EndCriteria.Value.checkStationaryFunctionValue(fxOld.Value, fxNew.Value, ref statStateIterations.Value, ref ecType.Value))
    let _checkStationaryPoint                      (xOld : ICell<double>) (xNew : ICell<double>) (statStateIterations : ICell<int>) (ecType : ICell<EndCriteria.Type>)   
                                                   = cell _EndCriteria (fun () -> _EndCriteria.Value.checkStationaryPoint(xOld.Value, xNew.Value, ref statStateIterations.Value, ref ecType.Value))
    let _checkZeroGradientNorm                     (gradientNorm : ICell<double>) (ecType : ICell<EndCriteria.Type>)   
                                                   = triv _EndCriteria (fun () -> _EndCriteria.Value.checkZeroGradientNorm(gradientNorm.Value, ref ecType.Value))
    let _functionEpsilon                           = triv _EndCriteria (fun () -> _EndCriteria.Value.functionEpsilon())
    let _gradientNormEpsilon                       = triv _EndCriteria (fun () -> _EndCriteria.Value.gradientNormEpsilon())
    let _maxIterations                             = triv _EndCriteria (fun () -> _EndCriteria.Value.maxIterations())
    let _maxStationaryStateIterations              = triv _EndCriteria (fun () -> _EndCriteria.Value.maxStationaryStateIterations())
    let _rootEpsilon                               = triv _EndCriteria (fun () -> _EndCriteria.Value.rootEpsilon())
    let _value                                     (iteration : ICell<int>) (statStateIterations : ICell<int>) (positiveOptimization : ICell<bool>) (fold : ICell<double>) (UnnamedParameter1 : ICell<double>) (fnew : ICell<double>) (normgnew : ICell<double>) (ecType : ICell<EndCriteria.Type>)   
                                                   = cell _EndCriteria (fun () -> _EndCriteria.Value.value(iteration.Value, ref statStateIterations.Value, positiveOptimization.Value, fold.Value, UnnamedParameter1.Value, fnew.Value, normgnew.Value, ref ecType.Value))
    do this.Bind(_EndCriteria)
(* 
    casting 
*)
    internal new () = new EndCriteriaModel(null,null,null,null,null)
    member internal this.Inject v = _EndCriteria <- v
    static member Cast (p : ICell<EndCriteria>) = 
        if p :? EndCriteriaModel then 
            p :?> EndCriteriaModel
        else
            let o = new EndCriteriaModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.maxIterations                      = _maxIterations 
    member this.maxStationaryStateIterations       = _maxStationaryStateIterations 
    member this.rootEpsilon                        = _rootEpsilon 
    member this.functionEpsilon                    = _functionEpsilon 
    member this.gradientNormEpsilon                = _gradientNormEpsilon 
    member this.CheckMaxIterations                 iteration ecType   
                                                   = _checkMaxIterations iteration ecType 
    member this.CheckStationaryFunctionAccuracy    f positiveOptimization ecType   
                                                   = _checkStationaryFunctionAccuracy f positiveOptimization ecType 
    member this.CheckStationaryFunctionValue       fxOld fxNew statStateIterations ecType   
                                                   = _checkStationaryFunctionValue fxOld fxNew statStateIterations ecType 
    member this.CheckStationaryPoint               xOld xNew statStateIterations ecType   
                                                   = _checkStationaryPoint xOld xNew statStateIterations ecType 
    member this.CheckZeroGradientNorm              gradientNorm ecType   
                                                   = _checkZeroGradientNorm gradientNorm ecType 
    member this.FunctionEpsilon                    = _functionEpsilon
    member this.GradientNormEpsilon                = _gradientNormEpsilon
    member this.MaxIterations                      = _maxIterations
    member this.MaxStationaryStateIterations       = _maxStationaryStateIterations
    member this.RootEpsilon                        = _rootEpsilon
    member this.Value                              iteration statStateIterations positiveOptimization fold UnnamedParameter1 fnew normgnew ecType   
                                                   = _value iteration statStateIterations positiveOptimization fold UnnamedParameter1 fnew normgnew ecType 
