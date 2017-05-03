using System.Collections.Generic;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zz;

namespace LamedalCore.lib.SolutionNT.ClassNT.ClassNTAttribute.ClassNTBlueprintRule
{
    [BlueprintRule_Class(enBlueprintClassNetworkType.Node_State)]
    public sealed class ClassNTBlueprintRule_ : BlueprintRule_ClassAttribute
    {
        // Fields - See fields of parent class BlueprintRule_Attribute
        public static ClassNTBlueprintRule_ Create(string attributeCode)
        {
            var result = new ClassNTBlueprintRule_(); // {Name = name, Value = value};
            // Execute static method to populate result parameters
            string name;
            List<string> parameters;
            if (ClassNTBlueprintRule_Methods.BlueprintRule_Attributes(attributeCode, out name, out parameters,
                out result.ClassType, out result.Ignore_Namespace1, out result.Ignore_Namespace2, out result.Ignore_Namespace3, out result.Ignore_Namespace4))
            {
                ClassNTBlueprintRule_Methods.BlueprintRule_AttributeParameters(parameters, out result.DefaultGroup,
                                out result.DefaultType, out result.GroupName, out result.IgnoreGroup, out result.IgnoreGroupPath,
                                out result.IncludeObjects, out result.ShortcutClass);
            }

            return result;
        }

        public static ClassNTBlueprintRule_ Create(List<string> attributeLines)
        {
            foreach (string attLine in attributeLines)
            {
                if (BlueprintRule_ClassIsIn(attLine)) return Create(attLine);
            }
            return null;
        }

        /// <summary>Identifies a Blueprint method rule.</summary>
        /// <param name="codeLine">The code line to be tested</param>
        /// <returns></returns>
        private static bool BlueprintRule_ClassIsIn(string codeLine)
        {
            if (_BlueprintRule_Class1 == null)
            {
                _BlueprintRule_Class1 = typeof(BlueprintRule_ClassAttribute).Name;
                _BlueprintRule_Class2 = _BlueprintRule_Class1.Replace("Attribute", "");
            }
            return codeLine.zContains_Any(_BlueprintRule_Class1, _BlueprintRule_Class2);
        }
        private static string _BlueprintRule_Class1 = null;
        private static string _BlueprintRule_Class2 = null;

        //private ClassNTBlueprintRule_() { }  // Hide default constructor

        public ClassNTBlueprintRule_(enBlueprintClassNetworkType classType = enBlueprintClassNetworkType.Undefined) : base(classType)
        {
        }
    }
}
