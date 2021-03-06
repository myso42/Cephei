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
  References: http://en.wikipedia.org/wiki/Richardson_extrapolation
  </summary> *)
[<AutoSerializable(true)>]
module RichardsonEqnFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_RichardsonEqn", Description="Create a RichardsonEqn",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RichardsonEqn_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="fh",Description = "double")>] 
         fh : obj)
        ([<ExcelArgument(Name="ft",Description = "double")>] 
         ft : obj)
        ([<ExcelArgument(Name="fs",Description = "double")>] 
         fs : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="s",Description = "double")>] 
         s : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _fh = Helper.toCell<double> fh "fh" 
                let _ft = Helper.toCell<double> ft "ft" 
                let _fs = Helper.toCell<double> fs "fs" 
                let _t = Helper.toCell<double> t "t" 
                let _s = Helper.toCell<double> s "s" 
                let builder (current : ICell) = (Fun.RichardsonEqn 
                                                            _fh.cell 
                                                            _ft.cell 
                                                            _fs.cell 
                                                            _t.cell 
                                                            _s.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RichardsonEqn>) l

                let source () = Helper.sourceFold "Fun.RichardsonEqn" 
                                               [| _fh.source
                                               ;  _ft.source
                                               ;  _fs.source
                                               ;  _t.source
                                               ;  _s.source
                                               |]
                let hash = Helper.hashFold 
                                [| _fh.cell
                                ;  _ft.cell
                                ;  _fs.cell
                                ;  _t.cell
                                ;  _s.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<RichardsonEqn> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_RichardsonEqn_value", Description="Create a RichardsonEqn",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RichardsonEqn_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RichardsonEqn",Description = "RichardsonEqn")>] 
         richardsoneqn : obj)
        ([<ExcelArgument(Name="k",Description = "double")>] 
         k : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RichardsonEqn = Helper.toModelReference<RichardsonEqn> richardsoneqn "RichardsonEqn"  
                let _k = Helper.toCell<double> k "k" 
                let builder (current : ICell) = ((RichardsonEqnModel.Cast _RichardsonEqn.cell).Value
                                                            _k.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RichardsonEqn.source + ".Value") 

                                               [| _k.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RichardsonEqn.cell
                                ;  _k.cell
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
    [<ExcelFunction(Name="_RichardsonEqn_derivative", Description="Create a RichardsonEqn",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RichardsonEqn_derivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RichardsonEqn",Description = "RichardsonEqn")>] 
         richardsoneqn : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RichardsonEqn = Helper.toModelReference<RichardsonEqn> richardsoneqn "RichardsonEqn"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = ((RichardsonEqnModel.Cast _RichardsonEqn.cell).Derivative
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RichardsonEqn.source + ".Derivative") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RichardsonEqn.cell
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
    [<ExcelFunction(Name="_RichardsonEqn_Range", Description="Create a range of RichardsonEqn",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RichardsonEqn_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<RichardsonEqn> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<RichardsonEqn> (c)) :> ICell
                let format (i : Cephei.Cell.List<RichardsonEqn>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<RichardsonEqn>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
