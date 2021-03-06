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
  This payoff is equivalent to being (1/lowerstrike) a) long (short) an AssetOrNothing Call (Put) at the lower strike and b) short (long) an AssetOrNothing Call (Put) at the higher strike
  </summary> *)
[<AutoSerializable(true)>]
module SuperFundPayoffFunction =

    (*
        Payoff interface
    *)
    [<ExcelFunction(Name="_SuperFundPayoff_name", Description="Create a SuperFundPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SuperFundPayoff_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SuperFundPayoff",Description = "SuperFundPayoff")>] 
         superfundpayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SuperFundPayoff = Helper.toModelReference<SuperFundPayoff> superfundpayoff "SuperFundPayoff"  
                let builder (current : ICell) = ((SuperFundPayoffModel.Cast _SuperFundPayoff.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SuperFundPayoff.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SuperFundPayoff.cell
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
    [<ExcelFunction(Name="_SuperFundPayoff_secondStrike", Description="Create a SuperFundPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SuperFundPayoff_secondStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SuperFundPayoff",Description = "SuperFundPayoff")>] 
         superfundpayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SuperFundPayoff = Helper.toModelReference<SuperFundPayoff> superfundpayoff "SuperFundPayoff"  
                let builder (current : ICell) = ((SuperFundPayoffModel.Cast _SuperFundPayoff.cell).SecondStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SuperFundPayoff.source + ".SecondStrike") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SuperFundPayoff.cell
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
    [<ExcelFunction(Name="_SuperFundPayoff", Description="Create a SuperFundPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SuperFundPayoff_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="secondStrike",Description = "double")>] 
         secondStrike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _strike = Helper.toCell<double> strike "strike" 
                let _secondStrike = Helper.toCell<double> secondStrike "secondStrike" 
                let builder (current : ICell) = (Fun.SuperFundPayoff 
                                                            _strike.cell 
                                                            _secondStrike.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SuperFundPayoff>) l

                let source () = Helper.sourceFold "Fun.SuperFundPayoff" 
                                               [| _strike.source
                                               ;  _secondStrike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _strike.cell
                                ;  _secondStrike.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SuperFundPayoff> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SuperFundPayoff_value", Description="Create a SuperFundPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SuperFundPayoff_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SuperFundPayoff",Description = "SuperFundPayoff")>] 
         superfundpayoff : obj)
        ([<ExcelArgument(Name="price",Description = "double")>] 
         price : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SuperFundPayoff = Helper.toModelReference<SuperFundPayoff> superfundpayoff "SuperFundPayoff"  
                let _price = Helper.toCell<double> price "price" 
                let builder (current : ICell) = ((SuperFundPayoffModel.Cast _SuperFundPayoff.cell).Value
                                                            _price.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SuperFundPayoff.source + ".Value") 

                                               [| _price.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SuperFundPayoff.cell
                                ;  _price.cell
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
    [<ExcelFunction(Name="_SuperFundPayoff_description", Description="Create a SuperFundPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SuperFundPayoff_description
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SuperFundPayoff",Description = "SuperFundPayoff")>] 
         superfundpayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SuperFundPayoff = Helper.toModelReference<SuperFundPayoff> superfundpayoff "SuperFundPayoff"  
                let builder (current : ICell) = ((SuperFundPayoffModel.Cast _SuperFundPayoff.cell).Description
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SuperFundPayoff.source + ".Description") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SuperFundPayoff.cell
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
    [<ExcelFunction(Name="_SuperFundPayoff_strike", Description="Create a SuperFundPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SuperFundPayoff_strike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SuperFundPayoff",Description = "SuperFundPayoff")>] 
         superfundpayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SuperFundPayoff = Helper.toModelReference<SuperFundPayoff> superfundpayoff "SuperFundPayoff"  
                let builder (current : ICell) = ((SuperFundPayoffModel.Cast _SuperFundPayoff.cell).Strike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SuperFundPayoff.source + ".Strike") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SuperFundPayoff.cell
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
    [<ExcelFunction(Name="_SuperFundPayoff_optionType", Description="Create a SuperFundPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SuperFundPayoff_optionType
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SuperFundPayoff",Description = "SuperFundPayoff")>] 
         superfundpayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SuperFundPayoff = Helper.toModelReference<SuperFundPayoff> superfundpayoff "SuperFundPayoff"  
                let builder (current : ICell) = ((SuperFundPayoffModel.Cast _SuperFundPayoff.cell).OptionType
                                                       ) :> ICell
                let format (o : Option.Type) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SuperFundPayoff.source + ".OptionType") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SuperFundPayoff.cell
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
    [<ExcelFunction(Name="_SuperFundPayoff_accept", Description="Create a SuperFundPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SuperFundPayoff_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SuperFundPayoff",Description = "SuperFundPayoff")>] 
         superfundpayoff : obj)
        ([<ExcelArgument(Name="v",Description = "IAcyclicVisitor")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SuperFundPayoff = Helper.toModelReference<SuperFundPayoff> superfundpayoff "SuperFundPayoff"  
                let _v = Helper.toCell<IAcyclicVisitor> v "v" 
                let builder (current : ICell) = ((SuperFundPayoffModel.Cast _SuperFundPayoff.cell).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : SuperFundPayoff) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SuperFundPayoff.source + ".Accept") 

                                               [| _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SuperFundPayoff.cell
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
    [<ExcelFunction(Name="_SuperFundPayoff_Range", Description="Create a range of SuperFundPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SuperFundPayoff_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SuperFundPayoff> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<SuperFundPayoff> (c)) :> ICell
                let format (i : Cephei.Cell.List<SuperFundPayoff>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<SuperFundPayoff>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
