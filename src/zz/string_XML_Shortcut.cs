using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace LamedalCore.zz
{
    [Test_IgnoreCoverage(enCode_TestIgnore.MethodIsShortCut)]
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Transformation_Extention)]
    public static class string_XML_Shortcut
    {
        /// <summary>
        /// Function to return list of XML attributes from the XML element.
        /// </summary>
        /// <param name="xmlElement">The XML element</param>
        /// <returns>List <XAttribute/></returns>
        /// <code>
        /// CTIN_Transformation;
        /// </code>
        public static List<XAttribute> zxDoc_List_Attributes(this XElement xmlElement)
        {
            return LamedalCore_.Instance.lib.XML.xDoc.List_Attributes(xmlElement);
        }

        /// <summary>
        /// Function to return list of XML elements from the XML document.
        /// </summary>
        /// <param name="xmlDoc">The XML document</param>
        /// <returns>List<XElement/></returns>
        /// <code>CTIN_Transformation;</code>
        public static List<XElement> zxDoc_List_Elements(this XDocument xmlDoc)
        {
            return LamedalCore_.Instance.lib.XML.xDoc.List_Elements(xmlDoc);
        }

        /// <summary>
        /// Sets the attribute.
        /// </summary>
        /// <param name="element">The element</param>
        /// <param name="attributeName">The attribute name</param>
        /// <param name="value">The value</param>
        /// <code>CTIN_Transformation;</code>
        public static void zxDoc_Attribute_Set(this XElement element, string attributeName, string value)
        {
            LamedalCore_.Instance.lib.XML.xDoc.Attribute_Set(element, attributeName, value);
        }

        /// <summary>
        /// Function to return attribute from XML element in XML document.
        /// </summary>
        /// <param name="xml">The XML</param>
        /// <param name="element">The element</param>
        /// <param name="attribute">The attribute</param>
        /// <param name="autoFix">if set to <c>true</c> [automatic fix].</param>
        /// <returns>
        /// XAttribute
        /// </returns>
        /// <code>CTIN_Transformation;</code>
        public static XAttribute zxDoc_Attribute_(this string xml, string element, string attribute,
            bool autoFix = false)
        {
            return LamedalCore_.Instance.lib.XML.xDoc.Attribute_(xml, element, attribute, autoFix);
        }

        /// <summary>
        /// Function to return attribute from XML element in XML document.
        /// </summary>
        /// <param name="xmlDoc">The XML document</param>
        /// <param name="element">The element</param>
        /// <param name="attribute">The attribute</param>
        /// <returns>XAttribute</returns>
        /// <code>CTIN_Transformation;</code>
        public static XAttribute zxDoc_Attribute_(this XDocument xmlDoc, string element, string attribute)
        {
            return LamedalCore_.Instance.lib.XML.xDoc.Attribute_(xmlDoc, element, attribute);
        }

        /// <summary>
        /// Function to return attribute from XML element.
        /// </summary>
        /// <param name="xmlElement">The XML element</param>
        /// <param name="attribute">The attribute</param>
        /// <param name="autoAdd">if set to <c>true</c> [automatic add].</param>
        /// <returns>
        /// XAttribute
        /// </returns>
        /// <code>CTIN_Transformation;</code>
        public static XAttribute zxDoc_Attribute_(this XElement xmlElement, string attribute, bool autoAdd = true)
        {
            return LamedalCore_.Instance.lib.XML.xDoc.Attribute_(xmlElement, attribute, autoAdd);
        }

        /// <summary>
        /// Function to return attribute string from XML element.
        /// </summary>
        /// <param name="xmlElement">The XML element</param>
        /// <param name="attribute">The attribute</param>
        /// <returns>XAttribute</returns>
        /// <code>CTIN_Transformation;</code>
        public static string zxDoc_Attribute_AsStr(this XElement xmlElement, string attribute)
        {
            return LamedalCore_.Instance.lib.XML.xDoc.Attribute_AsStr(xmlElement, attribute);
        }

        /// <summary>
        /// Function to return attribute string from XML element.
        /// </summary>
        /// <param name="attribute">The attribute</param>
        /// <returns>
        /// XAttribute
        /// </returns>
        /// <code>CTIN_Transformation;</code>
        public static string zxDoc_Attribute_AsStr(this XAttribute attribute)
        {
            return LamedalCore_.Instance.lib.XML.xDoc.Attribute_AsStr(attribute);
        }

        /// <summary>
        /// Function to return XElement of XElement element.
        /// </summary>
        /// <param name="xElement">The XML element</param>
        /// <param name="element">The element</param>
        /// <returns>XElement</returns>
        /// <code>CTIN_Transformation;</code>
        public static XElement zxDoc_Element_(this XElement xElement, string element)
        {
            return LamedalCore_.Instance.lib.XML.xDoc.Element_(xElement, element);
        }

        /// <summary>
        /// Sets the element value. The value can be added and removed.
        /// </summary>
        /// <param name="code">The code</param>
        /// <param name="addValue">Add value indicator. if [true] then value is added; else value is removed. Default value = true.</param>
        /// <param name="newValues">The new values.</param>
        /// <code>CTIN_Transformation;</code>
        public static void zxDoc_Element_Set(this XElement code, bool addValue = true, params string[] newValues)
        {
            LamedalCore_.Instance.lib.XML.xDoc.Element_Set(code, addValue, newValues);
        }

        /// <summary>
        /// Sets the element value. The value can be added and removed.
        /// </summary>
        /// <param name="code">The code</param>
        /// <param name="newValue">The new value</param>
        /// <param name="addValue">Add value indicator. if [true] then value is added; else value is removed. Default value = true.</param>
        /// <code>CTIN_Transformation;</code>
        public static void zxDoc_Element_Set(this XElement code, string newValue, bool addValue = true)
        {
            LamedalCore_.Instance.lib.XML.xDoc.Element_Set(code, newValue, addValue);
        }

        /// <summary>
        /// Function to adds the XML element to the root element.
        /// </summary>
        /// <param name="element">The root element</param>
        /// <param name="elementValue">The element</param>
        /// <returns>
        /// XElement
        /// </returns>
        /// <code>CTIN_Transformation;</code>
        public static XElement zxDoc_Element_Add(this XElement element, string elementValue)
        {
            return LamedalCore_.Instance.lib.XML.xDoc.Element_Add(element, elementValue);
        }

        /// <summary>
        /// Function to return XElement of XML document.
        /// </summary>
        /// <param name="xmlDoc">The XML document</param>
        /// <param name="element">The element</param>
        /// <returns>XElement</returns>
        /// <code>CTIN_Transformation;</code>
        public static XElement zxDoc_Element_(this XDocument xmlDoc, string element)
        {
            return LamedalCore_.Instance.lib.XML.xDoc.Element_(xmlDoc, element);
        }

        /// <summary>Function to return element string from XML string.</summary>
        /// <param name="element">The element</param>
        /// <returns>
        /// XElement
        /// </returns>
        /// <code>CTIN_Transformation;</code>
        public static string zxDoc_Element_AsStr(this XElement element)
        {
            return LamedalCore_.Instance.lib.XML.xDoc.Element_AsStr(element);
        }

        /// <summary>Function to return element string from XML string.</summary>
        /// <param name="xml">The XML.</param>
        /// <param name="element">The element</param>
        /// <param name="autoFix">if set to <c>true</c> [automatic fix].</param>
        /// <returns>
        /// XElement
        /// </returns>
        /// <code>CTIN_Transformation;</code>
        public static string zxDoc_Element_AsStr(this string xml, string element, bool autoFix = false)
        {
            return LamedalCore_.Instance.lib.XML.xDoc.Element_AsStr(xml, element, autoFix);
        }

        /// <summary>
        /// Function to return XElement from XML string.
        /// </summary>
        /// <param name="xml">The XML.</param>
        /// <param name="element">The element</param>
        /// <param name="autoFix">if set to <c>true</c> [automatic fix].</param>
        /// <returns>
        /// XElement
        /// </returns>
        /// <code>CTIN_Transformation;</code>
        public static XElement zxDoc_Element_(this string xml, string element, bool autoFix = false)
        {
            return LamedalCore_.Instance.lib.XML.xDoc.Element_(xml, element, autoFix);
        }

        /// <summary>Root sets the x document element from the XML document.</summary>
        /// <code>CTIN_Transformation;</code>
        public static XElement zxDoc_Element_RootSet(this XDocument xmlDoc, string elementName)
        {
            return LamedalCore_.Instance.lib.XML.xDoc.Element_RootSet(xmlDoc, elementName);
        }

        /// <summary>
        /// Function to return root XElement from XML document.
        /// </summary>
        /// <param name="xmlDoc">The XML document.</param>
        /// <returns>
        /// XElement
        /// </returns>
        /// <code>CTIN_Transformation;</code>
        public static XElement zxDoc_Element_Root(this XDocument xmlDoc)
        {
            return LamedalCore_.Instance.lib.XML.xDoc.Element_Root(xmlDoc);
        }

        /// <summary>
        /// Function to fix XML  document from the XML.
        /// </summary>
        /// <param name="xml">The XML</param>
        /// <returns>string</returns>
        /// <code>IgnoreName; </code>
        /// <code>CTIN_Transformation;</code>
        public static string zxDoc_Document_FixXML(this string xml)
        {
            return LamedalCore_.Instance.lib.XML.Setup.Fix_XMLErrorRootElements(xml);
        }

        /// <summary>
        /// Function to  return document of parsed the XML.
        /// </summary>
        /// <param name="xml">The XML</param>
        /// <param name="autoFix">if set to <c>true</c> [automatic fix].</param>
        /// <returns>
        /// XDocument
        /// </returns>
        /// <code>CTIN_Transformation;</code>
        public static XDocument zxDoc_Document(this string xml, bool autoFix = false)
        {
            return LamedalCore_.Instance.lib.XML.xDoc.Document(xml, autoFix);
        }
    }
}
