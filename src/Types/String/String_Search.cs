using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zz;

namespace LamedalCore.Types.String
{
    /// <summary>
    /// Searches a string for a value
    /// </summary>
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_Action, DefaultType = typeof(string), GroupName = "Str")]
    public sealed class String_Search
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance; // system library

        #region var_

        /// <summary>Return the identifier string variable from the input string that is in the form  'Id_Value'. </summary>
        /// <param name="inputStr">The input string.</param>
        /// <param name="delimiter">The delimiter setting. Default value = "".</param>
        /// <returns>
        /// string
        /// </returns>
        [Pure]
        public string Var_Id(string inputStr, string delimiter = "♣")
        {
            return Var_Next(ref inputStr, delimiter);
        }


        /// <summary>Return the next string variable from the input string reference variable in the form 'value1,value2,value3'. The seperator character is customisable. </summary>
        /// <remarks>Recall</remarks>
        /// <param name="line">The inputStr reference variable</param>
        /// <param name="delimiter">The delimiter setting. Default inputStr = "".</param>
        /// <param name="trim">Trim indicator. Default inputStr = true.</param>
        /// <returns>string</returns>
        [Pure]
        public string Var_Next(ref string line, string delimiter = "♣", bool trim = true)
        {
            if (System.String.IsNullOrEmpty(line)) return "";

            if (!line.Contains(delimiter))
            {
                var value = (trim) ? line.Trim() : line;
                line = "";
                return value;
            }

            var position = line.IndexOf(delimiter);
            var result = line.Substring(0, position);
            if (trim)
            {
                result = result.Trim(' ');
            }
            var length = delimiter.Length;
            line = line.Substring(position + length);
            return result;
        }

        /// <summary>
        /// Return value variable part  from the input string that is in the form 'Id_Value'.
        /// </summary>
        /// <param name="inputStr">The input string</param>
        /// <param name="delimiter">The delimiter setting. Default value = "♣".</param>
        /// <param name="trim">if set to <c>true</c> [trim].</param>
        /// <returns>
        /// string
        /// </returns>
        [Pure]
        public string Var_Value(string inputStr, string delimiter = "♣", bool trim = true)
        {
            if (System.String.IsNullOrEmpty(inputStr)) return "";
            if (!inputStr.Contains(delimiter)) return "";

            int position = inputStr.IndexOf(delimiter, System.StringComparison.Ordinal);
            string result = inputStr.Substring(position + delimiter.Length);
            if (trim) result = result.Trim();
            return result;
        }

        /// <summary>Split the line into 3 values.</summary>
        /// <param name="line">The line</param>
        /// <param name="val1">Return the value1</param>
        /// <param name="val2">Return the value to</param>
        /// <param name="val3">Return the value3</param>
        /// <param name="delimiter1">The deleteimiter1 setting. Default value = "->".</param>
        /// <param name="delimiter2">The deleteimiter to setting. Default value = "=>".</param>
        public void Var_3Values(string line, out string val1, out string val2, out string val3, string delimiter1 = "->",
            string delimiter2 = "=>")
        {
            var def1 = line;
            val1 = Var_Next(ref def1, delimiter1);
            val2 = Var_Next(ref def1, delimiter2);
            val3 = def1;
        }

        #endregion

        #region Contains

        /// <summary>Determines whether the input (string) contains the search (string) with case sensitivity flag setting.</summary>
        /// <param name="inputStr">The source</param>
        /// <param name="searchValue">To checks the</param>
        /// <param name="comp">The string comparison</param>
        /// <returns>bool</returns>
        public bool Contains(string inputStr, string searchValue,
            StringComparison comp = StringComparison.OrdinalIgnoreCase)
        {
            return inputStr.IndexOf(searchValue, comp) >= 0;
        }

        /// <summary>
        /// Searches for the item in the text ignoring case and return the found value.
        /// </summary>
        /// <param name="text">The text that will be searched</param>
        /// <param name="searchItem">The item searched for</param>
        /// <param name="comparisonType">Type of the comparison.</param>
        /// <returns>The match that was found in the text</returns>
        public string Contains_AsStr(string text, string searchItem,
            StringComparison comparisonType = StringComparison.CurrentCulture)
        {
            var index = text.IndexOf(searchItem, comparisonType);
            if (index == -1) return "";
            var result = text.Substring(index, searchItem.Length);
            return result;
        }

        /// <summary>
        /// Determines whether the specified input string contains index. This is supposed to be faster than index of
        /// </summary>
        /// <param name="inputStr">The input string.</param>
        /// <param name="searchValue">The search value.</param>
        /// <param name="compare">The compare.</param>
        /// <returns></returns>
        public int Contains_Index(string inputStr, string searchValue,
            StringComparison compare = StringComparison.Ordinal)
        {
            //quick check to protect the user from themselves
            if (System.String.IsNullOrEmpty(searchValue) || string.IsNullOrEmpty(inputStr)) return -1;
            return inputStr.IndexOf(searchValue, compare);
        }

        /// <summary>
        /// Determines whether the specified input string contains all searchvalues.
        /// </summary>
        /// <param name="inputStr">The input string.</param>
        /// <param name="compare">The compare.</param>
        /// <param name="searchValues">The search values.</param>
        /// <returns>
        ///   <c>true</c> if the specified inputStr contains all; otherwise, <c>false</c>.
        /// </returns>
        [Pure]
        public bool Contains_All(string inputStr, StringComparison compare = StringComparison.OrdinalIgnoreCase,
            params string[] searchValues)
        {
            foreach (var value in searchValues)
            {
                if (inputStr.IndexOf(value, compare) == -1) return false;
            }
            return true;
        }

        /// <summary>
        /// Determines whether the specified input string contains all searchvalues.
        /// </summary>
        /// <param name="inputStr">The input string.</param>
        /// <param name="searchValues">The search values.</param>
        /// <returns>
        ///   <c>true</c> if the specified inputStr contains all; otherwise, <c>false</c>.
        /// </returns>
        [Pure]
        public bool Contains_All(string inputStr, params string[] searchValues)
        {
            return Contains_All(inputStr, StringComparison.OrdinalIgnoreCase, searchValues);
        }

        /// <summary>
        /// Determines whether the specified input string contains any of the search values.
        /// </summary>
        /// <param name="inputStr">The input string.</param>
        /// <param name="searchValues">The search values.</param>
        /// <returns>
        ///   <c>true</c> if the specified inputStr contains all; otherwise, <c>false</c>.
        /// </returns>
        [Pure]
        public bool Contains_Any(string inputStr, params string[] searchValues)
        {
            string findValue;
            return Contains_Any(inputStr, out findValue, StringComparison.CurrentCulture, searchValues);
        }

        /// <summary>
        /// Determines whether the specified input string contains any of the search values.
        /// </summary>
        /// <param name="inputStr">The input string.</param>
        /// <param name="comparisonType">Type of the comparison.</param>
        /// <param name="searchValues">The search values.</param>
        /// <returns>
        ///   <c>true</c> if the specified inputStr contains all; otherwise, <c>false</c>.
        /// </returns>
        [Pure]
        public bool Contains_Any(string inputStr, StringComparison comparisonType = StringComparison.CurrentCulture,
            params string[] searchValues)
        {
            string findValue;
            return Contains_Any(inputStr, out findValue, comparisonType, searchValues);
        }

        /// <summary>
        /// Determines whether the specified input string contains any of the search values. Returns true if found as well at the value that was found.
        /// </summary>
        /// <param name="text">The input string.</param>
        /// <param name="findValue">The find value.</param>
        /// <param name="comparisonType">Type of the comparison.</param>
        /// <param name="searchValues">The search values.</param>
        /// <returns>
        ///   <c>true</c> if the specified inputStr contains all; otherwise, <c>false</c>.
        /// </returns>
        [Pure]
        public bool Contains_Any(string text, out string findValue,
            StringComparison comparisonType = StringComparison.CurrentCulture, params string[] searchValues)
        {
            findValue = "";
            foreach (var value in searchValues)
            {
                findValue = Contains_AsStr(text, value, comparisonType);
                if (findValue != "") return true;
            }
            return false;
        }

        #endregion

        #region Equal

        /// <summary>
        /// Determines whether the value is in the compare values array.
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="compareValues">The compare values array</param>
        /// <returns>bool</returns>
        public bool Equal_In(string value, params string[] compareValues)
        {
            foreach (string compareValue in compareValues)
            {
                if (value == compareValue) return true;
            }
            return false;
        }

        /// <summary>Percent value1 is equal to value2.</summary>
        /// <param name="value1">The valueue1</param>
        /// <param name="value2">The valueue to</param>
        /// <returns>double</returns>
        public double Equal_Percent(string value1, string value2)
        {
            if (value1 == value2) return 100;
            if ((value1.Length == 0) || (value2.Length == 0)) return 0;

            double total = value1.Length > value2.Length ? value1.Length : value2.Length;
            int min = value1.Length < value2.Length ? value1.Length : value2.Length;
            int isMatch = 0;
            for (int i = 0; i < min; i++) if (value1[i] == value2[i]) isMatch++; //Compare char by char
            var percent = isMatch/total*100;
            return percent;
        }

        /// <summary>Show the difference between two strings at index.</summary>
        /// <param name="str1">The string1</param>
        /// <param name="str2">The string to</param>
        /// <param name="index">The index to</param>
        /// <returns>string</returns>
        public string Equal_StrError(string str1, string str2, int index)
        {
            string errorMsg = "Values differ at pos = {0}.".NL(2);
            errorMsg += "Value1: '{1}' != ".NL();
            errorMsg += "Value2: '{2}'; ".NL();
            errorMsg = errorMsg.zFormat(index, str1, str2);
            if (index > 0) errorMsg += "Diff??: " + "-".zRepeat(index) + "^";
            return errorMsg;
        }

        /// <summary>
        /// Determines whether the value1 string is equal to value2.
        /// </summary>
        /// <param name="value1">The value1</param>
        /// <param name="value2">The value to</param>
        /// <param name="errorMsg">Return the error msg</param>
        /// <param name="index">The index where the two strings differ</param>
        /// <returns>bool</returns>
        public bool Equal_(string value1, string value2, out string errorMsg, out int index)
        {
            index = 0;
            errorMsg = "";
            if (value1 == value2) return true;

            if ((value1.Length != 0) && (value2.Length != 0))
            {
                //double maxLen = value1.Length > value2.Length ? value1.Length : value2.Length;
                int minLen = value1.Length < value2.Length ? value1.Length : value2.Length;
                //int isMatch = 0;
                for (int i = 0; i < minLen; i++) //Compare char by char
                {
                    index++;
                    if (value1[i] != value2[i]) break;
                }
            }

            errorMsg = Equal_StrError(value1, value2, index);
            return false;
        }

        #endregion

        /// <summary>Determines whether [is valid string] [the specified s].</summary>
        /// <param name="s">The string</param>
        /// <returns></returns>
        [Test_IgnoreCoverage(enCode_TestIgnore.MethodIsShortCut)]
        public bool IsValidStr(string s)
        {
            return _lamed.Types.Test.IsValidStr(s);
        }
    }
}
