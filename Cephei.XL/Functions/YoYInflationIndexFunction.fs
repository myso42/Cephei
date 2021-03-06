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
  These may be genuine indices published on, say, Bloomberg, or "fake" indices that are defined as the ratio of an index at different time points.
  </summary> *)
[<AutoSerializable(true)>]
module YoYInflationIndexFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_YoYInflationIndex_clone", Description="Create a YoYInflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationIndex_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationIndex",Description = "YoYInflationIndex")>] 
         yoyinflationindex : obj)
        ([<ExcelArgument(Name="h",Description = "YoYInflationTermStructure")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationIndex = Helper.toModelReference<YoYInflationIndex> yoyinflationindex "YoYInflationIndex"  
                let _h = Helper.toHandle<YoYInflationTermStructure> h "h" 
                let builder (current : ICell) = ((YoYInflationIndexModel.Cast _YoYInflationIndex.cell).Clone
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YoYInflationIndex>) l

                let source () = Helper.sourceFold (_YoYInflationIndex.source + ".Clone") 

                                               [| _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationIndex.cell
                                ;  _h.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YoYInflationIndex> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Index interface The forecastTodaysFixing parameter (required by the Index interface) is currently ignored.
    *)
    [<ExcelFunction(Name="_YoYInflationIndex_fixing", Description="Create a YoYInflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationIndex_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationIndex",Description = "YoYInflationIndex")>] 
         yoyinflationindex : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "YoYInflationIndex")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationIndex = Helper.toModelReference<YoYInflationIndex> yoyinflationindex "YoYInflationIndex"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toDefault<bool> forecastTodaysFixing "forecastTodaysFixing" false
                let builder (current : ICell) = ((YoYInflationIndexModel.Cast _YoYInflationIndex.cell).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_YoYInflationIndex.source + ".Fixing") 

                                               [| _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationIndex.cell
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
        Other methods
    *)
    [<ExcelFunction(Name="_YoYInflationIndex_ratio", Description="Create a YoYInflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationIndex_ratio
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationIndex",Description = "YoYInflationIndex")>] 
         yoyinflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationIndex = Helper.toModelReference<YoYInflationIndex> yoyinflationindex "YoYInflationIndex"  
                let builder (current : ICell) = ((YoYInflationIndexModel.Cast _YoYInflationIndex.cell).Ratio
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YoYInflationIndex.source + ".Ratio") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YoYInflationIndex.cell
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
    [<ExcelFunction(Name="_YoYInflationIndex", Description="Create a YoYInflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationIndex_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="familyName",Description = "string")>] 
         familyName : obj)
        ([<ExcelArgument(Name="region",Description = "Region")>] 
         region : obj)
        ([<ExcelArgument(Name="revised",Description = "bool")>] 
         revised : obj)
        ([<ExcelArgument(Name="interpolated",Description = "bool")>] 
         interpolated : obj)
        ([<ExcelArgument(Name="ratio",Description = "bool")>] 
         ratio : obj)
        ([<ExcelArgument(Name="frequency",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         frequency : obj)
        ([<ExcelArgument(Name="availabilityLag",Description = "Period")>] 
         availabilityLag : obj)
        ([<ExcelArgument(Name="currency",Description = "Currency")>] 
         currency : obj)
        ([<ExcelArgument(Name="yoyInflation",Description = "YoYInflationTermStructure")>] 
         yoyInflation : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _familyName = Helper.toCell<string> familyName "familyName" 
                let _region = Helper.toCell<Region> region "region" 
                let _revised = Helper.toCell<bool> revised "revised" 
                let _interpolated = Helper.toCell<bool> interpolated "interpolated" 
                let _ratio = Helper.toCell<bool> ratio "ratio" 
                let _frequency = Helper.toCell<Frequency> frequency "frequency" 
                let _availabilityLag = Helper.toCell<Period> availabilityLag "availabilityLag" 
                let _currency = Helper.toCell<Currency> currency "currency" 
                let _yoyInflation = Helper.toHandle<YoYInflationTermStructure> yoyInflation "yoyInflation" 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = (Fun.YoYInflationIndex 
                                                            _familyName.cell 
                                                            _region.cell 
                                                            _revised.cell 
                                                            _interpolated.cell 
                                                            _ratio.cell 
                                                            _frequency.cell 
                                                            _availabilityLag.cell 
                                                            _currency.cell 
                                                            _yoyInflation.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YoYInflationIndex>) l

                let source () = Helper.sourceFold "Fun.YoYInflationIndex" 
                                               [| _familyName.source
                                               ;  _region.source
                                               ;  _revised.source
                                               ;  _interpolated.source
                                               ;  _ratio.source
                                               ;  _frequency.source
                                               ;  _availabilityLag.source
                                               ;  _currency.source
                                               ;  _yoyInflation.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _familyName.cell
                                ;  _region.cell
                                ;  _revised.cell
                                ;  _interpolated.cell
                                ;  _ratio.cell
                                ;  _frequency.cell
                                ;  _availabilityLag.cell
                                ;  _currency.cell
                                ;  _yoyInflation.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YoYInflationIndex> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YoYInflationIndex_yoyInflationTermStructure", Description="Create a YoYInflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationIndex_yoyInflationTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationIndex",Description = "YoYInflationIndex")>] 
         yoyinflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationIndex = Helper.toModelReference<YoYInflationIndex> yoyinflationindex "YoYInflationIndex"  
                let builder (current : ICell) = ((YoYInflationIndexModel.Cast _YoYInflationIndex.cell).YoyInflationTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YoYInflationTermStructure>>) l

                let source () = Helper.sourceFold (_YoYInflationIndex.source + ".YoyInflationTermStructure") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YoYInflationIndex.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YoYInflationIndex> format
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
    [<ExcelFunction(Name="_YoYInflationIndex_addFixing", Description="Create a YoYInflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationIndex_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationIndex",Description = "YoYInflationIndex")>] 
         yoyinflationindex : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="fixing",Description = "double")>] 
         fixing : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationIndex = Helper.toModelReference<YoYInflationIndex> yoyinflationindex "YoYInflationIndex"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _fixing = Helper.toCell<double> fixing "fixing" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = ((YoYInflationIndexModel.Cast _YoYInflationIndex.cell).AddFixing
                                                            _fixingDate.cell 
                                                            _fixing.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : YoYInflationIndex) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YoYInflationIndex.source + ".AddFixing") 

                                               [| _fixingDate.source
                                               ;  _fixing.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationIndex.cell
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
    [<ExcelFunction(Name="_YoYInflationIndex_availabilityLag", Description="Create a YoYInflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationIndex_availabilityLag
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationIndex",Description = "YoYInflationIndex")>] 
         yoyinflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationIndex = Helper.toModelReference<YoYInflationIndex> yoyinflationindex "YoYInflationIndex"  
                let builder (current : ICell) = ((YoYInflationIndexModel.Cast _YoYInflationIndex.cell).AvailabilityLag
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_YoYInflationIndex.source + ".AvailabilityLag") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YoYInflationIndex.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YoYInflationIndex> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YoYInflationIndex_currency", Description="Create a YoYInflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationIndex_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationIndex",Description = "YoYInflationIndex")>] 
         yoyinflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationIndex = Helper.toModelReference<YoYInflationIndex> yoyinflationindex "YoYInflationIndex"  
                let builder (current : ICell) = ((YoYInflationIndexModel.Cast _YoYInflationIndex.cell).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_YoYInflationIndex.source + ".Currency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YoYInflationIndex.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YoYInflationIndex> format
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
    [<ExcelFunction(Name="_YoYInflationIndex_familyName", Description="Create a YoYInflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationIndex_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationIndex",Description = "YoYInflationIndex")>] 
         yoyinflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationIndex = Helper.toModelReference<YoYInflationIndex> yoyinflationindex "YoYInflationIndex"  
                let builder (current : ICell) = ((YoYInflationIndexModel.Cast _YoYInflationIndex.cell).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YoYInflationIndex.source + ".FamilyName") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YoYInflationIndex.cell
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
    [<ExcelFunction(Name="_YoYInflationIndex_fixingCalendar", Description="Create a YoYInflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationIndex_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationIndex",Description = "YoYInflationIndex")>] 
         yoyinflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationIndex = Helper.toModelReference<YoYInflationIndex> yoyinflationindex "YoYInflationIndex"  
                let builder (current : ICell) = ((YoYInflationIndexModel.Cast _YoYInflationIndex.cell).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_YoYInflationIndex.source + ".FixingCalendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YoYInflationIndex.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YoYInflationIndex> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YoYInflationIndex_frequency", Description="Create a YoYInflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationIndex_frequency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationIndex",Description = "YoYInflationIndex")>] 
         yoyinflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationIndex = Helper.toModelReference<YoYInflationIndex> yoyinflationindex "YoYInflationIndex"  
                let builder (current : ICell) = ((YoYInflationIndexModel.Cast _YoYInflationIndex.cell).Frequency
                                                       ) :> ICell
                let format (o : Frequency) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YoYInflationIndex.source + ".Frequency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YoYInflationIndex.cell
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
    [<ExcelFunction(Name="_YoYInflationIndex_interpolated", Description="Create a YoYInflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationIndex_interpolated
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationIndex",Description = "YoYInflationIndex")>] 
         yoyinflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationIndex = Helper.toModelReference<YoYInflationIndex> yoyinflationindex "YoYInflationIndex"  
                let builder (current : ICell) = ((YoYInflationIndexModel.Cast _YoYInflationIndex.cell).Interpolated
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YoYInflationIndex.source + ".Interpolated") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YoYInflationIndex.cell
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
    [<ExcelFunction(Name="_YoYInflationIndex_isValidFixingDate", Description="Create a YoYInflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationIndex_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationIndex",Description = "YoYInflationIndex")>] 
         yoyinflationindex : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationIndex = Helper.toModelReference<YoYInflationIndex> yoyinflationindex "YoYInflationIndex"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = ((YoYInflationIndexModel.Cast _YoYInflationIndex.cell).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YoYInflationIndex.source + ".IsValidFixingDate") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationIndex.cell
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
    [<ExcelFunction(Name="_YoYInflationIndex_name", Description="Create a YoYInflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationIndex_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationIndex",Description = "YoYInflationIndex")>] 
         yoyinflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationIndex = Helper.toModelReference<YoYInflationIndex> yoyinflationindex "YoYInflationIndex"  
                let builder (current : ICell) = ((YoYInflationIndexModel.Cast _YoYInflationIndex.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YoYInflationIndex.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YoYInflationIndex.cell
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
    [<ExcelFunction(Name="_YoYInflationIndex_region", Description="Create a YoYInflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationIndex_region
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationIndex",Description = "YoYInflationIndex")>] 
         yoyinflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationIndex = Helper.toModelReference<YoYInflationIndex> yoyinflationindex "YoYInflationIndex"  
                let builder (current : ICell) = ((YoYInflationIndexModel.Cast _YoYInflationIndex.cell).Region
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Region>) l

                let source () = Helper.sourceFold (_YoYInflationIndex.source + ".Region") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YoYInflationIndex.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YoYInflationIndex> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YoYInflationIndex_revised", Description="Create a YoYInflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationIndex_revised
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationIndex",Description = "YoYInflationIndex")>] 
         yoyinflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationIndex = Helper.toModelReference<YoYInflationIndex> yoyinflationindex "YoYInflationIndex"  
                let builder (current : ICell) = ((YoYInflationIndexModel.Cast _YoYInflationIndex.cell).Revised
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YoYInflationIndex.source + ".Revised") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YoYInflationIndex.cell
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
    [<ExcelFunction(Name="_YoYInflationIndex_update", Description="Create a YoYInflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationIndex_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationIndex",Description = "YoYInflationIndex")>] 
         yoyinflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationIndex = Helper.toModelReference<YoYInflationIndex> yoyinflationindex "YoYInflationIndex"  
                let builder (current : ICell) = ((YoYInflationIndexModel.Cast _YoYInflationIndex.cell).Update
                                                       ) :> ICell
                let format (o : YoYInflationIndex) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YoYInflationIndex.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YoYInflationIndex.cell
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
    [<ExcelFunction(Name="_YoYInflationIndex_addFixings", Description="Create a YoYInflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationIndex_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationIndex",Description = "YoYInflationIndex")>] 
         yoyinflationindex : obj)
        ([<ExcelArgument(Name="d",Description = "Date range")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "double range")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationIndex = Helper.toModelReference<YoYInflationIndex> yoyinflationindex "YoYInflationIndex"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = ((YoYInflationIndexModel.Cast _YoYInflationIndex.cell).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : YoYInflationIndex) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YoYInflationIndex.source + ".AddFixings") 

                                               [| _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationIndex.cell
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
    [<ExcelFunction(Name="_YoYInflationIndex_addFixings1", Description="Create a YoYInflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationIndex_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationIndex",Description = "YoYInflationIndex")>] 
         yoyinflationindex : obj)
        ([<ExcelArgument(Name="source",Description = "double")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationIndex = Helper.toModelReference<YoYInflationIndex> yoyinflationindex "YoYInflationIndex"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = ((YoYInflationIndexModel.Cast _YoYInflationIndex.cell).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : YoYInflationIndex) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YoYInflationIndex.source + ".AddFixings1") 

                                               [| _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationIndex.cell
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
    [<ExcelFunction(Name="_YoYInflationIndex_allowsNativeFixings", Description="Create a YoYInflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationIndex_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationIndex",Description = "YoYInflationIndex")>] 
         yoyinflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationIndex = Helper.toModelReference<YoYInflationIndex> yoyinflationindex "YoYInflationIndex"  
                let builder (current : ICell) = ((YoYInflationIndexModel.Cast _YoYInflationIndex.cell).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YoYInflationIndex.source + ".AllowsNativeFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YoYInflationIndex.cell
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
    [<ExcelFunction(Name="_YoYInflationIndex_clearFixings", Description="Create a YoYInflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationIndex_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationIndex",Description = "YoYInflationIndex")>] 
         yoyinflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationIndex = Helper.toModelReference<YoYInflationIndex> yoyinflationindex "YoYInflationIndex"  
                let builder (current : ICell) = ((YoYInflationIndexModel.Cast _YoYInflationIndex.cell).ClearFixings
                                                       ) :> ICell
                let format (o : YoYInflationIndex) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YoYInflationIndex.source + ".ClearFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YoYInflationIndex.cell
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
    [<ExcelFunction(Name="_YoYInflationIndex_registerWith", Description="Create a YoYInflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationIndex_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationIndex",Description = "YoYInflationIndex")>] 
         yoyinflationindex : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationIndex = Helper.toModelReference<YoYInflationIndex> yoyinflationindex "YoYInflationIndex"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((YoYInflationIndexModel.Cast _YoYInflationIndex.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : YoYInflationIndex) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YoYInflationIndex.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationIndex.cell
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
    [<ExcelFunction(Name="_YoYInflationIndex_timeSeries", Description="Create a YoYInflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationIndex_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationIndex",Description = "YoYInflationIndex")>] 
         yoyinflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationIndex = Helper.toModelReference<YoYInflationIndex> yoyinflationindex "YoYInflationIndex"  
                let builder (current : ICell) = ((YoYInflationIndexModel.Cast _YoYInflationIndex.cell).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YoYInflationIndex.source + ".TimeSeries") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YoYInflationIndex.cell
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
    [<ExcelFunction(Name="_YoYInflationIndex_unregisterWith", Description="Create a YoYInflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationIndex_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationIndex",Description = "YoYInflationIndex")>] 
         yoyinflationindex : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationIndex = Helper.toModelReference<YoYInflationIndex> yoyinflationindex "YoYInflationIndex"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((YoYInflationIndexModel.Cast _YoYInflationIndex.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : YoYInflationIndex) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YoYInflationIndex.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationIndex.cell
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
    [<ExcelFunction(Name="_YoYInflationIndex_Range", Description="Create a range of YoYInflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationIndex_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<YoYInflationIndex> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<YoYInflationIndex> (c)) :> ICell
                let format (i : Cephei.Cell.List<YoYInflationIndex>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<YoYInflationIndex>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
