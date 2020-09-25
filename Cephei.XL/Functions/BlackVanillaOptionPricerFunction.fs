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
===========================================================================// BlackVanillaOptionPricer                         // ===========================================================================
  </summary> *)
[<AutoSerializable(true)>]
module BlackVanillaOptionPricerFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BlackVanillaOptionPricer", Description="Create a BlackVanillaOptionPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackVanillaOptionPricer_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="forwardValue",Description = "Reference to forwardValue")>] 
         forwardValue : obj)
        ([<ExcelArgument(Name="expiryDate",Description = "Reference to expiryDate")>] 
         expiryDate : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="volatilityStructure",Description = "Reference to volatilityStructure")>] 
         volatilityStructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _forwardValue = Helper.toCell<double> forwardValue "forwardValue" true
                let _expiryDate = Helper.toCell<Date> expiryDate "expiryDate" true
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" true
                let _volatilityStructure = Helper.toCell<SwaptionVolatilityStructure> volatilityStructure "volatilityStructure" true
                let builder () = withMnemonic mnemonic (Fun.BlackVanillaOptionPricer 
                                                            _forwardValue.cell 
                                                            _expiryDate.cell 
                                                            _swapTenor.cell 
                                                            _volatilityStructure.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BlackVanillaOptionPricer>) l

                let source = Helper.sourceFold "Fun.BlackVanillaOptionPricer" 
                                               [| _forwardValue.source
                                               ;  _expiryDate.source
                                               ;  _swapTenor.source
                                               ;  _volatilityStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _forwardValue.cell
                                ;  _expiryDate.cell
                                ;  _swapTenor.cell
                                ;  _volatilityStructure.cell
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
    [<ExcelFunction(Name="_BlackVanillaOptionPricer_value", Description="Create a BlackVanillaOptionPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackVanillaOptionPricer_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackVanillaOptionPricer",Description = "Reference to BlackVanillaOptionPricer")>] 
         blackvanillaoptionpricer : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="optionType",Description = "Reference to optionType")>] 
         optionType : obj)
        ([<ExcelArgument(Name="deflator",Description = "Reference to deflator")>] 
         deflator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackVanillaOptionPricer = Helper.toCell<BlackVanillaOptionPricer> blackvanillaoptionpricer "BlackVanillaOptionPricer" true 
                let _strike = Helper.toCell<double> strike "strike" true
                let _optionType = Helper.toCell<Option.Type> optionType "optionType" true
                let _deflator = Helper.toCell<double> deflator "deflator" true
                let builder () = withMnemonic mnemonic ((_BlackVanillaOptionPricer.cell :?> BlackVanillaOptionPricerModel).Value
                                                            _strike.cell 
                                                            _optionType.cell 
                                                            _deflator.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackVanillaOptionPricer.source + ".Value") 
                                               [| _BlackVanillaOptionPricer.source
                                               ;  _strike.source
                                               ;  _optionType.source
                                               ;  _deflator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackVanillaOptionPricer.cell
                                ;  _strike.cell
                                ;  _optionType.cell
                                ;  _deflator.cell
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
    [<ExcelFunction(Name="_BlackVanillaOptionPricer_Range", Description="Create a range of BlackVanillaOptionPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackVanillaOptionPricer_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the BlackVanillaOptionPricer")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BlackVanillaOptionPricer> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BlackVanillaOptionPricer>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<BlackVanillaOptionPricer>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<BlackVanillaOptionPricer>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"