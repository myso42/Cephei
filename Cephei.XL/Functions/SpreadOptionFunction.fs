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
module SpreadOptionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SpreadOption", Description="Create a SpreadOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadOption_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="payoff",Description = "Reference to payoff")>] 
         payoff : obj)
        ([<ExcelArgument(Name="exercise",Description = "Reference to exercise")>] 
         exercise : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "Reference to Pricing Engine used")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Reference to the date used for evaluation")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _payoff = Helper.toCell<PlainVanillaPayoff> payoff "payoff" true
                let _exercise = Helper.toCell<Exercise> exercise "exercise" true
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine" true 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate" true 
                let builder () = withMnemonic mnemonic (Fun.SpreadOption 
                                                            _payoff.cell 
                                                            _exercise.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SpreadOption>) l

                let source = Helper.sourceFold "Fun.SpreadOption" 
                                               [| _payoff.source
                                               ;  _exercise.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _payoff.cell
                                ;  _exercise.cell
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
        greeks
    *)
    [<ExcelFunction(Name="_SpreadOption_delta", Description="Create a SpreadOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadOption_delta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadOption",Description = "Reference to SpreadOption")>] 
         spreadoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadOption = Helper.toCell<SpreadOption> spreadoption "SpreadOption" true 
                let builder () = withMnemonic mnemonic ((_SpreadOption.cell :?> SpreadOptionModel).Delta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SpreadOption.source + ".Delta") 
                                               [| _SpreadOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadOption.cell
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
    [<ExcelFunction(Name="_SpreadOption_dividendRho", Description="Create a SpreadOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadOption_dividendRho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadOption",Description = "Reference to SpreadOption")>] 
         spreadoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadOption = Helper.toCell<SpreadOption> spreadoption "SpreadOption" true 
                let builder () = withMnemonic mnemonic ((_SpreadOption.cell :?> SpreadOptionModel).DividendRho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SpreadOption.source + ".DividendRho") 
                                               [| _SpreadOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadOption.cell
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
    [<ExcelFunction(Name="_SpreadOption_gamma", Description="Create a SpreadOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadOption_gamma
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadOption",Description = "Reference to SpreadOption")>] 
         spreadoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadOption = Helper.toCell<SpreadOption> spreadoption "SpreadOption" true 
                let builder () = withMnemonic mnemonic ((_SpreadOption.cell :?> SpreadOptionModel).Gamma
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SpreadOption.source + ".Gamma") 
                                               [| _SpreadOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadOption.cell
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
        Instrument interface
    *)
    [<ExcelFunction(Name="_SpreadOption_isExpired", Description="Create a SpreadOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadOption_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadOption",Description = "Reference to SpreadOption")>] 
         spreadoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadOption = Helper.toCell<SpreadOption> spreadoption "SpreadOption" true 
                let builder () = withMnemonic mnemonic ((_SpreadOption.cell :?> SpreadOptionModel).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SpreadOption.source + ".IsExpired") 
                                               [| _SpreadOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadOption.cell
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
    [<ExcelFunction(Name="_SpreadOption_rho", Description="Create a SpreadOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadOption_rho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadOption",Description = "Reference to SpreadOption")>] 
         spreadoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadOption = Helper.toCell<SpreadOption> spreadoption "SpreadOption" true 
                let builder () = withMnemonic mnemonic ((_SpreadOption.cell :?> SpreadOptionModel).Rho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SpreadOption.source + ".Rho") 
                                               [| _SpreadOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadOption.cell
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
    [<ExcelFunction(Name="_SpreadOption_theta", Description="Create a SpreadOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadOption_theta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadOption",Description = "Reference to SpreadOption")>] 
         spreadoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadOption = Helper.toCell<SpreadOption> spreadoption "SpreadOption" true 
                let builder () = withMnemonic mnemonic ((_SpreadOption.cell :?> SpreadOptionModel).Theta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SpreadOption.source + ".Theta") 
                                               [| _SpreadOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadOption.cell
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
    [<ExcelFunction(Name="_SpreadOption_vega", Description="Create a SpreadOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadOption_vega
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadOption",Description = "Reference to SpreadOption")>] 
         spreadoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadOption = Helper.toCell<SpreadOption> spreadoption "SpreadOption" true 
                let builder () = withMnemonic mnemonic ((_SpreadOption.cell :?> SpreadOptionModel).Vega
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SpreadOption.source + ".Vega") 
                                               [| _SpreadOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadOption.cell
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
    [<ExcelFunction(Name="_SpreadOption_exercise", Description="Create a SpreadOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadOption_exercise
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadOption",Description = "Reference to SpreadOption")>] 
         spreadoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadOption = Helper.toCell<SpreadOption> spreadoption "SpreadOption" true 
                let builder () = withMnemonic mnemonic ((_SpreadOption.cell :?> SpreadOptionModel).Exercise
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Exercise>) l

                let source = Helper.sourceFold (_SpreadOption.source + ".Exercise") 
                                               [| _SpreadOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadOption.cell
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
    [<ExcelFunction(Name="_SpreadOption_payoff", Description="Create a SpreadOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadOption_payoff
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadOption",Description = "Reference to SpreadOption")>] 
         spreadoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadOption = Helper.toCell<SpreadOption> spreadoption "SpreadOption" true 
                let builder () = withMnemonic mnemonic ((_SpreadOption.cell :?> SpreadOptionModel).Payoff
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Payoff>) l

                let source = Helper.sourceFold (_SpreadOption.source + ".Payoff") 
                                               [| _SpreadOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadOption.cell
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
    [<ExcelFunction(Name="_SpreadOption_CASH", Description="Create a SpreadOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadOption_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadOption",Description = "Reference to SpreadOption")>] 
         spreadoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadOption = Helper.toCell<SpreadOption> spreadoption "SpreadOption" true 
                let builder () = withMnemonic mnemonic ((_SpreadOption.cell :?> SpreadOptionModel).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SpreadOption.source + ".CASH") 
                                               [| _SpreadOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadOption.cell
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
    [<ExcelFunction(Name="_SpreadOption_errorEstimate", Description="Create a SpreadOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadOption_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadOption",Description = "Reference to SpreadOption")>] 
         spreadoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadOption = Helper.toCell<SpreadOption> spreadoption "SpreadOption" true 
                let builder () = withMnemonic mnemonic ((_SpreadOption.cell :?> SpreadOptionModel).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SpreadOption.source + ".ErrorEstimate") 
                                               [| _SpreadOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadOption.cell
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
    [<ExcelFunction(Name="_SpreadOption_NPV", Description="Create a SpreadOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadOption_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadOption",Description = "Reference to SpreadOption")>] 
         spreadoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadOption = Helper.toCell<SpreadOption> spreadoption "SpreadOption" true 
                let builder () = withMnemonic mnemonic ((_SpreadOption.cell :?> SpreadOptionModel).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SpreadOption.source + ".NPV") 
                                               [| _SpreadOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadOption.cell
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
    [<ExcelFunction(Name="_SpreadOption_result", Description="Create a SpreadOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadOption_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadOption",Description = "Reference to SpreadOption")>] 
         spreadoption : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadOption = Helper.toCell<SpreadOption> spreadoption "SpreadOption" true 
                let _tag = Helper.toCell<string> tag "tag" true
                let builder () = withMnemonic mnemonic ((_SpreadOption.cell :?> SpreadOptionModel).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SpreadOption.source + ".Result") 
                                               [| _SpreadOption.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadOption.cell
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
    [<ExcelFunction(Name="_SpreadOption_setPricingEngine", Description="Create a SpreadOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadOption_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadOption",Description = "Reference to SpreadOption")>] 
         spreadoption : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadOption = Helper.toCell<SpreadOption> spreadoption "SpreadOption" true 
                let _e = Helper.toCell<IPricingEngine> e "e" true
                let builder () = withMnemonic mnemonic ((_SpreadOption.cell :?> SpreadOptionModel).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : SpreadOption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SpreadOption.source + ".SetPricingEngine") 
                                               [| _SpreadOption.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadOption.cell
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
    [<ExcelFunction(Name="_SpreadOption_valuationDate", Description="Create a SpreadOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadOption_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadOption",Description = "Reference to SpreadOption")>] 
         spreadoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadOption = Helper.toCell<SpreadOption> spreadoption "SpreadOption" true 
                let builder () = withMnemonic mnemonic ((_SpreadOption.cell :?> SpreadOptionModel).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_SpreadOption.source + ".ValuationDate") 
                                               [| _SpreadOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadOption.cell
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
    [<ExcelFunction(Name="_SpreadOption_Range", Description="Create a range of SpreadOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadOption_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the SpreadOption")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SpreadOption> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<SpreadOption>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<SpreadOption>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<SpreadOption>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"