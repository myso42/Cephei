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
  Claim on the notional of a reference security, including accrual
  </summary> *)
[<AutoSerializable(true)>]
module FaceValueAccrualClaimFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FaceValueAccrualClaim_amount", Description="Create a FaceValueAccrualClaim",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FaceValueAccrualClaim_amount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FaceValueAccrualClaim",Description = "FaceValueAccrualClaim")>] 
         facevalueaccrualclaim : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="notional",Description = "double")>] 
         notional : obj)
        ([<ExcelArgument(Name="recoveryRate",Description = "double")>] 
         recoveryRate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FaceValueAccrualClaim = Helper.toModelReference<FaceValueAccrualClaim> facevalueaccrualclaim "FaceValueAccrualClaim"  
                let _d = Helper.toCell<Date> d "d" 
                let _notional = Helper.toCell<double> notional "notional" 
                let _recoveryRate = Helper.toCell<double> recoveryRate "recoveryRate" 
                let builder (current : ICell) = ((FaceValueAccrualClaimModel.Cast _FaceValueAccrualClaim.cell).Amount
                                                            _d.cell 
                                                            _notional.cell 
                                                            _recoveryRate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FaceValueAccrualClaim.source + ".Amount") 

                                               [| _d.source
                                               ;  _notional.source
                                               ;  _recoveryRate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FaceValueAccrualClaim.cell
                                ;  _d.cell
                                ;  _notional.cell
                                ;  _recoveryRate.cell
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
    [<ExcelFunction(Name="_FaceValueAccrualClaim", Description="Create a FaceValueAccrualClaim",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FaceValueAccrualClaim_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="referenceSecurity",Description = "Bond")>] 
         referenceSecurity : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _referenceSecurity = Helper.toCell<Bond> referenceSecurity "referenceSecurity" 
                let builder (current : ICell) = (Fun.FaceValueAccrualClaim 
                                                            _referenceSecurity.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FaceValueAccrualClaim>) l

                let source () = Helper.sourceFold "Fun.FaceValueAccrualClaim" 
                                               [| _referenceSecurity.source
                                               |]
                let hash = Helper.hashFold 
                                [| _referenceSecurity.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FaceValueAccrualClaim> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FaceValueAccrualClaim_registerWith", Description="Create a FaceValueAccrualClaim",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FaceValueAccrualClaim_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FaceValueAccrualClaim",Description = "FaceValueAccrualClaim")>] 
         facevalueaccrualclaim : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FaceValueAccrualClaim = Helper.toModelReference<FaceValueAccrualClaim> facevalueaccrualclaim "FaceValueAccrualClaim"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((FaceValueAccrualClaimModel.Cast _FaceValueAccrualClaim.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : FaceValueAccrualClaim) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FaceValueAccrualClaim.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FaceValueAccrualClaim.cell
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
        
    *)
    [<ExcelFunction(Name="_FaceValueAccrualClaim_unregisterWith", Description="Create a FaceValueAccrualClaim",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FaceValueAccrualClaim_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FaceValueAccrualClaim",Description = "FaceValueAccrualClaim")>] 
         facevalueaccrualclaim : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FaceValueAccrualClaim = Helper.toModelReference<FaceValueAccrualClaim> facevalueaccrualclaim "FaceValueAccrualClaim"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((FaceValueAccrualClaimModel.Cast _FaceValueAccrualClaim.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : FaceValueAccrualClaim) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FaceValueAccrualClaim.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FaceValueAccrualClaim.cell
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
        
    *)
    [<ExcelFunction(Name="_FaceValueAccrualClaim_update", Description="Create a FaceValueAccrualClaim",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FaceValueAccrualClaim_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FaceValueAccrualClaim",Description = "FaceValueAccrualClaim")>] 
         facevalueaccrualclaim : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FaceValueAccrualClaim = Helper.toModelReference<FaceValueAccrualClaim> facevalueaccrualclaim "FaceValueAccrualClaim"  
                let builder (current : ICell) = ((FaceValueAccrualClaimModel.Cast _FaceValueAccrualClaim.cell).Update
                                                       ) :> ICell
                let format (o : FaceValueAccrualClaim) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FaceValueAccrualClaim.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FaceValueAccrualClaim.cell
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
    [<ExcelFunction(Name="_FaceValueAccrualClaim_Range", Description="Create a range of FaceValueAccrualClaim",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FaceValueAccrualClaim_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FaceValueAccrualClaim> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<FaceValueAccrualClaim> (c)) :> ICell
                let format (i : Cephei.Cell.List<FaceValueAccrualClaim>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<FaceValueAccrualClaim>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
