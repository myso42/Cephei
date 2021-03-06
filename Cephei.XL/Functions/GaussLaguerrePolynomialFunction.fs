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
  Gauss-Laguerre polynomial
  </summary> *)
[<AutoSerializable(true)>]
module GaussLaguerrePolynomialFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_GaussLaguerrePolynomial_alpha", Description="Create a GaussLaguerrePolynomial",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussLaguerrePolynomial_alpha
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussLaguerrePolynomial",Description = "GaussLaguerrePolynomial")>] 
         gausslaguerrepolynomial : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussLaguerrePolynomial = Helper.toModelReference<GaussLaguerrePolynomial> gausslaguerrepolynomial "GaussLaguerrePolynomial"  
                let _i = Helper.toCell<int> i "i" 
                let builder (current : ICell) = ((GaussLaguerrePolynomialModel.Cast _GaussLaguerrePolynomial.cell).Alpha
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GaussLaguerrePolynomial.source + ".Alpha") 

                                               [| _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussLaguerrePolynomial.cell
                                ;  _i.cell
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
    [<ExcelFunction(Name="_GaussLaguerrePolynomial_beta", Description="Create a GaussLaguerrePolynomial",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussLaguerrePolynomial_beta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussLaguerrePolynomial",Description = "GaussLaguerrePolynomial")>] 
         gausslaguerrepolynomial : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussLaguerrePolynomial = Helper.toModelReference<GaussLaguerrePolynomial> gausslaguerrepolynomial "GaussLaguerrePolynomial"  
                let _i = Helper.toCell<int> i "i" 
                let builder (current : ICell) = ((GaussLaguerrePolynomialModel.Cast _GaussLaguerrePolynomial.cell).Beta
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GaussLaguerrePolynomial.source + ".Beta") 

                                               [| _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussLaguerrePolynomial.cell
                                ;  _i.cell
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
    [<ExcelFunction(Name="_GaussLaguerrePolynomial1", Description="Create a GaussLaguerrePolynomial",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussLaguerrePolynomial_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="s",Description = "double")>] 
         s : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _s = Helper.toCell<double> s "s" 
                let builder (current : ICell) = (Fun.GaussLaguerrePolynomial1 
                                                            _s.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GaussLaguerrePolynomial>) l

                let source () = Helper.sourceFold "Fun.GaussLaguerrePolynomial1" 
                                               [| _s.source
                                               |]
                let hash = Helper.hashFold 
                                [| _s.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GaussLaguerrePolynomial> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_GaussLaguerrePolynomial", Description="Create a GaussLaguerrePolynomial",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussLaguerrePolynomial_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = (Fun.GaussLaguerrePolynomial ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GaussLaguerrePolynomial>) l

                let source () = Helper.sourceFold "Fun.GaussLaguerrePolynomial" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GaussLaguerrePolynomial> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_GaussLaguerrePolynomial_mu_0", Description="Create a GaussLaguerrePolynomial",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussLaguerrePolynomial_mu_0
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussLaguerrePolynomial",Description = "GaussLaguerrePolynomial")>] 
         gausslaguerrepolynomial : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussLaguerrePolynomial = Helper.toModelReference<GaussLaguerrePolynomial> gausslaguerrepolynomial "GaussLaguerrePolynomial"  
                let builder (current : ICell) = ((GaussLaguerrePolynomialModel.Cast _GaussLaguerrePolynomial.cell).Mu_0
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GaussLaguerrePolynomial.source + ".Mu_0") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GaussLaguerrePolynomial.cell
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
    [<ExcelFunction(Name="_GaussLaguerrePolynomial_w", Description="Create a GaussLaguerrePolynomial",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussLaguerrePolynomial_w
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussLaguerrePolynomial",Description = "GaussLaguerrePolynomial")>] 
         gausslaguerrepolynomial : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussLaguerrePolynomial = Helper.toModelReference<GaussLaguerrePolynomial> gausslaguerrepolynomial "GaussLaguerrePolynomial"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = ((GaussLaguerrePolynomialModel.Cast _GaussLaguerrePolynomial.cell).W
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GaussLaguerrePolynomial.source + ".W") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussLaguerrePolynomial.cell
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
    (*
        
    *)
    [<ExcelFunction(Name="_GaussLaguerrePolynomial_value", Description="Create a GaussLaguerrePolynomial",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussLaguerrePolynomial_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussLaguerrePolynomial",Description = "GaussLaguerrePolynomial")>] 
         gausslaguerrepolynomial : obj)
        ([<ExcelArgument(Name="n",Description = "int")>] 
         n : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussLaguerrePolynomial = Helper.toModelReference<GaussLaguerrePolynomial> gausslaguerrepolynomial "GaussLaguerrePolynomial"  
                let _n = Helper.toCell<int> n "n" 
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = ((GaussLaguerrePolynomialModel.Cast _GaussLaguerrePolynomial.cell).Value
                                                            _n.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GaussLaguerrePolynomial.source + ".Value") 

                                               [| _n.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussLaguerrePolynomial.cell
                                ;  _n.cell
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
    (*
        
    *)
    [<ExcelFunction(Name="_GaussLaguerrePolynomial_weightedValue", Description="Create a GaussLaguerrePolynomial",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussLaguerrePolynomial_weightedValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussLaguerrePolynomial",Description = "GaussLaguerrePolynomial")>] 
         gausslaguerrepolynomial : obj)
        ([<ExcelArgument(Name="n",Description = "int")>] 
         n : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussLaguerrePolynomial = Helper.toModelReference<GaussLaguerrePolynomial> gausslaguerrepolynomial "GaussLaguerrePolynomial"  
                let _n = Helper.toCell<int> n "n" 
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = ((GaussLaguerrePolynomialModel.Cast _GaussLaguerrePolynomial.cell).WeightedValue
                                                            _n.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GaussLaguerrePolynomial.source + ".WeightedValue") 

                                               [| _n.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussLaguerrePolynomial.cell
                                ;  _n.cell
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
    [<ExcelFunction(Name="_GaussLaguerrePolynomial_Range", Description="Create a range of GaussLaguerrePolynomial",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussLaguerrePolynomial_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<GaussLaguerrePolynomial> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<GaussLaguerrePolynomial> (c)) :> ICell
                let format (i : Cephei.Cell.List<GaussLaguerrePolynomial>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<GaussLaguerrePolynomial>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
