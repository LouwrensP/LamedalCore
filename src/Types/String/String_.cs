using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using JetBrains.Annotations;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.lib.XML;
using LamedalCore.Types.List;
using LamedalCore.zz;

namespace LamedalCore.Types.String
{
    /// <summary>
    /// Strings Methods
    /// </summary>
    [BlueprintRule_Class(enBlueprintClassNetworkType.Node_Link, DefaultType = typeof(string), GroupName = "Str")]
    [Test_IgnoreCoverage(enTestIgnore.ClassIsNodeLink)]
    public sealed class String_
    {
        #region Edit
        /// <summary>
        /// Gets the Edit library methods.
        /// </summary>
        public String_Edit Edit
        {
            get { return _Edit ?? (_Edit = new String_Edit()); }
        }
        private String_Edit _Edit;
        #endregion

        #region List
        /// <summary>
        /// Gets the String library methods.
        /// </summary>
        public List_String List
        {
            get { return _String ?? (_String = new List_String()); }
        }
        private List_String _String;
        #endregion

        #region Quote
        /// <summary>
        /// Gets the Setup library methods.
        /// </summary>
        public String_Quote Quote
        {
            get { return _Quote ?? (_Quote = new String_Quote()); }
        }
        private String_Quote _Quote;
        #endregion
        
        #region Regex
        /// <summary>
        /// Gets the Regex library methods.
        /// </summary>
        public String_Regex Regex
        {
            get { return _Regex ?? (_Regex = new String_Regex()); }
        }
        private String_Regex _Regex;
        #endregion

        #region Search
        /// <summary>
        /// Gets the Search library methods.
        /// </summary>
        public String_Search Search
        {
            get { return _Search ?? (_Search = new String_Search()); }
        }
        private String_Search _Search;
        #endregion
        
        #region SpecialChar
        /// <summary>
        /// Gets the SpecialChar library methods.
        /// </summary>
        public String_SpecialChar SpecialChar
        {
            get { return _SpecialChar ?? (_SpecialChar = new String_SpecialChar()); }
        }
        private String_SpecialChar _SpecialChar;
        #endregion

        #region Word
        /// <summary>
        /// Gets the Word library methods.
        /// </summary>
        public String_Word Word
        {
            get { return _Word ?? (_Word = new String_Word()); }
        }
        private String_Word _Word;
        #endregion
    }
}
