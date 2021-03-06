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

  </summary> *)
[<AutoSerializable(true)>]
module RendistatoCalculatorFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_RendistatoCalculator_duration", Description="Create a RendistatoCalculator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RendistatoCalculator_duration
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RendistatoCalculator",Description = "RendistatoCalculator")>] 
         rendistatocalculator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RendistatoCalculator = Helper.toModelReference<RendistatoCalculator> rendistatocalculator "RendistatoCalculator"  
                let builder (current : ICell) = ((RendistatoCalculatorModel.Cast _RendistatoCalculator.cell).Duration
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RendistatoCalculator.source + ".Duration") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _RendistatoCalculator.cell
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
    [<ExcelFunction(Name="_RendistatoCalculator_durations", Description="Create a RendistatoCalculator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RendistatoCalculator_durations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RendistatoCalculator",Description = "RendistatoCalculator")>] 
         rendistatocalculator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RendistatoCalculator = Helper.toModelReference<RendistatoCalculator> rendistatocalculator "RendistatoCalculator"  
                let builder (current : ICell) = ((RendistatoCalculatorModel.Cast _RendistatoCalculator.cell).Durations
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_RendistatoCalculator.source + ".Durations") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _RendistatoCalculator.cell
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
    [<ExcelFunction(Name="_RendistatoCalculator_equivalentSwap", Description="Create a RendistatoCalculator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RendistatoCalculator_equivalentSwap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RendistatoCalculator",Description = "RendistatoCalculator")>] 
         rendistatocalculator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RendistatoCalculator = Helper.toModelReference<RendistatoCalculator> rendistatocalculator "RendistatoCalculator"  
                let builder (current : ICell) = ((RendistatoCalculatorModel.Cast _RendistatoCalculator.cell).EquivalentSwap
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<VanillaSwap>) l

                let source () = Helper.sourceFold (_RendistatoCalculator.source + ".EquivalentSwap") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _RendistatoCalculator.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<RendistatoCalculator> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_RendistatoCalculator_equivalentSwapDuration", Description="Create a RendistatoCalculator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RendistatoCalculator_equivalentSwapDuration
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RendistatoCalculator",Description = "RendistatoCalculator")>] 
         rendistatocalculator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RendistatoCalculator = Helper.toModelReference<RendistatoCalculator> rendistatocalculator "RendistatoCalculator"  
                let builder (current : ICell) = ((RendistatoCalculatorModel.Cast _RendistatoCalculator.cell).EquivalentSwapDuration
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RendistatoCalculator.source + ".EquivalentSwapDuration") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _RendistatoCalculator.cell
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
    [<ExcelFunction(Name="_RendistatoCalculator_equivalentSwapLength", Description="Create a RendistatoCalculator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RendistatoCalculator_equivalentSwapLength
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RendistatoCalculator",Description = "RendistatoCalculator")>] 
         rendistatocalculator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RendistatoCalculator = Helper.toModelReference<RendistatoCalculator> rendistatocalculator "RendistatoCalculator"  
                let builder (current : ICell) = ((RendistatoCalculatorModel.Cast _RendistatoCalculator.cell).EquivalentSwapLength
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RendistatoCalculator.source + ".EquivalentSwapLength") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _RendistatoCalculator.cell
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
    [<ExcelFunction(Name="_RendistatoCalculator_equivalentSwapRate", Description="Create a RendistatoCalculator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RendistatoCalculator_equivalentSwapRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RendistatoCalculator",Description = "RendistatoCalculator")>] 
         rendistatocalculator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RendistatoCalculator = Helper.toModelReference<RendistatoCalculator> rendistatocalculator "RendistatoCalculator"  
                let builder (current : ICell) = ((RendistatoCalculatorModel.Cast _RendistatoCalculator.cell).EquivalentSwapRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RendistatoCalculator.source + ".EquivalentSwapRate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _RendistatoCalculator.cell
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
    [<ExcelFunction(Name="_RendistatoCalculator_equivalentSwapSpread", Description="Create a RendistatoCalculator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RendistatoCalculator_equivalentSwapSpread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RendistatoCalculator",Description = "RendistatoCalculator")>] 
         rendistatocalculator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RendistatoCalculator = Helper.toModelReference<RendistatoCalculator> rendistatocalculator "RendistatoCalculator"  
                let builder (current : ICell) = ((RendistatoCalculatorModel.Cast _RendistatoCalculator.cell).EquivalentSwapSpread
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RendistatoCalculator.source + ".EquivalentSwapSpread") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _RendistatoCalculator.cell
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
    [<ExcelFunction(Name="_RendistatoCalculator_equivalentSwapYield", Description="Create a RendistatoCalculator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RendistatoCalculator_equivalentSwapYield
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RendistatoCalculator",Description = "RendistatoCalculator")>] 
         rendistatocalculator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RendistatoCalculator = Helper.toModelReference<RendistatoCalculator> rendistatocalculator "RendistatoCalculator"  
                let builder (current : ICell) = ((RendistatoCalculatorModel.Cast _RendistatoCalculator.cell).EquivalentSwapYield
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RendistatoCalculator.source + ".EquivalentSwapYield") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _RendistatoCalculator.cell
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
    [<ExcelFunction(Name="_RendistatoCalculator", Description="Create a RendistatoCalculator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RendistatoCalculator_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="basket",Description = "RendistatoBasket")>] 
         basket : obj)
        ([<ExcelArgument(Name="euriborIndex",Description = "Euribor")>] 
         euriborIndex : obj)
        ([<ExcelArgument(Name="discountCurve",Description = "YieldTermStructure")>] 
         discountCurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _basket = Helper.toCell<RendistatoBasket> basket "basket" 
                let _euriborIndex = Helper.toCell<Euribor> euriborIndex "euriborIndex" 
                let _discountCurve = Helper.toHandle<YieldTermStructure> discountCurve "discountCurve" 
                let builder (current : ICell) = (Fun.RendistatoCalculator 
                                                            _basket.cell 
                                                            _euriborIndex.cell 
                                                            _discountCurve.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RendistatoCalculator>) l

                let source () = Helper.sourceFold "Fun.RendistatoCalculator" 
                                               [| _basket.source
                                               ;  _euriborIndex.source
                                               ;  _discountCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _basket.cell
                                ;  _euriborIndex.cell
                                ;  _discountCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<RendistatoCalculator> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_RendistatoCalculator_swapDurations", Description="Create a RendistatoCalculator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RendistatoCalculator_swapDurations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RendistatoCalculator",Description = "RendistatoCalculator")>] 
         rendistatocalculator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RendistatoCalculator = Helper.toModelReference<RendistatoCalculator> rendistatocalculator "RendistatoCalculator"  
                let builder (current : ICell) = ((RendistatoCalculatorModel.Cast _RendistatoCalculator.cell).SwapDurations
                                                       ) :> ICell
                let format (i : Generic.List<Nullable<double>>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_RendistatoCalculator.source + ".SwapDurations") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _RendistatoCalculator.cell
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
        swaps
    *)
    [<ExcelFunction(Name="_RendistatoCalculator_swapLengths", Description="Create a RendistatoCalculator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RendistatoCalculator_swapLengths
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RendistatoCalculator",Description = "RendistatoCalculator")>] 
         rendistatocalculator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RendistatoCalculator = Helper.toModelReference<RendistatoCalculator> rendistatocalculator "RendistatoCalculator"  
                let builder (current : ICell) = ((RendistatoCalculatorModel.Cast _RendistatoCalculator.cell).SwapLengths
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_RendistatoCalculator.source + ".SwapLengths") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _RendistatoCalculator.cell
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
    [<ExcelFunction(Name="_RendistatoCalculator_swapRates", Description="Create a RendistatoCalculator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RendistatoCalculator_swapRates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RendistatoCalculator",Description = "RendistatoCalculator")>] 
         rendistatocalculator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RendistatoCalculator = Helper.toModelReference<RendistatoCalculator> rendistatocalculator "RendistatoCalculator"  
                let builder (current : ICell) = ((RendistatoCalculatorModel.Cast _RendistatoCalculator.cell).SwapRates
                                                       ) :> ICell
                let format (i : Generic.List<Nullable<double>>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_RendistatoCalculator.source + ".SwapRates") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _RendistatoCalculator.cell
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
    [<ExcelFunction(Name="_RendistatoCalculator_swapYields", Description="Create a RendistatoCalculator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RendistatoCalculator_swapYields
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RendistatoCalculator",Description = "RendistatoCalculator")>] 
         rendistatocalculator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RendistatoCalculator = Helper.toModelReference<RendistatoCalculator> rendistatocalculator "RendistatoCalculator"  
                let builder (current : ICell) = ((RendistatoCalculatorModel.Cast _RendistatoCalculator.cell).SwapYields
                                                       ) :> ICell
                let format (i : Generic.List<Nullable<double>>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_RendistatoCalculator.source + ".SwapYields") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _RendistatoCalculator.cell
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
    [<ExcelFunction(Name="_RendistatoCalculator_yield", Description="Create a RendistatoCalculator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RendistatoCalculator_yield
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RendistatoCalculator",Description = "RendistatoCalculator")>] 
         rendistatocalculator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RendistatoCalculator = Helper.toModelReference<RendistatoCalculator> rendistatocalculator "RendistatoCalculator"  
                let builder (current : ICell) = ((RendistatoCalculatorModel.Cast _RendistatoCalculator.cell).Yield
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RendistatoCalculator.source + ".Yield") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _RendistatoCalculator.cell
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
        bonds
    *)
    [<ExcelFunction(Name="_RendistatoCalculator_yields", Description="Create a RendistatoCalculator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RendistatoCalculator_yields
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RendistatoCalculator",Description = "RendistatoCalculator")>] 
         rendistatocalculator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RendistatoCalculator = Helper.toModelReference<RendistatoCalculator> rendistatocalculator "RendistatoCalculator"  
                let builder (current : ICell) = ((RendistatoCalculatorModel.Cast _RendistatoCalculator.cell).Yields
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_RendistatoCalculator.source + ".Yields") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _RendistatoCalculator.cell
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
    [<ExcelFunction(Name="_RendistatoCalculator_Range", Description="Create a range of RendistatoCalculator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RendistatoCalculator_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<RendistatoCalculator> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<RendistatoCalculator> (c)) :> ICell
                let format (i : Cephei.Cell.List<RendistatoCalculator>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<RendistatoCalculator>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
