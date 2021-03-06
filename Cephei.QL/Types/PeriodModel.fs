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


  </summary> *)
[<AutoSerializable(true)>]
type PeriodModel
    ( n                                            : ICell<int>
    , u                                            : ICell<TimeUnit>
    ) as this =

    inherit Model<Period> ()
(*
    Parameters
*)
    let _n                                         = n
    let _u                                         = u
(*
    Functions
*)
    let mutable
        _Period                                    = make (fun () -> new Period (n.Value, u.Value))
    let _CompareTo                                 (obj : ICell<Object>)   
                                                   = triv _Period (fun () -> _Period.Value.CompareTo(obj.Value))
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv _Period (fun () -> _Period.Value.Equals(o.Value))
    let _frequency                                 = triv _Period (fun () -> _Period.Value.frequency())
    let _length                                    = triv _Period (fun () -> _Period.Value.length())
    let _normalize                                 = triv _Period (fun () -> _Period.Value.normalize()
                                                                             _Period.Value)
    let _ToShortString                             = triv _Period (fun () -> _Period.Value.ToShortString())
    let _ToString                                  = triv _Period (fun () -> _Period.Value.ToString())
    let _units                                     = triv _Period (fun () -> _Period.Value.units())
    do this.Bind(_Period)
(* 
    casting 
*)
    internal new () = new PeriodModel(null,null)
    member internal this.Inject v = _Period <- v
    static member Cast (p : ICell<Period>) = 
        if p :? PeriodModel then 
            p :?> PeriodModel
        else
            let o = new PeriodModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.n                                  = _n 
    member this.u                                  = _u 
    member this.CompareTo                          obj   
                                                   = _CompareTo obj 
    member this.Equals                             o   
                                                   = _Equals o 
    member this.Frequency                          = _frequency
    member this.Length                             = _length
    member this.Normalize                          = _normalize
    member this.ToShortString                      = _ToShortString
    member this.ToString                           = _ToString
    member this.Units                              = _units
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type PeriodModel1
    () as this =
    inherit Model<Period> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _Period                                    = make (fun () -> new Period ())
    let _CompareTo                                 (obj : ICell<Object>)   
                                                   = triv _Period (fun () -> _Period.Value.CompareTo(obj.Value))
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv _Period (fun () -> _Period.Value.Equals(o.Value))
    let _frequency                                 = triv _Period (fun () -> _Period.Value.frequency())
    let _length                                    = triv _Period (fun () -> _Period.Value.length())
    let _normalize                                 = triv _Period (fun () -> _Period.Value.normalize()
                                                                             _Period.Value)
    let _ToShortString                             = triv _Period (fun () -> _Period.Value.ToShortString())
    let _ToString                                  = triv _Period (fun () -> _Period.Value.ToString())
    let _units                                     = triv _Period (fun () -> _Period.Value.units())
    do this.Bind(_Period)
(* 
    casting 
*)
    
    member internal this.Inject v = _Period <- v
    static member Cast (p : ICell<Period>) = 
        if p :? PeriodModel1 then 
            p :?> PeriodModel1
        else
            let o = new PeriodModel1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.CompareTo                          obj   
                                                   = _CompareTo obj 
    member this.Equals                             o   
                                                   = _Equals o 
    member this.Frequency                          = _frequency
    member this.Length                             = _length
    member this.Normalize                          = _normalize
    member this.ToShortString                      = _ToShortString
    member this.ToString                           = _ToString
    member this.Units                              = _units
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type PeriodModel2
    ( f                                            : ICell<Frequency>
    ) as this =

    inherit Model<Period> ()
(*
    Parameters
*)
    let _f                                         = f
(*
    Functions
*)
    let mutable
        _Period                                    = make (fun () -> new Period (f.Value))
    let _CompareTo                                 (obj : ICell<Object>)   
                                                   = triv _Period (fun () -> _Period.Value.CompareTo(obj.Value))
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv _Period (fun () -> _Period.Value.Equals(o.Value))
    let _frequency                                 = triv _Period (fun () -> _Period.Value.frequency())
    let _length                                    = triv _Period (fun () -> _Period.Value.length())
    let _normalize                                 = triv _Period (fun () -> _Period.Value.normalize()
                                                                             _Period.Value)
    let _ToShortString                             = triv _Period (fun () -> _Period.Value.ToShortString())
    let _ToString                                  = triv _Period (fun () -> _Period.Value.ToString())
    let _units                                     = triv _Period (fun () -> _Period.Value.units())
    do this.Bind(_Period)
(* 
    casting 
*)
    internal new () = new PeriodModel2(null)
    member internal this.Inject v = _Period <- v
    static member Cast (p : ICell<Period>) = 
        if p :? PeriodModel2 then 
            p :?> PeriodModel2
        else
            let o = new PeriodModel2 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.f                                  = _f 
    member this.CompareTo                          obj   
                                                   = _CompareTo obj 
    member this.Equals                             o   
                                                   = _Equals o 
    member this.Frequency                          = _frequency
    member this.Length                             = _length
    member this.Normalize                          = _normalize
    member this.ToShortString                      = _ToShortString
    member this.ToString                           = _ToString
    member this.Units                              = _units
(* <summary>

Create from a string like "1M", "2Y"...
  </summary> *)
[<AutoSerializable(true)>]
type PeriodModel3
    ( periodString                                 : ICell<string>
    ) as this =

    inherit Model<Period> ()
(*
    Parameters
*)
    let _periodString                              = periodString
(*
    Functions
*)
    let mutable
        _Period                                    = make (fun () -> new Period (periodString.Value))
    let _CompareTo                                 (obj : ICell<Object>)   
                                                   = triv _Period (fun () -> _Period.Value.CompareTo(obj.Value))
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv _Period (fun () -> _Period.Value.Equals(o.Value))
    let _frequency                                 = triv _Period (fun () -> _Period.Value.frequency())
    let _length                                    = triv _Period (fun () -> _Period.Value.length())
    let _normalize                                 = triv _Period (fun () -> _Period.Value.normalize()
                                                                             _Period.Value)
    let _ToShortString                             = triv _Period (fun () -> _Period.Value.ToShortString())
    let _ToString                                  = triv _Period (fun () -> _Period.Value.ToString())
    let _units                                     = triv _Period (fun () -> _Period.Value.units())
    do this.Bind(_Period)
(* 
    casting 
*)
    internal new () = new PeriodModel3(null)
    member internal this.Inject v = _Period <- v
    static member Cast (p : ICell<Period>) = 
        if p :? PeriodModel3 then 
            p :?> PeriodModel3
        else
            let o = new PeriodModel3 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.periodString                       = _periodString 
    member this.CompareTo                          obj   
                                                   = _CompareTo obj 
    member this.Equals                             o   
                                                   = _Equals o 
    member this.Frequency                          = _frequency
    member this.Length                             = _length
    member this.Normalize                          = _normalize
    member this.ToShortString                      = _ToShortString
    member this.ToString                           = _ToString
    member this.Units                              = _units
