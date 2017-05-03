using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using HtmlAgilityPack;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zz;

namespace LamedalCore.lib.XML
{
    [BlueprintRule_Class(enBlueprintClassNetworkType.Node_Action, GroupName = "xDoc")]
    public sealed class XML_xDoc
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance; // system library

        /// <summary>
        /// Function to  return document of parsed the XML.
        /// </summary>
        /// <param name="xml">The XML</param>
        /// <param name="autoFix">if set to <c>true</c> [automatic fix].</param>
        /// <returns>
        /// XDocument
        /// </returns>
        public XDocument Document(string xml, bool autoFix = false)
        {
            if (autoFix) xml =  _lamed.lib.XML.Setup.Fix_XMLErrorRootElements(xml);

            XDocument result = null;
            try
            {
                result = XDocument.Parse(xml);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                if (autoFix == false) return Document(xml, true);  // Retry with autofix
                e.zException_Show("Error in XML: " + xml);
            }
            return result;
        }

        #region Element
        /// <summary>Return a XElement from and HTML string.</summary>
        /// <param name="htmlString">The HTML string.</param>
        /// <param name="removeScriptsAndStyle">if set to <c>true</c> [remove class].</param>
        /// <param name="nodes2Remove">The nodes2 remove.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">htmlString</exception>
        public XElement Element_FromHtmlStr(string htmlString, bool removeScriptsAndStyle = true, params string[] nodes2Remove)
        {
            if (htmlString.zIsNullOrEmpty()) throw new ArgumentNullException(nameof(htmlString));

            var nodesList = nodes2Remove.ToList();
            if (removeScriptsAndStyle)
            {
                nodesList.Add("script");
                nodesList.Add("style");
            }
            var nodesArray = nodesList.ToArray();


            var doc = new HtmlDocument();
            doc.OptionOutputAsXml = true;
            doc.OptionFixNestedTags = true;
            doc.LoadHtml(htmlString);

            if (removeScriptsAndStyle)
            {
                doc.DocumentNode.Descendants().Where(n => n.Name.zIn(nodesArray))
                 .ToList()
                 .ForEach(n => n.Remove());
            }

            using (var writer = new StringWriter())
            {
                doc.Save(writer);
                using (var reader = new StringReader(writer.ToString()))
                {
                    return XElement.Load(reader);
                }
            }
        }

        /// <summary>
        /// Function to return root XElement from XML document.
        /// </summary>
        /// <param name="xmlDoc">The XML document.</param>
        /// <returns>
        /// XElement
        /// </returns>
        public XElement Element_Root(XDocument xmlDoc)
        {
            var name = xmlDoc.Root.Name;
            var result = xmlDoc.Element(name);
            return result;
        }

        /// <summary>Set the Root element from for the XML document.</summary>
        public XElement Element_RootSet(XDocument xmlDoc, string elementName)
        {
            XElement result = null;
            if (xmlDoc.Root == null)
            {
                result = new XElement(elementName);
                xmlDoc.Add(result);
            }
            else result = Element_Root(xmlDoc);
            return result;
        }

        /// <summary>Updates the root element.</summary>
        /// <param name="xDoc">The x document</param>
        /// <param name="newRootName">The element name</param>
        public void Element_RootUpdate(XDocument xDoc, string newRootName)
        {
            var element = Element_Root(xDoc);
            element.Name = newRootName;
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
        public XElement Element_(string xml, string element, bool autoFix = false)
        {
            var xmlDoc = Document(xml, autoFix);
            var result = Element_(xmlDoc, element);
            return result;
        }

        /// <summary>Function to return element string from XML string.</summary>
        /// <param name="xml">The XML.</param>
        /// <param name="element">The element</param>
        /// <param name="autoFix">if set to <c>true</c> [automatic fix].</param>
        /// <returns>
        /// XElement
        /// </returns>
        public string Element_AsStr(string xml, string element, bool autoFix = false)
        {
            var xElement = Element_(xml, element, autoFix);
            var result = Element_AsStr(xElement);
            return result;
        }

        /// <summary>Function to return element string from XML string.</summary>
        /// <param name="element">The element</param>
        /// <returns>
        /// XElement
        /// </returns>
        public string Element_AsStr(XElement element)
        {
            if (element == null) return "";

            var result = element.Value;
            return result;
        }

        /// <summary>
        /// Function to return XElement of XML document.
        /// </summary>
        /// <param name="xmlDoc">The XML document</param>
        /// <param name="element">The element</param>
        /// <returns>XElement</returns>
        public XElement Element_(XDocument xmlDoc, string element)
        {
            XElement result = null;
            XElement rootElement = Element_Root(xmlDoc);
            if (rootElement.Name == element) result = rootElement; 
            else
            {
                result = rootElement.Element(element);
                if (result == null) result = Element_Add(rootElement, element);
            }
            return result;
        }

        /// <summary>
        /// Function to adds the XML element to the root element.
        /// </summary>
        /// <param name="element">The root element</param>
        /// <param name="elementValue">The element</param>
        /// <returns>
        /// XElement
        /// </returns>
        public XElement Element_Add(XElement element, string elementValue)
        {
            if (element == null)
            {
                "Error! Can not add element value to undefined element!".zException_Show();
            }
            var result = new XElement(elementValue);
            element.Add(result);
            return result;
        }

        /// <summary>
        /// Sets the element value. The value can be added and removed.
        /// </summary>
        /// <param name="element">The element</param>
        /// <param name="newValue">The new value</param>
        /// <param name="addValue">Add value indicator. if [true] then value is added; else value is removed. Default value = true.</param>
        public void Element_Set(XElement element, string newValue, bool addValue = true)
        {
            if (newValue == "") return;

            if (newValue.EndsWith(";") == false) newValue += ";";
            var elementAsStr = element.zxDoc_Element_AsStr();
            var update = false;
            if (addValue)
            {
                //Checked
                if (elementAsStr.Contains(newValue) == false) elementAsStr += newValue;
                update = true;
            } else
            {
                // Not Checked
                if (elementAsStr.Contains(newValue) == true) elementAsStr = elementAsStr.Replace(newValue, "");
                update = true;
            }
            if (update)
            {
                elementAsStr = elementAsStr.Trim();
                element.SetValue(elementAsStr);
            }
        }

        /// <summary>
        /// Sets the element value. The value can be added and removed.
        /// </summary>
        /// <param name="element">The element</param>
        /// <param name="addValue">Add value indicator. if [true] then value is added; else value is removed. Default value = true.</param>
        /// <param name="newValues">The new values.</param>
        public void Element_Set(XElement element, bool addValue = true, params string[] newValues)
        {
            foreach (var value in newValues) Element_Set(element, value, addValue);
        }

        /// <summary>Function to return XElement of XElement element.</summary>
        /// <param name="xElement">The XML element</param>
        /// <param name="element">The element</param>
        /// <param name="autoAddIfNotFound">if set to <c>true</c> [automatic add if not found].</param>
        /// <returns>XElement</returns>
        public XElement Element_(XElement xElement, string element, bool autoAddIfNotFound = true)
        {
            var result = xElement.Element(element);
            if (result == null && autoAddIfNotFound) result = Element_Add(xElement, element);
            return result;
        }
        #endregion

        #region Attribute
        /// <summary>
        /// Function to return attribute string from XML element.
        /// </summary>
        /// <param name="attribute">The attribute</param>
        /// <returns>
        /// XAttribute
        /// </returns>
        public string Attribute_AsStr(XAttribute attribute)
        {
            if (attribute == null) return "";
            var result = attribute.Value;
            return result;
        }

        /// <summary>
        /// Function to return attribute string from XML element.
        /// </summary>
        /// <param name="xmlElement">The XML element</param>
        /// <param name="attribute">The attribute</param>
        /// <returns>XAttribute</returns>
        public string Attribute_AsStr(XElement xmlElement, string attribute)
        {
            if (xmlElement == null) return "";
            var attribute1 = xmlElement.Attribute(attribute);
            var result = Attribute_AsStr(attribute1);
            return result;
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
        public XAttribute Attribute_(XElement xmlElement, string attribute, bool autoAdd = true)
        {
            var result = xmlElement.Attribute(attribute);
            if (result == null && autoAdd)
            {
                // The attribute does not exist -> lets add it.
                result = new XAttribute(attribute, "");
                xmlElement.Add(result);
            }
            return result;
        }


        /// <summary>
        /// Function to return attribute from XML element in XML document.
        /// </summary>
        /// <param name="xmlDoc">The XML document</param>
        /// <param name="element">The element</param>
        /// <param name="attribute">The attribute</param>
        /// <returns>XAttribute</returns>
        public XAttribute Attribute_(XDocument xmlDoc, string element, string attribute)
        {
            var xmlElement = Element_(xmlDoc, element);
            return Attribute_(xmlElement, attribute);
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
        public XAttribute Attribute_(string xml, string element, string attribute, bool autoFix = false)
        {
            var xmlDoc = Document(xml, autoFix);
            var result = Attribute_(xmlDoc, element, attribute);
            return result;
        }

        /// <summary>
        /// Sets the attribute.
        /// </summary>
        /// <param name="element">The element</param>
        /// <param name="attributeName">The attribute name</param>
        /// <param name="value">The value</param>
        public void Attribute_Set(XElement element, string attributeName, string value)
        {
            if (value != null)
            {
                if (value == "")
                {
                    var xAttribute = Attribute_(element, attributeName, false);
                    if (xAttribute == null) return;
                    xAttribute.Remove();
                }
                else
                {
                    var xDefaultType = Attribute_(element, attributeName);
                    xDefaultType.SetValue(value);
                }
            }
        }
        #endregion

        #region xmlList_

        /// <summary>
        /// Function to return list of XML elements from the XML document.
        /// </summary>
        /// <param name="xmlDoc">The XML document</param>
        /// <returns>List<XElement/></returns>
        public List<XElement> List_Elements(XDocument xmlDoc)
        {
            var result = xmlDoc.Elements().ToList();
            return result;
        }

        /// <summary>
        /// Function to return list of XML attributes from the XML element.
        /// </summary>
        /// <param name="xmlElement">The XML element</param>
        /// <returns>List<XAttribute/></returns>
        public List<XAttribute> List_Attributes(XElement xmlElement)
        {
            var result = xmlElement.Attributes().ToList();
            return result;
        }
        #endregion
    }
}
