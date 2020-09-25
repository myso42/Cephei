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
module BlackKarasinskiFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BlackKarasinski1", Description="Create a BlackKarasinski",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackKarasinski_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="termStructure",Description = "Reference to termStructure")>] 
         termStructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _termStructure = Helper.toHandle<YieldTermStructure> termStructure "termStructure" 
                let builder () = withMnemonic mnemonic (Fun.BlackKarasinski1 
                                                            _termStructure.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BlackKarasinski>) l

                let source = Helper.sourceFold "Fun.BlackKarasinski1" 
                                               [| _termStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _termStructure.cell
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
    [<ExcelFunction(Name="_BlackKarasinski", Description="Create a BlackKarasinski",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackKarasinski_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="termStructure",Description = "Reference to termStructure")>] 
         termStructure : obj)
        ([<ExcelArgument(Name="a",Description = "Reference to a")>] 
         a : obj)
        ([<ExcelArgument(Name="sigma",Description = "Reference to sigma")>] 
         sigma : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _termStructure = Helper.toHandle<YieldTermStructure> termStructure "termStructure" 
                let _a = Helper.toCell<double> a "a" true
                let _sigma = Helper.toCell<double> sigma "sigma" true
                let builder () = withMnemonic mnemonic (Fun.BlackKarasinski 
                                                            _termStructure.cell 
                                                            _a.cell 
                                                            _sigma.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BlackKarasinski>) l

                let source = Helper.sourceFold "Fun.BlackKarasinski" 
                                               [| _termStructure.source
                                               ;  _a.source
                                               ;  _sigma.source
                                               |]
                let hash = Helper.hashFold 
                                [| _termStructure.cell
                                ;  _a.cell
                                ;  _sigma.cell
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
    [<ExcelFunction(Name="_BlackKarasinski_dynamics", Description="Create a BlackKarasinski",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackKarasinski_dynamics
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackKarasinski",Description = "Reference to BlackKarasinski")>] 
         blackkarasinski : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackKarasinski = Helper.toCell<BlackKarasinski> blackkarasinski "BlackKarasinski" true 
                let builder () = withMnemonic mnemonic ((_BlackKarasinski.cell :?> BlackKarasinskiModel).Dynamics
                                                       ) :> ICell
                let format (o : OneFactorModel.ShortRateDynamics) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BlackKarasinski.source + ".Dynamics") 
                                               [| _BlackKarasinski.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackKarasinski.cell
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
    [<ExcelFunction(Name="_BlackKarasinski_termStructure", Description="Create a BlackKarasinski",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackKarasinski_termStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackKarasinski",Description = "Reference to BlackKarasinski")>] 
         blackkarasinski : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackKarasinski = Helper.toCell<BlackKarasinski> blackkarasinski "BlackKarasinski" true 
                let builder () = withMnemonic mnemonic ((_BlackKarasinski.cell :?> BlackKarasinskiModel).TermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_BlackKarasinski.source + ".TermStructure") 
                                               [| _BlackKarasinski.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackKarasinski.cell
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
    [<ExcelFunction(Name="_BlackKarasinski_termStructure_", Description="Create a BlackKarasinski",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackKarasinski_termStructure_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackKarasinski",Description = "Reference to BlackKarasinski")>] 
         blackkarasinski : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackKarasinski = Helper.toCell<BlackKarasinski> blackkarasinski "BlackKarasinski" true 
                let builder () = withMnemonic mnemonic ((_BlackKarasinski.cell :?> BlackKarasinskiModel).TermStructure_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_BlackKarasinski.source + ".TermStructure_") 
                                               [| _BlackKarasinski.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackKarasinski.cell
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
    [<ExcelFunction(Name="_BlackKarasinski_tree", Description="Create a BlackKarasinski",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackKarasinski_tree
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackKarasinski",Description = "Reference to BlackKarasinski")>] 
         blackkarasinski : obj)
        ([<ExcelArgument(Name="grid",Description = "Reference to grid")>] 
         grid : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackKarasinski = Helper.toCell<BlackKarasinski> blackkarasinski "BlackKarasinski" true 
                let _grid = Helper.toCell<TimeGrid> grid "grid" true
                let builder () = withMnemonic mnemonic ((_BlackKarasinski.cell :?> BlackKarasinskiModel).Tree
                                                            _grid.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Lattice>) l

                let source = Helper.sourceFold (_BlackKarasinski.source + ".Tree") 
                                               [| _BlackKarasinski.source
                                               ;  _grid.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackKarasinski.cell
                                ;  _grid.cell
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
        ! An additional constraint can be passed which must be satisfied in addition to the constraints of the model.
    *)
    [<ExcelFunction(Name="_BlackKarasinski_calibrate", Description="Create a BlackKarasinski",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackKarasinski_calibrate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackKarasinski",Description = "Reference to BlackKarasinski")>] 
         blackkarasinski : obj)
        ([<ExcelArgument(Name="instruments",Description = "Reference to instruments")>] 
         instruments : obj)
        ([<ExcelArgument(Name="Method",Description = "Reference to Method")>] 
         Method : obj)
        ([<ExcelArgument(Name="endCriteria",Description = "Reference to endCriteria")>] 
         endCriteria : obj)
        ([<ExcelArgument(Name="additionalConstraint",Description = "Reference to additionalConstraint")>] 
         additionalConstraint : obj)
        ([<ExcelArgument(Name="weights",Description = "Reference to weights")>] 
         weights : obj)
        ([<ExcelArgument(Name="fixParameters",Description = "Reference to fixParameters")>] 
         fixParameters : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackKarasinski = Helper.toCell<BlackKarasinski> blackkarasinski "BlackKarasinski" true 
                let _instruments = Helper.toCell<Generic.List<CalibrationHelper>> instruments "instruments" true
                let _Method = Helper.toCell<OptimizationMethod> Method "Method" true
                let _endCriteria = Helper.toCell<EndCriteria> endCriteria "endCriteria" true
                let _additionalConstraint = Helper.toCell<Constraint> additionalConstraint "additionalConstraint" true
                let _weights = Helper.toCell<Generic.List<double>> weights "weights" true
                let _fixParameters = Helper.toCell<Generic.List<bool>> fixParameters "fixParameters" true
                let builder () = withMnemonic mnemonic ((_BlackKarasinski.cell :?> BlackKarasinskiModel).Calibrate
                                                            _instruments.cell 
                                                            _Method.cell 
                                                            _endCriteria.cell 
                                                            _additionalConstraint.cell 
                                                            _weights.cell 
                                                            _fixParameters.cell 
                                                       ) :> ICell
                let format (o : BlackKarasinski) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BlackKarasinski.source + ".Calibrate") 
                                               [| _BlackKarasinski.source
                                               ;  _instruments.source
                                               ;  _Method.source
                                               ;  _endCriteria.source
                                               ;  _additionalConstraint.source
                                               ;  _weights.source
                                               ;  _fixParameters.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackKarasinski.cell
                                ;  _instruments.cell
                                ;  _Method.cell
                                ;  _endCriteria.cell
                                ;  _additionalConstraint.cell
                                ;  _weights.cell
                                ;  _fixParameters.cell
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
    [<ExcelFunction(Name="_BlackKarasinski_constraint", Description="Create a BlackKarasinski",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackKarasinski_constraint
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackKarasinski",Description = "Reference to BlackKarasinski")>] 
         blackkarasinski : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackKarasinski = Helper.toCell<BlackKarasinski> blackkarasinski "BlackKarasinski" true 
                let builder () = withMnemonic mnemonic ((_BlackKarasinski.cell :?> BlackKarasinskiModel).Constraint
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Constraint>) l

                let source = Helper.sourceFold (_BlackKarasinski.source + ".CONSTRAINT") 
                                               [| _BlackKarasinski.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackKarasinski.cell
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
    [<ExcelFunction(Name="_BlackKarasinski_endCriteria", Description="Create a BlackKarasinski",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackKarasinski_endCriteria
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackKarasinski",Description = "Reference to BlackKarasinski")>] 
         blackkarasinski : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackKarasinski = Helper.toCell<BlackKarasinski> blackkarasinski "BlackKarasinski" true 
                let builder () = withMnemonic mnemonic ((_BlackKarasinski.cell :?> BlackKarasinskiModel).EndCriteria
                                                       ) :> ICell
                let format (o : EndCriteria.Type) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BlackKarasinski.source + ".EndCriteria") 
                                               [| _BlackKarasinski.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackKarasinski.cell
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
    [<ExcelFunction(Name="_BlackKarasinski_notifyObservers", Description="Create a BlackKarasinski",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackKarasinski_notifyObservers
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackKarasinski",Description = "Reference to BlackKarasinski")>] 
         blackkarasinski : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackKarasinski = Helper.toCell<BlackKarasinski> blackkarasinski "BlackKarasinski" true 
                let builder () = withMnemonic mnemonic ((_BlackKarasinski.cell :?> BlackKarasinskiModel).NotifyObservers
                                                       ) :> ICell
                let format (o : BlackKarasinski) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BlackKarasinski.source + ".NotifyObservers") 
                                               [| _BlackKarasinski.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackKarasinski.cell
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
        ! Returns array of arguments on which calibration is done
    *)
    [<ExcelFunction(Name="_BlackKarasinski_parameters", Description="Create a BlackKarasinski",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackKarasinski_parameters
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackKarasinski",Description = "Reference to BlackKarasinski")>] 
         blackkarasinski : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackKarasinski = Helper.toCell<BlackKarasinski> blackkarasinski "BlackKarasinski" true 
                let builder () = withMnemonic mnemonic ((_BlackKarasinski.cell :?> BlackKarasinskiModel).Parameters
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_BlackKarasinski.source + ".Parameters") 
                                               [| _BlackKarasinski.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackKarasinski.cell
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
    [<ExcelFunction(Name="_BlackKarasinski_registerWith", Description="Create a BlackKarasinski",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackKarasinski_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackKarasinski",Description = "Reference to BlackKarasinski")>] 
         blackkarasinski : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackKarasinski = Helper.toCell<BlackKarasinski> blackkarasinski "BlackKarasinski" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_BlackKarasinski.cell :?> BlackKarasinskiModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : BlackKarasinski) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BlackKarasinski.source + ".RegisterWith") 
                                               [| _BlackKarasinski.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackKarasinski.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_BlackKarasinski_setParams", Description="Create a BlackKarasinski",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackKarasinski_setParams
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackKarasinski",Description = "Reference to BlackKarasinski")>] 
         blackkarasinski : obj)
        ([<ExcelArgument(Name="parameters",Description = "Reference to parameters")>] 
         parameters : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackKarasinski = Helper.toCell<BlackKarasinski> blackkarasinski "BlackKarasinski" true 
                let _parameters = Helper.toCell<Vector> parameters "parameters" true
                let builder () = withMnemonic mnemonic ((_BlackKarasinski.cell :?> BlackKarasinskiModel).SetParams
                                                            _parameters.cell 
                                                       ) :> ICell
                let format (o : BlackKarasinski) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BlackKarasinski.source + ".SetParams") 
                                               [| _BlackKarasinski.source
                                               ;  _parameters.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackKarasinski.cell
                                ;  _parameters.cell
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
    [<ExcelFunction(Name="_BlackKarasinski_unregisterWith", Description="Create a BlackKarasinski",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackKarasinski_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackKarasinski",Description = "Reference to BlackKarasinski")>] 
         blackkarasinski : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackKarasinski = Helper.toCell<BlackKarasinski> blackkarasinski "BlackKarasinski" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_BlackKarasinski.cell :?> BlackKarasinskiModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : BlackKarasinski) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BlackKarasinski.source + ".UnregisterWith") 
                                               [| _BlackKarasinski.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackKarasinski.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_BlackKarasinski_update", Description="Create a BlackKarasinski",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackKarasinski_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackKarasinski",Description = "Reference to BlackKarasinski")>] 
         blackkarasinski : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackKarasinski = Helper.toCell<BlackKarasinski> blackkarasinski "BlackKarasinski" true 
                let builder () = withMnemonic mnemonic ((_BlackKarasinski.cell :?> BlackKarasinskiModel).Update
                                                       ) :> ICell
                let format (o : BlackKarasinski) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BlackKarasinski.source + ".Update") 
                                               [| _BlackKarasinski.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackKarasinski.cell
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
    [<ExcelFunction(Name="_BlackKarasinski_value", Description="Create a BlackKarasinski",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackKarasinski_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackKarasinski",Description = "Reference to BlackKarasinski")>] 
         blackkarasinski : obj)
        ([<ExcelArgument(Name="parameters",Description = "Reference to parameters")>] 
         parameters : obj)
        ([<ExcelArgument(Name="instruments",Description = "Reference to instruments")>] 
         instruments : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackKarasinski = Helper.toCell<BlackKarasinski> blackkarasinski "BlackKarasinski" true 
                let _parameters = Helper.toCell<Vector> parameters "parameters" true
                let _instruments = Helper.toCell<Generic.List<CalibrationHelper>> instruments "instruments" true
                let builder () = withMnemonic mnemonic ((_BlackKarasinski.cell :?> BlackKarasinskiModel).Value
                                                            _parameters.cell 
                                                            _instruments.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackKarasinski.source + ".Value") 
                                               [| _BlackKarasinski.source
                                               ;  _parameters.source
                                               ;  _instruments.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackKarasinski.cell
                                ;  _parameters.cell
                                ;  _instruments.cell
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
    [<ExcelFunction(Name="_BlackKarasinski_Range", Description="Create a range of BlackKarasinski",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackKarasinski_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the BlackKarasinski")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BlackKarasinski> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BlackKarasinski>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<BlackKarasinski>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<BlackKarasinski>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"