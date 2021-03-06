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
module JpyLiborSwapIsdaFixPmFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixPm", Description="Create a JpyLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixPm_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="tenor",Description = "Period")>] 
         tenor : obj)
        ([<ExcelArgument(Name="h",Description = "YieldTermStructure")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let builder (current : ICell) = (Fun.JpyLiborSwapIsdaFixPm 
                                                            _tenor.cell 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<JpyLiborSwapIsdaFixPm>) l

                let source () = Helper.sourceFold "Fun.JpyLiborSwapIsdaFixPm" 
                                               [| _tenor.source
                                               ;  _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _tenor.cell
                                ;  _h.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<JpyLiborSwapIsdaFixPm> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixPm1", Description="Create a JpyLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixPm_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="tenor",Description = "Period")>] 
         tenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let builder (current : ICell) = (Fun.JpyLiborSwapIsdaFixPm1 
                                                            _tenor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<JpyLiborSwapIsdaFixPm>) l

                let source () = Helper.sourceFold "Fun.JpyLiborSwapIsdaFixPm1" 
                                               [| _tenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _tenor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<JpyLiborSwapIsdaFixPm> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! returns a copy of itself linked to a different tenor
    *)
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixPm_clone", Description="Create a JpyLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixPm_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixPm",Description = "JpyLiborSwapIsdaFixPm")>] 
         jpyliborswapisdafixpm : obj)
        ([<ExcelArgument(Name="tenor",Description = "Period")>] 
         tenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixPm = Helper.toModelReference<JpyLiborSwapIsdaFixPm> jpyliborswapisdafixpm "JpyLiborSwapIsdaFixPm"  
                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let builder (current : ICell) = ((JpyLiborSwapIsdaFixPmModel.Cast _JpyLiborSwapIsdaFixPm.cell).Clone
                                                            _tenor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source () = Helper.sourceFold (_JpyLiborSwapIsdaFixPm.source + ".Clone") 

                                               [| _tenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixPm.cell
                                ;  _tenor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<JpyLiborSwapIsdaFixPm> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! returns a copy of itself linked to a different curves
    *)
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixPm_clone1", Description="Create a JpyLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixPm_clone1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixPm",Description = "JpyLiborSwapIsdaFixPm")>] 
         jpyliborswapisdafixpm : obj)
        ([<ExcelArgument(Name="forwarding",Description = "YieldTermStructure")>] 
         forwarding : obj)
        ([<ExcelArgument(Name="discounting",Description = "YieldTermStructure")>] 
         discounting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixPm = Helper.toModelReference<JpyLiborSwapIsdaFixPm> jpyliborswapisdafixpm "JpyLiborSwapIsdaFixPm"  
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let _discounting = Helper.toHandle<YieldTermStructure> discounting "discounting" 
                let builder (current : ICell) = ((JpyLiborSwapIsdaFixPmModel.Cast _JpyLiborSwapIsdaFixPm.cell).Clone1
                                                            _forwarding.cell 
                                                            _discounting.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source () = Helper.sourceFold (_JpyLiborSwapIsdaFixPm.source + ".Clone1") 

                                               [| _forwarding.source
                                               ;  _discounting.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixPm.cell
                                ;  _forwarding.cell
                                ;  _discounting.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<JpyLiborSwapIsdaFixPm> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Other methods returns a copy of itself linked to a different forwarding curve
    *)
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixPm_clone2", Description="Create a JpyLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixPm_clone2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixPm",Description = "JpyLiborSwapIsdaFixPm")>] 
         jpyliborswapisdafixpm : obj)
        ([<ExcelArgument(Name="forwarding",Description = "YieldTermStructure")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixPm = Helper.toModelReference<JpyLiborSwapIsdaFixPm> jpyliborswapisdafixpm "JpyLiborSwapIsdaFixPm"  
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let builder (current : ICell) = ((JpyLiborSwapIsdaFixPmModel.Cast _JpyLiborSwapIsdaFixPm.cell).Clone2
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source () = Helper.sourceFold (_JpyLiborSwapIsdaFixPm.source + ".Clone2") 

                                               [| _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixPm.cell
                                ;  _forwarding.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<JpyLiborSwapIsdaFixPm> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixPm_discountingTermStructure", Description="Create a JpyLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixPm_discountingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixPm",Description = "JpyLiborSwapIsdaFixPm")>] 
         jpyliborswapisdafixpm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixPm = Helper.toModelReference<JpyLiborSwapIsdaFixPm> jpyliborswapisdafixpm "JpyLiborSwapIsdaFixPm"  
                let builder (current : ICell) = ((JpyLiborSwapIsdaFixPmModel.Cast _JpyLiborSwapIsdaFixPm.cell).DiscountingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_JpyLiborSwapIsdaFixPm.source + ".DiscountingTermStructure") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixPm.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<JpyLiborSwapIsdaFixPm> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixPm_exogenousDiscount", Description="Create a JpyLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixPm_exogenousDiscount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixPm",Description = "JpyLiborSwapIsdaFixPm")>] 
         jpyliborswapisdafixpm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixPm = Helper.toModelReference<JpyLiborSwapIsdaFixPm> jpyliborswapisdafixpm "JpyLiborSwapIsdaFixPm"  
                let builder (current : ICell) = ((JpyLiborSwapIsdaFixPmModel.Cast _JpyLiborSwapIsdaFixPm.cell).ExogenousDiscount
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_JpyLiborSwapIsdaFixPm.source + ".ExogenousDiscount") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixPm_fixedLegConvention", Description="Create a JpyLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixPm_fixedLegConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixPm",Description = "JpyLiborSwapIsdaFixPm")>] 
         jpyliborswapisdafixpm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixPm = Helper.toModelReference<JpyLiborSwapIsdaFixPm> jpyliborswapisdafixpm "JpyLiborSwapIsdaFixPm"  
                let builder (current : ICell) = ((JpyLiborSwapIsdaFixPmModel.Cast _JpyLiborSwapIsdaFixPm.cell).FixedLegConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_JpyLiborSwapIsdaFixPm.source + ".FixedLegConvention") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixPm.cell
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
        Inspectors
    *)
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixPm_fixedLegTenor", Description="Create a JpyLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixPm_fixedLegTenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixPm",Description = "JpyLiborSwapIsdaFixPm")>] 
         jpyliborswapisdafixpm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixPm = Helper.toModelReference<JpyLiborSwapIsdaFixPm> jpyliborswapisdafixpm "JpyLiborSwapIsdaFixPm"  
                let builder (current : ICell) = ((JpyLiborSwapIsdaFixPmModel.Cast _JpyLiborSwapIsdaFixPm.cell).FixedLegTenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_JpyLiborSwapIsdaFixPm.source + ".FixedLegTenor") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixPm.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<JpyLiborSwapIsdaFixPm> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixPm_forecastFixing", Description="Create a JpyLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixPm_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixPm",Description = "JpyLiborSwapIsdaFixPm")>] 
         jpyliborswapisdafixpm : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixPm = Helper.toModelReference<JpyLiborSwapIsdaFixPm> jpyliborswapisdafixpm "JpyLiborSwapIsdaFixPm"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = ((JpyLiborSwapIsdaFixPmModel.Cast _JpyLiborSwapIsdaFixPm.cell).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_JpyLiborSwapIsdaFixPm.source + ".ForecastFixing") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixPm.cell
                                ;  _fixingDate.cell
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
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixPm_forwardingTermStructure", Description="Create a JpyLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixPm_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixPm",Description = "JpyLiborSwapIsdaFixPm")>] 
         jpyliborswapisdafixpm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixPm = Helper.toModelReference<JpyLiborSwapIsdaFixPm> jpyliborswapisdafixpm "JpyLiborSwapIsdaFixPm"  
                let builder (current : ICell) = ((JpyLiborSwapIsdaFixPmModel.Cast _JpyLiborSwapIsdaFixPm.cell).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_JpyLiborSwapIsdaFixPm.source + ".ForwardingTermStructure") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixPm.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<JpyLiborSwapIsdaFixPm> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixPm_iborIndex", Description="Create a JpyLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixPm_iborIndex
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixPm",Description = "JpyLiborSwapIsdaFixPm")>] 
         jpyliborswapisdafixpm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixPm = Helper.toModelReference<JpyLiborSwapIsdaFixPm> jpyliborswapisdafixpm "JpyLiborSwapIsdaFixPm"  
                let builder (current : ICell) = ((JpyLiborSwapIsdaFixPmModel.Cast _JpyLiborSwapIsdaFixPm.cell).IborIndex
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source () = Helper.sourceFold (_JpyLiborSwapIsdaFixPm.source + ".IborIndex") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixPm.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<JpyLiborSwapIsdaFixPm> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        InterestRateIndex interface
    *)
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixPm_maturityDate", Description="Create a JpyLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixPm_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixPm",Description = "JpyLiborSwapIsdaFixPm")>] 
         jpyliborswapisdafixpm : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Date")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixPm = Helper.toModelReference<JpyLiborSwapIsdaFixPm> jpyliborswapisdafixpm "JpyLiborSwapIsdaFixPm"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = ((JpyLiborSwapIsdaFixPmModel.Cast _JpyLiborSwapIsdaFixPm.cell).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_JpyLiborSwapIsdaFixPm.source + ".MaturityDate") 

                                               [| _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixPm.cell
                                ;  _valueDate.cell
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
        \warning Relinking the term structure underlying the index will not have effect on the returned swap. recheck
    *)
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixPm_underlyingSwap", Description="Create a JpyLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixPm_underlyingSwap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixPm",Description = "JpyLiborSwapIsdaFixPm")>] 
         jpyliborswapisdafixpm : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixPm = Helper.toModelReference<JpyLiborSwapIsdaFixPm> jpyliborswapisdafixpm "JpyLiborSwapIsdaFixPm"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = ((JpyLiborSwapIsdaFixPmModel.Cast _JpyLiborSwapIsdaFixPm.cell).UnderlyingSwap
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<VanillaSwap>) l

                let source () = Helper.sourceFold (_JpyLiborSwapIsdaFixPm.source + ".UnderlyingSwap") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixPm.cell
                                ;  _fixingDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<JpyLiborSwapIsdaFixPm> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixPm_currency", Description="Create a JpyLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixPm_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixPm",Description = "JpyLiborSwapIsdaFixPm")>] 
         jpyliborswapisdafixpm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixPm = Helper.toModelReference<JpyLiborSwapIsdaFixPm> jpyliborswapisdafixpm "JpyLiborSwapIsdaFixPm"  
                let builder (current : ICell) = ((JpyLiborSwapIsdaFixPmModel.Cast _JpyLiborSwapIsdaFixPm.cell).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_JpyLiborSwapIsdaFixPm.source + ".Currency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixPm.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<JpyLiborSwapIsdaFixPm> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixPm_dayCounter", Description="Create a JpyLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixPm_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixPm",Description = "JpyLiborSwapIsdaFixPm")>] 
         jpyliborswapisdafixpm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixPm = Helper.toModelReference<JpyLiborSwapIsdaFixPm> jpyliborswapisdafixpm "JpyLiborSwapIsdaFixPm"  
                let builder (current : ICell) = ((JpyLiborSwapIsdaFixPmModel.Cast _JpyLiborSwapIsdaFixPm.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_JpyLiborSwapIsdaFixPm.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixPm.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<JpyLiborSwapIsdaFixPm> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Inspectors
    *)
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixPm_familyName", Description="Create a JpyLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixPm_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixPm",Description = "JpyLiborSwapIsdaFixPm")>] 
         jpyliborswapisdafixpm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixPm = Helper.toModelReference<JpyLiborSwapIsdaFixPm> jpyliborswapisdafixpm "JpyLiborSwapIsdaFixPm"  
                let builder (current : ICell) = ((JpyLiborSwapIsdaFixPmModel.Cast _JpyLiborSwapIsdaFixPm.cell).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_JpyLiborSwapIsdaFixPm.source + ".FamilyName") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixPm_fixing", Description="Create a JpyLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixPm_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixPm",Description = "JpyLiborSwapIsdaFixPm")>] 
         jpyliborswapisdafixpm : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "bool")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixPm = Helper.toModelReference<JpyLiborSwapIsdaFixPm> jpyliborswapisdafixpm "JpyLiborSwapIsdaFixPm"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder (current : ICell) = ((JpyLiborSwapIsdaFixPmModel.Cast _JpyLiborSwapIsdaFixPm.cell).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_JpyLiborSwapIsdaFixPm.source + ".Fixing") 

                                               [| _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixPm.cell
                                ;  _fixingDate.cell
                                ;  _forecastTodaysFixing.cell
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
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixPm_fixingCalendar", Description="Create a JpyLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixPm_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixPm",Description = "JpyLiborSwapIsdaFixPm")>] 
         jpyliborswapisdafixpm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixPm = Helper.toModelReference<JpyLiborSwapIsdaFixPm> jpyliborswapisdafixpm "JpyLiborSwapIsdaFixPm"  
                let builder (current : ICell) = ((JpyLiborSwapIsdaFixPmModel.Cast _JpyLiborSwapIsdaFixPm.cell).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_JpyLiborSwapIsdaFixPm.source + ".FixingCalendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixPm.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<JpyLiborSwapIsdaFixPm> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixPm_fixingDate", Description="Create a JpyLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixPm_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixPm",Description = "JpyLiborSwapIsdaFixPm")>] 
         jpyliborswapisdafixpm : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Date")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixPm = Helper.toModelReference<JpyLiborSwapIsdaFixPm> jpyliborswapisdafixpm "JpyLiborSwapIsdaFixPm"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = ((JpyLiborSwapIsdaFixPmModel.Cast _JpyLiborSwapIsdaFixPm.cell).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_JpyLiborSwapIsdaFixPm.source + ".FixingDate") 

                                               [| _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixPm.cell
                                ;  _valueDate.cell
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
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixPm_fixingDays", Description="Create a JpyLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixPm_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixPm",Description = "JpyLiborSwapIsdaFixPm")>] 
         jpyliborswapisdafixpm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixPm = Helper.toModelReference<JpyLiborSwapIsdaFixPm> jpyliborswapisdafixpm "JpyLiborSwapIsdaFixPm"  
                let builder (current : ICell) = ((JpyLiborSwapIsdaFixPmModel.Cast _JpyLiborSwapIsdaFixPm.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_JpyLiborSwapIsdaFixPm.source + ".FixingDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixPm_isValidFixingDate", Description="Create a JpyLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixPm_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixPm",Description = "JpyLiborSwapIsdaFixPm")>] 
         jpyliborswapisdafixpm : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixPm = Helper.toModelReference<JpyLiborSwapIsdaFixPm> jpyliborswapisdafixpm "JpyLiborSwapIsdaFixPm"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = ((JpyLiborSwapIsdaFixPmModel.Cast _JpyLiborSwapIsdaFixPm.cell).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_JpyLiborSwapIsdaFixPm.source + ".IsValidFixingDate") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixPm.cell
                                ;  _fixingDate.cell
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
        Index interface
    *)
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixPm_name", Description="Create a JpyLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixPm_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixPm",Description = "JpyLiborSwapIsdaFixPm")>] 
         jpyliborswapisdafixpm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixPm = Helper.toModelReference<JpyLiborSwapIsdaFixPm> jpyliborswapisdafixpm "JpyLiborSwapIsdaFixPm"  
                let builder (current : ICell) = ((JpyLiborSwapIsdaFixPmModel.Cast _JpyLiborSwapIsdaFixPm.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_JpyLiborSwapIsdaFixPm.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixPm_pastFixing", Description="Create a JpyLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixPm_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixPm",Description = "JpyLiborSwapIsdaFixPm")>] 
         jpyliborswapisdafixpm : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixPm = Helper.toModelReference<JpyLiborSwapIsdaFixPm> jpyliborswapisdafixpm "JpyLiborSwapIsdaFixPm"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = ((JpyLiborSwapIsdaFixPmModel.Cast _JpyLiborSwapIsdaFixPm.cell).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_JpyLiborSwapIsdaFixPm.source + ".PastFixing") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixPm.cell
                                ;  _fixingDate.cell
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
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixPm_tenor", Description="Create a JpyLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixPm_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixPm",Description = "JpyLiborSwapIsdaFixPm")>] 
         jpyliborswapisdafixpm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixPm = Helper.toModelReference<JpyLiborSwapIsdaFixPm> jpyliborswapisdafixpm "JpyLiborSwapIsdaFixPm"  
                let builder (current : ICell) = ((JpyLiborSwapIsdaFixPmModel.Cast _JpyLiborSwapIsdaFixPm.cell).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_JpyLiborSwapIsdaFixPm.source + ".Tenor") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixPm.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<JpyLiborSwapIsdaFixPm> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Observer interface
    *)
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixPm_update", Description="Create a JpyLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixPm_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixPm",Description = "JpyLiborSwapIsdaFixPm")>] 
         jpyliborswapisdafixpm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixPm = Helper.toModelReference<JpyLiborSwapIsdaFixPm> jpyliborswapisdafixpm "JpyLiborSwapIsdaFixPm"  
                let builder (current : ICell) = ((JpyLiborSwapIsdaFixPmModel.Cast _JpyLiborSwapIsdaFixPm.cell).Update
                                                       ) :> ICell
                let format (o : JpyLiborSwapIsdaFixPm) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_JpyLiborSwapIsdaFixPm.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixPm.cell
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
        Date calculations These methods can be overridden to implement particular conventions (e.g. EurLibor)
    *)
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixPm_valueDate", Description="Create a JpyLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixPm_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixPm",Description = "JpyLiborSwapIsdaFixPm")>] 
         jpyliborswapisdafixpm : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixPm = Helper.toModelReference<JpyLiborSwapIsdaFixPm> jpyliborswapisdafixpm "JpyLiborSwapIsdaFixPm"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = ((JpyLiborSwapIsdaFixPmModel.Cast _JpyLiborSwapIsdaFixPm.cell).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_JpyLiborSwapIsdaFixPm.source + ".ValueDate") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixPm.cell
                                ;  _fixingDate.cell
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
        Stores the historical fixing at the given date The date passed as arguments must be the actual calendar date of the fixing; no settlement days must be used.
    *)
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixPm_addFixing", Description="Create a JpyLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixPm_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixPm",Description = "JpyLiborSwapIsdaFixPm")>] 
         jpyliborswapisdafixpm : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "double")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixPm = Helper.toModelReference<JpyLiborSwapIsdaFixPm> jpyliborswapisdafixpm "JpyLiborSwapIsdaFixPm"  
                let _d = Helper.toCell<Date> d "d" 
                let _v = Helper.toCell<double> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = ((JpyLiborSwapIsdaFixPmModel.Cast _JpyLiborSwapIsdaFixPm.cell).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : JpyLiborSwapIsdaFixPm) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_JpyLiborSwapIsdaFixPm.source + ".AddFixing") 

                                               [| _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixPm.cell
                                ;  _d.cell
                                ;  _v.cell
                                ;  _forceOverwrite.cell
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
        Stores historical fixings at the given dates The dates passed as arguments must be the actual calendar dates of the fixings; no settlement days must be used.
    *)
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixPm_addFixings", Description="Create a JpyLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixPm_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixPm",Description = "JpyLiborSwapIsdaFixPm")>] 
         jpyliborswapisdafixpm : obj)
        ([<ExcelArgument(Name="d",Description = "Date range")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "double range")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixPm = Helper.toModelReference<JpyLiborSwapIsdaFixPm> jpyliborswapisdafixpm "JpyLiborSwapIsdaFixPm"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = ((JpyLiborSwapIsdaFixPmModel.Cast _JpyLiborSwapIsdaFixPm.cell).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : JpyLiborSwapIsdaFixPm) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_JpyLiborSwapIsdaFixPm.source + ".AddFixings") 

                                               [| _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixPm.cell
                                ;  _d.cell
                                ;  _v.cell
                                ;  _forceOverwrite.cell
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
        Stores historical fixings from a TimeSeries The dates in the TimeSeries must be the actual calendar dates of the fixings; no settlement days must be used.
    *)
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixPm_addFixings1", Description="Create a JpyLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixPm_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixPm",Description = "JpyLiborSwapIsdaFixPm")>] 
         jpyliborswapisdafixpm : obj)
        ([<ExcelArgument(Name="source",Description = "double")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixPm = Helper.toModelReference<JpyLiborSwapIsdaFixPm> jpyliborswapisdafixpm "JpyLiborSwapIsdaFixPm"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = ((JpyLiborSwapIsdaFixPmModel.Cast _JpyLiborSwapIsdaFixPm.cell).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : JpyLiborSwapIsdaFixPm) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_JpyLiborSwapIsdaFixPm.source + ".AddFixings1") 

                                               [| _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixPm.cell
                                ;  _source.cell
                                ;  _forceOverwrite.cell
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
        Check if index allows for native fixings. If this returns false, calls to addFixing and similar methods will raise an exception.
    *)
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixPm_allowsNativeFixings", Description="Create a JpyLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixPm_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixPm",Description = "JpyLiborSwapIsdaFixPm")>] 
         jpyliborswapisdafixpm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixPm = Helper.toModelReference<JpyLiborSwapIsdaFixPm> jpyliborswapisdafixpm "JpyLiborSwapIsdaFixPm"  
                let builder (current : ICell) = ((JpyLiborSwapIsdaFixPmModel.Cast _JpyLiborSwapIsdaFixPm.cell).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_JpyLiborSwapIsdaFixPm.source + ".AllowsNativeFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixPm.cell
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
        Clears all stored historical fixings
    *)
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixPm_clearFixings", Description="Create a JpyLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixPm_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixPm",Description = "JpyLiborSwapIsdaFixPm")>] 
         jpyliborswapisdafixpm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixPm = Helper.toModelReference<JpyLiborSwapIsdaFixPm> jpyliborswapisdafixpm "JpyLiborSwapIsdaFixPm"  
                let builder (current : ICell) = ((JpyLiborSwapIsdaFixPmModel.Cast _JpyLiborSwapIsdaFixPm.cell).ClearFixings
                                                       ) :> ICell
                let format (o : JpyLiborSwapIsdaFixPm) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_JpyLiborSwapIsdaFixPm.source + ".ClearFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixPm_registerWith", Description="Create a JpyLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixPm_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixPm",Description = "JpyLiborSwapIsdaFixPm")>] 
         jpyliborswapisdafixpm : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixPm = Helper.toModelReference<JpyLiborSwapIsdaFixPm> jpyliborswapisdafixpm "JpyLiborSwapIsdaFixPm"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((JpyLiborSwapIsdaFixPmModel.Cast _JpyLiborSwapIsdaFixPm.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : JpyLiborSwapIsdaFixPm) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_JpyLiborSwapIsdaFixPm.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixPm.cell
                                ;  _handler.cell
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
        Returns the fixing TimeSeries
    *)
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixPm_timeSeries", Description="Create a JpyLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixPm_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixPm",Description = "JpyLiborSwapIsdaFixPm")>] 
         jpyliborswapisdafixpm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixPm = Helper.toModelReference<JpyLiborSwapIsdaFixPm> jpyliborswapisdafixpm "JpyLiborSwapIsdaFixPm"  
                let builder (current : ICell) = ((JpyLiborSwapIsdaFixPmModel.Cast _JpyLiborSwapIsdaFixPm.cell).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_JpyLiborSwapIsdaFixPm.source + ".TimeSeries") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixPm_unregisterWith", Description="Create a JpyLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixPm_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixPm",Description = "JpyLiborSwapIsdaFixPm")>] 
         jpyliborswapisdafixpm : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixPm = Helper.toModelReference<JpyLiborSwapIsdaFixPm> jpyliborswapisdafixpm "JpyLiborSwapIsdaFixPm"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((JpyLiborSwapIsdaFixPmModel.Cast _JpyLiborSwapIsdaFixPm.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : JpyLiborSwapIsdaFixPm) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_JpyLiborSwapIsdaFixPm.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixPm.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixPm_Range", Description="Create a range of JpyLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixPm_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<JpyLiborSwapIsdaFixPm> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<JpyLiborSwapIsdaFixPm> (c)) :> ICell
                let format (i : Cephei.Cell.List<JpyLiborSwapIsdaFixPm>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<JpyLiborSwapIsdaFixPm>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
