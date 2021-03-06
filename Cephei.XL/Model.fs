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
open System.Threading
open System.Threading.Tasks

module public  Model =

    let kv (k:'k) (v:'v) = new System.Collections.Generic.KeyValuePair<'k,'v>(k,v)
    // apply a generic format for conversion to Excel types
    let rec genericFormat (o : obj) : obj =
        try
            let enumerate (e : IEnumerable) = 
                let i = e.GetEnumerator()
                seq {while i.MoveNext() do i.Current} 
            let trim o =
                let min a b = if a < b then a else b
                let s = o.ToString()
                if s = null then
                    null
                elif s = "" then
                    s
                elif s.StartsWith(",") then
                    s.Substring(1,min (s.Length - 1) 254)
                else
                    s.Substring(0,min s.Length 255)
            match o with
            | null -> null
            | :? double -> o 
            | :? int -> o
            | :? string -> trim o :> obj
            | :? DateTime as d -> d.ToOADate() :> obj
            | :? QLNet.Date as d -> d.serialNumber() :> obj
            | :? Enum as e -> e.ToString() :> obj
            | :? IEnumerable as e -> trim (enumerate e |> Seq.fold (fun a y -> a + "," + (genericFormat y).ToString()) "") :> obj
            | :? ICell as c -> genericFormat c.Box
            | _ -> trim (o.ToString()) :> obj
        with 
        | e -> "#" + e.Message :> obj

    let formatMnemonic (s : string) =
        let str = 
            if s = null || s = "" then 
                let reference = ExcelDna.Integration.XlCall.Excel(ExcelDna.Integration.XlCall.xlfCaller) :?> ExcelDna.Integration.ExcelReference
                let cellReference = ExcelDna.Integration.XlCall.Excel(ExcelDna.Integration.XlCall.xlfAddress, 1+reference.RowFirst, 1+reference.ColumnFirst).ToString()
                let sheetName = ExcelDna.Integration.XlCall.Excel(ExcelDna.Integration.XlCall.xlSheetNm, reference).ToString()
                sheetName + cellReference 
            else
                s
        let filter = 
            str.ToCharArray() |>
            Array.filter (fun i -> Char.IsLetterOrDigit (i) && not (i = '.'))
        if Char.IsDigit( filter.[0]) then
            "N" + new string (filter);
        else
            if str.StartsWith("+") then 
                "+" + (new string (filter))
            elif str.StartsWith("-") then
                "-" + (new string (filter))
            else
                new string (filter)

    let getState () = 
        let modelName = "ModelState"
        let mutable state = AppDomain.CurrentDomain.GetData(modelName)
        if state = null then
            state <- new ModelState ()
            AppDomain.CurrentDomain.SetData(modelName, state)
        state :?> ModelState

    let _state = lazy getState()

    let setRange m l o =
        _state.Value.Ranges.[kv m l] <- o

    let hasRange m l =
        _state.Value.Ranges.ContainsKey (kv m l)

    let clearRange s =
        _state.Value.Ranges |> 
        Seq.filter (fun i -> i.Key.Key = s) |>
        Seq.toList |>
        List.iter (fun i -> _state.Value.Ranges.TryRemove( i.Key) |> ignore)

    let mutable xlInterface             = (new ExcelInterface (setRange) ) :> IExcelInterace

    let IsInFunctionWizard () = 
        xlInterface.IsInFunctionWizard ()

    // Subscribe to the objct 
    let subscribe (rtd : IValueRTD) (mnemonic : string) (layout : string) = 
        if _state.Value.Subscriber.ContainsKey (mnemonic) then 

            let f = _state.Value.Subscriber.[mnemonic]
            let c = _state.Value.Model.[mnemonic]
            let d = f rtd c layout
            d
        else
            null :> IDisposable

    let add (s: string) = 
        if _state.Value.Rtd.ContainsKey(s) then
            let sub = _state.Value.Rtd.[s]
            let current = 
                if (_state.Value.Model.ContainsKey (sub.mnemonic)) then 
                    _state.Value.Model.[sub.mnemonic]
                else
                    null :> ICell
            let cell = 
                let c = sub.creator(current)
                if c :? ITrivial then 
                    let t = c :?> ITrivial
                    t.ToCell ()
                else
                    c
            _state.Value.Rtd.TryRemove (s) |> ignore
            cell.Mnemonic <- sub.mnemonic
            if (not (current = null)) && cell.GetType() = current.GetType() && not (current :? ICellModel) then
                current.Merge(cell, _state.Value.Model)
                _state.Value.Source.[sub.mnemonic] <- sub.source()

            elif not (current = cell) then 
                _state.Value.Model.[sub.mnemonic] <- cell
                _state.Value.Source.[sub.mnemonic] <- sub.source()
                _state.Value.Subscriber.[sub.mnemonic] <- sub.subscriber
                if not (current = null) then 
                    current.Dispose() 
                cell.OnChange(CellEvent.Calculate, cell, cell, DateTime.Now, null)

    // Register a functor to create a cell if requried
    let specify (spec : spec) : obj =
        _state.Value.Rtd.[spec.mnemonic] <- spec
        let xlv = 
            if _state.Value.Model.ContainsKey(spec.mnemonic) && _state.Value.Model.[spec.mnemonic].State = CellState.Error then
                xlInterface.ModelRTD spec.mnemonic (spec.hash.ToString() + "#") // + DateTime.Now.Ticks.ToString()) // force recalc if there is an error
            else
                xlInterface.ModelRTD spec.mnemonic (spec.hash.ToString()) 
        if xlv = null then 
            add spec.mnemonic |> ignore
            spec.mnemonic :> obj
        else
            xlv

    // Register and get the value of a single obj
    let value (mnemonic : string) : obj =
        if not (mnemonic.StartsWith("#")) then
            let xlv = xlInterface.ValueRTD mnemonic ""
            if xlv = null then 
                add mnemonic |> ignore
                genericFormat (_state.Value.Model.[mnemonic].Box)
            else
                xlv
        else
            "#+" + mnemonic :> obj
            

    // Register and get the value from a range
    let range (mnemonic : string) (layout : string) : obj[,] =
        let k = kv mnemonic layout
        let xlv = xlInterface.ValueRTD mnemonic layout 
        if _state.Value.Ranges.ContainsKey(k) then
                _state.Value.Ranges.[k]
        else 
            Array2D.create<obj> 1 1 "#NoValue"

    let remove s = 
        if _state.Value.Model.ContainsKey(s) then
            let cell = _state.Value.Model.[s]
            let mutable cell2 = cell
            if _state.Value.Model.TryRemove (s, ref cell2) then
                if not (cell = null) then
                    cell.Dependants|> Seq.iter (fun d -> if not (d = null) then d.OnChange (CellEvent.Delete, cell, cell, DateTime.Now, null ))
                    cell.Dispose ()
                _state.Value.Source.TryRemove s |> ignore
                _state.Value.Subscriber.TryRemove s |> ignore

    let cell mnemonic : ICell option = 
        let m = _state.Value.Model
        if m.ContainsKey(mnemonic) then 
            Some m.[mnemonic]
        else 
            None

    let contains mnemonic = 
        _state.Value.Model.ContainsKey mnemonic

    let dependancyMatrix () = 
    (*
        let rec deps (cell : ICell) : string list = 
            cell.Dependants
            |> Seq.filter (fun i -> i :? ICell)
            |> Seq.map (fun i -> i :?> ICell)
            |> Seq.fold (fun a y -> [y.Mnemonic + "/" + y.GetType().ToString() + "/" + y.GetHashCode().ToString()] @ a) []

        let depens = 
            _state.Value.Model
            |> Seq.map (fun i -> if i.Value :? ICellModel then new KeyValuePair<string, ICell>(i.Key, (i.Value :?> ICellModel).Cell) else i)
            |> Seq.map (fun i -> (i.Key + "/" + i.Value.GetType().ToString() + "/" + i.Value.GetHashCode().ToString() , (deps i.Value)))
            |> Seq.toList
            |> List.sortBy (fun i -> (fst i).ToUpper())
*)
        let rec deps (cell : ICell) : string list = 
            cell.Dependants
            |> Seq.filter (fun i -> i :? ICell)
            |> Seq.map (fun i -> i :?> ICell)
            |> Seq.fold (fun a y -> [y.Mnemonic] @ a) []

        let depens = 
            _state.Value.Model
            // |> Seq.map (fun i -> if i.Value :? ICellModel then new KeyValuePair<string, ICell>(i.Key, (i.Value :?> ICellModel).Subject) else i)
            |> Seq.map (fun i -> (i.Key, (deps i.Value)))
            |> Seq.toList
            |> List.sortBy (fun i -> (fst i).ToUpper())

        let size = 
            let max a b = if a > b then a else b
            depens 
            |> List.fold (fun (r,c) (n,l) -> ((r + 1), max (List.length l) c)) (0,0)

        let range = Array2D.create<obj> (fst size) ((snd size) + 1) null

        let listtorow (c : string) (l : string list) (r : int) =
            l |> List.iteri (fun i s -> Array2D.set range r (i + 1) (s :> obj))
            Array2D.set range r 0 (c :> obj)

        depens
        |> List.iteri (fun i (s,l) ->  listtorow s l i )

        range

    let sourcecode (name : string) = 
        let modelName = if name.ToLower().EndsWith("model") then name else name + "Model"
        let tieredCells (model : Model) =

            let mem = new Dictionary<string, int>()

            let uppack (c : ICell) = 
                c.Dependants
                |> Seq.filter (fun i -> i :? ICell)
                |> Seq.map (fun i -> i :?> ICell)
                |> Seq.filter (fun i -> not (i.Mnemonic = null || i.Mnemonic = c.Mnemonic))
                |> Seq.map (fun i -> i.Mnemonic)
                |> Seq.filter (fun i -> _state.Value.Source.ContainsKey(i))
                |> Seq.toArray

            let mapper = 
                model
                |> Seq.map (fun i -> (i.Key,uppack i.Value))
                |> Map.ofSeq

            let memorise f s (sl : string array) =
                match (mem.ContainsKey(s)) with
                | true  -> mem.[s]
                | _     -> let r = f s sl
                           mem.[s] <- r
                           r

            let rec depth (s : string) (sl : string array) =
                sl 
                |> Array.fold (fun a y -> a + 1 + memorise depth y mapper.[y]) 0
                
            model 
            |> Seq.map (fun i -> (i.Value, memorise depth i.Key mapper.[i.Key]))
            |> Seq.toArray 
            |> Array.sortBy (fun (c,d) -> (d,c.Mnemonic))
            |> Array.rev

        let tiers = 
            tieredCells _state.Value.Model

        let strip (s : string) = 
            if s.StartsWith("+") || s.StartsWith("-") then 
                s.Substring(1)
            else    
                s

        let typeString (c : ICell) =
            let rec genericTypeString (t : Type) =
                if t.IsGenericType then
                    let p  = 
                        t.GetGenericArguments()
                        |> Array.fold (fun a y -> a + "," + (genericTypeString y)) ""
                    let q = 
                        t.ToString().Split('`').[0]
                    q + "<" + p.Substring(1) + ">"
                else
                    t.ToString()
            let t = c.GetType()
            if t.IsGenericType then
                genericTypeString (t.GetGenericArguments().[0])
            else
                t.ToString();

        let cells = 
            tiers |>
            Array.filter (fun (c,d) -> not(c.Mnemonic = null) && _state.Value.Source.ContainsKey c.Mnemonic) |>
            Array.map (fun (c,d) -> (c, _state.Value.Source.[c.Mnemonic]))

        let constructors = 
            match fst   (
                        cells |>
                        Array.filter (fun (c,s) -> c.Mnemonic.StartsWith("+")) |>
                        Array.map (fun (c,s) -> sprintf "%s : ICell<%s>\n" (strip c.Mnemonic) (typeString c)) |>
                        Array.fold (fun (s,d) y -> (s + "    " + d + y,", ")) ("", "( ") 
                        ) with
            | "" -> "    ("
            | s -> s

        let functions =
            cells |> 
            Array.map (fun (c,s) -> sprintf "    let _%s = %s\n" (strip c.Mnemonic) (if c.Mnemonic.StartsWith("+") then (strip c.Mnemonic) else s)) |>
            Array.fold (fun a y -> a + y) "\n(* functions *)\n"

        let members = 
            cells |> 
            Array.filter (fun (c,s) -> not (c.Mnemonic.StartsWith ("-"))) |>
            Array.map (fun (c,s) -> sprintf "    member this.%s = _%s\n" (strip c.Mnemonic) (strip c.Mnemonic)) |>
            Array.fold (fun a y -> a + y) "\n(* Externally visible/bindable properties *)\n"

        let excelParameters = 
            cells |>
            Array.filter (fun (c,s) -> c.Mnemonic.StartsWith("+")) |>
            Array.map (fun (c,s) -> sprintf "        ([<ExcelArgument(Name=\"%s\",Description = \"reference to %s\")>]\n        %s : obj)\n" (strip c.Mnemonic) (typeString c) (strip c.Mnemonic)) |>
            Array.fold (fun a y -> a + y) ""

        let excelCasts = 
            cells |>
            Array.filter (fun (c,s) -> c.Mnemonic.StartsWith("+")) |>
            Array.map (fun (c,s) -> sprintf "                let _%s = Helper.toCell<%s> %s \"%s\"\n" (strip c.Mnemonic) (typeString c) (strip c.Mnemonic) (strip c.Mnemonic)) |>
            Array.fold (fun a y -> a + y) ""

        let excelBuilder = 
            let mutable delim = "("
            let apply (c : ICell,s)  = 
                let r = sprintf "                                                                        %s _%s.cell\n" delim (strip c.Mnemonic)
                delim <- ","
                r 
            let s = 
                cells |>
                Array.filter (fun (c,s) -> (c.Mnemonic.StartsWith("+"))) |>
                Array.map apply |>
                Array.fold (fun a y -> a + y) ""
            if s = "" then 
                "                                                            ()\n" 
            else
                s + ")"
                
        let excelsource : string = 
            let buff = 
                fst (
                    cells |>
                    Array.filter (fun (c,s) -> c.Mnemonic.StartsWith("+")) |>
                    Array.map (fun (c,s) -> sprintf "_%s.source\n" (strip c.Mnemonic)) |>
                    Array.fold (fun (s,d) y -> (s + "                                               " + d + y,";  ")) ("", "[| ") 
                    )
            if buff = "" then 
                "                                               [|"
            else
                buff

        let excelhash = 
            let buff = 
                fst (
                    cells |>
                    Array.filter (fun (c,s) -> (c.Mnemonic.StartsWith("+"))) |>
                    Array.map (fun (c,s) -> sprintf "_%s.cell\n" (strip c.Mnemonic)) |>
                    Array.fold (fun (s,d) y -> (s + "                                " + d + y,";  ")) ("", "[| ") 
                    )
            if buff = "" then 
                "                                [|"
            else
                buff

        let formatProperty (n : string) (p : string) (t : string) (m : string)= 
            String.Format ("
    [<ExcelFunction(Name=\"__{0}_{1}\", Description=\"Create a {2}\",Category=\"Cephei Models\", IsThreadSafe = false, IsExceptionSafe=true)>]
    let {0}_{1}
        ([<ExcelArgument(Name=\"Mnemonic\",Description = \"Identifer for the Cell\")>] 
         mnemonic : string)
        ([<ExcelArgument(Name=\"{0}\",Description = \"{0}\")>] 
         {0} : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _{0} = Helper.toModel<{3}, obj> {0} \"{0}\"  
                let builder (current : ICell) = (_{0}.cell :?> {3}).{1} :> ICell
                let format (o : {2}) (l:string) = Model.genericFormat o
                let source () = (_{0}.source + \".{1}\")
                let hash = Helper.hashFold [| _{0}.cell |]
                Model.specify 
                    {{ mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    }} :?> string
            with
            | _ as e ->  \"#\" + e.Message
        else
            \"<WIZ>\"
                            ", n, p, t, m)

        let excelProperties = 
            cells |>
            Array.filter (fun (c,s) -> not (c.Mnemonic.StartsWith("-") || c.Mnemonic.StartsWith("+"))) |>
            Array.map (fun (c,s) -> formatProperty name c.Mnemonic (typeString c) modelName) |>
            Array.fold (fun a y -> a + y) ""


        String.Format ("
namespace Cephei.Models

open QLNet
open Cephei.QL
open Cephei.QL.Util
open Cephei.Cell
open Cephei.Cell.Generic
open System
open System.Collections

type {10} 
{1}    ) as this =
    inherit Model<obj> ()
{2}
    do this.Bind (null)
{3}

#if EXCEL

open ExcelDna.Integration
open Cephei.XL
open Cephei.XL.Helper

module {10}Function =

    [<ExcelFunction(Name=\"__{0}\", Description=\"Create a {0}\",Category=\"Cephei Models\", IsThreadSafe = false, IsExceptionSafe=true)>]
    let {0}_create
        ([<ExcelArgument(Name=\"Mnemonic\",Description = \"Identifer for the value\")>] 
         mnemonic : string)
{4}
        = 
        if not (Model.IsInFunctionWizard()) then
            try
{5}
                let builder (current : ICell) = (new {10}
{6}
                                                                      ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> {10}) l
                let source () = Helper.sourceFold \"new {0}\"
{7}                                               |]

                let hash = Helper.hashFold
{8}                                |]
                Model.specify 
                    {{ mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<{0}> format
                    ; source = source 
                    ; hash = hash
                    }} :?> string
                        with
                        | _ as e ->  \"#\" + e.Message
        else
            \"<WIZ>\"
{9}
#endif
", (*0*)name, (*1*)constructors, (*2*)functions, (*3*)members, (*4*)excelParameters, (*5*)excelCasts, (*6*)excelBuilder, (*7*)excelsource, (*8*)excelhash, (*9*)excelProperties, (*10*)modelName )
