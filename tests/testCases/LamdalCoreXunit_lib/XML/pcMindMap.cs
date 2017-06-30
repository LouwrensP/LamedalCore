using System.Collections.Generic;
using System.Xml.Linq;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace LamdalCoreXunit_lib.XML
{
    /// <summary>
    /// public class
    /// </summary>
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_State)]
    public sealed class pcMindMap
    {
        public XElement mm;
        public Dictionary<string, XElement>  mmDictionary = new Dictionary<string, XElement>();

        public pcMindMap(XElement mindmap)
        {
            this.mm = mindmap;
        }
    }
}
