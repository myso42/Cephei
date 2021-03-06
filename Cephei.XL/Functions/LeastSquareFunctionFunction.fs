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
  Cost function for least-square problems   Implements a cost function using the interface provided by the LeastSquareProblem class.
  </summary> *)
[<AutoSerializable(true)>]
module LeastSquareFunctionFunction =

    (*
        ! compute vector of derivatives of the least square function
    *)
    [<ExcelFunction(Name="_LeastSquareFunction_gradient", Description="Create a LeastSquareFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LeastSquareFunction_gradient
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LeastSquareFunction",Description = "LeastSquareFunction")>] 
         leastsquarefunction : obj)
        ([<ExcelArgument(Name="grad_f",Description = "Vector")>] 
         grad_f : obj)
        ([<ExcelArgument(Name="x",Description = "Vector")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LeastSquareFunction = Helper.toModelReference<LeastSquareFunction> leastsquarefunction "LeastSquareFunction"  
                let _grad_f = Helper.toCell<Vector> grad_f "grad_f" 
                let _x = Helper.toCell<Vector> x "x" 
                let builder (current : ICell) = ((LeastSquareFunctionModel.Cast _LeastSquareFunction.cell).Gradient
                                                            _grad_f.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : LeastSquareFunction) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_LeastSquareFunction.source + ".Gradient") 

                                               [| _grad_f.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LeastSquareFunction.cell
                                ;  _grad_f.cell
                                ;  _x.cell
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
        ! Default constructor
    *)
    [<ExcelFunction(Name="_LeastSquareFunction", Description="Create a LeastSquareFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LeastSquareFunction_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="lsp",Description = "LeastSquareProblem")>] 
         lsp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _lsp = Helper.toCell<LeastSquareProblem> lsp "lsp" 
                let builder (current : ICell) = (Fun.LeastSquareFunction 
                                                            _lsp.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LeastSquareFunction>) l

                let source () = Helper.sourceFold "Fun.LeastSquareFunction" 
                                               [| _lsp.source
                                               |]
                let hash = Helper.hashFold 
                                [| _lsp.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LeastSquareFunction> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! compute value of the least square function
    *)
    [<ExcelFunction(Name="_LeastSquareFunction_value", Description="Create a LeastSquareFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LeastSquareFunction_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LeastSquareFunction",Description = "LeastSquareFunction")>] 
         leastsquarefunction : obj)
        ([<ExcelArgument(Name="x",Description = "Vector")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LeastSquareFunction = Helper.toModelReference<LeastSquareFunction> leastsquarefunction "LeastSquareFunction"  
                let _x = Helper.toCell<Vector> x "x" 
                let builder (current : ICell) = ((LeastSquareFunctionModel.Cast _LeastSquareFunction.cell).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_LeastSquareFunction.source + ".Value") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LeastSquareFunction.cell
                                ;  _x.cell
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
        ! compute value and gradient of the least square function
    *)
    [<ExcelFunction(Name="_LeastSquareFunction_valueAndGradient", Description="Create a LeastSquareFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LeastSquareFunction_valueAndGradient
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LeastSquareFunction",Description = "LeastSquareFunction")>] 
         leastsquarefunction : obj)
        ([<ExcelArgument(Name="grad_f",Description = "Vector")>] 
         grad_f : obj)
        ([<ExcelArgument(Name="x",Description = "Vector")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LeastSquareFunction = Helper.toModelReference<LeastSquareFunction> leastsquarefunction "LeastSquareFunction"  
                let _grad_f = Helper.toCell<Vector> grad_f "grad_f" 
                let _x = Helper.toCell<Vector> x "x" 
                let builder (current : ICell) = ((LeastSquareFunctionModel.Cast _LeastSquareFunction.cell).ValueAndGradient
                                                            _grad_f.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_LeastSquareFunction.source + ".ValueAndGradient") 

                                               [| _grad_f.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LeastSquareFunction.cell
                                ;  _grad_f.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_LeastSquareFunction_values", Description="Create a LeastSquareFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LeastSquareFunction_values
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LeastSquareFunction",Description = "LeastSquareFunction")>] 
         leastsquarefunction : obj)
        ([<ExcelArgument(Name="x",Description = "Vector")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LeastSquareFunction = Helper.toModelReference<LeastSquareFunction> leastsquarefunction "LeastSquareFunction"  
                let _x = Helper.toCell<Vector> x "x" 
                let builder (current : ICell) = ((LeastSquareFunctionModel.Cast _LeastSquareFunction.cell).Values
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_LeastSquareFunction.source + ".Values") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LeastSquareFunction.cell
                                ;  _x.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LeastSquareFunction> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! Default epsilon for finite difference method :
    *)
    [<ExcelFunction(Name="_LeastSquareFunction_finiteDifferenceEpsilon", Description="Create a LeastSquareFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LeastSquareFunction_finiteDifferenceEpsilon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LeastSquareFunction",Description = "LeastSquareFunction")>] 
         leastsquarefunction : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LeastSquareFunction = Helper.toModelReference<LeastSquareFunction> leastsquarefunction "LeastSquareFunction"  
                let builder (current : ICell) = ((LeastSquareFunctionModel.Cast _LeastSquareFunction.cell).FiniteDifferenceEpsilon
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_LeastSquareFunction.source + ".FiniteDifferenceEpsilon") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LeastSquareFunction.cell
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
        ! method to overload to compute J_f, the jacobian of the cost function with respect to x
    *)
    [<ExcelFunction(Name="_LeastSquareFunction_jacobian", Description="Create a LeastSquareFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LeastSquareFunction_jacobian
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LeastSquareFunction",Description = "LeastSquareFunction")>] 
         leastsquarefunction : obj)
        ([<ExcelArgument(Name="jac",Description = "Matrix")>] 
         jac : obj)
        ([<ExcelArgument(Name="x",Description = "Vector")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LeastSquareFunction = Helper.toModelReference<LeastSquareFunction> leastsquarefunction "LeastSquareFunction"  
                let _jac = Helper.toCell<Matrix> jac "jac" 
                let _x = Helper.toCell<Vector> x "x" 
                let builder (current : ICell) = ((LeastSquareFunctionModel.Cast _LeastSquareFunction.cell).Jacobian
                                                            _jac.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : LeastSquareFunction) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_LeastSquareFunction.source + ".Jacobian") 

                                               [| _jac.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LeastSquareFunction.cell
                                ;  _jac.cell
                                ;  _x.cell
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
        ! method to overload to compute J_f, the jacobian of the cost function with respect to x and also the cost function
    *)
    [<ExcelFunction(Name="_LeastSquareFunction_valuesAndJacobian", Description="Create a LeastSquareFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LeastSquareFunction_valuesAndJacobian
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LeastSquareFunction",Description = "LeastSquareFunction")>] 
         leastsquarefunction : obj)
        ([<ExcelArgument(Name="jac",Description = "Matrix")>] 
         jac : obj)
        ([<ExcelArgument(Name="x",Description = "Vector")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LeastSquareFunction = Helper.toModelReference<LeastSquareFunction> leastsquarefunction "LeastSquareFunction"  
                let _jac = Helper.toCell<Matrix> jac "jac" 
                let _x = Helper.toCell<Vector> x "x" 
                let builder (current : ICell) = ((LeastSquareFunctionModel.Cast _LeastSquareFunction.cell).ValuesAndJacobian
                                                            _jac.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_LeastSquareFunction.source + ".ValuesAndJacobian") 

                                               [| _jac.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LeastSquareFunction.cell
                                ;  _jac.cell
                                ;  _x.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LeastSquareFunction> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_LeastSquareFunction_Range", Description="Create a range of LeastSquareFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LeastSquareFunction_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<LeastSquareFunction> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<LeastSquareFunction> (c)) :> ICell
                let format (i : Cephei.Cell.List<LeastSquareFunction>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<LeastSquareFunction>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
