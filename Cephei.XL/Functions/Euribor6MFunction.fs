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
6-months %Euribor index
  </summary> *)
[<AutoSerializable(true)>]
module Euribor6MFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Euribor6M", Description="Create a Euribor6M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor6M_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="h",Description = "YieldTermStructure")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let builder (current : ICell) = (Fun.Euribor6M 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Euribor6M>) l

                let source () = Helper.sourceFold "Fun.Euribor6M" 
                                               [| _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _h.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Euribor6M> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Euribor6M1", Description="Create a Euribor6M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor6M_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = (Fun.Euribor6M1 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Euribor6M>) l

                let source () = Helper.sourceFold "Fun.Euribor6M1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Euribor6M> format
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
    [<ExcelFunction(Name="_Euribor6M_businessDayConvention", Description="Create a Euribor6M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor6M_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor6M",Description = "Euribor6M")>] 
         euribor6m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor6M = Helper.toModelReference<Euribor6M> euribor6m "Euribor6M"  
                let builder (current : ICell) = ((Euribor6MModel.Cast _Euribor6M.cell).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Euribor6M.source + ".BusinessDayConvention") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Euribor6M.cell
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
        Other methods returns a copy of itself linked to a different forwarding curve
    *)
    [<ExcelFunction(Name="_Euribor6M_clone", Description="Create a Euribor6M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor6M_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor6M",Description = "Euribor6M")>] 
         euribor6m : obj)
        ([<ExcelArgument(Name="forwarding",Description = "YieldTermStructure")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor6M = Helper.toModelReference<Euribor6M> euribor6m "Euribor6M"  
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let builder (current : ICell) = ((Euribor6MModel.Cast _Euribor6M.cell).Clone
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source () = Helper.sourceFold (_Euribor6M.source + ".Clone") 

                                               [| _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor6M.cell
                                ;  _forwarding.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Euribor6M> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Euribor6M_endOfMonth", Description="Create a Euribor6M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor6M_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor6M",Description = "Euribor6M")>] 
         euribor6m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor6M = Helper.toModelReference<Euribor6M> euribor6m "Euribor6M"  
                let builder (current : ICell) = ((Euribor6MModel.Cast _Euribor6M.cell).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Euribor6M.source + ".EndOfMonth") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Euribor6M.cell
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
    [<ExcelFunction(Name="_Euribor6M_forecastFixing1", Description="Create a Euribor6M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor6M_forecastFixing1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor6M",Description = "Euribor6M")>] 
         euribor6m : obj)
        ([<ExcelArgument(Name="d1",Description = "Date")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Date")>] 
         d2 : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor6M = Helper.toModelReference<Euribor6M> euribor6m "Euribor6M"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = ((Euribor6MModel.Cast _Euribor6M.cell).ForecastFixing1
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Euribor6M.source + ".ForecastFixing1") 

                                               [| _d1.source
                                               ;  _d2.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor6M.cell
                                ;  _d1.cell
                                ;  _d2.cell
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
        
    *)
    [<ExcelFunction(Name="_Euribor6M_forecastFixing", Description="Create a Euribor6M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor6M_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor6M",Description = "Euribor6M")>] 
         euribor6m : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor6M = Helper.toModelReference<Euribor6M> euribor6m "Euribor6M"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = ((Euribor6MModel.Cast _Euribor6M.cell).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Euribor6M.source + ".ForecastFixing") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor6M.cell
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
        the curve used to forecast fixings
    *)
    [<ExcelFunction(Name="_Euribor6M_forwardingTermStructure", Description="Create a Euribor6M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor6M_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor6M",Description = "Euribor6M")>] 
         euribor6m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor6M = Helper.toModelReference<Euribor6M> euribor6m "Euribor6M"  
                let builder (current : ICell) = ((Euribor6MModel.Cast _Euribor6M.cell).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_Euribor6M.source + ".ForwardingTermStructure") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Euribor6M.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Euribor6M> format
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
    [<ExcelFunction(Name="_Euribor6M_maturityDate", Description="Create a Euribor6M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor6M_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor6M",Description = "Euribor6M")>] 
         euribor6m : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Date")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor6M = Helper.toModelReference<Euribor6M> euribor6m "Euribor6M"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = ((Euribor6MModel.Cast _Euribor6M.cell).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Euribor6M.source + ".MaturityDate") 

                                               [| _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor6M.cell
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
    [<ExcelFunction(Name="_Euribor6M_currency", Description="Create a Euribor6M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor6M_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor6M",Description = "Euribor6M")>] 
         euribor6m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor6M = Helper.toModelReference<Euribor6M> euribor6m "Euribor6M"  
                let builder (current : ICell) = ((Euribor6MModel.Cast _Euribor6M.cell).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_Euribor6M.source + ".Currency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Euribor6M.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Euribor6M> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Euribor6M_dayCounter", Description="Create a Euribor6M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor6M_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor6M",Description = "Euribor6M")>] 
         euribor6m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor6M = Helper.toModelReference<Euribor6M> euribor6m "Euribor6M"  
                let builder (current : ICell) = ((Euribor6MModel.Cast _Euribor6M.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_Euribor6M.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Euribor6M.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Euribor6M> format
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
    [<ExcelFunction(Name="_Euribor6M_familyName", Description="Create a Euribor6M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor6M_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor6M",Description = "Euribor6M")>] 
         euribor6m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor6M = Helper.toModelReference<Euribor6M> euribor6m "Euribor6M"  
                let builder (current : ICell) = ((Euribor6MModel.Cast _Euribor6M.cell).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Euribor6M.source + ".FamilyName") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Euribor6M.cell
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
    [<ExcelFunction(Name="_Euribor6M_fixing", Description="Create a Euribor6M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor6M_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor6M",Description = "Euribor6M")>] 
         euribor6m : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "bool")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor6M = Helper.toModelReference<Euribor6M> euribor6m "Euribor6M"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder (current : ICell) = ((Euribor6MModel.Cast _Euribor6M.cell).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Euribor6M.source + ".Fixing") 

                                               [| _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor6M.cell
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
    [<ExcelFunction(Name="_Euribor6M_fixingCalendar", Description="Create a Euribor6M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor6M_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor6M",Description = "Euribor6M")>] 
         euribor6m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor6M = Helper.toModelReference<Euribor6M> euribor6m "Euribor6M"  
                let builder (current : ICell) = ((Euribor6MModel.Cast _Euribor6M.cell).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_Euribor6M.source + ".FixingCalendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Euribor6M.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Euribor6M> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Euribor6M_fixingDate", Description="Create a Euribor6M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor6M_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor6M",Description = "Euribor6M")>] 
         euribor6m : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Date")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor6M = Helper.toModelReference<Euribor6M> euribor6m "Euribor6M"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = ((Euribor6MModel.Cast _Euribor6M.cell).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Euribor6M.source + ".FixingDate") 

                                               [| _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor6M.cell
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
    [<ExcelFunction(Name="_Euribor6M_fixingDays", Description="Create a Euribor6M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor6M_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor6M",Description = "Euribor6M")>] 
         euribor6m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor6M = Helper.toModelReference<Euribor6M> euribor6m "Euribor6M"  
                let builder (current : ICell) = ((Euribor6MModel.Cast _Euribor6M.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Euribor6M.source + ".FixingDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Euribor6M.cell
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
    [<ExcelFunction(Name="_Euribor6M_isValidFixingDate", Description="Create a Euribor6M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor6M_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor6M",Description = "Euribor6M")>] 
         euribor6m : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor6M = Helper.toModelReference<Euribor6M> euribor6m "Euribor6M"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = ((Euribor6MModel.Cast _Euribor6M.cell).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Euribor6M.source + ".IsValidFixingDate") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor6M.cell
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
    [<ExcelFunction(Name="_Euribor6M_name", Description="Create a Euribor6M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor6M_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor6M",Description = "Euribor6M")>] 
         euribor6m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor6M = Helper.toModelReference<Euribor6M> euribor6m "Euribor6M"  
                let builder (current : ICell) = ((Euribor6MModel.Cast _Euribor6M.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Euribor6M.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Euribor6M.cell
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
    [<ExcelFunction(Name="_Euribor6M_pastFixing", Description="Create a Euribor6M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor6M_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor6M",Description = "Euribor6M")>] 
         euribor6m : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor6M = Helper.toModelReference<Euribor6M> euribor6m "Euribor6M"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = ((Euribor6MModel.Cast _Euribor6M.cell).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Euribor6M.source + ".PastFixing") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor6M.cell
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
    [<ExcelFunction(Name="_Euribor6M_tenor", Description="Create a Euribor6M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor6M_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor6M",Description = "Euribor6M")>] 
         euribor6m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor6M = Helper.toModelReference<Euribor6M> euribor6m "Euribor6M"  
                let builder (current : ICell) = ((Euribor6MModel.Cast _Euribor6M.cell).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_Euribor6M.source + ".Tenor") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Euribor6M.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Euribor6M> format
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
    [<ExcelFunction(Name="_Euribor6M_update", Description="Create a Euribor6M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor6M_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor6M",Description = "Euribor6M")>] 
         euribor6m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor6M = Helper.toModelReference<Euribor6M> euribor6m "Euribor6M"  
                let builder (current : ICell) = ((Euribor6MModel.Cast _Euribor6M.cell).Update
                                                       ) :> ICell
                let format (o : Euribor6M) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Euribor6M.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Euribor6M.cell
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
    [<ExcelFunction(Name="_Euribor6M_valueDate", Description="Create a Euribor6M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor6M_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor6M",Description = "Euribor6M")>] 
         euribor6m : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor6M = Helper.toModelReference<Euribor6M> euribor6m "Euribor6M"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = ((Euribor6MModel.Cast _Euribor6M.cell).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Euribor6M.source + ".ValueDate") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor6M.cell
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
    [<ExcelFunction(Name="_Euribor6M_addFixing", Description="Create a Euribor6M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor6M_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor6M",Description = "Euribor6M")>] 
         euribor6m : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "double")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor6M = Helper.toModelReference<Euribor6M> euribor6m "Euribor6M"  
                let _d = Helper.toCell<Date> d "d" 
                let _v = Helper.toCell<double> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = ((Euribor6MModel.Cast _Euribor6M.cell).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Euribor6M) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Euribor6M.source + ".AddFixing") 

                                               [| _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor6M.cell
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
    [<ExcelFunction(Name="_Euribor6M_addFixings", Description="Create a Euribor6M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor6M_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor6M",Description = "Euribor6M")>] 
         euribor6m : obj)
        ([<ExcelArgument(Name="d",Description = "Date range")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "double range")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor6M = Helper.toModelReference<Euribor6M> euribor6m "Euribor6M"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = ((Euribor6MModel.Cast _Euribor6M.cell).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Euribor6M) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Euribor6M.source + ".AddFixings") 

                                               [| _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor6M.cell
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
    [<ExcelFunction(Name="_Euribor6M_addFixings1", Description="Create a Euribor6M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor6M_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor6M",Description = "Euribor6M")>] 
         euribor6m : obj)
        ([<ExcelArgument(Name="source",Description = "double")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor6M = Helper.toModelReference<Euribor6M> euribor6m "Euribor6M"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = ((Euribor6MModel.Cast _Euribor6M.cell).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Euribor6M) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Euribor6M.source + ".AddFixings1") 

                                               [| _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor6M.cell
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
    [<ExcelFunction(Name="_Euribor6M_allowsNativeFixings", Description="Create a Euribor6M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor6M_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor6M",Description = "Euribor6M")>] 
         euribor6m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor6M = Helper.toModelReference<Euribor6M> euribor6m "Euribor6M"  
                let builder (current : ICell) = ((Euribor6MModel.Cast _Euribor6M.cell).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Euribor6M.source + ".AllowsNativeFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Euribor6M.cell
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
    [<ExcelFunction(Name="_Euribor6M_clearFixings", Description="Create a Euribor6M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor6M_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor6M",Description = "Euribor6M")>] 
         euribor6m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor6M = Helper.toModelReference<Euribor6M> euribor6m "Euribor6M"  
                let builder (current : ICell) = ((Euribor6MModel.Cast _Euribor6M.cell).ClearFixings
                                                       ) :> ICell
                let format (o : Euribor6M) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Euribor6M.source + ".ClearFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Euribor6M.cell
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
    [<ExcelFunction(Name="_Euribor6M_registerWith", Description="Create a Euribor6M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor6M_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor6M",Description = "Euribor6M")>] 
         euribor6m : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor6M = Helper.toModelReference<Euribor6M> euribor6m "Euribor6M"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((Euribor6MModel.Cast _Euribor6M.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : Euribor6M) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Euribor6M.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor6M.cell
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
    [<ExcelFunction(Name="_Euribor6M_timeSeries", Description="Create a Euribor6M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor6M_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor6M",Description = "Euribor6M")>] 
         euribor6m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor6M = Helper.toModelReference<Euribor6M> euribor6m "Euribor6M"  
                let builder (current : ICell) = ((Euribor6MModel.Cast _Euribor6M.cell).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Euribor6M.source + ".TimeSeries") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Euribor6M.cell
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
    [<ExcelFunction(Name="_Euribor6M_unregisterWith", Description="Create a Euribor6M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor6M_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor6M",Description = "Euribor6M")>] 
         euribor6m : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor6M = Helper.toModelReference<Euribor6M> euribor6m "Euribor6M"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((Euribor6MModel.Cast _Euribor6M.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : Euribor6M) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Euribor6M.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor6M.cell
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
    [<ExcelFunction(Name="_Euribor6M_Range", Description="Create a range of Euribor6M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor6M_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Euribor6M> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<Euribor6M> (c)) :> ICell
                let format (i : Cephei.Cell.List<Euribor6M>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<Euribor6M>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
