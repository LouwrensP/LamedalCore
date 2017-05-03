using System.Collections.Generic;
using System.Linq;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zz;

namespace LamedalCore.lib.SolutionNT.ClassNT.ClassNTBody.MethodNT.MethodNTHeader.MethodNTHeader_Parameter
{
    [BlueprintRule_Class(enBlueprintClassNetworkType.VS_Static)]
    public static class MethodNTHeader_Parameter_Methods
    {
        #region Parameters_Parse

        /// <summary>
        /// Parse the method parameters.
        /// </summary>
        /// <param name="headerOriginalLine">The header original line.</param>
        /// <param name="parametersLines">The parameters line.</param>
        /// <returns>false if there was an error</returns>
        public static bool Parameters_Parse(string headerOriginalLine, out List<string> parametersLines)
        {
            //MethodDef_ method, List<string> parameterXMLHelpList

            // Get the parameters
            // -----------------------
            // public override void Trace_Application(string header, DateTime starttime = default(DateTime), params object[] theDetail)
            string buffer = headerOriginalLine;
            string pre = "(".zVar_Next(ref buffer);

            // Parameter line
            int pos1 = buffer.LastIndexOf(")");
            int pos2 = buffer.LastIndexOf(") :");
            int pos = (pos2 > 0) ? pos2 : pos1;
            string parametersStr = buffer.zSubStr_Save(0, pos);
            parametersLines = Parameter_Parse2StrList(parametersStr);

            // Check for error condition
            buffer = buffer.Substring(pos + 1);
            buffer = buffer.Trim();
            if (buffer != "" && !buffer.Contains(":") && (buffer != "{" && buffer != ";") &&
                buffer.zContains_All("{", "}") == false)
            {
                if (!buffer.Contains("//") || buffer.Substring(0, 2) != "//") return false; // This is an error - add unit test for this line
            }

            return true;
        }

        /// <summary>
        /// Converts the parameters line into a parameter string list.
        /// </summary>
        /// <param name="lineOfAllParameters">The line of all parameters.</param>
        /// <returns></returns>
        public static List<string> Parameter_Parse2StrList(string lineOfAllParameters)
        {
            var result = new List<string>();
            string parms = lineOfAllParameters;
            while (parms.Length > 0)
            {
                // Get the next parameter
                string parm = ",".zVar_Next(ref parms);
                if (parm.Contains("<") && parm.Contains(">") == false)
                {
                    parm += ", " + ">".zVar_Next(ref parms) + ">";
                    if (parm.zSubStr_Right(1) != " ") parm += " ";
                    parm += ",".zVar_Next(ref parms);
                    // This is a dictionary -> move to the next comment to get the full parameter
                }
                parm = parm.Replace("[NotNull]", "").Trim();
                result.Add(parm);
            }
            return result;
        }



        #endregion

        /// <summary>
        /// Return parameter parts.
        /// </summary>
        /// <param name="paramLine">The parameter line reference variable</param>
        /// <param name="isThis"></param>
        /// <param name="refType"></param>
        /// <param name="typeName">Return the type name</param>
        /// <param name="name">The name.</param>
        /// <param name="optionalValue">The optional value.</param>
        public static void Parameter_Parts(ref string paramLine, out bool isThis, out enParameterRefType refType, out string typeName, out string name, out string optionalValue)
        {
            var defBuffer = paramLine;
            if (defBuffer.IndexOf("this ") == 0)
            {
                isThis = true;
                "this ".zVar_Next(ref defBuffer);
            }
            else isThis = false;

            // Type ---------------------------------
            typeName = " ".zVar_Next(ref defBuffer);

            switch (typeName)
            {
                case "params":
                    {
                        refType = enParameterRefType.ParamArray;
                        typeName = " ".zVar_Next(ref defBuffer);
                        break;
                    }
                case "out":
                    {
                        refType = enParameterRefType.Output;
                        typeName = " ".zVar_Next(ref defBuffer);
                        break;
                    }
                case "ref":
                    {
                        refType = enParameterRefType.ByReference;
                        typeName = " ".zVar_Next(ref defBuffer);
                        break;
                    }

                default:
                    refType = enParameterRefType.ByValue;
                    break;
            }

            if (typeName.Contains("<") && typeName.Contains(">") == false)
            {
                typeName += " " + ">".zVar_Next(ref defBuffer) + ">";
                //if (typeName.zSubStr_Right(1) != " ") typeName += " ";
                //typeName += ",".zVar_Next(ref typeName); // This is a dictionary -> move to the next comment to get the full parameter
            }

            //if (typeName.Contains("Dictionary<"))
            //{
            //    typeName = "Dictionary";
            //    if (defBuffer.Contains(">")) ">".zVar_Next(ref defBuffer); // Move past dictionary
            //} else if (typeName.Contains("Tuple<"))
            //{
            //    typeName = "Tuple";
            //    if (defBuffer.Contains(">")) ">".zVar_Next(ref defBuffer); // Move past tuple
            //}

            // Name ---------------------
            defBuffer = defBuffer.Replace("[]", "");  // Remove array chars fromt the name
            defBuffer = defBuffer.TrimStart();        // Remove starting spaces
            name = " ".zVar_Next(ref defBuffer);

            optionalValue = defBuffer.zvar_Value("=");
            if (optionalValue == "") optionalValue = null;  // There can be confusion between "" default value and no default value. It is therefor better to assign a null for novalue.

            paramLine = defBuffer;
        }
    }
}
