using System;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Net;
using System.Text;
using JetBrains.Annotations;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zz;

namespace LamedalCore.lib.XML
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_Action)]
    public sealed class XML_Setup
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance; // system library

        /// <summary>Converts the input string to valid XML by replacing illegal characters with their XML codes.</summary>
        /// <param name="inputStr">The input string</param>
        /// <returns>string</returns>
        [Pure]
        public string Fix_InvalidXML(string inputStr)
        {
            if (inputStr.zIsNullOrEmpty()) return "";  // Return empty string 

            if (inputStr.Substring(0, 1) != "<")
            {
                inputStr = inputStr.Replace("<", "&lt;")
                    .Replace(">", "&gt;")
                    .Replace("\"", "&quot;")
                    .Replace("'", "&apos;");
            // Do not do this replace .Replace("&", "&amp;")
            }

            string result = Regex.Replace(inputStr, @"value=\""(.*?)\""", m => "value=\"" + WebUtility.HtmlEncode(WebUtility.HtmlDecode(m.Groups[1].Value)) + "\"");
            result = result.Replace("\\", "/")
                .Replace("<!doctype", "<!DOCTYPE")
                .Replace("</doctype", "</DOCTYPE"); // Convert backslash \ to forward slash/
            return result;
        }

        /// <summary>
        /// Function to fix XML  document from the XML.
        /// </summary>
        /// <param name="xml">The XML</param>
        /// <param name="root">The root.</param>
        /// <returns>
        /// string
        /// </returns>
        public string Fix_XMLErrorRootElements(string xml, string root = "doc")
        {
            var doFix = false;
            
            // Null comment
            if (xml == null) return "<{0}></{0}>".zFormat(root);

            // Remove comments
            if (xml.Contains("///"))
            {
                xml = xml.Replace("///", "");
                doFix = true;
            }
            else
            {
                // Test for root node
                var root1 = xml.zvar_Id(">");
                var rootend = root1.Replace("<", "</") + ">";
                var rootend2 = xml.zSubStr_Right(root1.Length);
                if (rootend != rootend2) doFix = true;
            }

            if (doFix) xml = "<doc>".NL() + xml.NL() + "</doc>";
            return xml;
        }

        /// <summary>Formats XML into a structure</summary>
        /// <param name="unformatedXML">The unformated XML.</param>
        /// <param name="convert2ValidXMLFirst">if set to <c>true</c> [convert2 valid XML first].</param>
        /// <returns></returns>
        public string XML_Format(string unformatedXML, bool convert2ValidXMLFirst = false)
        {
            string result = null;
            if (convert2ValidXMLFirst) unformatedXML = Fix_InvalidXML(unformatedXML);
            try
            {
                var xElement = XElement.Parse(unformatedXML);
                result = XML_Format(xElement);
            }
            catch (Exception ex)
            {
                ex.zLogLibraryMsg();
                throw;
            }
            return result;
        }

        /// <summary>Formats XML into a structure</summary>
        /// <param name="unformatedHTML">The unformated HTML.</param>
        /// <param name="element">The element.</param>
        /// <param name="removeScriptsAndStyle">if set to <c>true</c> [remove scripts and style].</param>
        /// <param name="nodes2Remove">The nodes2 remove.</param>
        /// <returns></returns>
        public string XML_FormatHTML(string unformatedHTML, out XElement element, bool removeScriptsAndStyle = true, params string[] nodes2Remove)
        {
            element = _lamed.lib.XML.xDoc.Element_FromHtmlStr(unformatedHTML, removeScriptsAndStyle, nodes2Remove);
            var formatedXML = _lamed.lib.XML.Setup.XML_Format(element);
            return formatedXML;
        }

    public string XML_Format(XElement xElement)
        {
            return xElement.ToString();
        }

        /// <summary>
        /// Return the XML elements beteen the tag pattern.
        /// </summary>
        /// <param name="xml">The XML</param>
        /// <param name="tag">The node</param>
        /// <param name="tagHasAttributes">if set to <c>true</c> [tagHasAttributes].</param>
        /// <param name="errorIfTagNotFound">if set to <c>true</c> [error if tag not found].</param>
        /// <returns>
        /// string
        /// </returns>
        public string XML_ValueBetweenTags(string xml, string tag, bool tagHasAttributes = false, bool errorIfTagNotFound = true)
        {
            var startTag = (tagHasAttributes) ? "<" + tag + " " : "<" + tag + ">";
            return XML_ValueBetweenTags(xml, startTag, "</" + tag + ">",errorIfTagNotFound);
        }

        /// <summary>
        /// From the input string return the sub-string located between the start and end tags.
        /// </summary>
        /// <param name="inputStr">The inputStr.</param>
        /// <param name="startTag">The start tag.</param>
        /// <param name="endTag">The end tag.</param>
        /// <param name="errorIfTagNotFound">if set to <c>true</c> [error if tag not found].</param>
        /// <returns>
        /// string.
        /// </returns>
        [Pure]
        public string XML_ValueBetweenTags([NotNull] string inputStr, string startTag, string endTag, bool errorIfTagNotFound = true)
        {
            var result = "";
            if (inputStr.zIsNullOrEmpty()) return result;
            if (inputStr.Contains(startTag) && inputStr.Contains(endTag))
            {
                var indexStart = inputStr.IndexOf(startTag) + startTag.Length;
                var indexEnd = inputStr.IndexOf(endTag);
                //return SubStr_ValueBetweenIndexes(inputStr, indexStart, indexEnd - indexStart);
                result = _lamed.Types.String.Edit.SubStr_Index(inputStr, indexStart, indexEnd);
            } else if (errorIfTagNotFound)
            {
                ArgumentException ex;
                if (inputStr.Contains(startTag) == false)
                     ex = new ArgumentException($"Error! '{startTag}' was not found in XML '{inputStr}'", nameof(startTag));
                else ex = new ArgumentException($"Error! '{endTag}' was not found in XML '{inputStr}'", nameof(endTag));
                ex.zLogLibraryMsg();
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// Return the XML Attribute value parameterfrom the  XML line.
        /// </summary>
        /// <param name="attributeLine">The attribute line</param>
        /// <param name="attribute">The attribute</param>
        /// <param name="attributeName">The attribute name</param>
        /// <param name="nameValue">Return the name value</param>
        /// <returns>string</returns>
        public string XML_Attribute(string attributeLine, string attribute, string attributeName, out string nameValue)
        {
            // <param name="paramLine">The parameter line.</param>
            var line = attributeLine.zConvert_XML_ValueBetweenTags(attribute, true);
            nameValue = line.zConvert_XML_ValueBetweenTags(attributeName + "=\"", "\">");
            var result = line.zvar_Value("\">");
            return result;
        }
    }
}
