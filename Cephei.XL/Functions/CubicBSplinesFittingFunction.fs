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
  Fits a discount function to a set of cubic B-splines N_{i,3}(t) i.e., d(t) =  c_i * N_{i,3}(t)  See: McCulloch, J. 1971, "Measuring the Term Structure of Interest Rates." Journal of Business, 44: 19-31  McCulloch, J. 1975, "The tax adjusted yield curve." Journal of Finance, XXX811-30  "The results are extremely sensitive to the number and location of the knot points, and there is no optimal way of selecting them." James, J. and N. Webber, "Interest Rate Modelling" John Wiley, 2000, pp. 440.
  </summary> *)
[<AutoSerializable(true)>]
module CubicBSplinesFittingFunction =

    (*
        ! cubic B-spline basis functions
    *)
    [<ExcelFunction(Name="_CubicBSplinesFitting_basisFunction", Description="Create a CubicBSplinesFitting",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CubicBSplinesFitting_basisFunction
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicBSplinesFitting",Description = "CubicBSplinesFitting")>] 
         cubicbsplinesfitting : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicBSplinesFitting = Helper.toModelReference<CubicBSplinesFitting> cubicbsplinesfitting "CubicBSplinesFitting"  
                let _i = Helper.toCell<int> i "i" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = ((CubicBSplinesFittingModel.Cast _CubicBSplinesFitting.cell).BasisFunction
                                                            _i.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CubicBSplinesFitting.source + ".BasisFunction") 

                                               [| _i.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicBSplinesFitting.cell
                                ;  _i.cell
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
    [<ExcelFunction(Name="_CubicBSplinesFitting_clone", Description="Create a CubicBSplinesFitting",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CubicBSplinesFitting_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicBSplinesFitting",Description = "CubicBSplinesFitting")>] 
         cubicbsplinesfitting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicBSplinesFitting = Helper.toModelReference<CubicBSplinesFitting> cubicbsplinesfitting "CubicBSplinesFitting"  
                let builder (current : ICell) = ((CubicBSplinesFittingModel.Cast _CubicBSplinesFitting.cell).Clone
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FittedBondDiscountCurve.FittingMethod>) l

                let source () = Helper.sourceFold (_CubicBSplinesFitting.source + ".Clone") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CubicBSplinesFitting.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CubicBSplinesFitting> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CubicBSplinesFitting", Description="Create a CubicBSplinesFitting",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CubicBSplinesFitting_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="knots",Description = "double range")>] 
         knots : obj)
        ([<ExcelArgument(Name="constrainAtZero",Description = "bool or empty")>] 
         constrainAtZero : obj)
        ([<ExcelArgument(Name="weights",Description = "Vector or empty")>] 
         weights : obj)
        ([<ExcelArgument(Name="optimizationMethod",Description = "OptimizationMethod or empty")>] 
         optimizationMethod : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _knots = Helper.toCell<Generic.List<double>> knots "knots" 
                let _constrainAtZero = Helper.toDefault<bool> constrainAtZero "constrainAtZero" true
                let _weights = Helper.toDefault<Vector> weights "weights" null
                let _optimizationMethod = Helper.toDefault<OptimizationMethod> optimizationMethod "optimizationMethod" null
                let builder (current : ICell) = (Fun.CubicBSplinesFitting 
                                                            _knots.cell 
                                                            _constrainAtZero.cell 
                                                            _weights.cell 
                                                            _optimizationMethod.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CubicBSplinesFitting>) l

                let source () = Helper.sourceFold "Fun.CubicBSplinesFitting" 
                                               [| _knots.source
                                               ;  _constrainAtZero.source
                                               ;  _weights.source
                                               ;  _optimizationMethod.source
                                               |]
                let hash = Helper.hashFold 
                                [| _knots.cell
                                ;  _constrainAtZero.cell
                                ;  _weights.cell
                                ;  _optimizationMethod.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CubicBSplinesFitting> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CubicBSplinesFitting_size", Description="Create a CubicBSplinesFitting",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CubicBSplinesFitting_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicBSplinesFitting",Description = "CubicBSplinesFitting")>] 
         cubicbsplinesfitting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicBSplinesFitting = Helper.toModelReference<CubicBSplinesFitting> cubicbsplinesfitting "CubicBSplinesFitting"  
                let builder (current : ICell) = ((CubicBSplinesFittingModel.Cast _CubicBSplinesFitting.cell).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CubicBSplinesFitting.source + ".Size") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CubicBSplinesFitting.cell
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
        ! return whether there is a constraint at zero
    *)
    [<ExcelFunction(Name="_CubicBSplinesFitting_constrainAtZero", Description="Create a CubicBSplinesFitting",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CubicBSplinesFitting_constrainAtZero
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicBSplinesFitting",Description = "CubicBSplinesFitting")>] 
         cubicbsplinesfitting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicBSplinesFitting = Helper.toModelReference<CubicBSplinesFitting> cubicbsplinesfitting "CubicBSplinesFitting"  
                let builder (current : ICell) = ((CubicBSplinesFittingModel.Cast _CubicBSplinesFitting.cell).ConstrainAtZero
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CubicBSplinesFitting.source + ".ConstrainAtZero") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CubicBSplinesFitting.cell
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
    [<ExcelFunction(Name="_CubicBSplinesFitting_discount", Description="Create a CubicBSplinesFitting",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CubicBSplinesFitting_discount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicBSplinesFitting",Description = "CubicBSplinesFitting")>] 
         cubicbsplinesfitting : obj)
        ([<ExcelArgument(Name="x",Description = "Vector")>] 
         x : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicBSplinesFitting = Helper.toModelReference<CubicBSplinesFitting> cubicbsplinesfitting "CubicBSplinesFitting"  
                let _x = Helper.toCell<Vector> x "x" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = ((CubicBSplinesFittingModel.Cast _CubicBSplinesFitting.cell).Discount
                                                            _x.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CubicBSplinesFitting.source + ".Discount") 

                                               [| _x.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicBSplinesFitting.cell
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
    [<ExcelFunction(Name="_CubicBSplinesFitting_minimumCostValue", Description="Create a CubicBSplinesFitting",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CubicBSplinesFitting_minimumCostValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicBSplinesFitting",Description = "CubicBSplinesFitting")>] 
         cubicbsplinesfitting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicBSplinesFitting = Helper.toModelReference<CubicBSplinesFitting> cubicbsplinesfitting "CubicBSplinesFitting"  
                let builder (current : ICell) = ((CubicBSplinesFittingModel.Cast _CubicBSplinesFitting.cell).MinimumCostValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CubicBSplinesFitting.source + ".MinimumCostValue") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CubicBSplinesFitting.cell
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
    [<ExcelFunction(Name="_CubicBSplinesFitting_numberOfIterations", Description="Create a CubicBSplinesFitting",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CubicBSplinesFitting_numberOfIterations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicBSplinesFitting",Description = "CubicBSplinesFitting")>] 
         cubicbsplinesfitting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicBSplinesFitting = Helper.toModelReference<CubicBSplinesFitting> cubicbsplinesfitting "CubicBSplinesFitting"  
                let builder (current : ICell) = ((CubicBSplinesFittingModel.Cast _CubicBSplinesFitting.cell).NumberOfIterations
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CubicBSplinesFitting.source + ".NumberOfIterations") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CubicBSplinesFitting.cell
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
    [<ExcelFunction(Name="_CubicBSplinesFitting_optimizationMethod", Description="Create a CubicBSplinesFitting",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CubicBSplinesFitting_optimizationMethod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicBSplinesFitting",Description = "CubicBSplinesFitting")>] 
         cubicbsplinesfitting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicBSplinesFitting = Helper.toModelReference<CubicBSplinesFitting> cubicbsplinesfitting "CubicBSplinesFitting"  
                let builder (current : ICell) = ((CubicBSplinesFittingModel.Cast _CubicBSplinesFitting.cell).OptimizationMethod
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<OptimizationMethod>) l

                let source () = Helper.sourceFold (_CubicBSplinesFitting.source + ".OptimizationMethod") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CubicBSplinesFitting.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CubicBSplinesFitting> format
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
    [<ExcelFunction(Name="_CubicBSplinesFitting_solution", Description="Create a CubicBSplinesFitting",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CubicBSplinesFitting_solution
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicBSplinesFitting",Description = "CubicBSplinesFitting")>] 
         cubicbsplinesfitting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicBSplinesFitting = Helper.toModelReference<CubicBSplinesFitting> cubicbsplinesfitting "CubicBSplinesFitting"  
                let builder (current : ICell) = ((CubicBSplinesFittingModel.Cast _CubicBSplinesFitting.cell).Solution
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_CubicBSplinesFitting.source + ".Solution") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CubicBSplinesFitting.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CubicBSplinesFitting> format
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
    [<ExcelFunction(Name="_CubicBSplinesFitting_weights", Description="Create a CubicBSplinesFitting",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CubicBSplinesFitting_weights
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicBSplinesFitting",Description = "CubicBSplinesFitting")>] 
         cubicbsplinesfitting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicBSplinesFitting = Helper.toModelReference<CubicBSplinesFitting> cubicbsplinesfitting "CubicBSplinesFitting"  
                let builder (current : ICell) = ((CubicBSplinesFittingModel.Cast _CubicBSplinesFitting.cell).Weights
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_CubicBSplinesFitting.source + ".Weights") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CubicBSplinesFitting.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CubicBSplinesFitting> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_CubicBSplinesFitting_Range", Description="Create a range of CubicBSplinesFitting",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CubicBSplinesFitting_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CubicBSplinesFitting> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<CubicBSplinesFitting> (c)) :> ICell
                let format (i : Cephei.Cell.List<CubicBSplinesFitting>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<CubicBSplinesFitting>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
