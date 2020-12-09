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
    using System.IO;
    using Cephei.Gen.Model;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Users\steve\Source\Repos\Cephei2\Cephei.Gen\QL\QLEnum.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class QLEnum : QLEnumBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            
            #line 1 "C:\Users\steve\Source\Repos\Cephei2\Cephei.Gen\QL\QLEnum.tt"
/*
Name:           
Author:         Stephen Channell
Description:    Generate the Enumerations associated with this element
*/
            
            #line default
            #line hidden
            this.Write("\r\nnamespace Cephei.");
            
            #line 18 "C:\Users\steve\Source\Repos\Cephei2\Cephei.Gen\QL\QLEnum.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Package.GlobalName.Replace("::", ".")));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n");
            
            #line 20 "C:\Users\steve\Source\Repos\Cephei2\Cephei.Gen\QL\QLEnum.tt"
 
    foreach (var element in ChildCollection)
    {
        Console.WriteLine ("Rendering enum " + element.Name);
        if (element.Name != "<anonymous>")
        {
            string elementNamespace = "";
            if (element.ParentID != 0)
            {
                elementNamespace = GetNamespace (element);

            
            #line default
            #line hidden
            this.Write(" \r\n    namespace ");
            
            #line 31 "C:\Users\steve\Source\Repos\Cephei2\Cephei.Gen\QL\QLEnum.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(elementNamespace));
            
            #line default
            #line hidden
            this.Write("\r\n    {\r\n");
            
            #line 33 "C:\Users\steve\Source\Repos\Cephei2\Cephei.Gen\QL\QLEnum.tt"

            }

            
            #line default
            #line hidden
            this.Write("        public enum ");
            
            #line 36 "C:\Users\steve\Source\Repos\Cephei2\Cephei.Gen\QL\QLEnum.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(element.Name));
            
            #line default
            #line hidden
            this.Write("Enum\r\n        {\r\n");
            
            #line 38 "C:\Users\steve\Source\Repos\Cephei2\Cephei.Gen\QL\QLEnum.tt"
   
            string prefix = "  ";
			int i= 0;
            var ordered = new SortedList<int, EA.Gen.Model.Jet.Attribute> ();
            foreach (var Attribute in element.Attributes)
            {
                ordered.Add (Attribute.Pos ?? i, Attribute);
				++i;
            }
            foreach (var pair in ordered)
            {

            
            #line default
            #line hidden
            this.Write("            ");
            
            #line 50 "C:\Users\steve\Source\Repos\Cephei2\Cephei.Gen\QL\QLEnum.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(prefix + pair.Value.Name.Replace("::",".")));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 50 "C:\Users\steve\Source\Repos\Cephei2\Cephei.Gen\QL\QLEnum.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture((pair.Value.Default == null ? "" : "= " + pair.Value.Default)));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 51 "C:\Users\steve\Source\Repos\Cephei2\Cephei.Gen\QL\QLEnum.tt"

                prefix = ", "; 
            }

            
            #line default
            #line hidden
            this.Write("        }\r\n");
            
            #line 56 "C:\Users\steve\Source\Repos\Cephei2\Cephei.Gen\QL\QLEnum.tt"

            if (elementNamespace != "")
            {

            
            #line default
            #line hidden
            this.Write("    } // ");
            
            #line 60 "C:\Users\steve\Source\Repos\Cephei2\Cephei.Gen\QL\QLEnum.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(elementNamespace));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 61 "C:\Users\steve\Source\Repos\Cephei2\Cephei.Gen\QL\QLEnum.tt"

            }
        }
    }

            
            #line default
            #line hidden
            this.Write("}\r\n\r\n");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 68 "C:\Users\steve\Source\Repos\Cephei2\Cephei.Gen\QL\QLEnum.tt"


private EA.Gen.Model.Jet.Package rootPackage = null;

public EA.Gen.Model.Jet.Package ThisPackage
{
	get
	{
		if( rootPackage == null )
		{
            rootPackage = FindPackage (CurrentRepository.Models(), Package.Name);
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


public EA.Gen.Model.Jet.Sparx CurrentRepository
{
	get
	{
        return Context.Repository;
	}
	set
	{ 
        Context.Repository = value; 
    }
}

private List<EA.Gen.Model.Jet.Element> ChildCollection
{
    get
    {
        return (from fp in Context.Repository.Elements
                where fp.PackageId == Package.Id
                && fp.Stereotype == "enumeration"
                select fp).ToList();
    }
}

public string GetNamespace (EA.Gen.Model.Jet.Element element)
{
    if (element.ParentID == 0)
    {
        return "";
    }
    
    var parent = Context.GetElementByID (element.ParentID ?? 0);
    //return parent.Name; //was used because enums were always part of a root package
    if (parent.ParentID != 0)
    {
        return GetNamespace(parent) + "." + parent.Name;
    }
    else
    {
        return parent.Name;
    }
}
		public Context Context;
		public QLEnum 
			( Cephei.Gen.Model.Package Package
			, Context ctx = null
			)
		{
			if (ctx != null)
				Context = ctx;
			else
				Context = new Context();

			_PackageField = Package;
		}

        
        #line default
        #line hidden
        
        #line 1 "C:\Users\steve\Source\Repos\Cephei2\Cephei.Gen\QL\QLEnum.tt"

private global::Cephei.Gen.Model.Package _PackageField;

/// <summary>
/// Access the Package parameter of the template.
/// </summary>
private global::Cephei.Gen.Model.Package Package
{
    get
    {
        return this._PackageField;
    }
}


/// <summary>
/// Initialize the template
/// </summary>
public virtual void Initialize()
{
    if ((this.Errors.HasErrors == false))
    {
bool PackageValueAcquired = false;
if (this.Session.ContainsKey("Package"))
{
    this._PackageField = ((global::Cephei.Gen.Model.Package)(this.Session["Package"]));
    PackageValueAcquired = true;
}
if ((PackageValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("Package");
    if ((data != null))
    {
        this._PackageField = ((global::Cephei.Gen.Model.Package)(data));
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
    public class QLEnumBase
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
