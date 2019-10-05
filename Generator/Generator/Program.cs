using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;

namespace T4TemplateGenerator
{ 
    class Program
    { 
        static void Main(string[] args)
        {
            string tableName = "APP_REQUEST";

            var solutionFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\";
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString();

            #region File paths
            string entityPath = solutionFolder + ConfigurationManager.AppSettings["EntityPath"];
            string dalPath = solutionFolder + ConfigurationManager.AppSettings["DalPath"];
            string servicePath = solutionFolder + ConfigurationManager.AppSettings["ServicePath"];
            string validatorPath = solutionFolder + ConfigurationManager.AppSettings["ValidatorPath"];
            string controllerPath = solutionFolder + ConfigurationManager.AppSettings["ControllerPath"];
            string angularEntitiyPath = solutionFolder + ConfigurationManager.AppSettings["AngularEntitiyPath"];
            string angularServicePath = solutionFolder + ConfigurationManager.AppSettings["AngularServicePath"];
            string angularComponentPath = solutionFolder + ConfigurationManager.AppSettings["AngularComponentPath"];
            #endregion

            List<string> columnNameList = new List<string>();
            List<string> columnTypeList = new List<string>();
            List<string> nullableList = new List<string>();
            List<string> dataPrecision = new List<string>();
            List<string> dataScale = new List<string>();
            List<string> columnLengthList = new List<string>();
            var conn = new OracleConnection(connectionString);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT DATA_TYPE,COLUMN_NAME,NULLABLE,DATA_PRECISION,DATA_SCALE,DATA_LENGTH  FROM all_tab_cols WHERE table_name = '" + tableName + "'";
            cmd.CommandType = CommandType.Text;
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                columnTypeList.Add(Convert.ToString(reader[0]));
                columnNameList.Add(Convert.ToString(reader[1]));
                nullableList.Add(Convert.ToString(reader[2]));
                dataPrecision.Add(Convert.ToString(reader[3]));
                dataScale.Add(Convert.ToString(reader[4]));
                columnLengthList.Add(Convert.ToString(reader[5]));
            }
            conn.Close();

            Dictionary<string, object> templateParams = new Dictionary<string, object>(){
                { "tableName", tableName },
                { "columnNameList",columnNameList},
                { "columnTypeList" ,columnTypeList},
                { "nullableList",nullableList},
                { "dataPrecision",dataPrecision },
                { "dataScale",dataScale},
                { "columnLengthList",columnLengthList},
                { "ClassName",GetClassName(tableName)},
                { "ObjectName",GetObjectName(tableName)},
                { "AngularFileName",GetAngularFileName(tableName)}
            };

            #region Server Side
            //Entity
            GenerateEntity(tableName, entityPath, templateParams);
          
            //DAL
            GenerateDAL(tableName, dalPath, templateParams);

            //Service
            GenerateService(tableName, servicePath, templateParams);

            //Validator
            GenerateValidator(tableName, validatorPath, templateParams);
            
            //Controller.
            GenerateController(tableName, controllerPath, templateParams);
            #endregion

            #region Client Side Angular
            //clientSide

            //angular entity
            GenerateAngularEntity(tableName, angularEntitiyPath, templateParams);

            //angular Service
            GenerateAngualrService(tableName, angularServicePath, templateParams);

            //angular List Component TypeScript
            GenerateListComponent(tableName, angularComponentPath, templateParams);

            //angular List Component CSS
            GenerateListCSS(tableName, angularComponentPath, templateParams);

            //angular List Component HTML
            GenerateListHTML(tableName, angularComponentPath, templateParams);

            //angular Add Component TypeScript
            GenerateAddComponent(tableName, angularComponentPath, templateParams);

            //angular Add Component CSS
            GenerateAddCSS(tableName, angularComponentPath, templateParams);

            //angular Add Component HTML
            GenerateAddHTML(tableName, angularComponentPath, templateParams);

            //angular Edit Component TypeScript
            GenerateEditComponent(tableName, angularComponentPath, templateParams);

            ////angular Edit Component CSS
            GenerateEditCSS(tableName, angularComponentPath, templateParams);

            //angular Edit Component HTML
            GenerateEditHTML(tableName, angularComponentPath, templateParams);

            #endregion

            #region Database Package and body

            GenerateDBPackage(connectionString, templateParams);

            #endregion
        }

        private static void GenerateDBPackage(string connectionString, Dictionary<string, object> templateParams)
        {
            //Package Header
            var conn = new OracleConnection(connectionString);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            var packageTemplate = new Generator.DataBase.DBPackage();
            packageTemplate.Session = templateParams;

            packageTemplate.Initialize();
            cmd.CommandText = packageTemplate.TransformText();
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            //Package Body
            var packageBodyTemplate = new Generator.DataBase.DBPackageBody();
            packageBodyTemplate.Session = templateParams;

            packageBodyTemplate.Initialize();
            cmd.CommandText = packageBodyTemplate.TransformText();
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private static void GenerateEditHTML(string tableName, string angularComponentPath, Dictionary<string, object> templateParams)
        {
            var angularEditComponentHTMLTemplate = new Generator.Angular.EditComponent.EditComponentHTML();
            angularEditComponentHTMLTemplate.Session = templateParams;
            angularEditComponentHTMLTemplate.Initialize();
            string result = angularEditComponentHTMLTemplate.TransformText();
            System.IO.File.WriteAllText(angularComponentPath + "/" + GetAngularFileName(tableName) + "/edit-" + GetAngularFileName(tableName) + "/edit-" + GetAngularFileName(tableName) + ".component.html", result);
        }

        private static void GenerateEditCSS(string tableName, string angularComponentPath, Dictionary<string, object> templateParams)
        {
            var angularEditComponentCSSTemplate = new Generator.Angular.EditComponent.EditComponentCSS();
            angularEditComponentCSSTemplate.Session = templateParams;

            angularEditComponentCSSTemplate.Initialize();
            string result = angularEditComponentCSSTemplate.TransformText();
            System.IO.File.WriteAllText(angularComponentPath + "/" + GetAngularFileName(tableName) + "/edit-" + GetAngularFileName(tableName) + "/edit-" + GetAngularFileName(tableName) + ".component.css", result);
        }

        private static void GenerateEditComponent(string tableName, string angularComponentPath, Dictionary<string, object> templateParams)
        {
            var angularEditComponentTypeScriptTemplate = new Generator.Angular.EditComponent.EditComponentTypeScript();
            angularEditComponentTypeScriptTemplate.Session = templateParams;

            angularEditComponentTypeScriptTemplate.Initialize();
            string result = angularEditComponentTypeScriptTemplate.TransformText();
            System.IO.Directory.CreateDirectory(angularComponentPath + "/" + GetAngularFileName(tableName) + "/edit-" + GetAngularFileName(tableName));
            System.IO.File.WriteAllText(angularComponentPath + "/" + GetAngularFileName(tableName) + "/edit-" + GetAngularFileName(tableName) + "/edit-" + GetAngularFileName(tableName) + ".component.ts", result);
        }

        private static void GenerateAddHTML(string tableName, string angularComponentPath, Dictionary<string, object> templateParams)
        {
            var angularAddComponentHTMLTemplate = new Generator.Angular.AddComponent.AddComponentHTML();
            angularAddComponentHTMLTemplate.Session = templateParams;

            angularAddComponentHTMLTemplate.Initialize();
            string result = angularAddComponentHTMLTemplate.TransformText();
            System.IO.File.WriteAllText(angularComponentPath + "/" + GetAngularFileName(tableName) + "/add-" + GetAngularFileName(tableName) + "/add-" + GetAngularFileName(tableName) + ".component.html", result);
        }

        private static void GenerateAddCSS(string tableName, string angularComponentPath, Dictionary<string, object> templateParams)
        {
            var angularAddComponentCSSTemplate = new Generator.Angular.AddComponent.AddComponentCSS();
            angularAddComponentCSSTemplate.Session = templateParams;

            angularAddComponentCSSTemplate.Initialize();
            string result = angularAddComponentCSSTemplate.TransformText();
            System.IO.File.WriteAllText(angularComponentPath + "/" + GetAngularFileName(tableName) + "/add-" + GetAngularFileName(tableName) + "/add-" + GetAngularFileName(tableName) + ".component.css", result);
        }

        private static void GenerateAddComponent(string tableName, string angularComponentPath, Dictionary<string, object> templateParams)
        {
            var angularAddComponentTypeScriptTemplate = new Generator.Angular.AddComponent.AddComponentTypeScript();
            angularAddComponentTypeScriptTemplate.Session = templateParams;

            angularAddComponentTypeScriptTemplate.Initialize();
            string result = angularAddComponentTypeScriptTemplate.TransformText();
            System.IO.Directory.CreateDirectory(angularComponentPath + "/" + GetAngularFileName(tableName) + "/add-" + GetAngularFileName(tableName));
            System.IO.File.WriteAllText(angularComponentPath + "/" + GetAngularFileName(tableName) + "/add-" + GetAngularFileName(tableName) + "/add-" + GetAngularFileName(tableName) + ".component.ts", result);
        }

        private static void GenerateListHTML(string tableName, string angularComponentPath, Dictionary<string, object> templateParams)
        {
            var angularListComponentHTMLTemplate = new Generator.Angular.ListComponent.ListComponentHTML();
            angularListComponentHTMLTemplate.Session = templateParams;

            angularListComponentHTMLTemplate.Initialize();
            string result = angularListComponentHTMLTemplate.TransformText();
            System.IO.File.WriteAllText(angularComponentPath + "/" + GetAngularFileName(tableName) + "/" + GetAngularFileName(tableName) + ".component.html", result);
        }

        private static void GenerateListCSS(string tableName, string angularComponentPath, Dictionary<string, object> templateParams)
        {
            var angularListComponentCSSTemplate = new Generator.Angular.ListComponent.ListComponentCSS();
            angularListComponentCSSTemplate.Session = templateParams;

            angularListComponentCSSTemplate.Initialize();
            string result = angularListComponentCSSTemplate.TransformText();
            System.IO.File.WriteAllText(angularComponentPath + "/" + GetAngularFileName(tableName) + "/" + GetAngularFileName(tableName) + ".component.css", result);
        }

        private static void GenerateListComponent(string tableName, string angularComponentPath, Dictionary<string, object> templateParams)
        {
            var angularListComponentTypeScriptTemplate = new Generator.Angular.ListComponent.ListComponetTypeScript();
            angularListComponentTypeScriptTemplate.Session = templateParams;

            angularListComponentTypeScriptTemplate.Initialize();
            string result = angularListComponentTypeScriptTemplate.TransformText();
            System.IO.Directory.CreateDirectory(angularComponentPath + "/" + GetAngularFileName(tableName));
            System.IO.File.WriteAllText(angularComponentPath + "/" + GetAngularFileName(tableName) + "/" + GetAngularFileName(tableName) + ".component.ts", result);
        }

        private static void GenerateAngualrService(string tableName, string angularServicePath, Dictionary<string, object> templateParams)
        {
            var angularServiceTemplate = new Generator.Angular.Services.AngularService();
            angularServiceTemplate.Session = templateParams;

            angularServiceTemplate.Initialize();
            string result = angularServiceTemplate.TransformText();
            System.IO.File.WriteAllText(angularServicePath + GetAngularFileName(tableName) + ".service.ts", result);
        }

        private static void GenerateAngularEntity(string tableName, string angularEntitiyPath, Dictionary<string, object> templateParams)
        {
            var angularEntityTemplate = new Generator.Angular.Classes.AngularEntity();
            angularEntityTemplate.Session = templateParams;

            angularEntityTemplate.Initialize();
            string result = angularEntityTemplate.TransformText();
            System.IO.File.WriteAllText(angularEntitiyPath + GetAngularFileName(tableName) + ".ts", result);
        }

        private static string GenerateController(string tableName, string controllerPath, Dictionary<string, object> templateParams)
        {
            var controllerTemplate = new Generator.Controller.Controller();
            controllerTemplate.Session = templateParams;

            controllerTemplate.Initialize();
            string result = controllerTemplate.TransformText();
            System.IO.File.WriteAllText(controllerPath + GetClassName(tableName) + "Controller.cs", result);
            return result;
        }

        private static string GenerateValidator(string tableName, string validatorPath, Dictionary<string, object> templateParams)
        {
            var validatorTemplate = new Generator.Validator.Validator();
            validatorTemplate.Session = templateParams;

            validatorTemplate.Initialize();
            string result = validatorTemplate.TransformText();
            System.IO.File.WriteAllText(validatorPath + GetClassName(tableName) + "Validator.cs", result);
            return result;
        }

        private static string GenerateService(string tableName, string servicePath, Dictionary<string, object> templateParams)
        {
            var serviceTemplate = new Generator.Services.Service();
            serviceTemplate.Session = templateParams;

            serviceTemplate.Initialize();
            string result = serviceTemplate.TransformText();
            System.IO.File.WriteAllText(servicePath + GetClassName(tableName) + "Service.cs", result);
            return result;
        }

        private static string GenerateDAL(string tableName, string dalPath, Dictionary<string, object> templateParams)
        {
            var dalTemplate = new Generator.DAL.DAL();
            dalTemplate.Session = templateParams;

            dalTemplate.Initialize();
            string result = dalTemplate.TransformText();
            System.IO.Directory.CreateDirectory(dalPath + "/" + GetClassName(tableName));
            System.IO.File.WriteAllText(dalPath + "/" + GetClassName(tableName) + "/" + GetClassName(tableName) + "DAL.cs", result);
            return result;
        }

        private static string GenerateEntity(string tableName, string entityPath, Dictionary<string, object> templateParams)
        {
            var entityTemplate = new Generator.Entities.Entities();
            entityTemplate.Session = templateParams;

            entityTemplate.Initialize();
            string result = entityTemplate.TransformText();
            Console.WriteLine(result);
            System.IO.File.WriteAllText(entityPath + GetClassName(tableName) + ".cs", result);
            return result;
        }

        public static string GetClassName(string text)
        {
            text = ToPascalCase(text);
            if(text.IndexOf('s')==text.Length-1){
                string result = text.Remove(text.LastIndexOf('s'));
                return result;
            }
            return text;
        }
        public static string ToPascalCase(string text)
        {
            string result = text.Split('_').Select(s => char.ToUpperInvariant(s[0]) + s.Substring(1, s.Length - 1).ToLower()).Aggregate(string.Empty, (s1, s2) => s1 + s2); ;
            return result;
        }

        public static string GetAngularFileName(string text)
        {
            string result = text.ToLower().Replace("_", "-");
            if (result.IndexOf('s') == result.Length - 1)
            {
                result = result.Remove(text.LastIndexOf('s')); 
            }
            return result;
        }

        public static string GetObjectName(string text)
        {
            text = ToPascalCase(text);
            text = Char.ToLower(text[0]) + text.Substring(1, text.Length - 1);
            if (text.LastIndexOf('s') == text.Length - 1)
            {
                text = text.Remove(text.LastIndexOf('s'));
            }
            return text;
        }
    }
}
