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
module ImpliedVolHelperFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ImpliedVolHelper_derivative", Description="Create a ImpliedVolHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ImpliedVolHelper_derivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ImpliedVolHelper",Description = "ImpliedVolHelper")>] 
         impliedvolhelper : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ImpliedVolHelper = Helper.toModelReference<ImpliedVolHelper> impliedvolhelper "ImpliedVolHelper"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = ((ImpliedVolHelperModel.Cast _ImpliedVolHelper.cell).Derivative
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ImpliedVolHelper.source + ".Derivative") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ImpliedVolHelper.cell
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
    [<ExcelFunction(Name="_ImpliedVolHelper", Description="Create a ImpliedVolHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ImpliedVolHelper_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="cap",Description = "CapFloor")>] 
         cap : obj)
        ([<ExcelArgument(Name="discountCurve",Description = "YieldTermStructure")>] 
         discountCurve : obj)
        ([<ExcelArgument(Name="targetValue",Description = "double")>] 
         targetValue : obj)
        ([<ExcelArgument(Name="displacement",Description = "double")>] 
         displacement : obj)
        ([<ExcelArgument(Name="Type",Description = "VolatilityType: ShiftedLognormal, Normal")>] 
         Type : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _cap = Helper.toCell<CapFloor> cap "cap" 
                let _discountCurve = Helper.toHandle<YieldTermStructure> discountCurve "discountCurve" 
                let _targetValue = Helper.toCell<double> targetValue "targetValue" 
                let _displacement = Helper.toCell<double> displacement "displacement" 
                let _Type = Helper.toCell<VolatilityType> Type "Type" 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = (Fun.ImpliedVolHelper 
                                                            _cap.cell 
                                                            _discountCurve.cell 
                                                            _targetValue.cell 
                                                            _displacement.cell 
                                                            _Type.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ImpliedVolHelper>) l

                let source () = Helper.sourceFold "Fun.ImpliedVolHelper" 
                                               [| _cap.source
                                               ;  _discountCurve.source
                                               ;  _targetValue.source
                                               ;  _displacement.source
                                               ;  _Type.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _cap.cell
                                ;  _discountCurve.cell
                                ;  _targetValue.cell
                                ;  _displacement.cell
                                ;  _Type.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ImpliedVolHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ImpliedVolHelper_value", Description="Create a ImpliedVolHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ImpliedVolHelper_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ImpliedVolHelper",Description = "ImpliedVolHelper")>] 
         impliedvolhelper : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ImpliedVolHelper = Helper.toModelReference<ImpliedVolHelper> impliedvolhelper "ImpliedVolHelper"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = ((ImpliedVolHelperModel.Cast _ImpliedVolHelper.cell).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ImpliedVolHelper.source + ".Value") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ImpliedVolHelper.cell
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
    [<ExcelFunction(Name="_ImpliedVolHelper_Range", Description="Create a range of ImpliedVolHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ImpliedVolHelper_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ImpliedVolHelper> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<ImpliedVolHelper> (c)) :> ICell
                let format (i : Cephei.Cell.List<ImpliedVolHelper>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<ImpliedVolHelper>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
