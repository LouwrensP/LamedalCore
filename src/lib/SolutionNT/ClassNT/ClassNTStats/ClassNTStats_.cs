using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace LamedalCore.lib.SolutionNT.ClassNT.ClassNTStats
{
    [BlueprintRule_Class(enBlueprintClassNetworkType.Node_State)]
    public sealed class ClassNTStats_
    {
        // Class ========================
        public int ClassTotalLines;
        public int ClassTotalBlankLines;
        public int ClassTotalCommentLines;
        public int ClassTotalCodeLines;

        // Class Elements
        public int TotalAttributes;
        public int TotalMethods;
        public int TotalMethods_Public;
        public int TotalMethods_Static;
        public int TotalFields;
        public int TotalProperties;
        public int TotalEnumerals;

        // Method Lines =======================
        public int MethodTotalLines;
        public int MethodTotalBodyLines;
        public int MethodMaxLines;
        public int MethodAvgLines;

        // Code =========================
        public int CodeMaintainability;
        public int CodeComplexity;

        public static ClassNTStats_ Create()
        {
            var result = new ClassNTStats_(); // {Name = name, Value = value};
            // Statistics are updated within other methods.
            return result;
        }

    }
}
