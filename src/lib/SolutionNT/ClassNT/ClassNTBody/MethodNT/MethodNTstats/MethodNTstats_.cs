using System;
using System.Collections.Generic;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.lib.SolutionNT.ClassNT.ClassNTBody.MethodNT.MethodNTComment;
using LamedalCore.lib.SolutionNT.ClassNT.ClassNTBody.MethodNT.MethodNTHeader;
using LamedalCore.zz;

namespace LamedalCore.lib.SolutionNT.ClassNT.ClassNTBody.MethodNT.MethodNTstats
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_State)]
    public sealed class MethodNTstats_
    {
        // Method Lines =======================
        public int MethodTotalLines;
        public int MethodTotalCommentLines;
        public int MethodTotalBodyLines;

        // Code =========================
        /// <summary>The complexity of the given method body. The higher the count the more complex the method</summary>
        public int CodeComplexity;
        public int CodeMaintainability;

        // Other info
        public List<string> ReferenceCalls;         // Reference calls of the method
        public readonly List<string> SourceLines = new List<string>();            // Source lines of the method

        [Test_IgnoreCoverage(enCode_TestIgnore.MethodIsShortCut)]
        public static MethodNTstats_ Create(List<string> sourceLines, ref int ii, MethodNT_ method)
        {
            return Create(sourceLines, ref ii, method.Comment, method.Header, method.Attribute_Lines.Count);
        }

        /// <summary>Creates the specified statistics for the source lines.</summary>
        /// <param name="sourceLines">The source lines.</param>
        /// <param name="ii">The ii.</param>
        /// <param name="comments">The comments.</param>
        /// <param name="header">The header.</param>
        /// <param name="attributeLines">The attribute lines.</param>
        /// <returns></returns>
        public static MethodNTstats_ Create(List<string> sourceLines, ref int ii, MethodNTComment_ comments = null,  MethodNTHeader_ header = null, int attributeLines = 0)
        {
            var result = new MethodNTstats_(); // {Name = name, Value = value};
            // Execute static method to populate result parameters
            sourceLines.zTo_IList(result.SourceLines, true, ii);

            // comments
            var commentCount = 0;
            if (comments != null)
            {
                commentCount = comments.CommentParameters.Count;
                if (comments.CommentReturn != "") commentCount++;
                if (comments.CommentSummary != "") commentCount++;
            }
            
            result.MethodTotalCommentLines = commentCount;
            result.MethodTotalLines = sourceLines.Count;
            result.MethodTotalBodyLines = sourceLines.Count - commentCount - attributeLines - 3; // 3 = header + { + }
            if (result.MethodTotalBodyLines < 1) result.MethodTotalBodyLines = 1;

            MethodNTstats_Methods.Method_Stats(result.SourceLines, out result.CodeComplexity, out result.CodeMaintainability,
                        out result.ReferenceCalls, header);
            return result;
        }
    }
}
