using System.Collections.Generic;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.lib.SolutionNT.ClassNT.ClassNTAttributes;
using LamedalCore.lib.SolutionNT.ClassNT.ClassNTStats;
using LamedalCore.zz;

namespace LamedalCore.lib.SolutionNT.ClassNT.ClassNTBody.MethodNT.MethodNTComment
{
    [BlueprintRule_Class(enBlueprintClassNetworkType.VS_Static)]
    public static class MethodNTComment_Methods
    {
        /// <summary>
        /// Get the documentation return string.
        /// </summary>
        /// <param name="documentationReturnLine">The documentation return line</param>
        /// <returns>string</returns>
        public static string Return_FromXML(string documentationReturnLine)
        {
            return documentationReturnLine.zConvert_XML_ValueBetweenTags("returns");
        }
        
        /// <summary>
        /// Create string from setup XML return definition.
        /// </summary>
        /// <param name="returnHelpStr">The return help string.</param>
        /// <param name="convertToValidXML">The convert to validentifier XML.</param>
        /// <returns>string</returns>
        public static string Return_ToXML(string returnHelpStr, bool convertToValidXML = false)
        {
            if (convertToValidXML) returnHelpStr = LamedalCore_.Instance.lib.XML.Setup.Fix_InvalidXML(returnHelpStr);
            returnHelpStr = ClassNT_Methods.codeSpace + "<returns>" + returnHelpStr + "</returns>";
            return returnHelpStr;
        }

        /// <summary>
        /// Function to get the comment from XML 
        /// </summary>
        /// <param name="XML">The XML</param>
        /// <returns>string</returns>
        public static string Summary_FromXML(string XML)
        {
            return LamedalCore_.Instance.lib.XML.Setup.XML_ValueBetweenTags(XML, "summary").Replace("///", "").Trim();
        }

        /// <summary>Create string from setup XML summary definition.</summary>
        /// <param name="summaryStr">The summary string.</param>
        /// <param name="convertToValidXML">The convert to validentifier XML.</param>
        /// <param name="Add3Slashes">if set to <c>true</c> [add3 slashes].</param>
        /// <returns>string</returns>
        public static string Summary_ToXML(string summaryStr, bool convertToValidXML = false, bool Add3Slashes = false)
        {
            var space = ClassNT_Methods.codeSpace;
            if (Add3Slashes) space += "/// ";
            if (convertToValidXML) summaryStr = LamedalCore_.Instance.lib.XML.Setup.Fix_InvalidXML(summaryStr);
            var summaryXML = space + "<summary>" + summaryStr + "</summary>".NL();    // Do not add newline here
            return summaryXML;
        }

        #region Comment_Parts

        /// <summary>
        /// Converts the method's documentation to intermediate lines list.
        /// </summary>
        /// <param name="sourceLines">The header lines list</param>
        /// <param name="ii">The ii indexer reference variable</param>
        /// <param name="summaryLine">The summary line.</param>
        /// <param name="parameterLines">The documentation lines.</param>
        /// <param name="attributeLines">The attribute lines.</param>
        /// <param name="returnLine">The return line.</param>
        /// <param name="ctiCodeLine">The cti code line.</param>
        public static void Comment_Parts(List<string> sourceLines, ref int ii, out string summaryLine, out List<string> parameterLines, out List<string> attributeLines, out string returnLine, out string ctiCodeLine)
        {
            // <summary>Determines whether the specified input string contains index. This is supposed to be faster than IndexOf()</summary>
            bool summaryStart = false;
            bool returnStart = false;
            bool codeStart = false;
            parameterLines = new List<string>();
            attributeLines = new List<string>();
            returnLine = "";
            summaryLine = "";
            ctiCodeLine = "";

            string line = sourceLines[ii].Trim();
            while (line == "" || line.Contains("///") || line.Substring(0, 1) == "[")
            {
                if (line.Substring(0, 1) == "[")
                {
                    // Attributes
                    attributeLines.AddRange(Source_ParseAttributeLine(line));
                }
                else if (line.Contains("////") == false && line != "")
                {
                    // This is not a comment or this is an empty line -> This is the documentation
                    line = line.Replace("///", "").Trim();

                    #region Summary =======================================================
                    if (summaryStart)
                    {
                        if (summaryLine != "<summary>") summaryLine += " ";
                        summaryLine += line;
                        if (line.Contains("</summary>"))
                        {
                            summaryStart = false;
                            line = summaryLine;
                        }
                    }
                    else if (line.Contains("<summary>"))
                    {
                        summaryLine = line;
                        if (line.Contains("</summary>") == false) summaryStart = true;
                    }
                    #endregion

                    #region Return ======================================================
                    if (returnStart)
                    {
                        if (returnLine != "<returns>") returnLine += " ";
                        returnLine += line;
                        if (line.Contains("</returns>"))
                        {
                            returnStart = false;
                            line = returnLine;
                        }
                    }
                    else if (line.Contains("<returns>"))
                    {
                        returnLine = line;
                        if (line.Contains("</returns>") == false) returnStart = true;
                    }
                    #endregion ==============================================================

                    #region Code ======================================================
                    if (codeStart)
                    {
                        ctiCodeLine += line;
                        if (ctiCodeLine.Contains("</code>"))
                        {
                            codeStart = false;
                            line = ctiCodeLine;
                        }
                    }
                    else if (line.Contains("<code>"))
                    {
                        ctiCodeLine = line;
                        if (line.Contains("</code>") == false) codeStart = true;
                    }
                    #endregion ==============================================================

                    // Only add the line if we know what the return value is -> we want to compress the XML to viewer lines as it is then more readable
                    if (summaryStart == false && returnStart == false)
                    {
                        if (line.Contains("<param name")) parameterLines.Add(line);
                    }
                }

                ii++;
                line = sourceLines[ii].Trim(); // Move to the next line
            }

            summaryLine = summaryLine.zConvert_XML_ValueBetweenTags("summary").Trim();
            returnLine = returnLine.zConvert_XML_ValueBetweenTags("returns").Trim();
            ctiCodeLine = ctiCodeLine.zConvert_XML_ValueBetweenTags("code").Trim();
        }

        private static List<string> Source_ParseAttributeLine(string line)
        {
            // Is there more than one attribute in the same line -> split the lines
            List<string> attributes = line.zConvert_Str_ToListStr(", ");
            if (attributes.Count > 1)
            {
                for (int ii = 0; ii < attributes.Count; ii++)
                {
                    if (ii > 0) attributes[ii] = "[" + attributes[ii];
                    if (ii < attributes.Count - 1) attributes[ii] = attributes[ii] + "]";
                }
            }
            return attributes;
        }

        #endregion

        /// <summary>
        /// Converts the method's documentation to intermediate lines list.
        /// </summary>
        /// <param name="sourceLines">The header lines list</param>
        /// <param name="ii">The ii indexer reference variable</param>
        /// <param name="statistics"></param>
        /// <param name="commentLines">The documentation lines.</param>
        /// <param name="summaryLine">The summary line.</param>
        /// <param name="attributeLines">The attribute lines.</param>
        /// <param name="returnLine">The return line.</param>
        /// <param name="ctiCodeLine">The cti code line.</param>
        public static void Documentation_Parts(List<string> sourceLines, ref int ii, ClassNTStats_ statistics, out List<string> commentLines, out string summaryLine, 
                    out List<string> attributeLines, out string returnLine, out string ctiCodeLine)
        {
            // <summary>Determines whether the specified input string contains index. This is supposed to be faster than IndexOf()</summary>
            bool summaryStart = false;
            bool returnStart = false;
            //bool codeStart = false;
            commentLines = new List<string>();
            attributeLines = new List<string>();
            returnLine = "";
            summaryLine = "";
            ctiCodeLine = "";

            string line = sourceLines[ii].Trim();
            while (line == "" || line.Contains("///") || line.Substring(0, 1) == "[")
            {
                statistics.ClassTotalLines++;
                if (line.Substring(0, 1) == "[")
                {
                    // Attributes
                    attributeLines.AddRange(ClassNTAttributes_Methods.Attributes_FromCodeLine(line));
                    statistics.TotalAttributes++;
                    statistics.ClassTotalCodeLines++;
                }
                else if (line.Contains("////") == false && line != "")
                {
                    // This is not a comment or this is an empty line -> This is the documentation
                    statistics.ClassTotalCommentLines++;
                    line = line.Replace("///", "").Trim();

                    #region Summary =======================================================
                    if (summaryStart)
                    {
                        summaryLine += line;
                        if (line.Contains("</summary>"))
                        {
                            summaryStart = false;
                            line = summaryLine;
                        }
                    }
                    else if (line.Contains("<summary>"))
                    {
                        summaryLine = line;
                        if (line.Contains("</summary>") == false) summaryStart = true;
                    }
                    #endregion

                    #region Return ======================================================
                    if (returnStart)
                    {
                        returnLine += line;
                        if (line.Contains("</returns>"))
                        {
                            returnStart = false;
                            line = returnLine;
                        }
                    }
                    else if (line.Contains("<returns>"))
                    {
                        returnLine = line;
                        if (line.Contains("</returns>") == false) returnStart = true;
                    }
                    #endregion ==============================================================

                    #region Code ======================================================
                    // Code tag is no longer used
                    //if (codeStart)
                    //{
                    //    ctiCodeLine += line;
                    //    if (ctiCodeLine.Contains("</code>"))
                    //    {
                    //        codeStart = false;
                    //        line = ctiCodeLine;
                    //    }
                    //}
                    //else 
                    //if (line.Contains("<code "))
                    //{
                    //    ctiCodeLine = line;
                    //    if (line.Contains("</code>") == false) codeStart = true;
                    //}
                    #endregion ==============================================================

                    // Only add the line if we know what the return value is -> we want to compress the XML to viewer lines as it is then more readable
                    if (summaryStart == false && returnStart == false) commentLines.Add(line);
                }

                ii++;
                line = sourceLines[ii].Trim(); // Move to the next line
            }

            summaryLine = summaryLine.zConvert_XML_ValueBetweenTags("summary");
        }
    }
}
