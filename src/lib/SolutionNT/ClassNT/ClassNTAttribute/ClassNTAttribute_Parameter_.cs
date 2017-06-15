using System;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace LamedalCore.lib.SolutionNT.ClassNT.ClassNTAttribute
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_State)]
    public sealed class ClassNTAttribute_Parameter_
    {
        public string Name;
        public object Value;
        public bool IsEnumeral = false;  // Test for "en*.*"

        /// <summary>
        /// Setups the parameter from the attribute name.
        /// </summary>
        /// <param name="attributeName">The attribute name</param>
        /// <param name="parameterStr">The parameter string</param>
        /// <returns>MethodNTAttribute_Parameter</returns>
        public static ClassNTAttribute_Parameter_ Create(string attributeName, string parameterStr)
        {
            string name;
            object value;
            bool isEnum;
            ClassNTAttribute_Parameter_Methods.Attribute_Parameter(attributeName, parameterStr, out name, out value, out isEnum);

            return new ClassNTAttribute_Parameter_ {Name = name, Value = value, IsEnumeral = isEnum};
        }
    }
}
