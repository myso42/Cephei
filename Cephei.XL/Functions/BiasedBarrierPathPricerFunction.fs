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
module BiasedBarrierPathPricerFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BiasedBarrierPathPricer", Description="Create a BiasedBarrierPathPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BiasedBarrierPathPricer_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="barrierType",Description = "Barrier.Type: DownIn, UpIn, DownOut, UpOut, NULL")>] 
         barrierType : obj)
        ([<ExcelArgument(Name="barrier",Description = "double")>] 
         barrier : obj)
        ([<ExcelArgument(Name="rebate",Description = "double")>] 
         rebate : obj)
        ([<ExcelArgument(Name="Type",Description = "Option.Type: Put, Call")>] 
         Type : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="discounts",Description = "double range")>] 
         discounts : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _barrierType = Helper.toCell<Barrier.Type> barrierType "barrierType" 
                let _barrier = Helper.toNullable<double> barrier "barrier"
                let _rebate = Helper.toNullable<double> rebate "rebate"
                let _Type = Helper.toCell<Option.Type> Type "Type" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _discounts = Helper.toCell<Generic.List<double>> discounts "discounts" 
                let builder (current : ICell) = (Fun.BiasedBarrierPathPricer 
                                                            _barrierType.cell 
                                                            _barrier.cell 
                                                            _rebate.cell 
                                                            _Type.cell 
                                                            _strike.cell 
                                                            _discounts.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BiasedBarrierPathPricer>) l

                let source () = Helper.sourceFold "Fun.BiasedBarrierPathPricer" 
                                               [| _barrierType.source
                                               ;  _barrier.source
                                               ;  _rebate.source
                                               ;  _Type.source
                                               ;  _strike.source
                                               ;  _discounts.source
                                               |]
                let hash = Helper.hashFold 
                                [| _barrierType.cell
                                ;  _barrier.cell
                                ;  _rebate.cell
                                ;  _Type.cell
                                ;  _strike.cell
                                ;  _discounts.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BiasedBarrierPathPricer> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BiasedBarrierPathPricer_value", Description="Create a BiasedBarrierPathPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BiasedBarrierPathPricer_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BiasedBarrierPathPricer",Description = "BiasedBarrierPathPricer")>] 
         biasedbarrierpathpricer : obj)
        ([<ExcelArgument(Name="path",Description = "IPath")>] 
         path : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BiasedBarrierPathPricer = Helper.toModelReference<BiasedBarrierPathPricer> biasedbarrierpathpricer "BiasedBarrierPathPricer"  
                let _path = Helper.toCell<IPath> path "path" 
                let builder (current : ICell) = ((BiasedBarrierPathPricerModel.Cast _BiasedBarrierPathPricer.cell).Value
                                                            _path.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BiasedBarrierPathPricer.source + ".Value") 

                                               [| _path.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BiasedBarrierPathPricer.cell
                                ;  _path.cell
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
    [<ExcelFunction(Name="_BiasedBarrierPathPricer_Range", Description="Create a range of BiasedBarrierPathPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BiasedBarrierPathPricer_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BiasedBarrierPathPricer> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<BiasedBarrierPathPricer> (c)) :> ICell
                let format (i : Cephei.Cell.List<BiasedBarrierPathPricer>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<BiasedBarrierPathPricer>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
