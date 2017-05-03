using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Drawing;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zz;

namespace LamedalCore.Types.List
{
    public sealed class List_String
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance; // system library

        ///// <summary>
        ///// Search for a value in a string array.
        ///// </summary>
        ///// <param name="array">The array.</param>
        ///// <param name="searchValue">The search value.</param>
        ///// <param name="Index">The index.</param>
        ///// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
        ///// <returns></returns>
        //public bool Find_(string[] array, string searchValue, out int Index, bool ignoreCase = true)
        //{
        //    // Word_FromAbbreviation array to lowercase
        //    if (ignoreCase)
        //    {
        //        IList<string> arrayLower = ToLower(array);
        //        return _lamed.Types.List.Find.Index_OfValue(arrayLower, searchValue.ToLower(), out Index);
        //    }
        //    else return _lamed.Types.List.Find.Index_OfValue(array, searchValue.ToLower(), out Index);
        //}

        ///// <summary>
        ///// Finds all occurrences of findStr.
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="searchList">The search list. #</param>
        ///// <param name="findStr">The find string.</param>
        ///// <param name="caseSensitive">if set to <c>true</c> [case sensitive].</param>
        ///// <returns>
        /////   <c>true</c> if XXXX, <c>false</c> otherwise.
        ///// </returns>
        //public bool Find_StrValue<T>(IList<T> searchList, string findStr, bool caseSensitive = true)
        //{
        //    List<T> result;
        //    return Find_StrValue<T>(searchList, findStr, out result, caseSensitive);
        //}

        ///// <summary>
        ///// Finds all occurrences of findStr.
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="searchList">The search list. #</param>
        ///// <param name="findStr">The find string.</param>
        ///// <param name="result">The result.</param>
        ///// <param name="caseSensitive">if set to <c>true</c> [case sensitive].</param>
        ///// <returns>
        /////   <c>true</c> if XXXX, <c>false</c> otherwise.
        ///// </returns>
        //public bool Find_StrValue<T>(IList<T> searchList, string findStr, out List<T> result, bool caseSensitive = true)
        //{
        //    var searchList2 = new List<T>(searchList);

        //    if (caseSensitive == false)
        //    {
        //        findStr = findStr.ToLower();
        //        result = searchList2.FindAll(delegate (T s) { return s.ToString().ToLower() == (findStr); });
        //    }
        //    else result = searchList2.FindAll(delegate (T s) { return s.ToString() == (findStr); });
        //    return (result.Count > 0);
        //}


        /// <summary>Filters the specified list.</summary>
        /// <param name="list">The project names.</param>
        /// <param name="searchStr">The search string.</param>
        /// <param name="returnFound">if set to <c>true</c> [contains].</param>
        /// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
        /// <returns>List&lt;System.String&gt;.</returns>
        public List<string> Find_All(IList<string> list, string searchStr, bool returnFound = true, bool ignoreCase = true)
        {
            StringComparison comparer = (ignoreCase) ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;

            if (searchStr.zIsNullOrEmpty()) return null;
            if (list == null) return null;
            if (list.Count == 0) return null;

            List<string> prjNames;
            if (returnFound) prjNames = new List<string>(list).FindAll(s => s.IndexOf(searchStr, comparer) >= 0);  // Return what was found
            else prjNames = new List<string>(list).FindAll(s => s.IndexOf(searchStr, comparer) < 0);               // Return what was not found

            return prjNames;
        }

        /// <summary>Filters the specified list.</summary>
        /// <param name="list">The project names.</param>
        /// <param name="searchStr">The search string.</param>
        /// <param name="result">The result.</param>
        /// <param name="returnFound">if set to <c>true</c> [contains].</param>
        /// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
        /// <returns>List&lt;System.String&gt;.</returns>
        public bool Find_All(IList<string> list, string searchStr, out List<string> result, bool returnFound = true, bool ignoreCase = true)
        {
            result = Find_All(list, searchStr, returnFound, ignoreCase);
            if (result == null || result.Count == 0) return false;
            return true;
        }

        /// <summary>Returns the first occurance of an item in a list.</summary>
        /// <param name="list">The project names.</param>
        /// <param name="searchStr">The search string.</param>
        /// <param name="returnFound">if set to <c>true</c> [contains].</param>
        /// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
        /// <returns>List&lt;System.String&gt;.</returns>
        public string Find_FirstStr(IList<string> list, string searchStr, bool returnFound = true, bool ignoreCase = true)
        {
            List<string> resultList = Find_All(list, searchStr, returnFound, ignoreCase);

            if (resultList == null || resultList.Count == 0) return null;
            return resultList[0];
        }

        /// <summary>Returns the first occurance of an item in a list.</summary>
        /// <param name="list">The project names.</param>
        /// <param name="searchStr">The search string.</param>
        /// <param name="returnFound">if set to <c>true</c> [contains].</param>
        /// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
        /// <returns>List&lt;System.String&gt;.</returns>
        public bool Find_First(IList<string> list, string searchStr, bool returnFound = true, bool ignoreCase = true)
        {
            string retunValue;
            var result = Find_First(list, searchStr, out retunValue, returnFound, ignoreCase);
            return result;
        }

        /// <summary>Returns the first occurance of an item in a list.</summary>
        /// <param name="list">The project names.</param>
        /// <param name="searchStr">The search string.</param>
        /// <param name="result">The result.</param>
        /// <param name="returnFound">if set to <c>true</c> [contains].</param>
        /// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
        /// <returns>List&lt;System.String&gt;.</returns>
        public bool Find_First(IList<string> list, string searchStr, out string result, bool returnFound = true, bool ignoreCase = true)
        {
            List<string> resultList = Find_All(list, searchStr, returnFound, ignoreCase);

            if (resultList == null || resultList.Count == 0)
            {
                result = null;
                return false;
            }
            result = resultList[0];
            return true;
        }

        /// <summary>Finds the index in the list. There is some overhead as list is converted to array before search.</summary>
        /// <param name="list">The list.</param>
        /// <param name="searchStr">The search string.</param>
        /// <param name="isContained">if set to <c>true</c> [is contained] else do equal test.</param>
        /// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
        /// <returns></returns>
        public int Find_Index(IList<string> list, string searchStr, bool isContained = false, bool ignoreCase = true)
        {
            var comparer = (ignoreCase) ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
            if (isContained) return Array.FindIndex(list.ToArray(), t => t.IndexOf(searchStr, comparer) >= 0);
            else return Array.FindIndex(list.ToArray(), t => t.Equals(searchStr, comparer));
        }

        /// <summary>
        /// Replaces the values in the specified array.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="oldValue">The old value.</param>
        /// <param name="newValue">The new value.</param>
        /// <returns></returns>
        public string[] Replace(string[] array, string oldValue, string newValue)
        {
            var ii = 0;
            var result = new string[array.Length];
            foreach (var item in array) result[ii++] = item.Replace(oldValue, newValue);

            return result;
        }

        /// <summary>
        /// Sorts the by length.
        /// </summary>
        /// <param name="array">The array</param>
        /// <param name="sortType">Acending indicator. Default value = true.</param>
        /// <returns>IEnumerable<string/></returns>
        public IEnumerable<string> SortByStrLength(IEnumerable<string> array, enSort sortType = enSort.Ascending)
        {
            // Use LINQ to sortType the array received and return a copy.

            if (sortType == enSort.Ascending)
            {
                var sorted = array.OrderBy(str => str.Length).ToArray();
                return sorted;
            }
            else if (sortType == enSort.Descending)
            {
                var sorted = array.OrderByDescending(str => str.Length).ToArray();
                return sorted;
            }
            return array;
        }

        /// <summary>Convert list to dictionary.</summary>
        /// <param name="list">The list.</param>
        /// <param name="seperator">The seperator.</param>
        /// <param name="reverseOrder">if set to <c>true</c> [reverse order] of the keys and values.</param>
        /// <param name="onError">The on error.</param>
        /// <returns></returns>
        public IDictionary<string, string> ToDictionary(IList<string> list, string seperator = "=", bool reverseOrder = false,
                        enDuplicateError onError = enDuplicateError.Ignore)
        {
            var result = new Dictionary<string, string>(list.Count); // Replace with longer version
            foreach (string abbr in list)
            {
                var id = abbr.zvar_Id(seperator);
                var value = abbr.zvar_Value(seperator);
                if (reverseOrder)
                     _lamed.Types.Dictionary.Key_AddSafe(result,value,id, onError);
                else _lamed.Types.Dictionary.Key_AddSafe(result, id, value);
            }
            return result;
        }

        /// <summary>
        /// Split string into string array.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <param name="delimiter">The delimiter.</param>
        /// <returns></returns>
        public List<string> ToListStr(string inputStr, string delimiter = "♣")
        {
            inputStr = inputStr.Replace(delimiter, "♣");
            var list = inputStr.Split('♣').ToList();
            return list;
        }

        /// <summary>
        /// Word_FromAbbreviation all values in array is lower case.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns></returns>
        public IList<string> ToLower(IList<string> array)
        {
            return array.Select(s => s.ToLowerInvariant()).ToList();
        }

        /// <summary>Word_FromAbbreviation an Array to string.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The array.</param>
        /// <param name="delimiter">The delimiter.</param>
        /// <param name="trim">if set to <c>true</c> [trim].</param>
        /// <param name="index">The index.</param>
        /// <param name="lastIndex">The last index. if -1 then it will be up to the last item</param>
        /// <returns>System.String.</returns>
        /// <code ShortcutMethod="ToString"></code>
        public string ToString<T>(IList<T> list, string delimiter = "♣", bool trim = false, int index = 0, int lastIndex = -1)
        {
            if (list == null) return "";
            if (lastIndex == -1 || lastIndex > list.Count) lastIndex = list.Count;

            var result = new StringBuilder("");
            for (var ii = index; ii < lastIndex; ii++)
            {
                string item = list[ii] as string;
                if (trim) item = item.Trim();

                if (ii == index) result.Append(item);
                else result.Append(delimiter + item);
            }
            return result.ToString();
        }

        /// <summary>
        /// Trim left side of all the lines in the array by an equal amount. This has the effect of triming on the left side of a block of text.
        /// </summary>
        /// <param name="lines">The lines array</param>
        /// <returns>string[]</returns>
        public string[] TrimLeftRegion(params string[] lines)
        {
            if (lines.Length <= 1) return lines;

            while (lines[0].Length > 0 && lines[0].Substring(0, 1) == " ")
            {
                for (var ii = 0; ii < lines.Length; ii++)
                {
                    var value = lines[ii];
                    if (value == "") continue;
                    if (value.Substring(0, 1) == " ") lines[ii] = value.Substring(1);
                    //else if (ii != 0) break;  // Line needs test case
                }
            }
            return lines;
        }

        /// <summary>Return a unique list.</summary>
        /// <param name="list">The list.</param>
        /// <param name="sortType">if set to <c>true</c> [sortType].</param>
        /// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">list</exception>
        [Test_IgnoreCoverage(enTestIgnore.MethodIsShortCut)]
        public IList<string> Unique(IList<string> list, enSort sortType = enSort.NoSort, bool ignoreCase = false)
        {
            return _lamed.Types.List.Action.Unique(list, sortType, ignoreCase);
        }
    }
}
