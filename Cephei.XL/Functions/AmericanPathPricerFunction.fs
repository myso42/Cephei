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
module AmericanPathPricerFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_AmericanPathPricer", Description="Create a AmericanPathPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmericanPathPricer_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="payoff",Description = "Payoff")>] 
         payoff : obj)
        ([<ExcelArgument(Name="polynomOrder",Description = "int")>] 
         polynomOrder : obj)
        ([<ExcelArgument(Name="polynomType",Description = "LsmBasisSystem.PolynomType: Monomial, Laguerre, Hermite, Hyperbolic, Legendre, Chebyshev, Chebyshev2th")>] 
         polynomType : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _payoff = Helper.toCell<Payoff> payoff "payoff" 
                let _polynomOrder = Helper.toCell<int> polynomOrder "polynomOrder" 
                let _polynomType = Helper.toCell<LsmBasisSystem.PolynomType> polynomType "polynomType" 
                let builder (current : ICell) = (Fun.AmericanPathPricer 
                                                            _payoff.cell 
                                                            _polynomOrder.cell 
                                                            _polynomType.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AmericanPathPricer>) l

                let source () = Helper.sourceFold "Fun.AmericanPathPricer" 
                                               [| _payoff.source
                                               ;  _polynomOrder.source
                                               ;  _polynomType.source
                                               |]
                let hash = Helper.hashFold 
                                [| _payoff.cell
                                ;  _polynomOrder.cell
                                ;  _polynomType.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AmericanPathPricer> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AmericanPathPricer_basisSystem", Description="Create a AmericanPathPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmericanPathPricer_basisSystem
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmericanPathPricer",Description = "AmericanPathPricer")>] 
         americanpathpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmericanPathPricer = Helper.toModelReference<AmericanPathPricer> americanpathpricer "AmericanPathPricer"  
                let builder (current : ICell) = ((AmericanPathPricerModel.Cast _AmericanPathPricer.cell).BasisSystem
                                                       ) :> ICell
                let format (i : Generic.List<Func<double,double>>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_AmericanPathPricer.source + ".BasisSystem") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AmericanPathPricer.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        scale values of the underlying to increase numerical stability
    *)
    [<ExcelFunction(Name="_AmericanPathPricer_state", Description="Create a AmericanPathPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmericanPathPricer_state
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmericanPathPricer",Description = "AmericanPathPricer")>] 
         americanpathpricer : obj)
        ([<ExcelArgument(Name="path",Description = "IPath")>] 
         path : obj)
        ([<ExcelArgument(Name="t",Description = "int")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmericanPathPricer = Helper.toModelReference<AmericanPathPricer> americanpathpricer "AmericanPathPricer"  
                let _path = Helper.toCell<IPath> path "path" 
                let _t = Helper.toCell<int> t "t" 
                let builder (current : ICell) = ((AmericanPathPricerModel.Cast _AmericanPathPricer.cell).State
                                                            _path.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AmericanPathPricer.source + ".State") 

                                               [| _path.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmericanPathPricer.cell
                                ;  _path.cell
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
    [<ExcelFunction(Name="_AmericanPathPricer_value", Description="Create a AmericanPathPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmericanPathPricer_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmericanPathPricer",Description = "AmericanPathPricer")>] 
         americanpathpricer : obj)
        ([<ExcelArgument(Name="path",Description = "IPath")>] 
         path : obj)
        ([<ExcelArgument(Name="t",Description = "int")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmericanPathPricer = Helper.toModelReference<AmericanPathPricer> americanpathpricer "AmericanPathPricer"  
                let _path = Helper.toCell<IPath> path "path" 
                let _t = Helper.toCell<int> t "t" 
                let builder (current : ICell) = ((AmericanPathPricerModel.Cast _AmericanPathPricer.cell).Value
                                                            _path.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AmericanPathPricer.source + ".Value") 

                                               [| _path.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmericanPathPricer.cell
                                ;  _path.cell
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
    [<ExcelFunction(Name="_AmericanPathPricer_Range", Description="Create a range of AmericanPathPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmericanPathPricer_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<AmericanPathPricer> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<AmericanPathPricer> (c)) :> ICell
                let format (i : Cephei.Cell.List<AmericanPathPricer>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<AmericanPathPricer>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
