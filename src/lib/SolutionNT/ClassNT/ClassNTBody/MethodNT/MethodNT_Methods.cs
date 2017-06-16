using System.Collections.Generic;
using System.Linq;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.lib.SolutionNT.ClassNT.ClassNTAttribute.ClassNTBlueprintRule;
using LamedalCore.lib.SolutionNT.ClassNT.ClassNTAttributes;
using LamedalCore.lib.SolutionNT.ClassNT.ClassNTBody.MethodNT.MethodNTComment;
using LamedalCore.lib.SolutionNT.ClassNT.ClassNTBody.MethodNT.MethodNTComment.MethodNTCommentParameter;
using LamedalCore.lib.SolutionNT.ClassNT.ClassNTBody.MethodNT.MethodNTHeader;
using LamedalCore.lib.SolutionNT.ClassNT.ClassNTBody.MethodNT.MethodNTHeader.MethodNTHeaderParameter;
using LamedalCore.lib.SolutionNT.ClassNT.ClassNTBody.MethodNT.MethodNTstats;
using LamedalCore.zz;

namespace LamedalCore.lib.SolutionNT.ClassNT.ClassNTBody.MethodNT
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.VS_Static)]
    public static class MethodNT_Methods
    {
        /// <summary>
        /// Parse the method.
        /// </summary>
        /// <param name="sourceLines">The source lines.</param>
        /// <param name="ii">The ii.</param>
        /// <param name="iiMethodEnd">The ii method end.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <param name="sourceCode">The source code.</param>
        /// <param name="comment">The comment.</param>
        /// <param name="attribute_Lines">The attribute_ lines.</param>
        /// <param name="attribute_Breakdown">The attribute_ breakdown.</param>
        /// <param name="methodRule">The blueprint method rule.</param>
        /// <param name="methodAliasDef">The method alias definition.</param>
        /// <param name="header">The header.</param>
        /// <param name="stats">The body.</param>
        public static void Method_Parse(List<string> sourceLines, ref int ii, int iiMethodEnd, out string methodName, out List<string> sourceCode, 
            out MethodNTComment_ comment, out List<string> attribute_Lines, out ClassNTAttributes_ attribute_Breakdown, 
            out ClassNTBlueprintMethodRule_ methodRule, out ClassNTBlueprintMethodRule_AliasDef_ methodAliasDef,
            out MethodNTHeader_ header, out MethodNTstats_ stats)
        {
            if (iiMethodEnd == 0) iiMethodEnd = sourceLines.Count-1;
            sourceCode = new List<string>();
            sourceCode.zFrom_IList(sourceLines, true, ii, iiMethodEnd);
            ii = iiMethodEnd;

            int jj = 0;
            comment = MethodNTComment_.Create(sourceCode, ref jj, out attribute_Lines);
            methodRule = ClassNTBlueprintMethodRule_.Create(attribute_Lines);
            methodAliasDef = ClassNTBlueprintMethodRule_AliasDef_.Create(attribute_Lines);
            attribute_Breakdown = ClassNTAttributes_.Create(attribute_Lines);  // attributes
            header = MethodNTHeader_.Create(sourceCode, ref jj);
            stats = MethodNTstats_.Create(sourceCode, ref jj, comment, header, attribute_Lines.Count);
            
            methodName = header.Header_Name;
        }

        /// <summary>
        /// Merges the parameters with comments.
        /// </summary>
        /// <param name="header">The header.</param>
        /// <param name="comments">The comments.</param>
        public static void SyncParametersWithComments(MethodNTHeader_ header, MethodNTComment_ comments)
        {
            var parameters = header.Header_Parameters;
            foreach (MethodNTHeaderParameter_ parameter in parameters)
            {
                var name = parameter.ParameterName.Replace("@", "");
                MethodNTCommentParameter_ parmComment = comments.CommentParameters.FirstOrDefault(x => x.ParameterName == name);
                if (parmComment != null) parameter.ParameterComment = parmComment.ParameterComment;
            }
        }
    }
}
