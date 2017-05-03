using System;
using System.Collections.Generic;
using System.Diagnostics;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.lib.SolutionNT.ClassNT.ClassNTBody.MethodNT.MethodNTComment.MethodNTComment_Parameter;
using LamedalCore.zz;

namespace LamedalCore.lib.SolutionNT.ClassNT.ClassNTBody.MethodNT.MethodNTComment
{
    [Serializable]
    [BlueprintRule_Class(enBlueprintClassNetworkType.Node_State)]
    [DebuggerDisplay("Summary = {CommentSummary}; Parameters = {CommentParameters.Count}")]
    public sealed class MethodNTComment_
    {
        public string CommentSummary;
        public string CommentReturn;
        public readonly List<MethodNTComment_Parameter_> CommentParameters = new List<MethodNTComment_Parameter_>();

        /// <summary>
        /// Convert the comment to XML.
        /// </summary>
        public string ToXML(bool add3SlashLines = false)
        {
            var result = MethodNTComment_Methods.Summary_ToXML(CommentSummary, true, add3SlashLines);
            foreach (MethodNTComment_Parameter_ parameter_ in CommentParameters)
            {
                result += parameter_.ToXML(add3SlashLines);
            }
            result = result.zSubStr_RemoveStrAtEnd();  // Remove last enter
            return result;
        }

        public static MethodNTComment_ Create(List<string> sourceLines, ref int ii, out List<string> Attribute_Lines)
        {
            var result = new MethodNTComment_(); // {Name = name, Value = value};

            List<string> parameterLines;
            string ctiCodeLine;
            MethodNTComment_Methods.Comment_Parts(sourceLines, ref ii, out result.CommentSummary, out parameterLines, out Attribute_Lines, out result.CommentReturn, out ctiCodeLine);

            // Add the parameters
            foreach (string parameterLine in parameterLines)
            {
                var parameter = MethodNTComment_Parameter_.Create(parameterLine);
                result.CommentParameters.Add(parameter);
            }


            return result;
        }
    }
}
