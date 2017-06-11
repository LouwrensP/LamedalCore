using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Serialization;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.lib.SolutionNT.ClassNT.ClassNTAttribute.ClassNTBlueprintRule;
using LamedalCore.lib.SolutionNT.ClassNT.ClassNTAttributes;
using LamedalCore.lib.SolutionNT.ClassNT.ClassNTBody.MethodNT.MethodNTComment;
using LamedalCore.lib.SolutionNT.ClassNT.ClassNTBody.MethodNT.MethodNTHeader;
using LamedalCore.lib.SolutionNT.ClassNT.ClassNTBody.MethodNT.MethodNTstats;
using LamedalCore.zz;

namespace LamedalCore.lib.SolutionNT.ClassNT.ClassNTBody.MethodNT
{
    [BlueprintRule_Class(enBlueprintClassNetworkType.Node_State)]
    [DebuggerDisplay("Name = {MethodName}")]
    public sealed class MethodNT_
    {
        public string MethodName;                               // Readonly refenerce to MethodName
        public MethodNTComment_ Comment;
        // Attributes
        public List<string> Attribute_Lines;
        public ClassNTAttributes_ Attribute_Breakdown;
        public ClassNTBlueprintMethodRule_ Attribute_Rule;
        public ClassNTBlueprintMethodRuleAliasDef_ Attribute_Alias;
        public MethodNTHeader_ Header;
        public MethodNTstats_ Statistics;

        [XmlIgnore]
        public ClassNT_ ParentClass;
        public string ParentClassName;                          // Sometimes only the method code is analysed within a class. The classname is stored for quick reference to context
        public List<string> SourceCode;                         // Source code of the class body 

        public static MethodNT_ Create(string source, string parentClassName)
        {
            List<string> sourceLines = new List<string>();
            source.zConvert_Array_FromStr("".NL()).zTo_List(sourceLines);
            int ii = 0;
            return Create(sourceLines, ref ii, -1, parentClassName: parentClassName);
        }

        public static MethodNT_ Create(List<string> sourceLines, ref int ii, int iiMethodEnd, ClassNT_ parentClass = null, string parentClassName = "")
        {
            var result = new MethodNT_(); // {Name = name, Value = value};
            // Execute static method to populate result parameters
            result.ParentClass = parentClass;
            if (parentClass != null) result.ParentClassName = parentClass.ClassName;
            else if (parentClassName != "") result.ParentClassName = parentClassName;

            MethodNT_Methods.Method_Parse(sourceLines, ref ii, iiMethodEnd, out result.MethodName, out result.SourceCode, out result.Comment,
                    out result.Attribute_Lines, out result.Attribute_Breakdown, out result.Attribute_Rule, out result.Attribute_Alias, 
                    out result.Header, out result.Statistics);

            MethodNT_Methods.SyncParametersWithComments(result.Header, result.Comment);   // Sync comments to the header parameters
            //result.MethodName = result.Header.Header_Name;
            return result;
        }

    }
}
