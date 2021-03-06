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
(*!! ommited
(* <summary>
  stochastic process whose dynamics are expressed in the forward measure.  processes
  </summary> *)
[<AutoSerializable(true)>]
module ForwardMeasureProcessFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ForwardMeasureProcess_diffusion", Description="Create a ForwardMeasureProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardMeasureProcess_diffusion
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardMeasureProcess",Description = "ForwardMeasureProcess")>] 
         forwardmeasureprocess : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Vector")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardMeasureProcess = Helper.toModelReference<ForwardMeasureProcess> forwardmeasureprocess "ForwardMeasureProcess"  
                let _t = Helper.toCell<double> t "t" 
                let _x = Helper.toCell<Vector> x "x" 
                let builder (current : ICell) = ((ForwardMeasureProcessModel.Cast _ForwardMeasureProcess.cell).Diffusion
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source () = Helper.sourceFold (_ForwardMeasureProcess.source + ".Diffusion") 

                                               [| _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardMeasureProcess.cell
                                ;  _t.cell
                                ;  _x.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ForwardMeasureProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ForwardMeasureProcess_drift", Description="Create a ForwardMeasureProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardMeasureProcess_drift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardMeasureProcess",Description = "ForwardMeasureProcess")>] 
         forwardmeasureprocess : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Vector")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardMeasureProcess = Helper.toModelReference<ForwardMeasureProcess> forwardmeasureprocess "ForwardMeasureProcess"  
                let _t = Helper.toCell<double> t "t" 
                let _x = Helper.toCell<Vector> x "x" 
                let builder (current : ICell) = ((ForwardMeasureProcessModel.Cast _ForwardMeasureProcess.cell).Drift
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_ForwardMeasureProcess.source + ".Drift") 

                                               [| _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardMeasureProcess.cell
                                ;  _t.cell
                                ;  _x.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ForwardMeasureProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ForwardMeasureProcess_getForwardMeasureTime", Description="Create a ForwardMeasureProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardMeasureProcess_getForwardMeasureTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardMeasureProcess",Description = "ForwardMeasureProcess")>] 
         forwardmeasureprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardMeasureProcess = Helper.toModelReference<ForwardMeasureProcess> forwardmeasureprocess "ForwardMeasureProcess"  
                let builder (current : ICell) = ((ForwardMeasureProcessModel.Cast _ForwardMeasureProcess.cell).GetForwardMeasureTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ForwardMeasureProcess.source + ".GetForwardMeasureTime") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ForwardMeasureProcess.cell
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
    [<ExcelFunction(Name="_ForwardMeasureProcess_initialValues", Description="Create a ForwardMeasureProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardMeasureProcess_initialValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardMeasureProcess",Description = "ForwardMeasureProcess")>] 
         forwardmeasureprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardMeasureProcess = Helper.toModelReference<ForwardMeasureProcess> forwardmeasureprocess "ForwardMeasureProcess"  
                let builder (current : ICell) = ((ForwardMeasureProcessModel.Cast _ForwardMeasureProcess.cell).InitialValues
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_ForwardMeasureProcess.source + ".InitialValues") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ForwardMeasureProcess.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ForwardMeasureProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ForwardMeasureProcess_setForwardMeasureTime", Description="Create a ForwardMeasureProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardMeasureProcess_setForwardMeasureTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardMeasureProcess",Description = "ForwardMeasureProcess")>] 
         forwardmeasureprocess : obj)
        ([<ExcelArgument(Name="T",Description = "double")>] 
         T : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardMeasureProcess = Helper.toModelReference<ForwardMeasureProcess> forwardmeasureprocess "ForwardMeasureProcess"  
                let _T = Helper.toCell<double> T "T" 
                let builder (current : ICell) = ((ForwardMeasureProcessModel.Cast _ForwardMeasureProcess.cell).SetForwardMeasureTime
                                                            _T.cell 
                                                       ) :> ICell
                let format (o : ForwardMeasureProcess) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ForwardMeasureProcess.source + ".SetForwardMeasureTime") 

                                               [| _T.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardMeasureProcess.cell
                                ;  _T.cell
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
    [<ExcelFunction(Name="_ForwardMeasureProcess_size", Description="Create a ForwardMeasureProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardMeasureProcess_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardMeasureProcess",Description = "ForwardMeasureProcess")>] 
         forwardmeasureprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardMeasureProcess = Helper.toModelReference<ForwardMeasureProcess> forwardmeasureprocess "ForwardMeasureProcess"  
                let builder (current : ICell) = ((ForwardMeasureProcessModel.Cast _ForwardMeasureProcess.cell).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ForwardMeasureProcess.source + ".Size") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ForwardMeasureProcess.cell
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
        applies a change to the asset value.
    *)
    [<ExcelFunction(Name="_ForwardMeasureProcess_apply", Description="Create a ForwardMeasureProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardMeasureProcess_apply
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardMeasureProcess",Description = "ForwardMeasureProcess")>] 
         forwardmeasureprocess : obj)
        ([<ExcelArgument(Name="x0",Description = "Vector")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dx",Description = "Vector")>] 
         dx : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardMeasureProcess = Helper.toModelReference<ForwardMeasureProcess> forwardmeasureprocess "ForwardMeasureProcess"  
                let _x0 = Helper.toCell<Vector> x0 "x0" 
                let _dx = Helper.toCell<Vector> dx "dx" 
                let builder (current : ICell) = ((ForwardMeasureProcessModel.Cast _ForwardMeasureProcess.cell).Apply
                                                            _x0.cell 
                                                            _dx.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_ForwardMeasureProcess.source + ".Apply") 

                                               [| _x0.source
                                               ;  _dx.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardMeasureProcess.cell
                                ;  _x0.cell
                                ;  _dx.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ForwardMeasureProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! returns the covariance. This method can be overridden in derived classes which want to hard-code a particular discretization.
    *)
    [<ExcelFunction(Name="_ForwardMeasureProcess_covariance", Description="Create a ForwardMeasureProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardMeasureProcess_covariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardMeasureProcess",Description = "ForwardMeasureProcess")>] 
         forwardmeasureprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "double")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Vector")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "double")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardMeasureProcess = Helper.toModelReference<ForwardMeasureProcess> forwardmeasureprocess "ForwardMeasureProcess"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<Vector> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let builder (current : ICell) = ((ForwardMeasureProcessModel.Cast _ForwardMeasureProcess.cell).Covariance
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source () = Helper.sourceFold (_ForwardMeasureProcess.source + ".Covariance") 

                                               [| _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardMeasureProcess.cell
                                ;  _t0.cell
                                ;  _x0.cell
                                ;  _dt.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ForwardMeasureProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        returns the asset value after a time interval
    *)
    [<ExcelFunction(Name="_ForwardMeasureProcess_evolve", Description="Create a ForwardMeasureProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardMeasureProcess_evolve
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardMeasureProcess",Description = "ForwardMeasureProcess")>] 
         forwardmeasureprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "double")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Vector")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "double")>] 
         dt : obj)
        ([<ExcelArgument(Name="dw",Description = "Vector")>] 
         dw : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardMeasureProcess = Helper.toModelReference<ForwardMeasureProcess> forwardmeasureprocess "ForwardMeasureProcess"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<Vector> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let _dw = Helper.toCell<Vector> dw "dw" 
                let builder (current : ICell) = ((ForwardMeasureProcessModel.Cast _ForwardMeasureProcess.cell).Evolve
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                            _dw.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_ForwardMeasureProcess.source + ".Evolve") 

                                               [| _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               ;  _dw.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardMeasureProcess.cell
                                ;  _t0.cell
                                ;  _x0.cell
                                ;  _dt.cell
                                ;  _dw.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ForwardMeasureProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! This method can be overridden in derived classes which want to hard-code a particular discretization.
    *)
    [<ExcelFunction(Name="_ForwardMeasureProcess_expectation", Description="Create a ForwardMeasureProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardMeasureProcess_expectation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardMeasureProcess",Description = "ForwardMeasureProcess")>] 
         forwardmeasureprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "double")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Vector")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "double")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardMeasureProcess = Helper.toModelReference<ForwardMeasureProcess> forwardmeasureprocess "ForwardMeasureProcess"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<Vector> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let builder (current : ICell) = ((ForwardMeasureProcessModel.Cast _ForwardMeasureProcess.cell).Expectation
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_ForwardMeasureProcess.source + ".Expectation") 

                                               [| _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardMeasureProcess.cell
                                ;  _t0.cell
                                ;  _x0.cell
                                ;  _dt.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ForwardMeasureProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! returns the number of independent factors of the process
    *)
    [<ExcelFunction(Name="_ForwardMeasureProcess_factors", Description="Create a ForwardMeasureProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardMeasureProcess_factors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardMeasureProcess",Description = "ForwardMeasureProcess")>] 
         forwardmeasureprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardMeasureProcess = Helper.toModelReference<ForwardMeasureProcess> forwardmeasureprocess "ForwardMeasureProcess"  
                let builder (current : ICell) = ((ForwardMeasureProcessModel.Cast _ForwardMeasureProcess.cell).Factors
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ForwardMeasureProcess.source + ".Factors") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ForwardMeasureProcess.cell
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
    [<ExcelFunction(Name="_ForwardMeasureProcess_registerWith", Description="Create a ForwardMeasureProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardMeasureProcess_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardMeasureProcess",Description = "ForwardMeasureProcess")>] 
         forwardmeasureprocess : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardMeasureProcess = Helper.toModelReference<ForwardMeasureProcess> forwardmeasureprocess "ForwardMeasureProcess"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((ForwardMeasureProcessModel.Cast _ForwardMeasureProcess.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : ForwardMeasureProcess) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ForwardMeasureProcess.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardMeasureProcess.cell
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
        ! returns the standard deviation. This method can be overridden in derived classes which want to hard-code a particular discretization.
    *)
    [<ExcelFunction(Name="_ForwardMeasureProcess_stdDeviation", Description="Create a ForwardMeasureProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardMeasureProcess_stdDeviation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardMeasureProcess",Description = "ForwardMeasureProcess")>] 
         forwardmeasureprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "double")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Vector")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "double")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardMeasureProcess = Helper.toModelReference<ForwardMeasureProcess> forwardmeasureprocess "ForwardMeasureProcess"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<Vector> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let builder (current : ICell) = ((ForwardMeasureProcessModel.Cast _ForwardMeasureProcess.cell).StdDeviation
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source () = Helper.sourceFold (_ForwardMeasureProcess.source + ".StdDeviation") 

                                               [| _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardMeasureProcess.cell
                                ;  _t0.cell
                                ;  _x0.cell
                                ;  _dt.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ForwardMeasureProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! returns the time value corresponding to the given date in the reference system of the stochastic process.  \note As a number of processes might not need this functionality, a default implementation is given which raises an exception.
    *)
    [<ExcelFunction(Name="_ForwardMeasureProcess_time", Description="Create a ForwardMeasureProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardMeasureProcess_time
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardMeasureProcess",Description = "ForwardMeasureProcess")>] 
         forwardmeasureprocess : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardMeasureProcess = Helper.toModelReference<ForwardMeasureProcess> forwardmeasureprocess "ForwardMeasureProcess"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = ((ForwardMeasureProcessModel.Cast _ForwardMeasureProcess.cell).Time
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ForwardMeasureProcess.source + ".Time") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardMeasureProcess.cell
                                ;  _d.cell
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
    [<ExcelFunction(Name="_ForwardMeasureProcess_unregisterWith", Description="Create a ForwardMeasureProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardMeasureProcess_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardMeasureProcess",Description = "ForwardMeasureProcess")>] 
         forwardmeasureprocess : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardMeasureProcess = Helper.toModelReference<ForwardMeasureProcess> forwardmeasureprocess "ForwardMeasureProcess"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((ForwardMeasureProcessModel.Cast _ForwardMeasureProcess.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : ForwardMeasureProcess) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ForwardMeasureProcess.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardMeasureProcess.cell
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
    [<ExcelFunction(Name="_ForwardMeasureProcess_update", Description="Create a ForwardMeasureProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardMeasureProcess_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardMeasureProcess",Description = "ForwardMeasureProcess")>] 
         forwardmeasureprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardMeasureProcess = Helper.toModelReference<ForwardMeasureProcess> forwardmeasureprocess "ForwardMeasureProcess"  
                let builder (current : ICell) = ((ForwardMeasureProcessModel.Cast _ForwardMeasureProcess.cell).Update
                                                       ) :> ICell
                let format (o : ForwardMeasureProcess) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ForwardMeasureProcess.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ForwardMeasureProcess.cell
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
    [<ExcelFunction(Name="_ForwardMeasureProcess_Range", Description="Create a range of ForwardMeasureProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardMeasureProcess_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ForwardMeasureProcess> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<ForwardMeasureProcess> (c)) :> ICell
                let format (i : Cephei.Cell.List<ForwardMeasureProcess>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<ForwardMeasureProcess>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
