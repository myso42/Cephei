﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Cephei.Gen.NetQL
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Users\steve\source\repos\Cephei\Cephei.Gen\NetQL\Project.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class Project : ProjectBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write(@"
<Project Sdk=""Microsoft.NET.Sdk"">

  <PropertyGroup>
    <TargetFramework>netstandard2.0</TargetFramework>
  </PropertyGroup>

  <PropertyGroup Condition=""'$(Configuration)|$(Platform)'=='Debug|AnyCPU'"">
    <WarningsAsErrors>3239</WarningsAsErrors>
    <NoWarn>49</NoWarn>
  </PropertyGroup>


  <ItemGroup>
	<Compile Include=""Util.fs"" />
");
            
            #line 24 "C:\Users\steve\source\repos\Cephei\Cephei.Gen\NetQL\Project.tt"

	foreach (var ic in Package.Classes)
	{
		var i = ic.Value;
		if (!i.IsEnum && !i.IsInterface && !i.IsAbstract && (!i.ParentID.HasValue || i.ParentID.Value == 0))
		{
			var itype = new Class(i);
			var tcode = itype.TransformText();
			var tfn = OutputDirectory + "\\Types\\" + i.Name + "Model.fs";
			System.IO.File.WriteAllText (tfn, tcode);

            
            #line default
            #line hidden
            this.Write("\t<Compile Include=\"Types\\");
            
            #line 35 "C:\Users\steve\source\repos\Cephei\Cephei.Gen\NetQL\Project.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(i.Name));
            
            #line default
            #line hidden
            this.Write("Model.fs\" />\r\n");
            
            #line 36 "C:\Users\steve\source\repos\Cephei\Cephei.Gen\NetQL\Project.tt"

		}
	} 
    var ifun = new Fun(Package);
    var code = ifun.TransformText();
	var fn = OutputDirectory + "\\" + Package.Name + ".fs";
	System.IO.File.WriteAllText (fn, code);


            
            #line default
            #line hidden
            this.Write(@"	<Compile Include=""QLNet.fs"" />
  </ItemGroup>

  <ItemGroup>
    <PackageReference Include=""QLNet"" Version=""1.11.4"" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include=""..\Cephei.Cell\Cephei.Cell.csproj"" />
    <ProjectReference Include=""..\Cephei.QLNetHelper\Cephei.QLNetHelper.csproj"" />
  </ItemGroup>

  <ItemGroup>
    <PackageReference Update=""FSharp.Core"" Version=""4.7.2"" />
  </ItemGroup>
</Project>
");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 61 "C:\Users\steve\source\repos\Cephei\Cephei.Gen\NetQL\Project.tt"

        public NetModel.Package Package;

		public Project
			( string PackageName
			, string projectName
			, string outputDirectory
			)
		{
			_PackageNameField = PackageName;
			_ProjectNameField = projectName;
			_OutputDirectoryField = outputDirectory;
	        Package = NetModel.Context.Current.Value.getPackage(_PackageNameField);
		}

        
        #line default
        #line hidden
        
        #line 1 "C:\Users\steve\source\repos\Cephei\Cephei.Gen\NetQL\Project.tt"

private string _PackageNameField;

/// <summary>
/// Access the PackageName parameter of the template.
/// </summary>
private string PackageName
{
    get
    {
        return this._PackageNameField;
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
bool PackageNameValueAcquired = false;
if (this.Session.ContainsKey("PackageName"))
{
    this._PackageNameField = ((string)(this.Session["PackageName"]));
    PackageNameValueAcquired = true;
}
if ((PackageNameValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("PackageName");
    if ((data != null))
    {
        this._PackageNameField = ((string)(data));
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
    public class ProjectBase
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
