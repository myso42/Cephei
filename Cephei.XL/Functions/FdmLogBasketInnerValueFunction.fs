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
module FdmLogBasketInnerValueFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FdmLogBasketInnerValue_avgInnerValue", Description="Create a FdmLogBasketInnerValue",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmLogBasketInnerValue_avgInnerValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmLogBasketInnerValue",Description = "FdmLogBasketInnerValue")>] 
         fdmlogbasketinnervalue : obj)
        ([<ExcelArgument(Name="iter",Description = "FdmLinearOpIterator")>] 
         iter : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmLogBasketInnerValue = Helper.toModelReference<FdmLogBasketInnerValue> fdmlogbasketinnervalue "FdmLogBasketInnerValue"  
                let _iter = Helper.toCell<FdmLinearOpIterator> iter "iter" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = ((FdmLogBasketInnerValueModel.Cast _FdmLogBasketInnerValue.cell).AvgInnerValue
                                                            _iter.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FdmLogBasketInnerValue.source + ".AvgInnerValue") 

                                               [| _iter.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmLogBasketInnerValue.cell
                                ;  _iter.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_FdmLogBasketInnerValue", Description="Create a FdmLogBasketInnerValue",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmLogBasketInnerValue_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="payoff",Description = "BasketPayoff")>] 
         payoff : obj)
        ([<ExcelArgument(Name="mesher",Description = "FdmMesher")>] 
         mesher : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _payoff = Helper.toCell<BasketPayoff> payoff "payoff" 
                let _mesher = Helper.toCell<FdmMesher> mesher "mesher" 
                let builder (current : ICell) = (Fun.FdmLogBasketInnerValue 
                                                            _payoff.cell 
                                                            _mesher.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmLogBasketInnerValue>) l

                let source () = Helper.sourceFold "Fun.FdmLogBasketInnerValue" 
                                               [| _payoff.source
                                               ;  _mesher.source
                                               |]
                let hash = Helper.hashFold 
                                [| _payoff.cell
                                ;  _mesher.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmLogBasketInnerValue> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmLogBasketInnerValue_innerValue", Description="Create a FdmLogBasketInnerValue",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmLogBasketInnerValue_innerValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmLogBasketInnerValue",Description = "FdmLogBasketInnerValue")>] 
         fdmlogbasketinnervalue : obj)
        ([<ExcelArgument(Name="iter",Description = "FdmLinearOpIterator")>] 
         iter : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmLogBasketInnerValue = Helper.toModelReference<FdmLogBasketInnerValue> fdmlogbasketinnervalue "FdmLogBasketInnerValue"  
                let _iter = Helper.toCell<FdmLinearOpIterator> iter "iter" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = ((FdmLogBasketInnerValueModel.Cast _FdmLogBasketInnerValue.cell).InnerValue
                                                            _iter.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FdmLogBasketInnerValue.source + ".InnerValue") 

                                               [| _iter.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmLogBasketInnerValue.cell
                                ;  _iter.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_FdmLogBasketInnerValue_Range", Description="Create a range of FdmLogBasketInnerValue",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmLogBasketInnerValue_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FdmLogBasketInnerValue> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<FdmLogBasketInnerValue> (c)) :> ICell
                let format (i : Cephei.Cell.List<FdmLogBasketInnerValue>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<FdmLogBasketInnerValue>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
