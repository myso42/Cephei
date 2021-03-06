﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Cephei.Gen.XL
{
    using System.IO;
    using System.Text;
    using System.Collections.Generic;
    using Cephei.Gen.Model;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Users\steve\source\repos\Cephei\Cephei.Gen\XL\Project.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class Project : ProjectBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            
            #line 1 "C:\Users\steve\source\repos\Cephei\Cephei.Gen\XL\Project.tt"
/* 
Name:           Project.tt
Author:         Stephen Channell
Description:    Generate the project file for the XL interface
*/
            
            #line default
            #line hidden
            
            #line 17 "C:\Users\steve\source\repos\Cephei\Cephei.Gen\XL\Project.tt"

    Context.RootName = RootPackageName;
    Context.Prefix = "I";
    Context.Suffix = "";
    Context.ClassDelimiter = ".";

            
            #line default
            #line hidden
            this.Write(@"  
<?xml version=""1.0"" encoding=""utf-8""?>
<Project ToolsVersion=""4.0"" DefaultTargets=""Build"" xmlns=""http://schemas.microsoft.com/developer/msbuild/2003"">
  <PropertyGroup>
    <Configuration Condition="" '$(Configuration)' == '' "">Debug</Configuration>
    <Platform Condition="" '$(Platform)' == '' "">AnyCPU</Platform>
    <ProductVersion>8.0.30703</ProductVersion>
    <SchemaVersion>2.0</SchemaVersion>
    <ProjectGuid>{0133EB61-C961-4056-9160-4A79920AF91B}</ProjectGuid>
    <OutputType>Library</OutputType>
    <AppDesignerFolder>Properties</AppDesignerFolder>
    <RootNamespace>");
            
            #line 33 "C:\Users\steve\source\repos\Cephei\Cephei.Gen\XL\Project.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ProjectName));
            
            #line default
            #line hidden
            this.Write("</RootNamespace>\r\n    <AssemblyName>");
            
            #line 34 "C:\Users\steve\source\repos\Cephei\Cephei.Gen\XL\Project.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ProjectName));
            
            #line default
            #line hidden
            this.Write("</AssemblyName>\r\n    <TargetFrameworkVersion>v4.5</TargetFrameworkVersion>\r\n    <" +
                    "FileAlignment>512</FileAlignment>\r\n    <SccProjectName>%24/Cephei/2.2/Cephei.XL1" +
                    "21</SccProjectName>\r\n    <SccLocalPath>.</SccLocalPath>\r\n    <SccAuxPath>https:/" +
                    "/cephei.tfspreview.com/defaultcollection</SccAuxPath>\r\n    <SccProvider>{4CA58AB" +
                    "2-18FA-4F8D-95D4-32DDF27D184C}</SccProvider>\r\n    <TargetFrameworkProfile />\r\n  " +
                    "</PropertyGroup>\r\n  <PropertyGroup Condition=\" \'$(Configuration)|$(Platform)\' ==" +
                    " \'Debug|AnyCPU\' \">\r\n    <DebugSymbols>true</DebugSymbols>\r\n    <DebugType>full</" +
                    "DebugType>\r\n    <Optimize>false</Optimize>\r\n    <OutputPath>..\\Debug\\</OutputPat" +
                    "h>\r\n    <DefineConstants>DEBUG;TRACE</DefineConstants>\r\n    <ErrorReport>prompt<" +
                    "/ErrorReport>\r\n    <WarningLevel>4</WarningLevel>\r\n    <Prefer32Bit>false</Prefe" +
                    "r32Bit>\r\n  </PropertyGroup>\r\n  <PropertyGroup Condition=\" \'$(Configuration)|$(Pl" +
                    "atform)\' == \'Release|AnyCPU\' \">\r\n    <DebugType>pdbonly</DebugType>\r\n    <Optimi" +
                    "ze>true</Optimize>\r\n    <OutputPath>..\\Release\\</OutputPath>\r\n    <DefineConstan" +
                    "ts>TRACE</DefineConstants>\r\n    <ErrorReport>prompt</ErrorReport>\r\n    <WarningL" +
                    "evel>4</WarningLevel>\r\n    <DocumentationFile>..\\Release\\Cephei.XL121.XML</Docum" +
                    "entationFile>\r\n    <Prefer32Bit>false</Prefer32Bit>\r\n  </PropertyGroup>\r\n  <Prop" +
                    "ertyGroup>\r\n    <SignAssembly>true</SignAssembly>\r\n  </PropertyGroup>\r\n  <Proper" +
                    "tyGroup>\r\n    <AssemblyOriginatorKeyFile>Cephei.snk</AssemblyOriginatorKeyFile>\r" +
                    "\n  </PropertyGroup>\r\n  <ItemGroup>\r\n    <Reference Include=\"FSharp.Core, Version" +
                    "=4.3.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a, processorArchitectur" +
                    "e=MSIL\" />\r\n    <Reference Include=\"Microsoft.Office.Interop.Excel, Version=12.0" +
                    ".0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c\">\r\n      <EmbedInteropTyp" +
                    "es>True</EmbedInteropTypes>\r\n    </Reference>\r\n    <Reference Include=\"Microsoft" +
                    ".Practices.EnterpriseLibrary.Logging, Version=5.0.414.0, Culture=neutral, Public" +
                    "KeyToken=31bf3856ad364e35, processorArchitecture=MSIL\">\r\n      <SpecificVersion>" +
                    "False</SpecificVersion>\r\n      <HintPath>..\\packages\\EnterpriseLibrary.Logging.5" +
                    ".0.505.1\\lib\\NET35\\Microsoft.Practices.EnterpriseLibrary.Logging.dll</HintPath>\r" +
                    "\n    </Reference>\r\n    <Reference Include=\"System\" />\r\n    <Reference Include=\"S" +
                    "ystem.Core\" />\r\n    <Reference Include=\"System.Configuration\" />\r\n    <Reference" +
                    " Include=\"System.Drawing\" />\r\n    <Reference Include=\"System.Runtime.Serializati" +
                    "on\" />\r\n    <Reference Include=\"System.Xml.Linq\" />\r\n    <Reference Include=\"Sys" +
                    "tem.Data.DataSetExtensions\" />\r\n    <Reference Include=\"System.ServiceModel\" />\r" +
                    "\n    <Reference Include=\"Microsoft.CSharp\" />\r\n    <Reference Include=\"System.Da" +
                    "ta\" />\r\n    <Reference Include=\"System.Xml\" />\r\n    <Reference Include=\"System.W" +
                    "indows.Forms\" />\r\n    <Reference Include=\"WindowsBase\" />\r\n  </ItemGroup>\r\n  <It" +
                    "emGroup>\r\n    <Compile Include=\"AboutBox.cs\">\r\n      <SubType>Form</SubType>\r\n  " +
                    "  </Compile>\r\n    <Compile Include=\"AboutBox.Designer.cs\">\r\n      <DependentUpon" +
                    ">AboutBox.cs</DependentUpon>\r\n    </Compile>\r\n    <Compile Include=\"Banner.cs\">\r" +
                    "\n      <SubType>Form</SubType>\r\n    </Compile>\r\n    <Compile Include=\"Banner.Des" +
                    "igner.cs\">\r\n      <DependentUpon>Banner.cs</DependentUpon>\r\n    </Compile>\r\n    " +
                    "<Compile Include=\"Properties\\Resources.Designer.cs\">\r\n      <AutoGen>True</AutoG" +
                    "en>\r\n      <DesignTime>True</DesignTime>\r\n      <DependentUpon>Resources.resx</D" +
                    "ependentUpon>\r\n    </Compile>\r\n    <Compile Include=\"Addin.cs\" />\r\n    <Compile " +
                    "Include=\"Bools.cs\" />\r\n    <Compile Include=\"DateTimes.cs\" />\r\n    <Compile Incl" +
                    "ude=\"Helper.cs\" />\r\n    <Compile Include=\"Ints.cs\" />\r\n    <Compile Include=\"Lon" +
                    "gs.cs\" />\r\n    <Compile Include=\"CepheiModel.cs\" />\r\n    <Compile Include=\"Prope" +
                    "rties\\AssemblyInfo.cs\" />\r\n    <Compile Include=\"Doubles.cs\" />\r\n    <Compile In" +
                    "clude=\"Service\\Session.cs\" />\r\n    <Compile Include=\"Strings.cs\" />\r\n    <Compil" +
                    "e Include=\"UInts.cs\" />\r\n    <Compile Include=\"ULongs.cs\" />\r\n    <Compile Inclu" +
                    "de=\"Now.cs\" />\r\n    <Compile Include=\"Value.cs\" />\r\n    <Compile Include=\"Sessio" +
                    "n.cs\" />\r\n    <Compile Include=\"XLInterface.cs\" />\r\n");
            
            #line 127 "C:\Users\steve\source\repos\Cephei\Cephei.Gen\XL\Project.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetPackage (Context.RootTree, RootPackageName, "\t")));
            
            #line default
            #line hidden
            this.Write("\r\n  </ItemGroup>\r\n  <ItemGroup>\r\n    <ProjectReference Include=\"..\\Cephei.Cell\\Ce" +
                    "phei.Kernel.csproj\">\r\n      <Project>{9559D07F-7AE4-4533-BBD9-38112766D904}</Pro" +
                    "ject>\r\n      <Name>Cephei.Kernel</Name>\r\n    </ProjectReference>\r\n    <ProjectRe" +
                    "ference Include=\"..\\Cephei.Core\\Cephei.Core.csproj\">\r\n      <Project>{7AFE3EF3-E" +
                    "F62-4DA1-9AE4-06D472FAFF74}</Project>\r\n      <Name>Cephei.Core</Name>\r\n      <Pr" +
                    "ivate>False</Private>\r\n    </ProjectReference>\r\n    <ProjectReference Include=\"." +
                    ".\\Cephei.Data121\\Cephei.Data121.csproj\">\r\n      <Project>{4839265A-31FB-41F5-B39" +
                    "5-98959FB19958}</Project>\r\n      <Name>Cephei.Data121</Name>\r\n      <Private>Fal" +
                    "se</Private>\r\n    </ProjectReference>\r\n    <ProjectReference Include=\"..\\Cephei." +
                    "Fun121\\Cephei.Fun121.fsproj\">\r\n      <Project>{25C63D66-5A0A-4673-B2BA-55564802F" +
                    "9D8}</Project>\r\n      <Name>Cephei.Fun121</Name>\r\n      <Private>False</Private>" +
                    "\r\n    </ProjectReference>\r\n    <ProjectReference Include=\"..\\Cephei.QL121\\Cephei" +
                    ".QL121.csproj\">\r\n      <Project>{87BDBA6F-F760-4AB0-8D8C-BC8F7F54FB64}</Project>" +
                    "\r\n      <Name>Cephei.QL121</Name>\r\n      <Private>False</Private>\r\n    </Project" +
                    "Reference>\r\n    <ProjectReference Include=\"..\\ExcelDNA\\Source\\ExcelDna.Integrati" +
                    "on\\ExcelDna.Integration.csproj\">\r\n      <Project>{196735BC-5A5C-4A21-9FE4-EC01CB" +
                    "7F3DE9}</Project>\r\n      <Name>ExcelDna.Integration</Name>\r\n      <Private>False" +
                    "</Private>\r\n    </ProjectReference>\r\n  </ItemGroup>\r\n  <ItemGroup>\r\n    <None In" +
                    "clude=\"App.config\">\r\n      <SubType>Designer</SubType>\r\n    </None>\r\n    <None I" +
                    "nclude=\"Cephei.dna\">\r\n      <CopyToOutputDirectory>PreserveNewest</CopyToOutputD" +
                    "irectory>\r\n    </None>\r\n    <None Include=\"Cephei.snk\" />\r\n    <None Include=\"pa" +
                    "ckages.config\">\r\n      <SubType>Designer</SubType>\r\n    </None>\r\n    <None Inclu" +
                    "de=\"XLL64\\Cephei64.dna\">\r\n      <CopyToOutputDirectory>PreserveNewest</CopyToOut" +
                    "putDirectory>\r\n    </None>\r\n    <None Include=\"XLL\\Cephei.dna\">\r\n      <CopyToOu" +
                    "tputDirectory>PreserveNewest</CopyToOutputDirectory>\r\n    </None>\r\n  </ItemGroup" +
                    ">\r\n  <ItemGroup>\r\n    <EmbeddedResource Include=\"AboutBox.resx\">\r\n      <Depende" +
                    "ntUpon>AboutBox.cs</DependentUpon>\r\n    </EmbeddedResource>\r\n    <EmbeddedResour" +
                    "ce Include=\"Banner.resx\">\r\n      <DependentUpon>Banner.cs</DependentUpon>\r\n    <" +
                    "/EmbeddedResource>\r\n    <EmbeddedResource Include=\"Properties\\Resources.resx\">\r\n" +
                    "      <Generator>ResXFileCodeGenerator</Generator>\r\n      <LastGenOutput>Resourc" +
                    "es.Designer.cs</LastGenOutput>\r\n      <SubType>Designer</SubType>\r\n    </Embedde" +
                    "dResource>\r\n  </ItemGroup>\r\n  <ItemGroup>\r\n    <None Include=\"Resources\\cephei.x" +
                    "l.png\" />\r\n  </ItemGroup>\r\n  <ItemGroup>\r\n    <Content Include=\"Resources\\a.png\"" +
                    ">\r\n      <CopyToOutputDirectory>Always</CopyToOutputDirectory>\r\n    </Content>\r\n" +
                    "    <Content Include=\"Resources\\about.png\">\r\n      <CopyToOutputDirectory>Always" +
                    "</CopyToOutputDirectory>\r\n    </Content>\r\n    <Content Include=\"Resources\\c.png\"" +
                    ">\r\n      <CopyToOutputDirectory>Always</CopyToOutputDirectory>\r\n    </Content>\r\n" +
                    "    <Content Include=\"Resources\\cephei.xl2.png\" />\r\n    <Content Include=\"Resour" +
                    "ces\\compile.png\">\r\n      <CopyToOutputDirectory>Always</CopyToOutputDirectory>\r\n" +
                    "    </Content>\r\n    <Content Include=\"Resources\\dataLoad.png\">\r\n      <CopyToOut" +
                    "putDirectory>Always</CopyToOutputDirectory>\r\n    </Content>\r\n    <Content Includ" +
                    "e=\"Resources\\dataSave.png\">\r\n      <CopyToOutputDirectory>Always</CopyToOutputDi" +
                    "rectory>\r\n    </Content>\r\n    <Content Include=\"Resources\\g.png\">\r\n      <CopyTo" +
                    "OutputDirectory>Always</CopyToOutputDirectory>\r\n    </Content>\r\n    <Content Inc" +
                    "lude=\"Resources\\generate.png\">\r\n      <CopyToOutputDirectory>Always</CopyToOutpu" +
                    "tDirectory>\r\n    </Content>\r\n    <Content Include=\"Resources\\h.png\">\r\n      <Cop" +
                    "yToOutputDirectory>Always</CopyToOutputDirectory>\r\n    </Content>\r\n    <Content " +
                    "Include=\"Resources\\help.png\">\r\n      <CopyToOutputDirectory>Always</CopyToOutput" +
                    "Directory>\r\n    </Content>\r\n    <Content Include=\"Resources\\l.png\">\r\n      <Copy" +
                    "ToOutputDirectory>Always</CopyToOutputDirectory>\r\n    </Content>\r\n    <Content I" +
                    "nclude=\"Resources\\Load.png\">\r\n      <CopyToOutputDirectory>Always</CopyToOutputD" +
                    "irectory>\r\n    </Content>\r\n    <Content Include=\"Resources\\s.png\">\r\n      <CopyT" +
                    "oOutputDirectory>Always</CopyToOutputDirectory>\r\n    </Content>\r\n    <Content In" +
                    "clude=\"Resources\\save.png\">\r\n      <CopyToOutputDirectory>Always</CopyToOutputDi" +
                    "rectory>\r\n    </Content>\r\n    <Content Include=\"Resources\\sdk.png\">\r\n      <Copy" +
                    "ToOutputDirectory>Always</CopyToOutputDirectory>\r\n    </Content>\r\n    <Content I" +
                    "nclude=\"xll-pack.txt\" />\r\n  </ItemGroup>\r\n  <Import Project=\"$(MSBuildToolsPath)" +
                    "\\Microsoft.CSharp.targets\" />\r\n  <PropertyGroup>\r\n    <PostBuildEvent>copy $(Out" +
                    "Dir)Cephei.dna $(OutDir)Cephei64.dna\r\ncopy $(OutDir)Cephei.XL121.dll.config $(Ou" +
                    "tDir)Cephei.xll.config \r\ncopy $(OutDir)Cephei.XL121.dll.config $(OutDir)Cephei64" +
                    ".xll.config \r\ncopy $(OutDir)Cephei.XL121.dll.config $(OutDir)xll\\Cephei.xll.conf" +
                    "ig \r\ncopy $(OutDir)Cephei.XL121.dll.config $(OutDir)xll64\\Cephei64.xll.config \r\n" +
                    "</PostBuildEvent>\r\n  </PropertyGroup>\r\n  <!-- To modify your build process, add " +
                    "your task inside one of the targets below and uncomment it. \r\n       Other simil" +
                    "ar extension points exist, see Microsoft.Common.targets.\r\n  <Target Name=\"Before" +
                    "Build\">\r\n  </Target>\r\n  <Target Name=\"AfterBuild\">\r\n  </Target>\r\n  -->\r\n</Projec" +
                    "t>\r\n");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 260 "C:\Users\steve\source\repos\Cephei\Cephei.Gen\XL\Project.tt"


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
    
	string directory =  OutputDirectory + "\\" + nameSpace.Replace("::", "\\");
 
    if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

    string lastName = "";

    foreach (var pair in package.Content)
	{
        lastName = pair.Name;
		string fileName =  directory + "\\" + pair.Name + ".cs";
		string fileRef =  nameSpace.Replace("::", "\\") + "\\" + pair.Name + ".cs";
        sb.AppendFormat ("\t{0}<Compile Include=\"{1}\" />\n", tabs, fileRef);

		Console.WriteLine(tabs + "Processing Class: " + pair.Name + " to file: " + fileName);

        var cls = new Class(pair.Name, RootPackageName);
        cls.Context.Repository = Context.Repository;
        cls.Context.CurrentElement = pair.Element;
        cls.Context.CurrentClass = pair;
        var clsCode = cls.TransformText();
        System.IO.File.WriteAllText(fileName, clsCode);
	}
//    sb.AppendFormat ("{0}</Filter>\n", tabs);

    return sb.ToString ();
}
		public Context Context;

		public Project
			( string rootPackageName
			, string projectName
			, string outputDirectory
			, Context ctx = null
			)
		{
			_RootPackageNameField = rootPackageName;
			_ProjectNameField = projectName;
			_OutputDirectoryField = outputDirectory;
			if (ctx != null)
				Context = ctx;
			else
				Context = new Context();
		}

        
        #line default
        #line hidden
        
        #line 1 "C:\Users\steve\source\repos\Cephei\Cephei.Gen\XL\Project.tt"

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
