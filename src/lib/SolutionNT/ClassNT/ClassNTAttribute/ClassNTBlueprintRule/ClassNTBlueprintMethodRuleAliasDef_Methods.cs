using System;
using System.Collections.Generic;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.lib.SolutionNT.ClassNT.ClassNTAttributes;
using LamedalCore.zz;

namespace LamedalCore.lib.SolutionNT.ClassNT.ClassNTAttribute.ClassNTBlueprintRule
{
    [BlueprintRule_Class(enBlueprintClassNetworkType.VS_Static)]
    public static class ClassNTBlueprintMethodRuleAliasDef_Methods
    {
        [BlueprintRule_MethodAliasDef(MirrorClass = typeof(string), MirrorMethodName = "mirrorMethod", MirrorParameter1 = "parName")]
        public static bool Attribute_AliasDefinition(string attributeCode, out string attrinuteName, out string mirrorParameter1, out string mirrorClass, out string mirrorMethodName)
        {
            List<string> parameters;
            ClassNTAttributes_Methods.Attribute_Parts(attributeCode, out attrinuteName, out parameters);

            // Default values
            mirrorParameter1 = null;
            mirrorClass = null;
            mirrorMethodName = null;

            if (BlueprintMethodRuleAlias(attrinuteName) == false) return false;  //<================================================

            // Parse the parameters
            foreach (string parameter in parameters)
            {
                if (parameter.Contains("MirrorParameter1")) mirrorParameter1 = parameter.zvar_Value("=").zRemove_DoubleQuotes();
                if (parameter.Contains("MirrorClass")) mirrorClass = parameter.zvar_Value("=").zRemove_DoubleQuotes();
                if (parameter.Contains("MirrorMethodName")) mirrorMethodName = parameter.zvar_Value("=").zRemove_DoubleQuotes();
            }
            return true;
        }

        /// <summary>Identifies a Blueprint method rule.</summary>
        /// <param name="name">The name of the attribute.</param>
        /// <returns></returns>
        public static bool BlueprintMethodRuleAlias(string name)
        {
            if (_BlueprintMethodRule1 == null)
            {
                _BlueprintMethodRule1 = typeof(BlueprintRule_MethodAliasDefAttribute).Name;
                _BlueprintMethodRule2 = _BlueprintMethodRule1.Replace("Attribute", "");
            }
            return (name == _BlueprintMethodRule1 || name == _BlueprintMethodRule2);
        }
        private static string _BlueprintMethodRule1 = null;
        private static string _BlueprintMethodRule2 = null;

    }
}
