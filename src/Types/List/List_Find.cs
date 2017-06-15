using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zz;

namespace LamedalCore.Types.List
{
    /// <summary>
    ///  Generic list methods
    /// </summary>
    /// <remarks>IgnoreGroup</remarks>
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_Action, GroupName = "Generic", IgnoreGroup = true)]
    public sealed class List_Find
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance; // system library

        /// <summary>Tests if two lists are equal.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list1">The list1.</param>
        /// <param name="list2">The list2.</param>
        /// <param name="equalItems">if set to <c>true</c> [equal items].</param>
        /// <returns></returns>
        public bool Contains<T>(IList<T> list1, IList<T> list2, bool equalItems = false)
        {
            string errorMsg;
            return Contains(list1, list2, out errorMsg, equalItems);
        }

        ///// <summary>Searches for a value withing an array.</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="list2Search">The array.</param>
        ///// <param name="searchValue">The search value.</param>
        ///// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
        ///// <returns></returns>
        ///// <code>Recall</code>
        //public bool Contains<T>(IList<T> list2Search, T searchValue, bool ignoreCase = false)
        //{
        //    if (searchValue is string)
        //    {
        //        var valueTest = searchValue.ToString().Trim();
        //        if (ignoreCase) valueTest = valueTest.ToLower();
        //        foreach (var item in list2Search)
        //        {
        //            var value = (ignoreCase) ? item.ToString().Trim().ToLower() : item.ToString().Trim();
        //            if (value.Contains(valueTest)) return true;  //-----------------------------------------------
        //        }
        //    }
        //    else
        //    {
        //        foreach (var item in list2Search)
        //        {
        //            if (item.Equals(searchValue)) return true;  // ---------------------------
        //        }
        //    }
        //    return false;
        //}

        /// <summary>Tests if two lists have equal values. The order of the values need not be the same</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list1">The list1.</param>
        /// <param name="list2">The list2.</param>
        /// <param name="equalItems">if set to <c>true</c> [equal items].</param>
        /// <param name="errorMsg">The error MSG.</param>
        /// <returns></returns>
        public bool Contains<T>(IList<T> list1, IList<T> list2, out string errorMsg, bool equalItems = false)
        {
            var result = true;
            errorMsg = "";
            if (list1 == null && list2 == null) return true;
            if (list1 == null) return false;
            if (list2 == null) return false;

            if (equalItems & list1.Count != list2.Count)
            {
                errorMsg = $"Error! List1.Count = {list1.Count}; List2.Count = {list2.Count} ({list1.Count} != {list2.Count})".NL();
                result = false;
            }

            var list1Hash = new HashSet<T>(list1);
            for (var ii = 0; ii < list2.Count; ii++)
            {
                var value = list2[ii];
                if (list1Hash.Contains(value) == false)
                {
                    var value1 = list1[ii] as string;
                    var value2 = list2[ii] as string;
                    int index;
                    string err1;
                    _lamed.Types.String.Search.Equal_(value1, value2, out err1, out index);
                    errorMsg += "Error! No match found at index = " + ii + ".".NL() + err1;
                    result = false;
                    break;
                }
            }
            return result;
        }

        /// <summary>Tests if two lists are exactly the same. Order of elements must also match.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list1">The list1.</param>
        /// <param name="list2">The list2.</param>
        /// <param name="errorMsg">The error MSG.</param>
        /// <returns></returns>
        public bool Identical<T>(IList<T> list1, IList<T> list2, out string errorMsg) where T : IComparable
        {
            errorMsg = "";
            if (list1 == null && list2 == null) return true;
            if (list1 == null) return false;
            if (list2 == null) return false;

            if (list1.Count != list2.Count) errorMsg = $"Error! Item counts mismatch {list1.Count} != {list2.Count}.".NL();
            T value1 = _lamed.Types.Object.DefaultValue<T>();

            for (var ii = 0; ii < list2.Count; ii++)
            {
                if (ii < list1.Count) value1 = list1[ii];
                var value2 = list2[ii];
                if (value1.CompareTo(value2) != 0 )
                {
                    int index;
                    string errMsg1;
                    _lamed.Types.String.Search.Equal_(value1.ToString(), value2.ToString(), out errMsg1, out index);
                    errorMsg += "Error! No match found at index = " + ii + ".".NL() + errMsg1;
                    return false;
                }
            }
            return true;
        }

        /// <summary>Tests if two lists are exactly the same. Order of elements must also match.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list1">The list1.</param>
        /// <param name="list2">The list2.</param>
        /// <returns></returns>
        public bool Identical<T>(IList<T> list1, IList<T> list2) where T : IComparable
        {
            string errorMsg;
            return Identical(list1, list2, out errorMsg);
        }

        /// <summary>Searches for a value withing an array.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arrayToSearch">The array.</param>
        /// <param name="searchValue">The search value.</param>
        /// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
        /// <returns></returns>
        /// <code>Recall</code>
        public bool In<T>(IList<T> arrayToSearch, T searchValue, bool ignoreCase = false)
        {
            if (searchValue is string)
            {
                var valueTest = searchValue.ToString().Trim();
                if (ignoreCase) valueTest = valueTest.ToLower();
                foreach (var item in arrayToSearch)
                {
                    var value = (ignoreCase) ? item.ToString().Trim().ToLower() : item.ToString().Trim();
                    if (value == valueTest) return true;  //-----------------------------------------------
                }
            }
            else
            {
                foreach (var item in arrayToSearch)
                {
                    if (item.Equals(searchValue)) return true;  // ---------------------------
                }
            }
            return false;
        }

        /// <summary>Return true if findValues is contained in list.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <param name="findValues">The find values.</param>
        /// <returns></returns>
        public bool In<T>(IList<T> list, params T[] findValues)
        {
            foreach (T value in findValues)
            {
                var result = _lamed.Types.List.Find.In(list, value);
                if (result == false) return false;
            }
            return true;
        }

        /// <summary>Determines whether the source value is in the compare values.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="findValue">The value to find</param>
        /// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
        /// <param name="list">The compare values optional array</param>
        /// <returns>bool</returns>
        /// <exception cref="System.ArgumentNullException">findValue</exception>
        public bool In<T>(T findValue, bool ignoreCase = false, params T[] list)
        {
            if (findValue == null) throw new ArgumentNullException(nameof(findValue));

            return In(list, findValue, ignoreCase);
        }

        /// <summary>
        /// Searches for a value in an array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">The array.</param>
        /// <param name="searchValue">The search value.</param>
        /// <param name="Index">The index.</param>
        /// <returns></returns>
        public bool Index_OfValue<T>(IList<T> array, T searchValue, out int Index)
        {
            Index = array.IndexOf(searchValue);
            return (Index != -1);
        }

        /// <summary>Determines whether list [is null or empty].</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        public bool IsNullOrEmpty<T>(ICollection<T> list)
        {
            return list == null || list.Count == 0;
        }

    }
}
