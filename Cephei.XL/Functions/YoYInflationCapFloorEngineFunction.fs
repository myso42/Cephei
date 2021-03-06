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
  This class doesn't know yet what sort of vol it is.  The inflation index must be linked to a yoy inflation term structure.  This provides the curves, hence the call uses a shared_ptr<> not a handle<> to the index.  inflationcapfloorengines
  </summary> *)
[<AutoSerializable(true)>]
module YoYInflationCapFloorEngineFunction =


    (*
        
    *)
    [<ExcelFunction(Name="_YoYInflationCapFloorEngine_index", Description="Create a YoYInflationCapFloorEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCapFloorEngine_index
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCapFloorEngine",Description = "YoYInflationCapFloorEngine")>] 
         yoyinflationcapfloorengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCapFloorEngine = Helper.toModelReference<YoYInflationCapFloorEngine> yoyinflationcapfloorengine "YoYInflationCapFloorEngine"  
                let builder (current : ICell) = ((YoYInflationCapFloorEngineModel.Cast _YoYInflationCapFloorEngine.cell).Index
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YoYInflationIndex>) l

                let source () = Helper.sourceFold (_YoYInflationCapFloorEngine.source + ".Index") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YoYInflationCapFloorEngine.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YoYInflationCapFloorEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YoYInflationCapFloorEngine_setVolatility", Description="Create a YoYInflationCapFloorEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCapFloorEngine_setVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCapFloorEngine",Description = "YoYInflationCapFloorEngine")>] 
         yoyinflationcapfloorengine : obj)
        ([<ExcelArgument(Name="vol",Description = "YoYOptionletVolatilitySurface")>] 
         vol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCapFloorEngine = Helper.toModelReference<YoYInflationCapFloorEngine> yoyinflationcapfloorengine "YoYInflationCapFloorEngine"  
                let _vol = Helper.toHandle<YoYOptionletVolatilitySurface> vol "vol" 
                let builder (current : ICell) = ((YoYInflationCapFloorEngineModel.Cast _YoYInflationCapFloorEngine.cell).SetVolatility
                                                            _vol.cell 
                                                       ) :> ICell
                let format (o : YoYInflationCapFloorEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YoYInflationCapFloorEngine.source + ".SetVolatility") 

                                               [| _vol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCapFloorEngine.cell
                                ;  _vol.cell
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
    [<ExcelFunction(Name="_YoYInflationCapFloorEngine_volatility", Description="Create a YoYInflationCapFloorEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCapFloorEngine_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCapFloorEngine",Description = "YoYInflationCapFloorEngine")>] 
         yoyinflationcapfloorengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCapFloorEngine = Helper.toModelReference<YoYInflationCapFloorEngine> yoyinflationcapfloorengine "YoYInflationCapFloorEngine"  
                let builder (current : ICell) = ((YoYInflationCapFloorEngineModel.Cast _YoYInflationCapFloorEngine.cell).Volatility
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YoYOptionletVolatilitySurface>>) l

                let source () = Helper.sourceFold (_YoYInflationCapFloorEngine.source + ".Volatility") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YoYInflationCapFloorEngine.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YoYInflationCapFloorEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YoYInflationCapFloorEngine", Description="Create a YoYInflationCapFloorEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCapFloorEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="index",Description = "YoYInflationIndex")>] 
         index : obj)
        ([<ExcelArgument(Name="vol",Description = "YoYOptionletVolatilitySurface")>] 
         vol : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _index = Helper.toCell<YoYInflationIndex> index "index" 
                let _vol = Helper.toHandle<YoYOptionletVolatilitySurface> vol "vol" 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = (Fun.YoYInflationCapFloorEngine 
                                                            _index.cell 
                                                            _vol.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YoYInflationCapFloorEngine>) l

                let source () = Helper.sourceFold "Fun.YoYInflationCapFloorEngine" 
                                               [| _index.source
                                               ;  _vol.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _index.cell
                                ;  _vol.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YoYInflationCapFloorEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_YoYInflationCapFloorEngine_Range", Description="Create a range of YoYInflationCapFloorEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCapFloorEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<YoYInflationCapFloorEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<YoYInflationCapFloorEngine> (c)) :> ICell
                let format (i : Cephei.Cell.List<YoYInflationCapFloorEngine>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<YoYInflationCapFloorEngine>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
