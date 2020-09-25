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
  TRY LIBOR fixed by TBA.  See <http://www.trlibor.org/trlibor/english/>  check end-of-month adjustment.
  </summary> *)
[<AutoSerializable(true)>]
module TRLiborFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_TRLibor1", Description="Create a TRLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TRLibor_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _tenor = Helper.toCell<Period> tenor "tenor" true
                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let builder () = withMnemonic mnemonic (Fun.TRLibor1 
                                                            _tenor.cell 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TRLibor>) l

                let source = Helper.sourceFold "Fun.TRLibo1r" 
                                               [| _tenor.source
                                               ;  _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _tenor.cell
                                ;  _h.cell
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
    [<ExcelFunction(Name="_TRLibor", Description="Create a TRLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TRLibor_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _tenor = Helper.toCell<Period> tenor "tenor" true
                let builder () = withMnemonic mnemonic (Fun.TRLibor
                                                            _tenor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TRLibor>) l

                let source = Helper.sourceFold "Fun.TRLibor" 
                                               [| _tenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _tenor.cell
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
        Inspectors
    *)
    [<ExcelFunction(Name="_TRLibor_businessDayConvention", Description="Create a TRLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TRLibor_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TRLibor",Description = "Reference to TRLibor")>] 
         trlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TRLibor = Helper.toCell<TRLibor> trlibor "TRLibor" true 
                let builder () = withMnemonic mnemonic ((_TRLibor.cell :?> TRLiborModel).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TRLibor.source + ".BusinessDayConvention") 
                                               [| _TRLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TRLibor.cell
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
        Other methods returns a copy of itself linked to a different forwarding curve
    *)
    [<ExcelFunction(Name="_TRLibor_clone", Description="Create a TRLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TRLibor_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TRLibor",Description = "Reference to TRLibor")>] 
         trlibor : obj)
        ([<ExcelArgument(Name="forwarding",Description = "Reference to forwarding")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TRLibor = Helper.toCell<TRLibor> trlibor "TRLibor" true 
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let builder () = withMnemonic mnemonic ((_TRLibor.cell :?> TRLiborModel).Clone
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source = Helper.sourceFold (_TRLibor.source + ".Clone") 
                                               [| _TRLibor.source
                                               ;  _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TRLibor.cell
                                ;  _forwarding.cell
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
    [<ExcelFunction(Name="_TRLibor_endOfMonth", Description="Create a TRLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TRLibor_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TRLibor",Description = "Reference to TRLibor")>] 
         trlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TRLibor = Helper.toCell<TRLibor> trlibor "TRLibor" true 
                let builder () = withMnemonic mnemonic ((_TRLibor.cell :?> TRLiborModel).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TRLibor.source + ".EndOfMonth") 
                                               [| _TRLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TRLibor.cell
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
    [<ExcelFunction(Name="_TRLibor_forecastFixing1", Description="Create a TRLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TRLibor_forecastFixing1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TRLibor",Description = "Reference to TRLibor")>] 
         trlibor : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TRLibor = Helper.toCell<TRLibor> trlibor "TRLibor" true 
                let _d1 = Helper.toCell<Date> d1 "d1" true
                let _d2 = Helper.toCell<Date> d2 "d2" true
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_TRLibor.cell :?> TRLiborModel).ForecastFixing1
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_TRLibor.source + ".ForecastFixing1") 
                                               [| _TRLibor.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TRLibor.cell
                                ;  _d1.cell
                                ;  _d2.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_TRLibor_forecastFixing", Description="Create a TRLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TRLibor_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TRLibor",Description = "Reference to TRLibor")>] 
         trlibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TRLibor = Helper.toCell<TRLibor> trlibor "TRLibor" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_TRLibor.cell :?> TRLiborModel).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_TRLibor.source + ".ForecastFixing") 
                                               [| _TRLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TRLibor.cell
                                ;  _fixingDate.cell
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
        the curve used to forecast fixings
    *)
    [<ExcelFunction(Name="_TRLibor_forwardingTermStructure", Description="Create a TRLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TRLibor_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TRLibor",Description = "Reference to TRLibor")>] 
         trlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TRLibor = Helper.toCell<TRLibor> trlibor "TRLibor" true 
                let builder () = withMnemonic mnemonic ((_TRLibor.cell :?> TRLiborModel).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_TRLibor.source + ".ForwardingTermStructure") 
                                               [| _TRLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TRLibor.cell
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
        InterestRateIndex interface
    *)
    [<ExcelFunction(Name="_TRLibor_maturityDate", Description="Create a TRLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TRLibor_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TRLibor",Description = "Reference to TRLibor")>] 
         trlibor : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TRLibor = Helper.toCell<TRLibor> trlibor "TRLibor" true 
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" true
                let builder () = withMnemonic mnemonic ((_TRLibor.cell :?> TRLiborModel).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_TRLibor.source + ".MaturityDate") 
                                               [| _TRLibor.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TRLibor.cell
                                ;  _valueDate.cell
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
    [<ExcelFunction(Name="_TRLibor_currency", Description="Create a TRLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TRLibor_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TRLibor",Description = "Reference to TRLibor")>] 
         trlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TRLibor = Helper.toCell<TRLibor> trlibor "TRLibor" true 
                let builder () = withMnemonic mnemonic ((_TRLibor.cell :?> TRLiborModel).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_TRLibor.source + ".Currency") 
                                               [| _TRLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TRLibor.cell
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
    [<ExcelFunction(Name="_TRLibor_dayCounter", Description="Create a TRLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TRLibor_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TRLibor",Description = "Reference to TRLibor")>] 
         trlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TRLibor = Helper.toCell<TRLibor> trlibor "TRLibor" true 
                let builder () = withMnemonic mnemonic ((_TRLibor.cell :?> TRLiborModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_TRLibor.source + ".DayCounter") 
                                               [| _TRLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TRLibor.cell
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
        Inspectors
    *)
    [<ExcelFunction(Name="_TRLibor_familyName", Description="Create a TRLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TRLibor_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TRLibor",Description = "Reference to TRLibor")>] 
         trlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TRLibor = Helper.toCell<TRLibor> trlibor "TRLibor" true 
                let builder () = withMnemonic mnemonic ((_TRLibor.cell :?> TRLiborModel).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TRLibor.source + ".FamilyName") 
                                               [| _TRLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TRLibor.cell
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
    [<ExcelFunction(Name="_TRLibor_fixing", Description="Create a TRLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TRLibor_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TRLibor",Description = "Reference to TRLibor")>] 
         trlibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TRLibor = Helper.toCell<TRLibor> trlibor "TRLibor" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" true
                let builder () = withMnemonic mnemonic ((_TRLibor.cell :?> TRLiborModel).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_TRLibor.source + ".Fixing") 
                                               [| _TRLibor.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TRLibor.cell
                                ;  _fixingDate.cell
                                ;  _forecastTodaysFixing.cell
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
    [<ExcelFunction(Name="_TRLibor_fixingCalendar", Description="Create a TRLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TRLibor_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TRLibor",Description = "Reference to TRLibor")>] 
         trlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TRLibor = Helper.toCell<TRLibor> trlibor "TRLibor" true 
                let builder () = withMnemonic mnemonic ((_TRLibor.cell :?> TRLiborModel).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_TRLibor.source + ".FixingCalendar") 
                                               [| _TRLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TRLibor.cell
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
    [<ExcelFunction(Name="_TRLibor_fixingDate", Description="Create a TRLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TRLibor_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TRLibor",Description = "Reference to TRLibor")>] 
         trlibor : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TRLibor = Helper.toCell<TRLibor> trlibor "TRLibor" true 
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" true
                let builder () = withMnemonic mnemonic ((_TRLibor.cell :?> TRLiborModel).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_TRLibor.source + ".FixingDate") 
                                               [| _TRLibor.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TRLibor.cell
                                ;  _valueDate.cell
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
    [<ExcelFunction(Name="_TRLibor_fixingDays", Description="Create a TRLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TRLibor_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TRLibor",Description = "Reference to TRLibor")>] 
         trlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TRLibor = Helper.toCell<TRLibor> trlibor "TRLibor" true 
                let builder () = withMnemonic mnemonic ((_TRLibor.cell :?> TRLiborModel).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_TRLibor.source + ".FixingDays") 
                                               [| _TRLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TRLibor.cell
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
    [<ExcelFunction(Name="_TRLibor_isValidFixingDate", Description="Create a TRLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TRLibor_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TRLibor",Description = "Reference to TRLibor")>] 
         trlibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TRLibor = Helper.toCell<TRLibor> trlibor "TRLibor" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_TRLibor.cell :?> TRLiborModel).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TRLibor.source + ".IsValidFixingDate") 
                                               [| _TRLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TRLibor.cell
                                ;  _fixingDate.cell
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
        Index interface
    *)
    [<ExcelFunction(Name="_TRLibor_name", Description="Create a TRLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TRLibor_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TRLibor",Description = "Reference to TRLibor")>] 
         trlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TRLibor = Helper.toCell<TRLibor> trlibor "TRLibor" true 
                let builder () = withMnemonic mnemonic ((_TRLibor.cell :?> TRLiborModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TRLibor.source + ".Name") 
                                               [| _TRLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TRLibor.cell
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
    [<ExcelFunction(Name="_TRLibor_pastFixing", Description="Create a TRLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TRLibor_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TRLibor",Description = "Reference to TRLibor")>] 
         trlibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TRLibor = Helper.toCell<TRLibor> trlibor "TRLibor" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_TRLibor.cell :?> TRLiborModel).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TRLibor.source + ".PastFixing") 
                                               [| _TRLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TRLibor.cell
                                ;  _fixingDate.cell
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
    [<ExcelFunction(Name="_TRLibor_tenor", Description="Create a TRLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TRLibor_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TRLibor",Description = "Reference to TRLibor")>] 
         trlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TRLibor = Helper.toCell<TRLibor> trlibor "TRLibor" true 
                let builder () = withMnemonic mnemonic ((_TRLibor.cell :?> TRLiborModel).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_TRLibor.source + ".Tenor") 
                                               [| _TRLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TRLibor.cell
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
        Observer interface
    *)
    [<ExcelFunction(Name="_TRLibor_update", Description="Create a TRLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TRLibor_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TRLibor",Description = "Reference to TRLibor")>] 
         trlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TRLibor = Helper.toCell<TRLibor> trlibor "TRLibor" true 
                let builder () = withMnemonic mnemonic ((_TRLibor.cell :?> TRLiborModel).Update
                                                       ) :> ICell
                let format (o : TRLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TRLibor.source + ".Update") 
                                               [| _TRLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TRLibor.cell
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
        Date calculations These methods can be overridden to implement particular conventions (e.g. EurLibor)
    *)
    [<ExcelFunction(Name="_TRLibor_valueDate", Description="Create a TRLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TRLibor_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TRLibor",Description = "Reference to TRLibor")>] 
         trlibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TRLibor = Helper.toCell<TRLibor> trlibor "TRLibor" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_TRLibor.cell :?> TRLiborModel).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_TRLibor.source + ".ValueDate") 
                                               [| _TRLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TRLibor.cell
                                ;  _fixingDate.cell
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
        Stores the historical fixing at the given date The date passed as arguments must be the actual calendar date of the fixing; no settlement days must be used.
    *)
    [<ExcelFunction(Name="_TRLibor_addFixing", Description="Create a TRLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TRLibor_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TRLibor",Description = "Reference to TRLibor")>] 
         trlibor : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TRLibor = Helper.toCell<TRLibor> trlibor "TRLibor" true 
                let _d = Helper.toCell<Date> d "d" true
                let _v = Helper.toCell<double> v "v" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_TRLibor.cell :?> TRLiborModel).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : TRLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TRLibor.source + ".AddFixing") 
                                               [| _TRLibor.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TRLibor.cell
                                ;  _d.cell
                                ;  _v.cell
                                ;  _forceOverwrite.cell
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
        Stores historical fixings at the given dates The dates passed as arguments must be the actual calendar dates of the fixings; no settlement days must be used.
    *)
    [<ExcelFunction(Name="_TRLibor_addFixings", Description="Create a TRLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TRLibor_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TRLibor",Description = "Reference to TRLibor")>] 
         trlibor : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TRLibor = Helper.toCell<TRLibor> trlibor "TRLibor" true 
                let _d = Helper.toCell<Generic.List<Date>> d "d" true
                let _v = Helper.toCell<Generic.List<double>> v "v" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_TRLibor.cell :?> TRLiborModel).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : TRLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TRLibor.source + ".AddFixings") 
                                               [| _TRLibor.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TRLibor.cell
                                ;  _d.cell
                                ;  _v.cell
                                ;  _forceOverwrite.cell
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
        Stores historical fixings from a TimeSeries The dates in the TimeSeries must be the actual calendar dates of the fixings; no settlement days must be used.
    *)
    [<ExcelFunction(Name="_TRLibor_addFixings1", Description="Create a TRLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TRLibor_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TRLibor",Description = "Reference to TRLibor")>] 
         trlibor : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TRLibor = Helper.toCell<TRLibor> trlibor "TRLibor" true 
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_TRLibor.cell :?> TRLiborModel).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : TRLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TRLibor.source + ".AddFixings1 ") 
                                               [| _TRLibor.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TRLibor.cell
                                ;  _source.cell
                                ;  _forceOverwrite.cell
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
        Check if index allows for native fixings. If this returns false, calls to addFixing and similar methods will raise an exception.
    *)
    [<ExcelFunction(Name="_TRLibor_allowsNativeFixings", Description="Create a TRLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TRLibor_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TRLibor",Description = "Reference to TRLibor")>] 
         trlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TRLibor = Helper.toCell<TRLibor> trlibor "TRLibor" true 
                let builder () = withMnemonic mnemonic ((_TRLibor.cell :?> TRLiborModel).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TRLibor.source + ".AllowsNativeFixings") 
                                               [| _TRLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TRLibor.cell
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
        Clears all stored historical fixings
    *)
    [<ExcelFunction(Name="_TRLibor_clearFixings", Description="Create a TRLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TRLibor_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TRLibor",Description = "Reference to TRLibor")>] 
         trlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TRLibor = Helper.toCell<TRLibor> trlibor "TRLibor" true 
                let builder () = withMnemonic mnemonic ((_TRLibor.cell :?> TRLiborModel).ClearFixings
                                                       ) :> ICell
                let format (o : TRLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TRLibor.source + ".ClearFixings") 
                                               [| _TRLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TRLibor.cell
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
    [<ExcelFunction(Name="_TRLibor_registerWith", Description="Create a TRLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TRLibor_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TRLibor",Description = "Reference to TRLibor")>] 
         trlibor : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TRLibor = Helper.toCell<TRLibor> trlibor "TRLibor" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_TRLibor.cell :?> TRLiborModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : TRLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TRLibor.source + ".RegisterWith") 
                                               [| _TRLibor.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TRLibor.cell
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
        Returns the fixing TimeSeries
    *)
    [<ExcelFunction(Name="_TRLibor_timeSeries", Description="Create a TRLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TRLibor_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TRLibor",Description = "Reference to TRLibor")>] 
         trlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TRLibor = Helper.toCell<TRLibor> trlibor "TRLibor" true 
                let builder () = withMnemonic mnemonic ((_TRLibor.cell :?> TRLiborModel).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TRLibor.source + ".TimeSeries") 
                                               [| _TRLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TRLibor.cell
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
    [<ExcelFunction(Name="_TRLibor_unregisterWith", Description="Create a TRLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TRLibor_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TRLibor",Description = "Reference to TRLibor")>] 
         trlibor : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TRLibor = Helper.toCell<TRLibor> trlibor "TRLibor" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_TRLibor.cell :?> TRLiborModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : TRLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TRLibor.source + ".UnregisterWith") 
                                               [| _TRLibor.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TRLibor.cell
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
    [<ExcelFunction(Name="_TRLibor_Range", Description="Create a range of TRLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TRLibor_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the TRLibor")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<TRLibor> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<TRLibor>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<TRLibor>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<TRLibor>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"