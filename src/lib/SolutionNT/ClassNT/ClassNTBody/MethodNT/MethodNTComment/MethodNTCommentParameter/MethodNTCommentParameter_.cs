using System.Diagnostics;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace LamedalCore.lib.SolutionNT.ClassNT.ClassNTBody.MethodNT.MethodNTComment.MethodNTCommentParameter
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_State)]
    [DebuggerDisplay("Name = {ParameterName}; Comment = {ParameterComment}")]
    public sealed class MethodNTCommentParameter_
    {
        public string ParameterName;
        public string ParameterComment;

        /// <summary>
        /// Convert fields to XML.
        /// </summary>
        public string ToXML(bool add3SlashLines = false)
        {
            return MethodNTCommentParameter_Methods.Parameter_ToXML(ParameterName, ParameterComment, true, add3SlashLines);
        }

        public static MethodNTCommentParameter_ Create(string parameterLine)
        {
            var result = new MethodNTCommentParameter_(); 

            MethodNTCommentParameter_Methods.Parameter_FromXML(parameterLine, out result.ParameterName, out result.ParameterComment);

            return result;
        }
    }
}
