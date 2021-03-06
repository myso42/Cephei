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
  %Payoff based on a floating strike
  </summary> *)
[<AutoSerializable(true)>]
module FloatingTypePayoffFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FloatingTypePayoff", Description="Create a FloatingTypePayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingTypePayoff_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Type",Description = "Option.Type: Put, Call")>] 
         Type : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Type = Helper.toCell<Option.Type> Type "Type" 
                let builder (current : ICell) = (Fun.FloatingTypePayoff 
                                                            _Type.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingTypePayoff>) l

                let source () = Helper.sourceFold "Fun.FloatingTypePayoff" 
                                               [| _Type.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Type.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FloatingTypePayoff> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Payoff interface
    *)
    [<ExcelFunction(Name="_FloatingTypePayoff_name", Description="Create a FloatingTypePayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingTypePayoff_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingTypePayoff",Description = "FloatingTypePayoff")>] 
         floatingtypepayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingTypePayoff = Helper.toModelReference<FloatingTypePayoff> floatingtypepayoff "FloatingTypePayoff"  
                let builder (current : ICell) = ((FloatingTypePayoffModel.Cast _FloatingTypePayoff.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FloatingTypePayoff.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingTypePayoff.cell
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
    [<ExcelFunction(Name="_FloatingTypePayoff_value", Description="Create a FloatingTypePayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingTypePayoff_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingTypePayoff",Description = "FloatingTypePayoff")>] 
         floatingtypepayoff : obj)
        ([<ExcelArgument(Name="k",Description = "double")>] 
         k : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingTypePayoff = Helper.toModelReference<FloatingTypePayoff> floatingtypepayoff "FloatingTypePayoff"  
                let _k = Helper.toCell<double> k "k" 
                let builder (current : ICell) = ((FloatingTypePayoffModel.Cast _FloatingTypePayoff.cell).Value
                                                            _k.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingTypePayoff.source + ".Value") 

                                               [| _k.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingTypePayoff.cell
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
        Payoff interface
    *)
    [<ExcelFunction(Name="_FloatingTypePayoff_description", Description="Create a FloatingTypePayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingTypePayoff_description
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingTypePayoff",Description = "FloatingTypePayoff")>] 
         floatingtypepayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingTypePayoff = Helper.toModelReference<FloatingTypePayoff> floatingtypepayoff "FloatingTypePayoff"  
                let builder (current : ICell) = ((FloatingTypePayoffModel.Cast _FloatingTypePayoff.cell).Description
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FloatingTypePayoff.source + ".Description") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingTypePayoff.cell
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
    [<ExcelFunction(Name="_FloatingTypePayoff_optionType", Description="Create a FloatingTypePayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingTypePayoff_optionType
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingTypePayoff",Description = "FloatingTypePayoff")>] 
         floatingtypepayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingTypePayoff = Helper.toModelReference<FloatingTypePayoff> floatingtypepayoff "FloatingTypePayoff"  
                let builder (current : ICell) = ((FloatingTypePayoffModel.Cast _FloatingTypePayoff.cell).OptionType
                                                       ) :> ICell
                let format (o : Option.Type) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FloatingTypePayoff.source + ".OptionType") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingTypePayoff.cell
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
    [<ExcelFunction(Name="_FloatingTypePayoff_accept", Description="Create a FloatingTypePayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingTypePayoff_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingTypePayoff",Description = "FloatingTypePayoff")>] 
         floatingtypepayoff : obj)
        ([<ExcelArgument(Name="v",Description = "IAcyclicVisitor")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingTypePayoff = Helper.toModelReference<FloatingTypePayoff> floatingtypepayoff "FloatingTypePayoff"  
                let _v = Helper.toCell<IAcyclicVisitor> v "v" 
                let builder (current : ICell) = ((FloatingTypePayoffModel.Cast _FloatingTypePayoff.cell).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : FloatingTypePayoff) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FloatingTypePayoff.source + ".Accept") 

                                               [| _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingTypePayoff.cell
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
    [<ExcelFunction(Name="_FloatingTypePayoff_Range", Description="Create a range of FloatingTypePayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingTypePayoff_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FloatingTypePayoff> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<FloatingTypePayoff> (c)) :> ICell
                let format (i : Cephei.Cell.List<FloatingTypePayoff>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<FloatingTypePayoff>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
