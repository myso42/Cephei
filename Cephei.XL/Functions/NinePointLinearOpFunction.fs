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
module NinePointLinearOpFunction =

    (*
        
    *)
    (*!! duplicate Add function 
    [<ExcelFunction(Name="_NinePointLinearOp_add", Description="Create a NinePointLinearOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NinePointLinearOp_add
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NinePointLinearOp",Description = "NinePointLinearOp")>] 
         ninepointlinearop : obj)
        ([<ExcelArgument(Name="A",Description = "IOperator")>] 
         A : obj)
        ([<ExcelArgument(Name="B",Description = "IOperator")>] 
         B : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NinePointLinearOp = Helper.toModelReference<NinePointLinearOp> ninepointlinearop "NinePointLinearOp"  
                let _A = Helper.toCell<IOperator> A "A" 
                let _B = Helper.toCell<IOperator> B "B" 
                let builder (current : ICell) = ((NinePointLinearOpModel.Cast _NinePointLinearOp.cell).Add
                                                            _A.cell 
                                                            _B.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source () = Helper.sourceFold (_NinePointLinearOp.source + ".Add") 

                                               [| _A.source
                                               ;  _B.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NinePointLinearOp.cell
                                ;  _A.cell
                                ;  _B.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NinePointLinearOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
            *)
    (*
        
    *)
    [<ExcelFunction(Name="_NinePointLinearOp_apply", Description="Create a NinePointLinearOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NinePointLinearOp_apply
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NinePointLinearOp",Description = "NinePointLinearOp")>] 
         ninepointlinearop : obj)
        ([<ExcelArgument(Name="r",Description = "Vector")>] 
         r : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NinePointLinearOp = Helper.toModelReference<NinePointLinearOp> ninepointlinearop "NinePointLinearOp"  
                let _r = Helper.toCell<Vector> r "r" 
                let builder (current : ICell) = ((NinePointLinearOpModel.Cast _NinePointLinearOp.cell).Apply
                                                            _r.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_NinePointLinearOp.source + ".Apply") 

                                               [| _r.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NinePointLinearOp.cell
                                ;  _r.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NinePointLinearOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_NinePointLinearOp_applyTo", Description="Create a NinePointLinearOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NinePointLinearOp_applyTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NinePointLinearOp",Description = "NinePointLinearOp")>] 
         ninepointlinearop : obj)
        ([<ExcelArgument(Name="v",Description = "Vector")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NinePointLinearOp = Helper.toModelReference<NinePointLinearOp> ninepointlinearop "NinePointLinearOp"  
                let _v = Helper.toCell<Vector> v "v" 
                let builder (current : ICell) = ((NinePointLinearOpModel.Cast _NinePointLinearOp.cell).ApplyTo
                                                            _v.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_NinePointLinearOp.source + ".ApplyTo") 

                                               [| _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NinePointLinearOp.cell
                                ;  _v.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NinePointLinearOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_NinePointLinearOp_Clone", Description="Create a NinePointLinearOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NinePointLinearOp_Clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NinePointLinearOp",Description = "NinePointLinearOp")>] 
         ninepointlinearop : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NinePointLinearOp = Helper.toModelReference<NinePointLinearOp> ninepointlinearop "NinePointLinearOp"  
                let builder (current : ICell) = ((NinePointLinearOpModel.Cast _NinePointLinearOp.cell).Clone
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NinePointLinearOp.source + ".Clone") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NinePointLinearOp.cell
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
    [<ExcelFunction(Name="_NinePointLinearOp_identity", Description="Create a NinePointLinearOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NinePointLinearOp_identity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NinePointLinearOp",Description = "NinePointLinearOp")>] 
         ninepointlinearop : obj)
        ([<ExcelArgument(Name="size",Description = "int")>] 
         size : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NinePointLinearOp = Helper.toModelReference<NinePointLinearOp> ninepointlinearop "NinePointLinearOp"  
                let _size = Helper.toCell<int> size "size" 
                let builder (current : ICell) = ((NinePointLinearOpModel.Cast _NinePointLinearOp.cell).Identity
                                                            _size.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source () = Helper.sourceFold (_NinePointLinearOp.source + ".Identity") 

                                               [| _size.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NinePointLinearOp.cell
                                ;  _size.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NinePointLinearOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_NinePointLinearOp_isTimeDependent", Description="Create a NinePointLinearOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NinePointLinearOp_isTimeDependent
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NinePointLinearOp",Description = "NinePointLinearOp")>] 
         ninepointlinearop : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NinePointLinearOp = Helper.toModelReference<NinePointLinearOp> ninepointlinearop "NinePointLinearOp"  
                let builder (current : ICell) = ((NinePointLinearOpModel.Cast _NinePointLinearOp.cell).IsTimeDependent
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NinePointLinearOp.source + ".IsTimeDependent") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NinePointLinearOp.cell
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
    [<ExcelFunction(Name="_NinePointLinearOp_mult", Description="Create a NinePointLinearOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NinePointLinearOp_mult
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NinePointLinearOp",Description = "NinePointLinearOp")>] 
         ninepointlinearop : obj)
        ([<ExcelArgument(Name="r",Description = "Vector")>] 
         r : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NinePointLinearOp = Helper.toModelReference<NinePointLinearOp> ninepointlinearop "NinePointLinearOp"  
                let _r = Helper.toCell<Vector> r "r" 
                let builder (current : ICell) = ((NinePointLinearOpModel.Cast _NinePointLinearOp.cell).Mult
                                                            _r.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<NinePointLinearOp>) l

                let source () = Helper.sourceFold (_NinePointLinearOp.source + ".Mult") 

                                               [| _r.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NinePointLinearOp.cell
                                ;  _r.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NinePointLinearOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_NinePointLinearOp_multiply", Description="Create a NinePointLinearOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NinePointLinearOp_multiply
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NinePointLinearOp",Description = "NinePointLinearOp")>] 
         ninepointlinearop : obj)
        ([<ExcelArgument(Name="a",Description = "double")>] 
         a : obj)
        ([<ExcelArgument(Name="D",Description = "IOperator")>] 
         D : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NinePointLinearOp = Helper.toModelReference<NinePointLinearOp> ninepointlinearop "NinePointLinearOp"  
                let _a = Helper.toCell<double> a "a" 
                let _D = Helper.toCell<IOperator> D "D" 
                let builder (current : ICell) = ((NinePointLinearOpModel.Cast _NinePointLinearOp.cell).Multiply
                                                            _a.cell 
                                                            _D.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source () = Helper.sourceFold (_NinePointLinearOp.source + ".Multiply") 

                                               [| _a.source
                                               ;  _D.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NinePointLinearOp.cell
                                ;  _a.cell
                                ;  _D.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NinePointLinearOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_NinePointLinearOp", Description="Create a NinePointLinearOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NinePointLinearOp_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="m",Description = "NinePointLinearOp")>] 
         m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _m = Helper.toCell<NinePointLinearOp> m "m" 
                let builder (current : ICell) = (Fun.NinePointLinearOp 
                                                            _m.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<NinePointLinearOp>) l

                let source () = Helper.sourceFold "Fun.NinePointLinearOp" 
                                               [| _m.source
                                               |]
                let hash = Helper.hashFold 
                                [| _m.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NinePointLinearOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_NinePointLinearOp1", Description="Create a NinePointLinearOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NinePointLinearOp_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="d0",Description = "int")>] 
         d0 : obj)
        ([<ExcelArgument(Name="d1",Description = "int")>] 
         d1 : obj)
        ([<ExcelArgument(Name="mesher",Description = "FdmMesher")>] 
         mesher : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _d0 = Helper.toCell<int> d0 "d0" 
                let _d1 = Helper.toCell<int> d1 "d1" 
                let _mesher = Helper.toCell<FdmMesher> mesher "mesher" 
                let builder (current : ICell) = (Fun.NinePointLinearOp1 
                                                            _d0.cell 
                                                            _d1.cell 
                                                            _mesher.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<NinePointLinearOp>) l

                let source () = Helper.sourceFold "Fun.NinePointLinearOp1" 
                                               [| _d0.source
                                               ;  _d1.source
                                               ;  _mesher.source
                                               |]
                let hash = Helper.hashFold 
                                [| _d0.cell
                                ;  _d1.cell
                                ;  _mesher.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NinePointLinearOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_NinePointLinearOp_setTime", Description="Create a NinePointLinearOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NinePointLinearOp_setTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NinePointLinearOp",Description = "NinePointLinearOp")>] 
         ninepointlinearop : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NinePointLinearOp = Helper.toModelReference<NinePointLinearOp> ninepointlinearop "NinePointLinearOp"  
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = ((NinePointLinearOpModel.Cast _NinePointLinearOp.cell).SetTime
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : NinePointLinearOp) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NinePointLinearOp.source + ".SetTime") 

                                               [| _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NinePointLinearOp.cell
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
    [<ExcelFunction(Name="_NinePointLinearOp_size", Description="Create a NinePointLinearOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NinePointLinearOp_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NinePointLinearOp",Description = "NinePointLinearOp")>] 
         ninepointlinearop : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NinePointLinearOp = Helper.toModelReference<NinePointLinearOp> ninepointlinearop "NinePointLinearOp"  
                let builder (current : ICell) = ((NinePointLinearOpModel.Cast _NinePointLinearOp.cell).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_NinePointLinearOp.source + ".Size") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NinePointLinearOp.cell
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
    [<ExcelFunction(Name="_NinePointLinearOp_solveFor", Description="Create a NinePointLinearOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NinePointLinearOp_solveFor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NinePointLinearOp",Description = "NinePointLinearOp")>] 
         ninepointlinearop : obj)
        ([<ExcelArgument(Name="rhs",Description = "Vector")>] 
         rhs : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NinePointLinearOp = Helper.toModelReference<NinePointLinearOp> ninepointlinearop "NinePointLinearOp"  
                let _rhs = Helper.toCell<Vector> rhs "rhs" 
                let builder (current : ICell) = ((NinePointLinearOpModel.Cast _NinePointLinearOp.cell).SolveFor
                                                            _rhs.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_NinePointLinearOp.source + ".SolveFor") 

                                               [| _rhs.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NinePointLinearOp.cell
                                ;  _rhs.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NinePointLinearOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_NinePointLinearOp_subtract", Description="Create a NinePointLinearOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NinePointLinearOp_subtract
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NinePointLinearOp",Description = "NinePointLinearOp")>] 
         ninepointlinearop : obj)
        ([<ExcelArgument(Name="A",Description = "IOperator")>] 
         A : obj)
        ([<ExcelArgument(Name="B",Description = "IOperator")>] 
         B : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NinePointLinearOp = Helper.toModelReference<NinePointLinearOp> ninepointlinearop "NinePointLinearOp"  
                let _A = Helper.toCell<IOperator> A "A" 
                let _B = Helper.toCell<IOperator> B "B" 
                let builder (current : ICell) = ((NinePointLinearOpModel.Cast _NinePointLinearOp.cell).Subtract
                                                            _A.cell 
                                                            _B.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source () = Helper.sourceFold (_NinePointLinearOp.source + ".Subtract") 

                                               [| _A.source
                                               ;  _B.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NinePointLinearOp.cell
                                ;  _A.cell
                                ;  _B.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NinePointLinearOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_NinePointLinearOp_swap", Description="Create a NinePointLinearOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NinePointLinearOp_swap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NinePointLinearOp",Description = "NinePointLinearOp")>] 
         ninepointlinearop : obj)
        ([<ExcelArgument(Name="m",Description = "NinePointLinearOp")>] 
         m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NinePointLinearOp = Helper.toModelReference<NinePointLinearOp> ninepointlinearop "NinePointLinearOp"  
                let _m = Helper.toCell<NinePointLinearOp> m "m" 
                let builder (current : ICell) = ((NinePointLinearOpModel.Cast _NinePointLinearOp.cell).Swap
                                                            _m.cell 
                                                       ) :> ICell
                let format (o : NinePointLinearOp) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NinePointLinearOp.source + ".Swap") 

                                               [| _m.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NinePointLinearOp.cell
                                ;  _m.cell
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
    [<ExcelFunction(Name="_NinePointLinearOp_toMatrix", Description="Create a NinePointLinearOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NinePointLinearOp_toMatrix
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NinePointLinearOp",Description = "NinePointLinearOp")>] 
         ninepointlinearop : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NinePointLinearOp = Helper.toModelReference<NinePointLinearOp> ninepointlinearop "NinePointLinearOp"  
                let builder (current : ICell) = ((NinePointLinearOpModel.Cast _NinePointLinearOp.cell).ToMatrix
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SparseMatrix>) l

                let source () = Helper.sourceFold (_NinePointLinearOp.source + ".ToMatrix") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NinePointLinearOp.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NinePointLinearOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_NinePointLinearOp_Range", Description="Create a range of NinePointLinearOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NinePointLinearOp_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<NinePointLinearOp> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<NinePointLinearOp> (c)) :> ICell
                let format (i : Cephei.Cell.List<NinePointLinearOp>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<NinePointLinearOp>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
