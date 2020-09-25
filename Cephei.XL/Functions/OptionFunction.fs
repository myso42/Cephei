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
  base option class
  </summary> *)
[<AutoSerializable(true)>]
module OptionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Option_exercise", Description="Create a Option",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Option_exercise
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Option",Description = "Reference to Option")>] 
         option : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Option = Helper.toCell<Option> option "Option" true 
                let builder () = withMnemonic mnemonic ((_Option.cell :?> OptionModel).Exercise
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Exercise>) l

                let source = Helper.sourceFold (_Option.source + ".Exercise") 
                                               [| _Option.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Option.cell
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
    [<ExcelFunction(Name="_Option", Description="Create a Option",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Option_create
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

                let _payoff = Helper.toCell<Payoff> payoff "payoff" true
                let _exercise = Helper.toCell<Exercise> exercise "exercise" true
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine" true 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate" true 
                let builder () = withMnemonic mnemonic (Fun.Option 
                                                            _payoff.cell 
                                                            _exercise.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Option>) l

                let source = Helper.sourceFold "Fun.Option" 
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
        
    *)
    [<ExcelFunction(Name="_Option_payoff", Description="Create a Option",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Option_payoff
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Option",Description = "Reference to Option")>] 
         option : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Option = Helper.toCell<Option> option "Option" true 
                let builder () = withMnemonic mnemonic ((_Option.cell :?> OptionModel).Payoff
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Payoff>) l

                let source = Helper.sourceFold (_Option.source + ".Payoff") 
                                               [| _Option.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Option.cell
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
    [<ExcelFunction(Name="_Option_CASH", Description="Create a Option",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Option_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Option",Description = "Reference to Option")>] 
         option : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Option = Helper.toCell<Option> option "Option" true 
                let builder () = withMnemonic mnemonic ((_Option.cell :?> OptionModel).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Option.source + ".CASH") 
                                               [| _Option.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Option.cell
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
    [<ExcelFunction(Name="_Option_errorEstimate", Description="Create a Option",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Option_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Option",Description = "Reference to Option")>] 
         option : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Option = Helper.toCell<Option> option "Option" true 
                let builder () = withMnemonic mnemonic ((_Option.cell :?> OptionModel).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Option.source + ".ErrorEstimate") 
                                               [| _Option.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Option.cell
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
        ! returns whether the instrument is still tradable.
    *)
    [<ExcelFunction(Name="_Option_isExpired", Description="Create a Option",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Option_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Option",Description = "Reference to Option")>] 
         option : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Option = Helper.toCell<Option> option "Option" true 
                let builder () = withMnemonic mnemonic ((_Option.cell :?> OptionModel).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Option.source + ".IsExpired") 
                                               [| _Option.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Option.cell
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
    [<ExcelFunction(Name="_Option_NPV", Description="Create a Option",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Option_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Option",Description = "Reference to Option")>] 
         option : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Option = Helper.toCell<Option> option "Option" true 
                let builder () = withMnemonic mnemonic ((_Option.cell :?> OptionModel).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Option.source + ".NPV") 
                                               [| _Option.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Option.cell
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
    [<ExcelFunction(Name="_Option_result", Description="Create a Option",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Option_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Option",Description = "Reference to Option")>] 
         option : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Option = Helper.toCell<Option> option "Option" true 
                let _tag = Helper.toCell<string> tag "tag" true
                let builder () = withMnemonic mnemonic ((_Option.cell :?> OptionModel).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Option.source + ".Result") 
                                               [| _Option.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Option.cell
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
    [<ExcelFunction(Name="_Option_setPricingEngine", Description="Create a Option",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Option_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Option",Description = "Reference to Option")>] 
         option : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Option = Helper.toCell<Option> option "Option" true 
                let _e = Helper.toCell<IPricingEngine> e "e" true
                let builder () = withMnemonic mnemonic ((_Option.cell :?> OptionModel).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : Option) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Option.source + ".SetPricingEngine") 
                                               [| _Option.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Option.cell
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
    [<ExcelFunction(Name="_Option_valuationDate", Description="Create a Option",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Option_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Option",Description = "Reference to Option")>] 
         option : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Option = Helper.toCell<Option> option "Option" true 
                let builder () = withMnemonic mnemonic ((_Option.cell :?> OptionModel).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Option.source + ".ValuationDate") 
                                               [| _Option.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Option.cell
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
    [<ExcelFunction(Name="_Option_Range", Description="Create a range of Option",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Option_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Option")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Option> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Option>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Option>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Option>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"