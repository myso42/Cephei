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
  instruments
  </summary> *)
[<AutoSerializable(true)>]
module BTPFunction =

    (*
        ! The default bond settlement is used if no date is given.
    *)
    [<ExcelFunction(Name="_BTP_accruedAmount", Description="Create a BTP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BTP_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BTP",Description = "BTP")>] 
         btp : obj)
        ([<ExcelArgument(Name="d",Description = "BTP")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BTP = Helper.toModelReference<BTP> btp "BTP"  
                let _d = Helper.toDefault<Date> d "d" null
                let builder (current : ICell) = ((BTPModel.Cast _BTP.cell).AccruedAmount
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BTP.source + ".AccruedAmount") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BTP.cell
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
        ! constructor needed for legacy non-par redemption BTPs. As of today the only remaining one is IT123456789012 that will redeem 99.999 on xx-may-2037
    *)
    [<ExcelFunction(Name="_BTP", Description="Create a BTP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BTP_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="maturityDate",Description = "Date")>] 
         maturityDate : obj)
        ([<ExcelArgument(Name="fixedRate",Description = "double")>] 
         fixedRate : obj)
        ([<ExcelArgument(Name="redemption",Description = "double")>] 
         redemption : obj)
        ([<ExcelArgument(Name="startDate",Description = "Date or empty")>] 
         startDate : obj)
        ([<ExcelArgument(Name="issueDate",Description = "Date or empty")>] 
         issueDate : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "IPricingEngine")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _maturityDate = Helper.toCell<Date> maturityDate "maturityDate" 
                let _fixedRate = Helper.toCell<double> fixedRate "fixedRate" 
                let _redemption = Helper.toCell<double> redemption "redemption" 
                let _startDate = Helper.toDefault<Date> startDate "startDate" null
                let _issueDate = Helper.toDefault<Date> issueDate "issueDate" null
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = (Fun.BTP 
                                                            _maturityDate.cell 
                                                            _fixedRate.cell 
                                                            _redemption.cell 
                                                            _startDate.cell 
                                                            _issueDate.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BTP>) l

                let source () = Helper.sourceFold "Fun.BTP" 
                                               [| _maturityDate.source
                                               ;  _fixedRate.source
                                               ;  _redemption.source
                                               ;  _startDate.source
                                               ;  _issueDate.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _maturityDate.cell
                                ;  _fixedRate.cell
                                ;  _redemption.cell
                                ;  _startDate.cell
                                ;  _issueDate.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BTP> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BTP1", Description="Create a BTP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BTP_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="maturityDate",Description = "Date")>] 
         maturityDate : obj)
        ([<ExcelArgument(Name="fixedRate",Description = "double")>] 
         fixedRate : obj)
        ([<ExcelArgument(Name="startDate",Description = "Date or empty")>] 
         startDate : obj)
        ([<ExcelArgument(Name="issueDate",Description = "Date or empty")>] 
         issueDate : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "IPricingEngine")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _maturityDate = Helper.toCell<Date> maturityDate "maturityDate" 
                let _fixedRate = Helper.toCell<double> fixedRate "fixedRate" 
                let _startDate = Helper.toDefault<Date> startDate "startDate" null
                let _issueDate = Helper.toDefault<Date> issueDate "issueDate" null
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = (Fun.BTP1 
                                                            _maturityDate.cell 
                                                            _fixedRate.cell 
                                                            _startDate.cell 
                                                            _issueDate.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BTP>) l

                let source () = Helper.sourceFold "Fun.BTP1" 
                                               [| _maturityDate.source
                                               ;  _fixedRate.source
                                               ;  _startDate.source
                                               ;  _issueDate.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _maturityDate.cell
                                ;  _fixedRate.cell
                                ;  _startDate.cell
                                ;  _issueDate.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BTP> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! The default BTP conventions are used: Actual/Actual (ISMA), Compounded, Annual. The default bond settlement is used if no date is given.
    *)
    [<ExcelFunction(Name="_BTP_yield", Description="Create a BTP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BTP_yield
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BTP",Description = "BTP")>] 
         btp : obj)
        ([<ExcelArgument(Name="cleanPrice",Description = "double")>] 
         cleanPrice : obj)
        ([<ExcelArgument(Name="settlementDate",Description = "Date or empty")>] 
         settlementDate : obj)
        ([<ExcelArgument(Name="accuracy",Description = "double or empty")>] 
         accuracy : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "int or empty")>] 
         maxEvaluations : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BTP = Helper.toModelReference<BTP> btp "BTP"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let _settlementDate = Helper.toDefault<Date> settlementDate "settlementDate" null
                let _accuracy = Helper.toDefault<double> accuracy "accuracy" 1.0e-8
                let _maxEvaluations = Helper.toDefault<int> maxEvaluations "maxEvaluations" 100
                let builder (current : ICell) = ((BTPModel.Cast _BTP.cell).Yield
                                                            _cleanPrice.cell 
                                                            _settlementDate.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BTP.source + ".Yield") 

                                               [| _cleanPrice.source
                                               ;  _settlementDate.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BTP.cell
                                ;  _cleanPrice.cell
                                ;  _settlementDate.cell
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
    [<ExcelFunction(Name="_BTP_dayCounter", Description="Create a BTP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BTP_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BTP",Description = "BTP")>] 
         btp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BTP = Helper.toModelReference<BTP> btp "BTP"  
                let builder (current : ICell) = ((BTPModel.Cast _BTP.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_BTP.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BTP.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BTP> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BTP_frequency", Description="Create a BTP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BTP_frequency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BTP",Description = "BTP")>] 
         btp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BTP = Helper.toModelReference<BTP> btp "BTP"  
                let builder (current : ICell) = ((BTPModel.Cast _BTP.cell).Frequency
                                                       ) :> ICell
                let format (o : Frequency) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BTP.source + ".Frequency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BTP.cell
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
    [<ExcelFunction(Name="_BTP_calendar", Description="Create a BTP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BTP_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BTP",Description = "BTP")>] 
         btp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BTP = Helper.toModelReference<BTP> btp "BTP"  
                let builder (current : ICell) = ((BTPModel.Cast _BTP.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_BTP.source + ".Calendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BTP.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BTP> format
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
    [<ExcelFunction(Name="_BTP_cashflows", Description="Create a BTP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BTP_cashflows
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BTP",Description = "BTP")>] 
         btp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BTP = Helper.toModelReference<BTP> btp "BTP"  
                let builder (current : ICell) = ((BTPModel.Cast _BTP.cell).Cashflows
                                                       ) :> ICell
                let format (i : Generic.List<CashFlow>) (l : string) = Helper.Range.fromList i l

                let source () = Helper.sourceFold (_BTP.source + ".Cashflows") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BTP.cell
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
    [<ExcelFunction(Name="_BTP_cleanPrice", Description="Create a BTP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BTP_cleanPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BTP",Description = "BTP")>] 
         btp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BTP = Helper.toModelReference<BTP> btp "BTP"  
                let builder (current : ICell) = ((BTPModel.Cast _BTP.cell).CleanPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BTP.source + ".CleanPrice") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BTP.cell
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
    [<ExcelFunction(Name="_BTP_cleanPrice1", Description="Create a BTP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BTP_cleanPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BTP",Description = "BTP")>] 
         btp : obj)
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

                let _BTP = Helper.toModelReference<BTP> btp "BTP"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = ((BTPModel.Cast _BTP.cell).CleanPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BTP.source + ".CleanPrice1") 

                                               [| _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BTP.cell
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
    [<ExcelFunction(Name="_BTP_dirtyPrice1", Description="Create a BTP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BTP_dirtyPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BTP",Description = "BTP")>] 
         btp : obj)
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

                let _BTP = Helper.toModelReference<BTP> btp "BTP"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = ((BTPModel.Cast _BTP.cell).DirtyPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BTP.source + ".DirtyPrice1") 

                                               [| _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BTP.cell
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
    [<ExcelFunction(Name="_BTP_dirtyPrice", Description="Create a BTP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BTP_dirtyPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BTP",Description = "BTP")>] 
         btp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BTP = Helper.toModelReference<BTP> btp "BTP"  
                let builder (current : ICell) = ((BTPModel.Cast _BTP.cell).DirtyPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BTP.source + ".DirtyPrice") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BTP.cell
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
    [<ExcelFunction(Name="_BTP_isExpired", Description="Create a BTP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BTP_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BTP",Description = "BTP")>] 
         btp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BTP = Helper.toModelReference<BTP> btp "BTP"  
                let builder (current : ICell) = ((BTPModel.Cast _BTP.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BTP.source + ".IsExpired") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BTP.cell
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
    [<ExcelFunction(Name="_BTP_issueDate", Description="Create a BTP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BTP_issueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BTP",Description = "BTP")>] 
         btp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BTP = Helper.toModelReference<BTP> btp "BTP"  
                let builder (current : ICell) = ((BTPModel.Cast _BTP.cell).IssueDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_BTP.source + ".IssueDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BTP.cell
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
    [<ExcelFunction(Name="_BTP_isTradable", Description="Create a BTP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BTP_isTradable
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BTP",Description = "BTP")>] 
         btp : obj)
        ([<ExcelArgument(Name="d",Description = "Date or empty")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BTP = Helper.toModelReference<BTP> btp "BTP"  
                let _d = Helper.toDefault<Date> d "d" null
                let builder (current : ICell) = ((BTPModel.Cast _BTP.cell).IsTradable
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BTP.source + ".IsTradable") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BTP.cell
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
    [<ExcelFunction(Name="_BTP_maturityDate", Description="Create a BTP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BTP_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BTP",Description = "BTP")>] 
         btp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BTP = Helper.toModelReference<BTP> btp "BTP"  
                let builder (current : ICell) = ((BTPModel.Cast _BTP.cell).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_BTP.source + ".MaturityDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BTP.cell
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
    [<ExcelFunction(Name="_BTP_nextCashFlowDate", Description="Create a BTP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BTP_nextCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BTP",Description = "BTP")>] 
         btp : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BTP = Helper.toModelReference<BTP> btp "BTP"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = ((BTPModel.Cast _BTP.cell).NextCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_BTP.source + ".NextCashFlowDate") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BTP.cell
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
    [<ExcelFunction(Name="_BTP_nextCouponRate", Description="Create a BTP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BTP_nextCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BTP",Description = "BTP")>] 
         btp : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BTP = Helper.toModelReference<BTP> btp "BTP"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = ((BTPModel.Cast _BTP.cell).NextCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BTP.source + ".NextCouponRate") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BTP.cell
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
    [<ExcelFunction(Name="_BTP_notional", Description="Create a BTP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BTP_notional
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BTP",Description = "BTP")>] 
         btp : obj)
        ([<ExcelArgument(Name="d",Description = "Date or empty")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BTP = Helper.toModelReference<BTP> btp "BTP"  
                let _d = Helper.toDefault<Date> d "d" null
                let builder (current : ICell) = ((BTPModel.Cast _BTP.cell).Notional
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BTP.source + ".Notional") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BTP.cell
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
    [<ExcelFunction(Name="_BTP_notionals", Description="Create a BTP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BTP_notionals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BTP",Description = "BTP")>] 
         btp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BTP = Helper.toModelReference<BTP> btp "BTP"  
                let builder (current : ICell) = ((BTPModel.Cast _BTP.cell).Notionals
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_BTP.source + ".Notionals") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BTP.cell
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
    [<ExcelFunction(Name="_BTP_previousCashFlowDate", Description="Create a BTP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BTP_previousCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BTP",Description = "BTP")>] 
         btp : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BTP = Helper.toModelReference<BTP> btp "BTP"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = ((BTPModel.Cast _BTP.cell).PreviousCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_BTP.source + ".PreviousCashFlowDate") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BTP.cell
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
    [<ExcelFunction(Name="_BTP_previousCouponRate", Description="Create a BTP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BTP_previousCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BTP",Description = "BTP")>] 
         btp : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BTP = Helper.toModelReference<BTP> btp "BTP"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = ((BTPModel.Cast _BTP.cell).PreviousCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BTP.source + ".PreviousCouponRate") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BTP.cell
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
    [<ExcelFunction(Name="_BTP_redemption", Description="Create a BTP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BTP_redemption
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BTP",Description = "BTP")>] 
         btp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BTP = Helper.toModelReference<BTP> btp "BTP"  
                let builder (current : ICell) = ((BTPModel.Cast _BTP.cell).Redemption
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CashFlow>) l

                let source () = Helper.sourceFold (_BTP.source + ".Redemption") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BTP.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BTP> format
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
    [<ExcelFunction(Name="_BTP_redemptions", Description="Create a BTP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BTP_redemptions
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BTP",Description = "BTP")>] 
         btp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BTP = Helper.toModelReference<BTP> btp "BTP"  
                let builder (current : ICell) = ((BTPModel.Cast _BTP.cell).Redemptions
                                                       ) :> ICell
                let format (i : Generic.List<CashFlow>) (l : string) = Helper.Range.fromList i l

                let source () = Helper.sourceFold (_BTP.source + ".Redemptions") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BTP.cell
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
    [<ExcelFunction(Name="_BTP_settlementDate", Description="Create a BTP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BTP_settlementDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BTP",Description = "BTP")>] 
         btp : obj)
        ([<ExcelArgument(Name="date",Description = "Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BTP = Helper.toModelReference<BTP> btp "BTP"  
                let _date = Helper.toCell<Date> date "date" 
                let builder (current : ICell) = ((BTPModel.Cast _BTP.cell).SettlementDate
                                                            _date.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_BTP.source + ".SettlementDate") 

                                               [| _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BTP.cell
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
    [<ExcelFunction(Name="_BTP_settlementDays", Description="Create a BTP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BTP_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BTP",Description = "BTP")>] 
         btp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BTP = Helper.toModelReference<BTP> btp "BTP"  
                let builder (current : ICell) = ((BTPModel.Cast _BTP.cell).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BTP.source + ".SettlementDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BTP.cell
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
    [<ExcelFunction(Name="_BTP_settlementValue", Description="Create a BTP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BTP_settlementValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BTP",Description = "BTP")>] 
         btp : obj)
        ([<ExcelArgument(Name="cleanPrice",Description = "double")>] 
         cleanPrice : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BTP = Helper.toModelReference<BTP> btp "BTP"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let builder (current : ICell) = ((BTPModel.Cast _BTP.cell).SettlementValue
                                                            _cleanPrice.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BTP.source + ".SettlementValue") 

                                               [| _cleanPrice.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BTP.cell
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
    [<ExcelFunction(Name="_BTP_settlementValue1", Description="Create a BTP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BTP_settlementValue1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BTP",Description = "BTP")>] 
         btp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BTP = Helper.toModelReference<BTP> btp "BTP"  
                let builder (current : ICell) = ((BTPModel.Cast _BTP.cell).SettlementValue1
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BTP.source + ".SettlementValue1") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BTP.cell
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
    [<ExcelFunction(Name="_BTP_startDate", Description="Create a BTP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BTP_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BTP",Description = "BTP")>] 
         btp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BTP = Helper.toModelReference<BTP> btp "BTP"  
                let builder (current : ICell) = ((BTPModel.Cast _BTP.cell).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_BTP.source + ".StartDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BTP.cell
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
    [<ExcelFunction(Name="_BTP_CASH", Description="Create a BTP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BTP_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BTP",Description = "BTP")>] 
         btp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BTP = Helper.toModelReference<BTP> btp "BTP"  
                let builder (current : ICell) = ((BTPModel.Cast _BTP.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BTP.source + ".CASH") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BTP.cell
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
    [<ExcelFunction(Name="_BTP_errorEstimate", Description="Create a BTP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BTP_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BTP",Description = "BTP")>] 
         btp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BTP = Helper.toModelReference<BTP> btp "BTP"  
                let builder (current : ICell) = ((BTPModel.Cast _BTP.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BTP.source + ".ErrorEstimate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BTP.cell
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
    [<ExcelFunction(Name="_BTP_NPV", Description="Create a BTP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BTP_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BTP",Description = "BTP")>] 
         btp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BTP = Helper.toModelReference<BTP> btp "BTP"  
                let builder (current : ICell) = ((BTPModel.Cast _BTP.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BTP.source + ".NPV") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BTP.cell
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
    [<ExcelFunction(Name="_BTP_result", Description="Create a BTP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BTP_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BTP",Description = "BTP")>] 
         btp : obj)
        ([<ExcelArgument(Name="tag",Description = "string")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BTP = Helper.toModelReference<BTP> btp "BTP"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder (current : ICell) = ((BTPModel.Cast _BTP.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BTP.source + ".Result") 

                                               [| _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BTP.cell
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
    [<ExcelFunction(Name="_BTP_setPricingEngine", Description="Create a BTP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BTP_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BTP",Description = "BTP")>] 
         btp : obj)
        ([<ExcelArgument(Name="e",Description = "IPricingEngine")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BTP = Helper.toModelReference<BTP> btp "BTP"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder (current : ICell) = ((BTPModel.Cast _BTP.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : BTP) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BTP.source + ".SetPricingEngine") 

                                               [| _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BTP.cell
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
    [<ExcelFunction(Name="_BTP_valuationDate", Description="Create a BTP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BTP_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BTP",Description = "BTP")>] 
         btp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BTP = Helper.toModelReference<BTP> btp "BTP"  
                let builder (current : ICell) = ((BTPModel.Cast _BTP.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_BTP.source + ".ValuationDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BTP.cell
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
    [<ExcelFunction(Name="_BTP_Range", Description="Create a range of BTP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BTP_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BTP> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<BTP> (c)) :> ICell
                let format (i : Cephei.Cell.List<BTP>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<BTP>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
