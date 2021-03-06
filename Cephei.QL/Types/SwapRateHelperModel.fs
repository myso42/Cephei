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
Rate helper for bootstrapping over swap rates

  </summary> *)
[<AutoSerializable(true)>]
type SwapRateHelperModel
    ( rate                                         : ICell<double>
    , tenor                                        : ICell<Period>
    , calendar                                     : ICell<Calendar>
    , fixedFrequency                               : ICell<Frequency>
    , fixedConvention                              : ICell<BusinessDayConvention>
    , fixedDayCount                                : ICell<DayCounter>
    , iborIndex                                    : ICell<IborIndex>
    , spread                                       : ICell<Handle<Quote>>
    , fwdStart                                     : ICell<Period>
    , discount                                     : ICell<Handle<YieldTermStructure>>
    , settlementDays                               : ICell<Nullable<int>>
    , pillarChoice                                 : ICell<Pillar.Choice>
    , customPillarDate                             : ICell<Date>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<SwapRateHelper> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _rate                                      = rate
    let _tenor                                     = tenor
    let _calendar                                  = calendar
    let _fixedFrequency                            = fixedFrequency
    let _fixedConvention                           = fixedConvention
    let _fixedDayCount                             = fixedDayCount
    let _iborIndex                                 = iborIndex
    let _spread                                    = spread
    let _fwdStart                                  = fwdStart
    let _discount                                  = discount
    let _settlementDays                            = settlementDays
    let _pillarChoice                              = pillarChoice
    let _customPillarDate                          = customPillarDate
(*
    Functions
*)
    let mutable
        _SwapRateHelper                            = make (fun () -> (createEvaluationDate _evaluationDate (fun () ->new SwapRateHelper (rate.Value, tenor.Value, calendar.Value, fixedFrequency.Value, fixedConvention.Value, fixedDayCount.Value, iborIndex.Value, spread.Value, fwdStart.Value, discount.Value, settlementDays.Value, pillarChoice.Value, customPillarDate.Value))))
    let _forwardStart                              = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.forwardStart())
    let _impliedQuote                              = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.impliedQuote())
    let _setTermStructure                          (t : ICell<YieldTermStructure>)   
                                                   = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.setTermStructure(t.Value)
                                                                                     _SwapRateHelper.Value)
    let _spread                                    = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.spread())
    let _swap                                      = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.swap())
    let _update                                    = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.update()
                                                                                     _SwapRateHelper.Value)
    let _earliestDate                              = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.earliestDate())
    let _latestDate                                = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.latestDate())
    let _latestRelevantDate                        = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.latestRelevantDate())
    let _maturityDate                              = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.maturityDate())
    let _pillarDate                                = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.pillarDate())
    let _quote                                     = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.quote())
    let _quoteError                                = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.quoteError())
    let _quoteIsValid                              = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.quoteIsValid())
    let _quoteValue                                = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.quoteValue())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.registerWith(handler.Value)
                                                                                     _SwapRateHelper.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.unregisterWith(handler.Value)
                                                                                     _SwapRateHelper.Value)
    do this.Bind(_SwapRateHelper)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new SwapRateHelperModel(null,null,null,null,null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _SwapRateHelper <- v
    static member Cast (p : ICell<SwapRateHelper>) = 
        if p :? SwapRateHelperModel then 
            p :?> SwapRateHelperModel
        else
            let o = new SwapRateHelperModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.rate                               = _rate 
    member this.tenor                              = _tenor 
    member this.calendar                           = _calendar 
    member this.fixedFrequency                     = _fixedFrequency 
    member this.fixedConvention                    = _fixedConvention 
    member this.fixedDayCount                      = _fixedDayCount 
    member this.iborIndex                          = _iborIndex 
    member this.spread                             = _spread 
    member this.fwdStart                           = _fwdStart 
    member this.discount                           = _discount 
    member this.settlementDays                     = _settlementDays 
    member this.pillarChoice                       = _pillarChoice 
    member this.customPillarDate                   = _customPillarDate 
    member this.ForwardStart                       = _forwardStart
    member this.ImpliedQuote                       = _impliedQuote
    member this.SetTermStructure                   t   
                                                   = _setTermStructure t 
    member this.Spread                             = _spread
    member this.Swap                               = _swap
    member this.Update                             = _update
    member this.EarliestDate                       = _earliestDate
    member this.LatestDate                         = _latestDate
    member this.LatestRelevantDate                 = _latestRelevantDate
    member this.MaturityDate                       = _maturityDate
    member this.PillarDate                         = _pillarDate
    member this.Quote                              = _quote
    member this.QuoteError                         = _quoteError
    member this.QuoteIsValid                       = _quoteIsValid
    member this.QuoteValue                         = _quoteValue
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
(* <summary>
Rate helper for bootstrapping over swap rates

  </summary> *)
[<AutoSerializable(true)>]
type SwapRateHelperModel1
    ( rate                                         : ICell<double>
    , swapIndex                                    : ICell<SwapIndex>
    , spread                                       : ICell<Handle<Quote>>
    , fwdStart                                     : ICell<Period>
    , discount                                     : ICell<Handle<YieldTermStructure>>
    , pillarChoice                                 : ICell<Pillar.Choice>
    , customPillarDate                             : ICell<Date>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<SwapRateHelper> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _rate                                      = rate
    let _swapIndex                                 = swapIndex
    let _spread                                    = spread
    let _fwdStart                                  = fwdStart
    let _discount                                  = discount
    let _pillarChoice                              = pillarChoice
    let _customPillarDate                          = customPillarDate
(*
    Functions
*)
    let mutable
        _SwapRateHelper                            = make (fun () -> (createEvaluationDate _evaluationDate (fun () ->new SwapRateHelper (rate.Value, swapIndex.Value, spread.Value, fwdStart.Value, discount.Value, pillarChoice.Value, customPillarDate.Value))))
    let _forwardStart                              = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.forwardStart())
    let _impliedQuote                              = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.impliedQuote())
    let _setTermStructure                          (t : ICell<YieldTermStructure>)   
                                                   = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.setTermStructure(t.Value)
                                                                                     _SwapRateHelper.Value)
    let _spread                                    = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.spread())
    let _swap                                      = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.swap())
    let _update                                    = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.update()
                                                                                     _SwapRateHelper.Value)
    let _earliestDate                              = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.earliestDate())
    let _latestDate                                = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.latestDate())
    let _latestRelevantDate                        = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.latestRelevantDate())
    let _maturityDate                              = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.maturityDate())
    let _pillarDate                                = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.pillarDate())
    let _quote                                     = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.quote())
    let _quoteError                                = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.quoteError())
    let _quoteIsValid                              = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.quoteIsValid())
    let _quoteValue                                = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.quoteValue())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.registerWith(handler.Value)
                                                                                     _SwapRateHelper.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.unregisterWith(handler.Value)
                                                                                     _SwapRateHelper.Value)
    do this.Bind(_SwapRateHelper)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new SwapRateHelperModel1(null,null,null,null,null,null,null,null)
    member internal this.Inject v = _SwapRateHelper <- v
    static member Cast (p : ICell<SwapRateHelper>) = 
        if p :? SwapRateHelperModel1 then 
            p :?> SwapRateHelperModel1
        else
            let o = new SwapRateHelperModel1 ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.rate                               = _rate 
    member this.swapIndex                          = _swapIndex 
    member this.spread                             = _spread 
    member this.fwdStart                           = _fwdStart 
    member this.discount                           = _discount 
    member this.pillarChoice                       = _pillarChoice 
    member this.customPillarDate                   = _customPillarDate 
    member this.ForwardStart                       = _forwardStart
    member this.ImpliedQuote                       = _impliedQuote
    member this.SetTermStructure                   t   
                                                   = _setTermStructure t 
    member this.Spread                             = _spread
    member this.Swap                               = _swap
    member this.Update                             = _update
    member this.EarliestDate                       = _earliestDate
    member this.LatestDate                         = _latestDate
    member this.LatestRelevantDate                 = _latestRelevantDate
    member this.MaturityDate                       = _maturityDate
    member this.PillarDate                         = _pillarDate
    member this.Quote                              = _quote
    member this.QuoteError                         = _quoteError
    member this.QuoteIsValid                       = _quoteIsValid
    member this.QuoteValue                         = _quoteValue
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
(* <summary>
Rate helper for bootstrapping over swap rates

  </summary> *)
[<AutoSerializable(true)>]
type SwapRateHelperModel2
    ( rate                                         : ICell<Handle<Quote>>
    , tenor                                        : ICell<Period>
    , calendar                                     : ICell<Calendar>
    , fixedFrequency                               : ICell<Frequency>
    , fixedConvention                              : ICell<BusinessDayConvention>
    , fixedDayCount                                : ICell<DayCounter>
    , iborIndex                                    : ICell<IborIndex>
    , spread                                       : ICell<Handle<Quote>>
    , fwdStart                                     : ICell<Period>
    , discount                                     : ICell<Handle<YieldTermStructure>>
    , settlementDays                               : ICell<Nullable<int>>
    , pillarChoice                                 : ICell<Pillar.Choice>
    , customPillarDate                             : ICell<Date>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<SwapRateHelper> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _rate                                      = rate
    let _tenor                                     = tenor
    let _calendar                                  = calendar
    let _fixedFrequency                            = fixedFrequency
    let _fixedConvention                           = fixedConvention
    let _fixedDayCount                             = fixedDayCount
    let _iborIndex                                 = iborIndex
    let _spread                                    = spread
    let _fwdStart                                  = fwdStart
    let _discount                                  = discount
    let _settlementDays                            = settlementDays
    let _pillarChoice                              = pillarChoice
    let _customPillarDate                          = customPillarDate
(*
    Functions
*)
    let mutable
        _SwapRateHelper                            = make (fun () -> (createEvaluationDate _evaluationDate (fun () ->new SwapRateHelper (rate.Value, tenor.Value, calendar.Value, fixedFrequency.Value, fixedConvention.Value, fixedDayCount.Value, iborIndex.Value, spread.Value, fwdStart.Value, discount.Value, settlementDays.Value, pillarChoice.Value, customPillarDate.Value))))
    let _forwardStart                              = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.forwardStart())
    let _impliedQuote                              = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.impliedQuote())
    let _setTermStructure                          (t : ICell<YieldTermStructure>)   
                                                   = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.setTermStructure(t.Value)
                                                                                     _SwapRateHelper.Value)
    let _spread                                    = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.spread())
    let _swap                                      = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.swap())
    let _update                                    = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.update()
                                                                                     _SwapRateHelper.Value)
    let _earliestDate                              = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.earliestDate())
    let _latestDate                                = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.latestDate())
    let _latestRelevantDate                        = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.latestRelevantDate())
    let _maturityDate                              = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.maturityDate())
    let _pillarDate                                = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.pillarDate())
    let _quote                                     = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.quote())
    let _quoteError                                = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.quoteError())
    let _quoteIsValid                              = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.quoteIsValid())
    let _quoteValue                                = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.quoteValue())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.registerWith(handler.Value)
                                                                                     _SwapRateHelper.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.unregisterWith(handler.Value)
                                                                                     _SwapRateHelper.Value)
    do this.Bind(_SwapRateHelper)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new SwapRateHelperModel2(null,null,null,null,null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _SwapRateHelper <- v
    static member Cast (p : ICell<SwapRateHelper>) = 
        if p :? SwapRateHelperModel2 then 
            p :?> SwapRateHelperModel2
        else
            let o = new SwapRateHelperModel2 ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.rate                               = _rate 
    member this.tenor                              = _tenor 
    member this.calendar                           = _calendar 
    member this.fixedFrequency                     = _fixedFrequency 
    member this.fixedConvention                    = _fixedConvention 
    member this.fixedDayCount                      = _fixedDayCount 
    member this.iborIndex                          = _iborIndex 
    member this.spread                             = _spread 
    member this.fwdStart                           = _fwdStart 
    member this.discount                           = _discount 
    member this.settlementDays                     = _settlementDays 
    member this.pillarChoice                       = _pillarChoice 
    member this.customPillarDate                   = _customPillarDate 
    member this.ForwardStart                       = _forwardStart
    member this.ImpliedQuote                       = _impliedQuote
    member this.SetTermStructure                   t   
                                                   = _setTermStructure t 
    member this.Spread                             = _spread
    member this.Swap                               = _swap
    member this.Update                             = _update
    member this.EarliestDate                       = _earliestDate
    member this.LatestDate                         = _latestDate
    member this.LatestRelevantDate                 = _latestRelevantDate
    member this.MaturityDate                       = _maturityDate
    member this.PillarDate                         = _pillarDate
    member this.Quote                              = _quote
    member this.QuoteError                         = _quoteError
    member this.QuoteIsValid                       = _quoteIsValid
    member this.QuoteValue                         = _quoteValue
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
(* <summary>
Rate helper for bootstrapping over swap rates

  </summary> *)
[<AutoSerializable(true)>]
type SwapRateHelperModel3
    ( rate                                         : ICell<Handle<Quote>>
    , swapIndex                                    : ICell<SwapIndex>
    , spread                                       : ICell<Handle<Quote>>
    , fwdStart                                     : ICell<Period>
    , discount                                     : ICell<Handle<YieldTermStructure>>
    , pillarChoice                                 : ICell<Pillar.Choice>
    , customPillarDate                             : ICell<Date>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<SwapRateHelper> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _rate                                      = rate
    let _swapIndex                                 = swapIndex
    let _spread                                    = spread
    let _fwdStart                                  = fwdStart
    let _discount                                  = discount
    let _pillarChoice                              = pillarChoice
    let _customPillarDate                          = customPillarDate
(*
    Functions
*)
    let mutable
        _SwapRateHelper                            = make (fun () -> (createEvaluationDate _evaluationDate (fun () ->new SwapRateHelper (rate.Value, swapIndex.Value, spread.Value, fwdStart.Value, discount.Value, pillarChoice.Value, customPillarDate.Value))))
    let _forwardStart                              = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.forwardStart())
    let _impliedQuote                              = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.impliedQuote())
    let _setTermStructure                          (t : ICell<YieldTermStructure>)   
                                                   = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.setTermStructure(t.Value)
                                                                                     _SwapRateHelper.Value)
    let _spread                                    = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.spread())
    let _swap                                      = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.swap())
    let _update                                    = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.update()
                                                                                     _SwapRateHelper.Value)
    let _earliestDate                              = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.earliestDate())
    let _latestDate                                = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.latestDate())
    let _latestRelevantDate                        = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.latestRelevantDate())
    let _maturityDate                              = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.maturityDate())
    let _pillarDate                                = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.pillarDate())
    let _quote                                     = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.quote())
    let _quoteError                                = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.quoteError())
    let _quoteIsValid                              = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.quoteIsValid())
    let _quoteValue                                = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.quoteValue())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.registerWith(handler.Value)
                                                                                     _SwapRateHelper.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _SwapRateHelper (fun () -> (curryEvaluationDate _evaluationDate _SwapRateHelper).Value.unregisterWith(handler.Value)
                                                                                     _SwapRateHelper.Value)
    do this.Bind(_SwapRateHelper)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new SwapRateHelperModel3(null,null,null,null,null,null,null,null)
    member internal this.Inject v = _SwapRateHelper <- v
    static member Cast (p : ICell<SwapRateHelper>) = 
        if p :? SwapRateHelperModel3 then 
            p :?> SwapRateHelperModel3
        else
            let o = new SwapRateHelperModel3 ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.rate                               = _rate 
    member this.swapIndex                          = _swapIndex 
    member this.spread                             = _spread 
    member this.fwdStart                           = _fwdStart 
    member this.discount                           = _discount 
    member this.pillarChoice                       = _pillarChoice 
    member this.customPillarDate                   = _customPillarDate 
    member this.ForwardStart                       = _forwardStart
    member this.ImpliedQuote                       = _impliedQuote
    member this.SetTermStructure                   t   
                                                   = _setTermStructure t 
    member this.Spread                             = _spread
    member this.Swap                               = _swap
    member this.Update                             = _update
    member this.EarliestDate                       = _earliestDate
    member this.LatestDate                         = _latestDate
    member this.LatestRelevantDate                 = _latestRelevantDate
    member this.MaturityDate                       = _maturityDate
    member this.PillarDate                         = _pillarDate
    member this.Quote                              = _quote
    member this.QuoteError                         = _quoteError
    member this.QuoteIsValid                       = _quoteIsValid
    member this.QuoteValue                         = _quoteValue
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
