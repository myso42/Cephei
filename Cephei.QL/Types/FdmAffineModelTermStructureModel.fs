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
type FdmAffineModelTermStructureModel
    ( r                                            : ICell<Vector>
    , cal                                          : ICell<Calendar>
    , dayCounter                                   : ICell<DayCounter>
    , referenceDate                                : ICell<Date>
    , modelReferenceDate                           : ICell<Date>
    , model                                        : ICell<IAffineModel>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<FdmAffineModelTermStructure> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _r                                         = r
    let _cal                                       = cal
    let _dayCounter                                = dayCounter
    let _referenceDate                             = referenceDate
    let _modelReferenceDate                        = modelReferenceDate
    let _model                                     = model
(*
    Functions
*)
    let mutable
        _FdmAffineModelTermStructure               = make (fun () -> (createEvaluationDate _evaluationDate (fun () ->new FdmAffineModelTermStructure (r.Value, cal.Value, dayCounter.Value, referenceDate.Value, modelReferenceDate.Value, model.Value))))
    let _maxDate                                   = triv _FdmAffineModelTermStructure (fun () -> (curryEvaluationDate _evaluationDate _FdmAffineModelTermStructure).Value.maxDate())
    let _setVariable                               (r : ICell<Vector>)   
                                                   = triv _FdmAffineModelTermStructure (fun () -> (curryEvaluationDate _evaluationDate _FdmAffineModelTermStructure).Value.setVariable(r.Value)
                                                                                                  _FdmAffineModelTermStructure.Value)
    let _discount                                  (t : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv _FdmAffineModelTermStructure (fun () -> (curryEvaluationDate _evaluationDate _FdmAffineModelTermStructure).Value.discount(t.Value, extrapolate.Value))
    let _discount1                                 (d : ICell<Date>) (extrapolate : ICell<bool>)   
                                                   = triv _FdmAffineModelTermStructure (fun () -> (curryEvaluationDate _evaluationDate _FdmAffineModelTermStructure).Value.discount(d.Value, extrapolate.Value))
    let _forwardRate                               (d : ICell<Date>) (p : ICell<Period>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv _FdmAffineModelTermStructure (fun () -> (curryEvaluationDate _evaluationDate _FdmAffineModelTermStructure).Value.forwardRate(d.Value, p.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _forwardRate1                              (d1 : ICell<Date>) (d2 : ICell<Date>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv _FdmAffineModelTermStructure (fun () -> (curryEvaluationDate _evaluationDate _FdmAffineModelTermStructure).Value.forwardRate(d1.Value, d2.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _forwardRate2                              (t1 : ICell<double>) (t2 : ICell<double>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv _FdmAffineModelTermStructure (fun () -> (curryEvaluationDate _evaluationDate _FdmAffineModelTermStructure).Value.forwardRate(t1.Value, t2.Value, comp.Value, freq.Value, extrapolate.Value))
    let _jumpDates                                 = triv _FdmAffineModelTermStructure (fun () -> (curryEvaluationDate _evaluationDate _FdmAffineModelTermStructure).Value.jumpDates())
    let _jumpTimes                                 = triv _FdmAffineModelTermStructure (fun () -> (curryEvaluationDate _evaluationDate _FdmAffineModelTermStructure).Value.jumpTimes())
    let _update                                    = triv _FdmAffineModelTermStructure (fun () -> (curryEvaluationDate _evaluationDate _FdmAffineModelTermStructure).Value.update()
                                                                                                  _FdmAffineModelTermStructure.Value)
    let _zeroRate                                  (t : ICell<double>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv _FdmAffineModelTermStructure (fun () -> (curryEvaluationDate _evaluationDate _FdmAffineModelTermStructure).Value.zeroRate(t.Value, comp.Value, freq.Value, extrapolate.Value))
    let _zeroRate1                                 (d : ICell<Date>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv _FdmAffineModelTermStructure (fun () -> (curryEvaluationDate _evaluationDate _FdmAffineModelTermStructure).Value.zeroRate(d.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _calendar                                  = triv _FdmAffineModelTermStructure (fun () -> (curryEvaluationDate _evaluationDate _FdmAffineModelTermStructure).Value.calendar())
    let _dayCounter                                = triv _FdmAffineModelTermStructure (fun () -> (curryEvaluationDate _evaluationDate _FdmAffineModelTermStructure).Value.dayCounter())
    let _maxTime                                   = triv _FdmAffineModelTermStructure (fun () -> (curryEvaluationDate _evaluationDate _FdmAffineModelTermStructure).Value.maxTime())
    let _referenceDate                             = triv _FdmAffineModelTermStructure (fun () -> (curryEvaluationDate _evaluationDate _FdmAffineModelTermStructure).Value.referenceDate())
    let _settlementDays                            = triv _FdmAffineModelTermStructure (fun () -> (curryEvaluationDate _evaluationDate _FdmAffineModelTermStructure).Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv _FdmAffineModelTermStructure (fun () -> (curryEvaluationDate _evaluationDate _FdmAffineModelTermStructure).Value.timeFromReference(date.Value))
    let _allowsExtrapolation                       = triv _FdmAffineModelTermStructure (fun () -> (curryEvaluationDate _evaluationDate _FdmAffineModelTermStructure).Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv _FdmAffineModelTermStructure (fun () -> (curryEvaluationDate _evaluationDate _FdmAffineModelTermStructure).Value.disableExtrapolation(b.Value)
                                                                                                  _FdmAffineModelTermStructure.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv _FdmAffineModelTermStructure (fun () -> (curryEvaluationDate _evaluationDate _FdmAffineModelTermStructure).Value.enableExtrapolation(b.Value)
                                                                                                  _FdmAffineModelTermStructure.Value)
    let _extrapolate                               = triv _FdmAffineModelTermStructure (fun () -> (curryEvaluationDate _evaluationDate _FdmAffineModelTermStructure).Value.extrapolate)
    do this.Bind(_FdmAffineModelTermStructure)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new FdmAffineModelTermStructureModel(null,null,null,null,null,null,null)
    member internal this.Inject v = _FdmAffineModelTermStructure <- v
    static member Cast (p : ICell<FdmAffineModelTermStructure>) = 
        if p :? FdmAffineModelTermStructureModel then 
            p :?> FdmAffineModelTermStructureModel
        else
            let o = new FdmAffineModelTermStructureModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.r                                  = _r 
    member this.cal                                = _cal 
    member this.dayCounter                         = _dayCounter 
    member this.referenceDate                      = _referenceDate 
    member this.modelReferenceDate                 = _modelReferenceDate 
    member this.model                              = _model 
    member this.MaxDate                            = _maxDate
    member this.SetVariable                        r   
                                                   = _setVariable r 
    member this.Discount                           t extrapolate   
                                                   = _discount t extrapolate 
    member this.Discount1                          d extrapolate   
                                                   = _discount1 d extrapolate 
    member this.ForwardRate                        d p dayCounter comp freq extrapolate   
                                                   = _forwardRate d p dayCounter comp freq extrapolate 
    member this.ForwardRate1                       d1 d2 dayCounter comp freq extrapolate   
                                                   = _forwardRate1 d1 d2 dayCounter comp freq extrapolate 
    member this.ForwardRate2                       t1 t2 comp freq extrapolate   
                                                   = _forwardRate2 t1 t2 comp freq extrapolate 
    member this.JumpDates                          = _jumpDates
    member this.JumpTimes                          = _jumpTimes
    member this.Update                             = _update
    member this.ZeroRate                           t comp freq extrapolate   
                                                   = _zeroRate t comp freq extrapolate 
    member this.ZeroRate1                          d dayCounter comp freq extrapolate   
                                                   = _zeroRate1 d dayCounter comp freq extrapolate 
    member this.Calendar                           = _calendar
    member this.DayCounter                         = _dayCounter
    member this.MaxTime                            = _maxTime
    member this.ReferenceDate                      = _referenceDate
    member this.SettlementDays                     = _settlementDays
    member this.TimeFromReference                  date   
                                                   = _timeFromReference date 
    member this.AllowsExtrapolation                = _allowsExtrapolation
    member this.DisableExtrapolation               b   
                                                   = _disableExtrapolation b 
    member this.EnableExtrapolation                b   
                                                   = _enableExtrapolation b 
    member this.Extrapolate                        = _extrapolate
