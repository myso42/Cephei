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
module DiscretizedDermanKaniBarrierOptionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_DiscretizedDermanKaniBarrierOption", Description="Create a DiscretizedDermanKaniBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedDermanKaniBarrierOption_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="args",Description = "BarrierOption.Arguments")>] 
         args : obj)
        ([<ExcelArgument(Name="Process",Description = "StochasticProcess")>] 
         Process : obj)
        ([<ExcelArgument(Name="grid",Description = "TimeGrid or empty")>] 
         grid : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _args = Helper.toCell<BarrierOption.Arguments> args "args" 
                let _Process = Helper.toCell<StochasticProcess> Process "Process" 
                let _grid = Helper.toDefault<TimeGrid> grid "grid" null
                let builder (current : ICell) = (Fun.DiscretizedDermanKaniBarrierOption 
                                                            _args.cell 
                                                            _Process.cell 
                                                            _grid.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DiscretizedDermanKaniBarrierOption>) l

                let source () = Helper.sourceFold "Fun.DiscretizedDermanKaniBarrierOption" 
                                               [| _args.source
                                               ;  _Process.source
                                               ;  _grid.source
                                               |]
                let hash = Helper.hashFold 
                                [| _args.cell
                                ;  _Process.cell
                                ;  _grid.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DiscretizedDermanKaniBarrierOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DiscretizedDermanKaniBarrierOption_mandatoryTimes", Description="Create a DiscretizedDermanKaniBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedDermanKaniBarrierOption_mandatoryTimes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDermanKaniBarrierOption",Description = "DiscretizedDermanKaniBarrierOption")>] 
         discretizeddermankanibarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDermanKaniBarrierOption = Helper.toModelReference<DiscretizedDermanKaniBarrierOption> discretizeddermankanibarrieroption "DiscretizedDermanKaniBarrierOption"  
                let builder (current : ICell) = ((DiscretizedDermanKaniBarrierOptionModel.Cast _DiscretizedDermanKaniBarrierOption.cell).MandatoryTimes
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_DiscretizedDermanKaniBarrierOption.source + ".MandatoryTimes") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedDermanKaniBarrierOption.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DiscretizedDermanKaniBarrierOption_reset", Description="Create a DiscretizedDermanKaniBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedDermanKaniBarrierOption_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDermanKaniBarrierOption",Description = "DiscretizedDermanKaniBarrierOption")>] 
         discretizeddermankanibarrieroption : obj)
        ([<ExcelArgument(Name="size",Description = "int")>] 
         size : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDermanKaniBarrierOption = Helper.toModelReference<DiscretizedDermanKaniBarrierOption> discretizeddermankanibarrieroption "DiscretizedDermanKaniBarrierOption"  
                let _size = Helper.toCell<int> size "size" 
                let builder (current : ICell) = ((DiscretizedDermanKaniBarrierOptionModel.Cast _DiscretizedDermanKaniBarrierOption.cell).Reset
                                                            _size.cell 
                                                       ) :> ICell
                let format (o : DiscretizedDermanKaniBarrierOption) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedDermanKaniBarrierOption.source + ".Reset") 

                                               [| _size.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedDermanKaniBarrierOption.cell
                                ;  _size.cell
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
        ! This method performs both pre- and post-adjustment
    *)
    [<ExcelFunction(Name="_DiscretizedDermanKaniBarrierOption_adjustValues", Description="Create a DiscretizedDermanKaniBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedDermanKaniBarrierOption_adjustValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDermanKaniBarrierOption",Description = "DiscretizedDermanKaniBarrierOption")>] 
         discretizeddermankanibarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDermanKaniBarrierOption = Helper.toModelReference<DiscretizedDermanKaniBarrierOption> discretizeddermankanibarrieroption "DiscretizedDermanKaniBarrierOption"  
                let builder (current : ICell) = ((DiscretizedDermanKaniBarrierOptionModel.Cast _DiscretizedDermanKaniBarrierOption.cell).AdjustValues
                                                       ) :> ICell
                let format (o : DiscretizedDermanKaniBarrierOption) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedDermanKaniBarrierOption.source + ".AdjustValues") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedDermanKaniBarrierOption.cell
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
        High-level interface  Users of discretized assets should use these methods in order to initialize, evolve and take the present value of the assets.  They call the corresponding methods in the Lattice interface, to which we refer for documentation.
    *)
    [<ExcelFunction(Name="_DiscretizedDermanKaniBarrierOption_initialize", Description="Create a DiscretizedDermanKaniBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedDermanKaniBarrierOption_initialize
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDermanKaniBarrierOption",Description = "DiscretizedDermanKaniBarrierOption")>] 
         discretizeddermankanibarrieroption : obj)
        ([<ExcelArgument(Name="Method",Description = "Lattice")>] 
         Method : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDermanKaniBarrierOption = Helper.toModelReference<DiscretizedDermanKaniBarrierOption> discretizeddermankanibarrieroption "DiscretizedDermanKaniBarrierOption"  
                let _Method = Helper.toCell<Lattice> Method "Method" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = ((DiscretizedDermanKaniBarrierOptionModel.Cast _DiscretizedDermanKaniBarrierOption.cell).Initialize
                                                            _Method.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : DiscretizedDermanKaniBarrierOption) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedDermanKaniBarrierOption.source + ".Initialize") 

                                               [| _Method.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedDermanKaniBarrierOption.cell
                                ;  _Method.cell
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
    [<ExcelFunction(Name="_DiscretizedDermanKaniBarrierOption_method", Description="Create a DiscretizedDermanKaniBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedDermanKaniBarrierOption_method
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDermanKaniBarrierOption",Description = "DiscretizedDermanKaniBarrierOption")>] 
         discretizeddermankanibarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDermanKaniBarrierOption = Helper.toModelReference<DiscretizedDermanKaniBarrierOption> discretizeddermankanibarrieroption "DiscretizedDermanKaniBarrierOption"  
                let builder (current : ICell) = ((DiscretizedDermanKaniBarrierOptionModel.Cast _DiscretizedDermanKaniBarrierOption.cell).Method
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Lattice>) l

                let source () = Helper.sourceFold (_DiscretizedDermanKaniBarrierOption.source + ".METHOD") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedDermanKaniBarrierOption.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DiscretizedDermanKaniBarrierOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DiscretizedDermanKaniBarrierOption_partialRollback", Description="Create a DiscretizedDermanKaniBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedDermanKaniBarrierOption_partialRollback
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDermanKaniBarrierOption",Description = "DiscretizedDermanKaniBarrierOption")>] 
         discretizeddermankanibarrieroption : obj)
        ([<ExcelArgument(Name="To",Description = "double")>] 
         To : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDermanKaniBarrierOption = Helper.toModelReference<DiscretizedDermanKaniBarrierOption> discretizeddermankanibarrieroption "DiscretizedDermanKaniBarrierOption"  
                let _To = Helper.toCell<double> To "To" 
                let builder (current : ICell) = ((DiscretizedDermanKaniBarrierOptionModel.Cast _DiscretizedDermanKaniBarrierOption.cell).PartialRollback
                                                            _To.cell 
                                                       ) :> ICell
                let format (o : DiscretizedDermanKaniBarrierOption) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedDermanKaniBarrierOption.source + ".PartialRollback") 

                                               [| _To.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedDermanKaniBarrierOption.cell
                                ;  _To.cell
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
        ! This method will be invoked after rollback and after any other asset had their chance to look at the values. For instance, payments happening at the present time (and therefore not included in an option to be exercised at this time) will be added here.  This method is not virtual; derived classes must override the protected postAdjustValuesImpl() method instead.
    *)
    [<ExcelFunction(Name="_DiscretizedDermanKaniBarrierOption_postAdjustValues", Description="Create a DiscretizedDermanKaniBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedDermanKaniBarrierOption_postAdjustValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDermanKaniBarrierOption",Description = "DiscretizedDermanKaniBarrierOption")>] 
         discretizeddermankanibarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDermanKaniBarrierOption = Helper.toModelReference<DiscretizedDermanKaniBarrierOption> discretizeddermankanibarrieroption "DiscretizedDermanKaniBarrierOption"  
                let builder (current : ICell) = ((DiscretizedDermanKaniBarrierOptionModel.Cast _DiscretizedDermanKaniBarrierOption.cell).PostAdjustValues
                                                       ) :> ICell
                let format (o : DiscretizedDermanKaniBarrierOption) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedDermanKaniBarrierOption.source + ".PostAdjustValues") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedDermanKaniBarrierOption.cell
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
        ! This method will be invoked after rollback and before any other asset (i.e., an option on this one) has any chance to look at the values. For instance, payments happening at times already spanned by the rollback will be added here.  This method is not virtual; derived classes must override the protected preAdjustValuesImpl() method instead.
    *)
    [<ExcelFunction(Name="_DiscretizedDermanKaniBarrierOption_preAdjustValues", Description="Create a DiscretizedDermanKaniBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedDermanKaniBarrierOption_preAdjustValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDermanKaniBarrierOption",Description = "DiscretizedDermanKaniBarrierOption")>] 
         discretizeddermankanibarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDermanKaniBarrierOption = Helper.toModelReference<DiscretizedDermanKaniBarrierOption> discretizeddermankanibarrieroption "DiscretizedDermanKaniBarrierOption"  
                let builder (current : ICell) = ((DiscretizedDermanKaniBarrierOptionModel.Cast _DiscretizedDermanKaniBarrierOption.cell).PreAdjustValues
                                                       ) :> ICell
                let format (o : DiscretizedDermanKaniBarrierOption) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedDermanKaniBarrierOption.source + ".PreAdjustValues") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedDermanKaniBarrierOption.cell
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
    [<ExcelFunction(Name="_DiscretizedDermanKaniBarrierOption_presentValue", Description="Create a DiscretizedDermanKaniBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedDermanKaniBarrierOption_presentValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDermanKaniBarrierOption",Description = "DiscretizedDermanKaniBarrierOption")>] 
         discretizeddermankanibarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDermanKaniBarrierOption = Helper.toModelReference<DiscretizedDermanKaniBarrierOption> discretizeddermankanibarrieroption "DiscretizedDermanKaniBarrierOption"  
                let builder (current : ICell) = ((DiscretizedDermanKaniBarrierOptionModel.Cast _DiscretizedDermanKaniBarrierOption.cell).PresentValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DiscretizedDermanKaniBarrierOption.source + ".PresentValue") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedDermanKaniBarrierOption.cell
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
    [<ExcelFunction(Name="_DiscretizedDermanKaniBarrierOption_rollback", Description="Create a DiscretizedDermanKaniBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedDermanKaniBarrierOption_rollback
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDermanKaniBarrierOption",Description = "DiscretizedDermanKaniBarrierOption")>] 
         discretizeddermankanibarrieroption : obj)
        ([<ExcelArgument(Name="To",Description = "double")>] 
         To : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDermanKaniBarrierOption = Helper.toModelReference<DiscretizedDermanKaniBarrierOption> discretizeddermankanibarrieroption "DiscretizedDermanKaniBarrierOption"  
                let _To = Helper.toCell<double> To "To" 
                let builder (current : ICell) = ((DiscretizedDermanKaniBarrierOptionModel.Cast _DiscretizedDermanKaniBarrierOption.cell).Rollback
                                                            _To.cell 
                                                       ) :> ICell
                let format (o : DiscretizedDermanKaniBarrierOption) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedDermanKaniBarrierOption.source + ".Rollback") 

                                               [| _To.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedDermanKaniBarrierOption.cell
                                ;  _To.cell
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
        safe version of QL double* time()
    *)
    [<ExcelFunction(Name="_DiscretizedDermanKaniBarrierOption_setTime", Description="Create a DiscretizedDermanKaniBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedDermanKaniBarrierOption_setTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDermanKaniBarrierOption",Description = "DiscretizedDermanKaniBarrierOption")>] 
         discretizeddermankanibarrieroption : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDermanKaniBarrierOption = Helper.toModelReference<DiscretizedDermanKaniBarrierOption> discretizeddermankanibarrieroption "DiscretizedDermanKaniBarrierOption"  
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = ((DiscretizedDermanKaniBarrierOptionModel.Cast _DiscretizedDermanKaniBarrierOption.cell).SetTime
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : DiscretizedDermanKaniBarrierOption) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedDermanKaniBarrierOption.source + ".SetTime") 

                                               [| _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedDermanKaniBarrierOption.cell
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
        safe version of QL Vector* values()
    *)
    [<ExcelFunction(Name="_DiscretizedDermanKaniBarrierOption_setValues", Description="Create a DiscretizedDermanKaniBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedDermanKaniBarrierOption_setValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDermanKaniBarrierOption",Description = "DiscretizedDermanKaniBarrierOption")>] 
         discretizeddermankanibarrieroption : obj)
        ([<ExcelArgument(Name="v",Description = "Vector")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDermanKaniBarrierOption = Helper.toModelReference<DiscretizedDermanKaniBarrierOption> discretizeddermankanibarrieroption "DiscretizedDermanKaniBarrierOption"  
                let _v = Helper.toCell<Vector> v "v" 
                let builder (current : ICell) = ((DiscretizedDermanKaniBarrierOptionModel.Cast _DiscretizedDermanKaniBarrierOption.cell).SetValues
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : DiscretizedDermanKaniBarrierOption) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedDermanKaniBarrierOption.source + ".SetValues") 

                                               [| _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedDermanKaniBarrierOption.cell
                                ;  _v.cell
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
    [<ExcelFunction(Name="_DiscretizedDermanKaniBarrierOption_time", Description="Create a DiscretizedDermanKaniBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedDermanKaniBarrierOption_time
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDermanKaniBarrierOption",Description = "DiscretizedDermanKaniBarrierOption")>] 
         discretizeddermankanibarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDermanKaniBarrierOption = Helper.toModelReference<DiscretizedDermanKaniBarrierOption> discretizeddermankanibarrieroption "DiscretizedDermanKaniBarrierOption"  
                let builder (current : ICell) = ((DiscretizedDermanKaniBarrierOptionModel.Cast _DiscretizedDermanKaniBarrierOption.cell).Time
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DiscretizedDermanKaniBarrierOption.source + ".Time") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedDermanKaniBarrierOption.cell
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
    [<ExcelFunction(Name="_DiscretizedDermanKaniBarrierOption_values", Description="Create a DiscretizedDermanKaniBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedDermanKaniBarrierOption_values
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDermanKaniBarrierOption",Description = "DiscretizedDermanKaniBarrierOption")>] 
         discretizeddermankanibarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDermanKaniBarrierOption = Helper.toModelReference<DiscretizedDermanKaniBarrierOption> discretizeddermankanibarrieroption "DiscretizedDermanKaniBarrierOption"  
                let builder (current : ICell) = ((DiscretizedDermanKaniBarrierOptionModel.Cast _DiscretizedDermanKaniBarrierOption.cell).Values
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_DiscretizedDermanKaniBarrierOption.source + ".Values") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedDermanKaniBarrierOption.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DiscretizedDermanKaniBarrierOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_DiscretizedDermanKaniBarrierOption_Range", Description="Create a range of DiscretizedDermanKaniBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedDermanKaniBarrierOption_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DiscretizedDermanKaniBarrierOption> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<DiscretizedDermanKaniBarrierOption> (c)) :> ICell
                let format (i : Cephei.Cell.List<DiscretizedDermanKaniBarrierOption>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<DiscretizedDermanKaniBarrierOption>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
