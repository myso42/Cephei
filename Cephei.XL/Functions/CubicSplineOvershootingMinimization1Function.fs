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

  </summary> *)
[<AutoSerializable(true)>]
module CubicSplineOvershootingMinimization1Function =

    (*
        ! \pre the \f$ x \f$ values must be sorted.
    *)
    [<ExcelFunction(Name="_CubicSplineOvershootingMinimization1", Description="Create a CubicSplineOvershootingMinimization1",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CubicSplineOvershootingMinimization1_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="xBegin",Description = "Reference to xBegin")>] 
         xBegin : obj)
        ([<ExcelArgument(Name="size",Description = "Reference to size")>] 
         size : obj)
        ([<ExcelArgument(Name="yBegin",Description = "Reference to yBegin")>] 
         yBegin : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _xBegin = Helper.toCell<Generic.List<double>> xBegin "xBegin" true
                let _size = Helper.toCell<int> size "size" true
                let _yBegin = Helper.toCell<Generic.List<double>> yBegin "yBegin" true
                let builder () = withMnemonic mnemonic (Fun.CubicSplineOvershootingMinimization1 
                                                            _xBegin.cell 
                                                            _size.cell 
                                                            _yBegin.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CubicSplineOvershootingMinimization1>) l

                let source = Helper.sourceFold "Fun.CubicSplineOvershootingMinimization1" 
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
    [<ExcelFunction(Name="_CubicSplineOvershootingMinimization1_aCoefficients", Description="Create a CubicSplineOvershootingMinimization1",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CubicSplineOvershootingMinimization1_aCoefficients
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicSplineOvershootingMinimization1",Description = "Reference to CubicSplineOvershootingMinimization1")>] 
         cubicsplineovershootingminimization1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicSplineOvershootingMinimization1 = Helper.toCell<CubicSplineOvershootingMinimization1> cubicsplineovershootingminimization1 "CubicSplineOvershootingMinimization1" true 
                let builder () = withMnemonic mnemonic ((_CubicSplineOvershootingMinimization1.cell :?> CubicSplineOvershootingMinimization1Model).ACoefficients
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_CubicSplineOvershootingMinimization1.source + ".ACoefficients") 
                                               [| _CubicSplineOvershootingMinimization1.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicSplineOvershootingMinimization1.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_CubicSplineOvershootingMinimization1_bCoefficients", Description="Create a CubicSplineOvershootingMinimization1",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CubicSplineOvershootingMinimization1_bCoefficients
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicSplineOvershootingMinimization1",Description = "Reference to CubicSplineOvershootingMinimization1")>] 
         cubicsplineovershootingminimization1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicSplineOvershootingMinimization1 = Helper.toCell<CubicSplineOvershootingMinimization1> cubicsplineovershootingminimization1 "CubicSplineOvershootingMinimization1" true 
                let builder () = withMnemonic mnemonic ((_CubicSplineOvershootingMinimization1.cell :?> CubicSplineOvershootingMinimization1Model).BCoefficients
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_CubicSplineOvershootingMinimization1.source + ".BCoefficients") 
                                               [| _CubicSplineOvershootingMinimization1.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicSplineOvershootingMinimization1.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_CubicSplineOvershootingMinimization1_cCoefficients", Description="Create a CubicSplineOvershootingMinimization1",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CubicSplineOvershootingMinimization1_cCoefficients
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicSplineOvershootingMinimization1",Description = "Reference to CubicSplineOvershootingMinimization1")>] 
         cubicsplineovershootingminimization1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicSplineOvershootingMinimization1 = Helper.toCell<CubicSplineOvershootingMinimization1> cubicsplineovershootingminimization1 "CubicSplineOvershootingMinimization1" true 
                let builder () = withMnemonic mnemonic ((_CubicSplineOvershootingMinimization1.cell :?> CubicSplineOvershootingMinimization1Model).CCoefficients
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_CubicSplineOvershootingMinimization1.source + ".CCoefficients") 
                                               [| _CubicSplineOvershootingMinimization1.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicSplineOvershootingMinimization1.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_CubicSplineOvershootingMinimization1_derivative", Description="Create a CubicSplineOvershootingMinimization1",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CubicSplineOvershootingMinimization1_derivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicSplineOvershootingMinimization1",Description = "Reference to CubicSplineOvershootingMinimization1")>] 
         cubicsplineovershootingminimization1 : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicSplineOvershootingMinimization1 = Helper.toCell<CubicSplineOvershootingMinimization1> cubicsplineovershootingminimization1 "CubicSplineOvershootingMinimization1" true 
                let _x = Helper.toCell<double> x "x" true
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" true
                let builder () = withMnemonic mnemonic ((_CubicSplineOvershootingMinimization1.cell :?> CubicSplineOvershootingMinimization1Model).Derivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CubicSplineOvershootingMinimization1.source + ".Derivative") 
                                               [| _CubicSplineOvershootingMinimization1.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicSplineOvershootingMinimization1.cell
                                ;  _x.cell
                                ;  _allowExtrapolation.cell
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
        
    *)
    [<ExcelFunction(Name="_CubicSplineOvershootingMinimization1_empty", Description="Create a CubicSplineOvershootingMinimization1",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CubicSplineOvershootingMinimization1_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicSplineOvershootingMinimization1",Description = "Reference to CubicSplineOvershootingMinimization1")>] 
         cubicsplineovershootingminimization1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicSplineOvershootingMinimization1 = Helper.toCell<CubicSplineOvershootingMinimization1> cubicsplineovershootingminimization1 "CubicSplineOvershootingMinimization1" true 
                let builder () = withMnemonic mnemonic ((_CubicSplineOvershootingMinimization1.cell :?> CubicSplineOvershootingMinimization1Model).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CubicSplineOvershootingMinimization1.source + ".Empty") 
                                               [| _CubicSplineOvershootingMinimization1.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicSplineOvershootingMinimization1.cell
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
        
    *)
    [<ExcelFunction(Name="_CubicSplineOvershootingMinimization1_primitive", Description="Create a CubicSplineOvershootingMinimization1",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CubicSplineOvershootingMinimization1_primitive
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicSplineOvershootingMinimization1",Description = "Reference to CubicSplineOvershootingMinimization1")>] 
         cubicsplineovershootingminimization1 : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicSplineOvershootingMinimization1 = Helper.toCell<CubicSplineOvershootingMinimization1> cubicsplineovershootingminimization1 "CubicSplineOvershootingMinimization1" true 
                let _x = Helper.toCell<double> x "x" true
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" true
                let builder () = withMnemonic mnemonic ((_CubicSplineOvershootingMinimization1.cell :?> CubicSplineOvershootingMinimization1Model).Primitive
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CubicSplineOvershootingMinimization1.source + ".Primitive") 
                                               [| _CubicSplineOvershootingMinimization1.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicSplineOvershootingMinimization1.cell
                                ;  _x.cell
                                ;  _allowExtrapolation.cell
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
        
    *)
    [<ExcelFunction(Name="_CubicSplineOvershootingMinimization1_secondDerivative", Description="Create a CubicSplineOvershootingMinimization1",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CubicSplineOvershootingMinimization1_secondDerivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicSplineOvershootingMinimization1",Description = "Reference to CubicSplineOvershootingMinimization1")>] 
         cubicsplineovershootingminimization1 : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicSplineOvershootingMinimization1 = Helper.toCell<CubicSplineOvershootingMinimization1> cubicsplineovershootingminimization1 "CubicSplineOvershootingMinimization1" true 
                let _x = Helper.toCell<double> x "x" true
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" true
                let builder () = withMnemonic mnemonic ((_CubicSplineOvershootingMinimization1.cell :?> CubicSplineOvershootingMinimization1Model).SecondDerivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CubicSplineOvershootingMinimization1.source + ".SecondDerivative") 
                                               [| _CubicSplineOvershootingMinimization1.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicSplineOvershootingMinimization1.cell
                                ;  _x.cell
                                ;  _allowExtrapolation.cell
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
        
    *)
    [<ExcelFunction(Name="_CubicSplineOvershootingMinimization1_update", Description="Create a CubicSplineOvershootingMinimization1",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CubicSplineOvershootingMinimization1_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicSplineOvershootingMinimization1",Description = "Reference to CubicSplineOvershootingMinimization1")>] 
         cubicsplineovershootingminimization1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicSplineOvershootingMinimization1 = Helper.toCell<CubicSplineOvershootingMinimization1> cubicsplineovershootingminimization1 "CubicSplineOvershootingMinimization1" true 
                let builder () = withMnemonic mnemonic ((_CubicSplineOvershootingMinimization1.cell :?> CubicSplineOvershootingMinimization1Model).Update
                                                       ) :> ICell
                let format (o : CubicSplineOvershootingMinimization1) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CubicSplineOvershootingMinimization1.source + ".Update") 
                                               [| _CubicSplineOvershootingMinimization1.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicSplineOvershootingMinimization1.cell
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
        
    *)
    [<ExcelFunction(Name="_CubicSplineOvershootingMinimization1_value1", Description="Create a CubicSplineOvershootingMinimization1",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CubicSplineOvershootingMinimization1_value1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicSplineOvershootingMinimization1",Description = "Reference to CubicSplineOvershootingMinimization1")>] 
         cubicsplineovershootingminimization1 : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicSplineOvershootingMinimization1 = Helper.toCell<CubicSplineOvershootingMinimization1> cubicsplineovershootingminimization1 "CubicSplineOvershootingMinimization1" true 
                let _x = Helper.toCell<double> x "x" true
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" true
                let builder () = withMnemonic mnemonic ((_CubicSplineOvershootingMinimization1.cell :?> CubicSplineOvershootingMinimization1Model).Value1
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CubicSplineOvershootingMinimization1.source + ".Value1") 
                                               [| _CubicSplineOvershootingMinimization1.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicSplineOvershootingMinimization1.cell
                                ;  _x.cell
                                ;  _allowExtrapolation.cell
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
        main method to derive an interpolated point
    *)
    [<ExcelFunction(Name="_CubicSplineOvershootingMinimization1_value", Description="Create a CubicSplineOvershootingMinimization1",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CubicSplineOvershootingMinimization1_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicSplineOvershootingMinimization1",Description = "Reference to CubicSplineOvershootingMinimization1")>] 
         cubicsplineovershootingminimization1 : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicSplineOvershootingMinimization1 = Helper.toCell<CubicSplineOvershootingMinimization1> cubicsplineovershootingminimization1 "CubicSplineOvershootingMinimization1" true 
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_CubicSplineOvershootingMinimization1.cell :?> CubicSplineOvershootingMinimization1Model).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CubicSplineOvershootingMinimization1.source + ".Value") 
                                               [| _CubicSplineOvershootingMinimization1.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicSplineOvershootingMinimization1.cell
                                ;  _x.cell
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
        
    *)
    [<ExcelFunction(Name="_CubicSplineOvershootingMinimization1_xMax", Description="Create a CubicSplineOvershootingMinimization1",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CubicSplineOvershootingMinimization1_xMax
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicSplineOvershootingMinimization1",Description = "Reference to CubicSplineOvershootingMinimization1")>] 
         cubicsplineovershootingminimization1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicSplineOvershootingMinimization1 = Helper.toCell<CubicSplineOvershootingMinimization1> cubicsplineovershootingminimization1 "CubicSplineOvershootingMinimization1" true 
                let builder () = withMnemonic mnemonic ((_CubicSplineOvershootingMinimization1.cell :?> CubicSplineOvershootingMinimization1Model).XMax
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CubicSplineOvershootingMinimization1.source + ".XMax") 
                                               [| _CubicSplineOvershootingMinimization1.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicSplineOvershootingMinimization1.cell
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
        
    *)
    [<ExcelFunction(Name="_CubicSplineOvershootingMinimization1_xMin", Description="Create a CubicSplineOvershootingMinimization1",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CubicSplineOvershootingMinimization1_xMin
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicSplineOvershootingMinimization1",Description = "Reference to CubicSplineOvershootingMinimization1")>] 
         cubicsplineovershootingminimization1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicSplineOvershootingMinimization1 = Helper.toCell<CubicSplineOvershootingMinimization1> cubicsplineovershootingminimization1 "CubicSplineOvershootingMinimization1" true 
                let builder () = withMnemonic mnemonic ((_CubicSplineOvershootingMinimization1.cell :?> CubicSplineOvershootingMinimization1Model).XMin
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CubicSplineOvershootingMinimization1.source + ".XMin") 
                                               [| _CubicSplineOvershootingMinimization1.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicSplineOvershootingMinimization1.cell
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
        some extra functionality
    *)
    [<ExcelFunction(Name="_CubicSplineOvershootingMinimization1_allowsExtrapolation", Description="Create a CubicSplineOvershootingMinimization1",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CubicSplineOvershootingMinimization1_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicSplineOvershootingMinimization1",Description = "Reference to CubicSplineOvershootingMinimization1")>] 
         cubicsplineovershootingminimization1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicSplineOvershootingMinimization1 = Helper.toCell<CubicSplineOvershootingMinimization1> cubicsplineovershootingminimization1 "CubicSplineOvershootingMinimization1" true 
                let builder () = withMnemonic mnemonic ((_CubicSplineOvershootingMinimization1.cell :?> CubicSplineOvershootingMinimization1Model).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CubicSplineOvershootingMinimization1.source + ".AllowsExtrapolation") 
                                               [| _CubicSplineOvershootingMinimization1.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicSplineOvershootingMinimization1.cell
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
        ! enable extrapolation in subsequent calls
    *)
    [<ExcelFunction(Name="_CubicSplineOvershootingMinimization1_disableExtrapolation", Description="Create a CubicSplineOvershootingMinimization1",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CubicSplineOvershootingMinimization1_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicSplineOvershootingMinimization1",Description = "Reference to CubicSplineOvershootingMinimization1")>] 
         cubicsplineovershootingminimization1 : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicSplineOvershootingMinimization1 = Helper.toCell<CubicSplineOvershootingMinimization1> cubicsplineovershootingminimization1 "CubicSplineOvershootingMinimization1" true 
                let _b = Helper.toCell<bool> b "b" true
                let builder () = withMnemonic mnemonic ((_CubicSplineOvershootingMinimization1.cell :?> CubicSplineOvershootingMinimization1Model).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : CubicSplineOvershootingMinimization1) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CubicSplineOvershootingMinimization1.source + ".DisableExtrapolation") 
                                               [| _CubicSplineOvershootingMinimization1.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicSplineOvershootingMinimization1.cell
                                ;  _b.cell
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
        ! tells whether extrapolation is enabled
    *)
    [<ExcelFunction(Name="_CubicSplineOvershootingMinimization1_enableExtrapolation", Description="Create a CubicSplineOvershootingMinimization1",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CubicSplineOvershootingMinimization1_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicSplineOvershootingMinimization1",Description = "Reference to CubicSplineOvershootingMinimization1")>] 
         cubicsplineovershootingminimization1 : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicSplineOvershootingMinimization1 = Helper.toCell<CubicSplineOvershootingMinimization1> cubicsplineovershootingminimization1 "CubicSplineOvershootingMinimization1" true 
                let _b = Helper.toCell<bool> b "b" true
                let builder () = withMnemonic mnemonic ((_CubicSplineOvershootingMinimization1.cell :?> CubicSplineOvershootingMinimization1Model).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : CubicSplineOvershootingMinimization1) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CubicSplineOvershootingMinimization1.source + ".EnableExtrapolation") 
                                               [| _CubicSplineOvershootingMinimization1.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicSplineOvershootingMinimization1.cell
                                ;  _b.cell
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
        
    *)
    [<ExcelFunction(Name="_CubicSplineOvershootingMinimization1_extrapolate", Description="Create a CubicSplineOvershootingMinimization1",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CubicSplineOvershootingMinimization1_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicSplineOvershootingMinimization1",Description = "Reference to CubicSplineOvershootingMinimization1")>] 
         cubicsplineovershootingminimization1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicSplineOvershootingMinimization1 = Helper.toCell<CubicSplineOvershootingMinimization1> cubicsplineovershootingminimization1 "CubicSplineOvershootingMinimization1" true 
                let builder () = withMnemonic mnemonic ((_CubicSplineOvershootingMinimization1.cell :?> CubicSplineOvershootingMinimization1Model).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CubicSplineOvershootingMinimization1.source + ".Extrapolate") 
                                               [| _CubicSplineOvershootingMinimization1.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicSplineOvershootingMinimization1.cell
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
    [<ExcelFunction(Name="_CubicSplineOvershootingMinimization1_Range", Description="Create a range of CubicSplineOvershootingMinimization1",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CubicSplineOvershootingMinimization1_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the CubicSplineOvershootingMinimization1")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CubicSplineOvershootingMinimization1> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CubicSplineOvershootingMinimization1>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<CubicSplineOvershootingMinimization1>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<CubicSplineOvershootingMinimization1>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"