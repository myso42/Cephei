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
(*!! excluded from exscel interface
(* <summary>
helper class to temporarily and safely change the settings
  </summary> *)
[<AutoSerializable(true)>]
module SavedSettingsFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SavedSettings_Dispose", Description="Create a SavedSettings",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SavedSettings_Dispose
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SavedSettings",Description = "SavedSettings")>] 
         savedsettings : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SavedSettings = Helper.toModelReference<SavedSettings> savedsettings "SavedSettings"  
                let builder (current : ICell) = ((SavedSettingsModel.Cast _SavedSettings.cell).Dispose
                                                       ) :> ICell
                let format (o : SavedSettings) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SavedSettings.source + ".Dispose") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SavedSettings.cell
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
    [<ExcelFunction(Name="_SavedSettings", Description="Create a SavedSettings",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SavedSettings_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = (Fun.SavedSettings 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SavedSettings>) l

                let source () = Helper.sourceFold "Fun.SavedSettings" 
                                               ;  _evaluationDate.source
                                               [||]
                let hash = Helper.hashFold 
                                ;  _evaluationDate.cell
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SavedSettings> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_SavedSettings_Range", Description="Create a range of SavedSettings",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SavedSettings_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SavedSettings> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<SavedSettings> (c)) :> ICell
                let format (i : Cephei.Cell.List<SavedSettings>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<SavedSettings>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
