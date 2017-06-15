using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zz;

namespace LamedalCore.lib.XML
{
    /// <summary>
    /// Mindmap is very specific. No CTI network generated currently
    /// </summary>
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_Action)]
    public sealed class XML_Mindmap
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance;

        /// <summary>
        /// Converts the XML mindmap to node string list.
        /// </summary>
        /// <param name="XML">The XML</param>
        /// <param name="addId">if set to <c>true</c> [add identifier].</param>
        /// <returns>
        /// List<string />
        /// </returns>
        public List<string> TreeStrList_FromXML(string XML, bool addId = false)
        {
            var mm = _lamed.lib.XML.xDoc.Document(XML);
            var mapElement = mm.zxDoc_Element_Root(); // map

            var nodeList = new List<string>();
            var nodeDictionary = new Dictionary<string, XElement>();

            var rootElement = mapElement.zxDoc_Element_("node"); // Root
            var rootStr = rootElement.zxDoc_Attribute_AsStr("TEXT");
            var id = rootElement.zxDoc_Attribute_AsStr("ID").Substring(3);

             if (addId)
                  nodeList.Add(id + ":" + rootStr);
             else nodeList.Add(rootStr);
            nodeDictionary.Add(rootStr, rootElement);

            NodeStringList_AddNode(nodeList, nodeDictionary, "", rootElement, addId);
            return nodeList;
        }

        /// <summary>
        /// Creates the mind map xdoc from the node string list.
        /// </summary>
        /// <param name="treeStringList">The node list</param>
        /// <param name="addId">if set to <c>true</c> [add identifier].</param>
        /// <returns>
        /// XDocument
        /// </returns>
        public XDocument TreeStrList_2XmlDocument(List<string> treeStringList, bool addId = false)
        {
            if (treeStringList.Count == 0) return null;

            // From the nodeList create the XML document
            var nodeDictionary = new Dictionary<string, XElement>();
            var pathMissing = new List<string>();
            // Create the map element
            var xDoc = new XDocument();
            var map = xDoc.zxDoc_Element_RootSet("map");
            map.zxDoc_Attribute_Set("version", "1.0.1");

            // Create the first element
            var id = 1;
            var nodeName = treeStringList[0];
            if (addId) treeStringList[0] = id + ":" + treeStringList[0];
            var nodeElement = xDoc_NodeElementAdd(map, nodeName, id++);
            nodeElement.zxDoc_Attribute_Set("STYLE", "bubble");
            nodeDictionary.Add(nodeName, nodeElement);

            // Create the rest
            for (var ii = 1; ii <= treeStringList.Count - 1; ii++)
            {
                //if (ii == 129)
                //    "stop".zOk();
                nodeName = treeStringList[ii];
                if (nodeDictionary.ContainsKey(nodeName)) continue; // <==========================[This item is already generated

                if (nodeName.Contains(".csproj:Properties:AssemblyInfo.cs")) continue;  //<===============================[ Do not include this file

                string firstPart, lastPart;
                var parentElement = xDoc_FindParent(nodeName, nodeDictionary, out firstPart, out lastPart);

                if (parentElement == null)
                {
                    // Parent element was not found in the firstPart -> We need to make sure the full path exists.
                    var folders = nodeName.zConvert_Array_FromStr(":").ToList();
                    var root = "";
                    var item0 = "";
                    for (var jj = 0; jj < folders.Count; jj++)
                    {
                        // Reconstruct the full path and make sure every part of the path exists. 
                        var parent = parentElement;
                        var item1 = folders[jj];
                        folders[jj] = root + item1;
                        root += item1 + ":";
                        if (jj == 0)
                        {
                            item0 = item1;  // Save the folder for reference later
                            continue; // Skip the first folder -> this ensures that there is a first part.
                        }

                        string firstPart2, lastPart2;
                        parentElement = xDoc_FindParent(folders[jj], nodeDictionary, out firstPart2, out lastPart2);
                        if (parentElement == null)
                        {
                            // This part of the path does not exists yet -> Create the folder element 
                            if (addId) pathMissing.Add(id + ":" + firstPart2);
                            else pathMissing.Add(firstPart2);

                            parentElement = xDoc_NodeElementAdd(parent, item0, id++);
                            nodeDictionary.Add(firstPart2, parentElement);
                        }
                        item0 = item1; // Save the folder for reference later
                    }
                }

                if (addId) treeStringList[ii] = id + ":" + treeStringList[ii];
                nodeElement = xDoc_NodeElementAdd(parentElement, lastPart, id++);
                nodeDictionary.Add(nodeName, nodeElement);
            }

            treeStringList.AddRange(pathMissing);
            return xDoc;
        }
                
        #region Private

        /// <summary>Adds the node from the mindmap to the string list.</summary>
        private void NodeStringList_AddNode(List<string> nodeList, Dictionary<string, XElement> nodeDictionary, string root, XElement node, bool addId = false)
        {
            if (node == null) return;

            var nodeStr = node.zxDoc_Attribute_AsStr("TEXT");
            root = root + nodeStr + ":";
            var nodes = node.Elements("node").ToList();
            foreach (var node1 in nodes)
            {
                var value = node1.zxDoc_Attribute_AsStr("TEXT");
                var id = node1.zxDoc_Attribute_AsStr("ID").Substring(3);

                if (addId) 
                     nodeList.Add(id + ":" + root + value);
                else nodeList.Add(root + value);
                nodeDictionary.Add(root + value, node1);
                NodeStringList_AddNode(nodeList, nodeDictionary, root, node1, addId); //<<===================[Recursion
            }
        }

        private XElement xDoc_FindParent(string nodeName, Dictionary<string, XElement> nodeDictionary,
            out string firstPart, out string lastPart)
        {
            _lamed.Types.String.Word.Word_SplitOnLast(nodeName, out firstPart, out lastPart, ":");
            XElement parentElement;
            nodeDictionary.TryGetValue(firstPart, out parentElement);
            return parentElement;
        }

        /// <summary>Adds the node element to the parent element.</summary>
        public XElement xDoc_NodeElementAdd(XElement parentElement, string value, int id, bool right = false, bool folded = false)
        {
            if (parentElement == null) throw new ArgumentNullException(nameof(parentElement));
            
            // parent
            var parentStr = parentElement.zxDoc_Attribute_AsStr("TEXT");
            if (parentStr.Contains(".csproj") || value.Contains(".cs")) folded = true;   // Fold first level elements

            // node
            var element = parentElement.zxDoc_Element_Add("node");
            element.zxDoc_Attribute_Set("ID", "ID_" + id.zTo_Str().Trim());
            if (right) element.zxDoc_Attribute_Set("POSITION", "right");
            if (folded) element.zxDoc_Attribute_Set("FOLDED", "true");
            element.zxDoc_Attribute_Set("TEXT", value);

            // Icon
            var icon = enGenerate_FreemindIcon.folder;
            if (id == 1)
            {
                icon = enGenerate_FreemindIcon.gohome;

                //<font BOLD="true" NAME="SansSerif" SIZE="20"/>
                XElement_AddFont(element, "SansSerif", 20, true);
            }
            else if (value.Contains(".csproj"))
            {
                icon = enGenerate_FreemindIcon.launch;
                // <font BOLD="true" NAME="SansSerif" SIZE="16"/>
                XElement_AddFont(element, "SansSerif", 16, true);
            }
            else if (value.zContains_Any(".cs", ".doc", ".docx", ".xlsx", ".pptx", ".avi", ".flv", ".pdf", ".ppt", ".png",
                ".chm", ".gui", "*.jpg")) icon = enGenerate_FreemindIcon.idea;
            else if (value.zContains_All("(", ")")) icon = enGenerate_FreemindIcon.xmag;
            else if (value.Contains("- ")) icon = enGenerate_FreemindIcon.help;

            XElement_AddIcon(element, icon);

            return element;
        }

        private static void XElement_AddFont(XElement element, string fontName, int size, bool bold = false)
        {
            // Adds font to the node
            var fontElement = element.zxDoc_Element_Add("font");
            fontElement.zxDoc_Attribute_Set("NAME", fontName);
            if (bold) fontElement.zxDoc_Attribute_Set("BOLD", "true");
            fontElement.zxDoc_Attribute_Set("SIZE", size.zTo_Str());
        }

        private void XElement_AddIcon(XElement element, enGenerate_FreemindIcon icon)
        {
            var iconElement = element.zxDoc_Element_Add("icon");
            iconElement.zxDoc_Attribute_Set("BUILTIN", (icon.zTo_Description()));
        }



        #endregion


    }
}
