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
module BlackDeltaPremiumAdjustedMaxStrikeClassFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BlackDeltaPremiumAdjustedMaxStrikeClass", Description="Create a BlackDeltaPremiumAdjustedMaxStrikeClass",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackDeltaPremiumAdjustedMaxStrikeClass_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ot",Description = "Option.Type: Put, Call")>] 
         ot : obj)
        ([<ExcelArgument(Name="dt",Description = "DeltaVolQuote.DeltaType: Spot, Fwd, PaSpot, PaFwd")>] 
         dt : obj)
        ([<ExcelArgument(Name="spot",Description = "double")>] 
         spot : obj)
        ([<ExcelArgument(Name="dDiscount",Description = "double")>] 
         dDiscount : obj)
        ([<ExcelArgument(Name="fDiscount",Description = "double")>] 
         fDiscount : obj)
        ([<ExcelArgument(Name="stdDev",Description = "double")>] 
         stdDev : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ot = Helper.toCell<Option.Type> ot "ot" 
                let _dt = Helper.toCell<DeltaVolQuote.DeltaType> dt "dt" 
                let _spot = Helper.toCell<double> spot "spot" 
                let _dDiscount = Helper.toCell<double> dDiscount "dDiscount" 
                let _fDiscount = Helper.toCell<double> fDiscount "fDiscount" 
                let _stdDev = Helper.toCell<double> stdDev "stdDev" 
                let builder (current : ICell) = (Fun.BlackDeltaPremiumAdjustedMaxStrikeClass 
                                                            _ot.cell 
                                                            _dt.cell 
                                                            _spot.cell 
                                                            _dDiscount.cell 
                                                            _fDiscount.cell 
                                                            _stdDev.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BlackDeltaPremiumAdjustedMaxStrikeClass>) l

                let source () = Helper.sourceFold "Fun.BlackDeltaPremiumAdjustedMaxStrikeClass" 
                                               [| _ot.source
                                               ;  _dt.source
                                               ;  _spot.source
                                               ;  _dDiscount.source
                                               ;  _fDiscount.source
                                               ;  _stdDev.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ot.cell
                                ;  _dt.cell
                                ;  _spot.cell
                                ;  _dDiscount.cell
                                ;  _fDiscount.cell
                                ;  _stdDev.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackDeltaPremiumAdjustedMaxStrikeClass> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BlackDeltaPremiumAdjustedMaxStrikeClass_value", Description="Create a BlackDeltaPremiumAdjustedMaxStrikeClass",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackDeltaPremiumAdjustedMaxStrikeClass_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackDeltaPremiumAdjustedMaxStrikeClass",Description = "BlackDeltaPremiumAdjustedMaxStrikeClass")>] 
         blackdeltapremiumadjustedmaxstrikeclass : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackDeltaPremiumAdjustedMaxStrikeClass = Helper.toModelReference<BlackDeltaPremiumAdjustedMaxStrikeClass> blackdeltapremiumadjustedmaxstrikeclass "BlackDeltaPremiumAdjustedMaxStrikeClass"  
                let _strike = Helper.toCell<double> strike "strike" 
                let builder (current : ICell) = ((BlackDeltaPremiumAdjustedMaxStrikeClassModel.Cast _BlackDeltaPremiumAdjustedMaxStrikeClass.cell).Value
                                                            _strike.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackDeltaPremiumAdjustedMaxStrikeClass.source + ".Value") 

                                               [| _strike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackDeltaPremiumAdjustedMaxStrikeClass.cell
                                ;  _strike.cell
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
    [<ExcelFunction(Name="_BlackDeltaPremiumAdjustedMaxStrikeClass_derivative", Description="Create a BlackDeltaPremiumAdjustedMaxStrikeClass",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackDeltaPremiumAdjustedMaxStrikeClass_derivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackDeltaPremiumAdjustedMaxStrikeClass",Description = "BlackDeltaPremiumAdjustedMaxStrikeClass")>] 
         blackdeltapremiumadjustedmaxstrikeclass : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackDeltaPremiumAdjustedMaxStrikeClass = Helper.toModelReference<BlackDeltaPremiumAdjustedMaxStrikeClass> blackdeltapremiumadjustedmaxstrikeclass "BlackDeltaPremiumAdjustedMaxStrikeClass"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = ((BlackDeltaPremiumAdjustedMaxStrikeClassModel.Cast _BlackDeltaPremiumAdjustedMaxStrikeClass.cell).Derivative
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackDeltaPremiumAdjustedMaxStrikeClass.source + ".Derivative") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackDeltaPremiumAdjustedMaxStrikeClass.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_BlackDeltaPremiumAdjustedMaxStrikeClass_Range", Description="Create a range of BlackDeltaPremiumAdjustedMaxStrikeClass",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackDeltaPremiumAdjustedMaxStrikeClass_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BlackDeltaPremiumAdjustedMaxStrikeClass> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<BlackDeltaPremiumAdjustedMaxStrikeClass> (c)) :> ICell
                let format (i : Cephei.Cell.List<BlackDeltaPremiumAdjustedMaxStrikeClass>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<BlackDeltaPremiumAdjustedMaxStrikeClass>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
