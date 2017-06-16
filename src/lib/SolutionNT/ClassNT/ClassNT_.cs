using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.lib.SolutionNT.ClassNT.ClassNTAttribute.ClassNTBlueprintRule;
using LamedalCore.lib.SolutionNT.ClassNT.ClassNTBody.MethodNT;
using LamedalCore.lib.SolutionNT.ClassNT.ClassNTBody.PropertyNT;
using LamedalCore.lib.SolutionNT.ClassNT.ClassNTHeader;
using LamedalCore.lib.SolutionNT.ClassNT.ClassNTStats;
using LamedalCore.zz;

namespace LamedalCore.lib.SolutionNT.ClassNT
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_State)]
    [DebuggerDisplay("Name = {ClassName}")]
    public sealed class ClassNT_
    {
        public string ClassName; //{ get; private set; } // Readonly refenerece to Classname    
        public string ClassFileName; // { get; private set; } // Readonly refenerece to Class filename                       

        public ClassNTBlueprintRule_ BlueprintRule;   // The Blueprint rules that specify the class features
        public ClassNTHeader_ Header;                 // Class header information  
        public List<MethodNT_> Methods;               // Class methods
        public List<PropertyNT_> Properties;          // Class properties
        public ClassNTStats_ Statistics;              // Statistics about the class
        public List<string> SourceCode;               // Source code of the class body 
        //[XmlIgnore]
        //public ProjectNT_ ParentProject;

        public static ClassNT_ Create(List<string> sourceLines, out bool error, out ClassNTBlueprintRule_ blueprintRule, string classFilename = ""/*, ProjectNT_ project = null */)
        {
            var result = new ClassNT_(); // {Name = name, Value = value};
            // Execute static method to populate result parameters
            int ii = 0;
            result.SourceCode = sourceLines.ToList();
            ClassNTMethods.Parse_Class(sourceLines, ref ii, result, out error, out result.Header, out result.Methods, out result.Properties, out result.Statistics, out result.BlueprintRule);
            blueprintRule = result.BlueprintRule;
            result.ClassName = result.Header.ClassName;
            result.ClassFileName = classFilename;
            //result.ParentProject = project;
            return result;
        }

        public static ClassNT_ Create(string classFile, out bool error, out ClassNTBlueprintRule_ blueprintRule /*,ProjectNT_ project = null*/)
        {
            blueprintRule = null;
            if (1f.zIO().File.Exists(classFile) == false) "Error! File '{0}' does not exists.".zFormat(classFile).zException_Show();

            string[] codeLines = 1f.zIO().RW.File_Read2StrArray(classFile);
            return ClassNT_.Create(codeLines.ToList(), out error, out blueprintRule, classFile/*, project*/);
        }

        //public static ClassNT_ Create(CodeClass2 codeClass, out bool error, out ClassNTBlueprintRule_ blueprintRule)
        //{
        //    string classFile = codeClass.FullName;
        //    return ClassNT_.Create(classFile, out error, out blueprintRule);
        //}


        /// <summary>Search for a Method.</summary>
        /// <param name="searchStr">The search string.</param>
        /// <param name="delete">if set to <c>true</c> [delete] the method.</param>
        /// <returns>MethodNT_</returns>
        public MethodNT_ Method_Find(string searchStr, bool delete = false)
        {
            // Need to remove all enters and spaces after the enter
            var list = searchStr.zConvert_Str_ToListStr("".NL());

            var searchStr2 = list.zTo_Str("", true);
            foreach (MethodNT_ method in Methods)
            {
                var header = method.Header.Method_HeaderLine;
                //var header = method.ToString();
                if (header != searchStr2) continue;  // This way is less nesting; method.ToString() is method + parameters

                if (delete) Methods.Remove(method);
                return method;
            }
            return null;
        }
    }
}