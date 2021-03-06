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
  this pricer can already do swaplets but to get volatility-dependent coupons you need to implement the descendents.
  </summary> *)
[<AutoSerializable(true)>]
module CPICouponPricerFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_CPICouponPricer_capletPrice", Description="Create a CPICouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICouponPricer_capletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICouponPricer",Description = "CPICouponPricer")>] 
         cpicouponpricer : obj)
        ([<ExcelArgument(Name="effectiveCap",Description = "double")>] 
         effectiveCap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICouponPricer = Helper.toModelReference<CPICouponPricer> cpicouponpricer "CPICouponPricer"  
                let _effectiveCap = Helper.toCell<double> effectiveCap "effectiveCap" 
                let builder (current : ICell) = ((CPICouponPricerModel.Cast _CPICouponPricer.cell).CapletPrice
                                                            _effectiveCap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPICouponPricer.source + ".CapletPrice") 

                                               [| _effectiveCap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICouponPricer.cell
                                ;  _effectiveCap.cell
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
    [<ExcelFunction(Name="_CPICouponPricer_capletRate", Description="Create a CPICouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICouponPricer_capletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICouponPricer",Description = "CPICouponPricer")>] 
         cpicouponpricer : obj)
        ([<ExcelArgument(Name="effectiveCap",Description = "double")>] 
         effectiveCap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICouponPricer = Helper.toModelReference<CPICouponPricer> cpicouponpricer "CPICouponPricer"  
                let _effectiveCap = Helper.toCell<double> effectiveCap "effectiveCap" 
                let builder (current : ICell) = ((CPICouponPricerModel.Cast _CPICouponPricer.cell).CapletRate
                                                            _effectiveCap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPICouponPricer.source + ".CapletRate") 

                                               [| _effectiveCap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICouponPricer.cell
                                ;  _effectiveCap.cell
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
    [<ExcelFunction(Name="_CPICouponPricer_capletVolatility", Description="Create a CPICouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICouponPricer_capletVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICouponPricer",Description = "CPICouponPricer")>] 
         cpicouponpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICouponPricer = Helper.toModelReference<CPICouponPricer> cpicouponpricer "CPICouponPricer"  
                let builder (current : ICell) = ((CPICouponPricerModel.Cast _CPICouponPricer.cell).CapletVolatility
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<CPIVolatilitySurface>>) l

                let source () = Helper.sourceFold (_CPICouponPricer.source + ".CapletVolatility") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPICouponPricer.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CPICouponPricer> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CPICouponPricer", Description="Create a CPICouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICouponPricer_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="capletVol",Description = "CPIVolatilitySurface")>] 
         capletVol : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _capletVol = Helper.toHandle<CPIVolatilitySurface> capletVol "capletVol" 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = (Fun.CPICouponPricer 
                                                            _capletVol.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CPICouponPricer>) l

                let source () = Helper.sourceFold "Fun.CPICouponPricer" 
                                               [| _capletVol.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _capletVol.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CPICouponPricer> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CPICouponPricer_floorletPrice", Description="Create a CPICouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICouponPricer_floorletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICouponPricer",Description = "CPICouponPricer")>] 
         cpicouponpricer : obj)
        ([<ExcelArgument(Name="effectiveFloor",Description = "double")>] 
         effectiveFloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICouponPricer = Helper.toModelReference<CPICouponPricer> cpicouponpricer "CPICouponPricer"  
                let _effectiveFloor = Helper.toCell<double> effectiveFloor "effectiveFloor" 
                let builder (current : ICell) = ((CPICouponPricerModel.Cast _CPICouponPricer.cell).FloorletPrice
                                                            _effectiveFloor.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPICouponPricer.source + ".FloorletPrice") 

                                               [| _effectiveFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICouponPricer.cell
                                ;  _effectiveFloor.cell
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
    [<ExcelFunction(Name="_CPICouponPricer_floorletRate", Description="Create a CPICouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICouponPricer_floorletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICouponPricer",Description = "CPICouponPricer")>] 
         cpicouponpricer : obj)
        ([<ExcelArgument(Name="effectiveFloor",Description = "double")>] 
         effectiveFloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICouponPricer = Helper.toModelReference<CPICouponPricer> cpicouponpricer "CPICouponPricer"  
                let _effectiveFloor = Helper.toCell<double> effectiveFloor "effectiveFloor" 
                let builder (current : ICell) = ((CPICouponPricerModel.Cast _CPICouponPricer.cell).FloorletRate
                                                            _effectiveFloor.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPICouponPricer.source + ".FloorletRate") 

                                               [| _effectiveFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICouponPricer.cell
                                ;  _effectiveFloor.cell
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
    [<ExcelFunction(Name="_CPICouponPricer_initialize", Description="Create a CPICouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICouponPricer_initialize
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICouponPricer",Description = "CPICouponPricer")>] 
         cpicouponpricer : obj)
        ([<ExcelArgument(Name="coupon",Description = "InflationCoupon")>] 
         coupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICouponPricer = Helper.toModelReference<CPICouponPricer> cpicouponpricer "CPICouponPricer"  
                let _coupon = Helper.toCell<InflationCoupon> coupon "coupon" 
                let builder (current : ICell) = ((CPICouponPricerModel.Cast _CPICouponPricer.cell).Initialize
                                                            _coupon.cell 
                                                       ) :> ICell
                let format (o : CPICouponPricer) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CPICouponPricer.source + ".Initialize") 

                                               [| _coupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICouponPricer.cell
                                ;  _coupon.cell
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
    [<ExcelFunction(Name="_CPICouponPricer_setCapletVolatility", Description="Create a CPICouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICouponPricer_setCapletVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICouponPricer",Description = "CPICouponPricer")>] 
         cpicouponpricer : obj)
        ([<ExcelArgument(Name="capletVol",Description = "CPIVolatilitySurface")>] 
         capletVol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICouponPricer = Helper.toModelReference<CPICouponPricer> cpicouponpricer "CPICouponPricer"  
                let _capletVol = Helper.toHandle<CPIVolatilitySurface> capletVol "capletVol" 
                let builder (current : ICell) = ((CPICouponPricerModel.Cast _CPICouponPricer.cell).SetCapletVolatility
                                                            _capletVol.cell 
                                                       ) :> ICell
                let format (o : CPICouponPricer) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CPICouponPricer.source + ".SetCapletVolatility") 

                                               [| _capletVol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICouponPricer.cell
                                ;  _capletVol.cell
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
        InflationCouponPricer interface
    *)
    [<ExcelFunction(Name="_CPICouponPricer_swapletPrice", Description="Create a CPICouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICouponPricer_swapletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICouponPricer",Description = "CPICouponPricer")>] 
         cpicouponpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICouponPricer = Helper.toModelReference<CPICouponPricer> cpicouponpricer "CPICouponPricer"  
                let builder (current : ICell) = ((CPICouponPricerModel.Cast _CPICouponPricer.cell).SwapletPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPICouponPricer.source + ".SwapletPrice") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPICouponPricer.cell
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
    [<ExcelFunction(Name="_CPICouponPricer_swapletRate", Description="Create a CPICouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICouponPricer_swapletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICouponPricer",Description = "CPICouponPricer")>] 
         cpicouponpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICouponPricer = Helper.toModelReference<CPICouponPricer> cpicouponpricer "CPICouponPricer"  
                let builder (current : ICell) = ((CPICouponPricerModel.Cast _CPICouponPricer.cell).SwapletRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPICouponPricer.source + ".SwapletRate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPICouponPricer.cell
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
    [<ExcelFunction(Name="_CPICouponPricer_registerWith", Description="Create a CPICouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICouponPricer_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICouponPricer",Description = "CPICouponPricer")>] 
         cpicouponpricer : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICouponPricer = Helper.toModelReference<CPICouponPricer> cpicouponpricer "CPICouponPricer"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((CPICouponPricerModel.Cast _CPICouponPricer.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : CPICouponPricer) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CPICouponPricer.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICouponPricer.cell
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
    [<ExcelFunction(Name="_CPICouponPricer_unregisterWith", Description="Create a CPICouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICouponPricer_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICouponPricer",Description = "CPICouponPricer")>] 
         cpicouponpricer : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICouponPricer = Helper.toModelReference<CPICouponPricer> cpicouponpricer "CPICouponPricer"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((CPICouponPricerModel.Cast _CPICouponPricer.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : CPICouponPricer) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CPICouponPricer.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICouponPricer.cell
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
        observer interface
    *)
    [<ExcelFunction(Name="_CPICouponPricer_update", Description="Create a CPICouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICouponPricer_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICouponPricer",Description = "CPICouponPricer")>] 
         cpicouponpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICouponPricer = Helper.toModelReference<CPICouponPricer> cpicouponpricer "CPICouponPricer"  
                let builder (current : ICell) = ((CPICouponPricerModel.Cast _CPICouponPricer.cell).Update
                                                       ) :> ICell
                let format (o : CPICouponPricer) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CPICouponPricer.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPICouponPricer.cell
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
    [<ExcelFunction(Name="_CPICouponPricer_Range", Description="Create a range of CPICouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICouponPricer_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CPICouponPricer> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<CPICouponPricer> (c)) :> ICell
                let format (i : Cephei.Cell.List<CPICouponPricer>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<CPICouponPricer>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
