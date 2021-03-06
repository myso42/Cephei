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
module LfmHullWhiteParameterizationFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_LfmHullWhiteParameterization_covariance1", Description="Create a LfmHullWhiteParameterization",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LfmHullWhiteParameterization_covariance1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LfmHullWhiteParameterization",Description = "LfmHullWhiteParameterization")>] 
         lfmhullwhiteparameterization : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LfmHullWhiteParameterization = Helper.toModelReference<LfmHullWhiteParameterization> lfmhullwhiteparameterization "LfmHullWhiteParameterization"  
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = ((LfmHullWhiteParameterizationModel.Cast _LfmHullWhiteParameterization.cell).Covariance1
                                                            _t.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source () = Helper.sourceFold (_LfmHullWhiteParameterization.source + ".Covariance1") 

                                               [| _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LfmHullWhiteParameterization.cell
                                ;  _t.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LfmHullWhiteParameterization> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LfmHullWhiteParameterization_covariance", Description="Create a LfmHullWhiteParameterization",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LfmHullWhiteParameterization_covariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LfmHullWhiteParameterization",Description = "LfmHullWhiteParameterization")>] 
         lfmhullwhiteparameterization : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Vector or empty")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LfmHullWhiteParameterization = Helper.toModelReference<LfmHullWhiteParameterization> lfmhullwhiteparameterization "LfmHullWhiteParameterization"  
                let _t = Helper.toCell<double> t "t" 
                let _x = Helper.toDefault<Vector> x "x" null
                let builder (current : ICell) = ((LfmHullWhiteParameterizationModel.Cast _LfmHullWhiteParameterization.cell).Covariance
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source () = Helper.sourceFold (_LfmHullWhiteParameterization.source + ".Covariance") 

                                               [| _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LfmHullWhiteParameterization.cell
                                ;  _t.cell
                                ;  _x.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LfmHullWhiteParameterization> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LfmHullWhiteParameterization_diffusion", Description="Create a LfmHullWhiteParameterization",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LfmHullWhiteParameterization_diffusion
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LfmHullWhiteParameterization",Description = "LfmHullWhiteParameterization")>] 
         lfmhullwhiteparameterization : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LfmHullWhiteParameterization = Helper.toModelReference<LfmHullWhiteParameterization> lfmhullwhiteparameterization "LfmHullWhiteParameterization"  
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = ((LfmHullWhiteParameterizationModel.Cast _LfmHullWhiteParameterization.cell).Diffusion
                                                            _t.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source () = Helper.sourceFold (_LfmHullWhiteParameterization.source + ".Diffusion") 

                                               [| _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LfmHullWhiteParameterization.cell
                                ;  _t.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LfmHullWhiteParameterization> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LfmHullWhiteParameterization_diffusion1", Description="Create a LfmHullWhiteParameterization",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LfmHullWhiteParameterization_diffusion1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LfmHullWhiteParameterization",Description = "LfmHullWhiteParameterization")>] 
         lfmhullwhiteparameterization : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Vector or empty")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LfmHullWhiteParameterization = Helper.toModelReference<LfmHullWhiteParameterization> lfmhullwhiteparameterization "LfmHullWhiteParameterization"  
                let _t = Helper.toCell<double> t "t" 
                let _x = Helper.toDefault<Vector> x "x" null
                let builder (current : ICell) = ((LfmHullWhiteParameterizationModel.Cast _LfmHullWhiteParameterization.cell).Diffusion1
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source () = Helper.sourceFold (_LfmHullWhiteParameterization.source + ".Diffusion1") 

                                               [| _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LfmHullWhiteParameterization.cell
                                ;  _t.cell
                                ;  _x.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LfmHullWhiteParameterization> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LfmHullWhiteParameterization_integratedCovariance", Description="Create a LfmHullWhiteParameterization",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LfmHullWhiteParameterization_integratedCovariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LfmHullWhiteParameterization",Description = "LfmHullWhiteParameterization")>] 
         lfmhullwhiteparameterization : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Vector or empty")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LfmHullWhiteParameterization = Helper.toModelReference<LfmHullWhiteParameterization> lfmhullwhiteparameterization "LfmHullWhiteParameterization"  
                let _t = Helper.toCell<double> t "t" 
                let _x = Helper.toDefault<Vector> x "x" null
                let builder (current : ICell) = ((LfmHullWhiteParameterizationModel.Cast _LfmHullWhiteParameterization.cell).IntegratedCovariance
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source () = Helper.sourceFold (_LfmHullWhiteParameterization.source + ".IntegratedCovariance") 

                                               [| _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LfmHullWhiteParameterization.cell
                                ;  _t.cell
                                ;  _x.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LfmHullWhiteParameterization> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LfmHullWhiteParameterization1", Description="Create a LfmHullWhiteParameterization",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LfmHullWhiteParameterization_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Process",Description = "LiborForwardModelProcess")>] 
         Process : obj)
        ([<ExcelArgument(Name="capletVol",Description = "OptionletVolatilityStructure")>] 
         capletVol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Process = Helper.toCell<LiborForwardModelProcess> Process "Process" 
                let _capletVol = Helper.toCell<OptionletVolatilityStructure> capletVol "capletVol" 
                let builder (current : ICell) = (Fun.LfmHullWhiteParameterization1 
                                                            _Process.cell 
                                                            _capletVol.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LfmHullWhiteParameterization>) l

                let source () = Helper.sourceFold "Fun.LfmHullWhiteParameterization1" 
                                               [| _Process.source
                                               ;  _capletVol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Process.cell
                                ;  _capletVol.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LfmHullWhiteParameterization> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LfmHullWhiteParameterization", Description="Create a LfmHullWhiteParameterization",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LfmHullWhiteParameterization_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Process",Description = "LiborForwardModelProcess")>] 
         Process : obj)
        ([<ExcelArgument(Name="capletVol",Description = "OptionletVolatilityStructure")>] 
         capletVol : obj)
        ([<ExcelArgument(Name="correlation",Description = "Matrix")>] 
         correlation : obj)
        ([<ExcelArgument(Name="factors",Description = "int")>] 
         factors : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Process = Helper.toCell<LiborForwardModelProcess> Process "Process" 
                let _capletVol = Helper.toCell<OptionletVolatilityStructure> capletVol "capletVol" 
                let _correlation = Helper.toCell<Matrix> correlation "correlation" 
                let _factors = Helper.toCell<int> factors "factors" 
                let builder (current : ICell) = (Fun.LfmHullWhiteParameterization
                                                            _Process.cell 
                                                            _capletVol.cell 
                                                            _correlation.cell 
                                                            _factors.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LfmHullWhiteParameterization>) l

                let source () = Helper.sourceFold "Fun.LfmHullWhiteParameterization" 
                                               [| _Process.source
                                               ;  _capletVol.source
                                               ;  _correlation.source
                                               ;  _factors.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Process.cell
                                ;  _capletVol.cell
                                ;  _correlation.cell
                                ;  _factors.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LfmHullWhiteParameterization> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LfmHullWhiteParameterization_factors", Description="Create a LfmHullWhiteParameterization",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LfmHullWhiteParameterization_factors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LfmHullWhiteParameterization",Description = "LfmHullWhiteParameterization")>] 
         lfmhullwhiteparameterization : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LfmHullWhiteParameterization = Helper.toModelReference<LfmHullWhiteParameterization> lfmhullwhiteparameterization "LfmHullWhiteParameterization"  
                let builder (current : ICell) = ((LfmHullWhiteParameterizationModel.Cast _LfmHullWhiteParameterization.cell).Factors
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_LfmHullWhiteParameterization.source + ".Factors") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LfmHullWhiteParameterization.cell
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
    [<ExcelFunction(Name="_LfmHullWhiteParameterization_size", Description="Create a LfmHullWhiteParameterization",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LfmHullWhiteParameterization_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LfmHullWhiteParameterization",Description = "LfmHullWhiteParameterization")>] 
         lfmhullwhiteparameterization : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LfmHullWhiteParameterization = Helper.toModelReference<LfmHullWhiteParameterization> lfmhullwhiteparameterization "LfmHullWhiteParameterization"  
                let builder (current : ICell) = ((LfmHullWhiteParameterizationModel.Cast _LfmHullWhiteParameterization.cell).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_LfmHullWhiteParameterization.source + ".Size") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LfmHullWhiteParameterization.cell
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
    [<ExcelFunction(Name="_LfmHullWhiteParameterization_Range", Description="Create a range of LfmHullWhiteParameterization",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LfmHullWhiteParameterization_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<LfmHullWhiteParameterization> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<LfmHullWhiteParameterization> (c)) :> ICell
                let format (i : Cephei.Cell.List<LfmHullWhiteParameterization>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<LfmHullWhiteParameterization>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
