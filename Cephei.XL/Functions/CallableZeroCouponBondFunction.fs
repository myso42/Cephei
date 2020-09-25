(*
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

  </summary> *)
[<AutoSerializable(true)>]
module CallableZeroCouponBondFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_CallableZeroCouponBond", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="faceAmount",Description = "Reference to faceAmount")>] 
         faceAmount : obj)
        ([<ExcelArgument(Name="calendar",Description = "Reference to calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="maturityDate",Description = "Reference to maturityDate")>] 
         maturityDate : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="paymentConvention",Description = "Reference to paymentConvention")>] 
         paymentConvention : obj)
        ([<ExcelArgument(Name="redemption",Description = "Reference to redemption")>] 
         redemption : obj)
        ([<ExcelArgument(Name="issueDate",Description = "Reference to issueDate")>] 
         issueDate : obj)
        ([<ExcelArgument(Name="putCallSchedule",Description = "Reference to putCallSchedule")>] 
         putCallSchedule : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "Reference to Pricing Engine used")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Reference to the date used for evaluation")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" true
                let _faceAmount = Helper.toCell<double> faceAmount "faceAmount" true
                let _calendar = Helper.toCell<Calendar> calendar "calendar" true
                let _maturityDate = Helper.toCell<Date> maturityDate "maturityDate" true
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" true
                let _paymentConvention = Helper.toCell<BusinessDayConvention> paymentConvention "paymentConvention" true
                let _redemption = Helper.toCell<double> redemption "redemption" true
                let _issueDate = Helper.toCell<Date> issueDate "issueDate" true
                let _putCallSchedule = Helper.toCell<CallabilitySchedule> putCallSchedule "putCallSchedule" true
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine" true 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate" true 
                let builder () = withMnemonic mnemonic (Fun.CallableZeroCouponBond 
                                                            _settlementDays.cell 
                                                            _faceAmount.cell 
                                                            _calendar.cell 
                                                            _maturityDate.cell 
                                                            _dayCounter.cell 
                                                            _paymentConvention.cell 
                                                            _redemption.cell 
                                                            _issueDate.cell 
                                                            _putCallSchedule.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CallableZeroCouponBond>) l

                let source = Helper.sourceFold "Fun.CallableZeroCouponBond" 
                                               [| _settlementDays.source
                                               ;  _faceAmount.source
                                               ;  _calendar.source
                                               ;  _maturityDate.source
                                               ;  _dayCounter.source
                                               ;  _paymentConvention.source
                                               ;  _redemption.source
                                               ;  _issueDate.source
                                               ;  _putCallSchedule.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _faceAmount.cell
                                ;  _calendar.cell
                                ;  _maturityDate.cell
                                ;  _dayCounter.cell
                                ;  _paymentConvention.cell
                                ;  _redemption.cell
                                ;  _issueDate.cell
                                ;  _putCallSchedule.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CallableZeroCouponBond_callability", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_callability
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "Reference to CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond" true 
                let builder () = withMnemonic mnemonic ((_CallableZeroCouponBond.cell :?> CallableZeroCouponBondModel).Callability
                                                       ) :> ICell
                let format (o : CallabilitySchedule) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CallableZeroCouponBond.source + ".Callability") 
                                               [| _CallableZeroCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_cleanPriceOAS", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_cleanPriceOAS
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "Reference to CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        ([<ExcelArgument(Name="oas",Description = "Reference to oas")>] 
         oas : obj)
        ([<ExcelArgument(Name="engineTS",Description = "Reference to engineTS")>] 
         engineTS : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="compounding",Description = "Reference to compounding")>] 
         compounding : obj)
        ([<ExcelArgument(Name="frequency",Description = "Reference to frequency")>] 
         frequency : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond" true 
                let _oas = Helper.toCell<double> oas "oas" true
                let _engineTS = Helper.toHandle<YieldTermStructure> engineTS "engineTS" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" true
                let _compounding = Helper.toCell<Compounding> compounding "compounding" true
                let _frequency = Helper.toCell<Frequency> frequency "frequency" true
                let _settlement = Helper.toCell<Date> settlement "settlement" true
                let builder () = withMnemonic mnemonic ((_CallableZeroCouponBond.cell :?> CallableZeroCouponBondModel).CleanPriceOAS
                                                            _oas.cell 
                                                            _engineTS.cell 
                                                            _dayCounter.cell 
                                                            _compounding.cell 
                                                            _frequency.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableZeroCouponBond.source + ".CleanPriceOAS") 
                                               [| _CallableZeroCouponBond.source
                                               ;  _oas.source
                                               ;  _engineTS.source
                                               ;  _dayCounter.source
                                               ;  _compounding.source
                                               ;  _frequency.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
                                ;  _oas.cell
                                ;  _engineTS.cell
                                ;  _dayCounter.cell
                                ;  _compounding.cell
                                ;  _frequency.cell
                                ;  _settlement.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_effectiveConvexity", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_effectiveConvexity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "Reference to CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        ([<ExcelArgument(Name="oas",Description = "Reference to oas")>] 
         oas : obj)
        ([<ExcelArgument(Name="engineTS",Description = "Reference to engineTS")>] 
         engineTS : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="compounding",Description = "Reference to compounding")>] 
         compounding : obj)
        ([<ExcelArgument(Name="frequency",Description = "Reference to frequency")>] 
         frequency : obj)
        ([<ExcelArgument(Name="bump",Description = "Reference to bump")>] 
         bump : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond" true 
                let _oas = Helper.toCell<double> oas "oas" true
                let _engineTS = Helper.toHandle<YieldTermStructure> engineTS "engineTS" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" true
                let _compounding = Helper.toCell<Compounding> compounding "compounding" true
                let _frequency = Helper.toCell<Frequency> frequency "frequency" true
                let _bump = Helper.toCell<double> bump "bump" true
                let builder () = withMnemonic mnemonic ((_CallableZeroCouponBond.cell :?> CallableZeroCouponBondModel).EffectiveConvexity
                                                            _oas.cell 
                                                            _engineTS.cell 
                                                            _dayCounter.cell 
                                                            _compounding.cell 
                                                            _frequency.cell 
                                                            _bump.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableZeroCouponBond.source + ".EffectiveConvexity") 
                                               [| _CallableZeroCouponBond.source
                                               ;  _oas.source
                                               ;  _engineTS.source
                                               ;  _dayCounter.source
                                               ;  _compounding.source
                                               ;  _frequency.source
                                               ;  _bump.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
                                ;  _oas.cell
                                ;  _engineTS.cell
                                ;  _dayCounter.cell
                                ;  _compounding.cell
                                ;  _frequency.cell
                                ;  _bump.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_effectiveDuration", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_effectiveDuration
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "Reference to CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        ([<ExcelArgument(Name="oas",Description = "Reference to oas")>] 
         oas : obj)
        ([<ExcelArgument(Name="engineTS",Description = "Reference to engineTS")>] 
         engineTS : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="compounding",Description = "Reference to compounding")>] 
         compounding : obj)
        ([<ExcelArgument(Name="frequency",Description = "Reference to frequency")>] 
         frequency : obj)
        ([<ExcelArgument(Name="bump",Description = "Reference to bump")>] 
         bump : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond" true 
                let _oas = Helper.toCell<double> oas "oas" true
                let _engineTS = Helper.toHandle<YieldTermStructure> engineTS "engineTS" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" true
                let _compounding = Helper.toCell<Compounding> compounding "compounding" true
                let _frequency = Helper.toCell<Frequency> frequency "frequency" true
                let _bump = Helper.toCell<double> bump "bump" true
                let builder () = withMnemonic mnemonic ((_CallableZeroCouponBond.cell :?> CallableZeroCouponBondModel).EffectiveDuration
                                                            _oas.cell 
                                                            _engineTS.cell 
                                                            _dayCounter.cell 
                                                            _compounding.cell 
                                                            _frequency.cell 
                                                            _bump.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableZeroCouponBond.source + ".EffectiveDuration") 
                                               [| _CallableZeroCouponBond.source
                                               ;  _oas.source
                                               ;  _engineTS.source
                                               ;  _dayCounter.source
                                               ;  _compounding.source
                                               ;  _frequency.source
                                               ;  _bump.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
                                ;  _oas.cell
                                ;  _engineTS.cell
                                ;  _dayCounter.cell
                                ;  _compounding.cell
                                ;  _frequency.cell
                                ;  _bump.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_impliedVolatility", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_impliedVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "Reference to CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        ([<ExcelArgument(Name="targetValue",Description = "Reference to targetValue")>] 
         targetValue : obj)
        ([<ExcelArgument(Name="discountCurve",Description = "Reference to discountCurve")>] 
         discountCurve : obj)
        ([<ExcelArgument(Name="accuracy",Description = "Reference to accuracy")>] 
         accuracy : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "Reference to maxEvaluations")>] 
         maxEvaluations : obj)
        ([<ExcelArgument(Name="minVol",Description = "Reference to minVol")>] 
         minVol : obj)
        ([<ExcelArgument(Name="maxVol",Description = "Reference to maxVol")>] 
         maxVol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond" true 
                let _targetValue = Helper.toCell<double> targetValue "targetValue" true
                let _discountCurve = Helper.toHandle<YieldTermStructure> discountCurve "discountCurve" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" true
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" true
                let _minVol = Helper.toCell<double> minVol "minVol" true
                let _maxVol = Helper.toCell<double> maxVol "maxVol" true
                let builder () = withMnemonic mnemonic ((_CallableZeroCouponBond.cell :?> CallableZeroCouponBondModel).ImpliedVolatility
                                                            _targetValue.cell 
                                                            _discountCurve.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                            _minVol.cell 
                                                            _maxVol.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableZeroCouponBond.source + ".ImpliedVolatility") 
                                               [| _CallableZeroCouponBond.source
                                               ;  _targetValue.source
                                               ;  _discountCurve.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               ;  _minVol.source
                                               ;  _maxVol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
                                ;  _targetValue.cell
                                ;  _discountCurve.cell
                                ;  _accuracy.cell
                                ;  _maxEvaluations.cell
                                ;  _minVol.cell
                                ;  _maxVol.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_OAS", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_OAS
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "Reference to CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        ([<ExcelArgument(Name="cleanPrice",Description = "Reference to cleanPrice")>] 
         cleanPrice : obj)
        ([<ExcelArgument(Name="engineTS",Description = "Reference to engineTS")>] 
         engineTS : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="compounding",Description = "Reference to compounding")>] 
         compounding : obj)
        ([<ExcelArgument(Name="frequency",Description = "Reference to frequency")>] 
         frequency : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        ([<ExcelArgument(Name="accuracy",Description = "Reference to accuracy")>] 
         accuracy : obj)
        ([<ExcelArgument(Name="maxIterations",Description = "Reference to maxIterations")>] 
         maxIterations : obj)
        ([<ExcelArgument(Name="guess",Description = "Reference to guess")>] 
         guess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond" true 
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" true
                let _engineTS = Helper.toHandle<YieldTermStructure> engineTS "engineTS" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" true
                let _compounding = Helper.toCell<Compounding> compounding "compounding" true
                let _frequency = Helper.toCell<Frequency> frequency "frequency" true
                let _settlement = Helper.toCell<Date> settlement "settlement" true
                let _accuracy = Helper.toCell<double> accuracy "accuracy" true
                let _maxIterations = Helper.toCell<int> maxIterations "maxIterations" true
                let _guess = Helper.toCell<double> guess "guess" true
                let builder () = withMnemonic mnemonic ((_CallableZeroCouponBond.cell :?> CallableZeroCouponBondModel).OAS
                                                            _cleanPrice.cell 
                                                            _engineTS.cell 
                                                            _dayCounter.cell 
                                                            _compounding.cell 
                                                            _frequency.cell 
                                                            _settlement.cell 
                                                            _accuracy.cell 
                                                            _maxIterations.cell 
                                                            _guess.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableZeroCouponBond.source + ".OAS") 
                                               [| _CallableZeroCouponBond.source
                                               ;  _cleanPrice.source
                                               ;  _engineTS.source
                                               ;  _dayCounter.source
                                               ;  _compounding.source
                                               ;  _frequency.source
                                               ;  _settlement.source
                                               ;  _accuracy.source
                                               ;  _maxIterations.source
                                               ;  _guess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
                                ;  _cleanPrice.cell
                                ;  _engineTS.cell
                                ;  _dayCounter.cell
                                ;  _compounding.cell
                                ;  _frequency.cell
                                ;  _settlement.cell
                                ;  _accuracy.cell
                                ;  _maxIterations.cell
                                ;  _guess.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_accruedAmount", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "Reference to CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond" true 
                let _settlement = Helper.toCell<Date> settlement "settlement" true
                let builder () = withMnemonic mnemonic ((_CallableZeroCouponBond.cell :?> CallableZeroCouponBondModel).AccruedAmount
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableZeroCouponBond.source + ".AccruedAmount") 
                                               [| _CallableZeroCouponBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
                                ;  _settlement.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_calendar", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "Reference to CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond" true 
                let builder () = withMnemonic mnemonic ((_CallableZeroCouponBond.cell :?> CallableZeroCouponBondModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_CallableZeroCouponBond.source + ".Calendar") 
                                               [| _CallableZeroCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_cashflows", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_cashflows
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "Reference to CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond" true 
                let builder () = withMnemonic mnemonic ((_CallableZeroCouponBond.cell :?> CallableZeroCouponBondModel).Cashflows
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_CallableZeroCouponBond.source + ".Cashflows") 
                                               [| _CallableZeroCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_cleanPrice", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_cleanPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "Reference to CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond" true 
                let builder () = withMnemonic mnemonic ((_CallableZeroCouponBond.cell :?> CallableZeroCouponBondModel).CleanPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableZeroCouponBond.source + ".CleanPrice") 
                                               [| _CallableZeroCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_cleanPrice1", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_cleanPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "Reference to CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        ([<ExcelArgument(Name="Yield",Description = "Reference to Yield")>] 
         Yield : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        ([<ExcelArgument(Name="comp",Description = "Reference to comp")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Reference to freq")>] 
         freq : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond" true 
                let _Yield = Helper.toCell<double> Yield "Yield" true
                let _dc = Helper.toCell<DayCounter> dc "dc" true
                let _comp = Helper.toCell<Compounding> comp "comp" true
                let _freq = Helper.toCell<Frequency> freq "freq" true
                let _settlement = Helper.toCell<Date> settlement "settlement" true
                let builder () = withMnemonic mnemonic ((_CallableZeroCouponBond.cell :?> CallableZeroCouponBondModel).CleanPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableZeroCouponBond.source + ".CleanPrice1") 
                                               [| _CallableZeroCouponBond.source
                                               ;  _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
                                ;  _Yield.cell
                                ;  _dc.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _settlement.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_dirtyPrice1", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_dirtyPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "Reference to CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        ([<ExcelArgument(Name="Yield",Description = "Reference to Yield")>] 
         Yield : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        ([<ExcelArgument(Name="comp",Description = "Reference to comp")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Reference to freq")>] 
         freq : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond" true 
                let _Yield = Helper.toCell<double> Yield "Yield" true
                let _dc = Helper.toCell<DayCounter> dc "dc" true
                let _comp = Helper.toCell<Compounding> comp "comp" true
                let _freq = Helper.toCell<Frequency> freq "freq" true
                let _settlement = Helper.toCell<Date> settlement "settlement" true
                let builder () = withMnemonic mnemonic ((_CallableZeroCouponBond.cell :?> CallableZeroCouponBondModel).DirtyPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableZeroCouponBond.source + ".DirtyPrice1") 
                                               [| _CallableZeroCouponBond.source
                                               ;  _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
                                ;  _Yield.cell
                                ;  _dc.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _settlement.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_dirtyPrice", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_dirtyPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "Reference to CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond" true 
                let builder () = withMnemonic mnemonic ((_CallableZeroCouponBond.cell :?> CallableZeroCouponBondModel).DirtyPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableZeroCouponBond.source + ".DirtyPrice") 
                                               [| _CallableZeroCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_isExpired", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "Reference to CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond" true 
                let builder () = withMnemonic mnemonic ((_CallableZeroCouponBond.cell :?> CallableZeroCouponBondModel).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CallableZeroCouponBond.source + ".IsExpired") 
                                               [| _CallableZeroCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_issueDate", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_issueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "Reference to CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond" true 
                let builder () = withMnemonic mnemonic ((_CallableZeroCouponBond.cell :?> CallableZeroCouponBondModel).IssueDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CallableZeroCouponBond.source + ".IssueDate") 
                                               [| _CallableZeroCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_isTradable", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_isTradable
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "Reference to CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_CallableZeroCouponBond.cell :?> CallableZeroCouponBondModel).IsTradable
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CallableZeroCouponBond.source + ".IsTradable") 
                                               [| _CallableZeroCouponBond.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
                                ;  _d.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_maturityDate", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "Reference to CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond" true 
                let builder () = withMnemonic mnemonic ((_CallableZeroCouponBond.cell :?> CallableZeroCouponBondModel).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CallableZeroCouponBond.source + ".MaturityDate") 
                                               [| _CallableZeroCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_nextCashFlowDate", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_nextCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "Reference to CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond" true 
                let _settlement = Helper.toCell<Date> settlement "settlement" true
                let builder () = withMnemonic mnemonic ((_CallableZeroCouponBond.cell :?> CallableZeroCouponBondModel).NextCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CallableZeroCouponBond.source + ".NextCashFlowDate") 
                                               [| _CallableZeroCouponBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
                                ;  _settlement.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_nextCouponRate", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_nextCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "Reference to CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond" true 
                let _settlement = Helper.toCell<Date> settlement "settlement" true
                let builder () = withMnemonic mnemonic ((_CallableZeroCouponBond.cell :?> CallableZeroCouponBondModel).NextCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableZeroCouponBond.source + ".NextCouponRate") 
                                               [| _CallableZeroCouponBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
                                ;  _settlement.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_notional", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_notional
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "Reference to CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_CallableZeroCouponBond.cell :?> CallableZeroCouponBondModel).Notional
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableZeroCouponBond.source + ".Notional") 
                                               [| _CallableZeroCouponBond.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
                                ;  _d.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_notionals", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_notionals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "Reference to CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond" true 
                let builder () = withMnemonic mnemonic ((_CallableZeroCouponBond.cell :?> CallableZeroCouponBondModel).Notionals
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_CallableZeroCouponBond.source + ".Notionals") 
                                               [| _CallableZeroCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_previousCashFlowDate", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_previousCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "Reference to CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond" true 
                let _settlement = Helper.toCell<Date> settlement "settlement" true
                let builder () = withMnemonic mnemonic ((_CallableZeroCouponBond.cell :?> CallableZeroCouponBondModel).PreviousCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CallableZeroCouponBond.source + ".PreviousCashFlowDate") 
                                               [| _CallableZeroCouponBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
                                ;  _settlement.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_previousCouponRate", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_previousCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "Reference to CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond" true 
                let _settlement = Helper.toCell<Date> settlement "settlement" true
                let builder () = withMnemonic mnemonic ((_CallableZeroCouponBond.cell :?> CallableZeroCouponBondModel).PreviousCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableZeroCouponBond.source + ".PreviousCouponRate") 
                                               [| _CallableZeroCouponBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
                                ;  _settlement.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_redemption", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_redemption
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "Reference to CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond" true 
                let builder () = withMnemonic mnemonic ((_CallableZeroCouponBond.cell :?> CallableZeroCouponBondModel).Redemption
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CashFlow>) l

                let source = Helper.sourceFold (_CallableZeroCouponBond.source + ".Redemption") 
                                               [| _CallableZeroCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_redemptions", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_redemptions
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "Reference to CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond" true 
                let builder () = withMnemonic mnemonic ((_CallableZeroCouponBond.cell :?> CallableZeroCouponBondModel).Redemptions
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_CallableZeroCouponBond.source + ".Redemptions") 
                                               [| _CallableZeroCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CallableZeroCouponBond_settlementDate", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_settlementDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "Reference to CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond" true 
                let _date = Helper.toCell<Date> date "date" true
                let builder () = withMnemonic mnemonic ((_CallableZeroCouponBond.cell :?> CallableZeroCouponBondModel).SettlementDate
                                                            _date.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CallableZeroCouponBond.source + ".SettlementDate") 
                                               [| _CallableZeroCouponBond.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
                                ;  _date.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_settlementDays", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "Reference to CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond" true 
                let builder () = withMnemonic mnemonic ((_CallableZeroCouponBond.cell :?> CallableZeroCouponBondModel).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableZeroCouponBond.source + ".SettlementDays") 
                                               [| _CallableZeroCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_settlementValue", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_settlementValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "Reference to CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        ([<ExcelArgument(Name="cleanPrice",Description = "Reference to cleanPrice")>] 
         cleanPrice : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond" true 
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" true
                let builder () = withMnemonic mnemonic ((_CallableZeroCouponBond.cell :?> CallableZeroCouponBondModel).SettlementValue
                                                            _cleanPrice.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableZeroCouponBond.source + ".SettlementValue") 
                                               [| _CallableZeroCouponBond.source
                                               ;  _cleanPrice.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
                                ;  _cleanPrice.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_settlementValue1", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_settlementValue1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "Reference to CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond" true 
                let builder () = withMnemonic mnemonic ((_CallableZeroCouponBond.cell :?> CallableZeroCouponBondModel).SettlementValue1
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableZeroCouponBond.source + ".SettlementValue1") 
                                               [| _CallableZeroCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_startDate", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "Reference to CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond" true 
                let builder () = withMnemonic mnemonic ((_CallableZeroCouponBond.cell :?> CallableZeroCouponBondModel).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CallableZeroCouponBond.source + ".StartDate") 
                                               [| _CallableZeroCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_yield1", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_yield1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "Reference to CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        ([<ExcelArgument(Name="cleanPrice",Description = "Reference to cleanPrice")>] 
         cleanPrice : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        ([<ExcelArgument(Name="comp",Description = "Reference to comp")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Reference to freq")>] 
         freq : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        ([<ExcelArgument(Name="accuracy",Description = "Reference to accuracy")>] 
         accuracy : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "Reference to maxEvaluations")>] 
         maxEvaluations : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond" true 
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" true
                let _dc = Helper.toCell<DayCounter> dc "dc" true
                let _comp = Helper.toCell<Compounding> comp "comp" true
                let _freq = Helper.toCell<Frequency> freq "freq" true
                let _settlement = Helper.toCell<Date> settlement "settlement" true
                let _accuracy = Helper.toCell<double> accuracy "accuracy" true
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" true
                let builder () = withMnemonic mnemonic ((_CallableZeroCouponBond.cell :?> CallableZeroCouponBondModel).Yield1
                                                            _cleanPrice.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableZeroCouponBond.source + ".Yield1") 
                                               [| _CallableZeroCouponBond.source
                                               ;  _cleanPrice.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
                                ;  _cleanPrice.cell
                                ;  _dc.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _settlement.cell
                                ;  _accuracy.cell
                                ;  _maxEvaluations.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_yield", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_yield
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "Reference to CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        ([<ExcelArgument(Name="comp",Description = "Reference to comp")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Reference to freq")>] 
         freq : obj)
        ([<ExcelArgument(Name="accuracy",Description = "Reference to accuracy")>] 
         accuracy : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "Reference to maxEvaluations")>] 
         maxEvaluations : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond" true 
                let _dc = Helper.toCell<DayCounter> dc "dc" true
                let _comp = Helper.toCell<Compounding> comp "comp" true
                let _freq = Helper.toCell<Frequency> freq "freq" true
                let _accuracy = Helper.toCell<double> accuracy "accuracy" true
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" true
                let builder () = withMnemonic mnemonic ((_CallableZeroCouponBond.cell :?> CallableZeroCouponBondModel).Yield
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableZeroCouponBond.source + ".Yield") 
                                               [| _CallableZeroCouponBond.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
                                ;  _dc.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _accuracy.cell
                                ;  _maxEvaluations.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_CASH", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "Reference to CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond" true 
                let builder () = withMnemonic mnemonic ((_CallableZeroCouponBond.cell :?> CallableZeroCouponBondModel).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableZeroCouponBond.source + ".CASH") 
                                               [| _CallableZeroCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_errorEstimate", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "Reference to CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond" true 
                let builder () = withMnemonic mnemonic ((_CallableZeroCouponBond.cell :?> CallableZeroCouponBondModel).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableZeroCouponBond.source + ".ErrorEstimate") 
                                               [| _CallableZeroCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_NPV", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "Reference to CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond" true 
                let builder () = withMnemonic mnemonic ((_CallableZeroCouponBond.cell :?> CallableZeroCouponBondModel).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableZeroCouponBond.source + ".NPV") 
                                               [| _CallableZeroCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_result", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "Reference to CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond" true 
                let _tag = Helper.toCell<string> tag "tag" true
                let builder () = withMnemonic mnemonic ((_CallableZeroCouponBond.cell :?> CallableZeroCouponBondModel).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CallableZeroCouponBond.source + ".Result") 
                                               [| _CallableZeroCouponBond.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
                                ;  _tag.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_setPricingEngine", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "Reference to CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond" true 
                let _e = Helper.toCell<IPricingEngine> e "e" true
                let builder () = withMnemonic mnemonic ((_CallableZeroCouponBond.cell :?> CallableZeroCouponBondModel).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : CallableZeroCouponBond) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CallableZeroCouponBond.source + ".SetPricingEngine") 
                                               [| _CallableZeroCouponBond.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
                                ;  _e.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_valuationDate", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "Reference to CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond" true 
                let builder () = withMnemonic mnemonic ((_CallableZeroCouponBond.cell :?> CallableZeroCouponBondModel).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CallableZeroCouponBond.source + ".ValuationDate") 
                                               [| _CallableZeroCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_CallableZeroCouponBond_Range", Description="Create a range of CallableZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the CallableZeroCouponBond")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CallableZeroCouponBond> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CallableZeroCouponBond>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<CallableZeroCouponBond>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<CallableZeroCouponBond>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"