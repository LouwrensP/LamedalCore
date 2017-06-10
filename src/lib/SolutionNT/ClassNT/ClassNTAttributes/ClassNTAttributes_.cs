using System;
using System.Collections.Generic;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.lib.SolutionNT.ClassNT.ClassNTAttribute;

namespace LamedalCore.lib.SolutionNT.ClassNT.ClassNTAttributes
{
    [BlueprintRule_Class(enBlueprintClassNetworkType.Node_State)]
    public sealed class ClassNTAttributes_
    {
        public readonly List<ClassNTAttribute_> Items = new List<ClassNTAttribute_>(); 

        public static ClassNTAttributes_ Create(List<string> attributeCode)
        {
            var result = new ClassNTAttributes_(); 
            List<string> attributeList = ClassNTAttributes_Methods.Attributes_FromCode(attributeCode);
            foreach (string attributeStr in attributeList)
            {
                var attribute = ClassNTAttribute_.Create(attributeStr);
                result.Items.Add(attribute);
            }

            return result;
        }

    }
}
