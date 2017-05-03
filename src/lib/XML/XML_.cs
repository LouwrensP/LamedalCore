using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace LamedalCore.lib.XML
{
    [BlueprintRule_Class(enBlueprintClassNetworkType.Node_Link)]
    [Test_IgnoreCoverage(enTestIgnore.ClassIsNodeLink)]
    public sealed class XML_
    {
       
        #region Mindmap
        /// <summary>
        /// Gets the Mindmap library methods.
        /// </summary>
        public XML_Mindmap Mindmap
        {
            get { return _Mindmap ?? (_Mindmap = new XML_Mindmap()); }
        }
        private XML_Mindmap _Mindmap;
        #endregion

        #region Setup
        /// <summary>
        /// Gets the XML library methods.
        /// </summary>
        public XML_Setup Setup
        {
            get { return _Setup ?? (_Setup = new XML_Setup()); }
        }
        private XML_Setup _Setup;
        #endregion

        #region xDoc
        /// <summary>
        /// Gets the xDoc library methods.
        /// </summary>
        public XML_xDoc xDoc
        {
            get { return _xmlXDoc ?? (_xmlXDoc = new XML_xDoc()); }
        }
        private XML_xDoc _xmlXDoc;
        #endregion

    }
}
