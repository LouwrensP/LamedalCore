using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.lib.SolutionNT.ClassNT.ClassNTAttributes;
using LamedalCore.lib.SolutionNT.ClassNT.ClassNTStats;

namespace LamedalCore.lib.SolutionNT.ClassNT.ClassNTHeader
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_State)]
    public sealed class ClassNTHeader_
    {
        public string NameSpace_Name;                   // The Namespace of the class
        public List<string> NameSpace_UsingLines;       // Using
        public List<string> NameSpace_AttributeLines;   // Attribute Liness
        public ClassNTAttributes_ Namespace_Attributes; // Attribute breakdown

        public string ClassName;
        public string ClassName_ShortVersion = "";   // Sometimes the class name contain the namespace - the shorter version will have the namespace removed
        public string ClassName_Group;               // Last word in the namespace of the class (or the group of the class)
        public string ClassName1;                   // Part of Class before the '_'
        public string ClassName2;                   // Part of Class after the '_'

        public string Header_Comment;                      // Help defined for the class
        public List<string> Header_CommentLines;
        public string Header_ClassScope;                   // Tag_Scope of the class (private / public)
        public string Header_ClassKind;
        public string Header_ClassBase;                    // Parent Class


        public static ClassNTHeader_ Create(List<string> sourceLines, out int ii, ClassNTStats_ statistics)
        {
            var result = new ClassNTHeader_(); // {Name = name, Value = value};
            // Execute static method to populate result parameters

            var isClass = ClassNTHeader_Methods.Parse_ClassHeader(sourceLines, out ii, statistics, out result.NameSpace_UsingLines, out result.NameSpace_AttributeLines,
                out result.NameSpace_Name, out result.Header_Comment, out result.Header_CommentLines);

            if (isClass)
            {
                ClassNTHeader_Methods.Parse_ClassDefinition(sourceLines[ii++], result.NameSpace_Name,
                    out result.Header_ClassKind, out result.Header_ClassScope,
                    out result.ClassName, out result.Header_ClassBase, out result.ClassName_Group,
                    out result.ClassName_ShortVersion);

                ClassNTHeader_Methods.ClassNameBreakdown(result.ClassName, out result.ClassName1, out result.ClassName2);
                result.Namespace_Attributes = ClassNTAttributes_.Create(result.NameSpace_AttributeLines);
            } else result = null;

            return result;
        }

        
    }
}
