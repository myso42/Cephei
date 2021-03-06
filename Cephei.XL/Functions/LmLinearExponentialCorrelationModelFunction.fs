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
  This class describes a exponential correlation model  References:  Damiano Brigo, Fabio Mercurio, Massimo Morini, 2003, Different Covariance Parameterizations of Libor Market Model and Joint Caps/Swaptions Calibration, (<http://www.business.uts.edu.au/qfrc/conferences/qmf2001/Brigo_D.pdf>)
  </summary> *)
[<AutoSerializable(true)>]
module LmLinearExponentialCorrelationModelFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_LmLinearExponentialCorrelationModel_correlation", Description="Create a LmLinearExponentialCorrelationModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LmLinearExponentialCorrelationModel_correlation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmLinearExponentialCorrelationModel",Description = "LmLinearExponentialCorrelationModel")>] 
         lmlinearexponentialcorrelationmodel : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        ([<ExcelArgument(Name="j",Description = "int")>] 
         j : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Vector or empty")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LmLinearExponentialCorrelationModel = Helper.toModelReference<LmLinearExponentialCorrelationModel> lmlinearexponentialcorrelationmodel "LmLinearExponentialCorrelationModel"  
                let _i = Helper.toCell<int> i "i" 
                let _j = Helper.toCell<int> j "j" 
                let _t = Helper.toCell<double> t "t" 
                let _x = Helper.toDefault<Vector> x "x" null
                let builder (current : ICell) = ((LmLinearExponentialCorrelationModelModel.Cast _LmLinearExponentialCorrelationModel.cell).Correlation
                                                            _i.cell 
                                                            _j.cell 
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_LmLinearExponentialCorrelationModel.source + ".Correlation") 

                                               [| _i.source
                                               ;  _j.source
                                               ;  _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LmLinearExponentialCorrelationModel.cell
                                ;  _i.cell
                                ;  _j.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_LmLinearExponentialCorrelationModel_correlation1", Description="Create a LmLinearExponentialCorrelationModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LmLinearExponentialCorrelationModel_correlation1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmLinearExponentialCorrelationModel",Description = "LmLinearExponentialCorrelationModel")>] 
         lmlinearexponentialcorrelationmodel : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Vector or empty")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LmLinearExponentialCorrelationModel = Helper.toModelReference<LmLinearExponentialCorrelationModel> lmlinearexponentialcorrelationmodel "LmLinearExponentialCorrelationModel"  
                let _t = Helper.toCell<double> t "t" 
                let _x = Helper.toDefault<Vector> x "x" null
                let builder (current : ICell) = ((LmLinearExponentialCorrelationModelModel.Cast _LmLinearExponentialCorrelationModel.cell).Correlation1
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source () = Helper.sourceFold (_LmLinearExponentialCorrelationModel.source + ".Correlation1") 

                                               [| _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LmLinearExponentialCorrelationModel.cell
                                ;  _t.cell
                                ;  _x.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LmLinearExponentialCorrelationModel> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LmLinearExponentialCorrelationModel_factors", Description="Create a LmLinearExponentialCorrelationModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LmLinearExponentialCorrelationModel_factors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmLinearExponentialCorrelationModel",Description = "LmLinearExponentialCorrelationModel")>] 
         lmlinearexponentialcorrelationmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LmLinearExponentialCorrelationModel = Helper.toModelReference<LmLinearExponentialCorrelationModel> lmlinearexponentialcorrelationmodel "LmLinearExponentialCorrelationModel"  
                let builder (current : ICell) = ((LmLinearExponentialCorrelationModelModel.Cast _LmLinearExponentialCorrelationModel.cell).Factors
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_LmLinearExponentialCorrelationModel.source + ".Factors") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LmLinearExponentialCorrelationModel.cell
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
    [<ExcelFunction(Name="_LmLinearExponentialCorrelationModel_isTimeIndependent", Description="Create a LmLinearExponentialCorrelationModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LmLinearExponentialCorrelationModel_isTimeIndependent
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmLinearExponentialCorrelationModel",Description = "LmLinearExponentialCorrelationModel")>] 
         lmlinearexponentialcorrelationmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LmLinearExponentialCorrelationModel = Helper.toModelReference<LmLinearExponentialCorrelationModel> lmlinearexponentialcorrelationmodel "LmLinearExponentialCorrelationModel"  
                let builder (current : ICell) = ((LmLinearExponentialCorrelationModelModel.Cast _LmLinearExponentialCorrelationModel.cell).IsTimeIndependent
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_LmLinearExponentialCorrelationModel.source + ".IsTimeIndependent") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LmLinearExponentialCorrelationModel.cell
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
    [<ExcelFunction(Name="_LmLinearExponentialCorrelationModel", Description="Create a LmLinearExponentialCorrelationModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LmLinearExponentialCorrelationModel_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="size",Description = "int")>] 
         size : obj)
        ([<ExcelArgument(Name="rho",Description = "double")>] 
         rho : obj)
        ([<ExcelArgument(Name="beta",Description = "double")>] 
         beta : obj)
        ([<ExcelArgument(Name="factors",Description = "int")>] 
         factors : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _size = Helper.toCell<int> size "size" 
                let _rho = Helper.toCell<double> rho "rho" 
                let _beta = Helper.toCell<double> beta "beta" 
                let _factors = Helper.toNullable<int> factors "factors"
                let builder (current : ICell) = (Fun.LmLinearExponentialCorrelationModel 
                                                            _size.cell 
                                                            _rho.cell 
                                                            _beta.cell 
                                                            _factors.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LmLinearExponentialCorrelationModel>) l

                let source () = Helper.sourceFold "Fun.LmLinearExponentialCorrelationModel" 
                                               [| _size.source
                                               ;  _rho.source
                                               ;  _beta.source
                                               ;  _factors.source
                                               |]
                let hash = Helper.hashFold 
                                [| _size.cell
                                ;  _rho.cell
                                ;  _beta.cell
                                ;  _factors.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LmLinearExponentialCorrelationModel> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LmLinearExponentialCorrelationModel_pseudoSqrt", Description="Create a LmLinearExponentialCorrelationModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LmLinearExponentialCorrelationModel_pseudoSqrt
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmLinearExponentialCorrelationModel",Description = "LmLinearExponentialCorrelationModel")>] 
         lmlinearexponentialcorrelationmodel : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Vector or empty")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LmLinearExponentialCorrelationModel = Helper.toModelReference<LmLinearExponentialCorrelationModel> lmlinearexponentialcorrelationmodel "LmLinearExponentialCorrelationModel"  
                let _t = Helper.toCell<double> t "t" 
                let _x = Helper.toDefault<Vector> x "x" null
                let builder (current : ICell) = ((LmLinearExponentialCorrelationModelModel.Cast _LmLinearExponentialCorrelationModel.cell).PseudoSqrt
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source () = Helper.sourceFold (_LmLinearExponentialCorrelationModel.source + ".PseudoSqrt") 

                                               [| _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LmLinearExponentialCorrelationModel.cell
                                ;  _t.cell
                                ;  _x.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LmLinearExponentialCorrelationModel> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LmLinearExponentialCorrelationModel_parameters", Description="Create a LmLinearExponentialCorrelationModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LmLinearExponentialCorrelationModel_parameters
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmLinearExponentialCorrelationModel",Description = "LmLinearExponentialCorrelationModel")>] 
         lmlinearexponentialcorrelationmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LmLinearExponentialCorrelationModel = Helper.toModelReference<LmLinearExponentialCorrelationModel> lmlinearexponentialcorrelationmodel "LmLinearExponentialCorrelationModel"  
                let builder (current : ICell) = ((LmLinearExponentialCorrelationModelModel.Cast _LmLinearExponentialCorrelationModel.cell).Parameters
                                                       ) :> ICell
                let format (i : Generic.List<Parameter>) (l : string) = Helper.Range.fromList i l

                let source () = Helper.sourceFold (_LmLinearExponentialCorrelationModel.source + ".Parameters") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LmLinearExponentialCorrelationModel.cell
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
        
    *)
    [<ExcelFunction(Name="_LmLinearExponentialCorrelationModel_setParams", Description="Create a LmLinearExponentialCorrelationModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LmLinearExponentialCorrelationModel_setParams
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmLinearExponentialCorrelationModel",Description = "LmLinearExponentialCorrelationModel")>] 
         lmlinearexponentialcorrelationmodel : obj)
        ([<ExcelArgument(Name="arguments",Description = "Parameter range")>] 
         arguments : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LmLinearExponentialCorrelationModel = Helper.toModelReference<LmLinearExponentialCorrelationModel> lmlinearexponentialcorrelationmodel "LmLinearExponentialCorrelationModel"  
                let _arguments = Helper.toCell<Generic.List<Parameter>> arguments "arguments" 
                let builder (current : ICell) = ((LmLinearExponentialCorrelationModelModel.Cast _LmLinearExponentialCorrelationModel.cell).SetParams
                                                            _arguments.cell 
                                                       ) :> ICell
                let format (o : LmLinearExponentialCorrelationModel) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_LmLinearExponentialCorrelationModel.source + ".SetParams") 

                                               [| _arguments.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LmLinearExponentialCorrelationModel.cell
                                ;  _arguments.cell
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
    [<ExcelFunction(Name="_LmLinearExponentialCorrelationModel_size", Description="Create a LmLinearExponentialCorrelationModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LmLinearExponentialCorrelationModel_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmLinearExponentialCorrelationModel",Description = "LmLinearExponentialCorrelationModel")>] 
         lmlinearexponentialcorrelationmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LmLinearExponentialCorrelationModel = Helper.toModelReference<LmLinearExponentialCorrelationModel> lmlinearexponentialcorrelationmodel "LmLinearExponentialCorrelationModel"  
                let builder (current : ICell) = ((LmLinearExponentialCorrelationModelModel.Cast _LmLinearExponentialCorrelationModel.cell).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_LmLinearExponentialCorrelationModel.source + ".Size") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LmLinearExponentialCorrelationModel.cell
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
    [<ExcelFunction(Name="_LmLinearExponentialCorrelationModel_Range", Description="Create a range of LmLinearExponentialCorrelationModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LmLinearExponentialCorrelationModel_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<LmLinearExponentialCorrelationModel> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<LmLinearExponentialCorrelationModel> (c)) :> ICell
                let format (i : Cephei.Cell.List<LmLinearExponentialCorrelationModel>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<LmLinearExponentialCorrelationModel>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
