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
module BlackCapFloorEngineFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BlackCapFloorEngine1", Description="Create a BlackCapFloorEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackCapFloorEngine_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="discountCurve",Description = "YieldTermStructure")>] 
         discountCurve : obj)
        ([<ExcelArgument(Name="vol",Description = "OptionletVolatilityStructure")>] 
         vol : obj)
        ([<ExcelArgument(Name="displacement",Description = "double or empty")>] 
         displacement : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _discountCurve = Helper.toHandle<YieldTermStructure> discountCurve "discountCurve" 
                let _vol = Helper.toHandle<OptionletVolatilityStructure> vol "vol" 
                let _displacement = Helper.toDefault<double> displacement "displacement" 0.0
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = (Fun.BlackCapFloorEngine1 
                                                            _discountCurve.cell 
                                                            _vol.cell 
                                                            _displacement.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BlackCapFloorEngine>) l

                let source () = Helper.sourceFold "Fun.BlackCapFloorEngine1" 
                                               [| _discountCurve.source
                                               ;  _vol.source
                                               ;  _displacement.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _discountCurve.cell
                                ;  _vol.cell
                                ;  _displacement.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackCapFloorEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BlackCapFloorEngine2", Description="Create a BlackCapFloorEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackCapFloorEngine_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="discountCurve",Description = "YieldTermStructure")>] 
         discountCurve : obj)
        ([<ExcelArgument(Name="vol",Description = "Quote")>] 
         vol : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter or empty")>] 
         dc : obj)
        ([<ExcelArgument(Name="displacement",Description = "double or empty")>] 
         displacement : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _discountCurve = Helper.toHandle<YieldTermStructure> discountCurve "discountCurve" 
                let _vol = Helper.toHandle<Quote> vol "vol" 
                let _dc = Helper.toDefault<DayCounter> dc "dc" null
                let _displacement = Helper.toDefault<double> displacement "displacement" 0.0
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = (Fun.BlackCapFloorEngine2
                                                            _discountCurve.cell 
                                                            _vol.cell 
                                                            _dc.cell 
                                                            _displacement.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BlackCapFloorEngine>) l

                let source () = Helper.sourceFold "Fun.BlackCapFloorEngine2" 
                                               [| _discountCurve.source
                                               ;  _vol.source
                                               ;  _dc.source
                                               ;  _displacement.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _discountCurve.cell
                                ;  _vol.cell
                                ;  _dc.cell
                                ;  _displacement.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackCapFloorEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BlackCapFloorEngine", Description="Create a BlackCapFloorEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackCapFloorEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="discountCurve",Description = "YieldTermStructure")>] 
         discountCurve : obj)
        ([<ExcelArgument(Name="vol",Description = "double")>] 
         vol : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter or empty")>] 
         dc : obj)
        ([<ExcelArgument(Name="displacement",Description = "double or empty")>] 
         displacement : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _discountCurve = Helper.toHandle<YieldTermStructure> discountCurve "discountCurve" 
                let _vol = Helper.toCell<double> vol "vol" 
                let _dc = Helper.toDefault<DayCounter> dc "dc" null
                let _displacement = Helper.toDefault<double> displacement "displacement" 0.0
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = (Fun.BlackCapFloorEngine
                                                            _discountCurve.cell 
                                                            _vol.cell 
                                                            _dc.cell 
                                                            _displacement.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BlackCapFloorEngine>) l

                let source () = Helper.sourceFold "Fun.BlackCapFloorEngine" 
                                               [| _discountCurve.source
                                               ;  _vol.source
                                               ;  _dc.source
                                               ;  _displacement.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _discountCurve.cell
                                ;  _vol.cell
                                ;  _dc.cell
                                ;  _displacement.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackCapFloorEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"

    (*
        
    *)
    [<ExcelFunction(Name="_BlackCapFloorEngine_displacement", Description="Create a BlackCapFloorEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackCapFloorEngine_displacement
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackCapFloorEngine",Description = "BlackCapFloorEngine")>] 
         blackcapfloorengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackCapFloorEngine = Helper.toModelReference<BlackCapFloorEngine> blackcapfloorengine "BlackCapFloorEngine"  
                let builder (current : ICell) = ((BlackCapFloorEngineModel.Cast _BlackCapFloorEngine.cell).Displacement
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackCapFloorEngine.source + ".Displacement") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BlackCapFloorEngine.cell
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
    [<ExcelFunction(Name="_BlackCapFloorEngine_termStructure", Description="Create a BlackCapFloorEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackCapFloorEngine_termStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackCapFloorEngine",Description = "BlackCapFloorEngine")>] 
         blackcapfloorengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackCapFloorEngine = Helper.toModelReference<BlackCapFloorEngine> blackcapfloorengine "BlackCapFloorEngine"  
                let builder (current : ICell) = ((BlackCapFloorEngineModel.Cast _BlackCapFloorEngine.cell).TermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_BlackCapFloorEngine.source + ".TermStructure") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BlackCapFloorEngine.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackCapFloorEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BlackCapFloorEngine_volatility", Description="Create a BlackCapFloorEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackCapFloorEngine_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackCapFloorEngine",Description = "BlackCapFloorEngine")>] 
         blackcapfloorengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackCapFloorEngine = Helper.toModelReference<BlackCapFloorEngine> blackcapfloorengine "BlackCapFloorEngine"  
                let builder (current : ICell) = ((BlackCapFloorEngineModel.Cast _BlackCapFloorEngine.cell).Volatility
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<OptionletVolatilityStructure>>) l

                let source () = Helper.sourceFold (_BlackCapFloorEngine.source + ".Volatility") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BlackCapFloorEngine.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackCapFloorEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_BlackCapFloorEngine_Range", Description="Create a range of BlackCapFloorEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackCapFloorEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BlackCapFloorEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<BlackCapFloorEngine> (c)) :> ICell
                let format (i : Cephei.Cell.List<BlackCapFloorEngine>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<BlackCapFloorEngine>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
