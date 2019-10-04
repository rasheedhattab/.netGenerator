﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Generator.DataBase
{
    using System.Linq;
    using System.Collections.Generic;
    using System.Data;
    using System.Text;
    using System.Data.Common;
    using System.Runtime;
    using Oracle.ManagedDataAccess.Client;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Workspaces\Workflow\Generator\DataBase\DBPackage.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class DBPackage : DBPackageBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write(" \r\n");
            this.Write("create or replace PACKAGE ");
            
            #line 26 "C:\Workspaces\Workflow\Generator\DataBase\DBPackage.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableName));
            
            #line default
            #line hidden
            this.Write("_PKG AS \r\n\r\nPROCEDURE GET_");
            
            #line 28 "C:\Workspaces\Workflow\Generator\DataBase\DBPackage.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableName));
            
            #line default
            #line hidden
            this.Write("_PRC(P_ID NUMBER ,P_REFCURSOR_OUT  OUT SYS_REFCURSOR ) ;\r\nPROCEDURE ADD_");
            
            #line 29 "C:\Workspaces\Workflow\Generator\DataBase\DBPackage.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableName));
            
            #line default
            #line hidden
            this.Write("_PRC(\r\n");
            
            #line 30 "C:\Workspaces\Workflow\Generator\DataBase\DBPackage.tt"
for(int i=0;i<columnTypeList.Count;i++){ 
		if(columnNameList[i]!="DELETED_BY" 
		&& columnNameList[i]!="DELETION_DATE"
		&& columnNameList[i]!="MODIFIED_BY"
		&& columnNameList[i]!="MODIFICATION_DATE" 
		&& columnNameList[i]!="CREATION_DATE"
		&& columnNameList[i]!="ID"){
            
            #line default
            #line hidden
            this.Write("P_");
            
            #line 37 "C:\Workspaces\Workflow\Generator\DataBase\DBPackage.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(columnNameList[i]));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 37 "C:\Workspaces\Workflow\Generator\DataBase\DBPackage.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableName));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 37 "C:\Workspaces\Workflow\Generator\DataBase\DBPackage.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(columnNameList[i]));
            
            #line default
            #line hidden
            this.Write("%TYPE,\r\n");
            
            #line 38 "C:\Workspaces\Workflow\Generator\DataBase\DBPackage.tt"
}}
            
            #line default
            #line hidden
            this.Write("P_ID_OUT OUT NUMBER);\r\nPROCEDURE DEL_");
            
            #line 39 "C:\Workspaces\Workflow\Generator\DataBase\DBPackage.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableName));
            
            #line default
            #line hidden
            this.Write("_prc(P_ID NUMBER ,P_DELETED_BY ");
            
            #line 39 "C:\Workspaces\Workflow\Generator\DataBase\DBPackage.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableName));
            
            #line default
            #line hidden
            this.Write(".DELETED_BY%TYPE ) ;\r\nPROCEDURE UPD_");
            
            #line 40 "C:\Workspaces\Workflow\Generator\DataBase\DBPackage.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableName));
            
            #line default
            #line hidden
            this.Write("_PRC(\r\n");
            
            #line 41 "C:\Workspaces\Workflow\Generator\DataBase\DBPackage.tt"
for(int i=0;i<columnTypeList.Count;i++){ 
		if(columnNameList[i]!="DELETED_BY" 
		&& columnNameList[i]!="DELETION_DATE" 
		&& columnNameList[i]!="MODIFICATION_DATE"
		&& columnNameList[i]!="CREATED_BY"
		&& columnNameList[i]!="CREATION_DATE"){
		if(i<columnTypeList.Count-6){
            
            #line default
            #line hidden
            this.Write("P_");
            
            #line 48 "C:\Workspaces\Workflow\Generator\DataBase\DBPackage.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(columnNameList[i]));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 48 "C:\Workspaces\Workflow\Generator\DataBase\DBPackage.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableName));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 48 "C:\Workspaces\Workflow\Generator\DataBase\DBPackage.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(columnNameList[i]));
            
            #line default
            #line hidden
            this.Write("%TYPE,\r\n");
            
            #line 49 "C:\Workspaces\Workflow\Generator\DataBase\DBPackage.tt"
}else{
            
            #line default
            #line hidden
            this.Write("P_");
            
            #line 50 "C:\Workspaces\Workflow\Generator\DataBase\DBPackage.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(columnNameList[i]));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 50 "C:\Workspaces\Workflow\Generator\DataBase\DBPackage.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableName));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 50 "C:\Workspaces\Workflow\Generator\DataBase\DBPackage.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(columnNameList[i]));
            
            #line default
            #line hidden
            this.Write("%TYPE\r\n");
            
            #line 51 "C:\Workspaces\Workflow\Generator\DataBase\DBPackage.tt"
}}}
            
            #line default
            #line hidden
            this.Write(");\r\nPROCEDURE SEARCH_");
            
            #line 52 "C:\Workspaces\Workflow\Generator\DataBase\DBPackage.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableName));
            
            #line default
            #line hidden
            this.Write("_PRC (P_CURRENT_PAGE IN INTEGER,P_PAGE_SIZE IN INTEGER,P_TOTAL_RECORDS OUT INTEGE" +
                    "R,P_REFCURSOR_OUT OUT SYS_REFCURSOR);\r\n \r\n\r\nEND ");
            
            #line 55 "C:\Workspaces\Workflow\Generator\DataBase\DBPackage.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableName));
            
            #line default
            #line hidden
            this.Write("_PKG;\r\n");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 56 "C:\Workspaces\Workflow\Generator\DataBase\DBPackage.tt"

public string GetTypeScriptType(string dbType,string dataPrecision,string dataScale)
{
    if(dbType=="NUMBER" && string.IsNullOrEmpty(dataPrecision)){
        return "number";
    }else if(dbType=="VARCHAR2"){
        return "string";
    }else if(dbType=="VARCHAR"){
        return "string";
    }else if(dbType=="CHAR"){
        return "string";
    }else if(dbType=="DATE"){
        return "Date";
    }else if(dbType=="NUMBER" && !string.IsNullOrEmpty(dataPrecision)  && int.Parse(dataPrecision)==1){
        return "boolean";
    }else if(dbType=="NUMBER" && !string.IsNullOrEmpty(dataPrecision)  && int.Parse(dataPrecision)>1 
			&& !string.IsNullOrEmpty(dataScale) && int.Parse(dataPrecision)>0 ){
        return "number";
    }else{
    return dbType;
    }
}
public string GetType(string dbType,string dataPrecision,string dataScale)
{
    if(dbType=="NUMBER" && string.IsNullOrEmpty(dataPrecision)){
        return "int";
    }else if(dbType=="VARCHAR2"){
        return "string";
    }else if(dbType=="VARCHAR"){
        return "string";
    }else if(dbType=="CHAR"){
        return "string";
    }else if(dbType=="DATE"){
        return "DateTime";
    }else if(dbType=="NUMBER" && !string.IsNullOrEmpty(dataPrecision)  && int.Parse(dataPrecision)==1){
        return "bool";
    }else if(dbType=="NUMBER" && !string.IsNullOrEmpty(dataPrecision)  && int.Parse(dataPrecision)>1 
			&& !string.IsNullOrEmpty(dataScale) && int.Parse(dataPrecision)>0 ){
        return "double";
    }else{
    return dbType;
    }
}
public string GetNullableType(string dbType,string dataPrecision,string dataScale)
{
    if(dbType=="NUMBER" && string.IsNullOrEmpty(dataPrecision)){
        return "int?";
    }else if(dbType=="VARCHAR2"){
        return "string";
    }else if(dbType=="VARCHAR"){
        return "string";
    }else if(dbType=="CHAR"){
        return "string";
    }else if(dbType=="DATE"){
        return "DateTime?";
    }else if(dbType=="NUMBER" && !string.IsNullOrEmpty(dataPrecision)  && dataPrecision=="1"){
        return "bool?";
    }else if(dbType=="NUMBER" && !string.IsNullOrEmpty(dataPrecision)  && int.Parse(dataPrecision)>1 
			&& !string.IsNullOrEmpty(dataScale) && int.Parse(dataPrecision)>0 ){
        return "double?";
    }else{
    return dbType;
    }
}

        
        #line default
        #line hidden
        
        #line 1 "C:\Workspaces\Workflow\Generator\DataBase\DBPackage.tt"

private string _tableNameField;

/// <summary>
/// Access the tableName parameter of the template.
/// </summary>
private string tableName
{
    get
    {
        return this._tableNameField;
    }
}

private global::System.Collections.Generic.List<string> _columnNameListField;

/// <summary>
/// Access the columnNameList parameter of the template.
/// </summary>
private global::System.Collections.Generic.List<string> columnNameList
{
    get
    {
        return this._columnNameListField;
    }
}

private global::System.Collections.Generic.List<string> _columnTypeListField;

/// <summary>
/// Access the columnTypeList parameter of the template.
/// </summary>
private global::System.Collections.Generic.List<string> columnTypeList
{
    get
    {
        return this._columnTypeListField;
    }
}

private global::System.Collections.Generic.List<string> _nullableListField;

/// <summary>
/// Access the nullableList parameter of the template.
/// </summary>
private global::System.Collections.Generic.List<string> nullableList
{
    get
    {
        return this._nullableListField;
    }
}

private global::System.Collections.Generic.List<string> _dataPrecisionField;

/// <summary>
/// Access the dataPrecision parameter of the template.
/// </summary>
private global::System.Collections.Generic.List<string> dataPrecision
{
    get
    {
        return this._dataPrecisionField;
    }
}

private global::System.Collections.Generic.List<string> _dataScaleField;

/// <summary>
/// Access the dataScale parameter of the template.
/// </summary>
private global::System.Collections.Generic.List<string> dataScale
{
    get
    {
        return this._dataScaleField;
    }
}

private string _ClassNameField;

/// <summary>
/// Access the ClassName parameter of the template.
/// </summary>
private string ClassName
{
    get
    {
        return this._ClassNameField;
    }
}

private string _ObjectNameField;

/// <summary>
/// Access the ObjectName parameter of the template.
/// </summary>
private string ObjectName
{
    get
    {
        return this._ObjectNameField;
    }
}

private string _AngularFileNameField;

/// <summary>
/// Access the AngularFileName parameter of the template.
/// </summary>
private string AngularFileName
{
    get
    {
        return this._AngularFileNameField;
    }
}


/// <summary>
/// Initialize the template
/// </summary>
public virtual void Initialize()
{
    if ((this.Errors.HasErrors == false))
    {
bool tableNameValueAcquired = false;
if (this.Session.ContainsKey("tableName"))
{
    this._tableNameField = ((string)(this.Session["tableName"]));
    tableNameValueAcquired = true;
}
if ((tableNameValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("tableName");
    if ((data != null))
    {
        this._tableNameField = ((string)(data));
    }
}
bool columnNameListValueAcquired = false;
if (this.Session.ContainsKey("columnNameList"))
{
    this._columnNameListField = ((global::System.Collections.Generic.List<string>)(this.Session["columnNameList"]));
    columnNameListValueAcquired = true;
}
if ((columnNameListValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("columnNameList");
    if ((data != null))
    {
        this._columnNameListField = ((global::System.Collections.Generic.List<string>)(data));
    }
}
bool columnTypeListValueAcquired = false;
if (this.Session.ContainsKey("columnTypeList"))
{
    this._columnTypeListField = ((global::System.Collections.Generic.List<string>)(this.Session["columnTypeList"]));
    columnTypeListValueAcquired = true;
}
if ((columnTypeListValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("columnTypeList");
    if ((data != null))
    {
        this._columnTypeListField = ((global::System.Collections.Generic.List<string>)(data));
    }
}
bool nullableListValueAcquired = false;
if (this.Session.ContainsKey("nullableList"))
{
    this._nullableListField = ((global::System.Collections.Generic.List<string>)(this.Session["nullableList"]));
    nullableListValueAcquired = true;
}
if ((nullableListValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("nullableList");
    if ((data != null))
    {
        this._nullableListField = ((global::System.Collections.Generic.List<string>)(data));
    }
}
bool dataPrecisionValueAcquired = false;
if (this.Session.ContainsKey("dataPrecision"))
{
    this._dataPrecisionField = ((global::System.Collections.Generic.List<string>)(this.Session["dataPrecision"]));
    dataPrecisionValueAcquired = true;
}
if ((dataPrecisionValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("dataPrecision");
    if ((data != null))
    {
        this._dataPrecisionField = ((global::System.Collections.Generic.List<string>)(data));
    }
}
bool dataScaleValueAcquired = false;
if (this.Session.ContainsKey("dataScale"))
{
    this._dataScaleField = ((global::System.Collections.Generic.List<string>)(this.Session["dataScale"]));
    dataScaleValueAcquired = true;
}
if ((dataScaleValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("dataScale");
    if ((data != null))
    {
        this._dataScaleField = ((global::System.Collections.Generic.List<string>)(data));
    }
}
bool ClassNameValueAcquired = false;
if (this.Session.ContainsKey("ClassName"))
{
    this._ClassNameField = ((string)(this.Session["ClassName"]));
    ClassNameValueAcquired = true;
}
if ((ClassNameValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("ClassName");
    if ((data != null))
    {
        this._ClassNameField = ((string)(data));
    }
}
bool ObjectNameValueAcquired = false;
if (this.Session.ContainsKey("ObjectName"))
{
    this._ObjectNameField = ((string)(this.Session["ObjectName"]));
    ObjectNameValueAcquired = true;
}
if ((ObjectNameValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("ObjectName");
    if ((data != null))
    {
        this._ObjectNameField = ((string)(data));
    }
}
bool AngularFileNameValueAcquired = false;
if (this.Session.ContainsKey("AngularFileName"))
{
    this._AngularFileNameField = ((string)(this.Session["AngularFileName"]));
    AngularFileNameValueAcquired = true;
}
if ((AngularFileNameValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("AngularFileName");
    if ((data != null))
    {
        this._AngularFileNameField = ((string)(data));
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
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public class DBPackageBase
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
