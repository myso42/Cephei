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
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\NetXL\Project.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class Project : ProjectBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<Project ToolsVersion=\"4.0\" DefaultTarget" +
                    "s=\"Build\" xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\">\r\n  <Impor" +
                    "t Project=\"$(MSBuildExtensionsPath)\\$(MSBuildToolsVersion)\\Microsoft.Common.prop" +
                    "s\" Condition=\"Exists(\'$(MSBuildExtensionsPath)\\$(MSBuildToolsVersion)\\Microsoft." +
                    "Common.props\')\" />\r\n  <PropertyGroup>\r\n    <Configuration Condition=\" \'$(Configu" +
                    "ration)\' == \'\' \">Debug</Configuration>\r\n    <Platform Condition=\" \'$(Platform)\' " +
                    "== \'\' \">AnyCPU</Platform>\r\n    <SchemaVersion>2.0</SchemaVersion>\r\n    <ProjectG" +
                    "uid>d3325587-61db-4ab8-ad88-0677d9322a94</ProjectGuid>\r\n    <OutputType>Library<" +
                    "/OutputType>\r\n    <RootNamespace>Cephei.XL</RootNamespace>\r\n    <AssemblyName>Ce" +
                    "phei.XL</AssemblyName>\r\n    <TargetFrameworkVersion>v4.8</TargetFrameworkVersion" +
                    ">\r\n    <Name>Cephei.XL</Name>\r\n    <SccProjectName>SAK</SccProjectName>\r\n    <Sc" +
                    "cProvider>SAK</SccProvider>\r\n    <SccAuxPath>SAK</SccAuxPath>\r\n    <SccLocalPath" +
                    ">SAK</SccLocalPath>\r\n    <SolutionDir Condition=\"$(SolutionDir) == \'\' Or $(Solut" +
                    "ionDir) == \'*Undefined*\'\">..\\</SolutionDir>\r\n    <RestorePackages>true</RestoreP" +
                    "ackages>\r\n    <TargetFSharpCoreVersion>4.7.2</TargetFSharpCoreVersion>\r\n    <Tar" +
                    "getFrameworkProfile />\r\n    <NuGetPackageImportStamp>\r\n    </NuGetPackageImportS" +
                    "tamp>\r\n  </PropertyGroup>\r\n  <PropertyGroup Condition=\" \'$(Configuration)|$(Plat" +
                    "form)\' == \'Debug|AnyCPU\' \">\r\n    <DebugSymbols>true</DebugSymbols>\r\n    <DebugTy" +
                    "pe>full</DebugType>\r\n    <Optimize>false</Optimize>\r\n    <Tailcalls>false</Tailc" +
                    "alls>\r\n    <OutputPath>..\\Debug\\</OutputPath>\r\n    <DefineConstants>DEBUG;TRACE<" +
                    "/DefineConstants>\r\n    <WarningLevel>3</WarningLevel>\r\n    <DocumentationFile>.." +
                    "\\Debug\\Cephei.XL.XML</DocumentationFile>\r\n    <StartAction>Program</StartAction>" +
                    "\r\n    <StartProgram>C:\\Program Files\\Microsoft Office\\root\\Office16\\EXCEL.EXE</S" +
                    "tartProgram>\r\n    <StartArguments>\"Cephei.XL-AddIn64.xll\"</StartArguments>\r\n    " +
                    "<TreatWarningsAsErrors>false</TreatWarningsAsErrors>\r\n    <WarningsAsErrors>3239" +
                    "</WarningsAsErrors>\r\n    <NoWarn>49</NoWarn>\r\n  </PropertyGroup>\r\n  <PropertyGro" +
                    "up Condition=\" \'$(Configuration)|$(Platform)\' == \'Release|AnyCPU\' \">\r\n    <Debug" +
                    "Type>pdbonly</DebugType>\r\n    <Optimize>true</Optimize>\r\n    <Tailcalls>true</Ta" +
                    "ilcalls>\r\n    <OutputPath>..\\Release\\</OutputPath>\r\n    <DefineConstants>TRACE</" +
                    "DefineConstants>\r\n    <WarningLevel>3</WarningLevel>\r\n    <DocumentationFile>..\\" +
                    "Release\\Cephei.XL.XML</DocumentationFile>\r\n    <StartAction>Program</StartAction" +
                    ">\r\n    <StartProgram>C:\\Program Files\\Microsoft Office\\root\\Office16\\EXCEL.EXE</" +
                    "StartProgram>\r\n    <StartArguments>\"Cephei.XL-AddIn64.xll\"</StartArguments>\r\n   " +
                    " <TreatWarningsAsErrors>false</TreatWarningsAsErrors>\r\n    <WarningsAsErrors>323" +
                    "9</WarningsAsErrors>\r\n    <NoWarn>49</NoWarn>\r\n  </PropertyGroup>\r\n  <PropertyGr" +
                    "oup>\r\n    <MinimumVisualStudioVersion Condition=\"\'$(MinimumVisualStudioVersion)\'" +
                    " == \'\'\">11</MinimumVisualStudioVersion>\r\n  </PropertyGroup>\r\n  <Choose>\r\n    <Wh" +
                    "en Condition=\"\'$(VisualStudioVersion)\' == \'11.0\'\">\r\n      <PropertyGroup>\r\n     " +
                    "   <FSharpTargetsPath>$(MSBuildExtensionsPath32)\\..\\Microsoft SDKs\\F#\\3.0\\Framew" +
                    "ork\\v4.0\\Microsoft.FSharp.Targets</FSharpTargetsPath>\r\n      </PropertyGroup>\r\n " +
                    "   </When>\r\n    <Otherwise>\r\n      <PropertyGroup>\r\n        <FSharpTargetsPath>$" +
                    "(MSBuildExtensionsPath32)\\Microsoft\\VisualStudio\\v$(VisualStudioVersion)\\FSharp\\" +
                    "Microsoft.FSharp.Targets</FSharpTargetsPath>\r\n      </PropertyGroup>\r\n    </Othe" +
                    "rwise>\r\n  </Choose>\r\n  <Import Project=\"$(FSharpTargetsPath)\" Condition=\"Exists(" +
                    "\'$(FSharpTargetsPath)\')\" />\r\n  <Import Project=\"$(SolutionDir)\\.nuget\\NuGet.targ" +
                    "ets\" Condition=\"Exists(\'$(SolutionDir)\\.nuget\\NuGet.targets\')\" />\r\n  <Target Nam" +
                    "e=\"EnsureNuGetPackageBuildImports\" BeforeTargets=\"PrepareForBuild\">\r\n    <Proper" +
                    "tyGroup>\r\n      <ErrorText>This project references NuGet package(s) that are mis" +
                    "sing on this computer. Enable NuGet Package Restore to download them.  For more " +
                    "information, see http://go.microsoft.com/fwlink/?LinkID=322105. The missing file" +
                    " is {0}.</ErrorText>\r\n    </PropertyGroup>\r\n    <Error Condition=\"!Exists(\'$(Sol" +
                    "utionDir)\\.nuget\\NuGet.targets\')\" Text=\"$([System.String]::Format(\'$(ErrorText)\'" +
                    ", \'$(SolutionDir)\\.nuget\\NuGet.targets\'))\" />\r\n    <Error Condition=\"!Exists(\'.." +
                    "\\packages\\ExcelDna.AddIn.1.1.1\\build\\ExcelDna.AddIn.targets\')\" Text=\"$([System.S" +
                    "tring]::Format(\'$(ErrorText)\', \'..\\packages\\ExcelDna.AddIn.1.1.1\\build\\ExcelDna." +
                    "AddIn.targets\'))\" />\r\n  </Target>\r\n  <Import Project=\"..\\packages\\ExcelDna.AddIn" +
                    ".1.1.1\\build\\ExcelDna.AddIn.targets\" Condition=\"Exists(\'..\\packages\\ExcelDna.Add" +
                    "In.1.1.1\\build\\ExcelDna.AddIn.targets\')\" />\r\n  <ItemGroup>\r\n    <None Include=\"p" +
                    "ackages.config\" />\r\n    <None Include=\"Properties\\ExcelDna.Build.props\" />\r\n    " +
                    "<None Include=\"Cephei.XL-AddIn.dna\" />\r\n    <Compile Include=\"Model.fs\" />\r\n    " +
                    "<Compile Include=\"Helper.fs\" />\r\n    <Compile Include=\"Value.fs\" />\r\n    <Compil" +
                    "e Include=\"BondFunction.fs\" />\r\n    <Compile Include=\"DiscountingBondEngine.fs\" " +
                    "/>\r\n    <Compile Include=\"Today.fs\" />\r\n  </ItemGroup>\r\n\r\n  <ItemGroup>\r\n");
            
            #line 102 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\NetXL\Project.tt"

	foreach (var ic in Package.Classes)
	{
		var i = ic.Value;
		if (!i.IsEnum && !i.IsInterface && !i.IsAbstract && (!i.ParentID.HasValue || i.ParentID.Value == 0))
		{
			var itype = new Class(i);
			var tcode = itype.TransformText();
			var tfn = OutputDirectory + "\\Functions\\" + i.Name + "Function.fs";
			System.IO.File.WriteAllText (tfn, tcode);

            
            #line default
            #line hidden
            this.Write("\t<Compile Include=\"Functions\\");
            
            #line 113 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\NetXL\Project.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(i.Name));
            
            #line default
            #line hidden
            this.Write("Function.fs\" />\r\n");
            
            #line 114 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\NetXL\Project.tt"

		}
	} 

    var etype = new Enums (Package);
    var ecode = etype.TransformText();
    var efn = OutputDirectory + "\\Enums.fs";
	System.IO.File.WriteAllText (efn, ecode);

            
            #line default
            #line hidden
            this.Write("\t<Compile Include=\"Enums.fs\" />\r\n  </ItemGroup>\r\n\r\n\r\n  <ItemGroup>\r\n    <Referenc" +
                    "e Include=\"ExcelDna.Integration\">\r\n      <HintPath>..\\packages\\ExcelDna.Integrat" +
                    "ion.1.1.0\\lib\\ExcelDna.Integration.dll</HintPath>\r\n    </Reference>\r\n    <Refere" +
                    "nce Include=\"ExcelDna.Registration\">\r\n      <HintPath>..\\packages\\ExcelDna.Regis" +
                    "tration.1.1.0\\lib\\net40\\ExcelDna.Registration.dll</HintPath>\r\n    </Reference>\r\n" +
                    "    <Reference Include=\"ExcelDna.Registration.FSharp\">\r\n      <HintPath>..\\packa" +
                    "ges\\ExcelDna.Registration.FSharp.1.1.0\\lib\\net40\\ExcelDna.Registration.FSharp.dl" +
                    "l</HintPath>\r\n    </Reference>\r\n    <Reference Include=\"FSharp.Core\">\r\n      <Hi" +
                    "ntPath>..\\packages\\FSharp.Core.4.7.2\\lib\\net45\\FSharp.Core.dll</HintPath>\r\n    <" +
                    "/Reference>\r\n    <Reference Include=\"FSharp.Core, Version=, Culture=neutral, Pub" +
                    "licKeyToken=b03f5f7f11d50a3a\">\r\n      <Private>True</Private>\r\n    </Reference>\r" +
                    "\n    <Reference Include=\"Microsoft.Office.Interop.Excel\">\r\n      <HintPath>..\\pa" +
                    "ckages\\ExcelDna.Interop.14.0.1\\lib\\Microsoft.Office.Interop.Excel.dll</HintPath>" +
                    "\r\n    </Reference>\r\n    <Reference Include=\"Microsoft.Vbe.Interop\">\r\n      <Hint" +
                    "Path>..\\packages\\ExcelDna.Interop.14.0.1\\lib\\Microsoft.Vbe.Interop.dll</HintPath" +
                    ">\r\n    </Reference>\r\n    <Reference Include=\"mscorlib\" />\r\n    <Reference Includ" +
                    "e=\"office\">\r\n      <HintPath>..\\packages\\ExcelDna.Interop.14.0.1\\lib\\Office.dll<" +
                    "/HintPath>\r\n    </Reference>\r\n    <Reference Include=\"System\" />\r\n    <Reference" +
                    " Include=\"System.Core\" />\r\n    <Reference Include=\"System.Drawing\" />\r\n    <Refe" +
                    "rence Include=\"System.Numerics\" />\r\n    <Reference Include=\"System.Windows.Forms" +
                    "\" />\r\n    <Reference Include=\"System.Windows.Forms.DataVisualization\" />\r\n  </It" +
                    "emGroup>\r\n  <ItemGroup>\r\n    <ProjectReference Include=\"..\\..\\amaggiulli\\QLNet\\s" +
                    "rc\\QLNet\\QLNet.csproj\">\r\n      <Name>QLNet</Name>\r\n      <Project>{a3c24859-c41b" +
                    "-483d-a5ba-3e6d6a1db6a0}</Project>\r\n      <Private>True</Private>\r\n    </Project" +
                    "Reference>\r\n    <ProjectReference Include=\"..\\Cephei.Cell\\Cephei.Cell.csproj\">\r\n" +
                    "      <Name>Cephei.Cell</Name>\r\n      <Project>{947aa01a-f966-4731-9d27-373c74fe" +
                    "b794}</Project>\r\n      <Private>True</Private>\r\n    </ProjectReference>\r\n    <Pr" +
                    "ojectReference Include=\"..\\Cephei.QL\\Cephei.QL.fsproj\">\r\n      <Name>Cephei.QL</" +
                    "Name>\r\n      <Project>{e3d627af-54b8-4a9b-b645-0def1d08b9eb}</Project>\r\n      <P" +
                    "rivate>True</Private>\r\n    </ProjectReference>\r\n  </ItemGroup>\r\n  <!-- To modify" +
                    " your build process, add your task inside one of the targets below and uncomment" +
                    " it. \r\n       Other similar extension points exist, see Microsoft.Common.targets" +
                    ".\r\n  <Target Name=\"BeforeBuild\">\r\n  </Target>\r\n  <Target Name=\"AfterBuild\">\r\n  <" +
                    "/Target>\r\n  -->\r\n</Project>\r\n");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 185 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\NetXL\Project.tt"

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
        
        #line 1 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\NetXL\Project.tt"

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
