(*
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
  Intermediate class for put/call payoffs
  </summary> *)
[<AutoSerializable(true)>]
module TypePayoffFunction =

    (*
        Payoff interface
    *)
    [<ExcelFunction(Name="_TypePayoff_description", Description="Create a TypePayoff",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TypePayoff_description
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TypePayoff",Description = "Reference to TypePayoff")>] 
         typepayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TypePayoff = Helper.toCell<TypePayoff> typepayoff "TypePayoff" true 
                let builder () = withMnemonic mnemonic ((_TypePayoff.cell :?> TypePayoffModel).Description
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TypePayoff.source + ".Description") 
                                               [| _TypePayoff.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TypePayoff.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_TypePayoff_optionType", Description="Create a TypePayoff",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TypePayoff_optionType
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TypePayoff",Description = "Reference to TypePayoff")>] 
         typepayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TypePayoff = Helper.toCell<TypePayoff> typepayoff "TypePayoff" true 
                let builder () = withMnemonic mnemonic ((_TypePayoff.cell :?> TypePayoffModel).OptionType
                                                       ) :> ICell
                let format (o : Option.Type) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TypePayoff.source + ".OptionType") 
                                               [| _TypePayoff.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TypePayoff.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_TypePayoff", Description="Create a TypePayoff",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TypePayoff_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Type = Helper.toCell<Option.Type> Type "Type" true
                let builder () = withMnemonic mnemonic (Fun.TypePayoff 
                                                            _Type.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TypePayoff>) l

                let source = Helper.sourceFold "Fun.TypePayoff" 
                                               [| _Type.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Type.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TypePayoff_accept", Description="Create a TypePayoff",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TypePayoff_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TypePayoff",Description = "Reference to TypePayoff")>] 
         typepayoff : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TypePayoff = Helper.toCell<TypePayoff> typepayoff "TypePayoff" true 
                let _v = Helper.toCell<IAcyclicVisitor> v "v" true
                let builder () = withMnemonic mnemonic ((_TypePayoff.cell :?> TypePayoffModel).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : TypePayoff) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TypePayoff.source + ".Accept") 
                                               [| _TypePayoff.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TypePayoff.cell
                                ;  _v.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
        ! \warning This method is used for output and comparison between payoffs. It is <b>not</b> meant to be used for writing switch-on-type code.
    *)
    [<ExcelFunction(Name="_TypePayoff_name", Description="Create a TypePayoff",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TypePayoff_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TypePayoff",Description = "Reference to TypePayoff")>] 
         typepayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TypePayoff = Helper.toCell<TypePayoff> typepayoff "TypePayoff" true 
                let builder () = withMnemonic mnemonic ((_TypePayoff.cell :?> TypePayoffModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TypePayoff.source + ".Name") 
                                               [| _TypePayoff.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TypePayoff.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_TypePayoff_value", Description="Create a TypePayoff",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TypePayoff_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TypePayoff",Description = "Reference to TypePayoff")>] 
         typepayoff : obj)
        ([<ExcelArgument(Name="price",Description = "Reference to price")>] 
         price : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TypePayoff = Helper.toCell<TypePayoff> typepayoff "TypePayoff" true 
                let _price = Helper.toCell<double> price "price" true
                let builder () = withMnemonic mnemonic ((_TypePayoff.cell :?> TypePayoffModel).Value
                                                            _price.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_TypePayoff.source + ".Value") 
                                               [| _TypePayoff.source
                                               ;  _price.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TypePayoff.cell
                                ;  _price.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_TypePayoff_Range", Description="Create a range of TypePayoff",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TypePayoff_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the TypePayoff")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<TypePayoff> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<TypePayoff>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<TypePayoff>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<TypePayoff>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"