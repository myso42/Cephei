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
  South African CPI index
  </summary> *)
[<AutoSerializable(true)>]
module ZACPIFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ZACPI1", Description="Create a ZACPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZACPI_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="interpolated",Description = "bool")>] 
         interpolated : obj)
        ([<ExcelArgument(Name="ts",Description = "ZeroInflationTermStructure")>] 
         ts : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _interpolated = Helper.toCell<bool> interpolated "interpolated" 
                let _ts = Helper.toHandle<ZeroInflationTermStructure> ts "ts" 
                let builder (current : ICell) = (Fun.ZACPI1 
                                                            _interpolated.cell 
                                                            _ts.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ZACPI>) l

                let source () = Helper.sourceFold "Fun.ZACPI1" 
                                               [| _interpolated.source
                                               ;  _ts.source
                                               |]
                let hash = Helper.hashFold 
                                [| _interpolated.cell
                                ;  _ts.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ZACPI> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ZACPI", Description="Create a ZACPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZACPI_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="interpolated",Description = "bool")>] 
         interpolated : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _interpolated = Helper.toCell<bool> interpolated "interpolated" 
                let builder (current : ICell) = (Fun.ZACPI
                                                            _interpolated.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ZACPI>) l

                let source () = Helper.sourceFold "Fun.ZACPI" 
                                               [| _interpolated.source
                                               |]
                let hash = Helper.hashFold 
                                [| _interpolated.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ZACPI> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ZACPI_clone", Description="Create a ZACPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZACPI_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZACPI",Description = "ZACPI")>] 
         zacpi : obj)
        ([<ExcelArgument(Name="h",Description = "ZeroInflationTermStructure")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZACPI = Helper.toModelReference<ZACPI> zacpi "ZACPI"  
                let _h = Helper.toHandle<ZeroInflationTermStructure> h "h" 
                let builder (current : ICell) = ((ZACPIModel.Cast _ZACPI.cell).Clone
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ZeroInflationIndex>) l

                let source () = Helper.sourceFold (_ZACPI.source + ".Clone") 

                                               [| _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZACPI.cell
                                ;  _h.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ZACPI> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! \warning the forecastTodaysFixing parameter (required by the Index interface) is currently ignored.
    *)
    [<ExcelFunction(Name="_ZACPI_fixing", Description="Create a ZACPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZACPI_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZACPI",Description = "ZACPI")>] 
         zacpi : obj)
        ([<ExcelArgument(Name="aFixingDate",Description = "Date")>] 
         aFixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "bool")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZACPI = Helper.toModelReference<ZACPI> zacpi "ZACPI"  
                let _aFixingDate = Helper.toCell<Date> aFixingDate "aFixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder (current : ICell) = ((ZACPIModel.Cast _ZACPI.cell).Fixing
                                                            _aFixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ZACPI.source + ".Fixing") 

                                               [| _aFixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZACPI.cell
                                ;  _aFixingDate.cell
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
        Other methods
    *)
    [<ExcelFunction(Name="_ZACPI_zeroInflationTermStructure", Description="Create a ZACPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZACPI_zeroInflationTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZACPI",Description = "ZACPI")>] 
         zacpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZACPI = Helper.toModelReference<ZACPI> zacpi "ZACPI"  
                let builder (current : ICell) = ((ZACPIModel.Cast _ZACPI.cell).ZeroInflationTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<ZeroInflationTermStructure>>) l

                let source () = Helper.sourceFold (_ZACPI.source + ".ZeroInflationTermStructure") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ZACPI.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ZACPI> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! this method creates all the "fixings" for the relevant period of the index.  E.g. for monthly indices it will put the same value in every calendar day in the month.
    *)
    [<ExcelFunction(Name="_ZACPI_addFixing", Description="Create a ZACPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZACPI_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZACPI",Description = "ZACPI")>] 
         zacpi : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="fixing",Description = "double")>] 
         fixing : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZACPI = Helper.toModelReference<ZACPI> zacpi "ZACPI"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _fixing = Helper.toCell<double> fixing "fixing" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = ((ZACPIModel.Cast _ZACPI.cell).AddFixing
                                                            _fixingDate.cell 
                                                            _fixing.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : ZACPI) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ZACPI.source + ".AddFixing") 

                                               [| _fixingDate.source
                                               ;  _fixing.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZACPI.cell
                                ;  _fixingDate.cell
                                ;  _fixing.cell
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
        ! The availability lag describes when the index is
<i>available</i>, not how it is used.  Specifically the fixing for, say, January, may only be available in April but the index will always return the index value applicable for January as its January fixing (independent of the lag in availability).
    *)
    [<ExcelFunction(Name="_ZACPI_availabilityLag", Description="Create a ZACPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZACPI_availabilityLag
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZACPI",Description = "ZACPI")>] 
         zacpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZACPI = Helper.toModelReference<ZACPI> zacpi "ZACPI"  
                let builder (current : ICell) = ((ZACPIModel.Cast _ZACPI.cell).AvailabilityLag
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_ZACPI.source + ".AvailabilityLag") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ZACPI.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ZACPI> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ZACPI_currency", Description="Create a ZACPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZACPI_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZACPI",Description = "ZACPI")>] 
         zacpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZACPI = Helper.toModelReference<ZACPI> zacpi "ZACPI"  
                let builder (current : ICell) = ((ZACPIModel.Cast _ZACPI.cell).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_ZACPI.source + ".Currency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ZACPI.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ZACPI> format
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
    [<ExcelFunction(Name="_ZACPI_familyName", Description="Create a ZACPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZACPI_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZACPI",Description = "ZACPI")>] 
         zacpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZACPI = Helper.toModelReference<ZACPI> zacpi "ZACPI"  
                let builder (current : ICell) = ((ZACPIModel.Cast _ZACPI.cell).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ZACPI.source + ".FamilyName") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ZACPI.cell
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
        ! Inflation indices do not have fixing calendars.  An inflation index value is valid for every day (including weekends) of a calendar period.  I.e. it uses the NullCalendar as its fixing calendar.
    *)
    [<ExcelFunction(Name="_ZACPI_fixingCalendar", Description="Create a ZACPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZACPI_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZACPI",Description = "ZACPI")>] 
         zacpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZACPI = Helper.toModelReference<ZACPI> zacpi "ZACPI"  
                let builder (current : ICell) = ((ZACPIModel.Cast _ZACPI.cell).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_ZACPI.source + ".FixingCalendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ZACPI.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ZACPI> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ZACPI_frequency", Description="Create a ZACPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZACPI_frequency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZACPI",Description = "ZACPI")>] 
         zacpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZACPI = Helper.toModelReference<ZACPI> zacpi "ZACPI"  
                let builder (current : ICell) = ((ZACPIModel.Cast _ZACPI.cell).Frequency
                                                       ) :> ICell
                let format (o : Frequency) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ZACPI.source + ".Frequency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ZACPI.cell
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
        ! Forecasting index values using an inflation term structure uses the interpolation of the inflation term structure unless interpolation is set to false.  In this case the extrapolated values are constant within each period taking the mid-period extrapolated value.
    *)
    [<ExcelFunction(Name="_ZACPI_interpolated", Description="Create a ZACPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZACPI_interpolated
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZACPI",Description = "ZACPI")>] 
         zacpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZACPI = Helper.toModelReference<ZACPI> zacpi "ZACPI"  
                let builder (current : ICell) = ((ZACPIModel.Cast _ZACPI.cell).Interpolated
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ZACPI.source + ".Interpolated") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ZACPI.cell
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
    [<ExcelFunction(Name="_ZACPI_isValidFixingDate", Description="Create a ZACPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZACPI_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZACPI",Description = "ZACPI")>] 
         zacpi : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZACPI = Helper.toModelReference<ZACPI> zacpi "ZACPI"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = ((ZACPIModel.Cast _ZACPI.cell).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ZACPI.source + ".IsValidFixingDate") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZACPI.cell
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
    [<ExcelFunction(Name="_ZACPI_name", Description="Create a ZACPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZACPI_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZACPI",Description = "ZACPI")>] 
         zacpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZACPI = Helper.toModelReference<ZACPI> zacpi "ZACPI"  
                let builder (current : ICell) = ((ZACPIModel.Cast _ZACPI.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ZACPI.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ZACPI.cell
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
    [<ExcelFunction(Name="_ZACPI_region", Description="Create a ZACPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZACPI_region
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZACPI",Description = "ZACPI")>] 
         zacpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZACPI = Helper.toModelReference<ZACPI> zacpi "ZACPI"  
                let builder (current : ICell) = ((ZACPIModel.Cast _ZACPI.cell).Region
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Region>) l

                let source () = Helper.sourceFold (_ZACPI.source + ".Region") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ZACPI.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ZACPI> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ZACPI_revised", Description="Create a ZACPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZACPI_revised
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZACPI",Description = "ZACPI")>] 
         zacpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZACPI = Helper.toModelReference<ZACPI> zacpi "ZACPI"  
                let builder (current : ICell) = ((ZACPIModel.Cast _ZACPI.cell).Revised
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ZACPI.source + ".Revised") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ZACPI.cell
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
        Observer interface
    *)
    [<ExcelFunction(Name="_ZACPI_update", Description="Create a ZACPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZACPI_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZACPI",Description = "ZACPI")>] 
         zacpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZACPI = Helper.toModelReference<ZACPI> zacpi "ZACPI"  
                let builder (current : ICell) = ((ZACPIModel.Cast _ZACPI.cell).Update
                                                       ) :> ICell
                let format (o : ZACPI) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ZACPI.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ZACPI.cell
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
    [<ExcelFunction(Name="_ZACPI_addFixings", Description="Create a ZACPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZACPI_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZACPI",Description = "ZACPI")>] 
         zacpi : obj)
        ([<ExcelArgument(Name="d",Description = "Date range")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "double range")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZACPI = Helper.toModelReference<ZACPI> zacpi "ZACPI"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = ((ZACPIModel.Cast _ZACPI.cell).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : ZACPI) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ZACPI.source + ".AddFixings") 

                                               [| _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZACPI.cell
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
    [<ExcelFunction(Name="_ZACPI_addFixings1", Description="Create a ZACPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZACPI_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZACPI",Description = "ZACPI")>] 
         zacpi : obj)
        ([<ExcelArgument(Name="source",Description = "double")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZACPI = Helper.toModelReference<ZACPI> zacpi "ZACPI"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = ((ZACPIModel.Cast _ZACPI.cell).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : ZACPI) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ZACPI.source + ".AddFixings1") 

                                               [| _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZACPI.cell
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
    [<ExcelFunction(Name="_ZACPI_allowsNativeFixings", Description="Create a ZACPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZACPI_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZACPI",Description = "ZACPI")>] 
         zacpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZACPI = Helper.toModelReference<ZACPI> zacpi "ZACPI"  
                let builder (current : ICell) = ((ZACPIModel.Cast _ZACPI.cell).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ZACPI.source + ".AllowsNativeFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ZACPI.cell
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
    [<ExcelFunction(Name="_ZACPI_clearFixings", Description="Create a ZACPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZACPI_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZACPI",Description = "ZACPI")>] 
         zacpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZACPI = Helper.toModelReference<ZACPI> zacpi "ZACPI"  
                let builder (current : ICell) = ((ZACPIModel.Cast _ZACPI.cell).ClearFixings
                                                       ) :> ICell
                let format (o : ZACPI) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ZACPI.source + ".ClearFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ZACPI.cell
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
    [<ExcelFunction(Name="_ZACPI_registerWith", Description="Create a ZACPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZACPI_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZACPI",Description = "ZACPI")>] 
         zacpi : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZACPI = Helper.toModelReference<ZACPI> zacpi "ZACPI"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((ZACPIModel.Cast _ZACPI.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : ZACPI) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ZACPI.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZACPI.cell
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
    [<ExcelFunction(Name="_ZACPI_timeSeries", Description="Create a ZACPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZACPI_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZACPI",Description = "ZACPI")>] 
         zacpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZACPI = Helper.toModelReference<ZACPI> zacpi "ZACPI"  
                let builder (current : ICell) = ((ZACPIModel.Cast _ZACPI.cell).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ZACPI.source + ".TimeSeries") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ZACPI.cell
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
    [<ExcelFunction(Name="_ZACPI_unregisterWith", Description="Create a ZACPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZACPI_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZACPI",Description = "ZACPI")>] 
         zacpi : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZACPI = Helper.toModelReference<ZACPI> zacpi "ZACPI"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((ZACPIModel.Cast _ZACPI.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : ZACPI) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ZACPI.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZACPI.cell
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
    [<ExcelFunction(Name="_ZACPI_Range", Description="Create a range of ZACPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZACPI_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ZACPI> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<ZACPI> (c)) :> ICell
                let format (i : Cephei.Cell.List<ZACPI>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<ZACPI>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
