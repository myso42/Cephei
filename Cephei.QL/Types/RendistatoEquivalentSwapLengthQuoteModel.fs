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
  RendistatoCalculator equivalent swap lenth Quote adapter

  </summary> *)
[<AutoSerializable(true)>]
type RendistatoEquivalentSwapLengthQuoteModel
    ( r                                            : ICell<RendistatoCalculator>
    ) as this =

    inherit Model<RendistatoEquivalentSwapLengthQuote> ()
(*
    Parameters
*)
    let _r                                         = r
(*
    Functions
*)
    let mutable
        _RendistatoEquivalentSwapLengthQuote       = make (fun () -> new RendistatoEquivalentSwapLengthQuote (r.Value))
    let _isValid                                   = triv _RendistatoEquivalentSwapLengthQuote (fun () -> _RendistatoEquivalentSwapLengthQuote.Value.isValid())
    let _value                                     = triv _RendistatoEquivalentSwapLengthQuote (fun () -> _RendistatoEquivalentSwapLengthQuote.Value.value())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _RendistatoEquivalentSwapLengthQuote (fun () -> _RendistatoEquivalentSwapLengthQuote.Value.registerWith(handler.Value)
                                                                                                          _RendistatoEquivalentSwapLengthQuote.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _RendistatoEquivalentSwapLengthQuote (fun () -> _RendistatoEquivalentSwapLengthQuote.Value.unregisterWith(handler.Value)
                                                                                                          _RendistatoEquivalentSwapLengthQuote.Value)
    do this.Bind(_RendistatoEquivalentSwapLengthQuote)
(* 
    casting 
*)
    internal new () = new RendistatoEquivalentSwapLengthQuoteModel(null)
    member internal this.Inject v = _RendistatoEquivalentSwapLengthQuote <- v
    static member Cast (p : ICell<RendistatoEquivalentSwapLengthQuote>) = 
        if p :? RendistatoEquivalentSwapLengthQuoteModel then 
            p :?> RendistatoEquivalentSwapLengthQuoteModel
        else
            let o = new RendistatoEquivalentSwapLengthQuoteModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.r                                  = _r 
    member this.IsValid                            = _isValid
    member this.Value                              = _value
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
