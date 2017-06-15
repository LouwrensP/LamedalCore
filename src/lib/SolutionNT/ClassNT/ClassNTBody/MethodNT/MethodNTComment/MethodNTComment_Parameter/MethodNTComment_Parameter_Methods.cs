using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zz;

namespace LamedalCore.lib.SolutionNT.ClassNT.ClassNTBody.MethodNT.MethodNTComment.MethodNTComment_Parameter
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.VS_Static)]
    public static class MethodNTComment_Parameter_Methods
    {
        /// <summary>
        /// Parameter values from the  XML parameter line.
        /// </summary>
        /// <param name="paramLine">The parameter line</param>
        /// <param name="nameValue">Return the name value</param>
        /// <param name="commentValue">The comment value.</param>
        public static void Parameter_FromXML(string paramLine, out string nameValue, out string commentValue)
        {
            commentValue = LamedalCore_.Instance.lib.XML.Setup.XML_Attribute(paramLine, "param", "name", out nameValue);
        }

        /// <summary>Create string from setup XML parameter definition.</summary>
        /// <param name="parameterName">The parameter name.</param>
        /// <param name="helpStr">The help string.</param>
        /// <param name="convertToValidXML">if set to <c>true</c> [convert to valid XML].</param>
        /// <param name="add3SlashLines">if set to <c>true</c> [add3 slash lines].</param>
        /// <returns>string</returns>
        public static string Parameter_ToXML(string parameterName, string helpStr, bool convertToValidXML = false, bool add3SlashLines = false)
        {
            var space = ClassNT_Methods.codeSpace;
            if (add3SlashLines) space += "/// ";
            if (convertToValidXML) helpStr = LamedalCore_.Instance.lib.XML.Setup.Fix_InvalidXML(helpStr);
            var result = space + "<param name=\"" + parameterName + "\">" + helpStr + "</param>".NL();
            return result;
        }
    }
}
