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
module ConvertibleFloatingRateBondFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_create
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
        ([<ExcelArgument(Name="index",Description = "IborIndex")>] 
         index : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "int")>] 
         fixingDays : obj)
        ([<ExcelArgument(Name="spreads",Description = "double range")>] 
         spreads : obj)
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
                let _index = Helper.toCell<IborIndex> index "index" 
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" 
                let _spreads = Helper.toCell<Generic.List<double>> spreads "spreads" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _schedule = Helper.toCell<Schedule> schedule "schedule" 
                let _redemption = Helper.toDefault<double> redemption "redemption" 100.0
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = (Fun.ConvertibleFloatingRateBond 
                                                            _exercise.cell 
                                                            _conversionRatio.cell 
                                                            _dividends.cell 
                                                            _callability.cell 
                                                            _creditSpread.cell 
                                                            _issueDate.cell 
                                                            _settlementDays.cell 
                                                            _index.cell 
                                                            _fixingDays.cell 
                                                            _spreads.cell 
                                                            _dayCounter.cell 
                                                            _schedule.cell 
                                                            _redemption.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ConvertibleFloatingRateBond>) l

                let source () = Helper.sourceFold "Fun.ConvertibleFloatingRateBond" 
                                               [| _exercise.source
                                               ;  _conversionRatio.source
                                               ;  _dividends.source
                                               ;  _callability.source
                                               ;  _creditSpread.source
                                               ;  _issueDate.source
                                               ;  _settlementDays.source
                                               ;  _index.source
                                               ;  _fixingDays.source
                                               ;  _spreads.source
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
                                ;  _index.cell
                                ;  _fixingDays.cell
                                ;  _spreads.cell
                                ;  _dayCounter.cell
                                ;  _schedule.cell
                                ;  _redemption.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConvertibleFloatingRateBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_callability", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_callability
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toModelReference<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let builder (current : ICell) = ((ConvertibleFloatingRateBondModel.Cast _ConvertibleFloatingRateBond.cell).Callability
                                                       ) :> ICell
                let format (o : CallabilitySchedule) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".Callability") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_conversionRatio", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_conversionRatio
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toModelReference<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let builder (current : ICell) = ((ConvertibleFloatingRateBondModel.Cast _ConvertibleFloatingRateBond.cell).ConversionRatio
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".ConversionRatio") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_creditSpread", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_creditSpread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toModelReference<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let builder (current : ICell) = ((ConvertibleFloatingRateBondModel.Cast _ConvertibleFloatingRateBond.cell).CreditSpread
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<Quote>>) l

                let source () = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".CreditSpread") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConvertibleFloatingRateBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_dividends", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_dividends
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toModelReference<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let builder (current : ICell) = ((ConvertibleFloatingRateBondModel.Cast _ConvertibleFloatingRateBond.cell).Dividends
                                                       ) :> ICell
                let format (o : DividendSchedule) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".Dividends") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_accruedAmount", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toModelReference<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = ((ConvertibleFloatingRateBondModel.Cast _ConvertibleFloatingRateBond.cell).AccruedAmount
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".AccruedAmount") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_calendar", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toModelReference<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let builder (current : ICell) = ((ConvertibleFloatingRateBondModel.Cast _ConvertibleFloatingRateBond.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".Calendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConvertibleFloatingRateBond> format
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_cashflows", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_cashflows
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toModelReference<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let builder (current : ICell) = ((ConvertibleFloatingRateBondModel.Cast _ConvertibleFloatingRateBond.cell).Cashflows
                                                       ) :> ICell
                let format (i : Generic.List<CashFlow>) (l : string) = Helper.Range.fromList i l

                let source () = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".Cashflows") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_cleanPrice", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_cleanPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toModelReference<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let builder (current : ICell) = ((ConvertibleFloatingRateBondModel.Cast _ConvertibleFloatingRateBond.cell).CleanPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".CleanPrice") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_cleanPrice1", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_cleanPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
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

                let _ConvertibleFloatingRateBond = Helper.toModelReference<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = ((ConvertibleFloatingRateBondModel.Cast _ConvertibleFloatingRateBond.cell).CleanPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".CleanPrice1") 

                                               [| _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_dirtyPrice1", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_dirtyPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
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

                let _ConvertibleFloatingRateBond = Helper.toModelReference<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = ((ConvertibleFloatingRateBondModel.Cast _ConvertibleFloatingRateBond.cell).DirtyPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".DirtyPrice1") 

                                               [| _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_dirtyPrice", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_dirtyPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toModelReference<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let builder (current : ICell) = ((ConvertibleFloatingRateBondModel.Cast _ConvertibleFloatingRateBond.cell).DirtyPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".DirtyPrice") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_isExpired", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toModelReference<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let builder (current : ICell) = ((ConvertibleFloatingRateBondModel.Cast _ConvertibleFloatingRateBond.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".IsExpired") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_issueDate", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_issueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toModelReference<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let builder (current : ICell) = ((ConvertibleFloatingRateBondModel.Cast _ConvertibleFloatingRateBond.cell).IssueDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".IssueDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_isTradable", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_isTradable
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toModelReference<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = ((ConvertibleFloatingRateBondModel.Cast _ConvertibleFloatingRateBond.cell).IsTradable
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".IsTradable") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_maturityDate", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toModelReference<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let builder (current : ICell) = ((ConvertibleFloatingRateBondModel.Cast _ConvertibleFloatingRateBond.cell).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".MaturityDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_nextCashFlowDate", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_nextCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toModelReference<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = ((ConvertibleFloatingRateBondModel.Cast _ConvertibleFloatingRateBond.cell).NextCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".NextCashFlowDate") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_nextCouponRate", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_nextCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toModelReference<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = ((ConvertibleFloatingRateBondModel.Cast _ConvertibleFloatingRateBond.cell).NextCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".NextCouponRate") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_notional", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_notional
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toModelReference<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = ((ConvertibleFloatingRateBondModel.Cast _ConvertibleFloatingRateBond.cell).Notional
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".Notional") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_notionals", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_notionals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toModelReference<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let builder (current : ICell) = ((ConvertibleFloatingRateBondModel.Cast _ConvertibleFloatingRateBond.cell).Notionals
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".Notionals") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_previousCashFlowDate", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_previousCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toModelReference<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = ((ConvertibleFloatingRateBondModel.Cast _ConvertibleFloatingRateBond.cell).PreviousCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".PreviousCashFlowDate") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_previousCouponRate", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_previousCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toModelReference<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = ((ConvertibleFloatingRateBondModel.Cast _ConvertibleFloatingRateBond.cell).PreviousCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".PreviousCouponRate") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_redemption", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_redemption
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toModelReference<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let builder (current : ICell) = ((ConvertibleFloatingRateBondModel.Cast _ConvertibleFloatingRateBond.cell).Redemption
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CashFlow>) l

                let source () = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".Redemption") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConvertibleFloatingRateBond> format
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_redemptions", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_redemptions
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toModelReference<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let builder (current : ICell) = ((ConvertibleFloatingRateBondModel.Cast _ConvertibleFloatingRateBond.cell).Redemptions
                                                       ) :> ICell
                let format (i : Generic.List<CashFlow>) (l : string) = Helper.Range.fromList i l

                let source () = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".Redemptions") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_settlementDate", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_settlementDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        ([<ExcelArgument(Name="date",Description = "Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toModelReference<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let _date = Helper.toCell<Date> date "date" 
                let builder (current : ICell) = ((ConvertibleFloatingRateBondModel.Cast _ConvertibleFloatingRateBond.cell).SettlementDate
                                                            _date.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".SettlementDate") 

                                               [| _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_settlementDays", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toModelReference<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let builder (current : ICell) = ((ConvertibleFloatingRateBondModel.Cast _ConvertibleFloatingRateBond.cell).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".SettlementDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_settlementValue", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_settlementValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        ([<ExcelArgument(Name="cleanPrice",Description = "double")>] 
         cleanPrice : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toModelReference<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let builder (current : ICell) = ((ConvertibleFloatingRateBondModel.Cast _ConvertibleFloatingRateBond.cell).SettlementValue
                                                            _cleanPrice.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".SettlementValue") 

                                               [| _cleanPrice.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_settlementValue1", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_settlementValue1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toModelReference<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let builder (current : ICell) = ((ConvertibleFloatingRateBondModel.Cast _ConvertibleFloatingRateBond.cell).SettlementValue1
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".SettlementValue1") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_startDate", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toModelReference<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let builder (current : ICell) = ((ConvertibleFloatingRateBondModel.Cast _ConvertibleFloatingRateBond.cell).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".StartDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_yield1", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_yield1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
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

                let _ConvertibleFloatingRateBond = Helper.toModelReference<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder (current : ICell) = ((ConvertibleFloatingRateBondModel.Cast _ConvertibleFloatingRateBond.cell).Yield1
                                                            _cleanPrice.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".Yield1") 

                                               [| _cleanPrice.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_yield", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_yield
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
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

                let _ConvertibleFloatingRateBond = Helper.toModelReference<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder (current : ICell) = ((ConvertibleFloatingRateBondModel.Cast _ConvertibleFloatingRateBond.cell).Yield
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".Yield") 

                                               [| _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_CASH", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toModelReference<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let builder (current : ICell) = ((ConvertibleFloatingRateBondModel.Cast _ConvertibleFloatingRateBond.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".CASH") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_errorEstimate", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toModelReference<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let builder (current : ICell) = ((ConvertibleFloatingRateBondModel.Cast _ConvertibleFloatingRateBond.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".ErrorEstimate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_NPV", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toModelReference<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let builder (current : ICell) = ((ConvertibleFloatingRateBondModel.Cast _ConvertibleFloatingRateBond.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".NPV") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_result", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        ([<ExcelArgument(Name="tag",Description = "string")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toModelReference<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder (current : ICell) = ((ConvertibleFloatingRateBondModel.Cast _ConvertibleFloatingRateBond.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".Result") 

                                               [| _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_setPricingEngine", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        ([<ExcelArgument(Name="e",Description = "IPricingEngine")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toModelReference<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder (current : ICell) = ((ConvertibleFloatingRateBondModel.Cast _ConvertibleFloatingRateBond.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : ConvertibleFloatingRateBond) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".SetPricingEngine") 

                                               [| _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_valuationDate", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toModelReference<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let builder (current : ICell) = ((ConvertibleFloatingRateBondModel.Cast _ConvertibleFloatingRateBond.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".ValuationDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_Range", Description="Create a range of ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ConvertibleFloatingRateBond> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<ConvertibleFloatingRateBond> (c)) :> ICell
                let format (i : Cephei.Cell.List<ConvertibleFloatingRateBond>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<ConvertibleFloatingRateBond>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
