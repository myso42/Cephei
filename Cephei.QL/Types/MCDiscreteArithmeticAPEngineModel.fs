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
template <class RNG = PseudoRandom, class S = Statistics>
constructor
  </summary> *)
[<AutoSerializable(true)>]
type MCDiscreteArithmeticAPEngineModel<'RNG, 'S when 'RNG :> IRSG and 'RNG : (new : unit -> 'RNG) and 'S :> IGeneralStatistics and 'S : (new : unit -> 'S)>
    ( Process                                      : ICell<GeneralizedBlackScholesProcess>
    , maxTimeStepPerYear                           : ICell<int>
    , brownianBridge                               : ICell<bool>
    , antitheticVariate                            : ICell<bool>
    , controlVariate                               : ICell<bool>
    , requiredSamples                              : ICell<int>
    , requiredTolerance                            : ICell<double>
    , maxSamples                                   : ICell<int>
    , seed                                         : ICell<uint64>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<MCDiscreteArithmeticAPEngine<'RNG,'S>> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _Process                                   = Process
    let _maxTimeStepPerYear                        = maxTimeStepPerYear
    let _brownianBridge                            = brownianBridge
    let _antitheticVariate                         = antitheticVariate
    let _controlVariate                            = controlVariate
    let _requiredSamples                           = requiredSamples
    let _requiredTolerance                         = requiredTolerance
    let _maxSamples                                = maxSamples
    let _seed                                      = seed
(*
    Functions
*)
    let mutable
        _MCDiscreteArithmeticAPEngine              = make (fun () -> (createEvaluationDate _evaluationDate (fun () ->new MCDiscreteArithmeticAPEngine<'RNG,'S> (Process.Value, maxTimeStepPerYear.Value, brownianBridge.Value, antitheticVariate.Value, controlVariate.Value, requiredSamples.Value, requiredTolerance.Value, maxSamples.Value, seed.Value))))
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _MCDiscreteArithmeticAPEngine (fun () -> (curryEvaluationDate _evaluationDate _MCDiscreteArithmeticAPEngine).Value.registerWith(handler.Value)
                                                                                                   _MCDiscreteArithmeticAPEngine.Value)
    let _reset                                     = triv _MCDiscreteArithmeticAPEngine (fun () -> (curryEvaluationDate _evaluationDate _MCDiscreteArithmeticAPEngine).Value.reset()
                                                                                                   _MCDiscreteArithmeticAPEngine.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _MCDiscreteArithmeticAPEngine (fun () -> (curryEvaluationDate _evaluationDate _MCDiscreteArithmeticAPEngine).Value.unregisterWith(handler.Value)
                                                                                                   _MCDiscreteArithmeticAPEngine.Value)
    let _update                                    = triv _MCDiscreteArithmeticAPEngine (fun () -> (curryEvaluationDate _evaluationDate _MCDiscreteArithmeticAPEngine).Value.update()
                                                                                                   _MCDiscreteArithmeticAPEngine.Value)
    let _errorEstimate                             = triv _MCDiscreteArithmeticAPEngine (fun () -> (curryEvaluationDate _evaluationDate _MCDiscreteArithmeticAPEngine).Value.errorEstimate())
    let _sampleAccumulator                         = triv _MCDiscreteArithmeticAPEngine (fun () -> (curryEvaluationDate _evaluationDate _MCDiscreteArithmeticAPEngine).Value.sampleAccumulator())
    let _value                                     (tolerance : ICell<double>) (maxSamples : ICell<int>) (minSamples : ICell<int>)   
                                                   = triv _MCDiscreteArithmeticAPEngine (fun () -> (curryEvaluationDate _evaluationDate _MCDiscreteArithmeticAPEngine).Value.value(tolerance.Value, maxSamples.Value, minSamples.Value))
    let _valueWithSamples                          (samples : ICell<int>)   
                                                   = triv _MCDiscreteArithmeticAPEngine (fun () -> (curryEvaluationDate _evaluationDate _MCDiscreteArithmeticAPEngine).Value.valueWithSamples(samples.Value))
    do this.Bind(_MCDiscreteArithmeticAPEngine)

(* 
    Externally visible/bindable properties
*)
    member this.Process                            = _Process 
    member this.maxTimeStepPerYear                 = _maxTimeStepPerYear 
    member this.brownianBridge                     = _brownianBridge 
    member this.antitheticVariate                  = _antitheticVariate 
    member this.controlVariate                     = _controlVariate 
    member this.requiredSamples                    = _requiredSamples 
    member this.requiredTolerance                  = _requiredTolerance 
    member this.maxSamples                         = _maxSamples 
    member this.seed                               = _seed 
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.Reset                              = _reset
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Update                             = _update
    member this.ErrorEstimate                      = _errorEstimate
    member this.SampleAccumulator                  = _sampleAccumulator
    member this.Value                              tolerance maxSamples minSamples   
                                                   = _value tolerance maxSamples minSamples 
    member this.ValueWithSamples                   samples   
                                                   = _valueWithSamples samples 
