﻿(*
Copyright (C) 2020 Cepheis Ltd (steve.channell@cepheis.com)

This file is part of Cephei.QL Project https://github.com/channell/Cephei

Cephei.QL is open source software based on QLNet  you can redistribute it and/or modify it
under the terms of the Cephei.QL license.  You should have received a
copy of the license along with this program; if not, license is
available at <https://github.com/channell/Cephei/LICENSE>.

This program is distributed in the hope that it will be useful, but WITHOUT
ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
FOR A PARTICULAR PURPOSE.  See the license for more details.
*)

namespace Cephei.XL

//open ExcelDna.Integration
//open ExcelDna.Integration.Rtd
open Cephei.Cell
open Cephei.Cell.Generic
open Cephei.QL
open System.Collections.Generic
open System.Collections
open System
open System.Threading.Tasks


// Summary: bridge to convert observable events to an updatd value
type RTDObserver<'T> (rtd : IValueRTD, cell : ICell<'T>, format : 'T -> string -> obj, layout : string) as this =

    let _rtd = rtd
    let _mnemonic = cell.Mnemonic
    let _holder = cell.Subscribe(this)
    let _format = format
    let _layout = layout
    do Cell.Dispatch (new Action(fun () -> 
        try
            _rtd.UpdateValue _mnemonic _layout (_format cell.Value layout)
        with 
        | e -> (_rtd.UpdateValue _mnemonic _layout ("#" + e.Message))
               Serilog.Log.Error(e, e.Message)
        ))

    interface IObserver<'T> with
        member this.OnCompleted () : unit =
            ignore 1

        member this.OnError (e : Exception) =
            _rtd.UpdateValue _mnemonic _layout (("#" + e.Message) :> obj)

        member this.OnNext (value : 'T) = 
                _rtd.UpdateValue _mnemonic _layout (_format value layout)

    interface IDisposable with
        member this.Dispose () =
            _holder.Dispose ()


// Summary: bridge to convert observable events to an updatd values
type RTDRangeObserver<'T> (rtd : IValueRTD, cell : ICell<Generic.List<'T>>, format : System.Collections.Generic.List<'T> -> string -> obj[,], layout : string) as this =

    let _rtd = rtd
    let _mnemonic = cell.Mnemonic
    let _holder = cell.Subscribe(this)
    let _format = format
    let _layout = layout
    do Cell.Dispatch (new Action(fun () -> _rtd.UpdateRange _mnemonic _layout (_format cell.Value _layout))) 

    interface IObserver<System.Collections.Generic.List<'T>> with
        member this.OnCompleted () : unit =
            ignore 1

        member this.OnError (e : Exception) =
            _rtd.UpdateValue _mnemonic _layout (("#" + e.Message) :> obj)

        member this.OnNext (value : System.Collections.Generic.List<'T>) = 
            _rtd.UpdateRange _mnemonic _layout (_format value _layout)

    interface IDisposable with
        member this.Dispose () =
            _holder.Dispose ()

// Summary: bridge to convert observable events to am model update
type RTDModelObserver<'t> (rtd : IValueRTD, model : ICell<'t>, format : ICell<'t> -> string -> obj[,], layout : string) as this =

    let _rtd = rtd
    let _mnemonic = model.Mnemonic
    let _model = model
    let _holder = (model :?> Model).Subscribe(this)
    let _format = format
    let _layout = layout
    do Cell.Dispatch (new Action(fun () -> _rtd.UpdateRange _mnemonic _layout (_format _model layout)))

    interface IObserver<ICell> with
        member this.OnCompleted () : unit =
            ignore 1

        member this.OnError (e : Exception) =
            _rtd.UpdateValue _mnemonic _layout (("#" + e.Message) :> obj)

        member this.OnNext (value : ICell) = 
                _rtd.UpdateRange _mnemonic _layout (_format _model layout)

    interface IDisposable with
        member this.Dispose () =
            _holder.Dispose ()

// Summary: bridge to convert observable events to am model update
type RTDModelRangeObserver<'t> (rtd : IValueRTD, models : Cephei.Cell.List<'t>, format : Cephei.Cell.List<'t> -> string -> obj[,], layout : string) as this =
    let _rtd = rtd
    let _mnemonic = models.Mnemonic
    let _models = models
    let _holders = Seq.map (fun (i : ICell<'t>) -> (i :?> Model).Subscribe(this)) _models |> Seq.toArray
    let _format = format
    let _layout = layout
    do Cell.Dispatch (new Action(fun () -> _rtd.UpdateValue _mnemonic _layout (_format _models layout)))

    interface IObserver<ICell> with
        member this.OnCompleted () : unit =
            ignore 1

        member this.OnError (e : Exception) =
            _rtd.UpdateValue _mnemonic _layout (("#" + e.Message) :> obj)

        member this.OnNext (value : ICell) = 
                _rtd.UpdateRange _mnemonic _layout (_format _models layout)

    interface IDisposable with
        member this.Dispose () =
            _holders |> Array.iter (fun i -> i.Dispose ()) 

