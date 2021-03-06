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
  revise end conditions
  </summary> *)
[<AutoSerializable(true)>]
module BicubicSplineFunction =

    (*
        ! \pre the \f$ x \f$ and \f$ y \f$ values must be sorted.
    *)
    [<ExcelFunction(Name="_BicubicSpline", Description="Create a BicubicSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BicubicSpline_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="xBegin",Description = "double range")>] 
         xBegin : obj)
        ([<ExcelArgument(Name="size",Description = "int")>] 
         size : obj)
        ([<ExcelArgument(Name="yBegin",Description = "double range")>] 
         yBegin : obj)
        ([<ExcelArgument(Name="ySize",Description = "int")>] 
         ySize : obj)
        ([<ExcelArgument(Name="zData",Description = "Matrix")>] 
         zData : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _xBegin = Helper.toCell<Generic.List<double>> xBegin "xBegin" 
                let _size = Helper.toCell<int> size "size" 
                let _yBegin = Helper.toCell<Generic.List<double>> yBegin "yBegin" 
                let _ySize = Helper.toCell<int> ySize "ySize" 
                let _zData = Helper.toCell<Matrix> zData "zData" 
                let builder (current : ICell) = (Fun.BicubicSpline 
                                                            _xBegin.cell 
                                                            _size.cell 
                                                            _yBegin.cell 
                                                            _ySize.cell 
                                                            _zData.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BicubicSpline>) l

                let source () = Helper.sourceFold "Fun.BicubicSpline" 
                                               [| _xBegin.source
                                               ;  _size.source
                                               ;  _yBegin.source
                                               ;  _ySize.source
                                               ;  _zData.source
                                               |]
                let hash = Helper.hashFold 
                                [| _xBegin.cell
                                ;  _size.cell
                                ;  _yBegin.cell
                                ;  _ySize.cell
                                ;  _zData.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BicubicSpline> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BicubicSpline_derivativeX", Description="Create a BicubicSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BicubicSpline_derivativeX
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BicubicSpline",Description = "BicubicSpline")>] 
         bicubicspline : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="y",Description = "double")>] 
         y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BicubicSpline = Helper.toModelReference<BicubicSpline> bicubicspline "BicubicSpline"  
                let _x = Helper.toCell<double> x "x" 
                let _y = Helper.toCell<double> y "y" 
                let builder (current : ICell) = ((BicubicSplineModel.Cast _BicubicSpline.cell).DerivativeX
                                                            _x.cell 
                                                            _y.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BicubicSpline.source + ".DerivativeX") 

                                               [| _x.source
                                               ;  _y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BicubicSpline.cell
                                ;  _x.cell
                                ;  _y.cell
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
    [<ExcelFunction(Name="_BicubicSpline_derivativeXY", Description="Create a BicubicSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BicubicSpline_derivativeXY
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BicubicSpline",Description = "BicubicSpline")>] 
         bicubicspline : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="y",Description = "double")>] 
         y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BicubicSpline = Helper.toModelReference<BicubicSpline> bicubicspline "BicubicSpline"  
                let _x = Helper.toCell<double> x "x" 
                let _y = Helper.toCell<double> y "y" 
                let builder (current : ICell) = ((BicubicSplineModel.Cast _BicubicSpline.cell).DerivativeXY
                                                            _x.cell 
                                                            _y.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BicubicSpline.source + ".DerivativeXY") 

                                               [| _x.source
                                               ;  _y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BicubicSpline.cell
                                ;  _x.cell
                                ;  _y.cell
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
    [<ExcelFunction(Name="_BicubicSpline_derivativeY", Description="Create a BicubicSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BicubicSpline_derivativeY
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BicubicSpline",Description = "BicubicSpline")>] 
         bicubicspline : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="y",Description = "double")>] 
         y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BicubicSpline = Helper.toModelReference<BicubicSpline> bicubicspline "BicubicSpline"  
                let _x = Helper.toCell<double> x "x" 
                let _y = Helper.toCell<double> y "y" 
                let builder (current : ICell) = ((BicubicSplineModel.Cast _BicubicSpline.cell).DerivativeY
                                                            _x.cell 
                                                            _y.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BicubicSpline.source + ".DerivativeY") 

                                               [| _x.source
                                               ;  _y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BicubicSpline.cell
                                ;  _x.cell
                                ;  _y.cell
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
    [<ExcelFunction(Name="_BicubicSpline_secondDerivativeX", Description="Create a BicubicSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BicubicSpline_secondDerivativeX
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BicubicSpline",Description = "BicubicSpline")>] 
         bicubicspline : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="y",Description = "double")>] 
         y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BicubicSpline = Helper.toModelReference<BicubicSpline> bicubicspline "BicubicSpline"  
                let _x = Helper.toCell<double> x "x" 
                let _y = Helper.toCell<double> y "y" 
                let builder (current : ICell) = ((BicubicSplineModel.Cast _BicubicSpline.cell).SecondDerivativeX
                                                            _x.cell 
                                                            _y.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BicubicSpline.source + ".SecondDerivativeX") 

                                               [| _x.source
                                               ;  _y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BicubicSpline.cell
                                ;  _x.cell
                                ;  _y.cell
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
    [<ExcelFunction(Name="_BicubicSpline_secondDerivativeY", Description="Create a BicubicSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BicubicSpline_secondDerivativeY
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BicubicSpline",Description = "BicubicSpline")>] 
         bicubicspline : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="y",Description = "double")>] 
         y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BicubicSpline = Helper.toModelReference<BicubicSpline> bicubicspline "BicubicSpline"  
                let _x = Helper.toCell<double> x "x" 
                let _y = Helper.toCell<double> y "y" 
                let builder (current : ICell) = ((BicubicSplineModel.Cast _BicubicSpline.cell).SecondDerivativeY
                                                            _x.cell 
                                                            _y.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BicubicSpline.source + ".SecondDerivativeY") 

                                               [| _x.source
                                               ;  _y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BicubicSpline.cell
                                ;  _x.cell
                                ;  _y.cell
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
    [<ExcelFunction(Name="_BicubicSpline_isInRange", Description="Create a BicubicSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BicubicSpline_isInRange
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BicubicSpline",Description = "BicubicSpline")>] 
         bicubicspline : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="y",Description = "double")>] 
         y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BicubicSpline = Helper.toModelReference<BicubicSpline> bicubicspline "BicubicSpline"  
                let _x = Helper.toCell<double> x "x" 
                let _y = Helper.toCell<double> y "y" 
                let builder (current : ICell) = ((BicubicSplineModel.Cast _BicubicSpline.cell).IsInRange
                                                            _x.cell 
                                                            _y.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BicubicSpline.source + ".IsInRange") 

                                               [| _x.source
                                               ;  _y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BicubicSpline.cell
                                ;  _x.cell
                                ;  _y.cell
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
    [<ExcelFunction(Name="_BicubicSpline_locateX", Description="Create a BicubicSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BicubicSpline_locateX
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BicubicSpline",Description = "BicubicSpline")>] 
         bicubicspline : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BicubicSpline = Helper.toModelReference<BicubicSpline> bicubicspline "BicubicSpline"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = ((BicubicSplineModel.Cast _BicubicSpline.cell).LocateX
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BicubicSpline.source + ".LocateX") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BicubicSpline.cell
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
    [<ExcelFunction(Name="_BicubicSpline_locateY", Description="Create a BicubicSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BicubicSpline_locateY
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BicubicSpline",Description = "BicubicSpline")>] 
         bicubicspline : obj)
        ([<ExcelArgument(Name="y",Description = "double")>] 
         y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BicubicSpline = Helper.toModelReference<BicubicSpline> bicubicspline "BicubicSpline"  
                let _y = Helper.toCell<double> y "y" 
                let builder (current : ICell) = ((BicubicSplineModel.Cast _BicubicSpline.cell).LocateY
                                                            _y.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BicubicSpline.source + ".LocateY") 

                                               [| _y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BicubicSpline.cell
                                ;  _y.cell
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
    [<ExcelFunction(Name="_BicubicSpline_update", Description="Create a BicubicSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BicubicSpline_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BicubicSpline",Description = "BicubicSpline")>] 
         bicubicspline : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BicubicSpline = Helper.toModelReference<BicubicSpline> bicubicspline "BicubicSpline"  
                let builder (current : ICell) = ((BicubicSplineModel.Cast _BicubicSpline.cell).Update
                                                       ) :> ICell
                let format (o : BicubicSpline) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BicubicSpline.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BicubicSpline.cell
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
        main method to derive an interpolated point
    *)
    [<ExcelFunction(Name="_BicubicSpline_value1", Description="Create a BicubicSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BicubicSpline_value1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BicubicSpline",Description = "BicubicSpline")>] 
         bicubicspline : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="y",Description = "double")>] 
         y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BicubicSpline = Helper.toModelReference<BicubicSpline> bicubicspline "BicubicSpline"  
                let _x = Helper.toCell<double> x "x" 
                let _y = Helper.toCell<double> y "y" 
                let builder (current : ICell) = ((BicubicSplineModel.Cast _BicubicSpline.cell).Value1
                                                            _x.cell 
                                                            _y.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BicubicSpline.source + ".Value1") 

                                               [| _x.source
                                               ;  _y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BicubicSpline.cell
                                ;  _x.cell
                                ;  _y.cell
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
    [<ExcelFunction(Name="_BicubicSpline_value", Description="Create a BicubicSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BicubicSpline_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BicubicSpline",Description = "BicubicSpline")>] 
         bicubicspline : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="y",Description = "double")>] 
         y : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BicubicSpline = Helper.toModelReference<BicubicSpline> bicubicspline "BicubicSpline"  
                let _x = Helper.toCell<double> x "x" 
                let _y = Helper.toCell<double> y "y" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = ((BicubicSplineModel.Cast _BicubicSpline.cell).Value
                                                            _x.cell 
                                                            _y.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BicubicSpline.source + ".Value") 

                                               [| _x.source
                                               ;  _y.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BicubicSpline.cell
                                ;  _x.cell
                                ;  _y.cell
                                ;  _allowExtrapolation.cell
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
    [<ExcelFunction(Name="_BicubicSpline_xMax", Description="Create a BicubicSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BicubicSpline_xMax
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BicubicSpline",Description = "BicubicSpline")>] 
         bicubicspline : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BicubicSpline = Helper.toModelReference<BicubicSpline> bicubicspline "BicubicSpline"  
                let builder (current : ICell) = ((BicubicSplineModel.Cast _BicubicSpline.cell).XMax
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BicubicSpline.source + ".XMax") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BicubicSpline.cell
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
    [<ExcelFunction(Name="_BicubicSpline_xMin", Description="Create a BicubicSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BicubicSpline_xMin
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BicubicSpline",Description = "BicubicSpline")>] 
         bicubicspline : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BicubicSpline = Helper.toModelReference<BicubicSpline> bicubicspline "BicubicSpline"  
                let builder (current : ICell) = ((BicubicSplineModel.Cast _BicubicSpline.cell).XMin
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BicubicSpline.source + ".XMin") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BicubicSpline.cell
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
    [<ExcelFunction(Name="_BicubicSpline_xValues", Description="Create a BicubicSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BicubicSpline_xValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BicubicSpline",Description = "BicubicSpline")>] 
         bicubicspline : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BicubicSpline = Helper.toModelReference<BicubicSpline> bicubicspline "BicubicSpline"  
                let builder (current : ICell) = ((BicubicSplineModel.Cast _BicubicSpline.cell).XValues
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_BicubicSpline.source + ".XValues") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BicubicSpline.cell
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
    [<ExcelFunction(Name="_BicubicSpline_yMax", Description="Create a BicubicSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BicubicSpline_yMax
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BicubicSpline",Description = "BicubicSpline")>] 
         bicubicspline : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BicubicSpline = Helper.toModelReference<BicubicSpline> bicubicspline "BicubicSpline"  
                let builder (current : ICell) = ((BicubicSplineModel.Cast _BicubicSpline.cell).YMax
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BicubicSpline.source + ".YMax") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BicubicSpline.cell
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
    [<ExcelFunction(Name="_BicubicSpline_yMin", Description="Create a BicubicSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BicubicSpline_yMin
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BicubicSpline",Description = "BicubicSpline")>] 
         bicubicspline : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BicubicSpline = Helper.toModelReference<BicubicSpline> bicubicspline "BicubicSpline"  
                let builder (current : ICell) = ((BicubicSplineModel.Cast _BicubicSpline.cell).YMin
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BicubicSpline.source + ".YMin") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BicubicSpline.cell
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
    [<ExcelFunction(Name="_BicubicSpline_yValues", Description="Create a BicubicSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BicubicSpline_yValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BicubicSpline",Description = "BicubicSpline")>] 
         bicubicspline : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BicubicSpline = Helper.toModelReference<BicubicSpline> bicubicspline "BicubicSpline"  
                let builder (current : ICell) = ((BicubicSplineModel.Cast _BicubicSpline.cell).YValues
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_BicubicSpline.source + ".YValues") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BicubicSpline.cell
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
    [<ExcelFunction(Name="_BicubicSpline_zData", Description="Create a BicubicSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BicubicSpline_zData
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BicubicSpline",Description = "BicubicSpline")>] 
         bicubicspline : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BicubicSpline = Helper.toModelReference<BicubicSpline> bicubicspline "BicubicSpline"  
                let builder (current : ICell) = ((BicubicSplineModel.Cast _BicubicSpline.cell).ZData
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source () = Helper.sourceFold (_BicubicSpline.source + ".ZData") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BicubicSpline.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BicubicSpline> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        some extra functionality
    *)
    [<ExcelFunction(Name="_BicubicSpline_allowsExtrapolation", Description="Create a BicubicSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BicubicSpline_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BicubicSpline",Description = "BicubicSpline")>] 
         bicubicspline : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BicubicSpline = Helper.toModelReference<BicubicSpline> bicubicspline "BicubicSpline"  
                let builder (current : ICell) = ((BicubicSplineModel.Cast _BicubicSpline.cell).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BicubicSpline.source + ".AllowsExtrapolation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BicubicSpline.cell
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
        ! enable extrapolation in subsequent calls
    *)
    [<ExcelFunction(Name="_BicubicSpline_disableExtrapolation", Description="Create a BicubicSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BicubicSpline_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BicubicSpline",Description = "BicubicSpline")>] 
         bicubicspline : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BicubicSpline = Helper.toModelReference<BicubicSpline> bicubicspline "BicubicSpline"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = ((BicubicSplineModel.Cast _BicubicSpline.cell).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : BicubicSpline) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BicubicSpline.source + ".DisableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BicubicSpline.cell
                                ;  _b.cell
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
        ! tells whether extrapolation is enabled
    *)
    [<ExcelFunction(Name="_BicubicSpline_enableExtrapolation", Description="Create a BicubicSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BicubicSpline_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BicubicSpline",Description = "BicubicSpline")>] 
         bicubicspline : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BicubicSpline = Helper.toModelReference<BicubicSpline> bicubicspline "BicubicSpline"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = ((BicubicSplineModel.Cast _BicubicSpline.cell).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : BicubicSpline) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BicubicSpline.source + ".EnableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BicubicSpline.cell
                                ;  _b.cell
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
    [<ExcelFunction(Name="_BicubicSpline_extrapolate", Description="Create a BicubicSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BicubicSpline_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BicubicSpline",Description = "BicubicSpline")>] 
         bicubicspline : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BicubicSpline = Helper.toModelReference<BicubicSpline> bicubicspline "BicubicSpline"  
                let builder (current : ICell) = ((BicubicSplineModel.Cast _BicubicSpline.cell).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BicubicSpline.source + ".Extrapolate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BicubicSpline.cell
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
    [<ExcelFunction(Name="_BicubicSpline_Range", Description="Create a range of BicubicSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BicubicSpline_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BicubicSpline> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<BicubicSpline> (c)) :> ICell
                let format (i : Cephei.Cell.List<BicubicSpline>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<BicubicSpline>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
