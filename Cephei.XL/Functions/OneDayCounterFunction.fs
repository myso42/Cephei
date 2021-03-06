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
  1/1 day count convention
  </summary> *)
[<AutoSerializable(true)>]
module OneDayCounterFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_OneDayCounter", Description="Create a OneDayCounter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OneDayCounter_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = (Fun.OneDayCounter ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<OneDayCounter>) l

                let source () = Helper.sourceFold "Fun.OneDayCounter" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OneDayCounter> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OneDayCounter_dayCount", Description="Create a OneDayCounter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OneDayCounter_dayCount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OneDayCounter",Description = "OneDayCounter")>] 
         onedaycounter : obj)
        ([<ExcelArgument(Name="d1",Description = "Date")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Date")>] 
         d2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OneDayCounter = Helper.toModelReference<OneDayCounter> onedaycounter "OneDayCounter"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let builder (current : ICell) = ((OneDayCounterModel.Cast _OneDayCounter.cell).DayCount
                                                            _d1.cell 
                                                            _d2.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_OneDayCounter.source + ".DayCount") 

                                               [| _d1.source
                                               ;  _d2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OneDayCounter.cell
                                ;  _d1.cell
                                ;  _d2.cell
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
    [<ExcelFunction(Name="_OneDayCounter_dayCounter", Description="Create a OneDayCounter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OneDayCounter_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OneDayCounter",Description = "OneDayCounter")>] 
         onedaycounter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OneDayCounter = Helper.toModelReference<OneDayCounter> onedaycounter "OneDayCounter"  
                let builder (current : ICell) = ((OneDayCounterModel.Cast _OneDayCounter.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_OneDayCounter.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _OneDayCounter.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OneDayCounter> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OneDayCounter_empty", Description="Create a OneDayCounter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OneDayCounter_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OneDayCounter",Description = "OneDayCounter")>] 
         onedaycounter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OneDayCounter = Helper.toModelReference<OneDayCounter> onedaycounter "OneDayCounter"  
                let builder (current : ICell) = ((OneDayCounterModel.Cast _OneDayCounter.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_OneDayCounter.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _OneDayCounter.cell
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
    [<ExcelFunction(Name="_OneDayCounter_Equals", Description="Create a OneDayCounter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OneDayCounter_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OneDayCounter",Description = "OneDayCounter")>] 
         onedaycounter : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OneDayCounter = Helper.toModelReference<OneDayCounter> onedaycounter "OneDayCounter"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = ((OneDayCounterModel.Cast _OneDayCounter.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_OneDayCounter.source + ".Equals") 

                                               [| _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OneDayCounter.cell
                                ;  _o.cell
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
    [<ExcelFunction(Name="_OneDayCounter_name", Description="Create a OneDayCounter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OneDayCounter_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OneDayCounter",Description = "OneDayCounter")>] 
         onedaycounter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OneDayCounter = Helper.toModelReference<OneDayCounter> onedaycounter "OneDayCounter"  
                let builder (current : ICell) = ((OneDayCounterModel.Cast _OneDayCounter.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_OneDayCounter.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _OneDayCounter.cell
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
    [<ExcelFunction(Name="_OneDayCounter_ToString", Description="Create a OneDayCounter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OneDayCounter_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OneDayCounter",Description = "OneDayCounter")>] 
         onedaycounter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OneDayCounter = Helper.toModelReference<OneDayCounter> onedaycounter "OneDayCounter"  
                let builder (current : ICell) = ((OneDayCounterModel.Cast _OneDayCounter.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_OneDayCounter.source + ".ToString") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _OneDayCounter.cell
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
    [<ExcelFunction(Name="_OneDayCounter_yearFraction", Description="Create a OneDayCounter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OneDayCounter_yearFraction
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OneDayCounter",Description = "OneDayCounter")>] 
         onedaycounter : obj)
        ([<ExcelArgument(Name="d1",Description = "Date")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Date")>] 
         d2 : obj)
        ([<ExcelArgument(Name="refPeriodStart",Description = "Date")>] 
         refPeriodStart : obj)
        ([<ExcelArgument(Name="refPeriodEnd",Description = "Date")>] 
         refPeriodEnd : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OneDayCounter = Helper.toModelReference<OneDayCounter> onedaycounter "OneDayCounter"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let _refPeriodStart = Helper.toCell<Date> refPeriodStart "refPeriodStart" 
                let _refPeriodEnd = Helper.toCell<Date> refPeriodEnd "refPeriodEnd" 
                let builder (current : ICell) = ((OneDayCounterModel.Cast _OneDayCounter.cell).YearFraction
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _refPeriodStart.cell 
                                                            _refPeriodEnd.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_OneDayCounter.source + ".YearFraction") 

                                               [| _d1.source
                                               ;  _d2.source
                                               ;  _refPeriodStart.source
                                               ;  _refPeriodEnd.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OneDayCounter.cell
                                ;  _d1.cell
                                ;  _d2.cell
                                ;  _refPeriodStart.cell
                                ;  _refPeriodEnd.cell
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
    [<ExcelFunction(Name="_OneDayCounter_yearFraction1", Description="Create a OneDayCounter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OneDayCounter_yearFraction1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OneDayCounter",Description = "OneDayCounter")>] 
         onedaycounter : obj)
        ([<ExcelArgument(Name="d1",Description = "Date")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Date")>] 
         d2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OneDayCounter = Helper.toModelReference<OneDayCounter> onedaycounter "OneDayCounter"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let builder (current : ICell) = ((OneDayCounterModel.Cast _OneDayCounter.cell).YearFraction1
                                                            _d1.cell 
                                                            _d2.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_OneDayCounter.source + ".YearFraction1") 

                                               [| _d1.source
                                               ;  _d2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OneDayCounter.cell
                                ;  _d1.cell
                                ;  _d2.cell
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
    [<ExcelFunction(Name="_OneDayCounter_Range", Description="Create a range of OneDayCounter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OneDayCounter_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<OneDayCounter> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<OneDayCounter> (c)) :> ICell
                let format (i : Cephei.Cell.List<OneDayCounter>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<OneDayCounter>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
