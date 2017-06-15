using System.Collections.Generic;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace LamedalCore.lib.SolutionNT.ClassNT.ClassNTAttribute.ClassNTBlueprintRule
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_State)]
    public sealed class ClassNTBlueprintMethodRule_ : BlueprintRule_MethodAttribute
    {
        // Fields - See fields of parent class BlueprintMethodRule_Attribute

        public static ClassNTBlueprintMethodRule_ Create(string attributeCode)
        {
            var result = new ClassNTBlueprintMethodRule_(); 
            // Execute static method to populate result parameters
            string name;
            ClassNTBlueprintMethodRule_Methods.Method_Attributes(attributeCode, out name, out result.Ignore, out result.ShortcutClassName,
                        out result.ShortcutMethodName);

            return result;
        }

        [BlueprintRule_Method(Ignore = false)]
        public static ClassNTBlueprintMethodRule_ Create(List<string> attributeLines)
        {
            foreach (string attLine in attributeLines)
            {
                if (attLine.Contains("BlueprintRule_Method")) return Create(attLine);
            }
            return null;
        }

        private ClassNTBlueprintMethodRule_() { }  // Hide default constructor
    }
}
