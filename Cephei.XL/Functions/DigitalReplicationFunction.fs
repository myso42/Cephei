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
module DigitalReplicationFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_DigitalReplication", Description="Create a DigitalReplication",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalReplication_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="t",Description = "Replication.Type: Sub, Central, Super or empty")>] 
         t : obj)
        ([<ExcelArgument(Name="gap",Description = "double or empty")>] 
         gap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _t = Helper.toDefault<Replication.Type> t "t" Replication.Type.Central
                let _gap = Helper.toDefault<double> gap "gap" 1e-4
                let builder (current : ICell) = (Fun.DigitalReplication 
                                                            _t.cell 
                                                            _gap.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalReplication>) l

                let source () = Helper.sourceFold "Fun.DigitalReplication" 
                                               [| _t.source
                                               ;  _gap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _t.cell
                                ;  _gap.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalReplication> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalReplication_gap", Description="Create a DigitalReplication",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalReplication_gap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalReplication",Description = "DigitalReplication")>] 
         digitalreplication : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalReplication = Helper.toModelReference<DigitalReplication> digitalreplication "DigitalReplication"  
                let builder (current : ICell) = ((DigitalReplicationModel.Cast _DigitalReplication.cell).Gap
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DigitalReplication.source + ".Gap") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalReplication.cell
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
    [<ExcelFunction(Name="_DigitalReplication_replicationType", Description="Create a DigitalReplication",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalReplication_replicationType
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalReplication",Description = "DigitalReplication")>] 
         digitalreplication : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalReplication = Helper.toModelReference<DigitalReplication> digitalreplication "DigitalReplication"  
                let builder (current : ICell) = ((DigitalReplicationModel.Cast _DigitalReplication.cell).ReplicationType
                                                       ) :> ICell
                let format (o : Replication.Type) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DigitalReplication.source + ".ReplicationType") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalReplication.cell
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
    [<ExcelFunction(Name="_DigitalReplication_Range", Description="Create a range of DigitalReplication",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalReplication_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DigitalReplication> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<DigitalReplication> (c)) :> ICell
                let format (i : Cephei.Cell.List<DigitalReplication>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<DigitalReplication>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
