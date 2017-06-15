using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.Types.Class;
using LamedalCore.Types.List;
using LamedalCore.Types.String;

namespace LamedalCore.Types
{
    /// <summary>
    /// Methods that operate  on types & lists
    /// </summary>
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_Link)]
    [Test_IgnoreCoverage(enCode_TestIgnore.ClassIsNodeLink)]
    public sealed class Types_
    {

        #region Class
        /// <summary>
        /// Gets the Class library methods.
        /// </summary>
        public Class_ Class
        {
            get { return _Class ?? (_Class = new Class_()); }
        }
        private Class_ _Class;
        #endregion

        #region Convert
        /// <summary>
        /// Gets the As library methods.
        /// </summary>
        public Types_Convert Convert
        {
            get { return _Convert ?? (_Convert = new Types_Convert()); }
        }
        private Types_Convert _Convert;
        #endregion

        #region DateTime
        /// <summary>
        /// Gets the DateTime library methods.
        /// </summary>
        public Types_DateTime DateTime
        {
            get { return _DateTime ?? (_DateTime = new Types_DateTime()); }
        }
        private Types_DateTime _DateTime;
        #endregion

        #region DateTimeSpan
        /// <summary>
        /// Gets the TimeSpan library methods.
        /// </summary>
        public Types_DateTimeSpan DateTimeSpan
        {
            get { return _TimeSpan ?? (_TimeSpan = new Types_DateTimeSpan()); }
        }
        private Types_DateTimeSpan _TimeSpan;
        #endregion

        #region Dictionary
        /// <summary>
        /// Gets the Dictionary library methods.
        /// </summary>
        public Types_Dictionary Dictionary
        {
            get { return _typesDictionary ?? (_typesDictionary = new Types_Dictionary()); }
        }
        private Types_Dictionary _typesDictionary;
        #endregion

        #region Enum
        /// <summary>
        /// Gets the Enum library methods.
        /// </summary>
        public Types_Enum Enum
        {
            get { return _Enum ?? (_Enum = new Types_Enum()); }
        }
        private Types_Enum _Enum;
        #endregion

        #region Number
        /// <summary>
        /// Gets the Int library methods.
        /// </summary>
        public Types_Number Number
        {
            get { return _Number ?? (_Number = new Types_Number()); }
        }
        private Types_Number _Number;
        #endregion

        #region intRomanNumbers
        /// <summary>
        /// Gets the intRomanNumbers library methods.
        /// </summary>
        public Types_intRomanNumbers intRomanNumbers
        {
            get { return _intRomanNumbers ?? (_intRomanNumbers = new Types_intRomanNumbers()); }
        }
        private Types_intRomanNumbers _intRomanNumbers;
        #endregion

        #region Object
        /// <summary>
        /// Gets the Is library methods.
        /// </summary>
        public Types_Object Object
        {
            get { return _object ?? (_object = new Types_Object()); }
        }
        private Types_Object _object;
        #endregion

        #region List
        /// <summary>
        /// Gets the List library methods.
        /// </summary>
        public List_ List
        {
            get { return _List ?? (_List = new List_()); }
        }
        private List_ _List;
        #endregion

        #region String
        /// <summary>
        /// Gets the String library methods.
        /// </summary>
        public String_ String
        {
            get { return _String ?? (_String = new String_()); }
        }
        private String_ _String;
        #endregion

        #region Test
        /// <summary>
        /// Gets the Test library methods.
        /// </summary>
        public Types_Test Test
        {
            get { return _Test ?? (_Test = new Types_Test()); }
        }
        private Types_Test _Test;
        #endregion
    }
}
