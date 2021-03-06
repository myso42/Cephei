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
  if <tt>Settings::includeReferenceDateCashFlows()</tt> is set to <tt>true</tt>, payments occurring at the settlement date of the swap might be included in the NPV and therefore affect the fair-rate and fair-spread calculation. This might not be what you want.  - the correctness of the returned value is tested by checking - that the price of a swap paying the fair fixed rate is null. - that the price of a swap receiving the fair floating-rate spread is null. - that the price of a swap decreases with the paid fixed rate. - that the price of a swap increases with the received floating-rate spread. - the correctness of the returned value is tested by checking it against a known good value.
  </summary> *)
[<AutoSerializable(true)>]
module VanillaSwapFunction =

    (*
        results
    *)
    [<ExcelFunction(Name="_VanillaSwap_fairRate", Description="Create a VanillaSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaSwap_fairRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaSwap",Description = "VanillaSwap")>] 
         vanillaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaSwap = Helper.toModelReference<VanillaSwap> vanillaswap "VanillaSwap"  
                let builder (current : ICell) = ((VanillaSwapModel.Cast _VanillaSwap.cell).FairRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_VanillaSwap.source + ".FairRate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _VanillaSwap.cell
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
    [<ExcelFunction(Name="_VanillaSwap_fairSpread", Description="Create a VanillaSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaSwap_fairSpread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaSwap",Description = "VanillaSwap")>] 
         vanillaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaSwap = Helper.toModelReference<VanillaSwap> vanillaswap "VanillaSwap"  
                let builder (current : ICell) = ((VanillaSwapModel.Cast _VanillaSwap.cell).FairSpread
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_VanillaSwap.source + ".FairSpread") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _VanillaSwap.cell
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
    [<ExcelFunction(Name="_VanillaSwap_fixedDayCount", Description="Create a VanillaSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaSwap_fixedDayCount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaSwap",Description = "VanillaSwap")>] 
         vanillaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaSwap = Helper.toModelReference<VanillaSwap> vanillaswap "VanillaSwap"  
                let builder (current : ICell) = ((VanillaSwapModel.Cast _VanillaSwap.cell).FixedDayCount
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_VanillaSwap.source + ".FixedDayCount") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _VanillaSwap.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<VanillaSwap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_VanillaSwap_fixedLeg", Description="Create a VanillaSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaSwap_fixedLeg
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaSwap",Description = "VanillaSwap")>] 
         vanillaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaSwap = Helper.toModelReference<VanillaSwap> vanillaswap "VanillaSwap"  
                let builder (current : ICell) = ((VanillaSwapModel.Cast _VanillaSwap.cell).FixedLeg
                                                       ) :> ICell
                let format (i : Generic.List<CashFlow>) (l : string) = Helper.Range.fromList i l

                let source () = Helper.sourceFold (_VanillaSwap.source + ".FixedLeg") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _VanillaSwap.cell
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
    [<ExcelFunction(Name="_VanillaSwap_fixedLegBPS", Description="Create a VanillaSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaSwap_fixedLegBPS
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaSwap",Description = "VanillaSwap")>] 
         vanillaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaSwap = Helper.toModelReference<VanillaSwap> vanillaswap "VanillaSwap"  
                let builder (current : ICell) = ((VanillaSwapModel.Cast _VanillaSwap.cell).FixedLegBPS
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_VanillaSwap.source + ".FixedLegBPS") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _VanillaSwap.cell
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
    [<ExcelFunction(Name="_VanillaSwap_fixedLegNPV", Description="Create a VanillaSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaSwap_fixedLegNPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaSwap",Description = "VanillaSwap")>] 
         vanillaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaSwap = Helper.toModelReference<VanillaSwap> vanillaswap "VanillaSwap"  
                let builder (current : ICell) = ((VanillaSwapModel.Cast _VanillaSwap.cell).FixedLegNPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_VanillaSwap.source + ".FixedLegNPV") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _VanillaSwap.cell
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
    [<ExcelFunction(Name="_VanillaSwap_fixedRate", Description="Create a VanillaSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaSwap_fixedRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaSwap",Description = "VanillaSwap")>] 
         vanillaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaSwap = Helper.toModelReference<VanillaSwap> vanillaswap "VanillaSwap"  
                let builder (current : ICell) = ((VanillaSwapModel.Cast _VanillaSwap.cell).FixedRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_VanillaSwap.source + ".FixedRate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _VanillaSwap.cell
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
    [<ExcelFunction(Name="_VanillaSwap_fixedSchedule", Description="Create a VanillaSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaSwap_fixedSchedule
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaSwap",Description = "VanillaSwap")>] 
         vanillaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaSwap = Helper.toModelReference<VanillaSwap> vanillaswap "VanillaSwap"  
                let builder (current : ICell) = ((VanillaSwapModel.Cast _VanillaSwap.cell).FixedSchedule
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Schedule>) l

                let source () = Helper.sourceFold (_VanillaSwap.source + ".FixedSchedule") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _VanillaSwap.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<VanillaSwap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_VanillaSwap_floatingDayCount", Description="Create a VanillaSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaSwap_floatingDayCount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaSwap",Description = "VanillaSwap")>] 
         vanillaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaSwap = Helper.toModelReference<VanillaSwap> vanillaswap "VanillaSwap"  
                let builder (current : ICell) = ((VanillaSwapModel.Cast _VanillaSwap.cell).FloatingDayCount
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_VanillaSwap.source + ".FloatingDayCount") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _VanillaSwap.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<VanillaSwap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_VanillaSwap_floatingLeg", Description="Create a VanillaSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaSwap_floatingLeg
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaSwap",Description = "VanillaSwap")>] 
         vanillaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaSwap = Helper.toModelReference<VanillaSwap> vanillaswap "VanillaSwap"  
                let builder (current : ICell) = ((VanillaSwapModel.Cast _VanillaSwap.cell).FloatingLeg
                                                       ) :> ICell
                let format (i : Generic.List<CashFlow>) (l : string) = Helper.Range.fromList i l

                let source () = Helper.sourceFold (_VanillaSwap.source + ".FloatingLeg") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _VanillaSwap.cell
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
    [<ExcelFunction(Name="_VanillaSwap_floatingLegBPS", Description="Create a VanillaSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaSwap_floatingLegBPS
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaSwap",Description = "VanillaSwap")>] 
         vanillaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaSwap = Helper.toModelReference<VanillaSwap> vanillaswap "VanillaSwap"  
                let builder (current : ICell) = ((VanillaSwapModel.Cast _VanillaSwap.cell).FloatingLegBPS
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_VanillaSwap.source + ".FloatingLegBPS") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _VanillaSwap.cell
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
    [<ExcelFunction(Name="_VanillaSwap_floatingLegNPV", Description="Create a VanillaSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaSwap_floatingLegNPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaSwap",Description = "VanillaSwap")>] 
         vanillaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaSwap = Helper.toModelReference<VanillaSwap> vanillaswap "VanillaSwap"  
                let builder (current : ICell) = ((VanillaSwapModel.Cast _VanillaSwap.cell).FloatingLegNPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_VanillaSwap.source + ".FloatingLegNPV") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _VanillaSwap.cell
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
    [<ExcelFunction(Name="_VanillaSwap_floatingSchedule", Description="Create a VanillaSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaSwap_floatingSchedule
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaSwap",Description = "VanillaSwap")>] 
         vanillaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaSwap = Helper.toModelReference<VanillaSwap> vanillaswap "VanillaSwap"  
                let builder (current : ICell) = ((VanillaSwapModel.Cast _VanillaSwap.cell).FloatingSchedule
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Schedule>) l

                let source () = Helper.sourceFold (_VanillaSwap.source + ".FloatingSchedule") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _VanillaSwap.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<VanillaSwap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_VanillaSwap_iborIndex", Description="Create a VanillaSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaSwap_iborIndex
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaSwap",Description = "VanillaSwap")>] 
         vanillaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaSwap = Helper.toModelReference<VanillaSwap> vanillaswap "VanillaSwap"  
                let builder (current : ICell) = ((VanillaSwapModel.Cast _VanillaSwap.cell).IborIndex
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source () = Helper.sourceFold (_VanillaSwap.source + ".IborIndex") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _VanillaSwap.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<VanillaSwap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_VanillaSwap_nominal", Description="Create a VanillaSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaSwap_nominal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaSwap",Description = "VanillaSwap")>] 
         vanillaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaSwap = Helper.toModelReference<VanillaSwap> vanillaswap "VanillaSwap"  
                let builder (current : ICell) = ((VanillaSwapModel.Cast _VanillaSwap.cell).Nominal
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_VanillaSwap.source + ".Nominal") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _VanillaSwap.cell
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
    [<ExcelFunction(Name="_VanillaSwap_spread", Description="Create a VanillaSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaSwap_spread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaSwap",Description = "VanillaSwap")>] 
         vanillaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaSwap = Helper.toModelReference<VanillaSwap> vanillaswap "VanillaSwap"  
                let builder (current : ICell) = ((VanillaSwapModel.Cast _VanillaSwap.cell).Spread
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_VanillaSwap.source + ".Spread") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _VanillaSwap.cell
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
    [<ExcelFunction(Name="_VanillaSwap_swapType", Description="Create a VanillaSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaSwap_swapType
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaSwap",Description = "VanillaSwap")>] 
         vanillaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaSwap = Helper.toModelReference<VanillaSwap> vanillaswap "VanillaSwap"  
                let builder (current : ICell) = ((VanillaSwapModel.Cast _VanillaSwap.cell).SwapType
                                                       ) :> ICell
                let format (o : Type) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_VanillaSwap.source + ".SwapType") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _VanillaSwap.cell
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
        constructor
    *)
    [<ExcelFunction(Name="_VanillaSwap", Description="Create a VanillaSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaSwap_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Type",Description = "VanillaSwap.Type: Receiver, Payer")>] 
         Type : obj)
        ([<ExcelArgument(Name="nominal",Description = "double")>] 
         nominal : obj)
        ([<ExcelArgument(Name="fixedSchedule",Description = "Schedule")>] 
         fixedSchedule : obj)
        ([<ExcelArgument(Name="fixedRate",Description = "double")>] 
         fixedRate : obj)
        ([<ExcelArgument(Name="fixedDayCount",Description = "DayCounter")>] 
         fixedDayCount : obj)
        ([<ExcelArgument(Name="floatSchedule",Description = "Schedule")>] 
         floatSchedule : obj)
        ([<ExcelArgument(Name="iborIndex",Description = "IborIndex")>] 
         iborIndex : obj)
        ([<ExcelArgument(Name="spread",Description = "double")>] 
         spread : obj)
        ([<ExcelArgument(Name="floatingDayCount",Description = "DayCounter")>] 
         floatingDayCount : obj)
        ([<ExcelArgument(Name="paymentConvention",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         paymentConvention : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "IPricingEngine")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Type = Helper.toCell<VanillaSwap.Type> Type "Type" 
                let _nominal = Helper.toCell<double> nominal "nominal" 
                let _fixedSchedule = Helper.toCell<Schedule> fixedSchedule "fixedSchedule" 
                let _fixedRate = Helper.toCell<double> fixedRate "fixedRate" 
                let _fixedDayCount = Helper.toCell<DayCounter> fixedDayCount "fixedDayCount" 
                let _floatSchedule = Helper.toCell<Schedule> floatSchedule "floatSchedule" 
                let _iborIndex = Helper.toCell<IborIndex> iborIndex "iborIndex" 
                let _spread = Helper.toCell<double> spread "spread" 
                let _floatingDayCount = Helper.toCell<DayCounter> floatingDayCount "floatingDayCount" 
                let _paymentConvention = Helper.toNullable<BusinessDayConvention> paymentConvention "paymentConvention"
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = (Fun.VanillaSwap 
                                                            _Type.cell 
                                                            _nominal.cell 
                                                            _fixedSchedule.cell 
                                                            _fixedRate.cell 
                                                            _fixedDayCount.cell 
                                                            _floatSchedule.cell 
                                                            _iborIndex.cell 
                                                            _spread.cell 
                                                            _floatingDayCount.cell 
                                                            _paymentConvention.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<VanillaSwap>) l

                let source () = Helper.sourceFold "Fun.VanillaSwap" 
                                               [| _Type.source
                                               ;  _nominal.source
                                               ;  _fixedSchedule.source
                                               ;  _fixedRate.source
                                               ;  _fixedDayCount.source
                                               ;  _floatSchedule.source
                                               ;  _iborIndex.source
                                               ;  _spread.source
                                               ;  _floatingDayCount.source
                                               ;  _paymentConvention.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Type.cell
                                ;  _nominal.cell
                                ;  _fixedSchedule.cell
                                ;  _fixedRate.cell
                                ;  _fixedDayCount.cell
                                ;  _floatSchedule.cell
                                ;  _iborIndex.cell
                                ;  _spread.cell
                                ;  _floatingDayCount.cell
                                ;  _paymentConvention.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<VanillaSwap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_VanillaSwap_endDiscounts", Description="Create a VanillaSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaSwap_endDiscounts
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaSwap",Description = "VanillaSwap")>] 
         vanillaswap : obj)
        ([<ExcelArgument(Name="j",Description = "int")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaSwap = Helper.toModelReference<VanillaSwap> vanillaswap "VanillaSwap"  
                let _j = Helper.toCell<int> j "j" 
                let builder (current : ICell) = ((VanillaSwapModel.Cast _VanillaSwap.cell).EndDiscounts
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_VanillaSwap.source + ".EndDiscounts") 

                                               [| _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VanillaSwap.cell
                                ;  _j.cell
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
    (*!!
    [<ExcelFunction(Name="_VanillaSwap_engine", Description="Create a VanillaSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaSwap_engine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaSwap",Description = "VanillaSwap")>] 
         vanillaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaSwap = Helper.toModelReference<VanillaSwap> vanillaswap "VanillaSwap"  
                let builder (current : ICell) = ((VanillaSwapModel.Cast _VanillaSwap.cell).Engine
                                                       ) :> ICell
                let format (o : SwapEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_VanillaSwap.source + ".Engine") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _VanillaSwap.cell
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
            *)
    (*
        
    *)
    [<ExcelFunction(Name="_VanillaSwap_isExpired", Description="Create a VanillaSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaSwap_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaSwap",Description = "VanillaSwap")>] 
         vanillaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaSwap = Helper.toModelReference<VanillaSwap> vanillaswap "VanillaSwap"  
                let builder (current : ICell) = ((VanillaSwapModel.Cast _VanillaSwap.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_VanillaSwap.source + ".IsExpired") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _VanillaSwap.cell
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
    [<ExcelFunction(Name="_VanillaSwap_leg", Description="Create a VanillaSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaSwap_leg
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaSwap",Description = "VanillaSwap")>] 
         vanillaswap : obj)
        ([<ExcelArgument(Name="j",Description = "int")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaSwap = Helper.toModelReference<VanillaSwap> vanillaswap "VanillaSwap"  
                let _j = Helper.toCell<int> j "j" 
                let builder (current : ICell) = ((VanillaSwapModel.Cast _VanillaSwap.cell).Leg
                                                            _j.cell 
                                                       ) :> ICell
                let format (i : Generic.List<CashFlow>) (l : string) = Helper.Range.fromList i l

                let source () = Helper.sourceFold (_VanillaSwap.source + ".Leg") 

                                               [| _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VanillaSwap.cell
                                ;  _j.cell
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
    [<ExcelFunction(Name="_VanillaSwap_legBPS", Description="Create a VanillaSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaSwap_legBPS
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaSwap",Description = "VanillaSwap")>] 
         vanillaswap : obj)
        ([<ExcelArgument(Name="j",Description = "int")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaSwap = Helper.toModelReference<VanillaSwap> vanillaswap "VanillaSwap"  
                let _j = Helper.toCell<int> j "j" 
                let builder (current : ICell) = ((VanillaSwapModel.Cast _VanillaSwap.cell).LegBPS
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_VanillaSwap.source + ".LegBPS") 

                                               [| _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VanillaSwap.cell
                                ;  _j.cell
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
    [<ExcelFunction(Name="_VanillaSwap_legNPV", Description="Create a VanillaSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaSwap_legNPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaSwap",Description = "VanillaSwap")>] 
         vanillaswap : obj)
        ([<ExcelArgument(Name="j",Description = "int")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaSwap = Helper.toModelReference<VanillaSwap> vanillaswap "VanillaSwap"  
                let _j = Helper.toCell<int> j "j" 
                let builder (current : ICell) = ((VanillaSwapModel.Cast _VanillaSwap.cell).LegNPV
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_VanillaSwap.source + ".LegNPV") 

                                               [| _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VanillaSwap.cell
                                ;  _j.cell
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
    [<ExcelFunction(Name="_VanillaSwap_maturityDate", Description="Create a VanillaSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaSwap_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaSwap",Description = "VanillaSwap")>] 
         vanillaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaSwap = Helper.toModelReference<VanillaSwap> vanillaswap "VanillaSwap"  
                let builder (current : ICell) = ((VanillaSwapModel.Cast _VanillaSwap.cell).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_VanillaSwap.source + ".MaturityDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _VanillaSwap.cell
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
    [<ExcelFunction(Name="_VanillaSwap_npvDateDiscount", Description="Create a VanillaSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaSwap_npvDateDiscount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaSwap",Description = "VanillaSwap")>] 
         vanillaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaSwap = Helper.toModelReference<VanillaSwap> vanillaswap "VanillaSwap"  
                let builder (current : ICell) = ((VanillaSwapModel.Cast _VanillaSwap.cell).NpvDateDiscount
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_VanillaSwap.source + ".NpvDateDiscount") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _VanillaSwap.cell
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
    [<ExcelFunction(Name="_VanillaSwap_payer", Description="Create a VanillaSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaSwap_payer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaSwap",Description = "VanillaSwap")>] 
         vanillaswap : obj)
        ([<ExcelArgument(Name="j",Description = "int")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaSwap = Helper.toModelReference<VanillaSwap> vanillaswap "VanillaSwap"  
                let _j = Helper.toCell<int> j "j" 
                let builder (current : ICell) = ((VanillaSwapModel.Cast _VanillaSwap.cell).Payer
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_VanillaSwap.source + ".Payer") 

                                               [| _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VanillaSwap.cell
                                ;  _j.cell
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
    [<ExcelFunction(Name="_VanillaSwap_startDate", Description="Create a VanillaSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaSwap_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaSwap",Description = "VanillaSwap")>] 
         vanillaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaSwap = Helper.toModelReference<VanillaSwap> vanillaswap "VanillaSwap"  
                let builder (current : ICell) = ((VanillaSwapModel.Cast _VanillaSwap.cell).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_VanillaSwap.source + ".StartDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _VanillaSwap.cell
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
    [<ExcelFunction(Name="_VanillaSwap_startDiscounts", Description="Create a VanillaSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaSwap_startDiscounts
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaSwap",Description = "VanillaSwap")>] 
         vanillaswap : obj)
        ([<ExcelArgument(Name="j",Description = "int")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaSwap = Helper.toModelReference<VanillaSwap> vanillaswap "VanillaSwap"  
                let _j = Helper.toCell<int> j "j" 
                let builder (current : ICell) = ((VanillaSwapModel.Cast _VanillaSwap.cell).StartDiscounts
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_VanillaSwap.source + ".StartDiscounts") 

                                               [| _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VanillaSwap.cell
                                ;  _j.cell
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
    [<ExcelFunction(Name="_VanillaSwap_CASH", Description="Create a VanillaSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaSwap_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaSwap",Description = "VanillaSwap")>] 
         vanillaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaSwap = Helper.toModelReference<VanillaSwap> vanillaswap "VanillaSwap"  
                let builder (current : ICell) = ((VanillaSwapModel.Cast _VanillaSwap.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_VanillaSwap.source + ".CASH") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _VanillaSwap.cell
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
    [<ExcelFunction(Name="_VanillaSwap_errorEstimate", Description="Create a VanillaSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaSwap_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaSwap",Description = "VanillaSwap")>] 
         vanillaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaSwap = Helper.toModelReference<VanillaSwap> vanillaswap "VanillaSwap"  
                let builder (current : ICell) = ((VanillaSwapModel.Cast _VanillaSwap.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_VanillaSwap.source + ".ErrorEstimate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _VanillaSwap.cell
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
    [<ExcelFunction(Name="_VanillaSwap_NPV", Description="Create a VanillaSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaSwap_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaSwap",Description = "VanillaSwap")>] 
         vanillaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaSwap = Helper.toModelReference<VanillaSwap> vanillaswap "VanillaSwap"  
                let builder (current : ICell) = ((VanillaSwapModel.Cast _VanillaSwap.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_VanillaSwap.source + ".NPV") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _VanillaSwap.cell
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
    [<ExcelFunction(Name="_VanillaSwap_result", Description="Create a VanillaSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaSwap_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaSwap",Description = "VanillaSwap")>] 
         vanillaswap : obj)
        ([<ExcelArgument(Name="tag",Description = "string")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaSwap = Helper.toModelReference<VanillaSwap> vanillaswap "VanillaSwap"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder (current : ICell) = ((VanillaSwapModel.Cast _VanillaSwap.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_VanillaSwap.source + ".Result") 

                                               [| _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VanillaSwap.cell
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
    [<ExcelFunction(Name="_VanillaSwap_setPricingEngine", Description="Create a VanillaSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaSwap_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaSwap",Description = "VanillaSwap")>] 
         vanillaswap : obj)
        ([<ExcelArgument(Name="e",Description = "IPricingEngine")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaSwap = Helper.toModelReference<VanillaSwap> vanillaswap "VanillaSwap"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder (current : ICell) = ((VanillaSwapModel.Cast _VanillaSwap.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : VanillaSwap) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_VanillaSwap.source + ".SetPricingEngine") 

                                               [| _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VanillaSwap.cell
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
    [<ExcelFunction(Name="_VanillaSwap_valuationDate", Description="Create a VanillaSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaSwap_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaSwap",Description = "VanillaSwap")>] 
         vanillaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaSwap = Helper.toModelReference<VanillaSwap> vanillaswap "VanillaSwap"  
                let builder (current : ICell) = ((VanillaSwapModel.Cast _VanillaSwap.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_VanillaSwap.source + ".ValuationDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _VanillaSwap.cell
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
    [<ExcelFunction(Name="_VanillaSwap_Range", Description="Create a range of VanillaSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaSwap_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<VanillaSwap> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<VanillaSwap> (c)) :> ICell
                let format (i : Cephei.Cell.List<VanillaSwap>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<VanillaSwap>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
