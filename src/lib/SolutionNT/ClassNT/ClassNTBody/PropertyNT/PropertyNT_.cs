using System;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace LamedalCore.lib.SolutionNT.ClassNT.ClassNTBody.PropertyNT
{
    [Serializable]
    [BlueprintRule_Class(enBlueprintClassNetworkType.Node_State)]
    public sealed class PropertyNT_
    {
        public string Name;
        public string Scope;
        public string Type;
        public string Type_Part1;
        public string Type_Part2;
        public string Type_Part3;


        public static PropertyNT_ Create(string propertyLine)
        {
            var result = new PropertyNT_(); // {Name = name, Value = value};
            // Execute static method to populate result parameters
            PropertyNT_Methods.Property_Parse(propertyLine, out result.Scope, out result.Type, out result.Name, out result.Type_Part1, out result.Type_Part2, out result.Type_Part3);

            return result;
        }


    }
}
