using System;
using System.Collections.Generic;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.lib.SolutionNT.ClassNT.ClassNTAttributes;
using LamedalCore.zz;

namespace LamedalCore.lib.SolutionNT.ClassNT.ClassNTAttribute.ClassNTBlueprintRule
{
    [BlueprintRule_Class(enBlueprintClassNetworkType.VS_Static)]
    public static class ClassNTBlueprintRule_Methods
    {
        public static bool BlueprintRule_Attributes(string attributeCode, out string name, out List<string> parameters, out enBlueprintClassNetworkType classNetworkType,
            out string ignore1, out string ignore2, out string ignore3, out string ignore4)
        {
            ClassNTAttributes_Methods.Attribute_Parts(attributeCode, out name, out parameters);

            // Default values
            classNetworkType = enBlueprintClassNetworkType.Undefined;
            ignore1 = null;
            ignore2 = null;
            ignore3 = null;
            ignore4 = null;

            if (BlueprintRuleClass(name) == false) return false;  //<================================================

            // Test the parameters
            // The first parameter is the enBlueprintClassNetworkType
            var parm1 = parameters[0];
            classNetworkType = parm1.zEnum_To_EnumValue<enBlueprintClassNetworkType>();
            //var value = parm1.zvar_Value(".");
            //classNetworkType = value.zEnum_To_EnumValue<enBlueprintClassNetworkType>();

            foreach (string parameter in parameters)
            {
                if (parameter.Contains("Ignore_Namespace1")) ignore1 = parameter.zvar_Value("=").zRemove_DoubleQuotes();
                if (parameter.Contains("Ignore_Namespace2")) ignore2 = parameter.zvar_Value("=").zRemove_DoubleQuotes();
                if (parameter.Contains("Ignore_Namespace3")) ignore3 = parameter.zvar_Value("=").zRemove_DoubleQuotes();
                if (parameter.Contains("Ignore_Namespace4")) ignore4 = parameter.zvar_Value("=").zRemove_DoubleQuotes();
            }
            return true;
        }

        private static bool BlueprintRuleClass(string name)
        {
            if (_BlueprintRuleClass1 == null)
            {
                _BlueprintRuleClass1 = typeof(BlueprintRule_ClassAttribute).Name;
                _BlueprintRuleClass2 = _BlueprintRuleClass1.Replace("Attribute", "");
            }
            return (name == _BlueprintRuleClass1 || name == _BlueprintRuleClass2);
        }
        private static string _BlueprintRuleClass1 = null;
        private static string _BlueprintRuleClass2 = null;

        public static void BlueprintRule_AttributeParameters(List<string> parameters, out string defaultGroup, out Type defaultType, out string groupName, out bool ignoreGroup, out bool ignorePath, out bool includeObjects, out string ShortcutClass)
        {
            defaultType = null;
            defaultGroup = null;
            groupName = null;
            ignoreGroup = false;
            ignorePath = false;
            includeObjects = false;
            ShortcutClass = null;

            foreach (string parameter in parameters)
            {
                if (parameter.Contains("DefaultType"))
                {
                    var type = parameter.zvar_Value("=");
                    type = type.Replace("typeof(", "").Replace(")", "");
                    defaultType = 1f.zTypes().Convert.Type_FromStr(type);
                }
                if (parameter.Contains("DefaultGroup")) defaultGroup = parameter.zvar_Value("=").zRemove_DoubleQuotes().Replace(" ", "_");
                if (parameter.Contains("GroupName")) groupName = parameter.zvar_Value("=").zRemove_DoubleQuotes().Replace(" ", "_");
                if (parameter.Contains("IgnoreGroup")) ignoreGroup = parameter.zvar_Value("=").zTo_Bool();
                if (parameter.Contains("IgnoreGroupPath")) ignorePath = parameter.zvar_Value("=").zTo_Bool();
                if (parameter.Contains("IncludeObjects")) includeObjects = parameter.zvar_Value("=").zTo_Bool();
                if (parameter.Contains("ShortcutClass")) ShortcutClass = parameter.zvar_Value("=").zRemove_DoubleQuotes().Replace(" ", "_");
            }
        }

    }
}
