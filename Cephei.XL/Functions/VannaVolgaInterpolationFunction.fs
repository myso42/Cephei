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
module VannaVolgaInterpolationFunction =

    (*
        ! \pre the \f$ x \f$ values must be sorted.
    *)
    [<ExcelFunction(Name="_VannaVolgaInterpolation", Description="Create a VannaVolgaInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VannaVolgaInterpolation_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="xBegin",Description = "double range")>] 
         xBegin : obj)
        ([<ExcelArgument(Name="size",Description = "int")>] 
         size : obj)
        ([<ExcelArgument(Name="yBegin",Description = "double range")>] 
         yBegin : obj)
        ([<ExcelArgument(Name="spot",Description = "double")>] 
         spot : obj)
        ([<ExcelArgument(Name="dDiscount",Description = "double")>] 
         dDiscount : obj)
        ([<ExcelArgument(Name="fDiscount",Description = "double")>] 
         fDiscount : obj)
        ([<ExcelArgument(Name="T",Description = "double")>] 
         T : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _xBegin = Helper.toCell<Generic.List<double>> xBegin "xBegin" 
                let _size = Helper.toCell<int> size "size" 
                let _yBegin = Helper.toCell<Generic.List<double>> yBegin "yBegin" 
                let _spot = Helper.toCell<double> spot "spot" 
                let _dDiscount = Helper.toCell<double> dDiscount "dDiscount" 
                let _fDiscount = Helper.toCell<double> fDiscount "fDiscount" 
                let _T = Helper.toCell<double> T "T" 
                let builder (current : ICell) = (Fun.VannaVolgaInterpolation 
                                                            _xBegin.cell 
                                                            _size.cell 
                                                            _yBegin.cell 
                                                            _spot.cell 
                                                            _dDiscount.cell 
                                                            _fDiscount.cell 
                                                            _T.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<VannaVolgaInterpolation>) l

                let source () = Helper.sourceFold "Fun.VannaVolgaInterpolation" 
                                               [| _xBegin.source
                                               ;  _size.source
                                               ;  _yBegin.source
                                               ;  _spot.source
                                               ;  _dDiscount.source
                                               ;  _fDiscount.source
                                               ;  _T.source
                                               |]
                let hash = Helper.hashFold 
                                [| _xBegin.cell
                                ;  _size.cell
                                ;  _yBegin.cell
                                ;  _spot.cell
                                ;  _dDiscount.cell
                                ;  _fDiscount.cell
                                ;  _T.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<VannaVolgaInterpolation> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_VannaVolgaInterpolation_derivative", Description="Create a VannaVolgaInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VannaVolgaInterpolation_derivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VannaVolgaInterpolation",Description = "VannaVolgaInterpolation")>] 
         vannavolgainterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VannaVolgaInterpolation = Helper.toModelReference<VannaVolgaInterpolation> vannavolgainterpolation "VannaVolgaInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = ((VannaVolgaInterpolationModel.Cast _VannaVolgaInterpolation.cell).Derivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_VannaVolgaInterpolation.source + ".Derivative") 

                                               [| _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VannaVolgaInterpolation.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_VannaVolgaInterpolation_empty", Description="Create a VannaVolgaInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VannaVolgaInterpolation_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VannaVolgaInterpolation",Description = "VannaVolgaInterpolation")>] 
         vannavolgainterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VannaVolgaInterpolation = Helper.toModelReference<VannaVolgaInterpolation> vannavolgainterpolation "VannaVolgaInterpolation"  
                let builder (current : ICell) = ((VannaVolgaInterpolationModel.Cast _VannaVolgaInterpolation.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_VannaVolgaInterpolation.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _VannaVolgaInterpolation.cell
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
    [<ExcelFunction(Name="_VannaVolgaInterpolation_primitive", Description="Create a VannaVolgaInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VannaVolgaInterpolation_primitive
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VannaVolgaInterpolation",Description = "VannaVolgaInterpolation")>] 
         vannavolgainterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VannaVolgaInterpolation = Helper.toModelReference<VannaVolgaInterpolation> vannavolgainterpolation "VannaVolgaInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = ((VannaVolgaInterpolationModel.Cast _VannaVolgaInterpolation.cell).Primitive
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_VannaVolgaInterpolation.source + ".Primitive") 

                                               [| _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VannaVolgaInterpolation.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_VannaVolgaInterpolation_secondDerivative", Description="Create a VannaVolgaInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VannaVolgaInterpolation_secondDerivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VannaVolgaInterpolation",Description = "VannaVolgaInterpolation")>] 
         vannavolgainterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VannaVolgaInterpolation = Helper.toModelReference<VannaVolgaInterpolation> vannavolgainterpolation "VannaVolgaInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = ((VannaVolgaInterpolationModel.Cast _VannaVolgaInterpolation.cell).SecondDerivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_VannaVolgaInterpolation.source + ".SecondDerivative") 

                                               [| _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VannaVolgaInterpolation.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_VannaVolgaInterpolation_update", Description="Create a VannaVolgaInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VannaVolgaInterpolation_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VannaVolgaInterpolation",Description = "VannaVolgaInterpolation")>] 
         vannavolgainterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VannaVolgaInterpolation = Helper.toModelReference<VannaVolgaInterpolation> vannavolgainterpolation "VannaVolgaInterpolation"  
                let builder (current : ICell) = ((VannaVolgaInterpolationModel.Cast _VannaVolgaInterpolation.cell).Update
                                                       ) :> ICell
                let format (o : VannaVolgaInterpolation) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_VannaVolgaInterpolation.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _VannaVolgaInterpolation.cell
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
    [<ExcelFunction(Name="_VannaVolgaInterpolation_value1", Description="Create a VannaVolgaInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VannaVolgaInterpolation_value1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VannaVolgaInterpolation",Description = "VannaVolgaInterpolation")>] 
         vannavolgainterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VannaVolgaInterpolation = Helper.toModelReference<VannaVolgaInterpolation> vannavolgainterpolation "VannaVolgaInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = ((VannaVolgaInterpolationModel.Cast _VannaVolgaInterpolation.cell).Value1
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_VannaVolgaInterpolation.source + ".Value1") 

                                               [| _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VannaVolgaInterpolation.cell
                                ;  _x.cell
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
        main method to derive an interpolated point
    *)
    [<ExcelFunction(Name="_VannaVolgaInterpolation_value", Description="Create a VannaVolgaInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VannaVolgaInterpolation_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VannaVolgaInterpolation",Description = "VannaVolgaInterpolation")>] 
         vannavolgainterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VannaVolgaInterpolation = Helper.toModelReference<VannaVolgaInterpolation> vannavolgainterpolation "VannaVolgaInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = ((VannaVolgaInterpolationModel.Cast _VannaVolgaInterpolation.cell).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_VannaVolgaInterpolation.source + ".Value") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VannaVolgaInterpolation.cell
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
    [<ExcelFunction(Name="_VannaVolgaInterpolation_xMax", Description="Create a VannaVolgaInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VannaVolgaInterpolation_xMax
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VannaVolgaInterpolation",Description = "VannaVolgaInterpolation")>] 
         vannavolgainterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VannaVolgaInterpolation = Helper.toModelReference<VannaVolgaInterpolation> vannavolgainterpolation "VannaVolgaInterpolation"  
                let builder (current : ICell) = ((VannaVolgaInterpolationModel.Cast _VannaVolgaInterpolation.cell).XMax
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_VannaVolgaInterpolation.source + ".XMax") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _VannaVolgaInterpolation.cell
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
    [<ExcelFunction(Name="_VannaVolgaInterpolation_xMin", Description="Create a VannaVolgaInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VannaVolgaInterpolation_xMin
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VannaVolgaInterpolation",Description = "VannaVolgaInterpolation")>] 
         vannavolgainterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VannaVolgaInterpolation = Helper.toModelReference<VannaVolgaInterpolation> vannavolgainterpolation "VannaVolgaInterpolation"  
                let builder (current : ICell) = ((VannaVolgaInterpolationModel.Cast _VannaVolgaInterpolation.cell).XMin
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_VannaVolgaInterpolation.source + ".XMin") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _VannaVolgaInterpolation.cell
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
        some extra functionality
    *)
    [<ExcelFunction(Name="_VannaVolgaInterpolation_allowsExtrapolation", Description="Create a VannaVolgaInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VannaVolgaInterpolation_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VannaVolgaInterpolation",Description = "VannaVolgaInterpolation")>] 
         vannavolgainterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VannaVolgaInterpolation = Helper.toModelReference<VannaVolgaInterpolation> vannavolgainterpolation "VannaVolgaInterpolation"  
                let builder (current : ICell) = ((VannaVolgaInterpolationModel.Cast _VannaVolgaInterpolation.cell).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_VannaVolgaInterpolation.source + ".AllowsExtrapolation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _VannaVolgaInterpolation.cell
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
    [<ExcelFunction(Name="_VannaVolgaInterpolation_disableExtrapolation", Description="Create a VannaVolgaInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VannaVolgaInterpolation_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VannaVolgaInterpolation",Description = "VannaVolgaInterpolation")>] 
         vannavolgainterpolation : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VannaVolgaInterpolation = Helper.toModelReference<VannaVolgaInterpolation> vannavolgainterpolation "VannaVolgaInterpolation"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = ((VannaVolgaInterpolationModel.Cast _VannaVolgaInterpolation.cell).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : VannaVolgaInterpolation) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_VannaVolgaInterpolation.source + ".DisableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VannaVolgaInterpolation.cell
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
    [<ExcelFunction(Name="_VannaVolgaInterpolation_enableExtrapolation", Description="Create a VannaVolgaInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VannaVolgaInterpolation_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VannaVolgaInterpolation",Description = "VannaVolgaInterpolation")>] 
         vannavolgainterpolation : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VannaVolgaInterpolation = Helper.toModelReference<VannaVolgaInterpolation> vannavolgainterpolation "VannaVolgaInterpolation"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = ((VannaVolgaInterpolationModel.Cast _VannaVolgaInterpolation.cell).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : VannaVolgaInterpolation) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_VannaVolgaInterpolation.source + ".EnableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VannaVolgaInterpolation.cell
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
    [<ExcelFunction(Name="_VannaVolgaInterpolation_extrapolate", Description="Create a VannaVolgaInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VannaVolgaInterpolation_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VannaVolgaInterpolation",Description = "VannaVolgaInterpolation")>] 
         vannavolgainterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VannaVolgaInterpolation = Helper.toModelReference<VannaVolgaInterpolation> vannavolgainterpolation "VannaVolgaInterpolation"  
                let builder (current : ICell) = ((VannaVolgaInterpolationModel.Cast _VannaVolgaInterpolation.cell).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_VannaVolgaInterpolation.source + ".Extrapolate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _VannaVolgaInterpolation.cell
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
    [<ExcelFunction(Name="_VannaVolgaInterpolation_Range", Description="Create a range of VannaVolgaInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VannaVolgaInterpolation_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<VannaVolgaInterpolation> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<VannaVolgaInterpolation> (c)) :> ICell
                let format (i : Cephei.Cell.List<VannaVolgaInterpolation>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<VannaVolgaInterpolation>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
