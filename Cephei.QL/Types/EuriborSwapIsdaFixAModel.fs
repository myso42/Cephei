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
  %Euribor %Swap indexes fixed by ISDA in cooperation with Reuters and Intercapital Brokers at 11am Frankfurt. Annual 30/360 vs 6M Euribor, 1Y vs 3M Euribor. Reuters page ISDAFIX2 or EURSFIXA=.  Further info can be found at <http://www.isda.org/fix/isdafix.html> or Reuters page ISDAFIX.

  </summary> *)
[<AutoSerializable(true)>]
type EuriborSwapIsdaFixAModel
    ( tenor                                        : ICell<Period>
    ) as this =

    inherit Model<EuriborSwapIsdaFixA> ()
(*
    Parameters
*)
    let _tenor                                     = tenor
(*
    Functions
*)
    let mutable
        _EuriborSwapIsdaFixA                       = make (fun () -> new EuriborSwapIsdaFixA (tenor.Value))
    let _clone                                     (tenor : ICell<Period>)   
                                                   = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.clone(tenor.Value))
    let _clone1                                    (forwarding : ICell<Handle<YieldTermStructure>>) (discounting : ICell<Handle<YieldTermStructure>>)   
                                                   = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.clone(forwarding.Value, discounting.Value))
    let _clone2                                    (forwarding : ICell<Handle<YieldTermStructure>>)   
                                                   = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.clone(forwarding.Value))
    let _discountingTermStructure                  = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.discountingTermStructure())
    let _exogenousDiscount                         = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.exogenousDiscount())
    let _fixedLegConvention                        = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.fixedLegConvention())
    let _fixedLegTenor                             = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.fixedLegTenor())
    let _forecastFixing                            (fixingDate : ICell<Date>)   
                                                   = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.forecastFixing(fixingDate.Value))
    let _forwardingTermStructure                   = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.forwardingTermStructure())
    let _iborIndex                                 = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.iborIndex())
    let _maturityDate                              (valueDate : ICell<Date>)   
                                                   = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.maturityDate(valueDate.Value))
    let _underlyingSwap                            (fixingDate : ICell<Date>)   
                                                   = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.underlyingSwap(fixingDate.Value))
    let _currency                                  = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.currency())
    let _dayCounter                                = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.dayCounter())
    let _familyName                                = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.familyName())
    let _fixing                                    (fixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.fixing(fixingDate.Value, forecastTodaysFixing.Value))
    let _fixingCalendar                            = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.fixingCalendar())
    let _fixingDate                                (valueDate : ICell<Date>)   
                                                   = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.fixingDate(valueDate.Value))
    let _fixingDays                                = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.fixingDays())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.name())
    let _pastFixing                                (fixingDate : ICell<Date>)   
                                                   = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.pastFixing(fixingDate.Value))
    let _tenor                                     = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.tenor())
    let _update                                    = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.update()
                                                                                          _EuriborSwapIsdaFixA.Value)
    let _valueDate                                 (fixingDate : ICell<Date>)   
                                                   = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.valueDate(fixingDate.Value))
    let _addFixing                                 (d : ICell<Date>) (v : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.addFixing(d.Value, v.Value, forceOverwrite.Value)
                                                                                          _EuriborSwapIsdaFixA.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                                          _EuriborSwapIsdaFixA.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                                          _EuriborSwapIsdaFixA.Value)
    let _allowsNativeFixings                       = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.allowsNativeFixings())
    let _clearFixings                              = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.clearFixings()
                                                                                          _EuriborSwapIsdaFixA.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.registerWith(handler.Value)
                                                                                          _EuriborSwapIsdaFixA.Value)
    let _timeSeries                                = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.unregisterWith(handler.Value)
                                                                                          _EuriborSwapIsdaFixA.Value)
    do this.Bind(_EuriborSwapIsdaFixA)
(* 
    casting 
*)
    internal new () = new EuriborSwapIsdaFixAModel(null)
    member internal this.Inject v = _EuriborSwapIsdaFixA <- v
    static member Cast (p : ICell<EuriborSwapIsdaFixA>) = 
        if p :? EuriborSwapIsdaFixAModel then 
            p :?> EuriborSwapIsdaFixAModel
        else
            let o = new EuriborSwapIsdaFixAModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.tenor                              = _tenor 
    member this.Clone                              tenor   
                                                   = _clone tenor 
    member this.Clone1                             forwarding discounting   
                                                   = _clone1 forwarding discounting 
    member this.Clone2                             forwarding   
                                                   = _clone2 forwarding 
    member this.DiscountingTermStructure           = _discountingTermStructure
    member this.ExogenousDiscount                  = _exogenousDiscount
    member this.FixedLegConvention                 = _fixedLegConvention
    member this.FixedLegTenor                      = _fixedLegTenor
    member this.ForecastFixing                     fixingDate   
                                                   = _forecastFixing fixingDate 
    member this.ForwardingTermStructure            = _forwardingTermStructure
    member this.IborIndex                          = _iborIndex
    member this.MaturityDate                       valueDate   
                                                   = _maturityDate valueDate 
    member this.UnderlyingSwap                     fixingDate   
                                                   = _underlyingSwap fixingDate 
    member this.Currency                           = _currency
    member this.DayCounter                         = _dayCounter
    member this.FamilyName                         = _familyName
    member this.Fixing                             fixingDate forecastTodaysFixing   
                                                   = _fixing fixingDate forecastTodaysFixing 
    member this.FixingCalendar                     = _fixingCalendar
    member this.FixingDate                         valueDate   
                                                   = _fixingDate valueDate 
    member this.FixingDays                         = _fixingDays
    member this.IsValidFixingDate                  fixingDate   
                                                   = _isValidFixingDate fixingDate 
    member this.Name                               = _name
    member this.PastFixing                         fixingDate   
                                                   = _pastFixing fixingDate 
    member this.Tenor                              = _tenor
    member this.Update                             = _update
    member this.ValueDate                          fixingDate   
                                                   = _valueDate fixingDate 
    member this.AddFixing                          d v forceOverwrite   
                                                   = _addFixing d v forceOverwrite 
    member this.AddFixings                         d v forceOverwrite   
                                                   = _addFixings d v forceOverwrite 
    member this.AddFixings1                        source forceOverwrite   
                                                   = _addFixings1 source forceOverwrite 
    member this.AllowsNativeFixings                = _allowsNativeFixings
    member this.ClearFixings                       = _clearFixings
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.TimeSeries                         = _timeSeries
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
(* <summary>
  %Euribor %Swap indexes fixed by ISDA in cooperation with Reuters and Intercapital Brokers at 11am Frankfurt. Annual 30/360 vs 6M Euribor, 1Y vs 3M Euribor. Reuters page ISDAFIX2 or EURSFIXA=.  Further info can be found at <http://www.isda.org/fix/isdafix.html> or Reuters page ISDAFIX.

  </summary> *)
[<AutoSerializable(true)>]
type EuriborSwapIsdaFixAModel1
    ( tenor                                        : ICell<Period>
    , h                                            : ICell<Handle<YieldTermStructure>>
    ) as this =

    inherit Model<EuriborSwapIsdaFixA> ()
(*
    Parameters
*)
    let _tenor                                     = tenor
    let _h                                         = h
(*
    Functions
*)
    let mutable
        _EuriborSwapIsdaFixA                       = make (fun () -> new EuriborSwapIsdaFixA (tenor.Value, h.Value))
    let _clone                                     (tenor : ICell<Period>)   
                                                   = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.clone(tenor.Value))
    let _clone1                                    (forwarding : ICell<Handle<YieldTermStructure>>) (discounting : ICell<Handle<YieldTermStructure>>)   
                                                   = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.clone(forwarding.Value, discounting.Value))
    let _clone2                                    (forwarding : ICell<Handle<YieldTermStructure>>)   
                                                   = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.clone(forwarding.Value))
    let _discountingTermStructure                  = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.discountingTermStructure())
    let _exogenousDiscount                         = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.exogenousDiscount())
    let _fixedLegConvention                        = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.fixedLegConvention())
    let _fixedLegTenor                             = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.fixedLegTenor())
    let _forecastFixing                            (fixingDate : ICell<Date>)   
                                                   = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.forecastFixing(fixingDate.Value))
    let _forwardingTermStructure                   = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.forwardingTermStructure())
    let _iborIndex                                 = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.iborIndex())
    let _maturityDate                              (valueDate : ICell<Date>)   
                                                   = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.maturityDate(valueDate.Value))
    let _underlyingSwap                            (fixingDate : ICell<Date>)   
                                                   = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.underlyingSwap(fixingDate.Value))
    let _currency                                  = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.currency())
    let _dayCounter                                = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.dayCounter())
    let _familyName                                = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.familyName())
    let _fixing                                    (fixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.fixing(fixingDate.Value, forecastTodaysFixing.Value))
    let _fixingCalendar                            = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.fixingCalendar())
    let _fixingDate                                (valueDate : ICell<Date>)   
                                                   = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.fixingDate(valueDate.Value))
    let _fixingDays                                = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.fixingDays())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.name())
    let _pastFixing                                (fixingDate : ICell<Date>)   
                                                   = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.pastFixing(fixingDate.Value))
    let _tenor                                     = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.tenor())
    let _update                                    = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.update()
                                                                                          _EuriborSwapIsdaFixA.Value)
    let _valueDate                                 (fixingDate : ICell<Date>)   
                                                   = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.valueDate(fixingDate.Value))
    let _addFixing                                 (d : ICell<Date>) (v : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.addFixing(d.Value, v.Value, forceOverwrite.Value)
                                                                                          _EuriborSwapIsdaFixA.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                                          _EuriborSwapIsdaFixA.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                                          _EuriborSwapIsdaFixA.Value)
    let _allowsNativeFixings                       = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.allowsNativeFixings())
    let _clearFixings                              = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.clearFixings()
                                                                                          _EuriborSwapIsdaFixA.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.registerWith(handler.Value)
                                                                                          _EuriborSwapIsdaFixA.Value)
    let _timeSeries                                = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.unregisterWith(handler.Value)
                                                                                          _EuriborSwapIsdaFixA.Value)
    do this.Bind(_EuriborSwapIsdaFixA)
(* 
    casting 
*)
    internal new () = new EuriborSwapIsdaFixAModel1(null,null)
    member internal this.Inject v = _EuriborSwapIsdaFixA <- v
    static member Cast (p : ICell<EuriborSwapIsdaFixA>) = 
        if p :? EuriborSwapIsdaFixAModel1 then 
            p :?> EuriborSwapIsdaFixAModel1
        else
            let o = new EuriborSwapIsdaFixAModel1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.tenor                              = _tenor 
    member this.h                                  = _h 
    member this.Clone                              tenor   
                                                   = _clone tenor 
    member this.Clone1                             forwarding discounting   
                                                   = _clone1 forwarding discounting 
    member this.Clone2                             forwarding   
                                                   = _clone2 forwarding 
    member this.DiscountingTermStructure           = _discountingTermStructure
    member this.ExogenousDiscount                  = _exogenousDiscount
    member this.FixedLegConvention                 = _fixedLegConvention
    member this.FixedLegTenor                      = _fixedLegTenor
    member this.ForecastFixing                     fixingDate   
                                                   = _forecastFixing fixingDate 
    member this.ForwardingTermStructure            = _forwardingTermStructure
    member this.IborIndex                          = _iborIndex
    member this.MaturityDate                       valueDate   
                                                   = _maturityDate valueDate 
    member this.UnderlyingSwap                     fixingDate   
                                                   = _underlyingSwap fixingDate 
    member this.Currency                           = _currency
    member this.DayCounter                         = _dayCounter
    member this.FamilyName                         = _familyName
    member this.Fixing                             fixingDate forecastTodaysFixing   
                                                   = _fixing fixingDate forecastTodaysFixing 
    member this.FixingCalendar                     = _fixingCalendar
    member this.FixingDate                         valueDate   
                                                   = _fixingDate valueDate 
    member this.FixingDays                         = _fixingDays
    member this.IsValidFixingDate                  fixingDate   
                                                   = _isValidFixingDate fixingDate 
    member this.Name                               = _name
    member this.PastFixing                         fixingDate   
                                                   = _pastFixing fixingDate 
    member this.Tenor                              = _tenor
    member this.Update                             = _update
    member this.ValueDate                          fixingDate   
                                                   = _valueDate fixingDate 
    member this.AddFixing                          d v forceOverwrite   
                                                   = _addFixing d v forceOverwrite 
    member this.AddFixings                         d v forceOverwrite   
                                                   = _addFixings d v forceOverwrite 
    member this.AddFixings1                        source forceOverwrite   
                                                   = _addFixings1 source forceOverwrite 
    member this.AllowsNativeFixings                = _allowsNativeFixings
    member this.ClearFixings                       = _clearFixings
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.TimeSeries                         = _timeSeries
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
(* <summary>
  %Euribor %Swap indexes fixed by ISDA in cooperation with Reuters and Intercapital Brokers at 11am Frankfurt. Annual 30/360 vs 6M Euribor, 1Y vs 3M Euribor. Reuters page ISDAFIX2 or EURSFIXA=.  Further info can be found at <http://www.isda.org/fix/isdafix.html> or Reuters page ISDAFIX.

  </summary> *)
[<AutoSerializable(true)>]
type EuriborSwapIsdaFixAModel2
    ( tenor                                        : ICell<Period>
    , forwarding                                   : ICell<Handle<YieldTermStructure>>
    , discounting                                  : ICell<Handle<YieldTermStructure>>
    ) as this =

    inherit Model<EuriborSwapIsdaFixA> ()
(*
    Parameters
*)
    let _tenor                                     = tenor
    let _forwarding                                = forwarding
    let _discounting                               = discounting
(*
    Functions
*)
    let mutable
        _EuriborSwapIsdaFixA                       = make (fun () -> new EuriborSwapIsdaFixA (tenor.Value, forwarding.Value, discounting.Value))
    let _clone                                     (tenor : ICell<Period>)   
                                                   = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.clone(tenor.Value))
    let _clone1                                    (forwarding : ICell<Handle<YieldTermStructure>>) (discounting : ICell<Handle<YieldTermStructure>>)   
                                                   = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.clone(forwarding.Value, discounting.Value))
    let _clone2                                    (forwarding : ICell<Handle<YieldTermStructure>>)   
                                                   = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.clone(forwarding.Value))
    let _discountingTermStructure                  = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.discountingTermStructure())
    let _exogenousDiscount                         = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.exogenousDiscount())
    let _fixedLegConvention                        = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.fixedLegConvention())
    let _fixedLegTenor                             = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.fixedLegTenor())
    let _forecastFixing                            (fixingDate : ICell<Date>)   
                                                   = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.forecastFixing(fixingDate.Value))
    let _forwardingTermStructure                   = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.forwardingTermStructure())
    let _iborIndex                                 = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.iborIndex())
    let _maturityDate                              (valueDate : ICell<Date>)   
                                                   = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.maturityDate(valueDate.Value))
    let _underlyingSwap                            (fixingDate : ICell<Date>)   
                                                   = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.underlyingSwap(fixingDate.Value))
    let _currency                                  = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.currency())
    let _dayCounter                                = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.dayCounter())
    let _familyName                                = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.familyName())
    let _fixing                                    (fixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.fixing(fixingDate.Value, forecastTodaysFixing.Value))
    let _fixingCalendar                            = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.fixingCalendar())
    let _fixingDate                                (valueDate : ICell<Date>)   
                                                   = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.fixingDate(valueDate.Value))
    let _fixingDays                                = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.fixingDays())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.name())
    let _pastFixing                                (fixingDate : ICell<Date>)   
                                                   = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.pastFixing(fixingDate.Value))
    let _tenor                                     = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.tenor())
    let _update                                    = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.update()
                                                                                          _EuriborSwapIsdaFixA.Value)
    let _valueDate                                 (fixingDate : ICell<Date>)   
                                                   = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.valueDate(fixingDate.Value))
    let _addFixing                                 (d : ICell<Date>) (v : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.addFixing(d.Value, v.Value, forceOverwrite.Value)
                                                                                          _EuriborSwapIsdaFixA.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                                          _EuriborSwapIsdaFixA.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                                          _EuriborSwapIsdaFixA.Value)
    let _allowsNativeFixings                       = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.allowsNativeFixings())
    let _clearFixings                              = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.clearFixings()
                                                                                          _EuriborSwapIsdaFixA.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.registerWith(handler.Value)
                                                                                          _EuriborSwapIsdaFixA.Value)
    let _timeSeries                                = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _EuriborSwapIsdaFixA (fun () -> _EuriborSwapIsdaFixA.Value.unregisterWith(handler.Value)
                                                                                          _EuriborSwapIsdaFixA.Value)
    do this.Bind(_EuriborSwapIsdaFixA)
(* 
    casting 
*)
    internal new () = new EuriborSwapIsdaFixAModel2(null,null,null)
    member internal this.Inject v = _EuriborSwapIsdaFixA <- v
    static member Cast (p : ICell<EuriborSwapIsdaFixA>) = 
        if p :? EuriborSwapIsdaFixAModel2 then 
            p :?> EuriborSwapIsdaFixAModel2
        else
            let o = new EuriborSwapIsdaFixAModel2 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.tenor                              = _tenor 
    member this.forwarding                         = _forwarding 
    member this.discounting                        = _discounting 
    member this.Clone                              tenor   
                                                   = _clone tenor 
    member this.Clone1                             forwarding discounting   
                                                   = _clone1 forwarding discounting 
    member this.Clone2                             forwarding   
                                                   = _clone2 forwarding 
    member this.DiscountingTermStructure           = _discountingTermStructure
    member this.ExogenousDiscount                  = _exogenousDiscount
    member this.FixedLegConvention                 = _fixedLegConvention
    member this.FixedLegTenor                      = _fixedLegTenor
    member this.ForecastFixing                     fixingDate   
                                                   = _forecastFixing fixingDate 
    member this.ForwardingTermStructure            = _forwardingTermStructure
    member this.IborIndex                          = _iborIndex
    member this.MaturityDate                       valueDate   
                                                   = _maturityDate valueDate 
    member this.UnderlyingSwap                     fixingDate   
                                                   = _underlyingSwap fixingDate 
    member this.Currency                           = _currency
    member this.DayCounter                         = _dayCounter
    member this.FamilyName                         = _familyName
    member this.Fixing                             fixingDate forecastTodaysFixing   
                                                   = _fixing fixingDate forecastTodaysFixing 
    member this.FixingCalendar                     = _fixingCalendar
    member this.FixingDate                         valueDate   
                                                   = _fixingDate valueDate 
    member this.FixingDays                         = _fixingDays
    member this.IsValidFixingDate                  fixingDate   
                                                   = _isValidFixingDate fixingDate 
    member this.Name                               = _name
    member this.PastFixing                         fixingDate   
                                                   = _pastFixing fixingDate 
    member this.Tenor                              = _tenor
    member this.Update                             = _update
    member this.ValueDate                          fixingDate   
                                                   = _valueDate fixingDate 
    member this.AddFixing                          d v forceOverwrite   
                                                   = _addFixing d v forceOverwrite 
    member this.AddFixings                         d v forceOverwrite   
                                                   = _addFixings d v forceOverwrite 
    member this.AddFixings1                        source forceOverwrite   
                                                   = _addFixings1 source forceOverwrite 
    member this.AllowsNativeFixings                = _allowsNativeFixings
    member this.ClearFixings                       = _clearFixings
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.TimeSeries                         = _timeSeries
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
