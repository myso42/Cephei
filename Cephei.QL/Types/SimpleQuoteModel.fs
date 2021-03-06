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
namespace Cephei.QL

open System
open Cephei.QL.Util
open Cephei.Cell
open Cephei.Cell.Generic
open System.Collections
open System.Collections.Generic
open QLNet
open Cephei.QLNetHelper

(* <summary>
simple quote class   market element returning a stored value

  </summary> *)
[<AutoSerializable(true)>]
type SimpleQuoteModel
    () as this =
    inherit Model<SimpleQuote> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _SimpleQuote                               = make (fun () -> new SimpleQuote ())
    let _isValid                                   = triv _SimpleQuote (fun () -> _SimpleQuote.Value.isValid())
    let _reset                                     = triv _SimpleQuote (fun () -> _SimpleQuote.Value.reset()
                                                                                  _SimpleQuote.Value)
    let _setValue                                  (value : ICell<Nullable<double>>)   
                                                   = triv _SimpleQuote (fun () -> _SimpleQuote.Value.setValue(value.Value))
    let _value                                     = triv _SimpleQuote (fun () -> _SimpleQuote.Value.value())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _SimpleQuote (fun () -> _SimpleQuote.Value.registerWith(handler.Value)
                                                                                  _SimpleQuote.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _SimpleQuote (fun () -> _SimpleQuote.Value.unregisterWith(handler.Value)
                                                                                  _SimpleQuote.Value)
    do this.Bind(_SimpleQuote)
(* 
    casting 
*)
    
    member internal this.Inject v = _SimpleQuote <- v
    static member Cast (p : ICell<SimpleQuote>) = 
        if p :? SimpleQuoteModel then 
            p :?> SimpleQuoteModel
        else
            let o = new SimpleQuoteModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.IsValid                            = _isValid
    member this.Reset                              = _reset
    member this.SetValue                           value   
                                                   = _setValue value 
    member this.Value                              = _value
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
(* <summary>
simple quote class   market element returning a stored value

  </summary> *)
[<AutoSerializable(true)>]
type SimpleQuoteModel1
    ( value                                        : ICell<Nullable<double>>
    ) as this =

    inherit Model<SimpleQuote> ()
(*
    Parameters
*)
    let _value                                     = value
(*
    Functions
*)
    let mutable
        _SimpleQuote                               = make (fun () -> new SimpleQuote (value.Value))
    let _isValid                                   = triv _SimpleQuote (fun () -> _SimpleQuote.Value.isValid())
    let _reset                                     = triv _SimpleQuote (fun () -> _SimpleQuote.Value.reset()
                                                                                  _SimpleQuote.Value)
    let _setValue                                  (value : ICell<Nullable<double>>)   
                                                   = triv _SimpleQuote (fun () -> _SimpleQuote.Value.setValue(value.Value))
    let _value                                     = triv _SimpleQuote (fun () -> _SimpleQuote.Value.value())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _SimpleQuote (fun () -> _SimpleQuote.Value.registerWith(handler.Value)
                                                                                  _SimpleQuote.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _SimpleQuote (fun () -> _SimpleQuote.Value.unregisterWith(handler.Value)
                                                                                  _SimpleQuote.Value)
    do this.Bind(_SimpleQuote)
(* 
    casting 
*)
    internal new () = new SimpleQuoteModel1(null)
    member internal this.Inject v = _SimpleQuote <- v
    static member Cast (p : ICell<SimpleQuote>) = 
        if p :? SimpleQuoteModel1 then 
            p :?> SimpleQuoteModel1
        else
            let o = new SimpleQuoteModel1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.value                              = _value 
    member this.IsValid                            = _isValid
    member this.Reset                              = _reset
    member this.SetValue                           value   
                                                   = _setValue value 
    member this.Value                              = _value
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
