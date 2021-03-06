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
  Callable zero coupon bond, where the embedded (European) option price is assumed to obey the Black formula. Follows "European bond option" treatment in Hull, Fourth Edition, Chapter 20.  This class has yet to be tested.  callablebondengines
  </summary> *)
[<AutoSerializable(true)>]
module BlackCallableZeroCouponBondEngineFunction =

    (*
        ! volatility is the quoted fwd yield volatility, not price vol
    *)
    [<ExcelFunction(Name="_BlackCallableZeroCouponBondEngine", Description="Create a BlackCallableZeroCouponBondEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackCallableZeroCouponBondEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="yieldVolStructure",Description = "CallableBondVolatilityStructure")>] 
         yieldVolStructure : obj)
        ([<ExcelArgument(Name="discountCurve",Description = "YieldTermStructure")>] 
         discountCurve : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _yieldVolStructure = Helper.toHandle<CallableBondVolatilityStructure> yieldVolStructure "yieldVolStructure" 
                let _discountCurve = Helper.toHandle<YieldTermStructure> discountCurve "discountCurve" 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = (Fun.BlackCallableZeroCouponBondEngine 
                                                            _yieldVolStructure.cell 
                                                            _discountCurve.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BlackCallableZeroCouponBondEngine>) l

                let source () = Helper.sourceFold "Fun.BlackCallableZeroCouponBondEngine" 
                                               [| _yieldVolStructure.source
                                               ;  _discountCurve.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _yieldVolStructure.cell
                                ;  _discountCurve.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackCallableZeroCouponBondEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! volatility is the quoted fwd yield volatility, not price vol
    *)
    [<ExcelFunction(Name="_BlackCallableZeroCouponBondEngine1", Description="Create a BlackCallableZeroCouponBondEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackCallableZeroCouponBondEngine_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="fwdYieldVol",Description = "Quote")>] 
         fwdYieldVol : obj)
        ([<ExcelArgument(Name="discountCurve",Description = "YieldTermStructure")>] 
         discountCurve : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _fwdYieldVol = Helper.toHandle<Quote> fwdYieldVol "fwdYieldVol" 
                let _discountCurve = Helper.toHandle<YieldTermStructure> discountCurve "discountCurve" 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = (Fun.BlackCallableZeroCouponBondEngine1 
                                                            _fwdYieldVol.cell 
                                                            _discountCurve.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BlackCallableZeroCouponBondEngine>) l

                let source () = Helper.sourceFold "Fun.BlackCallableZeroCouponBondEngine1" 
                                               [| _fwdYieldVol.source
                                               ;  _discountCurve.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _fwdYieldVol.cell
                                ;  _discountCurve.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackCallableZeroCouponBondEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"

    [<ExcelFunction(Name="_BlackCallableZeroCouponBondEngine_Range", Description="Create a range of BlackCallableZeroCouponBondEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackCallableZeroCouponBondEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BlackCallableZeroCouponBondEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<BlackCallableZeroCouponBondEngine> (c)) :> ICell
                let format (i : Cephei.Cell.List<BlackCallableZeroCouponBondEngine>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<BlackCallableZeroCouponBondEngine>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
