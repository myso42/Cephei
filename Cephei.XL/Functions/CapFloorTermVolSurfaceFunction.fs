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
module CapFloorTermVolSurfaceFunction =

    (*
        ! floating reference date, fixed market data
    *)
    [<ExcelFunction(Name="_CapFloorTermVolSurface3", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_create3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "int")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="calendar",Description = "Calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="bdc",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         bdc : obj)
        ([<ExcelArgument(Name="optionTenors",Description = "Period range")>] 
         optionTenors : obj)
        ([<ExcelArgument(Name="strikes",Description = "double range")>] 
         strikes : obj)
        ([<ExcelArgument(Name="vols",Description = "Matrix")>] 
         vols : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter or empty")>] 
         dc : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _bdc = Helper.toCell<BusinessDayConvention> bdc "bdc" 
                let _optionTenors = Helper.toCell<Generic.List<Period>> optionTenors "optionTenors" 
                let _strikes = Helper.toCell<Generic.List<double>> strikes "strikes" 
                let _vols = Helper.toCell<Matrix> vols "vols" 
                let _dc = Helper.toDefault<DayCounter> dc "dc" null
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = (Fun.CapFloorTermVolSurface3
                                                            _settlementDays.cell 
                                                            _calendar.cell 
                                                            _bdc.cell 
                                                            _optionTenors.cell 
                                                            _strikes.cell 
                                                            _vols.cell 
                                                            _dc.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CapFloorTermVolSurface>) l

                let source () = Helper.sourceFold "Fun.CapFloorTermVolSurface3" 
                                               [| _settlementDays.source
                                               ;  _calendar.source
                                               ;  _bdc.source
                                               ;  _optionTenors.source
                                               ;  _strikes.source
                                               ;  _vols.source
                                               ;  _dc.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _calendar.cell
                                ;  _bdc.cell
                                ;  _optionTenors.cell
                                ;  _strikes.cell
                                ;  _vols.cell
                                ;  _dc.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CapFloorTermVolSurface> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! fixed reference date, fixed market data
    *)
    [<ExcelFunction(Name="_CapFloorTermVolSurface", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDate",Description = "Date")>] 
         settlementDate : obj)
        ([<ExcelArgument(Name="calendar",Description = "Calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="bdc",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         bdc : obj)
        ([<ExcelArgument(Name="optionTenors",Description = "Period range")>] 
         optionTenors : obj)
        ([<ExcelArgument(Name="strikes",Description = "double range")>] 
         strikes : obj)
        ([<ExcelArgument(Name="vols",Description = "Matrix")>] 
         vols : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter or empty")>] 
         dc : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDate = Helper.toCell<Date> settlementDate "settlementDate" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _bdc = Helper.toCell<BusinessDayConvention> bdc "bdc" 
                let _optionTenors = Helper.toCell<Generic.List<Period>> optionTenors "optionTenors" 
                let _strikes = Helper.toCell<Generic.List<double>> strikes "strikes" 
                let _vols = Helper.toCell<Matrix> vols "vols" 
                let _dc = Helper.toDefault<DayCounter> dc "dc" null
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = (Fun.CapFloorTermVolSurface
                                                            _settlementDate.cell 
                                                            _calendar.cell 
                                                            _bdc.cell 
                                                            _optionTenors.cell 
                                                            _strikes.cell 
                                                            _vols.cell 
                                                            _dc.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CapFloorTermVolSurface>) l

                let source () = Helper.sourceFold "Fun.CapFloorTermVolSurface" 
                                               [| _settlementDate.source
                                               ;  _calendar.source
                                               ;  _bdc.source
                                               ;  _optionTenors.source
                                               ;  _strikes.source
                                               ;  _vols.source
                                               ;  _dc.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDate.cell
                                ;  _calendar.cell
                                ;  _bdc.cell
                                ;  _optionTenors.cell
                                ;  _strikes.cell
                                ;  _vols.cell
                                ;  _dc.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CapFloorTermVolSurface> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! fixed reference date, floating market data
    *)
    [<ExcelFunction(Name="_CapFloorTermVolSurface1", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDate",Description = "Date")>] 
         settlementDate : obj)
        ([<ExcelArgument(Name="calendar",Description = "Calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="bdc",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         bdc : obj)
        ([<ExcelArgument(Name="optionTenors",Description = "Period range")>] 
         optionTenors : obj)
        ([<ExcelArgument(Name="strikes",Description = "double range")>] 
         strikes : obj)
        ([<ExcelArgument(Name="vols",Description = "Quote range")>] 
         vols : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter or empty")>] 
         dc : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDate = Helper.toCell<Date> settlementDate "settlementDate" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _bdc = Helper.toCell<BusinessDayConvention> bdc "bdc" 
                let _optionTenors = Helper.toCell<Generic.List<Period>> optionTenors "optionTenors" 
                let _strikes = Helper.toCell<Generic.List<double>> strikes "strikes" 
                let _vols = Helper.toCell<Generic.List<Generic.List<Handle<Quote>>>> vols "vols" 
                let _dc = Helper.toDefault<DayCounter> dc "dc" null
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = (Fun.CapFloorTermVolSurface1
                                                            _settlementDate.cell 
                                                            _calendar.cell 
                                                            _bdc.cell 
                                                            _optionTenors.cell 
                                                            _strikes.cell 
                                                            _vols.cell 
                                                            _dc.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CapFloorTermVolSurface>) l

                let source () = Helper.sourceFold "Fun.CapFloorTermVolSurface1" 
                                               [| _settlementDate.source
                                               ;  _calendar.source
                                               ;  _bdc.source
                                               ;  _optionTenors.source
                                               ;  _strikes.source
                                               ;  _vols.source
                                               ;  _dc.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDate.cell
                                ;  _calendar.cell
                                ;  _bdc.cell
                                ;  _optionTenors.cell
                                ;  _strikes.cell
                                ;  _vols.cell
                                ;  _dc.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CapFloorTermVolSurface> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! floating reference date, floating market data
    *)
    (*!!vol
    [<ExcelFunction(Name="_CapFloorTermVolSurface3", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_create3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "int")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="calendar",Description = "Calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="bdc",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         bdc : obj)
        ([<ExcelArgument(Name="optionTenors",Description = "Period range")>] 
         optionTenors : obj)
        ([<ExcelArgument(Name="strikes",Description = "double range")>] 
         strikes : obj)
        ([<ExcelArgument(Name="vols",Description = "Quote range")>] 
         vols : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter or empty")>] 
         dc : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _bdc = Helper.toCell<BusinessDayConvention> bdc "bdc" 
                let _optionTenors = Helper.toCell<Generic.List<Period>> optionTenors "optionTenors" 
                let _strikes = Helper.toCell<Generic.List<double>> strikes "strikes" 
                let _vols = Helper.toCell<Generic.List<Generic.List<Handle<Quote>>>> vols "vols" 
                let _dc = Helper.toDefault<DayCounter> dc "dc" null
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = (Fun.CapFloorTermVolSurface3 
                                                            _settlementDays.cell 
                                                            _calendar.cell 
                                                            _bdc.cell 
                                                            _optionTenors.cell 
                                                            _strikes.cell 
                                                            _vols.cell 
                                                            _dc.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CapFloorTermVolSurface>) l

                let source () = Helper.sourceFold "Fun.CapFloorTermVolSurface3" 
                                               [| _settlementDays.source
                                               ;  _calendar.source
                                               ;  _bdc.source
                                               ;  _optionTenors.source
                                               ;  _strikes.source
                                               ;  _vols.source
                                               ;  _dc.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _calendar.cell
                                ;  _bdc.cell
                                ;  _optionTenors.cell
                                ;  _strikes.cell
                                ;  _vols.cell
                                ;  _dc.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CapFloorTermVolSurface> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
            *)
    (*
        TermStructure interface
    *)
    [<ExcelFunction(Name="_CapFloorTermVolSurface_maxDate", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolSurface",Description = "CapFloorTermVolSurface")>] 
         capfloortermvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolSurface = Helper.toModelReference<CapFloorTermVolSurface> capfloortermvolsurface "CapFloorTermVolSurface"  
                let builder (current : ICell) = ((CapFloorTermVolSurfaceModel.Cast _CapFloorTermVolSurface.cell).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CapFloorTermVolSurface.source + ".MaxDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolSurface.cell
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
    [<ExcelFunction(Name="_CapFloorTermVolSurface_maxStrike", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_maxStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolSurface",Description = "CapFloorTermVolSurface")>] 
         capfloortermvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolSurface = Helper.toModelReference<CapFloorTermVolSurface> capfloortermvolsurface "CapFloorTermVolSurface"  
                let builder (current : ICell) = ((CapFloorTermVolSurfaceModel.Cast _CapFloorTermVolSurface.cell).MaxStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CapFloorTermVolSurface.source + ".MaxStrike") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolSurface.cell
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
        VolatilityTermStructure interface
    *)
    [<ExcelFunction(Name="_CapFloorTermVolSurface_minStrike", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_minStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolSurface",Description = "CapFloorTermVolSurface")>] 
         capfloortermvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolSurface = Helper.toModelReference<CapFloorTermVolSurface> capfloortermvolsurface "CapFloorTermVolSurface"  
                let builder (current : ICell) = ((CapFloorTermVolSurfaceModel.Cast _CapFloorTermVolSurface.cell).MinStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CapFloorTermVolSurface.source + ".MinStrike") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolSurface.cell
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
    [<ExcelFunction(Name="_CapFloorTermVolSurface_optionDates", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_optionDates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolSurface",Description = "CapFloorTermVolSurface")>] 
         capfloortermvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolSurface = Helper.toModelReference<CapFloorTermVolSurface> capfloortermvolsurface "CapFloorTermVolSurface"  
                let builder (current : ICell) = ((CapFloorTermVolSurfaceModel.Cast _CapFloorTermVolSurface.cell).OptionDates
                                                       ) :> ICell
                let format (i : Generic.List<Date>) (l : string) = Helper.Range.fromList i l

                let source () = Helper.sourceFold (_CapFloorTermVolSurface.source + ".OptionDates") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolSurface.cell
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
        some inspectors
    *)
    [<ExcelFunction(Name="_CapFloorTermVolSurface_optionTenors", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_optionTenors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolSurface",Description = "CapFloorTermVolSurface")>] 
         capfloortermvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolSurface = Helper.toModelReference<CapFloorTermVolSurface> capfloortermvolsurface "CapFloorTermVolSurface"  
                let builder (current : ICell) = ((CapFloorTermVolSurfaceModel.Cast _CapFloorTermVolSurface.cell).OptionTenors
                                                       ) :> ICell
                let format (i : Generic.List<Period>) (l : string) = Helper.Range.fromList i l

                let source () = Helper.sourceFold (_CapFloorTermVolSurface.source + ".OptionTenors") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolSurface.cell
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
    [<ExcelFunction(Name="_CapFloorTermVolSurface_optionTimes", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_optionTimes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolSurface",Description = "CapFloorTermVolSurface")>] 
         capfloortermvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolSurface = Helper.toModelReference<CapFloorTermVolSurface> capfloortermvolsurface "CapFloorTermVolSurface"  
                let builder (current : ICell) = ((CapFloorTermVolSurfaceModel.Cast _CapFloorTermVolSurface.cell).OptionTimes
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_CapFloorTermVolSurface.source + ".OptionTimes") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolSurface.cell
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
    [<ExcelFunction(Name="_CapFloorTermVolSurface_strikes", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_strikes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolSurface",Description = "CapFloorTermVolSurface")>] 
         capfloortermvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolSurface = Helper.toModelReference<CapFloorTermVolSurface> capfloortermvolsurface "CapFloorTermVolSurface"  
                let builder (current : ICell) = ((CapFloorTermVolSurfaceModel.Cast _CapFloorTermVolSurface.cell).Strikes
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_CapFloorTermVolSurface.source + ".Strikes") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolSurface.cell
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
        LazyObject interface
    *)
    [<ExcelFunction(Name="_CapFloorTermVolSurface_update", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolSurface",Description = "CapFloorTermVolSurface")>] 
         capfloortermvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolSurface = Helper.toModelReference<CapFloorTermVolSurface> capfloortermvolsurface "CapFloorTermVolSurface"  
                let builder (current : ICell) = ((CapFloorTermVolSurfaceModel.Cast _CapFloorTermVolSurface.cell).Update
                                                       ) :> ICell
                let format (o : CapFloorTermVolSurface) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CapFloorTermVolSurface.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolSurface.cell
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
        ! returns the volatility for a given cap/floor length and strike rate
    *)
    [<ExcelFunction(Name="_CapFloorTermVolSurface_volatility", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolSurface",Description = "CapFloorTermVolSurface")>] 
         capfloortermvolsurface : obj)
        ([<ExcelArgument(Name="length",Description = "Period")>] 
         length : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolSurface = Helper.toModelReference<CapFloorTermVolSurface> capfloortermvolsurface "CapFloorTermVolSurface"  
                let _length = Helper.toCell<Period> length "length" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = ((CapFloorTermVolSurfaceModel.Cast _CapFloorTermVolSurface.cell).Volatility
                                                            _length.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CapFloorTermVolSurface.source + ".Volatility") 

                                               [| _length.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolSurface.cell
                                ;  _length.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! returns the volatility for a given end time and strike rate
    *)
    [<ExcelFunction(Name="_CapFloorTermVolSurface_volatility1", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_volatility1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolSurface",Description = "CapFloorTermVolSurface")>] 
         capfloortermvolsurface : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolSurface = Helper.toModelReference<CapFloorTermVolSurface> capfloortermvolsurface "CapFloorTermVolSurface"  
                let _t = Helper.toCell<double> t "t" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = ((CapFloorTermVolSurfaceModel.Cast _CapFloorTermVolSurface.cell).Volatility1
                                                            _t.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CapFloorTermVolSurface.source + ".Volatility1") 

                                               [| _t.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolSurface.cell
                                ;  _t.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
    [<ExcelFunction(Name="_CapFloorTermVolSurface_volatility2", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_volatility2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolSurface",Description = "CapFloorTermVolSurface")>] 
         capfloortermvolsurface : obj)
        ([<ExcelArgument(Name="End",Description = "Date")>] 
         End : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolSurface = Helper.toModelReference<CapFloorTermVolSurface> capfloortermvolsurface "CapFloorTermVolSurface"  
                let _End = Helper.toCell<Date> End "End" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = ((CapFloorTermVolSurfaceModel.Cast _CapFloorTermVolSurface.cell).Volatility2
                                                            _End.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CapFloorTermVolSurface.source + ".Volatility2") 

                                               [| _End.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolSurface.cell
                                ;  _End.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! the business day convention used in tenor to date conversion
    *)
    [<ExcelFunction(Name="_CapFloorTermVolSurface_businessDayConvention", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolSurface",Description = "CapFloorTermVolSurface")>] 
         capfloortermvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolSurface = Helper.toModelReference<CapFloorTermVolSurface> capfloortermvolsurface "CapFloorTermVolSurface"  
                let builder (current : ICell) = ((CapFloorTermVolSurfaceModel.Cast _CapFloorTermVolSurface.cell).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CapFloorTermVolSurface.source + ".BusinessDayConvention") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolSurface.cell
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
        ! period/date conversion
    *)
    [<ExcelFunction(Name="_CapFloorTermVolSurface_optionDateFromTenor", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_optionDateFromTenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolSurface",Description = "CapFloorTermVolSurface")>] 
         capfloortermvolsurface : obj)
        ([<ExcelArgument(Name="p",Description = "Period")>] 
         p : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolSurface = Helper.toModelReference<CapFloorTermVolSurface> capfloortermvolsurface "CapFloorTermVolSurface"  
                let _p = Helper.toCell<Period> p "p" 
                let builder (current : ICell) = ((CapFloorTermVolSurfaceModel.Cast _CapFloorTermVolSurface.cell).OptionDateFromTenor
                                                            _p.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CapFloorTermVolSurface.source + ".OptionDateFromTenor") 

                                               [| _p.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolSurface.cell
                                ;  _p.cell
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
        ! the calendar used for reference and/or option date calculation
    *)
    [<ExcelFunction(Name="_CapFloorTermVolSurface_calendar", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolSurface",Description = "CapFloorTermVolSurface")>] 
         capfloortermvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolSurface = Helper.toModelReference<CapFloorTermVolSurface> capfloortermvolsurface "CapFloorTermVolSurface"  
                let builder (current : ICell) = ((CapFloorTermVolSurfaceModel.Cast _CapFloorTermVolSurface.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_CapFloorTermVolSurface.source + ".Calendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolSurface.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CapFloorTermVolSurface> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! the day counter used for date/time conversion
    *)
    [<ExcelFunction(Name="_CapFloorTermVolSurface_dayCounter", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolSurface",Description = "CapFloorTermVolSurface")>] 
         capfloortermvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolSurface = Helper.toModelReference<CapFloorTermVolSurface> capfloortermvolsurface "CapFloorTermVolSurface"  
                let builder (current : ICell) = ((CapFloorTermVolSurfaceModel.Cast _CapFloorTermVolSurface.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_CapFloorTermVolSurface.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolSurface.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CapFloorTermVolSurface> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! the latest time for which the curve can return values
    *)
    [<ExcelFunction(Name="_CapFloorTermVolSurface_maxTime", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_maxTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolSurface",Description = "CapFloorTermVolSurface")>] 
         capfloortermvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolSurface = Helper.toModelReference<CapFloorTermVolSurface> capfloortermvolsurface "CapFloorTermVolSurface"  
                let builder (current : ICell) = ((CapFloorTermVolSurfaceModel.Cast _CapFloorTermVolSurface.cell).MaxTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CapFloorTermVolSurface.source + ".MaxTime") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolSurface.cell
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
        ! the date at which discount = 1.0 and/or variance = 0.0
    *)
    [<ExcelFunction(Name="_CapFloorTermVolSurface_referenceDate", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolSurface",Description = "CapFloorTermVolSurface")>] 
         capfloortermvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolSurface = Helper.toModelReference<CapFloorTermVolSurface> capfloortermvolsurface "CapFloorTermVolSurface"  
                let builder (current : ICell) = ((CapFloorTermVolSurfaceModel.Cast _CapFloorTermVolSurface.cell).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CapFloorTermVolSurface.source + ".ReferenceDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolSurface.cell
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
        ! the settlementDays used for reference date calculation
    *)
    [<ExcelFunction(Name="_CapFloorTermVolSurface_settlementDays", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolSurface",Description = "CapFloorTermVolSurface")>] 
         capfloortermvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolSurface = Helper.toModelReference<CapFloorTermVolSurface> capfloortermvolsurface "CapFloorTermVolSurface"  
                let builder (current : ICell) = ((CapFloorTermVolSurfaceModel.Cast _CapFloorTermVolSurface.cell).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CapFloorTermVolSurface.source + ".SettlementDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolSurface.cell
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
        ! date/time conversion
    *)
    [<ExcelFunction(Name="_CapFloorTermVolSurface_timeFromReference", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_timeFromReference
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolSurface",Description = "CapFloorTermVolSurface")>] 
         capfloortermvolsurface : obj)
        ([<ExcelArgument(Name="date",Description = "Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolSurface = Helper.toModelReference<CapFloorTermVolSurface> capfloortermvolsurface "CapFloorTermVolSurface"  
                let _date = Helper.toCell<Date> date "date" 
                let builder (current : ICell) = ((CapFloorTermVolSurfaceModel.Cast _CapFloorTermVolSurface.cell).TimeFromReference
                                                            _date.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CapFloorTermVolSurface.source + ".TimeFromReference") 

                                               [| _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolSurface.cell
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
        some extra functionality
    *)
    [<ExcelFunction(Name="_CapFloorTermVolSurface_allowsExtrapolation", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolSurface",Description = "CapFloorTermVolSurface")>] 
         capfloortermvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolSurface = Helper.toModelReference<CapFloorTermVolSurface> capfloortermvolsurface "CapFloorTermVolSurface"  
                let builder (current : ICell) = ((CapFloorTermVolSurfaceModel.Cast _CapFloorTermVolSurface.cell).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CapFloorTermVolSurface.source + ".AllowsExtrapolation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolSurface.cell
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
        ! enable extrapolation in subsequent calls
    *)
    [<ExcelFunction(Name="_CapFloorTermVolSurface_disableExtrapolation", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolSurface",Description = "CapFloorTermVolSurface")>] 
         capfloortermvolsurface : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolSurface = Helper.toModelReference<CapFloorTermVolSurface> capfloortermvolsurface "CapFloorTermVolSurface"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = ((CapFloorTermVolSurfaceModel.Cast _CapFloorTermVolSurface.cell).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : CapFloorTermVolSurface) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CapFloorTermVolSurface.source + ".DisableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolSurface.cell
                                ;  _b.cell
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
        ! tells whether extrapolation is enabled
    *)
    [<ExcelFunction(Name="_CapFloorTermVolSurface_enableExtrapolation", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolSurface",Description = "CapFloorTermVolSurface")>] 
         capfloortermvolsurface : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolSurface = Helper.toModelReference<CapFloorTermVolSurface> capfloortermvolsurface "CapFloorTermVolSurface"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = ((CapFloorTermVolSurfaceModel.Cast _CapFloorTermVolSurface.cell).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : CapFloorTermVolSurface) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CapFloorTermVolSurface.source + ".EnableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolSurface.cell
                                ;  _b.cell
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
    [<ExcelFunction(Name="_CapFloorTermVolSurface_extrapolate", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolSurface",Description = "CapFloorTermVolSurface")>] 
         capfloortermvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolSurface = Helper.toModelReference<CapFloorTermVolSurface> capfloortermvolsurface "CapFloorTermVolSurface"  
                let builder (current : ICell) = ((CapFloorTermVolSurfaceModel.Cast _CapFloorTermVolSurface.cell).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CapFloorTermVolSurface.source + ".Extrapolate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolSurface.cell
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
    [<ExcelFunction(Name="_CapFloorTermVolSurface_Range", Description="Create a range of CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CapFloorTermVolSurface> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<CapFloorTermVolSurface> (c)) :> ICell
                let format (i : Cephei.Cell.List<CapFloorTermVolSurface>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<CapFloorTermVolSurface>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
