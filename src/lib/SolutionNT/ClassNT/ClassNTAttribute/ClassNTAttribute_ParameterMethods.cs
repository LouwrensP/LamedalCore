using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zz;

namespace LamedalCore.lib.SolutionNT.ClassNT.ClassNTAttribute
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.VS_Static)]
    public static class ClassNTAttribute_ParameterMethods
    {
        /// <summary>
        /// Parameter attribute.
        /// </summary>
        /// <param name="attributeName">The attribute name</param>
        /// <param name="parameterStr">The parameter string</param>
        /// <param name="name">Return the name</param>
        /// <param name="value">Return the value</param>
        public static void Attribute_Parameter(string attributeName, string parameterStr, out string name, out object value, out bool isEnum)
        {
            var _lamed = LamedalCore_.Instance;

            string valueStr;
            if (parameterStr.Contains("="))
            {
                name = parameterStr.zvar_Id("=");
                valueStr = parameterStr.zvar_Value("=").zRemove_DoubleQuotes();
            }
            else
            {
                name = attributeName;
                valueStr = parameterStr;
            }

            // true / false checks
            if (valueStr == "true") value = true;
            else if (valueStr == "false") value = false;
            else value = valueStr;

            // enum checks
            isEnum = _lamed.Types.String.Regex.IsLike(valueStr, "en*.*");
        }
    }
}
