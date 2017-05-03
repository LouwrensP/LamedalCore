using System.Collections.Generic;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.lib.SolutionNT.ClassNT.ClassNTAttributes;
using LamedalCore.zz;

namespace LamedalCore.lib.SolutionNT.ClassNT.ClassNTAttribute.ClassNTBlueprintRule
{
    [BlueprintRule_Class(enBlueprintClassNetworkType.VS_Static)]
    public static class ClassNTBlueprintMethodRule_Methods
    {
        public static bool Method_Attributes(string attributeCode, out string name, out bool ignore, out string shortcutClassName,out string shortcutMethodName)
        {
            List<string> parameters;
            ClassNTAttributes_Methods.Attribute_Parts(attributeCode, out name, out parameters);

            // Default values
            ignore = false;
            shortcutClassName = null;
            shortcutMethodName = null;

            if (BlueprintMethodRule(name) == false) return false;  //<================================================

            // Parse the parameters

            foreach (string parameter in parameters)
            {
                if (parameter.Contains("Ignore")) ignore = parameter.zvar_Value("=").zTo_Bool();
                if (parameter.Contains("ShortcutClassName")) shortcutClassName = parameter.zvar_Value("=").zRemove_DoubleQuotes();
                if (parameter.Contains("ShortcutMethodName")) shortcutMethodName = parameter.zvar_Value("=").zRemove_DoubleQuotes();
            }

            return true;
        }

        /// <summary>Identifies a Blueprint method rule.</summary>
        /// <param name="name">The name of the attribute.</param>
        /// <returns></returns>
        public static bool BlueprintMethodRule(string name)
        {
            if (_BlueprintMethodRule1 == null)
            {
                _BlueprintMethodRule1 = typeof(BlueprintRule_MethodAttribute).Name;
                _BlueprintMethodRule2 = _BlueprintMethodRule1.Replace("Attribute", "");
            }
            return (name == _BlueprintMethodRule1 || name == _BlueprintMethodRule2);
        }
        private static string _BlueprintMethodRule1 = null;
        private static string _BlueprintMethodRule2 = null;

    }
}
