<!DOCTYPE html>
<!--[if IE]><![endif]-->
<html>
  
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <title>Class EurLiborSwapIfrFixModel1
   </title>
    <meta name="viewport" content="width=device-width">
    <meta name="title" content="Class EurLiborSwapIfrFixModel1
   ">
    <meta name="generator" content="docfx 2.56.5.0">
    
    <link rel="shortcut icon" href="../favicon.ico">
    <link rel="stylesheet" href="../styles/docfx.vendor.css">
    <link rel="stylesheet" href="../styles/docfx.css">
    <link rel="stylesheet" href="../styles/main.css">
    <meta property="docfx:navrel" content="../toc.html">
    <meta property="docfx:tocrel" content="toc.html">
    
    
    
  </head>
  <body data-spy="scroll" data-target="#affix" data-offset="120">
    <div id="wrapper">
      <header>
        
        <nav id="autocollapse" class="navbar navbar-inverse ng-scope" role="navigation">
          <div class="container">
            <div class="navbar-header">
              <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#navbar">
                <span class="sr-only">Toggle navigation</span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
              </button>
              
              <a class="navbar-brand" href="../index.html">
                <img id="logo" class="svg" src="../logo.svg" alt="">
              </a>
            </div>
            <div class="collapse navbar-collapse" id="navbar">
              <form class="navbar-form navbar-right" role="search" id="search">
                <div class="form-group">
                  <input type="text" class="form-control" id="search-query" placeholder="Search" autocomplete="off">
                </div>
              </form>
            </div>
          </div>
        </nav>
        
        <div class="subnav navbar navbar-default">
          <div class="container hide-when-search" id="breadcrumb">
            <ul class="breadcrumb">
              <li></li>
            </ul>
          </div>
        </div>
      </header>
      <div role="main" class="container body-content hide-when-search">
        
        <div class="sidenav hide-when-search">
          <a class="btn toc-toggle collapse" data-toggle="collapse" href="#sidetoggle" aria-expanded="false" aria-controls="sidetoggle">Show / Hide Table of Contents</a>
          <div class="sidetoggle collapse" id="sidetoggle">
            <div id="sidetoc"></div>
          </div>
        </div>
        <div class="article row grid-right">
          <div class="col-md-10">
            <article class="content wrap" id="_content" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1">
  
  
  <h1 id="Cephei_QL_EurLiborSwapIfrFixModel1" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1" class="text-break">Class EurLiborSwapIfrFixModel1
  </h1>
  <div class="markdown level0 summary"></div>
  <div class="markdown level0 conceptual"></div>
  <div class="inheritance">
    <h5>Inheritance</h5>
    <div class="level0"><span class="xref">System.Object</span></div>
    <div class="level1"><span class="xref">System.Collections.Concurrent.ConcurrentDictionary</span>&lt;<span class="xref">string</span>,<a class="xref" href="Cephei.Cell.ICell.html">ICell</a>&gt;</div>
    <div class="level2"><a class="xref" href="Cephei.Cell.Model.html">Model</a></div>
    <div class="level3"><a class="xref" href="Cephei.Cell.Generic.Model-1.html">Model</a>&lt;<span class="xref">QLNet.EurLiborSwapIfrFix</span>&gt;</div>
    <div class="level4"><span class="xref">EurLiborSwapIfrFixModel1</span></div>
  </div>
  <div classs="implements">
    <h5>Implements</h5>
    <div><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.EurLiborSwapIfrFix</span>&gt;</div>
    <div><a class="xref" href="Cephei.Cell.ICell.html">ICell</a></div>
    <div><a class="xref" href="Cephei.Cell.ICellEvent.html">ICellEvent</a></div>
    <div><span class="xref">System.Collections.Generic.ICollection</span>&lt;<span class="xref">System.Collections.Generic.KeyValuePair</span>&lt;<span class="xref">string</span>,<a class="xref" href="Cephei.Cell.ICell.html">ICell</a>&gt;&gt;</div>
    <div><span class="xref">System.Collections.Generic.IDictionary</span>&lt;<span class="xref">string</span>,<a class="xref" href="Cephei.Cell.ICell.html">ICell</a>&gt;</div>
    <div><span class="xref">System.Collections.Generic.IEnumerable</span>&lt;<span class="xref">System.Collections.Generic.KeyValuePair</span>&lt;<span class="xref">string</span>,<a class="xref" href="Cephei.Cell.ICell.html">ICell</a>&gt;&gt;</div>
    <div><span class="xref">System.Collections.Generic.IReadOnlyCollection</span>&lt;<span class="xref">System.Collections.Generic.KeyValuePair</span>&lt;<span class="xref">string</span>,<a class="xref" href="Cephei.Cell.ICell.html">ICell</a>&gt;&gt;</div>
    <div><span class="xref">System.Collections.Generic.IReadOnlyDictionary</span>&lt;<span class="xref">string</span>,<a class="xref" href="Cephei.Cell.ICell.html">ICell</a>&gt;</div>
    <div><span class="xref">System.Collections.ICollection</span></div>
    <div><span class="xref">System.Collections.IDictionary</span></div>
    <div><span class="xref">System.Collections.IEnumerable</span></div>
    <div><span class="xref">System.IObservable</span>&lt;<a class="xref" href="Cephei.Cell.ICell.html">ICell</a>&gt;</div>
    <div><span class="xref">System.IObservable</span>&lt;<a class="xref" href="Cephei.Cell.ISession.html">ISession</a> * <a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.EurLiborSwapIfrFix</span>&gt; * <a class="xref" href="Cephei.Cell.CellEvent.html">CellEvent</a> * <a class="xref" href="Cephei.Cell.ICell.html">ICell</a> * <span class="xref">System.DateTime</span>&gt;</div>
    <div><span class="xref">System.IObservable</span>&lt;<a class="xref" href="Cephei.Cell.ISession.html">ISession</a> * <a class="xref" href="Cephei.Cell.Model.html">Model</a> * <a class="xref" href="Cephei.Cell.CellEvent.html">CellEvent</a> * <a class="xref" href="Cephei.Cell.ICell.html">ICell</a> * <span class="xref">System.DateTime</span>&gt;</div>
    <div><span class="xref">System.IObservable</span>&lt;<span class="xref">QLNet.EurLiborSwapIfrFix</span>&gt;</div>
    <div><span class="xref">System.IObservable</span>&lt;<span class="xref">System.Collections.Generic.KeyValuePair</span>&lt;<a class="xref" href="Cephei.Cell.ISession.html">ISession</a>,<span class="xref">System.Collections.Generic.KeyValuePair</span>&lt;<span class="xref">string</span>,<a class="xref" href="Cephei.Cell.ICell.html">ICell</a>&gt;&gt;&gt;</div>
    <div><span class="xref">System.IObservable</span>&lt;<span class="xref">System.Collections.Generic.KeyValuePair</span>&lt;<a class="xref" href="Cephei.Cell.ISession.html">ISession</a>,<span class="xref">System.Collections.Generic.KeyValuePair</span>&lt;<span class="xref">string</span>,<span class="xref">QLNet.EurLiborSwapIfrFix</span>&gt;&gt;&gt;</div>
    <div><span class="xref">System.IObservable</span>&lt;<span class="xref">System.Collections.Generic.KeyValuePair</span>&lt;<span class="xref">string</span>,<span class="xref">decimal</span>&gt;&gt;</div>
    <div><span class="xref">System.IObservable</span>&lt;<span class="xref">System.Collections.Generic.KeyValuePair</span>&lt;<span class="xref">string</span>,<span class="xref">float</span>&gt;&gt;</div>
    <div><span class="xref">System.IObservable</span>&lt;<span class="xref">System.Collections.Generic.KeyValuePair</span>&lt;<span class="xref">string</span>,<span class="xref">int</span>&gt;&gt;</div>
    <div><span class="xref">System.IObserver</span>&lt;<span class="xref">QLNet.EurLiborSwapIfrFix</span>&gt;</div>
  </div>
  <div class="inheritedMembers">
    <h5>Inherited Members</h5>
    <div>
      <span class="xref">member Cephei.Cell.Generic.Model.Bind: Cephei.Cell.Generic.ICell&lt;'T&gt; -&gt; unit</span>
    </div>
    <div>
      <span class="xref">abstract member Cephei.Cell.Generic.Model.OnCompleted: unit -&gt; unit</span>
    </div>
    <div>
      <span class="xref">abstract member Cephei.Cell.Generic.Model.OnError: exn -&gt; unit</span>
    </div>
    <div>
      <span class="xref">abstract member Cephei.Cell.Generic.Model.OnNext: 'T -&gt; unit</span>
    </div>
    <div>
      <span class="xref">abstract member Cephei.Cell.Generic.Model.Subscribe: System.IObserver&lt;'T&gt; -&gt; System.IDisposable</span>
    </div>
    <div>
      <span class="xref">abstract member Cephei.Cell.Generic.Model.Subscribe: System.IObserver&lt;Cephei.Cell.ISession * Cephei.Cell.Generic.ICell&lt;'T&gt; * Cephei.Cell.CellEvent * Cephei.Cell.ICell * System.DateTime&gt; -&gt; System.IDisposable</span>
    </div>
    <div>
      <span class="xref">abstract member Cephei.Cell.Generic.Model.Subscribe: System.IObserver&lt;System.Collections.Generic.KeyValuePair&lt;Cephei.Cell.ISession,System.Collections.Generic.KeyValuePair&lt;string,'T&gt;&gt;&gt; -&gt; System.IDisposable</span>
    </div>
    <div>
      <span class="xref">abstract property Cephei.Cell.Generic.Model.Value: 'T</span>
    </div>
    <div>
      <span class="xref">member Cephei.Cell.Model.As: string -&gt; Cephei.Cell.Generic.ICell&lt;'T&gt;</span>
    </div>
    <div>
      <span class="xref">member Cephei.Cell.Model.Bind: unit -&gt; unit</span>
    </div>
    <div>
      <span class="xref">abstract property Cephei.Cell.Model.Box: obj</span>
    </div>
    <div>
      <span class="xref">abstract member Cephei.Cell.Model.Change: Cephei.Cell.CellChange</span>
    </div>
    <div>
      <span class="xref">member Cephei.Cell.Model.Create: Unit -&gt; 'T * string -&gt; Cephei.Cell.Generic.Cell&lt;'T&gt;</span>
    </div>
    <div>
      <span class="xref">member Cephei.Cell.Model.CreateValue: 'T * string -&gt; Cephei.Cell.Generic.Cell&lt;'T&gt;</span>
    </div>
    <div>
      <span class="xref">abstract property Cephei.Cell.Model.Dependants: System.Collections.Generic.IEnumerable&lt;Cephei.Cell.ICellEvent&gt;</span>
    </div>
    <div>
      <span class="xref">member Cephei.Cell.Model.Dispose: unit -&gt; unit</span>
    </div>
    <div>
      <span class="xref">member Cephei.Cell.Model.GetOrAdd: string * Cephei.Cell.ICell -&gt; Cephei.Cell.ICell</span>
    </div>
    <div>
      <span class="xref">abstract property Cephei.Cell.Model.HasFunction: bool</span>
    </div>
    <div>
      <span class="xref">abstract property Cephei.Cell.Model.HasValue: bool</span>
    </div>
    <div>
      <span class="xref">property Cephei.Cell.Model.Item: string -&gt; Cephei.Cell.ICell</span>
    </div>
    <div>
      <span class="xref">abstract property Cephei.Cell.Model.Mnemonic: string</span>
    </div>
    <div>
      <span class="xref">abstract member Cephei.Cell.Model.OnChange: Cephei.Cell.CellEvent * Cephei.Cell.ICellEvent * System.DateTime * Cephei.Cell.ISession -&gt; unit</span>
    </div>
    <div>
      <span class="xref">abstract property Cephei.Cell.Model.Parent: Cephei.Cell.ICell</span>
    </div>
    <div>
      <span class="xref">abstract member Cephei.Cell.Model.Subscribe: System.IObserver&lt;Cephei.Cell.ICell&gt; -&gt; System.IDisposable</span>
    </div>
    <div>
      <span class="xref">abstract member Cephei.Cell.Model.Subscribe: System.IObserver&lt;Cephei.Cell.ISession * Cephei.Cell.Model * Cephei.Cell.CellEvent * Cephei.Cell.ICell * System.DateTime&gt; -&gt; System.IDisposable</span>
    </div>
    <div>
      <span class="xref">abstract member Cephei.Cell.Model.Subscribe: System.IObserver&lt;System.Collections.Generic.KeyValuePair&lt;Cephei.Cell.ISession,System.Collections.Generic.KeyValuePair&lt;string,Cephei.Cell.ICell&gt;&gt;&gt; -&gt; System.IDisposable</span>
    </div>
    <div>
      <span class="xref">abstract member Cephei.Cell.Model.Subscribe: System.IObserver&lt;System.Collections.Generic.KeyValuePair&lt;string,decimal&gt;&gt; -&gt; System.IDisposable</span>
    </div>
    <div>
      <span class="xref">abstract member Cephei.Cell.Model.Subscribe: System.IObserver&lt;System.Collections.Generic.KeyValuePair&lt;string,float&gt;&gt; -&gt; System.IDisposable</span>
    </div>
    <div>
      <span class="xref">abstract member Cephei.Cell.Model.Subscribe: System.IObserver&lt;System.Collections.Generic.KeyValuePair&lt;string,int&gt;&gt; -&gt; System.IDisposable</span>
    </div>
    <div>
      <span class="xref">member Cephei.Cell.Model.TryAdd: string * Cephei.Cell.ICell -&gt; bool</span>
    </div>
    <div>
      <span class="xref">member Cephei.Cell.Model.TryRemove: string * Cephei.Cell.ICell byref -&gt; bool</span>
    </div>
    <div>
      <span class="xref">member Cephei.Cell.Model.TryUpdate: string * Cephei.Cell.ICell * Cephei.Cell.ICell -&gt; bool</span>
    </div>
    <div>
      <span class="xref">abstract member Cephei.Cell.Model.add_Change: Cephei.Cell.CellChange -&gt; unit</span>
    </div>
    <div>
      <span class="xref">abstract member Cephei.Cell.Model.remove_Change: Cephei.Cell.CellChange -&gt; unit</span>
    </div>
    <div>
      <span class="xref">member System.Collections.Concurrent.ConcurrentDictionary.AddOrUpdate: 'TKey * 'TValue * System.Func&lt;'TKey,'TValue,'TValue&gt; -&gt; 'TValue</span>
    </div>
    <div>
      <span class="xref">member System.Collections.Concurrent.ConcurrentDictionary.AddOrUpdate: 'TKey * System.Func&lt;'TKey,'TValue&gt; * System.Func&lt;'TKey,'TValue,'TValue&gt; -&gt; 'TValue</span>
    </div>
    <div>
      <span class="xref">abstract member System.Collections.Concurrent.ConcurrentDictionary.Clear: unit -&gt; unit</span>
    </div>
    <div>
      <span class="xref">abstract member System.Collections.Concurrent.ConcurrentDictionary.ContainsKey: 'TKey -&gt; bool</span>
    </div>
    <div>
      <span class="xref">abstract property System.Collections.Concurrent.ConcurrentDictionary.Count: int</span>
    </div>
    <div>
      <span class="xref">abstract member System.Collections.Concurrent.ConcurrentDictionary.GetEnumerator: unit -&gt; System.Collections.Generic.IEnumerator&lt;System.Collections.Generic.KeyValuePair&lt;'TKey,'TValue&gt;&gt;</span>
    </div>
    <div>
      <span class="xref">member System.Collections.Concurrent.ConcurrentDictionary.GetOrAdd: 'TKey * 'TValue -&gt; 'TValue</span>
    </div>
    <div>
      <span class="xref">member System.Collections.Concurrent.ConcurrentDictionary.GetOrAdd: 'TKey * System.Func&lt;'TKey,'TValue&gt; -&gt; 'TValue</span>
    </div>
    <div>
      <span class="xref">property System.Collections.Concurrent.ConcurrentDictionary.IsEmpty: bool</span>
    </div>
    <div>
      <span class="xref">abstract property System.Collections.Concurrent.ConcurrentDictionary.Item: 'TKey -&gt; 'TValue</span>
    </div>
    <div>
      <span class="xref">abstract property System.Collections.Concurrent.ConcurrentDictionary.Keys: System.Collections.Generic.ICollection&lt;'TKey&gt;</span>
    </div>
    <div>
      <span class="xref">member System.Collections.Concurrent.ConcurrentDictionary.ToArray: unit -&gt; System.Collections.Generic.KeyValuePair&lt;'TKey,'TValue&gt; []</span>
    </div>
    <div>
      <span class="xref">member System.Collections.Concurrent.ConcurrentDictionary.TryAdd: 'TKey * 'TValue -&gt; bool</span>
    </div>
    <div>
      <span class="xref">abstract member System.Collections.Concurrent.ConcurrentDictionary.TryGetValue: 'TKey * 'TValue byref -&gt; bool</span>
    </div>
    <div>
      <span class="xref">member System.Collections.Concurrent.ConcurrentDictionary.TryRemove: 'TKey * 'TValue byref -&gt; bool</span>
    </div>
    <div>
      <span class="xref">member System.Collections.Concurrent.ConcurrentDictionary.TryUpdate: 'TKey * 'TValue * 'TValue -&gt; bool</span>
    </div>
    <div>
      <span class="xref">abstract property System.Collections.Concurrent.ConcurrentDictionary.Values: System.Collections.Generic.ICollection&lt;'TValue&gt;</span>
    </div>
  </div>
  <h6><strong>Namespace</strong>: <a class="xref" href="Cephei.QL.html">Cephei.QL</a></h6>
  <h6><strong>Assembly</strong>: Cephei.QL.dll</h6>
  <h5 id="Cephei_QL_EurLiborSwapIfrFixModel1_syntax">Syntax</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">[&lt;AutoSerializable(true)&gt;]
type EurLiborSwapIfrFixModel1 (tenor:ICell&lt;Period&gt;)
    inherit Model&lt;EurLiborSwapIfrFix&gt;
    interface IDictionary&lt;string,ICell&gt;
    interface ICollection&lt;KeyValuePair&lt;string,ICell&gt;&gt;
    interface IReadOnlyDictionary&lt;string,ICell&gt;
    interface IReadOnlyCollection&lt;KeyValuePair&lt;string,ICell&gt;&gt;
    interface IEnumerable&lt;KeyValuePair&lt;string,ICell&gt;&gt;
    interface IDictionary
    interface ICollection
    interface IEnumerable
    interface IObservable&lt;ICell&gt;
    interface IObservable&lt;KeyValuePair&lt;ISession,KeyValuePair&lt;string,ICell&gt;&gt;&gt;
    interface IObservable&lt;ISession * Model * CellEvent * ICell * DateTime&gt;
    interface IObservable&lt;KeyValuePair&lt;string,float&gt;&gt;
    interface IObservable&lt;KeyValuePair&lt;string,int&gt;&gt;
    interface IObservable&lt;KeyValuePair&lt;string,decimal&gt;&gt;
    interface ICell&lt;EurLiborSwapIfrFix&gt;
    interface ICell
    interface ICellEvent
    interface IObservable&lt;EurLiborSwapIfrFix&gt;
    interface IObservable&lt;KeyValuePair&lt;ISession,KeyValuePair&lt;string,EurLiborSwapIfrFix&gt;&gt;&gt;
    interface IObservable&lt;ISession * ICell&lt;EurLiborSwapIfrFix&gt; * CellEvent * ICell * DateTime&gt;
    interface IObserver&lt;EurLiborSwapIfrFix&gt;</code></pre>
  </div>
  <h5 class="parameters">Parameters</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Name</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Period</span>&gt;</td>
        <td><span class="parametername">tenor</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h3 id="constructors">Constructors
  </h3>
  
  
  <a id="Cephei_QL_EurLiborSwapIfrFixModel1__ctor_" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.#ctor*"></a>
  <h4 id="Cephei_QL_EurLiborSwapIfrFixModel1__ctor_Cephei_Cell_Generic_ICell_QLNet_Period__" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.#ctor(Cephei.Cell.Generic.ICell&lt;QLNet.Period&gt;)">new: ICell&lt;Period&gt; -&gt; EurLiborSwapIfrFixModel1</h4>
  <div class="markdown level1 summary"><p sourcefile="obj/api/Cephei.QL.EurLiborSwapIfrFixModel1.yml" sourcestartlinenumber="1" sourceendlinenumber="1">Implicit constructor.</p>
</div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">new: tenor:ICell&lt;Period&gt; -&gt; EurLiborSwapIfrFixModel1</code></pre>
  </div>
  <h5 class="parameters">Parameters</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Name</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Period</span>&gt;</td>
        <td><span class="parametername">tenor</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h5 class="returns">Returns</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.QL.EurLiborSwapIfrFixModel1.html">EurLiborSwapIfrFixModel1</a></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h3 id="properties">Properties
  </h3>
  
  
  <a id="Cephei_QL_EurLiborSwapIfrFixModel1_AllowsNativeFixings_" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.AllowsNativeFixings*"></a>
  <h4 id="Cephei_QL_EurLiborSwapIfrFixModel1_AllowsNativeFixings_unit_" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.AllowsNativeFixings(unit)">property AllowsNativeFixings: ICell&lt;bool&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property AllowsNativeFixings: ICell&lt;bool&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">bool</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_EurLiborSwapIfrFixModel1_ClearFixings_" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.ClearFixings*"></a>
  <h4 id="Cephei_QL_EurLiborSwapIfrFixModel1_ClearFixings_unit_" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.ClearFixings(unit)">property ClearFixings: ICell&lt;EurLiborSwapIfrFix&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property ClearFixings: ICell&lt;EurLiborSwapIfrFix&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.EurLiborSwapIfrFix</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_EurLiborSwapIfrFixModel1_Currency_" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.Currency*"></a>
  <h4 id="Cephei_QL_EurLiborSwapIfrFixModel1_Currency_unit_" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.Currency(unit)">property Currency: ICell&lt;Currency&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property Currency: ICell&lt;Currency&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Currency</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_EurLiborSwapIfrFixModel1_DayCounter_" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.DayCounter*"></a>
  <h4 id="Cephei_QL_EurLiborSwapIfrFixModel1_DayCounter_unit_" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.DayCounter(unit)">property DayCounter: ICell&lt;DayCounter&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property DayCounter: ICell&lt;DayCounter&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.DayCounter</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_EurLiborSwapIfrFixModel1_DiscountingTermStructure_" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.DiscountingTermStructure*"></a>
  <h4 id="Cephei_QL_EurLiborSwapIfrFixModel1_DiscountingTermStructure_unit_" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.DiscountingTermStructure(unit)">property DiscountingTermStructure: ICell&lt;Handle&lt;YieldTermStructure&gt;&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property DiscountingTermStructure: ICell&lt;Handle&lt;YieldTermStructure&gt;&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Handle</span>&lt;<span class="xref">QLNet.YieldTermStructure</span>&gt;&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_EurLiborSwapIfrFixModel1_ExogenousDiscount_" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.ExogenousDiscount*"></a>
  <h4 id="Cephei_QL_EurLiborSwapIfrFixModel1_ExogenousDiscount_unit_" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.ExogenousDiscount(unit)">property ExogenousDiscount: ICell&lt;bool&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property ExogenousDiscount: ICell&lt;bool&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">bool</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_EurLiborSwapIfrFixModel1_FamilyName_" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.FamilyName*"></a>
  <h4 id="Cephei_QL_EurLiborSwapIfrFixModel1_FamilyName_unit_" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.FamilyName(unit)">property FamilyName: ICell&lt;string&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property FamilyName: ICell&lt;string&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">string</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_EurLiborSwapIfrFixModel1_FixedLegConvention_" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.FixedLegConvention*"></a>
  <h4 id="Cephei_QL_EurLiborSwapIfrFixModel1_FixedLegConvention_unit_" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.FixedLegConvention(unit)">property FixedLegConvention: ICell&lt;BusinessDayConvention&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property FixedLegConvention: ICell&lt;BusinessDayConvention&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.BusinessDayConvention</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_EurLiborSwapIfrFixModel1_FixedLegTenor_" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.FixedLegTenor*"></a>
  <h4 id="Cephei_QL_EurLiborSwapIfrFixModel1_FixedLegTenor_unit_" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.FixedLegTenor(unit)">property FixedLegTenor: ICell&lt;Period&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property FixedLegTenor: ICell&lt;Period&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Period</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_EurLiborSwapIfrFixModel1_FixingCalendar_" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.FixingCalendar*"></a>
  <h4 id="Cephei_QL_EurLiborSwapIfrFixModel1_FixingCalendar_unit_" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.FixingCalendar(unit)">property FixingCalendar: ICell&lt;Calendar&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property FixingCalendar: ICell&lt;Calendar&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Calendar</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_EurLiborSwapIfrFixModel1_FixingDays_" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.FixingDays*"></a>
  <h4 id="Cephei_QL_EurLiborSwapIfrFixModel1_FixingDays_unit_" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.FixingDays(unit)">property FixingDays: ICell&lt;int&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property FixingDays: ICell&lt;int&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">int</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_EurLiborSwapIfrFixModel1_ForwardingTermStructure_" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.ForwardingTermStructure*"></a>
  <h4 id="Cephei_QL_EurLiborSwapIfrFixModel1_ForwardingTermStructure_unit_" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.ForwardingTermStructure(unit)">property ForwardingTermStructure: ICell&lt;Handle&lt;YieldTermStructure&gt;&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property ForwardingTermStructure: ICell&lt;Handle&lt;YieldTermStructure&gt;&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Handle</span>&lt;<span class="xref">QLNet.YieldTermStructure</span>&gt;&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_EurLiborSwapIfrFixModel1_IborIndex_" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.IborIndex*"></a>
  <h4 id="Cephei_QL_EurLiborSwapIfrFixModel1_IborIndex_unit_" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.IborIndex(unit)">property IborIndex: ICell&lt;IborIndex&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property IborIndex: ICell&lt;IborIndex&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.IborIndex</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_EurLiborSwapIfrFixModel1_Name_" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.Name*"></a>
  <h4 id="Cephei_QL_EurLiborSwapIfrFixModel1_Name_unit_" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.Name(unit)">property Name: ICell&lt;string&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property Name: ICell&lt;string&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">string</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_EurLiborSwapIfrFixModel1_tenor_" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.tenor*"></a>
  <h4 id="Cephei_QL_EurLiborSwapIfrFixModel1_tenor_unit_" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.tenor(unit)">property tenor: ICell&lt;Period&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property tenor: ICell&lt;Period&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Period</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_EurLiborSwapIfrFixModel1_Tenor_" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.Tenor*"></a>
  <h4 id="Cephei_QL_EurLiborSwapIfrFixModel1_Tenor_unit_" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.Tenor(unit)">property Tenor: ICell&lt;Period&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property Tenor: ICell&lt;Period&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Period</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_EurLiborSwapIfrFixModel1_TimeSeries_" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.TimeSeries*"></a>
  <h4 id="Cephei_QL_EurLiborSwapIfrFixModel1_TimeSeries_unit_" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.TimeSeries(unit)">property TimeSeries: ICell&lt;TimeSeries&lt;Nullable&lt;float&gt;&gt;&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property TimeSeries: ICell&lt;TimeSeries&lt;Nullable&lt;float&gt;&gt;&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.TimeSeries</span>&lt;<span class="xref">System.Nullable</span>&lt;<span class="xref">float</span>&gt;&gt;&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_EurLiborSwapIfrFixModel1_Update_" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.Update*"></a>
  <h4 id="Cephei_QL_EurLiborSwapIfrFixModel1_Update_unit_" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.Update(unit)">property Update: ICell&lt;EurLiborSwapIfrFix&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property Update: ICell&lt;EurLiborSwapIfrFix&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.EurLiborSwapIfrFix</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h3 id="methods">Methods
  </h3>
  
  
  <a id="Cephei_QL_EurLiborSwapIfrFixModel1_AddFixing_" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.AddFixing*"></a>
  <h4 id="Cephei_QL_EurLiborSwapIfrFixModel1_AddFixing_Cephei_Cell_Generic_ICell_QLNet_Date_____Cephei_Cell_Generic_ICell_double_____Cephei_Cell_Generic_ICell_bool__" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.AddFixing(Cephei.Cell.Generic.ICell&lt;QLNet.Date&gt; -&gt; Cephei.Cell.Generic.ICell&lt;double&gt; -&gt; Cephei.Cell.Generic.ICell&lt;bool&gt;)">member AddFixing: ICell&lt;Date&gt; -&gt; ICell&lt;double&gt; -&gt; ICell&lt;bool&gt; -&gt; ICell&lt;EurLiborSwapIfrFix&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">member AddFixing: d:ICell&lt;Date&gt; -&gt; v:ICell&lt;double&gt; -&gt; forceOverwrite:ICell&lt;bool&gt; -&gt; ICell&lt;EurLiborSwapIfrFix&gt;</code></pre>
  </div>
  <h5 class="parameters">Parameters</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Name</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Date</span>&gt;</td>
        <td><span class="parametername">d</span></td>
        <td></td>
      </tr>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">double</span>&gt;</td>
        <td><span class="parametername">v</span></td>
        <td></td>
      </tr>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">bool</span>&gt;</td>
        <td><span class="parametername">forceOverwrite</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h5 class="returns">Returns</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.EurLiborSwapIfrFix</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_EurLiborSwapIfrFixModel1_AddFixings_" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.AddFixings*"></a>
  <h4 id="Cephei_QL_EurLiborSwapIfrFixModel1_AddFixings_Cephei_Cell_Generic_ICell_System_Collections_Generic_List_QLNet_Date______Cephei_Cell_Generic_ICell_System_Collections_Generic_List_double______Cephei_Cell_Generic_ICell_bool__" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.AddFixings(Cephei.Cell.Generic.ICell&lt;System.Collections.Generic.List&lt;QLNet.Date&gt;&gt; -&gt; Cephei.Cell.Generic.ICell&lt;System.Collections.Generic.List&lt;double&gt;&gt; -&gt; Cephei.Cell.Generic.ICell&lt;bool&gt;)">member AddFixings: ICell&lt;List&lt;Date&gt;&gt; -&gt; ICell&lt;List&lt;double&gt;&gt; -&gt; ICell&lt;bool&gt; -&gt; ICell&lt;EurLiborSwapIfrFix&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">member AddFixings: d:ICell&lt;List&lt;Date&gt;&gt; -&gt; v:ICell&lt;List&lt;double&gt;&gt; -&gt; forceOverwrite:ICell&lt;bool&gt; -&gt; ICell&lt;EurLiborSwapIfrFix&gt;</code></pre>
  </div>
  <h5 class="parameters">Parameters</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Name</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">System.Collections.Generic.List</span>&lt;<span class="xref">QLNet.Date</span>&gt;&gt;</td>
        <td><span class="parametername">d</span></td>
        <td></td>
      </tr>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">System.Collections.Generic.List</span>&lt;<span class="xref">double</span>&gt;&gt;</td>
        <td><span class="parametername">v</span></td>
        <td></td>
      </tr>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">bool</span>&gt;</td>
        <td><span class="parametername">forceOverwrite</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h5 class="returns">Returns</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.EurLiborSwapIfrFix</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_EurLiborSwapIfrFixModel1_AddFixings1_" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.AddFixings1*"></a>
  <h4 id="Cephei_QL_EurLiborSwapIfrFixModel1_AddFixings1_Cephei_Cell_Generic_ICell_QLNet_TimeSeries_System_Nullable_double_______Cephei_Cell_Generic_ICell_bool__" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.AddFixings1(Cephei.Cell.Generic.ICell&lt;QLNet.TimeSeries&lt;System.Nullable&lt;double&gt;&gt;&gt; -&gt; Cephei.Cell.Generic.ICell&lt;bool&gt;)">member AddFixings1: ICell&lt;TimeSeries&lt;Nullable&lt;double&gt;&gt;&gt; -&gt; ICell&lt;bool&gt; -&gt; ICell&lt;EurLiborSwapIfrFix&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">member AddFixings1: source:ICell&lt;TimeSeries&lt;Nullable&lt;double&gt;&gt;&gt; -&gt; forceOverwrite:ICell&lt;bool&gt; -&gt; ICell&lt;EurLiborSwapIfrFix&gt;</code></pre>
  </div>
  <h5 class="parameters">Parameters</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Name</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.TimeSeries</span>&lt;<span class="xref">System.Nullable</span>&lt;<span class="xref">double</span>&gt;&gt;&gt;</td>
        <td><span class="parametername">source</span></td>
        <td></td>
      </tr>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">bool</span>&gt;</td>
        <td><span class="parametername">forceOverwrite</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h5 class="returns">Returns</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.EurLiborSwapIfrFix</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_EurLiborSwapIfrFixModel1_Clone_" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.Clone*"></a>
  <h4 id="Cephei_QL_EurLiborSwapIfrFixModel1_Clone_Cephei_Cell_Generic_ICell_QLNet_Period__" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.Clone(Cephei.Cell.Generic.ICell&lt;QLNet.Period&gt;)">member Clone: ICell&lt;Period&gt; -&gt; ICell&lt;SwapIndex&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">member Clone: tenor:ICell&lt;Period&gt; -&gt; ICell&lt;SwapIndex&gt;</code></pre>
  </div>
  <h5 class="parameters">Parameters</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Name</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Period</span>&gt;</td>
        <td><span class="parametername">tenor</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h5 class="returns">Returns</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.SwapIndex</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_EurLiborSwapIfrFixModel1_Clone1_" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.Clone1*"></a>
  <h4 id="Cephei_QL_EurLiborSwapIfrFixModel1_Clone1_Cephei_Cell_Generic_ICell_QLNet_Handle_QLNet_YieldTermStructure______Cephei_Cell_Generic_ICell_QLNet_Handle_QLNet_YieldTermStructure___" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.Clone1(Cephei.Cell.Generic.ICell&lt;QLNet.Handle&lt;QLNet.YieldTermStructure&gt;&gt; -&gt; Cephei.Cell.Generic.ICell&lt;QLNet.Handle&lt;QLNet.YieldTermStructure&gt;&gt;)">member Clone1: ICell&lt;Handle&lt;YieldTermStructure&gt;&gt; -&gt; ICell&lt;Handle&lt;YieldTermStructure&gt;&gt; -&gt; ICell&lt;SwapIndex&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">member Clone1: forwarding:ICell&lt;Handle&lt;YieldTermStructure&gt;&gt; -&gt; discounting:ICell&lt;Handle&lt;YieldTermStructure&gt;&gt; -&gt; ICell&lt;SwapIndex&gt;</code></pre>
  </div>
  <h5 class="parameters">Parameters</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Name</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Handle</span>&lt;<span class="xref">QLNet.YieldTermStructure</span>&gt;&gt;</td>
        <td><span class="parametername">forwarding</span></td>
        <td></td>
      </tr>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Handle</span>&lt;<span class="xref">QLNet.YieldTermStructure</span>&gt;&gt;</td>
        <td><span class="parametername">discounting</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h5 class="returns">Returns</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.SwapIndex</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_EurLiborSwapIfrFixModel1_Clone2_" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.Clone2*"></a>
  <h4 id="Cephei_QL_EurLiborSwapIfrFixModel1_Clone2_Cephei_Cell_Generic_ICell_QLNet_Handle_QLNet_YieldTermStructure___" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.Clone2(Cephei.Cell.Generic.ICell&lt;QLNet.Handle&lt;QLNet.YieldTermStructure&gt;&gt;)">member Clone2: ICell&lt;Handle&lt;YieldTermStructure&gt;&gt; -&gt; ICell&lt;SwapIndex&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">member Clone2: forwarding:ICell&lt;Handle&lt;YieldTermStructure&gt;&gt; -&gt; ICell&lt;SwapIndex&gt;</code></pre>
  </div>
  <h5 class="parameters">Parameters</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Name</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Handle</span>&lt;<span class="xref">QLNet.YieldTermStructure</span>&gt;&gt;</td>
        <td><span class="parametername">forwarding</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h5 class="returns">Returns</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.SwapIndex</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_EurLiborSwapIfrFixModel1_Fixing_" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.Fixing*"></a>
  <h4 id="Cephei_QL_EurLiborSwapIfrFixModel1_Fixing_Cephei_Cell_Generic_ICell_QLNet_Date_____Cephei_Cell_Generic_ICell_bool__" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.Fixing(Cephei.Cell.Generic.ICell&lt;QLNet.Date&gt; -&gt; Cephei.Cell.Generic.ICell&lt;bool&gt;)">member Fixing: ICell&lt;Date&gt; -&gt; ICell&lt;bool&gt; -&gt; ICell&lt;float&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">member Fixing: fixingDate:ICell&lt;Date&gt; -&gt; forecastTodaysFixing:ICell&lt;bool&gt; -&gt; ICell&lt;float&gt;</code></pre>
  </div>
  <h5 class="parameters">Parameters</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Name</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Date</span>&gt;</td>
        <td><span class="parametername">fixingDate</span></td>
        <td></td>
      </tr>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">bool</span>&gt;</td>
        <td><span class="parametername">forecastTodaysFixing</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h5 class="returns">Returns</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">float</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_EurLiborSwapIfrFixModel1_FixingDate_" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.FixingDate*"></a>
  <h4 id="Cephei_QL_EurLiborSwapIfrFixModel1_FixingDate_Cephei_Cell_Generic_ICell_QLNet_Date__" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.FixingDate(Cephei.Cell.Generic.ICell&lt;QLNet.Date&gt;)">member FixingDate: ICell&lt;Date&gt; -&gt; ICell&lt;Date&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">member FixingDate: valueDate:ICell&lt;Date&gt; -&gt; ICell&lt;Date&gt;</code></pre>
  </div>
  <h5 class="parameters">Parameters</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Name</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Date</span>&gt;</td>
        <td><span class="parametername">valueDate</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h5 class="returns">Returns</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Date</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_EurLiborSwapIfrFixModel1_ForecastFixing_" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.ForecastFixing*"></a>
  <h4 id="Cephei_QL_EurLiborSwapIfrFixModel1_ForecastFixing_Cephei_Cell_Generic_ICell_QLNet_Date__" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.ForecastFixing(Cephei.Cell.Generic.ICell&lt;QLNet.Date&gt;)">member ForecastFixing: ICell&lt;Date&gt; -&gt; ICell&lt;float&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">member ForecastFixing: fixingDate:ICell&lt;Date&gt; -&gt; ICell&lt;float&gt;</code></pre>
  </div>
  <h5 class="parameters">Parameters</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Name</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Date</span>&gt;</td>
        <td><span class="parametername">fixingDate</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h5 class="returns">Returns</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">float</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_EurLiborSwapIfrFixModel1_IsValidFixingDate_" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.IsValidFixingDate*"></a>
  <h4 id="Cephei_QL_EurLiborSwapIfrFixModel1_IsValidFixingDate_Cephei_Cell_Generic_ICell_QLNet_Date__" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.IsValidFixingDate(Cephei.Cell.Generic.ICell&lt;QLNet.Date&gt;)">member IsValidFixingDate: ICell&lt;Date&gt; -&gt; ICell&lt;bool&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">member IsValidFixingDate: fixingDate:ICell&lt;Date&gt; -&gt; ICell&lt;bool&gt;</code></pre>
  </div>
  <h5 class="parameters">Parameters</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Name</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Date</span>&gt;</td>
        <td><span class="parametername">fixingDate</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h5 class="returns">Returns</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">bool</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_EurLiborSwapIfrFixModel1_MaturityDate_" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.MaturityDate*"></a>
  <h4 id="Cephei_QL_EurLiborSwapIfrFixModel1_MaturityDate_Cephei_Cell_Generic_ICell_QLNet_Date__" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.MaturityDate(Cephei.Cell.Generic.ICell&lt;QLNet.Date&gt;)">member MaturityDate: ICell&lt;Date&gt; -&gt; ICell&lt;Date&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">member MaturityDate: valueDate:ICell&lt;Date&gt; -&gt; ICell&lt;Date&gt;</code></pre>
  </div>
  <h5 class="parameters">Parameters</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Name</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Date</span>&gt;</td>
        <td><span class="parametername">valueDate</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h5 class="returns">Returns</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Date</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_EurLiborSwapIfrFixModel1_PastFixing_" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.PastFixing*"></a>
  <h4 id="Cephei_QL_EurLiborSwapIfrFixModel1_PastFixing_Cephei_Cell_Generic_ICell_QLNet_Date__" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.PastFixing(Cephei.Cell.Generic.ICell&lt;QLNet.Date&gt;)">member PastFixing: ICell&lt;Date&gt; -&gt; ICell&lt;Nullable&lt;float&gt;&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">member PastFixing: fixingDate:ICell&lt;Date&gt; -&gt; ICell&lt;Nullable&lt;float&gt;&gt;</code></pre>
  </div>
  <h5 class="parameters">Parameters</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Name</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Date</span>&gt;</td>
        <td><span class="parametername">fixingDate</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h5 class="returns">Returns</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">System.Nullable</span>&lt;<span class="xref">float</span>&gt;&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_EurLiborSwapIfrFixModel1_RegisterWith_" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.RegisterWith*"></a>
  <h4 id="Cephei_QL_EurLiborSwapIfrFixModel1_RegisterWith_Cephei_Cell_Generic_ICell_QLNet_Callback__" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.RegisterWith(Cephei.Cell.Generic.ICell&lt;QLNet.Callback&gt;)">member RegisterWith: ICell&lt;Callback&gt; -&gt; ICell&lt;EurLiborSwapIfrFix&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">member RegisterWith: handler:ICell&lt;Callback&gt; -&gt; ICell&lt;EurLiborSwapIfrFix&gt;</code></pre>
  </div>
  <h5 class="parameters">Parameters</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Name</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Callback</span>&gt;</td>
        <td><span class="parametername">handler</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h5 class="returns">Returns</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.EurLiborSwapIfrFix</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_EurLiborSwapIfrFixModel1_UnderlyingSwap_" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.UnderlyingSwap*"></a>
  <h4 id="Cephei_QL_EurLiborSwapIfrFixModel1_UnderlyingSwap_Cephei_Cell_Generic_ICell_QLNet_Date__" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.UnderlyingSwap(Cephei.Cell.Generic.ICell&lt;QLNet.Date&gt;)">member UnderlyingSwap: ICell&lt;Date&gt; -&gt; ICell&lt;VanillaSwap&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">member UnderlyingSwap: fixingDate:ICell&lt;Date&gt; -&gt; ICell&lt;VanillaSwap&gt;</code></pre>
  </div>
  <h5 class="parameters">Parameters</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Name</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Date</span>&gt;</td>
        <td><span class="parametername">fixingDate</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h5 class="returns">Returns</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.VanillaSwap</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_EurLiborSwapIfrFixModel1_UnregisterWith_" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.UnregisterWith*"></a>
  <h4 id="Cephei_QL_EurLiborSwapIfrFixModel1_UnregisterWith_Cephei_Cell_Generic_ICell_QLNet_Callback__" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.UnregisterWith(Cephei.Cell.Generic.ICell&lt;QLNet.Callback&gt;)">member UnregisterWith: ICell&lt;Callback&gt; -&gt; ICell&lt;EurLiborSwapIfrFix&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">member UnregisterWith: handler:ICell&lt;Callback&gt; -&gt; ICell&lt;EurLiborSwapIfrFix&gt;</code></pre>
  </div>
  <h5 class="parameters">Parameters</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Name</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Callback</span>&gt;</td>
        <td><span class="parametername">handler</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h5 class="returns">Returns</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.EurLiborSwapIfrFix</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_EurLiborSwapIfrFixModel1_ValueDate_" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.ValueDate*"></a>
  <h4 id="Cephei_QL_EurLiborSwapIfrFixModel1_ValueDate_Cephei_Cell_Generic_ICell_QLNet_Date__" data-uid="Cephei.QL.EurLiborSwapIfrFixModel1.ValueDate(Cephei.Cell.Generic.ICell&lt;QLNet.Date&gt;)">member ValueDate: ICell&lt;Date&gt; -&gt; ICell&lt;Date&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">member ValueDate: fixingDate:ICell&lt;Date&gt; -&gt; ICell&lt;Date&gt;</code></pre>
  </div>
  <h5 class="parameters">Parameters</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Name</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Date</span>&gt;</td>
        <td><span class="parametername">fixingDate</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h5 class="returns">Returns</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Date</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h3 id="implements">Implements</h3>
  <div>
      <span class="xref">Cephei.Cell.Generic.ICell&lt;QLNet.EurLiborSwapIfrFix&gt;</span>
  </div>
  <div>
      <span class="xref">Cephei.Cell.ICell</span>
  </div>
  <div>
      <span class="xref">Cephei.Cell.ICellEvent</span>
  </div>
  <div>
      <span class="xref">System.Collections.Generic.ICollection&lt;System.Collections.Generic.KeyValuePair&lt;string,Cephei.Cell.ICell&gt;&gt;</span>
  </div>
  <div>
      <span class="xref">System.Collections.Generic.IDictionary&lt;string,Cephei.Cell.ICell&gt;</span>
  </div>
  <div>
      <span class="xref">System.Collections.Generic.IEnumerable&lt;System.Collections.Generic.KeyValuePair&lt;string,Cephei.Cell.ICell&gt;&gt;</span>
  </div>
  <div>
      <span class="xref">System.Collections.Generic.IReadOnlyCollection&lt;System.Collections.Generic.KeyValuePair&lt;string,Cephei.Cell.ICell&gt;&gt;</span>
  </div>
  <div>
      <span class="xref">System.Collections.Generic.IReadOnlyDictionary&lt;string,Cephei.Cell.ICell&gt;</span>
  </div>
  <div>
      <span class="xref">System.Collections.ICollection</span>
  </div>
  <div>
      <span class="xref">System.Collections.IDictionary</span>
  </div>
  <div>
      <span class="xref">System.Collections.IEnumerable</span>
  </div>
  <div>
      <span class="xref">System.IObservable&lt;Cephei.Cell.ICell&gt;</span>
  </div>
  <div>
      <span class="xref">System.IObservable&lt;Cephei.Cell.ISession * Cephei.Cell.Generic.ICell&lt;QLNet.EurLiborSwapIfrFix&gt; * Cephei.Cell.CellEvent * Cephei.Cell.ICell * System.DateTime&gt;</span>
  </div>
  <div>
      <span class="xref">System.IObservable&lt;Cephei.Cell.ISession * Cephei.Cell.Model * Cephei.Cell.CellEvent * Cephei.Cell.ICell * System.DateTime&gt;</span>
  </div>
  <div>
      <span class="xref">System.IObservable&lt;QLNet.EurLiborSwapIfrFix&gt;</span>
  </div>
  <div>
      <span class="xref">System.IObservable&lt;System.Collections.Generic.KeyValuePair&lt;Cephei.Cell.ISession,System.Collections.Generic.KeyValuePair&lt;string,Cephei.Cell.ICell&gt;&gt;&gt;</span>
  </div>
  <div>
      <span class="xref">System.IObservable&lt;System.Collections.Generic.KeyValuePair&lt;Cephei.Cell.ISession,System.Collections.Generic.KeyValuePair&lt;string,QLNet.EurLiborSwapIfrFix&gt;&gt;&gt;</span>
  </div>
  <div>
      <span class="xref">System.IObservable&lt;System.Collections.Generic.KeyValuePair&lt;string,decimal&gt;&gt;</span>
  </div>
  <div>
      <span class="xref">System.IObservable&lt;System.Collections.Generic.KeyValuePair&lt;string,float&gt;&gt;</span>
  </div>
  <div>
      <span class="xref">System.IObservable&lt;System.Collections.Generic.KeyValuePair&lt;string,int&gt;&gt;</span>
  </div>
  <div>
      <span class="xref">System.IObserver&lt;QLNet.EurLiborSwapIfrFix&gt;</span>
  </div>
</article>
          </div>
          
          <div class="hidden-sm col-md-2" role="complementary">
            <div class="sideaffix">
              <div class="contribution">
                <ul class="nav">
                </ul>
              </div>
              <nav class="bs-docs-sidebar hidden-print hidden-xs hidden-sm affix" id="affix">
                <h5>In This Article</h5>
                <div></div>
              </nav>
            </div>
          </div>
        </div>
      </div>
      
      <footer>
        <div class="grad-bottom"></div>
        <div class="footer">
          <div class="container">
            <span class="pull-right">
              <a href="#top">Back to top</a>
            </span>
            
            <span>Generated by <strong>DocFX</strong></span>
          </div>
        </div>
      </footer>
    </div>
    
    <script type="text/javascript" src="../styles/docfx.vendor.js"></script>
    <script type="text/javascript" src="../styles/docfx.js"></script>
    <script type="text/javascript" src="../styles/main.js"></script>
  </body>
</html>