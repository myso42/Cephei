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
  Chilean peso   The ISO three-letter code is CLP; the numeric code is 152. It is divided in 100 centavos.  currencies

  </summary> *)
[<AutoSerializable(true)>]
type CLPCurrencyModel
    () as this =
    inherit Model<CLPCurrency> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _CLPCurrency                               = make (fun () -> new CLPCurrency ())
    let _code                                      = triv _CLPCurrency (fun () -> _CLPCurrency.Value.code)
    let _empty                                     = triv _CLPCurrency (fun () -> _CLPCurrency.Value.empty())
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv _CLPCurrency (fun () -> _CLPCurrency.Value.Equals(o.Value))
    let _format                                    = triv _CLPCurrency (fun () -> _CLPCurrency.Value.format)
    let _fractionsPerUnit                          = triv _CLPCurrency (fun () -> _CLPCurrency.Value.fractionsPerUnit)
    let _fractionSymbol                            = triv _CLPCurrency (fun () -> _CLPCurrency.Value.fractionSymbol)
    let _name                                      = triv _CLPCurrency (fun () -> _CLPCurrency.Value.name)
    let _numericCode                               = triv _CLPCurrency (fun () -> _CLPCurrency.Value.numericCode)
    let _rounding                                  = triv _CLPCurrency (fun () -> _CLPCurrency.Value.rounding)
    let _symbol                                    = triv _CLPCurrency (fun () -> _CLPCurrency.Value.symbol)
    let _ToString                                  = triv _CLPCurrency (fun () -> _CLPCurrency.Value.ToString())
    let _triangulationCurrency                     = triv _CLPCurrency (fun () -> _CLPCurrency.Value.triangulationCurrency)
    do this.Bind(_CLPCurrency)
(* 
    casting 
*)
    
    member internal this.Inject v = _CLPCurrency <- v
    static member Cast (p : ICell<CLPCurrency>) = 
        if p :? CLPCurrencyModel then 
            p :?> CLPCurrencyModel
        else
            let o = new CLPCurrencyModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Code                               = _code
    member this.Empty                              = _empty
    member this.Equals                             o   
                                                   = _Equals o 
    member this.Format                             = _format
    member this.FractionsPerUnit                   = _fractionsPerUnit
    member this.FractionSymbol                     = _fractionSymbol
    member this.Name                               = _name
    member this.NumericCode                        = _numericCode
    member this.Rounding                           = _rounding
    member this.Symbol                             = _symbol
    member this.ToString                           = _ToString
    member this.TriangulationCurrency              = _triangulationCurrency
