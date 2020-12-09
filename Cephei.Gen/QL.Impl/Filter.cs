﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Cephei.Gen
{
    using System.IO;
    using System.Text;
    using System.Collections.Generic;
    using Cephei.Gen.Model;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Users\steve\Source\Repos\Cephei2\Cephei.Gen\QL.Impl\Filter.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class Filter : FilterBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            
            #line 1 "C:\Users\steve\Source\Repos\Cephei2\Cephei.Gen\QL.Impl\Filter.tt"
/* 
Name:			Filter.tt
Author:         Stephen Channell
Description:    Gnenerate the filter file for C++ projects
*/
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 19 "C:\Users\steve\Source\Repos\Cephei2\Cephei.Gen\QL.Impl\Filter.tt"

    
    Context.RootName = RootPackageName;
    Context.Prefix = "I";
    Context.Suffix = ""; 
    Context.ClassDelimiter = ".";

            
            #line default
            #line hidden
            this.Write(@"<?xml version=""1.0"" encoding=""utf-8""?>
<Project ToolsVersion=""4.0"" xmlns=""http://schemas.microsoft.com/developer/msbuild/2003"">
  <ItemGroup>
    <Filter Include=""Source Files"">
      <UniqueIdentifier>{4FC737F1-C7A5-4376-A066-2A32D752A2FF}</UniqueIdentifier>
      <Extensions>cpp;c;cc;cxx;def;odl;idl;hpj;bat;asm;asmx</Extensions>
    </Filter>
    <Filter Include=""Header Files"">
      <UniqueIdentifier>{93995380-89BD-4b04-88EB-625FBE52EBFB}</UniqueIdentifier>
      <Extensions>h;hpp;hxx;hm;inl;inc;xsd</Extensions>
    </Filter>
    <Filter Include=""Resource Files"">
      <UniqueIdentifier>{67DA6AB6-F800-4c08-8B7A-83BB121AAD01}</UniqueIdentifier>
      <Extensions>rc;ico;cur;bmp;dlg;rc2;rct;bin;rgs;gif;jpg;jpeg;jpe;resx;tiff;tif;png;wav</Extensions>
    </Filter>
    ");
            
            #line 41 "C:\Users\steve\Source\Repos\Cephei2\Cephei.Gen\QL.Impl\Filter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetFilters(Context.RootTree, RootPackageName, "\t")));
            
            #line default
            #line hidden
            this.Write("\r\n    <Filter Include=\"Cephei\">\r\n      <UniqueIdentifier>{ff823b86-4332-4334-b40b" +
                    "-3557da4095b0}</UniqueIdentifier>\r\n    </Filter>\r\n  </ItemGroup>\r\n  <ItemGroup>\r" +
                    "\n    ");
            
            #line 47 "C:\Users\steve\Source\Repos\Cephei2\Cephei.Gen\QL.Impl\Filter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetPackage (Context.RootTree, RootPackageName, "\t")));
            
            #line default
            #line hidden
            this.Write("\r\n <ClCompile Include=\"AssemblyInfo.cpp\">\r\n      <Filter>Source Files</Filter>\r\n " +
                    "   </ClCompile>\r\n    <ClCompile Include=\"CepheiAnalytics.cpp\">\r\n      <Filter>So" +
                    "urce Files</Filter>\r\n    </ClCompile>\r\n    <ClCompile Include=\"Stdafx.cpp\">\r\n   " +
                    "   <Filter>Source Files</Filter>\r\n    </ClCompile>\r\n    <ClCompile Include=\"CoVe" +
                    "ctor.cpp\">\r\n      <Filter>Cephei</Filter>\r\n    </ClCompile>\r\n    <ClCompile Incl" +
                    "ude=\"ValueCollections.cpp\">\r\n      <Filter>Cephei</Filter>\r\n    </ClCompile>\r\n  " +
                    "  <ClCompile Include=\"ValueHelpers.cpp\">\r\n      <Filter>Cephei</Filter>\r\n    </C" +
                    "lCompile>\r\n    <ClCompile Include=\"Session.cpp\">\r\n      <Filter>Source Files</Fi" +
                    "lter>\r\n    </ClCompile>\r\n    <ClCompile Include=\"Settings.cpp\">\r\n      <Filter>S" +
                    "ource Files</Filter>\r\n    </ClCompile>\r\n  </ItemGroup>\r\n  <ItemGroup>\r\n    <ClIn" +
                    "clude Include=\"CepheiAnalytics.h\">\r\n      <Filter>Header Files</Filter>\r\n    </C" +
                    "lInclude>\r\n    <ClInclude Include=\"resource.h\">\r\n      <Filter>Header Files</Fil" +
                    "ter>\r\n    </ClInclude>\r\n    <ClInclude Include=\"Stdafx.h\">\r\n      <Filter>Header" +
                    " Files</Filter>\r\n    </ClInclude>\r\n    <ClInclude Include=\"CoCube.h\">\r\n      <Fi" +
                    "lter>Cephei</Filter>\r\n    </ClInclude>\r\n    <ClInclude Include=\"CoMatrix.h\">\r\n  " +
                    "    <Filter>Cephei</Filter>\r\n    </ClInclude>\r\n    <ClInclude Include=\"CoVector." +
                    "h\">\r\n      <Filter>Cephei</Filter>\r\n    </ClInclude>\r\n    <ClInclude Include=\"ma" +
                    "cros.h\">\r\n      <Filter>Cephei</Filter>\r\n    </ClInclude>\r\n    <ClInclude Includ" +
                    "e=\"ValueCollections.h\">\r\n      <Filter>Cephei</Filter>\r\n    </ClInclude>\r\n    <C" +
                    "lInclude Include=\"ValueHelpers.h\">\r\n      <Filter>Cephei</Filter>\r\n    </ClInclu" +
                    "de>\r\n    <ClInclude Include=\"Session.h\">\r\n      <Filter>Header Files</Filter>\r\n " +
                    "   </ClInclude>\r\n    <ClInclude Include=\"Settings.h\">\r\n      <Filter>Header File" +
                    "s</Filter>\r\n    </ClInclude>\r\n  </ItemGroup>\r\n  <ItemGroup>\r\n    <None Include=\"" +
                    "app.ico\">\r\n      <Filter>Resource Files</Filter>\r\n    </None>\r\n    <None Include" +
                    "=\"ReadMe.txt\" />\r\n  </ItemGroup>\r\n  <ItemGroup>\r\n    <ResourceCompile Include=\"a" +
                    "pp.rc\">\r\n      <Filter>Resource Files</Filter>\r\n    </ResourceCompile>\r\n  </Item" +
                    "Group>\r\n</Project>\r\n");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 120 "C:\Users\steve\Source\Repos\Cephei2\Cephei.Gen\QL.Impl\Filter.tt"

private EA.Gen.Model.Jet.Package rootPackage = null;
private string _outputDirectory = String.Empty;

protected EA.Gen.Model.Jet.Package RootPackage
{
	get
	{
		if( rootPackage == null )
		{
            rootPackage = FindPackage (Context.Repository.Models(), RootPackageName);
		}
		if (rootPackage == null)
			throw new ApplicationException("You must identify a root package ");
		return rootPackage;
	}
	set 
    { 
        rootPackage = value; 
    }
}

public EA.Gen.Model.Jet.Package FindPackage (IEnumerable<EA.Gen.Model.Jet.Package> collection, string name)
{
    foreach (var package in collection)
    {
        if (package.Name == name)
        {
            return package;
        }
        var child = FindPackage (package.Children, name);
        if (child != null)
        {
            return child;
        }
    }
    return null;
}

string GetFilters (Package rootPackage,  string nameSpace, string tabs)
{
    rootPackage.LoadAll (Context);
    return GetFilters2 (rootPackage, nameSpace, tabs);
}

string GetFilters2 (Package package, string nameSpace, string tabs)
{
    System.GC.Collect ();
    Console.WriteLine(tabs + "Processing Package: " + package.Name);
    
    StringBuilder sb = new StringBuilder (); 
    sb.AppendFormat ("{0}<Filter Include=\"{1}\">\n", tabs, nameSpace);
    sb.AppendFormat ("{0}\t<UniqueIdentifier>{{{1}}}</UniqueIdentifier>\n", tabs, Guid.NewGuid().ToString());
    sb.AppendFormat ("{0}</Filter>\n", tabs);

	foreach (var child in package.Children)
	{
		sb.Append (GetFilters2 (child, nameSpace + "\\" + child.Name, tabs + "\t"));
	}

    return sb.ToString ();
}
string GetPackage(Package rootPackage,  string nameSpace, string tabs)
{
    rootPackage.LoadAll (Context);
    return GetPackage2 (rootPackage, rootPackage, nameSpace, tabs);
}
string GetPackage2(Package package, Package rootPackage,  string nameSpace, string tabs)
{
    System.GC.Collect ();
    Console.WriteLine(tabs + "Processing Package: " + package.Name);
    
    StringBuilder sb = new StringBuilder (); 
    
//    sb.AppendFormat ("{0}<Filter Name=\"{1}\">\n", tabs, package.Name);

	foreach (var child in package.Children)
	{
		sb.Append (GetPackage2 (child, rootPackage, nameSpace + "::" + child.Name.Substring (0, 1).ToUpper () + child.Name.Substring (1) , tabs + "\t"));
	}
    
    /////////////////////////////////////////////////////////////////////////////////////////////////
    // output the package enums
    //
    
	string directory =  OutputDirectory + "gen\\" + nameSpace.Replace("::", "\\");
	string efileName =  directory + "\\" + package.Name + "Enum.cs";

    if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

    string lastName = "";
    int lineCount = 0;

    sb.AppendFormat ("\t{0}<ClCompile Include=\"gen\\{1}\">\n", tabs, nameSpace.Replace("::", "\\") + "\\_" + package.Id + "_" + lineCount + ".cpp");
    sb.AppendFormat ("\t\t{0}<Filter>{1}</Filter>\n", tabs, nameSpace.Replace("::", "\\"));
    sb.AppendFormat ("\t{0}</ClCompile>\n", tabs);

    foreach (var pair in package.Content)
	{
        lastName = pair.Name;
        sb.AppendFormat ("\t{0}<None Include=\"gen\\{1}\" >\n", tabs, nameSpace.Replace("::", "\\") + "\\" + pair.Name + ".h");
        sb.AppendFormat ("\t\t{0}<Filter>{1}</Filter>\n", tabs, nameSpace.Replace("::", "\\"));
        sb.AppendFormat ("\t{0}</None>\n", tabs);
        sb.AppendFormat ("\t{0}<None Include=\"gen\\{1}\" >\n", tabs, nameSpace.Replace("::", "\\") + "\\" + pair.Name + ".hpp");
        sb.AppendFormat ("\t\t{0}<Filter>{1}</Filter>\n", tabs, nameSpace.Replace("::", "\\"));
        sb.AppendFormat ("\t{0}</None>\n", tabs);
        if (++lineCount % 50 == 49)
        {
            sb.AppendFormat ("\t{0}<ClCompile Include=\"gen\\{1}\">\n", tabs, nameSpace.Replace("::", "\\") + "\\_" + package.Id + "_" + lineCount + ".cpp");
            sb.AppendFormat ("\t\t{0}<Filter>{1}</Filter>\n", tabs, nameSpace.Replace("::", "\\"));
            sb.AppendFormat ("\t{0}</ClCompile>\n", tabs);
        }

		Console.WriteLine(tabs + "Processing Class: " + pair.Name + " to file: " + nameSpace.Replace("::", "\\") + "\\" + pair.Name);
	}
    return sb.ToString ();
}

        
        #line default
        #line hidden
        
        #line 238 "C:\Users\steve\Source\Repos\Cephei2\Cephei.Gen\QL.Impl\Filter.tt"


		public Context Context = new Context();

		public Filter 
			( string RootPackageName
			, string ProjectName
			, string OutputDirectory
			, Context ctx = null
			)
		{
			_RootPackageNameField = RootPackageName;
			_ProjectNameField = ProjectName;
			_OutputDirectoryField = OutputDirectory;
			if (ctx != null)
				Context = ctx;
			else
				Context = new Context();
		}

        
        #line default
        #line hidden
        
        #line 1 "C:\Users\steve\Source\Repos\Cephei2\Cephei.Gen\QL.Impl\Filter.tt"

private string _RootPackageNameField;

/// <summary>
/// Access the RootPackageName parameter of the template.
/// </summary>
private string RootPackageName
{
    get
    {
        return this._RootPackageNameField;
    }
}

private string _ProjectNameField;

/// <summary>
/// Access the ProjectName parameter of the template.
/// </summary>
private string ProjectName
{
    get
    {
        return this._ProjectNameField;
    }
}

private string _OutputDirectoryField;

/// <summary>
/// Access the OutputDirectory parameter of the template.
/// </summary>
private string OutputDirectory
{
    get
    {
        return this._OutputDirectoryField;
    }
}


/// <summary>
/// Initialize the template
/// </summary>
public virtual void Initialize()
{
    if ((this.Errors.HasErrors == false))
    {
bool RootPackageNameValueAcquired = false;
if (this.Session.ContainsKey("RootPackageName"))
{
    this._RootPackageNameField = ((string)(this.Session["RootPackageName"]));
    RootPackageNameValueAcquired = true;
}
if ((RootPackageNameValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("RootPackageName");
    if ((data != null))
    {
        this._RootPackageNameField = ((string)(data));
    }
}
bool ProjectNameValueAcquired = false;
if (this.Session.ContainsKey("ProjectName"))
{
    this._ProjectNameField = ((string)(this.Session["ProjectName"]));
    ProjectNameValueAcquired = true;
}
if ((ProjectNameValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("ProjectName");
    if ((data != null))
    {
        this._ProjectNameField = ((string)(data));
    }
}
bool OutputDirectoryValueAcquired = false;
if (this.Session.ContainsKey("OutputDirectory"))
{
    this._OutputDirectoryField = ((string)(this.Session["OutputDirectory"]));
    OutputDirectoryValueAcquired = true;
}
if ((OutputDirectoryValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("OutputDirectory");
    if ((data != null))
    {
        this._OutputDirectoryField = ((string)(data));
    }
}


    }
}


        
        #line default
        #line hidden
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public class FilterBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
