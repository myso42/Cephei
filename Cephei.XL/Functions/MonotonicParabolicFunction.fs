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
module MonotonicParabolicFunction =

    (*
        ! \pre the \f$ x \f$ values must be sorted.
    *)
    [<ExcelFunction(Name="_MonotonicParabolic", Description="Create a MonotonicParabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MonotonicParabolic_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="xBegin",Description = "double range")>] 
         xBegin : obj)
        ([<ExcelArgument(Name="size",Description = "int")>] 
         size : obj)
        ([<ExcelArgument(Name="yBegin",Description = "double range")>] 
         yBegin : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _xBegin = Helper.toCell<Generic.List<double>> xBegin "xBegin" 
                let _size = Helper.toCell<int> size "size" 
                let _yBegin = Helper.toCell<Generic.List<double>> yBegin "yBegin" 
                let builder (current : ICell) = (Fun.MonotonicParabolic 
                                                            _xBegin.cell 
                                                            _size.cell 
                                                            _yBegin.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<MonotonicParabolic>) l

                let source () = Helper.sourceFold "Fun.MonotonicParabolic" 
                                               [| _xBegin.source
                                               ;  _size.source
                                               ;  _yBegin.source
                                               |]
                let hash = Helper.hashFold 
                                [| _xBegin.cell
                                ;  _size.cell
                                ;  _yBegin.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MonotonicParabolic> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_MonotonicParabolic_aCoefficients", Description="Create a MonotonicParabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MonotonicParabolic_aCoefficients
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonotonicParabolic",Description = "MonotonicParabolic")>] 
         monotonicparabolic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonotonicParabolic = Helper.toModelReference<MonotonicParabolic> monotonicparabolic "MonotonicParabolic"  
                let builder (current : ICell) = ((MonotonicParabolicModel.Cast _MonotonicParabolic.cell).ACoefficients
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_MonotonicParabolic.source + ".ACoefficients") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MonotonicParabolic.cell
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
    [<ExcelFunction(Name="_MonotonicParabolic_bCoefficients", Description="Create a MonotonicParabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MonotonicParabolic_bCoefficients
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonotonicParabolic",Description = "MonotonicParabolic")>] 
         monotonicparabolic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonotonicParabolic = Helper.toModelReference<MonotonicParabolic> monotonicparabolic "MonotonicParabolic"  
                let builder (current : ICell) = ((MonotonicParabolicModel.Cast _MonotonicParabolic.cell).BCoefficients
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_MonotonicParabolic.source + ".BCoefficients") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MonotonicParabolic.cell
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
    [<ExcelFunction(Name="_MonotonicParabolic_cCoefficients", Description="Create a MonotonicParabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MonotonicParabolic_cCoefficients
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonotonicParabolic",Description = "MonotonicParabolic")>] 
         monotonicparabolic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonotonicParabolic = Helper.toModelReference<MonotonicParabolic> monotonicparabolic "MonotonicParabolic"  
                let builder (current : ICell) = ((MonotonicParabolicModel.Cast _MonotonicParabolic.cell).CCoefficients
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_MonotonicParabolic.source + ".CCoefficients") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MonotonicParabolic.cell
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
    [<ExcelFunction(Name="_MonotonicParabolic_derivative", Description="Create a MonotonicParabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MonotonicParabolic_derivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonotonicParabolic",Description = "MonotonicParabolic")>] 
         monotonicparabolic : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonotonicParabolic = Helper.toModelReference<MonotonicParabolic> monotonicparabolic "MonotonicParabolic"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = ((MonotonicParabolicModel.Cast _MonotonicParabolic.cell).Derivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MonotonicParabolic.source + ".Derivative") 

                                               [| _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MonotonicParabolic.cell
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
    [<ExcelFunction(Name="_MonotonicParabolic_empty", Description="Create a MonotonicParabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MonotonicParabolic_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonotonicParabolic",Description = "MonotonicParabolic")>] 
         monotonicparabolic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonotonicParabolic = Helper.toModelReference<MonotonicParabolic> monotonicparabolic "MonotonicParabolic"  
                let builder (current : ICell) = ((MonotonicParabolicModel.Cast _MonotonicParabolic.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MonotonicParabolic.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MonotonicParabolic.cell
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
    [<ExcelFunction(Name="_MonotonicParabolic_primitive", Description="Create a MonotonicParabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MonotonicParabolic_primitive
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonotonicParabolic",Description = "MonotonicParabolic")>] 
         monotonicparabolic : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonotonicParabolic = Helper.toModelReference<MonotonicParabolic> monotonicparabolic "MonotonicParabolic"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = ((MonotonicParabolicModel.Cast _MonotonicParabolic.cell).Primitive
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MonotonicParabolic.source + ".Primitive") 

                                               [| _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MonotonicParabolic.cell
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
    [<ExcelFunction(Name="_MonotonicParabolic_secondDerivative", Description="Create a MonotonicParabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MonotonicParabolic_secondDerivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonotonicParabolic",Description = "MonotonicParabolic")>] 
         monotonicparabolic : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonotonicParabolic = Helper.toModelReference<MonotonicParabolic> monotonicparabolic "MonotonicParabolic"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = ((MonotonicParabolicModel.Cast _MonotonicParabolic.cell).SecondDerivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MonotonicParabolic.source + ".SecondDerivative") 

                                               [| _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MonotonicParabolic.cell
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
    [<ExcelFunction(Name="_MonotonicParabolic_update", Description="Create a MonotonicParabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MonotonicParabolic_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonotonicParabolic",Description = "MonotonicParabolic")>] 
         monotonicparabolic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonotonicParabolic = Helper.toModelReference<MonotonicParabolic> monotonicparabolic "MonotonicParabolic"  
                let builder (current : ICell) = ((MonotonicParabolicModel.Cast _MonotonicParabolic.cell).Update
                                                       ) :> ICell
                let format (o : MonotonicParabolic) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MonotonicParabolic.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MonotonicParabolic.cell
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
    [<ExcelFunction(Name="_MonotonicParabolic_value1", Description="Create a MonotonicParabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MonotonicParabolic_value1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonotonicParabolic",Description = "MonotonicParabolic")>] 
         monotonicparabolic : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonotonicParabolic = Helper.toModelReference<MonotonicParabolic> monotonicparabolic "MonotonicParabolic"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = ((MonotonicParabolicModel.Cast _MonotonicParabolic.cell).Value1
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MonotonicParabolic.source + ".Value1") 

                                               [| _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MonotonicParabolic.cell
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
    [<ExcelFunction(Name="_MonotonicParabolic_value", Description="Create a MonotonicParabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MonotonicParabolic_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonotonicParabolic",Description = "MonotonicParabolic")>] 
         monotonicparabolic : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonotonicParabolic = Helper.toModelReference<MonotonicParabolic> monotonicparabolic "MonotonicParabolic"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = ((MonotonicParabolicModel.Cast _MonotonicParabolic.cell).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MonotonicParabolic.source + ".Value") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MonotonicParabolic.cell
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
    [<ExcelFunction(Name="_MonotonicParabolic_xMax", Description="Create a MonotonicParabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MonotonicParabolic_xMax
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonotonicParabolic",Description = "MonotonicParabolic")>] 
         monotonicparabolic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonotonicParabolic = Helper.toModelReference<MonotonicParabolic> monotonicparabolic "MonotonicParabolic"  
                let builder (current : ICell) = ((MonotonicParabolicModel.Cast _MonotonicParabolic.cell).XMax
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MonotonicParabolic.source + ".XMax") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MonotonicParabolic.cell
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
    [<ExcelFunction(Name="_MonotonicParabolic_xMin", Description="Create a MonotonicParabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MonotonicParabolic_xMin
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonotonicParabolic",Description = "MonotonicParabolic")>] 
         monotonicparabolic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonotonicParabolic = Helper.toModelReference<MonotonicParabolic> monotonicparabolic "MonotonicParabolic"  
                let builder (current : ICell) = ((MonotonicParabolicModel.Cast _MonotonicParabolic.cell).XMin
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MonotonicParabolic.source + ".XMin") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MonotonicParabolic.cell
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
    [<ExcelFunction(Name="_MonotonicParabolic_allowsExtrapolation", Description="Create a MonotonicParabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MonotonicParabolic_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonotonicParabolic",Description = "MonotonicParabolic")>] 
         monotonicparabolic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonotonicParabolic = Helper.toModelReference<MonotonicParabolic> monotonicparabolic "MonotonicParabolic"  
                let builder (current : ICell) = ((MonotonicParabolicModel.Cast _MonotonicParabolic.cell).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MonotonicParabolic.source + ".AllowsExtrapolation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MonotonicParabolic.cell
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
    [<ExcelFunction(Name="_MonotonicParabolic_disableExtrapolation", Description="Create a MonotonicParabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MonotonicParabolic_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonotonicParabolic",Description = "MonotonicParabolic")>] 
         monotonicparabolic : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonotonicParabolic = Helper.toModelReference<MonotonicParabolic> monotonicparabolic "MonotonicParabolic"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = ((MonotonicParabolicModel.Cast _MonotonicParabolic.cell).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : MonotonicParabolic) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MonotonicParabolic.source + ".DisableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MonotonicParabolic.cell
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
    [<ExcelFunction(Name="_MonotonicParabolic_enableExtrapolation", Description="Create a MonotonicParabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MonotonicParabolic_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonotonicParabolic",Description = "MonotonicParabolic")>] 
         monotonicparabolic : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonotonicParabolic = Helper.toModelReference<MonotonicParabolic> monotonicparabolic "MonotonicParabolic"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = ((MonotonicParabolicModel.Cast _MonotonicParabolic.cell).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : MonotonicParabolic) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MonotonicParabolic.source + ".EnableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MonotonicParabolic.cell
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
    [<ExcelFunction(Name="_MonotonicParabolic_extrapolate", Description="Create a MonotonicParabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MonotonicParabolic_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonotonicParabolic",Description = "MonotonicParabolic")>] 
         monotonicparabolic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonotonicParabolic = Helper.toModelReference<MonotonicParabolic> monotonicparabolic "MonotonicParabolic"  
                let builder (current : ICell) = ((MonotonicParabolicModel.Cast _MonotonicParabolic.cell).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MonotonicParabolic.source + ".Extrapolate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MonotonicParabolic.cell
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
    [<ExcelFunction(Name="_MonotonicParabolic_Range", Description="Create a range of MonotonicParabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MonotonicParabolic_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<MonotonicParabolic> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<MonotonicParabolic> (c)) :> ICell
                let format (i : Cephei.Cell.List<MonotonicParabolic>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<MonotonicParabolic>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
