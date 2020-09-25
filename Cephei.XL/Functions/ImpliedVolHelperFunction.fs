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
module ImpliedVolHelperFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ImpliedVolHelper_derivative", Description="Create a ImpliedVolHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ImpliedVolHelper_derivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ImpliedVolHelper",Description = "Reference to ImpliedVolHelper")>] 
         impliedvolhelper : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ImpliedVolHelper = Helper.toCell<ImpliedVolHelper> impliedvolhelper "ImpliedVolHelper" true 
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_ImpliedVolHelper.cell :?> ImpliedVolHelperModel).Derivative
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ImpliedVolHelper.source + ".Derivative") 
                                               [| _ImpliedVolHelper.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ImpliedVolHelper.cell
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
    [<ExcelFunction(Name="_ImpliedVolHelper", Description="Create a ImpliedVolHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ImpliedVolHelper_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="cap",Description = "Reference to cap")>] 
         cap : obj)
        ([<ExcelArgument(Name="discountCurve",Description = "Reference to discountCurve")>] 
         discountCurve : obj)
        ([<ExcelArgument(Name="targetValue",Description = "Reference to targetValue")>] 
         targetValue : obj)
        ([<ExcelArgument(Name="displacement",Description = "Reference to displacement")>] 
         displacement : obj)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _cap = Helper.toCell<CapFloor> cap "cap" true
                let _discountCurve = Helper.toHandle<YieldTermStructure> discountCurve "discountCurve" 
                let _targetValue = Helper.toCell<double> targetValue "targetValue" true
                let _displacement = Helper.toCell<double> displacement "displacement" true
                let _Type = Helper.toCell<VolatilityType> Type "Type" true
                let builder () = withMnemonic mnemonic (Fun.ImpliedVolHelper 
                                                            _cap.cell 
                                                            _discountCurve.cell 
                                                            _targetValue.cell 
                                                            _displacement.cell 
                                                            _Type.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ImpliedVolHelper>) l

                let source = Helper.sourceFold "Fun.ImpliedVolHelper" 
                                               [| _cap.source
                                               ;  _discountCurve.source
                                               ;  _targetValue.source
                                               ;  _displacement.source
                                               ;  _Type.source
                                               |]
                let hash = Helper.hashFold 
                                [| _cap.cell
                                ;  _discountCurve.cell
                                ;  _targetValue.cell
                                ;  _displacement.cell
                                ;  _Type.cell
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
    [<ExcelFunction(Name="_ImpliedVolHelper_value", Description="Create a ImpliedVolHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ImpliedVolHelper_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ImpliedVolHelper",Description = "Reference to ImpliedVolHelper")>] 
         impliedvolhelper : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ImpliedVolHelper = Helper.toCell<ImpliedVolHelper> impliedvolhelper "ImpliedVolHelper" true 
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_ImpliedVolHelper.cell :?> ImpliedVolHelperModel).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ImpliedVolHelper.source + ".Value") 
                                               [| _ImpliedVolHelper.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ImpliedVolHelper.cell
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
    [<ExcelFunction(Name="_ImpliedVolHelper_Range", Description="Create a range of ImpliedVolHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ImpliedVolHelper_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the ImpliedVolHelper")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ImpliedVolHelper> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ImpliedVolHelper>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<ImpliedVolHelper>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<ImpliedVolHelper>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"