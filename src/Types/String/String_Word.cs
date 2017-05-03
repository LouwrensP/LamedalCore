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
    /// Actions of sentences and words
    /// </summary>
    [BlueprintRule_Class(enBlueprintClassNetworkType.Node_Action, DefaultType = typeof(string), GroupName = "Str")]
    public sealed class String_Word
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance;

        /// <summary>Return the last word substring from the input string. The space character is customisable.</summary>
        /// <param name="sentence">The input string</param>
        /// <param name="delimiter">The delimiter setting. Default inputStr = " ".</param>
        /// <returns>string</returns>
        [Pure]
        public string Word_Last(string sentence, string delimiter = " ")
        {
            if (sentence.zIsNullOrEmpty()) return "";
            return sentence.Substring(sentence.LastIndexOf(delimiter) + 1);
        }

        /// <summary>Removes the last word from the input string.</summary>
        /// <param name="inputStr">The input string</param>
        /// <param name="delimiter">The delimiter setting. Default value = " ".</param>
        /// <returns>string</returns>
        public string Word_LastWord_Remove(string inputStr, string delimiter = " ")
        {
            var lastWord = Word_Last(inputStr, delimiter);
            var len = inputStr.Length - lastWord.Length;
            var result = inputStr.Substring(0, len);
            result = _lamed.Types.String.Edit.Remove_StrAtEnd(result, delimiter);
            return result;
        }

        /// <summary>Removes the adjacent duplicates words from the sentence.</summary>
        /// <param name="sentence">The sentence</param>
        /// <returns>string</returns>
        public string Word_RemoveAdjacentDuplicates(string sentence)
        {
            var words = sentence.zConvert_Array_FromStr(" ").ToList();
            var resultList = new List<string>();
            var word0 = "";
            for (var ii = 0; ii < words.Count; ii++)
            {
                var word1 = words[ii];
                if (word1 != word0) resultList.Add(word1);
                word0 = word1;
            }
            var result = resultList.zTo_Str(" ");
            return result;
        }

        /// <summary>Count the total items contained in the input string.</summary>
        /// <param name="sentence">The input string.</param>
        /// <param name="word2Search">The search pattern.</param>
        /// <returns>
        /// int
        /// </returns>
        [Pure]
        public int Word_Total(string sentence, string word2Search)
        {
            int count = 0, n = 0;

            if (word2Search != "")
            {
                while ((n = sentence.IndexOf(word2Search, n, StringComparison.CurrentCultureIgnoreCase)) != -1)
                {
                    n += word2Search.Length;
                    ++count;
                }
            }
            return count;
        }

        /// <summary>
        /// Converts the input text to camel case words string. booBa -> boo Ba
        /// </summary>
        /// <param name="camelCaseWord">The input string</param>
        /// <param name="convert2Lower">To lower indicator. Default value = false.</param>
        /// <returns>string</returns>
        [Pure]
        public string Word_Words_FromCamelCase(string camelCaseWord, bool convert2Lower = false)
        {
            // Break sentence up in words
            var result = "";
            var previousIsLower = false;
            foreach (char c in camelCaseWord)
            {
                if ((c >= 65 && c <= 90))     // A..Z
                {
                    if (previousIsLower) result += " ";    // Only split if uppercase follows lowercase
                    previousIsLower = false;
                }
                else previousIsLower = true;

                result += c;
            }
            if (convert2Lower) result = result.ToLower();  // Lowercase the words

            return result.Trim();
        }

        
        /// <summary>Splits the sentance on the last word. Words are identified by the space parameter.</summary>
        /// <param name="sentence">The sentence</param>
        /// <param name="firstPart">Return the first part</param>
        /// <param name="lastPart">Return the last part</param>
        /// <param name="space">The space setting. Default value = " ".</param>
        public void Word_SplitOnLast(string sentence, out string firstPart, out string lastPart, string space = " ")
        {
            var words = sentence.zConvert_Array_FromStr(space);
            var total = words.Count;
            firstPart = words.zTo_Str(space, 0, total - 1);
            lastPart = words[total - 1];
        }

        /// <summary>
        /// Replaces the input string by swapping the last underscore words.
        /// </summary>
        /// <param name="inputStr">The input string.</param>
        /// <returns>
        /// string
        /// </returns>
        [Pure]
        public string Word_SwapLast2UnderscoreWords(string inputStr)
        {
            if (inputStr.Contains("_") == false) return inputStr;

            var result = "";
            var words = inputStr.Split('_');
            for (var ii = 0; ii < words.Length - 2; ii++)
            {
                if (result == "") result += words[ii];
                else result += " " + words[ii];
            }

            // Only swap the last 2 words
            if (result != "") result += " ";
            result += words[words.Length - 1] + " ";
            result += words[words.Length - 2];

            return result;
        }

    }
}
