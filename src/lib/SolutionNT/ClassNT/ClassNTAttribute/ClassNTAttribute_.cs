using System;
using System.Collections.Generic;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.lib.SolutionNT.ClassNT.ClassNTAttributes;

namespace LamedalCore.lib.SolutionNT.ClassNT.ClassNTAttribute
{
    [Serializable]
    [BlueprintRule_Class(enBlueprintClassNetworkType.Node_State)]
    public sealed class ClassNTAttribute_
    {
        public string AttributeName;
        public readonly List<ClassNTAttribute_Parameter_> Parameters = new List<ClassNTAttribute_Parameter_>();

        public static ClassNTAttribute_ Create(string attributeStr)
        {
            var result = new ClassNTAttribute_();
            List<string> parameterList;
            ClassNTAttributes_Methods.Attribute_Parts(attributeStr, out result.AttributeName, out parameterList);
            foreach (string parameterStr in parameterList)
            {
                var parameter = ClassNTAttribute_Parameter_.Create(result.AttributeName, parameterStr);
                result.Parameters.Add(parameter);
            }
            return result;
        }

    }
}
