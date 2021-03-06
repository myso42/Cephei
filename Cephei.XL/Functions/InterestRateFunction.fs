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
namespace Cephei.XL

open ExcelDna.Integration
open Cephei.Cell
open Cephei.Cell.Generic
open Cephei.QL
open System.Collections
open System
open System.Linq
open QLNet
open Cephei.XL.Helper

(* <summary>
  This class encapsulate the interest rate compounding algebra. It manages day-counting conventions, compounding conventions, conversion between different conventions, discount/compound factor calculations, and implied/equivalent rate calculations.  Converted rates are checked against known good results
  </summary> *)
[<AutoSerializable(true)>]
module InterestRateFunction =

    (*
        ! returns the compound (a.k.a capitalization) factor implied by the rate compounded at time t.  \warning Time must be measured using InterestRate's own day counter.
    *)
    [<ExcelFunction(Name="_InterestRate_compoundFactor", Description="Create a InterestRate",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterestRate_compoundFactor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterestRate",Description = "InterestRate")>] 
         interestrate : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterestRate = Helper.toModelReference<InterestRate> interestrate "InterestRate"  
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = ((InterestRateModel.Cast _InterestRate.cell).CompoundFactor
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterestRate.source + ".CompoundFactor") 

                                               [| _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterestRate.cell
                                ;  _t.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! returns the compound (a.k.a capitalization) factor implied by the rate compounded between two dates.
    *)
    [<ExcelFunction(Name="_InterestRate_compoundFactor1", Description="Create a InterestRate",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterestRate_compoundFactor1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterestRate",Description = "InterestRate")>] 
         interestrate : obj)
        ([<ExcelArgument(Name="d1",Description = "Date")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Date")>] 
         d2 : obj)
        ([<ExcelArgument(Name="refStart",Description = "Date or empty")>] 
         refStart : obj)
        ([<ExcelArgument(Name="refEnd",Description = "Date or empty")>] 
         refEnd : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterestRate = Helper.toModelReference<InterestRate> interestrate "InterestRate"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let _refStart = Helper.toDefault<Date> refStart "refStart" null
                let _refEnd = Helper.toDefault<Date> refEnd "refEnd" null
                let builder (current : ICell) = ((InterestRateModel.Cast _InterestRate.cell).CompoundFactor1
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _refStart.cell 
                                                            _refEnd.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterestRate.source + ".CompoundFactor") 

                                               [| _d1.source
                                               ;  _d2.source
                                               ;  _refStart.source
                                               ;  _refEnd.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterestRate.cell
                                ;  _d1.cell
                                ;  _d2.cell
                                ;  _refStart.cell
                                ;  _refEnd.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterestRate_compounding", Description="Create a InterestRate",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterestRate_compounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterestRate",Description = "InterestRate")>] 
         interestrate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterestRate = Helper.toModelReference<InterestRate> interestrate "InterestRate"  
                let builder (current : ICell) = ((InterestRateModel.Cast _InterestRate.cell).Compounding
                                                       ) :> ICell
                let format (o : Compounding) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterestRate.source + ".Compounding") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterestRate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterestRate_dayCounter", Description="Create a InterestRate",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterestRate_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterestRate",Description = "InterestRate")>] 
         interestrate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterestRate = Helper.toModelReference<InterestRate> interestrate "InterestRate"  
                let builder (current : ICell) = ((InterestRateModel.Cast _InterestRate.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_InterestRate.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterestRate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterestRate> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! discount factor implied by the rate compounded between two dates
    *)
    [<ExcelFunction(Name="_InterestRate_discountFactor", Description="Create a InterestRate",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterestRate_discountFactor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterestRate",Description = "InterestRate")>] 
         interestrate : obj)
        ([<ExcelArgument(Name="d1",Description = "Date")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Date")>] 
         d2 : obj)
        ([<ExcelArgument(Name="refStart",Description = "InterestRate")>] 
         refStart : obj)
        ([<ExcelArgument(Name="refEnd",Description = "InterestRate")>] 
         refEnd : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterestRate = Helper.toModelReference<InterestRate> interestrate "InterestRate"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let _refStart = Helper.toDefault<Date> refStart "refStart" null
                let _refEnd = Helper.toDefault<Date> refEnd "refEnd" null
                let builder (current : ICell) = ((InterestRateModel.Cast _InterestRate.cell).DiscountFactor
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _refStart.cell 
                                                            _refEnd.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterestRate.source + ".DiscountFactor") 

                                               [| _d1.source
                                               ;  _d2.source
                                               ;  _refStart.source
                                               ;  _refEnd.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterestRate.cell
                                ;  _d1.cell
                                ;  _d2.cell
                                ;  _refStart.cell
                                ;  _refEnd.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! \warning Time must be measured using InterestRate's own day counter.
    *)
    [<ExcelFunction(Name="_InterestRate_discountFactor1", Description="Create a InterestRate",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterestRate_discountFactor1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterestRate",Description = "InterestRate")>] 
         interestrate : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterestRate = Helper.toModelReference<InterestRate> interestrate "InterestRate"  
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = ((InterestRateModel.Cast _InterestRate.cell).DiscountFactor1
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterestRate.source + ".DiscountFactor1") 

                                               [| _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterestRate.cell
                                ;  _t.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! The resulting rate is calculated taking the required day-counting rule into account.
    *)
    [<ExcelFunction(Name="_InterestRate_equivalentRate", Description="Create a InterestRate",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterestRate_equivalentRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterestRate",Description = "InterestRate")>] 
         interestrate : obj)
        ([<ExcelArgument(Name="resultDC",Description = "DayCounter")>] 
         resultDC : obj)
        ([<ExcelArgument(Name="comp",Description = "Compounding: Simple, Compounded, Continuous, SimpleThenCompounded")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         freq : obj)
        ([<ExcelArgument(Name="d1",Description = "Date")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Date")>] 
         d2 : obj)
        ([<ExcelArgument(Name="refStart",Description = "InterestRate")>] 
         refStart : obj)
        ([<ExcelArgument(Name="refEnd",Description = "InterestRate")>] 
         refEnd : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterestRate = Helper.toModelReference<InterestRate> interestrate "InterestRate"  
                let _resultDC = Helper.toCell<DayCounter> resultDC "resultDC" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let _refStart = Helper.toDefault<Date> refStart "refStart" null
                let _refEnd = Helper.toDefault<Date> refEnd "refEnd" null
                let builder (current : ICell) = ((InterestRateModel.Cast _InterestRate.cell).EquivalentRate
                                                            _resultDC.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _refStart.cell 
                                                            _refEnd.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRate>) l

                let source () = Helper.sourceFold (_InterestRate.source + ".EquivalentRate") 

                                               [| _resultDC.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _refStart.source
                                               ;  _refEnd.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterestRate.cell
                                ;  _resultDC.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _d1.cell
                                ;  _d2.cell
                                ;  _refStart.cell
                                ;  _refEnd.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterestRate> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! The resulting InterestRate shares the same implicit day-counting rule of the original InterestRate instance.  \warning Time must be measured using the InterestRate's own day counter.
    *)
    [<ExcelFunction(Name="_InterestRate_equivalentRate1", Description="Create a InterestRate",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterestRate_equivalentRate1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterestRate",Description = "InterestRate")>] 
         interestrate : obj)
        ([<ExcelArgument(Name="comp",Description = "Compounding: Simple, Compounded, Continuous, SimpleThenCompounded")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         freq : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterestRate = Helper.toModelReference<InterestRate> interestrate "InterestRate"  
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = ((InterestRateModel.Cast _InterestRate.cell).EquivalentRate1
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRate>) l

                let source () = Helper.sourceFold (_InterestRate.source + ".EquivalentRate") 

                                               [| _comp.source
                                               ;  _freq.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterestRate.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _t.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterestRate> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterestRate_frequency", Description="Create a InterestRate",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterestRate_frequency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterestRate",Description = "InterestRate")>] 
         interestrate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterestRate = Helper.toModelReference<InterestRate> interestrate "InterestRate"  
                let builder (current : ICell) = ((InterestRateModel.Cast _InterestRate.cell).Frequency
                                                       ) :> ICell
                let format (o : Frequency) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterestRate.source + ".Frequency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterestRate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! Standard constructor
    *)
    [<ExcelFunction(Name="_InterestRate", Description="Create a InterestRate",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterestRate_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="r",Description = "double")>] 
         r : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter")>] 
         dc : obj)
        ([<ExcelArgument(Name="comp",Description = "Compounding: Simple, Compounded, Continuous, SimpleThenCompounded")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         freq : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _r = Helper.toCell<double> r "r" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let builder (current : ICell) = (Fun.InterestRate 
                                                            _r.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRate>) l

                let source () = Helper.sourceFold "Fun.InterestRate" 
                                               [| _r.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               |]
                let hash = Helper.hashFold 
                                [| _r.cell
                                ;  _dc.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterestRate> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! Default constructor returning a null interest rate.
    *)
    [<ExcelFunction(Name="_InterestRate1", Description="Create a InterestRate",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterestRate_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = (Fun.InterestRate1 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRate>) l

                let source () = Helper.sourceFold "Fun.InterestRate1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterestRate> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterestRate_rate", Description="Create a InterestRate",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterestRate_rate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterestRate",Description = "InterestRate")>] 
         interestrate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterestRate = Helper.toModelReference<InterestRate> interestrate "InterestRate"  
                let builder (current : ICell) = ((InterestRateModel.Cast _InterestRate.cell).Rate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterestRate.source + ".Rate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterestRate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterestRate_ToString", Description="Create a InterestRate",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterestRate_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterestRate",Description = "InterestRate")>] 
         interestrate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterestRate = Helper.toModelReference<InterestRate> interestrate "InterestRate"  
                let builder (current : ICell) = ((InterestRateModel.Cast _InterestRate.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterestRate.source + ".ToString") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterestRate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterestRate_value", Description="Create a InterestRate",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterestRate_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterestRate",Description = "InterestRate")>] 
         interestrate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterestRate = Helper.toModelReference<InterestRate> interestrate "InterestRate"  
                let builder (current : ICell) = ((InterestRateModel.Cast _InterestRate.cell).Value
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterestRate.source + ".Value") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterestRate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_InterestRate_Range", Description="Create a range of InterestRate",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterestRate_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<InterestRate> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<InterestRate> (c)) :> ICell
                let format (i : Cephei.Cell.List<InterestRate>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<InterestRate>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
