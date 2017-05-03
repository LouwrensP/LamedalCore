using System;
using System.Collections.Generic;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace LamedalCore.zz
{
    [BlueprintRule_Class(enBlueprintClassNetworkType.Transformation_Extention)]
    [Test_IgnoreCoverage(enTestIgnore.MethodIsShortCut)]
    public static class Types_string_LaMedal_Core
    {
        /// <summary>
        /// Removes the double quotes from the line.
        /// </summary>
        /// <param name="line">The line</param>
        /// <returns>string</returns>
        /// <code>CTIN_Transformation;</code>
        public static string zRemove_DoubleQuotes(this string line)
        {
            return LamedalCore_.Instance.Types.String.Quote.Remove_DoubleQuotes(line);
        }
        /// <summary>From the input string return the sub-string located between the start and end tags.</summary>
        /// <param name="inputStr">The inputStr.</param>
        /// <param name="startTag">The start tag.</param>
        /// <param name="endTag">The end tag.</param>
        /// <returns>string.</returns>
        /// <code>CTIN_Transformation;</code>
        public static string zConvert_XML_ValueBetweenTags(this string inputStr, string startTag, string endTag)
        {
            return LamedalCore_.Instance.lib.XML.Setup.XML_ValueBetweenTags(inputStr, startTag, endTag);
        }

        /// <summary>
        /// Return the XML elements beteen the tag pattern.
        /// </summary>
        /// <param name="xml">The XML</param>
        /// <param name="tag">The node</param>
        /// <param name="tagHasAttributes">if set to <c>true</c> [tagHasAttributes].</param>
        /// <returns>
        /// string
        /// </returns>
        /// <code>CTIN_Transformation;</code>
        public static string zConvert_XML_ValueBetweenTags(this string xml, string tag, bool tagHasAttributes = false)
        {
            return LamedalCore_.Instance.lib.XML.Setup.XML_ValueBetweenTags(xml, tag, tagHasAttributes);
        }

        /// <summary>
        /// Repeat string from the string.
        /// </summary>
        /// <param name="s">The string</param>
        /// <param name="total">The total setting. Default value = 1.</param>
        /// <returns>string</returns>
        /// <code>CTIN_Transformation;</code>
        public static string zRepeat(this string s, int total = 1)
        {
            return LamedalCore_.Instance.Types.String.Edit.Repeat(s, total);
        }
        
        /// <summary>
        /// Determines whether the source contains the string with flag to set the case sensitivity.
        /// </summary>
        /// <param name="inputStr">The source</param>
        /// <param name="searchValue">To checks the</param>
        /// <param name="comp">The string comparison</param>
        /// <returns>bool</returns>
        /// <code>CTIN_Transformation;</code>
        public static bool zContains(this string inputStr, string searchValue, StringComparison comp = StringComparison.OrdinalIgnoreCase)
        {
            return LamedalCore_.Instance.Types.String.Search.Contains(inputStr, searchValue, comp);
        }

        /// <summary>
        /// Determines whether the specified inputStr contains all searchvalues.
        /// </summary>
        /// <param name="inputStr">The input string.</param>
        /// <param name="searchValues">The search values.</param>
        /// <returns>
        ///   <c>true</c> if the specified inputStr contains all; otherwise, <c>false</c>.
        /// </returns>
        /// <code>CTIN_Transformation;</code>
        public static bool zContains_All(this string inputStr, params string[] searchValues)
        {
            return LamedalCore_.Instance.Types.String.Search.Contains_All(inputStr, searchValues);
        }

        /// <summary>
        /// Determines whether the specified input string contains any of the search values. Returns true if found as well at the value that was found.
        /// </summary>
        /// <param name="inputStr">The input string.</param>
        /// <param name="findValue">The find value.</param>
        /// <param name="comparisonType">Type of the comparison.</param>
        /// <param name="searchValues">The search values.</param>
        /// <returns>
        ///   <c>true</c> if the specified inputStr contains all; otherwise, <c>false</c>.
        /// </returns>
        /// <code>CTIN_Transformation;</code>
        public static bool zContains_Any(this string inputStr, out string findValue, StringComparison comparisonType = StringComparison.CurrentCulture, params string[] searchValues)
        {
            return LamedalCore_.Instance.Types.String.Search.Contains_Any(inputStr, out findValue, comparisonType, searchValues);
        }

        /// <summary>
        /// Determines whether the specified input string contains any of the search values.
        /// </summary>
        /// <param name="inputStr">The input string.</param>
        /// <param name="searchValues">The search values.</param>
        /// <returns>
        ///   <c>true</c> if the specified inputStr contains all; otherwise, <c>false</c>.
        /// </returns>
        /// <code>CTIN_Transformation;</code>
        public static bool zContains_Any(this string inputStr, params string[] searchValues)
        {
            return LamedalCore_.Instance.Types.String.Search.Contains_Any(inputStr, StringComparison.CurrentCulture, searchValues);
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
        /// <code>CTIN_Transformation;</code>
        public static bool zContains_Any(this string inputStr, StringComparison comparisonType = StringComparison.CurrentCulture, params string[] searchValues)
        {
            return LamedalCore_.Instance.Types.String.Search.Contains_Any(inputStr, comparisonType, searchValues);
        }

        /// <summary>
        /// Determines whether the value is in the compare values array.
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="compareValues">The compare values array</param>
        /// <returns>bool</returns>
        /// <code>CTIN_Transformation;</code>
        public static bool zIn(this string value, params string[] compareValues)
        {
              return LamedalCore_.Instance.Types.String.Search.Equal_In(value, compareValues);
        }

        /// <summary>
        /// Converts the input string to valid XML.
        /// </summary>
        /// <param name="inputStr">The input string</param>
        /// <returns>string</returns>
        /// <code>CTIN_Transformation;</code>
        public static string zConvert_2ValidXML(this string inputStr)
        {
            return LamedalCore_.Instance.lib.XML.Setup.Fix_InvalidXML(inputStr);
        }

        /// <summary>
        /// Split string into string array.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <param name="delimiter">The delimiter.</param>
        /// <returns></returns>
        /// <code>CTIN_Transformation;</code>
        public static List<string> zConvert_Array_FromStr(this string s, string delimiter = "♣")
        {
            return LamedalCore_.Instance.Types.List.String.ToListStr(s, delimiter);
        }

        /// <summary>
        /// Split string into string array.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <param name="delimiter">The delimiter.</param>
        /// <returns></returns>
        /// <code>CTIN_Transformation;</code>
        public static List<string> zConvert_Str_ToListStr(this string s, string delimiter = "")
        {
            return LamedalCore_.Instance.Types.List.String.ToListStr(s, delimiter);
        }
        /// <summary>
        /// Converts the input string to camel case words string.
        /// </summary>
        /// <param name="inputStr">The input string</param>
        /// <param name="toLower">To lower indicator. Default value = false.</param>
        /// <returns>string</returns>
        /// <code>CTIN_Transformation;</code>
        public static string zConvert_ToCamelCaseWords(this string inputStr, bool toLower = false)
        {
            return LamedalCore_.Instance.Types.String.Word.Word_Words_FromCamelCase(inputStr, toLower);
        }

        /// <summary>
        /// Add comma and single quote to the specified inputStr.
        /// </summary>
        /// <param name="inputStr">The inputStr.</param>
        /// <code>CTIN_Transformation;</code>
        public static string zcQ(this string inputStr)
        {
            return LamedalCore_.Instance.Types.String.Quote.cQ(inputStr);
        }

        /// <summary>
        /// Word_FromAbbreviation enumeral string value to the enumeral type value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value</param>
        /// <param name="ignoreCase">Ignore case indicator. Default value = false.</param>
        /// <param name="removeStr">The remove string.</param>
        /// <returns>
        /// T
        /// </returns>
        /// <code Shortcut="Enums"></code>
        /// <code>CTIN_Transformation;</code>
        public static T zEnums_To_EnumValue<T>(this string value, bool ignoreCase = false, string removeStr = "")
        {
            return LamedalCore_.Instance.Types.Enum.Str_2EnumValue<T>(value, ignoreCase, removeStr);
        }

        /// <summary>
        /// Function to add single quote string to the input string.
        /// </summary>
        /// <param name="inputStr">The input string</param>
        /// <returns>string</returns>
        /// <code>CTIN_Transformation;</code>
        public static string zQ(this string inputStr)
        {
            return LamedalCore_.Instance.Types.String.Quote.Q(inputStr);
        }

        /// <summary>
        /// Function to double quote the input string.
        /// </summary>
        /// <param name="inputStr">The input string</param>
        /// <returns>string</returns>
        /// <code>CTIN_Transformation;</code>
        public static string zQQ(this string inputStr)
        {
            return LamedalCore_.Instance.Types.String.Quote.QQ(inputStr);
        }

        /// <summary>
        /// Function to replaces the input string between the start marker and end marker with the replace string.
        /// </summary>
        /// <param name="marker_start">The start marker</param>
        /// <param name="marker_end">The end marker</param>
        /// <param name="inputStr">The input string</param>
        /// <param name="replaceStr">The replace string</param>
        /// <returns>string</returns>
        /// <code>CTIN_Transformation;</code>
        public static string zReplace_Between(this string marker_start, string marker_end, string inputStr, string replaceStr)
        {
            return LamedalCore_.Instance.Types.String.Regex.Replace_Between(marker_start, marker_end, inputStr, replaceStr);
        }

        /// <summary>
        /// Function to replaces the first letter to lower case from the input string.
        /// </summary>
        /// <param name="strInput">The string input</param>
        /// <returns>string</returns>
        /// <code>CTIN_Transformation;</code>
        public static string zReplace_FirstLetterLowerCase(this string strInput)
        {
            return LamedalCore_.Instance.Types.String.Edit.Case_FirstLetter2Lower(strInput);
        }

        /// <summary>
        /// Function to replaces the first letter of the word to uppercase string.
        /// </summary>
        /// <param name="word">The word</param>
        /// <returns>string</returns>
        /// <code>CTIN_Transformation;</code>
        public static string zReplace_FirstLetterUppercase(this string word)
        {
            return LamedalCore_.Instance.Types.String.Edit.Case_FirstLetter2Upper(word);
        }

        /// <summary>
        /// Function to replaces the name by swapping the last underscore words in the name.
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>string</returns>
        /// <code>CTIN_Transformation;</code>
        public static string zReplace_SwapLast2UnderscoreWords(this string name)
        {
            return LamedalCore_.Instance.Types.String.Word.Word_SwapLast2UnderscoreWords(name);
        }

        /// <summary>
        /// Function to add single quote string to the sql in the input string.
        /// </summary>
        /// <param name="inputStr">The inputStr</param>
        /// <returns>string</returns>
        /// <code>CTIN_Transformation;</code>
        public static string zSQL_Q(this string inputStr)
        {
            return LamedalCore_.Instance.Types.String.Quote.SQL_Q(inputStr);
        }

        /// <summary>
        /// Cut the specified part from the input string.
        /// </summary>
        /// <param name="inputStr">The input string.</param>
        /// <param name="cutPart">The cut part.</param>
        /// <returns></returns>
        /// <code>CTIN_Transformation;</code>
        public static string zSubStr_Cut(this string inputStr, string cutPart)
        {
            return LamedalCore_.Instance.Types.String.Edit.SubStr_Cut(inputStr, cutPart);
        }

        /// <summary>
        /// Function to return the last word sub-string from the given sentence.
        /// </summary>
        /// <param name="sentence">The sentence</param>
        /// <param name="delimiter">The delimiter</param>
        /// <returns>string</returns>
        /// <code>CTIN_Transformation;</code>
        public static string zSubstr_LastWord(this string sentence, string delimiter = " ")
        {
            return LamedalCore_.Instance.Types.String.Word.Word_Last(sentence, delimiter);
        }

        /// <summary>
        /// Function to removes the extra spaces from the input string.
        /// </summary>
        /// <param name="inputStr">The input string</param>
        /// <param name="removeLastSpace">Remove last space indicator. Default value = true.</param>
        /// <returns>string</returns>
        /// <code>CTIN_Transformation;</code>
        public static string zSubStr_RemoveExtraSpaces(this string inputStr, bool removeLastSpace = true)
        {
            return LamedalCore_.Instance.Types.String.Edit.Remove_ExtraSpaces(inputStr, removeLastSpace);
        }

        /// <summary>
        /// Function to removes the last word from the input string.
        /// </summary>
        /// <param name="inputStr">The input string</param>
        /// <param name="delimiter">The delimiter setting. Default value = &quot; &quot;.</param>
        /// <returns>string</returns>
        /// <code>CTIN_Transformation;</code>
        public static string zSubStr_RemoveLastWord(this string inputStr, string delimiter = " ")
        {
            return LamedalCore_.Instance.Types.String.Word.Word_LastWord_Remove(inputStr, delimiter);
        }

        /// <summary>
        /// Function to removes the prefix from the input string.
        /// </summary>
        /// <param name="inputStr">The input string</param>
        /// <param name="ignorePrefix">The ignore prefix array</param>
        /// <returns>string</returns>
        /// <code>CTIN_Transformation;</code>
        public static string zSubStr_RemovePrefix(this string inputStr, string[] ignorePrefix)
        {
            return LamedalCore_.Instance.Types.String.Edit.Remove_Prefix(inputStr, ignorePrefix);
        }

        /// <summary>
        /// Remove string at end of the input string. The default is to remove the last enter
        /// </summary>
        /// <param name="inputStr">The input string.</param>
        /// <param name="removeStr">The remove string.</param>
        /// <returns>
        /// string
        /// </returns>
        /// <code>CTIN_Transformation;</code>
        public static string zSubStr_RemoveStrAtEnd(this string inputStr, string removeStr = "\r\n")
        {
            return LamedalCore_.Instance.Types.String.Edit.Remove_StrAtEnd(inputStr, removeStr);
        }

        /// <summary>
        /// Return the specified chars from the right of the input string.
        /// </summary>
        /// <param name="inputStr">The input string.</param>
        /// <param name="chars">The chars.</param>
        /// <returns></returns>
        /// <code>CTIN_Transformation;</code>
        public static string zSubStr_Right(this string inputStr, int chars)
        {
            return LamedalCore_.Instance.Types.String.Edit.SubStr_Right(inputStr, chars);
        }

        /// <summary>
        /// Splits the on last word.
        /// </summary>
        /// <param name="sentence">The sentence</param>
        /// <param name="firstPart">Return the first part</param>
        /// <param name="lastPart">Return the last part</param>
        /// <param name="space">The space setting. Default value = &quot; &quot;.</param>
        /// <code>CTIN_Transformation;</code>
        public static void zSubStr_SplitOnLastWord(this string sentence, out string firstPart, out string lastPart, string space = " ")
        {
            LamedalCore_.Instance.Types.String.Word.Word_SplitOnLast(sentence, out firstPart, out lastPart, space);
        }

        /// <summary>
        /// Function to return the substring inputStr between indexes of the input string.
        /// </summary>
        /// <param name="inputStr">The inputStr</param>
        /// <param name="indexStart">Index starts the</param>
        /// <param name="indexEnd">The index end</param>
        /// <returns>string</returns>
        /// <code>CTIN_Transformation;</code>
        public static string zSubStr_Save(this string inputStr, int indexStart, int indexEnd)
        {
            return LamedalCore_.Instance.Types.String.Edit.SubStr_Index(inputStr, indexStart, indexEnd);
        }

        /// <summary>
        /// Determines whether the string value is a true or false bool value.
        /// </summary>
        /// <param name="strValue">The string value</param>
        /// <returns>bool</returns>
        /// <code>CTIN_Transformation;</code>
        public static bool zTo_Bool(this string strValue)
        {
            return LamedalCore_.Instance.Types.Convert.Bool_FromStr(strValue);
        }

        /// <summary>
        /// Function to return a global unique identifier from the string value.
        /// </summary>
        /// <param name="strValue">The string value</param>
        /// <returns>Guid</returns>
        /// <code>CTIN_Transformation;</code>
        public static Guid zTo_Guid_(this string strValue)
        {
            return LamedalCore_.Instance.Types.Convert.Guid_FromStr(strValue);
        }

        /// <summary>
        /// Function to return int  from the string value.
        /// </summary>
        /// <param name="strValue">The string value</param>
        /// <param name="nullValue">The null value setting. Default value = 0.</param>
        /// <returns>int</returns>
        /// <code>CTIN_Transformation;</code>
        public static int zTo_Int(this string strValue, int nullValue = 0)
        {
            return LamedalCore_.Instance.Types.Convert.Int_FromStr(strValue, nullValue);
        }
        /// <summary>
        /// Function to return the identifier string variable from the inputStr.
        /// </summary>
        /// <param name="inputStr">The input string.</param>
        /// <param name="delimiter">The delimiter setting. Default value = "".</param>
        /// <returns>
        /// string
        /// </returns>
        /// <code>CTIN_Transformation;</code>
        public static string zvar_Id(this string inputStr, string delimiter = "♣")
        {
            return LamedalCore_.Instance.Types.String.Search.Var_Id(inputStr, delimiter);
        }

        /// <summary>
        /// Function to return value variable part  from the input string.
        /// </summary>
        /// <param name="inputStr">The input string</param>
        /// <param name="delimiter">The delimiter setting. Default value = "♣".</param>
        /// <param name="trim">if set to <c>true</c> [trim].</param>
        /// <returns>
        /// string
        /// </returns>
        /// <code>CTIN_Transformation;</code>
        public static string zvar_Value(this string inputStr, string delimiter = "♣", bool trim = true)
        {
            return LamedalCore_.Instance.Types.String.Search.Var_Value(inputStr, delimiter, trim);
        }

        /// <summary>
        /// Function to get the last word substring from the input string.
        /// </summary>
        /// <param name="inputStr">The input string</param>
        /// <param name="delimiter">The delimiter setting. Default inputStr = &quot; &quot;.</param>
        /// <returns>string</returns>
        /// <code>CTIN_Transformation;</code>
        public static string zWord_Last(this string inputStr, string delimiter = " ")
        {
            return LamedalCore_.Instance.Types.String.Word.Word_Last(inputStr, delimiter);
        }
        /// <summary>
        /// Function to removes the adjacent duplicates words from the sentence.
        /// </summary>
        /// <param name="sentence">The sentence</param>
        /// <returns>string</returns>
        /// <code>CTIN_Transformation;</code>
        public static string zWord_RemoveAdjacentDuplicates(this string sentence)
        {
            return LamedalCore_.Instance.Types.String.Word.Word_RemoveAdjacentDuplicates(sentence);
        }

        /// <summary>
        /// Function to count the total search items contains in the inputStr.
        /// </summary>
        /// <param name="inputStr">The input string.</param>
        /// <param name="searchPattern">The search pattern.</param>
        /// <returns>
        /// int
        /// </returns>
        /// <code>CTIN_Transformation;</code>
        public static int zWord_Total(this string inputStr, string searchPattern)
        {
            return LamedalCore_.Instance.Types.String.Word.Word_Total(inputStr, searchPattern);
        }
    }
}
