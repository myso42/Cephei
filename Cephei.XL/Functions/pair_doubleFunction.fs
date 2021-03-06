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
module pair_doubleFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_pair_double_CompareTo", Description="Create a pair_double",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let pair_double_CompareTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="pair_double",Description = "pair_double")>] 
         pair_double : obj)
        ([<ExcelArgument(Name="other",Description = "double,double")>] 
         other : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _pair_double = Helper.toModelReference<pair_double> pair_double "pair_double"  
                let _other = Helper.toCell<Pair<double,double>> other "other" 
                let builder (current : ICell) = ((pair_doubleModel.Cast _pair_double.cell).CompareTo
                                                            _other.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_pair_double.source + ".CompareTo") 

                                               [| _other.source
                                               |]
                let hash = Helper.hashFold 
                                [| _pair_double.cell
                                ;  _other.cell
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
    [<ExcelFunction(Name="_pair_double", Description="Create a pair_double",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let pair_double_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="first",Description = "double")>] 
         first : obj)
        ([<ExcelArgument(Name="second",Description = "double")>] 
         second : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _first = Helper.toCell<double> first "first" 
                let _second = Helper.toCell<double> second "second" 
                let builder (current : ICell) = (Fun.pair_double 
                                                            _first.cell 
                                                            _second.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<pair_double>) l

                let source () = Helper.sourceFold "Fun.pair_double" 
                                               [| _first.source
                                               ;  _second.source
                                               |]
                let hash = Helper.hashFold 
                                [| _first.cell
                                ;  _second.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<pair_double> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_pair_double_first", Description="Create a pair_double",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let pair_double_first
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="pair_double",Description = "pair_double")>] 
         pair_double : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _pair_double = Helper.toModelReference<pair_double> pair_double "pair_double"  
                let builder (current : ICell) = ((pair_doubleModel.Cast _pair_double.cell).First
                                                       ) :> ICell
                let format (o : double) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_pair_double.source + ".First") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _pair_double.cell
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
    [<ExcelFunction(Name="_pair_double_second", Description="Create a pair_double",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let pair_double_second
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="pair_double",Description = "pair_double")>] 
         pair_double : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _pair_double = Helper.toModelReference<pair_double> pair_double "pair_double"  
                let builder (current : ICell) = ((pair_doubleModel.Cast _pair_double.cell).Second
                                                       ) :> ICell
                let format (o : double) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_pair_double.source + ".Second") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _pair_double.cell
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
    [<ExcelFunction(Name="_pair_double_set", Description="Create a pair_double",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let pair_double_set
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="pair_double",Description = "pair_double")>] 
         pair_double : obj)
        ([<ExcelArgument(Name="first",Description = "double")>] 
         first : obj)
        ([<ExcelArgument(Name="second",Description = "double")>] 
         second : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _pair_double = Helper.toModelReference<pair_double> pair_double "pair_double"  
                let _first = Helper.toCell<double> first "first" 
                let _second = Helper.toCell<double> second "second" 
                let builder (current : ICell) = ((pair_doubleModel.Cast _pair_double.cell).Set
                                                            _first.cell 
                                                            _second.cell 
                                                       ) :> ICell
                let format (o : pair_double) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_pair_double.source + ".Set") 

                                               [| _first.source
                                               ;  _second.source
                                               |]
                let hash = Helper.hashFold 
                                [| _pair_double.cell
                                ;  _first.cell
                                ;  _second.cell
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
    [<ExcelFunction(Name="_pair_double_Range", Description="Create a range of pair_double",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let pair_double_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<pair_double> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<pair_double> (c)) :> ICell
                let format (i : Cephei.Cell.List<pair_double>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<pair_double>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
