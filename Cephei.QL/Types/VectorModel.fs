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
type VectorModel
    () as this =
    inherit Model<Vector> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _Vector                                    = make (fun () -> new Vector ())
    let _Clone                                     = triv _Vector (fun () -> _Vector.Value.Clone())
    let _empty                                     = triv _Vector (fun () -> _Vector.Value.empty())
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv _Vector (fun () -> _Vector.Value.Equals(o.Value))
    let _Equals1                                   (other : ICell<Vector>)   
                                                   = triv _Vector (fun () -> _Vector.Value.Equals(other.Value))
    let _size                                      = triv _Vector (fun () -> _Vector.Value.size())
    let _swap                                      (i1 : ICell<int>) (i2 : ICell<int>)   
                                                   = triv _Vector (fun () -> _Vector.Value.swap(i1.Value, i2.Value)
                                                                             _Vector.Value)
    do this.Bind(_Vector)
(* 
    casting 
*)
    
    member internal this.Inject v = _Vector <- v
    static member Cast (p : ICell<Vector>) = 
        if p :? VectorModel then 
            p :?> VectorModel
        else
            let o = new VectorModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Clone                              = _Clone
    member this.Empty                              = _empty
    member this.Equals                             o   
                                                   = _Equals o 
    member this.Equals1                            other   
                                                   = _Equals1 other 
    member this.Size                               = _size
    member this.Swap                               i1 i2   
                                                   = _swap i1 i2 
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type VectorModel1
    ( from                                         : ICell<Generic.List<double>>
    ) as this =

    inherit Model<Vector> ()
(*
    Parameters
*)
    let _from                                      = from
(*
    Functions
*)
    let mutable
        _Vector                                    = make (fun () -> new Vector (from.Value))
    let _Clone                                     = triv _Vector (fun () -> _Vector.Value.Clone())
    let _empty                                     = triv _Vector (fun () -> _Vector.Value.empty())
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv _Vector (fun () -> _Vector.Value.Equals(o.Value))
    let _Equals1                                   (other : ICell<Vector>)   
                                                   = triv _Vector (fun () -> _Vector.Value.Equals(other.Value))
    let _size                                      = triv _Vector (fun () -> _Vector.Value.size())
    let _swap                                      (i1 : ICell<int>) (i2 : ICell<int>)   
                                                   = triv _Vector (fun () -> _Vector.Value.swap(i1.Value, i2.Value)
                                                                             _Vector.Value)
    do this.Bind(_Vector)
(* 
    casting 
*)
    internal new () = new VectorModel1(null)
    member internal this.Inject v = _Vector <- v
    static member Cast (p : ICell<Vector>) = 
        if p :? VectorModel1 then 
            p :?> VectorModel1
        else
            let o = new VectorModel1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.from                               = _from 
    member this.Clone                              = _Clone
    member this.Empty                              = _empty
    member this.Equals                             o   
                                                   = _Equals o 
    member this.Equals1                            other   
                                                   = _Equals1 other 
    member this.Size                               = _size
    member this.Swap                               i1 i2   
                                                   = _swap i1 i2 
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type VectorModel2
    ( from                                         : ICell<Vector>
    ) as this =

    inherit Model<Vector> ()
(*
    Parameters
*)
    let _from                                      = from
(*
    Functions
*)
    let mutable
        _Vector                                    = make (fun () -> new Vector (from.Value))
    let _Clone                                     = triv _Vector (fun () -> _Vector.Value.Clone())
    let _empty                                     = triv _Vector (fun () -> _Vector.Value.empty())
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv _Vector (fun () -> _Vector.Value.Equals(o.Value))
    let _Equals1                                   (other : ICell<Vector>)   
                                                   = triv _Vector (fun () -> _Vector.Value.Equals(other.Value))
    let _size                                      = triv _Vector (fun () -> _Vector.Value.size())
    let _swap                                      (i1 : ICell<int>) (i2 : ICell<int>)   
                                                   = triv _Vector (fun () -> _Vector.Value.swap(i1.Value, i2.Value)
                                                                             _Vector.Value)
    do this.Bind(_Vector)
(* 
    casting 
*)
    internal new () = new VectorModel2(null)
    member internal this.Inject v = _Vector <- v
    static member Cast (p : ICell<Vector>) = 
        if p :? VectorModel2 then 
            p :?> VectorModel2
        else
            let o = new VectorModel2 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.from                               = _from 
    member this.Clone                              = _Clone
    member this.Empty                              = _empty
    member this.Equals                             o   
                                                   = _Equals o 
    member this.Equals1                            other   
                                                   = _Equals1 other 
    member this.Size                               = _size
    member this.Swap                               i1 i2   
                                                   = _swap i1 i2 
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type VectorModel3
    ( size                                         : ICell<int>
    , value                                        : ICell<double>
    , increment                                    : ICell<double>
    ) as this =

    inherit Model<Vector> ()
(*
    Parameters
*)
    let _size                                      = size
    let _value                                     = value
    let _increment                                 = increment
(*
    Functions
*)
    let mutable
        _Vector                                    = make (fun () -> new Vector (size.Value, value.Value, increment.Value))
    let _Clone                                     = triv _Vector (fun () -> _Vector.Value.Clone())
    let _empty                                     = triv _Vector (fun () -> _Vector.Value.empty())
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv _Vector (fun () -> _Vector.Value.Equals(o.Value))
    let _Equals1                                   (other : ICell<Vector>)   
                                                   = triv _Vector (fun () -> _Vector.Value.Equals(other.Value))
    let _size                                      = triv _Vector (fun () -> _Vector.Value.size())
    let _swap                                      (i1 : ICell<int>) (i2 : ICell<int>)   
                                                   = triv _Vector (fun () -> _Vector.Value.swap(i1.Value, i2.Value)
                                                                             _Vector.Value)
    do this.Bind(_Vector)
(* 
    casting 
*)
    internal new () = new VectorModel3(null,null,null)
    member internal this.Inject v = _Vector <- v
    static member Cast (p : ICell<Vector>) = 
        if p :? VectorModel3 then 
            p :?> VectorModel3
        else
            let o = new VectorModel3 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.size                               = _size 
    member this.value                              = _value 
    member this.increment                          = _increment 
    member this.Clone                              = _Clone
    member this.Empty                              = _empty
    member this.Equals                             o   
                                                   = _Equals o 
    member this.Equals1                            other   
                                                   = _Equals1 other 
    member this.Size                               = _size
    member this.Swap                               i1 i2   
                                                   = _swap i1 i2 
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type VectorModel4
    ( size                                         : ICell<int>
    ) as this =

    inherit Model<Vector> ()
(*
    Parameters
*)
    let _size                                      = size
(*
    Functions
*)
    let mutable
        _Vector                                    = make (fun () -> new Vector (size.Value))
    let _Clone                                     = triv _Vector (fun () -> _Vector.Value.Clone())
    let _empty                                     = triv _Vector (fun () -> _Vector.Value.empty())
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv _Vector (fun () -> _Vector.Value.Equals(o.Value))
    let _Equals1                                   (other : ICell<Vector>)   
                                                   = triv _Vector (fun () -> _Vector.Value.Equals(other.Value))
    let _size                                      = triv _Vector (fun () -> _Vector.Value.size())
    let _swap                                      (i1 : ICell<int>) (i2 : ICell<int>)   
                                                   = triv _Vector (fun () -> _Vector.Value.swap(i1.Value, i2.Value)
                                                                             _Vector.Value)
    do this.Bind(_Vector)
(* 
    casting 
*)
    internal new () = new VectorModel4(null)
    member internal this.Inject v = _Vector <- v
    static member Cast (p : ICell<Vector>) = 
        if p :? VectorModel4 then 
            p :?> VectorModel4
        else
            let o = new VectorModel4 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.size                               = _size 
    member this.Clone                              = _Clone
    member this.Empty                              = _empty
    member this.Equals                             o   
                                                   = _Equals o 
    member this.Equals1                            other   
                                                   = _Equals1 other 
    member this.Size                               = _size
    member this.Swap                               i1 i2   
                                                   = _swap i1 i2 
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type VectorModel5
    ( size                                         : ICell<int>
    , value                                        : ICell<double>
    ) as this =

    inherit Model<Vector> ()
(*
    Parameters
*)
    let _size                                      = size
    let _value                                     = value
(*
    Functions
*)
    let mutable
        _Vector                                    = make (fun () -> new Vector (size.Value, value.Value))
    let _Clone                                     = triv _Vector (fun () -> _Vector.Value.Clone())
    let _empty                                     = triv _Vector (fun () -> _Vector.Value.empty())
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv _Vector (fun () -> _Vector.Value.Equals(o.Value))
    let _Equals1                                   (other : ICell<Vector>)   
                                                   = triv _Vector (fun () -> _Vector.Value.Equals(other.Value))
    let _size                                      = triv _Vector (fun () -> _Vector.Value.size())
    let _swap                                      (i1 : ICell<int>) (i2 : ICell<int>)   
                                                   = triv _Vector (fun () -> _Vector.Value.swap(i1.Value, i2.Value)
                                                                             _Vector.Value)
    do this.Bind(_Vector)
(* 
    casting 
*)
    internal new () = new VectorModel5(null,null)
    member internal this.Inject v = _Vector <- v
    static member Cast (p : ICell<Vector>) = 
        if p :? VectorModel5 then 
            p :?> VectorModel5
        else
            let o = new VectorModel5 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.size                               = _size 
    member this.value                              = _value 
    member this.Clone                              = _Clone
    member this.Empty                              = _empty
    member this.Equals                             o   
                                                   = _Equals o 
    member this.Equals1                            other   
                                                   = _Equals1 other 
    member this.Size                               = _size
    member this.Swap                               i1 i2   
                                                   = _swap i1 i2 
