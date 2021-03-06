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
module VasicekFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Vasicek_a", Description="Create a Vasicek",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Vasicek_a
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Vasicek",Description = "Vasicek")>] 
         vasicek : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Vasicek = Helper.toModelReference<Vasicek> vasicek "Vasicek"  
                let builder (current : ICell) = ((VasicekModel.Cast _Vasicek.cell).A
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Vasicek.source + ".A") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Vasicek.cell
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
    [<ExcelFunction(Name="_Vasicek_b", Description="Create a Vasicek",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Vasicek_b
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Vasicek",Description = "Vasicek")>] 
         vasicek : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Vasicek = Helper.toModelReference<Vasicek> vasicek "Vasicek"  
                let builder (current : ICell) = ((VasicekModel.Cast _Vasicek.cell).B
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Vasicek.source + ".B") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Vasicek.cell
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
    [<ExcelFunction(Name="_Vasicek_discountBondOption", Description="Create a Vasicek",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Vasicek_discountBondOption
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Vasicek",Description = "Vasicek")>] 
         vasicek : obj)
        ([<ExcelArgument(Name="Type",Description = "Option.Type: Put, Call")>] 
         Type : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="maturity",Description = "double")>] 
         maturity : obj)
        ([<ExcelArgument(Name="bondMaturity",Description = "double")>] 
         bondMaturity : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Vasicek = Helper.toModelReference<Vasicek> vasicek "Vasicek"  
                let _Type = Helper.toCell<Option.Type> Type "Type" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _maturity = Helper.toCell<double> maturity "maturity" 
                let _bondMaturity = Helper.toCell<double> bondMaturity "bondMaturity" 
                let builder (current : ICell) = ((VasicekModel.Cast _Vasicek.cell).DiscountBondOption
                                                            _Type.cell 
                                                            _strike.cell 
                                                            _maturity.cell 
                                                            _bondMaturity.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Vasicek.source + ".DiscountBondOption") 

                                               [| _Type.source
                                               ;  _strike.source
                                               ;  _maturity.source
                                               ;  _bondMaturity.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Vasicek.cell
                                ;  _Type.cell
                                ;  _strike.cell
                                ;  _maturity.cell
                                ;  _bondMaturity.cell
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
    [<ExcelFunction(Name="_Vasicek_dynamics", Description="Create a Vasicek",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Vasicek_dynamics
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Vasicek",Description = "Vasicek")>] 
         vasicek : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Vasicek = Helper.toModelReference<Vasicek> vasicek "Vasicek"  
                let builder (current : ICell) = ((VasicekModel.Cast _Vasicek.cell).Dynamics
                                                       ) :> ICell
                let format (o : OneFactorModel.ShortRateDynamics) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Vasicek.source + ".Dynamics") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Vasicek.cell
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
    [<ExcelFunction(Name="_Vasicek_lambda", Description="Create a Vasicek",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Vasicek_lambda
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Vasicek",Description = "Vasicek")>] 
         vasicek : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Vasicek = Helper.toModelReference<Vasicek> vasicek "Vasicek"  
                let builder (current : ICell) = ((VasicekModel.Cast _Vasicek.cell).Lambda
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Vasicek.source + ".Lambda") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Vasicek.cell
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
    [<ExcelFunction(Name="_Vasicek_sigma", Description="Create a Vasicek",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Vasicek_sigma
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Vasicek",Description = "Vasicek")>] 
         vasicek : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Vasicek = Helper.toModelReference<Vasicek> vasicek "Vasicek"  
                let builder (current : ICell) = ((VasicekModel.Cast _Vasicek.cell).Sigma
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Vasicek.source + ".Sigma") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Vasicek.cell
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
    [<ExcelFunction(Name="_Vasicek", Description="Create a Vasicek",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Vasicek_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="r0",Description = "double")>] 
         r0 : obj)
        ([<ExcelArgument(Name="a",Description = "double")>] 
         a : obj)
        ([<ExcelArgument(Name="b",Description = "double or empty")>] 
         b : obj)
        ([<ExcelArgument(Name="sigma",Description = "double or empty")>] 
         sigma : obj)
        ([<ExcelArgument(Name="lambda",Description = "double or empty")>] 
         lambda : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _r0 = Helper.toCell<double> r0 "r0" 
                let _a = Helper.toCell<double> a "a" 
                let _b = Helper.toDefault<double> b "b" 0.05
                let _sigma = Helper.toDefault<double> sigma "sigma" 0.01
                let _lambda = Helper.toDefault<double> lambda "lambda" 0.0
                let builder (current : ICell) = (Fun.Vasicek 
                                                            _r0.cell 
                                                            _a.cell 
                                                            _b.cell 
                                                            _sigma.cell 
                                                            _lambda.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vasicek>) l

                let source () = Helper.sourceFold "Fun.Vasicek" 
                                               [| _r0.source
                                               ;  _a.source
                                               ;  _b.source
                                               ;  _sigma.source
                                               ;  _lambda.source
                                               |]
                let hash = Helper.hashFold 
                                [| _r0.cell
                                ;  _a.cell
                                ;  _b.cell
                                ;  _sigma.cell
                                ;  _lambda.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Vasicek> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Vasicek_discount", Description="Create a Vasicek",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Vasicek_discount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Vasicek",Description = "Vasicek")>] 
         vasicek : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Vasicek = Helper.toModelReference<Vasicek> vasicek "Vasicek"  
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = ((VasicekModel.Cast _Vasicek.cell).Discount
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Vasicek.source + ".Discount") 

                                               [| _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Vasicek.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_Vasicek_discountBond1", Description="Create a Vasicek",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Vasicek_discountBond1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Vasicek",Description = "Vasicek")>] 
         vasicek : obj)
        ([<ExcelArgument(Name="now",Description = "double")>] 
         now : obj)
        ([<ExcelArgument(Name="maturity",Description = "double")>] 
         maturity : obj)
        ([<ExcelArgument(Name="rate",Description = "double")>] 
         rate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Vasicek = Helper.toModelReference<Vasicek> vasicek "Vasicek"  
                let _now = Helper.toCell<double> now "now" 
                let _maturity = Helper.toCell<double> maturity "maturity" 
                let _rate = Helper.toCell<double> rate "rate" 
                let builder (current : ICell) = ((VasicekModel.Cast _Vasicek.cell).DiscountBond1
                                                            _now.cell 
                                                            _maturity.cell 
                                                            _rate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Vasicek.source + ".DiscountBond1") 

                                               [| _now.source
                                               ;  _maturity.source
                                               ;  _rate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Vasicek.cell
                                ;  _now.cell
                                ;  _maturity.cell
                                ;  _rate.cell
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
    [<ExcelFunction(Name="_Vasicek_discountBond", Description="Create a Vasicek",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Vasicek_discountBond
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Vasicek",Description = "Vasicek")>] 
         vasicek : obj)
        ([<ExcelArgument(Name="now",Description = "double")>] 
         now : obj)
        ([<ExcelArgument(Name="maturity",Description = "double")>] 
         maturity : obj)
        ([<ExcelArgument(Name="factors",Description = "Vector")>] 
         factors : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Vasicek = Helper.toModelReference<Vasicek> vasicek "Vasicek"  
                let _now = Helper.toCell<double> now "now" 
                let _maturity = Helper.toCell<double> maturity "maturity" 
                let _factors = Helper.toCell<Vector> factors "factors" 
                let builder (current : ICell) = ((VasicekModel.Cast _Vasicek.cell).DiscountBond
                                                            _now.cell 
                                                            _maturity.cell 
                                                            _factors.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Vasicek.source + ".DiscountBond") 

                                               [| _now.source
                                               ;  _maturity.source
                                               ;  _factors.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Vasicek.cell
                                ;  _now.cell
                                ;  _maturity.cell
                                ;  _factors.cell
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
        ! Return by default a trinomial recombining tree
    *)
    [<ExcelFunction(Name="_Vasicek_tree", Description="Create a Vasicek",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Vasicek_tree
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Vasicek",Description = "Vasicek")>] 
         vasicek : obj)
        ([<ExcelArgument(Name="grid",Description = "TimeGrid")>] 
         grid : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Vasicek = Helper.toModelReference<Vasicek> vasicek "Vasicek"  
                let _grid = Helper.toCell<TimeGrid> grid "grid" 
                let builder (current : ICell) = ((VasicekModel.Cast _Vasicek.cell).Tree
                                                            _grid.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Lattice>) l

                let source () = Helper.sourceFold (_Vasicek.source + ".Tree") 

                                               [| _grid.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Vasicek.cell
                                ;  _grid.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Vasicek> format
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
    [<ExcelFunction(Name="_Vasicek_calibrate", Description="Create a Vasicek",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Vasicek_calibrate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Vasicek",Description = "Vasicek")>] 
         vasicek : obj)
        ([<ExcelArgument(Name="instruments",Description = "CalibrationHelper range")>] 
         instruments : obj)
        ([<ExcelArgument(Name="Method",Description = "OptimizationMethod")>] 
         Method : obj)
        ([<ExcelArgument(Name="endCriteria",Description = "EndCriteria")>] 
         endCriteria : obj)
        ([<ExcelArgument(Name="additionalConstraint",Description = "Constraint")>] 
         additionalConstraint : obj)
        ([<ExcelArgument(Name="weights",Description = "double range")>] 
         weights : obj)
        ([<ExcelArgument(Name="fixParameters",Description = "bool range")>] 
         fixParameters : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Vasicek = Helper.toModelReference<Vasicek> vasicek "Vasicek"  
                let _instruments = Helper.toCell<Generic.List<CalibrationHelper>> instruments "instruments" 
                let _Method = Helper.toCell<OptimizationMethod> Method "Method" 
                let _endCriteria = Helper.toCell<EndCriteria> endCriteria "endCriteria" 
                let _additionalConstraint = Helper.toCell<Constraint> additionalConstraint "additionalConstraint" 
                let _weights = Helper.toCell<Generic.List<double>> weights "weights" 
                let _fixParameters = Helper.toCell<Generic.List<bool>> fixParameters "fixParameters" 
                let builder (current : ICell) = ((VasicekModel.Cast _Vasicek.cell).Calibrate
                                                            _instruments.cell 
                                                            _Method.cell 
                                                            _endCriteria.cell 
                                                            _additionalConstraint.cell 
                                                            _weights.cell 
                                                            _fixParameters.cell 
                                                       ) :> ICell
                let format (o : Vasicek) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Vasicek.source + ".Calibrate") 

                                               [| _instruments.source
                                               ;  _Method.source
                                               ;  _endCriteria.source
                                               ;  _additionalConstraint.source
                                               ;  _weights.source
                                               ;  _fixParameters.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Vasicek.cell
                                ;  _instruments.cell
                                ;  _Method.cell
                                ;  _endCriteria.cell
                                ;  _additionalConstraint.cell
                                ;  _weights.cell
                                ;  _fixParameters.cell
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
    [<ExcelFunction(Name="_Vasicek_constraint", Description="Create a Vasicek",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Vasicek_constraint
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Vasicek",Description = "Vasicek")>] 
         vasicek : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Vasicek = Helper.toModelReference<Vasicek> vasicek "Vasicek"  
                let builder (current : ICell) = ((VasicekModel.Cast _Vasicek.cell).Constraint
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Constraint>) l

                let source () = Helper.sourceFold (_Vasicek.source + ".CONSTRAINT") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Vasicek.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Vasicek> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Vasicek_endCriteria", Description="Create a Vasicek",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Vasicek_endCriteria
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Vasicek",Description = "Vasicek")>] 
         vasicek : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Vasicek = Helper.toModelReference<Vasicek> vasicek "Vasicek"  
                let builder (current : ICell) = ((VasicekModel.Cast _Vasicek.cell).EndCriteria
                                                       ) :> ICell
                let format (o : EndCriteria.Type) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Vasicek.source + ".EndCriteria") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Vasicek.cell
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
    [<ExcelFunction(Name="_Vasicek_notifyObservers", Description="Create a Vasicek",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Vasicek_notifyObservers
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Vasicek",Description = "Vasicek")>] 
         vasicek : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Vasicek = Helper.toModelReference<Vasicek> vasicek "Vasicek"  
                let builder (current : ICell) = ((VasicekModel.Cast _Vasicek.cell).NotifyObservers
                                                       ) :> ICell
                let format (o : Vasicek) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Vasicek.source + ".NotifyObservers") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Vasicek.cell
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
        ! Returns array of arguments on which calibration is done
    *)
    [<ExcelFunction(Name="_Vasicek_parameters", Description="Create a Vasicek",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Vasicek_parameters
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Vasicek",Description = "Vasicek")>] 
         vasicek : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Vasicek = Helper.toModelReference<Vasicek> vasicek "Vasicek"  
                let builder (current : ICell) = ((VasicekModel.Cast _Vasicek.cell).Parameters
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_Vasicek.source + ".Parameters") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Vasicek.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Vasicek> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Vasicek_registerWith", Description="Create a Vasicek",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Vasicek_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Vasicek",Description = "Vasicek")>] 
         vasicek : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Vasicek = Helper.toModelReference<Vasicek> vasicek "Vasicek"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((VasicekModel.Cast _Vasicek.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : Vasicek) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Vasicek.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Vasicek.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_Vasicek_setParams", Description="Create a Vasicek",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Vasicek_setParams
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Vasicek",Description = "Vasicek")>] 
         vasicek : obj)
        ([<ExcelArgument(Name="parameters",Description = "Vector")>] 
         parameters : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Vasicek = Helper.toModelReference<Vasicek> vasicek "Vasicek"  
                let _parameters = Helper.toCell<Vector> parameters "parameters" 
                let builder (current : ICell) = ((VasicekModel.Cast _Vasicek.cell).SetParams
                                                            _parameters.cell 
                                                       ) :> ICell
                let format (o : Vasicek) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Vasicek.source + ".SetParams") 

                                               [| _parameters.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Vasicek.cell
                                ;  _parameters.cell
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
    [<ExcelFunction(Name="_Vasicek_unregisterWith", Description="Create a Vasicek",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Vasicek_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Vasicek",Description = "Vasicek")>] 
         vasicek : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Vasicek = Helper.toModelReference<Vasicek> vasicek "Vasicek"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((VasicekModel.Cast _Vasicek.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : Vasicek) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Vasicek.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Vasicek.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_Vasicek_update", Description="Create a Vasicek",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Vasicek_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Vasicek",Description = "Vasicek")>] 
         vasicek : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Vasicek = Helper.toModelReference<Vasicek> vasicek "Vasicek"  
                let builder (current : ICell) = ((VasicekModel.Cast _Vasicek.cell).Update
                                                       ) :> ICell
                let format (o : Vasicek) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Vasicek.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Vasicek.cell
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
    [<ExcelFunction(Name="_Vasicek_value", Description="Create a Vasicek",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Vasicek_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Vasicek",Description = "Vasicek")>] 
         vasicek : obj)
        ([<ExcelArgument(Name="parameters",Description = "Vector")>] 
         parameters : obj)
        ([<ExcelArgument(Name="instruments",Description = "CalibrationHelper range")>] 
         instruments : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Vasicek = Helper.toModelReference<Vasicek> vasicek "Vasicek"  
                let _parameters = Helper.toCell<Vector> parameters "parameters" 
                let _instruments = Helper.toCell<Generic.List<CalibrationHelper>> instruments "instruments" 
                let builder (current : ICell) = ((VasicekModel.Cast _Vasicek.cell).Value
                                                            _parameters.cell 
                                                            _instruments.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Vasicek.source + ".Value") 

                                               [| _parameters.source
                                               ;  _instruments.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Vasicek.cell
                                ;  _parameters.cell
                                ;  _instruments.cell
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
    [<ExcelFunction(Name="_Vasicek_Range", Description="Create a range of Vasicek",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Vasicek_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Vasicek> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<Vasicek> (c)) :> ICell
                let format (i : Cephei.Cell.List<Vasicek>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<Vasicek>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
