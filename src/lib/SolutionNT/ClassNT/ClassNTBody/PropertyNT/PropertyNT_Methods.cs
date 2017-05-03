using System.Collections.Generic;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zz;

namespace LamedalCore.lib.SolutionNT.ClassNT.ClassNTBody.PropertyNT
{
    [BlueprintRule_Class(enBlueprintClassNetworkType.VS_Static)]
    public static class PropertyNT_Methods
    {
        /// <summary>
        /// Parses the specified property line.
        /// </summary>
        /// <param name="propertyLine">The property line.</param>
        /// <param name="scope">The scope.</param>
        /// <param name="type">The type.</param>
        /// <param name="name">The name.</param>
        /// <param name="typePart1">The type_ part1.</param>
        /// <param name="typePart2">The type_ part2.</param>
        /// <param name="typePart3">The type_ part3.</param>
        public static void Property_Parse(string propertyLine, out string scope, out string type, out string name, out string typePart1, out string typePart2, out string typePart3)
        {
            typePart1 = "";
            typePart2 = "";
            typePart3 = "";

            var words = propertyLine.zConvert_Array_FromStr(" ");
            if (words.Count != 3) "Error in CodeDef_Property parser!".zException_Show();

            scope = words[0];
            name = words[2];
            type = words[1];

            List<string> parts = type.zConvert_Str_ToListStr("_");
            if (parts.Count > 0) typePart1 = parts[0];
            if (parts.Count > 1) typePart2 = parts[1];
            if (parts.Count > 2)
            {
                typePart3 = parts[2];
                typePart2 += "_" + typePart3;
            }
        }
    }
}
