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
module PeriodFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Period_CompareTo", Description="Create a Period",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_CompareTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Period",Description = "Period")>] 
         period : obj)
        ([<ExcelArgument(Name="obj",Description = "Object")>] 
         obj : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Period = Helper.toModelReference<Period> period "Period"  
                let _obj = Helper.toCell<Object> obj "obj" 
                let builder (current : ICell) = ((PeriodModel.Cast _Period.cell).CompareTo
                                                            _obj.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Period.source + ".CompareTo") 

                                               [| _obj.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Period.cell
                                ;  _obj.cell
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
    [<ExcelFunction(Name="_Period_Equals", Description="Create a Period",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Period",Description = "Period")>] 
         period : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Period = Helper.toModelReference<Period> period "Period"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = ((PeriodModel.Cast _Period.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Period.source + ".Equals") 

                                               [| _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Period.cell
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
    [<ExcelFunction(Name="_Period_frequency", Description="Create a Period",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_frequency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Period",Description = "Period")>] 
         period : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Period = Helper.toModelReference<Period> period "Period"  
                let builder (current : ICell) = ((PeriodModel.Cast _Period.cell).Frequency
                                                       ) :> ICell
                let format (o : Frequency) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Period.source + ".Frequency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Period.cell
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
        properties
    *)
    [<ExcelFunction(Name="_Period_length", Description="Create a Period",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_length
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Period",Description = "Period")>] 
         period : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Period = Helper.toModelReference<Period> period "Period"  
                let builder (current : ICell) = ((PeriodModel.Cast _Period.cell).Length
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Period.source + ".Length") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Period.cell
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
    [<ExcelFunction(Name="_Period_normalize", Description="Create a Period",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_normalize
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Period",Description = "Period")>] 
         period : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Period = Helper.toModelReference<Period> period "Period"  
                let builder (current : ICell) = ((PeriodModel.Cast _Period.cell).Normalize
                                                       ) :> ICell
                let format (o : Period) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Period.source + ".Normalize") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Period.cell
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
        Create from a string like "1M", "2Y"...
    *)
    [<ExcelFunction(Name="_Period3", Description="Create a Period",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_create3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="periodString",Description = "string")>] 
         periodString : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _periodString = Helper.toCell<string> periodString "periodString" 
                let builder (current : ICell) = (Fun.Period3 
                                                            _periodString.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold "Fun.Period3" 
                                               [| _periodString.source
                                               |]
                let hash = Helper.hashFold 
                                [| _periodString.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Period> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Period2", Description="Create a Period",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="f",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         f : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _f = Helper.toCell<Frequency> f "f" 
                let builder (current : ICell) = (Fun.Period2
                                                            _f.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold "Fun.Period2" 
                                               [| _f.source
                                               |]
                let hash = Helper.hashFold 
                                [| _f.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Period> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Period", Description="Create a Period",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="n",Description = "int")>] 
         n : obj)
        ([<ExcelArgument(Name="u",Description = "TimeUnit: Days, Weeks, Months, Years")>] 
         u : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _n = Helper.toCell<int> n "n" 
                let _u = Helper.toCell<TimeUnit> u "u" 
                let builder (current : ICell) = (Fun.Period
                                                            _n.cell 
                                                            _u.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold "Fun.Period" 
                                               [| _n.source
                                               ;  _u.source
                                               |]
                let hash = Helper.hashFold 
                                [| _n.cell
                                ;  _u.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Period> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Period1", Description="Create a Period",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = (Fun.Period1 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold "Fun.Period1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Period> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Period_ToShortString", Description="Create a Period",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Period",Description = "Period")>] 
         period : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Period = Helper.toModelReference<Period> period "Period"  
                let builder (current : ICell) = ((PeriodModel.Cast _Period.cell).ToShortString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Period.source + ".ToShortString") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Period.cell
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
    [<ExcelFunction(Name="_Period_ToString", Description="Create a Period",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Period",Description = "Period")>] 
         period : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Period = Helper.toModelReference<Period> period "Period"  
                let builder (current : ICell) = ((PeriodModel.Cast _Period.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Period.source + ".ToString") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Period.cell
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
    [<ExcelFunction(Name="_Period_units", Description="Create a Period",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_units
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Period",Description = "Period")>] 
         period : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Period = Helper.toModelReference<Period> period "Period"  
                let builder (current : ICell) = ((PeriodModel.Cast _Period.cell).Units
                                                       ) :> ICell
                let format (o : TimeUnit) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Period.source + ".Units") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Period.cell
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
    [<ExcelFunction(Name="_Period_Range", Description="Create a range of Period",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Period> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<Period> (c)) :> ICell
                let format (i : Cephei.Cell.List<Period>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<Period>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
