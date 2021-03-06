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
  Most methods inherited from Bond (such as yield or the yield-based dirtyPrice and cleanPrice) refer to the underlying plain-vanilla bond and do not take convertibility and callability into account.
  </summary> *)
[<AutoSerializable(true)>]
module ConvertibleZeroCouponBondFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="exercise",Description = "Exercise")>] 
         exercise : obj)
        ([<ExcelArgument(Name="conversionRatio",Description = "double")>] 
         conversionRatio : obj)
        ([<ExcelArgument(Name="dividends",Description = "DividendSchedule")>] 
         dividends : obj)
        ([<ExcelArgument(Name="callability",Description = "CallabilitySchedule")>] 
         callability : obj)
        ([<ExcelArgument(Name="creditSpread",Description = "Quote")>] 
         creditSpread : obj)
        ([<ExcelArgument(Name="issueDate",Description = "Date")>] 
         issueDate : obj)
        ([<ExcelArgument(Name="settlementDays",Description = "int")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="schedule",Description = "Schedule")>] 
         schedule : obj)
        ([<ExcelArgument(Name="redemption",Description = "double or empty")>] 
         redemption : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "IPricingEngine")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _exercise = Helper.toCell<Exercise> exercise "exercise" 
                let _conversionRatio = Helper.toCell<double> conversionRatio "conversionRatio" 
                let _dividends = Helper.toCell<DividendSchedule> dividends "dividends" 
                let _callability = Helper.toCell<CallabilitySchedule> callability "callability" 
                let _creditSpread = Helper.toHandle<Quote> creditSpread "creditSpread" 
                let _issueDate = Helper.toCell<Date> issueDate "issueDate" 
                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _schedule = Helper.toCell<Schedule> schedule "schedule" 
                let _redemption = Helper.toDefault<double> redemption "redemption" 100.0
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = (Fun.ConvertibleZeroCouponBond 
                                                            _exercise.cell 
                                                            _conversionRatio.cell 
                                                            _dividends.cell 
                                                            _callability.cell 
                                                            _creditSpread.cell 
                                                            _issueDate.cell 
                                                            _settlementDays.cell 
                                                            _dayCounter.cell 
                                                            _schedule.cell 
                                                            _redemption.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ConvertibleZeroCouponBond>) l

                let source () = Helper.sourceFold "Fun.ConvertibleZeroCouponBond" 
                                               [| _exercise.source
                                               ;  _conversionRatio.source
                                               ;  _dividends.source
                                               ;  _callability.source
                                               ;  _creditSpread.source
                                               ;  _issueDate.source
                                               ;  _settlementDays.source
                                               ;  _dayCounter.source
                                               ;  _schedule.source
                                               ;  _redemption.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _exercise.cell
                                ;  _conversionRatio.cell
                                ;  _dividends.cell
                                ;  _callability.cell
                                ;  _creditSpread.cell
                                ;  _issueDate.cell
                                ;  _settlementDays.cell
                                ;  _dayCounter.cell
                                ;  _schedule.cell
                                ;  _redemption.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConvertibleZeroCouponBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_callability", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_callability
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toModelReference<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let builder (current : ICell) = ((ConvertibleZeroCouponBondModel.Cast _ConvertibleZeroCouponBond.cell).Callability
                                                       ) :> ICell
                let format (o : CallabilitySchedule) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".Callability") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_conversionRatio", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_conversionRatio
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toModelReference<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let builder (current : ICell) = ((ConvertibleZeroCouponBondModel.Cast _ConvertibleZeroCouponBond.cell).ConversionRatio
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".ConversionRatio") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_creditSpread", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_creditSpread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toModelReference<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let builder (current : ICell) = ((ConvertibleZeroCouponBondModel.Cast _ConvertibleZeroCouponBond.cell).CreditSpread
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<Quote>>) l

                let source () = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".CreditSpread") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConvertibleZeroCouponBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_dividends", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_dividends
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toModelReference<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let builder (current : ICell) = ((ConvertibleZeroCouponBondModel.Cast _ConvertibleZeroCouponBond.cell).Dividends
                                                       ) :> ICell
                let format (o : DividendSchedule) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".Dividends") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
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
        ! The default bond settlement is used if no date is given.
    *)
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_accruedAmount", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toModelReference<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = ((ConvertibleZeroCouponBondModel.Cast _ConvertibleZeroCouponBond.cell).AccruedAmount
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".AccruedAmount") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
                                ;  _settlement.cell
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
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_calendar", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toModelReference<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let builder (current : ICell) = ((ConvertibleZeroCouponBondModel.Cast _ConvertibleZeroCouponBond.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".Calendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConvertibleZeroCouponBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        \note returns all the cashflows, including the redemptions.
    *)
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_cashflows", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_cashflows
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toModelReference<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let builder (current : ICell) = ((ConvertibleZeroCouponBondModel.Cast _ConvertibleZeroCouponBond.cell).Cashflows
                                                       ) :> ICell
                let format (i : Generic.List<CashFlow>) (l : string) = Helper.Range.fromList i l

                let source () = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".Cashflows") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! The default bond settlement is used for calculation.  \warning the theoretical price calculated from a flat term structure might differ slightly from the price calculated from the corresponding yield by means of the other overload of this function. If the price from a constant yield is desired, it is advisable to use such other overload.
    *)
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_cleanPrice", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_cleanPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toModelReference<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let builder (current : ICell) = ((ConvertibleZeroCouponBondModel.Cast _ConvertibleZeroCouponBond.cell).CleanPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".CleanPrice") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
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
        ! The default bond settlement is used if no date is given.
    *)
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_cleanPrice1", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_cleanPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        ([<ExcelArgument(Name="Yield",Description = "double")>] 
         Yield : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter")>] 
         dc : obj)
        ([<ExcelArgument(Name="comp",Description = "Compounding: Simple, Compounded, Continuous, SimpleThenCompounded")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         freq : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toModelReference<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = ((ConvertibleZeroCouponBondModel.Cast _ConvertibleZeroCouponBond.cell).CleanPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".CleanPrice1") 

                                               [| _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
                                ;  _Yield.cell
                                ;  _dc.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _settlement.cell
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
        ! The default bond settlement is used if no date is given.
    *)
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_dirtyPrice1", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_dirtyPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        ([<ExcelArgument(Name="Yield",Description = "double")>] 
         Yield : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter")>] 
         dc : obj)
        ([<ExcelArgument(Name="comp",Description = "Compounding: Simple, Compounded, Continuous, SimpleThenCompounded")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         freq : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toModelReference<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = ((ConvertibleZeroCouponBondModel.Cast _ConvertibleZeroCouponBond.cell).DirtyPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".DirtyPrice1") 

                                               [| _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
                                ;  _Yield.cell
                                ;  _dc.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _settlement.cell
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
        ! The default bond settlement is used for calculation.  \warning the theoretical price calculated from a flat term structure might differ slightly from the price calculated from the corresponding yield by means of the other overload of this function. If the price from a constant yield is desired, it is advisable to use such other overload.
    *)
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_dirtyPrice", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_dirtyPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toModelReference<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let builder (current : ICell) = ((ConvertibleZeroCouponBondModel.Cast _ConvertibleZeroCouponBond.cell).DirtyPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".DirtyPrice") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_isExpired", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toModelReference<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let builder (current : ICell) = ((ConvertibleZeroCouponBondModel.Cast _ConvertibleZeroCouponBond.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".IsExpired") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_issueDate", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_issueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toModelReference<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let builder (current : ICell) = ((ConvertibleZeroCouponBondModel.Cast _ConvertibleZeroCouponBond.cell).IssueDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".IssueDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_isTradable", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_isTradable
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toModelReference<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = ((ConvertibleZeroCouponBondModel.Cast _ConvertibleZeroCouponBond.cell).IsTradable
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".IsTradable") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
                                ;  _d.cell
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
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_maturityDate", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toModelReference<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let builder (current : ICell) = ((ConvertibleZeroCouponBondModel.Cast _ConvertibleZeroCouponBond.cell).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".MaturityDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_nextCashFlowDate", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_nextCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toModelReference<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = ((ConvertibleZeroCouponBondModel.Cast _ConvertibleZeroCouponBond.cell).NextCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".NextCashFlowDate") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
                                ;  _settlement.cell
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
        ! Expected next coupon: depending on (the bond and) the given date the coupon can be historic, deterministic or expected in a stochastic sense. When the bond settlement date is used the coupon is the already-fixed not-yet-paid one.  The current bond settlement is used if no date is given.
    *)
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_nextCouponRate", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_nextCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toModelReference<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = ((ConvertibleZeroCouponBondModel.Cast _ConvertibleZeroCouponBond.cell).NextCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".NextCouponRate") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
                                ;  _settlement.cell
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
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_notional", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_notional
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toModelReference<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = ((ConvertibleZeroCouponBondModel.Cast _ConvertibleZeroCouponBond.cell).Notional
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".Notional") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
                                ;  _d.cell
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
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_notionals", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_notionals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toModelReference<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let builder (current : ICell) = ((ConvertibleZeroCouponBondModel.Cast _ConvertibleZeroCouponBond.cell).Notionals
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".Notionals") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_previousCashFlowDate", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_previousCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toModelReference<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = ((ConvertibleZeroCouponBondModel.Cast _ConvertibleZeroCouponBond.cell).PreviousCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".PreviousCashFlowDate") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
                                ;  _settlement.cell
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
        ! Expected previous coupon: depending on (the bond and) the given date the coupon can be historic, deterministic or expected in a stochastic sense. When the bond settlement date is used the coupon is the last paid one.  The current bond settlement is used if no date is given.
    *)
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_previousCouponRate", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_previousCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toModelReference<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = ((ConvertibleZeroCouponBondModel.Cast _ConvertibleZeroCouponBond.cell).PreviousCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".PreviousCouponRate") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
                                ;  _settlement.cell
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
        returns the redemption, if only one is defined
    *)
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_redemption", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_redemption
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toModelReference<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let builder (current : ICell) = ((ConvertibleZeroCouponBondModel.Cast _ConvertibleZeroCouponBond.cell).Redemption
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CashFlow>) l

                let source () = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".Redemption") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConvertibleZeroCouponBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! returns just the redemption flows (not interest payments)
    *)
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_redemptions", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_redemptions
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toModelReference<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let builder (current : ICell) = ((ConvertibleZeroCouponBondModel.Cast _ConvertibleZeroCouponBond.cell).Redemptions
                                                       ) :> ICell
                let format (i : Generic.List<CashFlow>) (l : string) = Helper.Range.fromList i l

                let source () = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".Redemptions") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_settlementDate", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_settlementDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        ([<ExcelArgument(Name="date",Description = "Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toModelReference<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let _date = Helper.toCell<Date> date "date" 
                let builder (current : ICell) = ((ConvertibleZeroCouponBondModel.Cast _ConvertibleZeroCouponBond.cell).SettlementDate
                                                            _date.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".SettlementDate") 

                                               [| _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
                                ;  _date.cell
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
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_settlementDays", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toModelReference<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let builder (current : ICell) = ((ConvertibleZeroCouponBondModel.Cast _ConvertibleZeroCouponBond.cell).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".SettlementDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_settlementValue", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_settlementValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        ([<ExcelArgument(Name="cleanPrice",Description = "double")>] 
         cleanPrice : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toModelReference<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let builder (current : ICell) = ((ConvertibleZeroCouponBondModel.Cast _ConvertibleZeroCouponBond.cell).SettlementValue
                                                            _cleanPrice.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".SettlementValue") 

                                               [| _cleanPrice.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
                                ;  _cleanPrice.cell
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
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_settlementValue1", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_settlementValue1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toModelReference<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let builder (current : ICell) = ((ConvertibleZeroCouponBondModel.Cast _ConvertibleZeroCouponBond.cell).SettlementValue1
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".SettlementValue1") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_startDate", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toModelReference<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let builder (current : ICell) = ((ConvertibleZeroCouponBondModel.Cast _ConvertibleZeroCouponBond.cell).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".StartDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
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
        ! The default bond settlement is used if no date is given.
    *)
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_yield1", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_yield1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        ([<ExcelArgument(Name="cleanPrice",Description = "double")>] 
         cleanPrice : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter")>] 
         dc : obj)
        ([<ExcelArgument(Name="comp",Description = "Compounding: Simple, Compounded, Continuous, SimpleThenCompounded")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         freq : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        ([<ExcelArgument(Name="accuracy",Description = "double")>] 
         accuracy : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "int")>] 
         maxEvaluations : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toModelReference<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder (current : ICell) = ((ConvertibleZeroCouponBondModel.Cast _ConvertibleZeroCouponBond.cell).Yield1
                                                            _cleanPrice.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".Yield1") 

                                               [| _cleanPrice.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
                                ;  _cleanPrice.cell
                                ;  _dc.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _settlement.cell
                                ;  _accuracy.cell
                                ;  _maxEvaluations.cell
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
        ! The default bond settlement and theoretical price are used for calculation.
    *)
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_yield", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_yield
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter")>] 
         dc : obj)
        ([<ExcelArgument(Name="comp",Description = "Compounding: Simple, Compounded, Continuous, SimpleThenCompounded")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         freq : obj)
        ([<ExcelArgument(Name="accuracy",Description = "double")>] 
         accuracy : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "int")>] 
         maxEvaluations : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toModelReference<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder (current : ICell) = ((ConvertibleZeroCouponBondModel.Cast _ConvertibleZeroCouponBond.cell).Yield
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".Yield") 

                                               [| _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
                                ;  _dc.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _accuracy.cell
                                ;  _maxEvaluations.cell
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
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_CASH", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toModelReference<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let builder (current : ICell) = ((ConvertibleZeroCouponBondModel.Cast _ConvertibleZeroCouponBond.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".CASH") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_errorEstimate", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toModelReference<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let builder (current : ICell) = ((ConvertibleZeroCouponBondModel.Cast _ConvertibleZeroCouponBond.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".ErrorEstimate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_NPV", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toModelReference<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let builder (current : ICell) = ((ConvertibleZeroCouponBondModel.Cast _ConvertibleZeroCouponBond.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".NPV") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
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
        returns any additional result returned by the pricing engine.
    *)
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_result", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        ([<ExcelArgument(Name="tag",Description = "string")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toModelReference<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder (current : ICell) = ((ConvertibleZeroCouponBondModel.Cast _ConvertibleZeroCouponBond.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".Result") 

                                               [| _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
                                ;  _tag.cell
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
        ! calling this method will have no effects in case the performCalculation method was overridden in a derived class.
    *)
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_setPricingEngine", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        ([<ExcelArgument(Name="e",Description = "IPricingEngine")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toModelReference<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder (current : ICell) = ((ConvertibleZeroCouponBondModel.Cast _ConvertibleZeroCouponBond.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : ConvertibleZeroCouponBond) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".SetPricingEngine") 

                                               [| _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
                                ;  _e.cell
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
        ! returns the date the net present value refers to.
    *)
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_valuationDate", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toModelReference<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let builder (current : ICell) = ((ConvertibleZeroCouponBondModel.Cast _ConvertibleZeroCouponBond.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".ValuationDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_Range", Description="Create a range of ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ConvertibleZeroCouponBond> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<ConvertibleZeroCouponBond> (c)) :> ICell
                let format (i : Cephei.Cell.List<ConvertibleZeroCouponBond>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<ConvertibleZeroCouponBond>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
