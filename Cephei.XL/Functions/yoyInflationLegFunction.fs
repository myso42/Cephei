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
  Helper class building a sequence of capped/floored yoy inflation coupons   payoff is: spread + gearing x index
  </summary> *)
[<AutoSerializable(true)>]
module yoyInflationLegFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_yoyInflationLeg_value", Description="Create a yoyInflationLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let yoyInflationLeg_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="yoyInflationLeg",Description = "yoyInflationLeg")>] 
         yoyinflationleg : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _yoyInflationLeg = Helper.toModelReference<yoyInflationLeg> yoyinflationleg "yoyInflationLeg"  
                let builder (current : ICell) = ((yoyInflationLegModel.Cast _yoyInflationLeg.cell).Value
                                                       ) :> ICell
                let format (i : Generic.List<CashFlow>) (l : string) = Helper.Range.fromList i l

                let source () = Helper.sourceFold (_yoyInflationLeg.source + ".Value") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _yoyInflationLeg.cell
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
    [<ExcelFunction(Name="_yoyInflationLeg", Description="Create a yoyInflationLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let yoyInflationLeg_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="schedule",Description = "Schedule")>] 
         schedule : obj)
        ([<ExcelArgument(Name="cal",Description = "Calendar")>] 
         cal : obj)
        ([<ExcelArgument(Name="index",Description = "YoYInflationIndex")>] 
         index : obj)
        ([<ExcelArgument(Name="observationLag",Description = "Period")>] 
         observationLag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _schedule = Helper.toCell<Schedule> schedule "schedule" 
                let _cal = Helper.toCell<Calendar> cal "cal" 
                let _index = Helper.toCell<YoYInflationIndex> index "index" 
                let _observationLag = Helper.toCell<Period> observationLag "observationLag" 
                let builder (current : ICell) = (Fun.yoyInflationLeg 
                                                            _schedule.cell 
                                                            _cal.cell 
                                                            _index.cell 
                                                            _observationLag.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<yoyInflationLeg>) l

                let source () = Helper.sourceFold "Fun.yoyInflationLeg" 
                                               [| _schedule.source
                                               ;  _cal.source
                                               ;  _index.source
                                               ;  _observationLag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _schedule.cell
                                ;  _cal.cell
                                ;  _index.cell
                                ;  _observationLag.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<yoyInflationLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_yoyInflationLeg_withCaps", Description="Create a yoyInflationLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let yoyInflationLeg_withCaps
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="yoyInflationLeg",Description = "yoyInflationLeg")>] 
         yoyinflationleg : obj)
        ([<ExcelArgument(Name="cap",Description = "double")>] 
         cap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _yoyInflationLeg = Helper.toModelReference<yoyInflationLeg> yoyinflationleg "yoyInflationLeg"  
                let _cap = Helper.toCell<double> cap "cap" 
                let builder (current : ICell) = ((yoyInflationLegModel.Cast _yoyInflationLeg.cell).WithCaps
                                                            _cap.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<yoyInflationLegBase>) l

                let source () = Helper.sourceFold (_yoyInflationLeg.source + ".WithCaps") 

                                               [| _cap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _yoyInflationLeg.cell
                                ;  _cap.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<yoyInflationLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_yoyInflationLeg_withCaps1", Description="Create a yoyInflationLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let yoyInflationLeg_withCaps1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="yoyInflationLeg",Description = "yoyInflationLeg")>] 
         yoyinflationleg : obj)
        ([<ExcelArgument(Name="caps",Description = "double range or empty")>] 
         caps : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _yoyInflationLeg = Helper.toModelReference<yoyInflationLeg> yoyinflationleg "yoyInflationLeg"  
                let _caps = Helper.toNullabletList<double> caps "caps" 
                let builder (current : ICell) = ((yoyInflationLegModel.Cast _yoyInflationLeg.cell).WithCaps1
                                                            _caps.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<yoyInflationLegBase>) l

                let source () = Helper.sourceFold (_yoyInflationLeg.source + ".WithCaps1") 

                                               [| _caps.source
                                               |]
                let hash = Helper.hashFold 
                                [| _yoyInflationLeg.cell
                                ;  _caps.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<yoyInflationLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_yoyInflationLeg_withFixingDays1", Description="Create a yoyInflationLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let yoyInflationLeg_withFixingDays1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="yoyInflationLeg",Description = "yoyInflationLeg")>] 
         yoyinflationleg : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "int")>] 
         fixingDays : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _yoyInflationLeg = Helper.toModelReference<yoyInflationLeg> yoyinflationleg "yoyInflationLeg"  
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" 
                let builder (current : ICell) = ((yoyInflationLegModel.Cast _yoyInflationLeg.cell).WithFixingDays1
                                                            _fixingDays.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<yoyInflationLegBase>) l

                let source () = Helper.sourceFold (_yoyInflationLeg.source + ".WithFixingDays1") 

                                               [| _fixingDays.source
                                               |]
                let hash = Helper.hashFold 
                                [| _yoyInflationLeg.cell
                                ;  _fixingDays.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<yoyInflationLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_yoyInflationLeg_withFixingDays", Description="Create a yoyInflationLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let yoyInflationLeg_withFixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="yoyInflationLeg",Description = "yoyInflationLeg")>] 
         yoyinflationleg : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "int range")>] 
         fixingDays : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _yoyInflationLeg = Helper.toModelReference<yoyInflationLeg> yoyinflationleg "yoyInflationLeg"  
                let _fixingDays = Helper.toCell<Generic.List<int>> fixingDays "fixingDays" 
                let builder (current : ICell) = ((yoyInflationLegModel.Cast _yoyInflationLeg.cell).WithFixingDays
                                                            _fixingDays.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<yoyInflationLegBase>) l

                let source () = Helper.sourceFold (_yoyInflationLeg.source + ".WithFixingDays") 

                                               [| _fixingDays.source
                                               |]
                let hash = Helper.hashFold 
                                [| _yoyInflationLeg.cell
                                ;  _fixingDays.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<yoyInflationLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_yoyInflationLeg_withFloors1", Description="Create a yoyInflationLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let yoyInflationLeg_withFloors1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="yoyInflationLeg",Description = "yoyInflationLeg")>] 
         yoyinflationleg : obj)
        ([<ExcelArgument(Name="floors",Description = "double range or empty")>] 
         floors : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _yoyInflationLeg = Helper.toModelReference<yoyInflationLeg> yoyinflationleg "yoyInflationLeg"  
                let _floors = Helper.toNullabletList<double> floors "floors" 
                let builder (current : ICell) = ((yoyInflationLegModel.Cast _yoyInflationLeg.cell).WithFloors1
                                                            _floors.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<yoyInflationLegBase>) l

                let source () = Helper.sourceFold (_yoyInflationLeg.source + ".WithFloors1") 

                                               [| _floors.source
                                               |]
                let hash = Helper.hashFold 
                                [| _yoyInflationLeg.cell
                                ;  _floors.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<yoyInflationLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_yoyInflationLeg_withFloors", Description="Create a yoyInflationLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let yoyInflationLeg_withFloors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="yoyInflationLeg",Description = "yoyInflationLeg")>] 
         yoyinflationleg : obj)
        ([<ExcelArgument(Name="floor",Description = "double")>] 
         floor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _yoyInflationLeg = Helper.toModelReference<yoyInflationLeg> yoyinflationleg "yoyInflationLeg"  
                let _floor = Helper.toCell<double> floor "floor" 
                let builder (current : ICell) = ((yoyInflationLegModel.Cast _yoyInflationLeg.cell).WithFloors
                                                            _floor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<yoyInflationLegBase>) l

                let source () = Helper.sourceFold (_yoyInflationLeg.source + ".WithFloors") 

                                               [| _floor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _yoyInflationLeg.cell
                                ;  _floor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<yoyInflationLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_yoyInflationLeg_withGearings", Description="Create a yoyInflationLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let yoyInflationLeg_withGearings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="yoyInflationLeg",Description = "yoyInflationLeg")>] 
         yoyinflationleg : obj)
        ([<ExcelArgument(Name="gearings",Description = "double range")>] 
         gearings : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _yoyInflationLeg = Helper.toModelReference<yoyInflationLeg> yoyinflationleg "yoyInflationLeg"  
                let _gearings = Helper.toCell<Generic.List<double>> gearings "gearings" 
                let builder (current : ICell) = ((yoyInflationLegModel.Cast _yoyInflationLeg.cell).WithGearings
                                                            _gearings.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<yoyInflationLegBase>) l

                let source () = Helper.sourceFold (_yoyInflationLeg.source + ".WithGearings") 

                                               [| _gearings.source
                                               |]
                let hash = Helper.hashFold 
                                [| _yoyInflationLeg.cell
                                ;  _gearings.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<yoyInflationLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_yoyInflationLeg_withGearings1", Description="Create a yoyInflationLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let yoyInflationLeg_withGearings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="yoyInflationLeg",Description = "yoyInflationLeg")>] 
         yoyinflationleg : obj)
        ([<ExcelArgument(Name="gearing",Description = "double")>] 
         gearing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _yoyInflationLeg = Helper.toModelReference<yoyInflationLeg> yoyinflationleg "yoyInflationLeg"  
                let _gearing = Helper.toCell<double> gearing "gearing" 
                let builder (current : ICell) = ((yoyInflationLegModel.Cast _yoyInflationLeg.cell).WithGearings1
                                                            _gearing.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<yoyInflationLegBase>) l

                let source () = Helper.sourceFold (_yoyInflationLeg.source + ".WithGearings1") 

                                               [| _gearing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _yoyInflationLeg.cell
                                ;  _gearing.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<yoyInflationLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_yoyInflationLeg_withPaymentDayCounter", Description="Create a yoyInflationLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let yoyInflationLeg_withPaymentDayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="yoyInflationLeg",Description = "yoyInflationLeg")>] 
         yoyinflationleg : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter")>] 
         dayCounter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _yoyInflationLeg = Helper.toModelReference<yoyInflationLeg> yoyinflationleg "yoyInflationLeg"  
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let builder (current : ICell) = ((yoyInflationLegModel.Cast _yoyInflationLeg.cell).WithPaymentDayCounter
                                                            _dayCounter.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<yoyInflationLegBase>) l

                let source () = Helper.sourceFold (_yoyInflationLeg.source + ".WithPaymentDayCounter") 

                                               [| _dayCounter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _yoyInflationLeg.cell
                                ;  _dayCounter.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<yoyInflationLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_yoyInflationLeg_withSpreads", Description="Create a yoyInflationLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let yoyInflationLeg_withSpreads
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="yoyInflationLeg",Description = "yoyInflationLeg")>] 
         yoyinflationleg : obj)
        ([<ExcelArgument(Name="spread",Description = "double")>] 
         spread : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _yoyInflationLeg = Helper.toModelReference<yoyInflationLeg> yoyinflationleg "yoyInflationLeg"  
                let _spread = Helper.toCell<double> spread "spread" 
                let builder (current : ICell) = ((yoyInflationLegModel.Cast _yoyInflationLeg.cell).WithSpreads
                                                            _spread.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<yoyInflationLegBase>) l

                let source () = Helper.sourceFold (_yoyInflationLeg.source + ".WithSpreads") 

                                               [| _spread.source
                                               |]
                let hash = Helper.hashFold 
                                [| _yoyInflationLeg.cell
                                ;  _spread.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<yoyInflationLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_yoyInflationLeg_withSpreads1", Description="Create a yoyInflationLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let yoyInflationLeg_withSpreads1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="yoyInflationLeg",Description = "yoyInflationLeg")>] 
         yoyinflationleg : obj)
        ([<ExcelArgument(Name="spreads",Description = "double range")>] 
         spreads : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _yoyInflationLeg = Helper.toModelReference<yoyInflationLeg> yoyinflationleg "yoyInflationLeg"  
                let _spreads = Helper.toCell<Generic.List<double>> spreads "spreads" 
                let builder (current : ICell) = ((yoyInflationLegModel.Cast _yoyInflationLeg.cell).WithSpreads1
                                                            _spreads.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<yoyInflationLegBase>) l

                let source () = Helper.sourceFold (_yoyInflationLeg.source + ".WithSpreads1") 

                                               [| _spreads.source
                                               |]
                let hash = Helper.hashFold 
                                [| _yoyInflationLeg.cell
                                ;  _spreads.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<yoyInflationLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_yoyInflationLeg_withNotionals1", Description="Create a yoyInflationLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let yoyInflationLeg_withNotionals1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="yoyInflationLeg",Description = "yoyInflationLeg")>] 
         yoyinflationleg : obj)
        ([<ExcelArgument(Name="notionals",Description = "double range")>] 
         notionals : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _yoyInflationLeg = Helper.toModelReference<yoyInflationLeg> yoyinflationleg "yoyInflationLeg"  
                let _notionals = Helper.toCell<Generic.List<double>> notionals "notionals" 
                let builder (current : ICell) = ((yoyInflationLegModel.Cast _yoyInflationLeg.cell).WithNotionals1
                                                            _notionals.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RateLegBase>) l

                let source () = Helper.sourceFold (_yoyInflationLeg.source + ".WithNotionals1") 

                                               [| _notionals.source
                                               |]
                let hash = Helper.hashFold 
                                [| _yoyInflationLeg.cell
                                ;  _notionals.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<yoyInflationLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        initializers
    *)
    [<ExcelFunction(Name="_yoyInflationLeg_withNotionals", Description="Create a yoyInflationLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let yoyInflationLeg_withNotionals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="yoyInflationLeg",Description = "yoyInflationLeg")>] 
         yoyinflationleg : obj)
        ([<ExcelArgument(Name="notional",Description = "double")>] 
         notional : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _yoyInflationLeg = Helper.toModelReference<yoyInflationLeg> yoyinflationleg "yoyInflationLeg"  
                let _notional = Helper.toCell<double> notional "notional" 
                let builder (current : ICell) = ((yoyInflationLegModel.Cast _yoyInflationLeg.cell).WithNotionals
                                                            _notional.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RateLegBase>) l

                let source () = Helper.sourceFold (_yoyInflationLeg.source + ".WithNotionals") 

                                               [| _notional.source
                                               |]
                let hash = Helper.hashFold 
                                [| _yoyInflationLeg.cell
                                ;  _notional.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<yoyInflationLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_yoyInflationLeg_withPaymentAdjustment", Description="Create a yoyInflationLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let yoyInflationLeg_withPaymentAdjustment
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="yoyInflationLeg",Description = "yoyInflationLeg")>] 
         yoyinflationleg : obj)
        ([<ExcelArgument(Name="convention",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         convention : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _yoyInflationLeg = Helper.toModelReference<yoyInflationLeg> yoyinflationleg "yoyInflationLeg"  
                let _convention = Helper.toCell<BusinessDayConvention> convention "convention" 
                let builder (current : ICell) = ((yoyInflationLegModel.Cast _yoyInflationLeg.cell).WithPaymentAdjustment
                                                            _convention.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RateLegBase>) l

                let source () = Helper.sourceFold (_yoyInflationLeg.source + ".WithPaymentAdjustment") 

                                               [| _convention.source
                                               |]
                let hash = Helper.hashFold 
                                [| _yoyInflationLeg.cell
                                ;  _convention.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<yoyInflationLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_yoyInflationLeg_Range", Description="Create a range of yoyInflationLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let yoyInflationLeg_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<yoyInflationLeg> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<yoyInflationLeg> (c)) :> ICell
                let format (i : Cephei.Cell.List<yoyInflationLeg>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<yoyInflationLeg>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
