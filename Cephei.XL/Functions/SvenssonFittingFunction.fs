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
  Fits a discount function to the form  See: Svensson, L. (1994). Estimating and interpreting forward interest rates: Sweden 1992-4. Discussion paper, Centre for Economic Policy Research(1051).
  </summary> *)
[<AutoSerializable(true)>]
module SvenssonFittingFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SvenssonFitting_clone", Description="Create a SvenssonFitting",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SvenssonFitting_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SvenssonFitting",Description = "SvenssonFitting")>] 
         svenssonfitting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SvenssonFitting = Helper.toModelReference<SvenssonFitting> svenssonfitting "SvenssonFitting"  
                let builder (current : ICell) = ((SvenssonFittingModel.Cast _SvenssonFitting.cell).Clone
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FittedBondDiscountCurve.FittingMethod>) l

                let source () = Helper.sourceFold (_SvenssonFitting.source + ".Clone") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SvenssonFitting.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SvenssonFitting> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SvenssonFitting_size", Description="Create a SvenssonFitting",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SvenssonFitting_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SvenssonFitting",Description = "SvenssonFitting")>] 
         svenssonfitting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SvenssonFitting = Helper.toModelReference<SvenssonFitting> svenssonfitting "SvenssonFitting"  
                let builder (current : ICell) = ((SvenssonFittingModel.Cast _SvenssonFitting.cell).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SvenssonFitting.source + ".Size") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SvenssonFitting.cell
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
    [<ExcelFunction(Name="_SvenssonFitting", Description="Create a SvenssonFitting",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SvenssonFitting_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="weights",Description = "Vector or empty")>] 
         weights : obj)
        ([<ExcelArgument(Name="optimizationMethod",Description = "OptimizationMethod or empty")>] 
         optimizationMethod : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _weights = Helper.toDefault<Vector> weights "weights" null
                let _optimizationMethod = Helper.toDefault<OptimizationMethod> optimizationMethod "optimizationMethod" null
                let builder (current : ICell) = (Fun.SvenssonFitting 
                                                            _weights.cell 
                                                            _optimizationMethod.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SvenssonFitting>) l

                let source () = Helper.sourceFold "Fun.SvenssonFitting" 
                                               [| _weights.source
                                               ;  _optimizationMethod.source
                                               |]
                let hash = Helper.hashFold 
                                [| _weights.cell
                                ;  _optimizationMethod.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SvenssonFitting> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! return whether there is a constraint at zero
    *)
    [<ExcelFunction(Name="_SvenssonFitting_constrainAtZero", Description="Create a SvenssonFitting",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SvenssonFitting_constrainAtZero
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SvenssonFitting",Description = "SvenssonFitting")>] 
         svenssonfitting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SvenssonFitting = Helper.toModelReference<SvenssonFitting> svenssonfitting "SvenssonFitting"  
                let builder (current : ICell) = ((SvenssonFittingModel.Cast _SvenssonFitting.cell).ConstrainAtZero
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SvenssonFitting.source + ".ConstrainAtZero") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SvenssonFitting.cell
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
        ! open discountFunction to public
    *)
    [<ExcelFunction(Name="_SvenssonFitting_discount", Description="Create a SvenssonFitting",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SvenssonFitting_discount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SvenssonFitting",Description = "SvenssonFitting")>] 
         svenssonfitting : obj)
        ([<ExcelArgument(Name="x",Description = "Vector")>] 
         x : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SvenssonFitting = Helper.toModelReference<SvenssonFitting> svenssonfitting "SvenssonFitting"  
                let _x = Helper.toCell<Vector> x "x" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = ((SvenssonFittingModel.Cast _SvenssonFitting.cell).Discount
                                                            _x.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SvenssonFitting.source + ".Discount") 

                                               [| _x.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SvenssonFitting.cell
                                ;  _x.cell
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
        ! final value of cost function after optimization
    *)
    [<ExcelFunction(Name="_SvenssonFitting_minimumCostValue", Description="Create a SvenssonFitting",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SvenssonFitting_minimumCostValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SvenssonFitting",Description = "SvenssonFitting")>] 
         svenssonfitting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SvenssonFitting = Helper.toModelReference<SvenssonFitting> svenssonfitting "SvenssonFitting"  
                let builder (current : ICell) = ((SvenssonFittingModel.Cast _SvenssonFitting.cell).MinimumCostValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SvenssonFitting.source + ".MinimumCostValue") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SvenssonFitting.cell
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
        ! final number of iterations used in the optimization problem
    *)
    [<ExcelFunction(Name="_SvenssonFitting_numberOfIterations", Description="Create a SvenssonFitting",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SvenssonFitting_numberOfIterations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SvenssonFitting",Description = "SvenssonFitting")>] 
         svenssonfitting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SvenssonFitting = Helper.toModelReference<SvenssonFitting> svenssonfitting "SvenssonFitting"  
                let builder (current : ICell) = ((SvenssonFittingModel.Cast _SvenssonFitting.cell).NumberOfIterations
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SvenssonFitting.source + ".NumberOfIterations") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SvenssonFitting.cell
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
        ! return optimization method being used
    *)
    [<ExcelFunction(Name="_SvenssonFitting_optimizationMethod", Description="Create a SvenssonFitting",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SvenssonFitting_optimizationMethod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SvenssonFitting",Description = "SvenssonFitting")>] 
         svenssonfitting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SvenssonFitting = Helper.toModelReference<SvenssonFitting> svenssonfitting "SvenssonFitting"  
                let builder (current : ICell) = ((SvenssonFittingModel.Cast _SvenssonFitting.cell).OptimizationMethod
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<OptimizationMethod>) l

                let source () = Helper.sourceFold (_SvenssonFitting.source + ".OptimizationMethod") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SvenssonFitting.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SvenssonFitting> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! output array of results of optimization problem
    *)
    [<ExcelFunction(Name="_SvenssonFitting_solution", Description="Create a SvenssonFitting",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SvenssonFitting_solution
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SvenssonFitting",Description = "SvenssonFitting")>] 
         svenssonfitting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SvenssonFitting = Helper.toModelReference<SvenssonFitting> svenssonfitting "SvenssonFitting"  
                let builder (current : ICell) = ((SvenssonFittingModel.Cast _SvenssonFitting.cell).Solution
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_SvenssonFitting.source + ".Solution") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SvenssonFitting.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SvenssonFitting> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! return weights being used
    *)
    [<ExcelFunction(Name="_SvenssonFitting_weights", Description="Create a SvenssonFitting",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SvenssonFitting_weights
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SvenssonFitting",Description = "SvenssonFitting")>] 
         svenssonfitting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SvenssonFitting = Helper.toModelReference<SvenssonFitting> svenssonfitting "SvenssonFitting"  
                let builder (current : ICell) = ((SvenssonFittingModel.Cast _SvenssonFitting.cell).Weights
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_SvenssonFitting.source + ".Weights") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SvenssonFitting.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SvenssonFitting> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_SvenssonFitting_Range", Description="Create a range of SvenssonFitting",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SvenssonFitting_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SvenssonFitting> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<SvenssonFitting> (c)) :> ICell
                let format (i : Cephei.Cell.List<SvenssonFitting>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<SvenssonFitting>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
