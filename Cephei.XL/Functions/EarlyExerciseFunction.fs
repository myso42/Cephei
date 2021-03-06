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
  The payoff can be at exercise (the default) or at expiry
  </summary> *)
[<AutoSerializable(true)>]
module EarlyExerciseFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_EarlyExercise", Description="Create a EarlyExercise",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EarlyExercise_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Type",Description = "Exercise.Type: American, Bermudan, European")>] 
         Type : obj)
        ([<ExcelArgument(Name="payoffAtExpiry",Description = "bool")>] 
         payoffAtExpiry : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Type = Helper.toCell<Exercise.Type> Type "Type" 
                let _payoffAtExpiry = Helper.toCell<bool> payoffAtExpiry "payoffAtExpiry" 
                let builder (current : ICell) = (Fun.EarlyExercise 
                                                            _Type.cell 
                                                            _payoffAtExpiry.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EarlyExercise>) l

                let source () = Helper.sourceFold "Fun.EarlyExercise" 
                                               [| _Type.source
                                               ;  _payoffAtExpiry.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Type.cell
                                ;  _payoffAtExpiry.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EarlyExercise> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EarlyExercise_payoffAtExpiry", Description="Create a EarlyExercise",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EarlyExercise_payoffAtExpiry
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EarlyExercise",Description = "EarlyExercise")>] 
         earlyexercise : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EarlyExercise = Helper.toModelReference<EarlyExercise> earlyexercise "EarlyExercise"  
                let builder (current : ICell) = ((EarlyExerciseModel.Cast _EarlyExercise.cell).PayoffAtExpiry
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EarlyExercise.source + ".PayoffAtExpiry") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EarlyExercise.cell
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
        inspectors
    *)
    [<ExcelFunction(Name="_EarlyExercise_date", Description="Create a EarlyExercise",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EarlyExercise_date
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EarlyExercise",Description = "EarlyExercise")>] 
         earlyexercise : obj)
        ([<ExcelArgument(Name="index",Description = "int")>] 
         index : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EarlyExercise = Helper.toModelReference<EarlyExercise> earlyexercise "EarlyExercise"  
                let _index = Helper.toCell<int> index "index" 
                let builder (current : ICell) = ((EarlyExerciseModel.Cast _EarlyExercise.cell).Date
                                                            _index.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_EarlyExercise.source + ".Date") 

                                               [| _index.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EarlyExercise.cell
                                ;  _index.cell
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
    [<ExcelFunction(Name="_EarlyExercise_dates", Description="Create a EarlyExercise",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EarlyExercise_dates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EarlyExercise",Description = "EarlyExercise")>] 
         earlyexercise : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EarlyExercise = Helper.toModelReference<EarlyExercise> earlyexercise "EarlyExercise"  
                let builder (current : ICell) = ((EarlyExerciseModel.Cast _EarlyExercise.cell).Dates
                                                       ) :> ICell
                let format (i : Generic.List<Date>) (l : string) = Helper.Range.fromList i l

                let source () = Helper.sourceFold (_EarlyExercise.source + ".Dates") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EarlyExercise.cell
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
    [<ExcelFunction(Name="_EarlyExercise_lastDate", Description="Create a EarlyExercise",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EarlyExercise_lastDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EarlyExercise",Description = "EarlyExercise")>] 
         earlyexercise : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EarlyExercise = Helper.toModelReference<EarlyExercise> earlyexercise "EarlyExercise"  
                let builder (current : ICell) = ((EarlyExerciseModel.Cast _EarlyExercise.cell).LastDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_EarlyExercise.source + ".LastDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EarlyExercise.cell
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
    [<ExcelFunction(Name="_EarlyExercise_type", Description="Create a EarlyExercise",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EarlyExercise_type
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EarlyExercise",Description = "EarlyExercise")>] 
         earlyexercise : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EarlyExercise = Helper.toModelReference<EarlyExercise> earlyexercise "EarlyExercise"  
                let builder (current : ICell) = ((EarlyExerciseModel.Cast _EarlyExercise.cell).Type
                                                       ) :> ICell
                let format (o : Type) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EarlyExercise.source + ".TYPE") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EarlyExercise.cell
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
    [<ExcelFunction(Name="_EarlyExercise_Range", Description="Create a range of EarlyExercise",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EarlyExercise_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<EarlyExercise> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<EarlyExercise> (c)) :> ICell
                let format (i : Cephei.Cell.List<EarlyExercise>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<EarlyExercise>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
