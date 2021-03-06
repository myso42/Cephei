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
  This cash flow pays a predetermined amount at a given date.
  </summary> *)
[<AutoSerializable(true)>]
module FractionalDividendFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FractionalDividend_amount1", Description="Create a FractionalDividend",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FractionalDividend_amount1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FractionalDividend",Description = "FractionalDividend")>] 
         fractionaldividend : obj)
        ([<ExcelArgument(Name="underlying",Description = "double")>] 
         underlying : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FractionalDividend = Helper.toModelReference<FractionalDividend> fractionaldividend "FractionalDividend"  
                let _underlying = Helper.toCell<double> underlying "underlying" 
                let builder (current : ICell) = ((FractionalDividendModel.Cast _FractionalDividend.cell).Amount1
                                                            _underlying.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FractionalDividend.source + ".Amount1") 

                                               [| _underlying.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FractionalDividend.cell
                                ;  _underlying.cell
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
        Dividend interface
    *)
    [<ExcelFunction(Name="_FractionalDividend_amount", Description="Create a FractionalDividend",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FractionalDividend_amount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FractionalDividend",Description = "FractionalDividend")>] 
         fractionaldividend : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FractionalDividend = Helper.toModelReference<FractionalDividend> fractionaldividend "FractionalDividend"  
                let builder (current : ICell) = ((FractionalDividendModel.Cast _FractionalDividend.cell).Amount
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FractionalDividend.source + ".Amount") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FractionalDividend.cell
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
    [<ExcelFunction(Name="_FractionalDividend", Description="Create a FractionalDividend",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FractionalDividend_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="rate",Description = "double")>] 
         rate : obj)
        ([<ExcelArgument(Name="nominal",Description = "double")>] 
         nominal : obj)
        ([<ExcelArgument(Name="date",Description = "Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _rate = Helper.toCell<double> rate "rate" 
                let _nominal = Helper.toCell<double> nominal "nominal" 
                let _date = Helper.toCell<Date> date "date" 
                let builder (current : ICell) = (Fun.FractionalDividend 
                                                            _rate.cell 
                                                            _nominal.cell 
                                                            _date.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FractionalDividend>) l

                let source () = Helper.sourceFold "Fun.FractionalDividend" 
                                               [| _rate.source
                                               ;  _nominal.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _rate.cell
                                ;  _nominal.cell
                                ;  _date.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FractionalDividend> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FractionalDividend1", Description="Create a FractionalDividend",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FractionalDividend_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="rate",Description = "double")>] 
         rate : obj)
        ([<ExcelArgument(Name="date",Description = "Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _rate = Helper.toCell<double> rate "rate" 
                let _date = Helper.toCell<Date> date "date" 
                let builder (current : ICell) = (Fun.FractionalDividend1 
                                                            _rate.cell 
                                                            _date.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FractionalDividend>) l

                let source () = Helper.sourceFold "Fun.FractionalDividend1" 
                                               [| _rate.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _rate.cell
                                ;  _date.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FractionalDividend> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FractionalDividend_nominal", Description="Create a FractionalDividend",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FractionalDividend_nominal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FractionalDividend",Description = "FractionalDividend")>] 
         fractionaldividend : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FractionalDividend = Helper.toModelReference<FractionalDividend> fractionaldividend "FractionalDividend"  
                let builder (current : ICell) = ((FractionalDividendModel.Cast _FractionalDividend.cell).Nominal
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FractionalDividend.source + ".Nominal") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FractionalDividend.cell
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
    [<ExcelFunction(Name="_FractionalDividend_rate", Description="Create a FractionalDividend",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FractionalDividend_rate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FractionalDividend",Description = "FractionalDividend")>] 
         fractionaldividend : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FractionalDividend = Helper.toModelReference<FractionalDividend> fractionaldividend "FractionalDividend"  
                let builder (current : ICell) = ((FractionalDividendModel.Cast _FractionalDividend.cell).Rate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FractionalDividend.source + ".Rate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FractionalDividend.cell
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
        Event interface
    *)
    [<ExcelFunction(Name="_FractionalDividend_date", Description="Create a FractionalDividend",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FractionalDividend_date
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FractionalDividend",Description = "FractionalDividend")>] 
         fractionaldividend : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FractionalDividend = Helper.toModelReference<FractionalDividend> fractionaldividend "FractionalDividend"  
                let builder (current : ICell) = ((FractionalDividendModel.Cast _FractionalDividend.cell).Date
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FractionalDividend.source + ".Date") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FractionalDividend.cell
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
    [<ExcelFunction(Name="_FractionalDividend_CompareTo", Description="Create a FractionalDividend",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FractionalDividend_CompareTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FractionalDividend",Description = "FractionalDividend")>] 
         fractionaldividend : obj)
        ([<ExcelArgument(Name="cf",Description = "CashFlow")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FractionalDividend = Helper.toModelReference<FractionalDividend> fractionaldividend "FractionalDividend"  
                let _cf = Helper.toCell<CashFlow> cf "cf" 
                let builder (current : ICell) = ((FractionalDividendModel.Cast _FractionalDividend.cell).CompareTo
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FractionalDividend.source + ".CompareTo") 

                                               [| _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FractionalDividend.cell
                                ;  _cf.cell
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
    [<ExcelFunction(Name="_FractionalDividend_Equals", Description="Create a FractionalDividend",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FractionalDividend_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FractionalDividend",Description = "FractionalDividend")>] 
         fractionaldividend : obj)
        ([<ExcelArgument(Name="cf",Description = "Object")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FractionalDividend = Helper.toModelReference<FractionalDividend> fractionaldividend "FractionalDividend"  
                let _cf = Helper.toCell<Object> cf "cf" 
                let builder (current : ICell) = ((FractionalDividendModel.Cast _FractionalDividend.cell).Equals
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FractionalDividend.source + ".Equals") 

                                               [| _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FractionalDividend.cell
                                ;  _cf.cell
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
        ! returns the date that the cash flow trades exCoupon
    *)
    [<ExcelFunction(Name="_FractionalDividend_exCouponDate", Description="Create a FractionalDividend",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FractionalDividend_exCouponDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FractionalDividend",Description = "FractionalDividend")>] 
         fractionaldividend : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FractionalDividend = Helper.toModelReference<FractionalDividend> fractionaldividend "FractionalDividend"  
                let builder (current : ICell) = ((FractionalDividendModel.Cast _FractionalDividend.cell).ExCouponDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FractionalDividend.source + ".ExCouponDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FractionalDividend.cell
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
    [<ExcelFunction(Name="_FractionalDividend_hasOccurred", Description="Create a FractionalDividend",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FractionalDividend_hasOccurred
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FractionalDividend",Description = "FractionalDividend")>] 
         fractionaldividend : obj)
        ([<ExcelArgument(Name="refDate",Description = "Date")>] 
         refDate : obj)
        ([<ExcelArgument(Name="includeRefDate",Description = "bool")>] 
         includeRefDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FractionalDividend = Helper.toModelReference<FractionalDividend> fractionaldividend "FractionalDividend"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let _includeRefDate = Helper.toNullable<bool> includeRefDate "includeRefDate"
                let builder (current : ICell) = ((FractionalDividendModel.Cast _FractionalDividend.cell).HasOccurred
                                                            _refDate.cell 
                                                            _includeRefDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FractionalDividend.source + ".HasOccurred") 

                                               [| _refDate.source
                                               ;  _includeRefDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FractionalDividend.cell
                                ;  _refDate.cell
                                ;  _includeRefDate.cell
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
        ! returns true if the cashflow is trading ex-coupon on the refDate
    *)
    [<ExcelFunction(Name="_FractionalDividend_tradingExCoupon", Description="Create a FractionalDividend",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FractionalDividend_tradingExCoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FractionalDividend",Description = "FractionalDividend")>] 
         fractionaldividend : obj)
        ([<ExcelArgument(Name="refDate",Description = "Date")>] 
         refDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FractionalDividend = Helper.toModelReference<FractionalDividend> fractionaldividend "FractionalDividend"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let builder (current : ICell) = ((FractionalDividendModel.Cast _FractionalDividend.cell).TradingExCoupon
                                                            _refDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FractionalDividend.source + ".TradingExCoupon") 

                                               [| _refDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FractionalDividend.cell
                                ;  _refDate.cell
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
    [<ExcelFunction(Name="_FractionalDividend_accept", Description="Create a FractionalDividend",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FractionalDividend_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FractionalDividend",Description = "FractionalDividend")>] 
         fractionaldividend : obj)
        ([<ExcelArgument(Name="v",Description = "IAcyclicVisitor")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FractionalDividend = Helper.toModelReference<FractionalDividend> fractionaldividend "FractionalDividend"  
                let _v = Helper.toCell<IAcyclicVisitor> v "v" 
                let builder (current : ICell) = ((FractionalDividendModel.Cast _FractionalDividend.cell).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : FractionalDividend) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FractionalDividend.source + ".Accept") 

                                               [| _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FractionalDividend.cell
                                ;  _v.cell
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
    [<ExcelFunction(Name="_FractionalDividend_registerWith", Description="Create a FractionalDividend",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FractionalDividend_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FractionalDividend",Description = "FractionalDividend")>] 
         fractionaldividend : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FractionalDividend = Helper.toModelReference<FractionalDividend> fractionaldividend "FractionalDividend"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((FractionalDividendModel.Cast _FractionalDividend.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : FractionalDividend) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FractionalDividend.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FractionalDividend.cell
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
    [<ExcelFunction(Name="_FractionalDividend_unregisterWith", Description="Create a FractionalDividend",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FractionalDividend_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FractionalDividend",Description = "FractionalDividend")>] 
         fractionaldividend : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FractionalDividend = Helper.toModelReference<FractionalDividend> fractionaldividend "FractionalDividend"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((FractionalDividendModel.Cast _FractionalDividend.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : FractionalDividend) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FractionalDividend.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FractionalDividend.cell
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
    [<ExcelFunction(Name="_FractionalDividend_Range", Description="Create a range of FractionalDividend",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FractionalDividend_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FractionalDividend> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<FractionalDividend> (c)) :> ICell
                let format (i : Cephei.Cell.List<FractionalDividend>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<FractionalDividend>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
