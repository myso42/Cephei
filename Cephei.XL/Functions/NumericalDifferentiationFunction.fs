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
module NumericalDifferentiationFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_NumericalDifferentiation", Description="Create a NumericalDifferentiation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NumericalDifferentiation_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="f",Description = "Reference to f")>] 
         f : obj)
        ([<ExcelArgument(Name="orderOfDerivative",Description = "Reference to orderOfDerivative")>] 
         orderOfDerivative : obj)
        ([<ExcelArgument(Name="stepSize",Description = "Reference to stepSize")>] 
         stepSize : obj)
        ([<ExcelArgument(Name="steps",Description = "Reference to steps")>] 
         steps : obj)
        ([<ExcelArgument(Name="scheme",Description = "Reference to scheme")>] 
         scheme : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _f = Helper.toCell<Func<double,double>> f "f" true
                let _orderOfDerivative = Helper.toCell<int> orderOfDerivative "orderOfDerivative" true
                let _stepSize = Helper.toCell<double> stepSize "stepSize" true
                let _steps = Helper.toCell<int> steps "steps" true
                let _scheme = Helper.toCell<NumericalDifferentiation.Scheme> scheme "scheme" true
                let builder () = withMnemonic mnemonic (Fun.NumericalDifferentiation 
                                                            _f.cell 
                                                            _orderOfDerivative.cell 
                                                            _stepSize.cell 
                                                            _steps.cell 
                                                            _scheme.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<NumericalDifferentiation>) l

                let source = Helper.sourceFold "Fun.NumericalDifferentiation" 
                                               [| _f.source
                                               ;  _orderOfDerivative.source
                                               ;  _stepSize.source
                                               ;  _steps.source
                                               ;  _scheme.source
                                               |]
                let hash = Helper.hashFold 
                                [| _f.cell
                                ;  _orderOfDerivative.cell
                                ;  _stepSize.cell
                                ;  _steps.cell
                                ;  _scheme.cell
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
    [<ExcelFunction(Name="_NumericalDifferentiation1", Description="Create a NumericalDifferentiation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NumericalDifferentiation_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="f",Description = "Reference to f")>] 
         f : obj)
        ([<ExcelArgument(Name="orderOfDerivative",Description = "Reference to orderOfDerivative")>] 
         orderOfDerivative : obj)
        ([<ExcelArgument(Name="x_offsets",Description = "Reference to x_offsets")>] 
         x_offsets : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _f = Helper.toCell<Func<double,double>> f "f" true
                let _orderOfDerivative = Helper.toCell<int> orderOfDerivative "orderOfDerivative" true
                let _x_offsets = Helper.toCell<Vector> x_offsets "x_offsets" true
                let builder () = withMnemonic mnemonic (Fun.NumericalDifferentiation1 
                                                            _f.cell 
                                                            _orderOfDerivative.cell 
                                                            _x_offsets.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<NumericalDifferentiation>) l

                let source = Helper.sourceFold "Fun.NumericalDifferentiation1" 
                                               [| _f.source
                                               ;  _orderOfDerivative.source
                                               ;  _x_offsets.source
                                               |]
                let hash = Helper.hashFold 
                                [| _f.cell
                                ;  _orderOfDerivative.cell
                                ;  _x_offsets.cell
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
    [<ExcelFunction(Name="_NumericalDifferentiation_offsets", Description="Create a NumericalDifferentiation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NumericalDifferentiation_offsets
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NumericalDifferentiation",Description = "Reference to NumericalDifferentiation")>] 
         numericaldifferentiation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NumericalDifferentiation = Helper.toCell<NumericalDifferentiation> numericaldifferentiation "NumericalDifferentiation" true 
                let builder () = withMnemonic mnemonic ((_NumericalDifferentiation.cell :?> NumericalDifferentiationModel).Offsets
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_NumericalDifferentiation.source + ".Offsets") 
                                               [| _NumericalDifferentiation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NumericalDifferentiation.cell
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
    [<ExcelFunction(Name="_NumericalDifferentiation_value", Description="Create a NumericalDifferentiation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NumericalDifferentiation_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NumericalDifferentiation",Description = "Reference to NumericalDifferentiation")>] 
         numericaldifferentiation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NumericalDifferentiation = Helper.toCell<NumericalDifferentiation> numericaldifferentiation "NumericalDifferentiation" true 
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_NumericalDifferentiation.cell :?> NumericalDifferentiationModel).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_NumericalDifferentiation.source + ".Value") 
                                               [| _NumericalDifferentiation.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NumericalDifferentiation.cell
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
    [<ExcelFunction(Name="_NumericalDifferentiation_weights", Description="Create a NumericalDifferentiation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NumericalDifferentiation_weights
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NumericalDifferentiation",Description = "Reference to NumericalDifferentiation")>] 
         numericaldifferentiation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NumericalDifferentiation = Helper.toCell<NumericalDifferentiation> numericaldifferentiation "NumericalDifferentiation" true 
                let builder () = withMnemonic mnemonic ((_NumericalDifferentiation.cell :?> NumericalDifferentiationModel).Weights
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_NumericalDifferentiation.source + ".Weights") 
                                               [| _NumericalDifferentiation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NumericalDifferentiation.cell
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
    [<ExcelFunction(Name="_NumericalDifferentiation_Range", Description="Create a range of NumericalDifferentiation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NumericalDifferentiation_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the NumericalDifferentiation")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<NumericalDifferentiation> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<NumericalDifferentiation>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<NumericalDifferentiation>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<NumericalDifferentiation>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"