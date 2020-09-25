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
  Fits a discount function to the exponential form See:Li, B., E. DeWetering, G. Lucas, R. Brenner and A. Shapiro (2001): "Merrill Lynch Exponential Spline Model." Merrill Lynch Working Paper  convergence may be slow
  </summary> *)
[<AutoSerializable(true)>]
module ExponentialSplinesFittingFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ExponentialSplinesFitting_clone", Description="Create a ExponentialSplinesFitting",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ExponentialSplinesFitting_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ExponentialSplinesFitting",Description = "Reference to ExponentialSplinesFitting")>] 
         exponentialsplinesfitting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ExponentialSplinesFitting = Helper.toCell<ExponentialSplinesFitting> exponentialsplinesfitting "ExponentialSplinesFitting" true 
                let builder () = withMnemonic mnemonic ((_ExponentialSplinesFitting.cell :?> ExponentialSplinesFittingModel).Clone
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FittedBondDiscountCurve.FittingMethod>) l

                let source = Helper.sourceFold (_ExponentialSplinesFitting.source + ".Clone") 
                                               [| _ExponentialSplinesFitting.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ExponentialSplinesFitting.cell
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
    [<ExcelFunction(Name="_ExponentialSplinesFitting", Description="Create a ExponentialSplinesFitting",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ExponentialSplinesFitting_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="constrainAtZero",Description = "Reference to constrainAtZero")>] 
         constrainAtZero : obj)
        ([<ExcelArgument(Name="weights",Description = "Reference to weights")>] 
         weights : obj)
        ([<ExcelArgument(Name="optimizationMethod",Description = "Reference to optimizationMethod")>] 
         optimizationMethod : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _constrainAtZero = Helper.toCell<bool> constrainAtZero "constrainAtZero" true
                let _weights = Helper.toCell<Vector> weights "weights" true
                let _optimizationMethod = Helper.toCell<OptimizationMethod> optimizationMethod "optimizationMethod" true
                let builder () = withMnemonic mnemonic (Fun.ExponentialSplinesFitting 
                                                            _constrainAtZero.cell 
                                                            _weights.cell 
                                                            _optimizationMethod.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ExponentialSplinesFitting>) l

                let source = Helper.sourceFold "Fun.ExponentialSplinesFitting" 
                                               [| _constrainAtZero.source
                                               ;  _weights.source
                                               ;  _optimizationMethod.source
                                               |]
                let hash = Helper.hashFold 
                                [| _constrainAtZero.cell
                                ;  _weights.cell
                                ;  _optimizationMethod.cell
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
    [<ExcelFunction(Name="_ExponentialSplinesFitting_size", Description="Create a ExponentialSplinesFitting",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ExponentialSplinesFitting_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ExponentialSplinesFitting",Description = "Reference to ExponentialSplinesFitting")>] 
         exponentialsplinesfitting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ExponentialSplinesFitting = Helper.toCell<ExponentialSplinesFitting> exponentialsplinesfitting "ExponentialSplinesFitting" true 
                let builder () = withMnemonic mnemonic ((_ExponentialSplinesFitting.cell :?> ExponentialSplinesFittingModel).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_ExponentialSplinesFitting.source + ".Size") 
                                               [| _ExponentialSplinesFitting.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ExponentialSplinesFitting.cell
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
        ! return whether there is a constraint at zero
    *)
    [<ExcelFunction(Name="_ExponentialSplinesFitting_constrainAtZero", Description="Create a ExponentialSplinesFitting",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ExponentialSplinesFitting_constrainAtZero
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ExponentialSplinesFitting",Description = "Reference to ExponentialSplinesFitting")>] 
         exponentialsplinesfitting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ExponentialSplinesFitting = Helper.toCell<ExponentialSplinesFitting> exponentialsplinesfitting "ExponentialSplinesFitting" true 
                let builder () = withMnemonic mnemonic ((_ExponentialSplinesFitting.cell :?> ExponentialSplinesFittingModel).ConstrainAtZero
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ExponentialSplinesFitting.source + ".ConstrainAtZero") 
                                               [| _ExponentialSplinesFitting.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ExponentialSplinesFitting.cell
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
        ! open discountFunction to public
    *)
    [<ExcelFunction(Name="_ExponentialSplinesFitting_discount", Description="Create a ExponentialSplinesFitting",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ExponentialSplinesFitting_discount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ExponentialSplinesFitting",Description = "Reference to ExponentialSplinesFitting")>] 
         exponentialsplinesfitting : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ExponentialSplinesFitting = Helper.toCell<ExponentialSplinesFitting> exponentialsplinesfitting "ExponentialSplinesFitting" true 
                let _x = Helper.toCell<Vector> x "x" true
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_ExponentialSplinesFitting.cell :?> ExponentialSplinesFittingModel).Discount
                                                            _x.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ExponentialSplinesFitting.source + ".Discount") 
                                               [| _ExponentialSplinesFitting.source
                                               ;  _x.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ExponentialSplinesFitting.cell
                                ;  _x.cell
                                ;  _t.cell
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
        ! final value of cost function after optimization
    *)
    [<ExcelFunction(Name="_ExponentialSplinesFitting_minimumCostValue", Description="Create a ExponentialSplinesFitting",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ExponentialSplinesFitting_minimumCostValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ExponentialSplinesFitting",Description = "Reference to ExponentialSplinesFitting")>] 
         exponentialsplinesfitting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ExponentialSplinesFitting = Helper.toCell<ExponentialSplinesFitting> exponentialsplinesfitting "ExponentialSplinesFitting" true 
                let builder () = withMnemonic mnemonic ((_ExponentialSplinesFitting.cell :?> ExponentialSplinesFittingModel).MinimumCostValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ExponentialSplinesFitting.source + ".MinimumCostValue") 
                                               [| _ExponentialSplinesFitting.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ExponentialSplinesFitting.cell
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
        ! final number of iterations used in the optimization problem
    *)
    [<ExcelFunction(Name="_ExponentialSplinesFitting_numberOfIterations", Description="Create a ExponentialSplinesFitting",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ExponentialSplinesFitting_numberOfIterations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ExponentialSplinesFitting",Description = "Reference to ExponentialSplinesFitting")>] 
         exponentialsplinesfitting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ExponentialSplinesFitting = Helper.toCell<ExponentialSplinesFitting> exponentialsplinesfitting "ExponentialSplinesFitting" true 
                let builder () = withMnemonic mnemonic ((_ExponentialSplinesFitting.cell :?> ExponentialSplinesFittingModel).NumberOfIterations
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_ExponentialSplinesFitting.source + ".NumberOfIterations") 
                                               [| _ExponentialSplinesFitting.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ExponentialSplinesFitting.cell
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
        ! return optimization method being used
    *)
    [<ExcelFunction(Name="_ExponentialSplinesFitting_optimizationMethod", Description="Create a ExponentialSplinesFitting",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ExponentialSplinesFitting_optimizationMethod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ExponentialSplinesFitting",Description = "Reference to ExponentialSplinesFitting")>] 
         exponentialsplinesfitting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ExponentialSplinesFitting = Helper.toCell<ExponentialSplinesFitting> exponentialsplinesfitting "ExponentialSplinesFitting" true 
                let builder () = withMnemonic mnemonic ((_ExponentialSplinesFitting.cell :?> ExponentialSplinesFittingModel).OptimizationMethod
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<OptimizationMethod>) l

                let source = Helper.sourceFold (_ExponentialSplinesFitting.source + ".OptimizationMethod") 
                                               [| _ExponentialSplinesFitting.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ExponentialSplinesFitting.cell
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
        ! output array of results of optimization problem
    *)
    [<ExcelFunction(Name="_ExponentialSplinesFitting_solution", Description="Create a ExponentialSplinesFitting",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ExponentialSplinesFitting_solution
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ExponentialSplinesFitting",Description = "Reference to ExponentialSplinesFitting")>] 
         exponentialsplinesfitting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ExponentialSplinesFitting = Helper.toCell<ExponentialSplinesFitting> exponentialsplinesfitting "ExponentialSplinesFitting" true 
                let builder () = withMnemonic mnemonic ((_ExponentialSplinesFitting.cell :?> ExponentialSplinesFittingModel).Solution
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_ExponentialSplinesFitting.source + ".Solution") 
                                               [| _ExponentialSplinesFitting.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ExponentialSplinesFitting.cell
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
        ! return weights being used
    *)
    [<ExcelFunction(Name="_ExponentialSplinesFitting_weights", Description="Create a ExponentialSplinesFitting",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ExponentialSplinesFitting_weights
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ExponentialSplinesFitting",Description = "Reference to ExponentialSplinesFitting")>] 
         exponentialsplinesfitting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ExponentialSplinesFitting = Helper.toCell<ExponentialSplinesFitting> exponentialsplinesfitting "ExponentialSplinesFitting" true 
                let builder () = withMnemonic mnemonic ((_ExponentialSplinesFitting.cell :?> ExponentialSplinesFittingModel).Weights
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_ExponentialSplinesFitting.source + ".Weights") 
                                               [| _ExponentialSplinesFitting.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ExponentialSplinesFitting.cell
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
    [<ExcelFunction(Name="_ExponentialSplinesFitting_Range", Description="Create a range of ExponentialSplinesFitting",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ExponentialSplinesFitting_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the ExponentialSplinesFitting")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ExponentialSplinesFitting> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ExponentialSplinesFitting>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<ExponentialSplinesFitting>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<ExponentialSplinesFitting>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"