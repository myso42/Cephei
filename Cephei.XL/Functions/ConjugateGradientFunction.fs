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
  Fletcher-Reeves-Polak-Ribiere algorithm adapted from Numerical Recipes in C, 2nd edition.  User has to provide line-search method and optimization end criteria.  This optimization method requires the knowledge of the gradient of the cost function.  optimizers
  </summary> *)
[<AutoSerializable(true)>]
module ConjugateGradientFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ConjugateGradient", Description="Create a ConjugateGradient",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConjugateGradient_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="lineSearch",Description = "LineSearch or empty")>] 
         lineSearch : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _lineSearch = Helper.toDefault<LineSearch> lineSearch "lineSearch" null
                let builder (current : ICell) = (Fun.ConjugateGradient 
                                                            _lineSearch.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ConjugateGradient>) l

                let source () = Helper.sourceFold "Fun.ConjugateGradient" 
                                               [| _lineSearch.source
                                               |]
                let hash = Helper.hashFold 
                                [| _lineSearch.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConjugateGradient> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ConjugateGradient_minimize", Description="Create a ConjugateGradient",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConjugateGradient_minimize
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConjugateGradient",Description = "ConjugateGradient")>] 
         conjugategradient : obj)
        ([<ExcelArgument(Name="P",Description = "Problem")>] 
         P : obj)
        ([<ExcelArgument(Name="endCriteria",Description = "EndCriteria")>] 
         endCriteria : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConjugateGradient = Helper.toModelReference<ConjugateGradient> conjugategradient "ConjugateGradient"  
                let _P = Helper.toCell<Problem> P "P" 
                let _endCriteria = Helper.toCell<EndCriteria> endCriteria "endCriteria" 
                let builder (current : ICell) = ((ConjugateGradientModel.Cast _ConjugateGradient.cell).Minimize
                                                            _P.cell 
                                                            _endCriteria.cell 
                                                       ) :> ICell
                let format (o : EndCriteria.Type) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ConjugateGradient.source + ".Minimize") 

                                               [| _P.source
                                               ;  _endCriteria.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConjugateGradient.cell
                                ;  _P.cell
                                ;  _endCriteria.cell
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
    [<ExcelFunction(Name="_ConjugateGradient_Range", Description="Create a range of ConjugateGradient",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConjugateGradient_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ConjugateGradient> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<ConjugateGradient> (c)) :> ICell
                let format (i : Cephei.Cell.List<ConjugateGradient>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<ConjugateGradient>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
