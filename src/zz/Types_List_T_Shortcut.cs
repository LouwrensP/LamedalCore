using System;
using System.Collections.Generic;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace LamedalCore.zz
{
    /// <summary>
    /// List/<T/> Shortcut methods
    /// </summary>
    [BlueprintRule_Class(enBlueprintClassNetworkType.Transformation_Extention)]
    [Test_IgnoreCoverage(enTestIgnore.MethodIsShortCut)]
    public static class Types_List_T_Shortcut
    {
        
        /// <summary>
        /// Word_FromAbbreviation an List to string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The array.</param>
        /// <param name="delimiter">The delimiter.</param>
        /// <param name="index">The index.</param>
        /// <param name="lastIndex">The last index. if -1 then it will be up to the last item</param>
        /// <returns>System.String.</returns>
        /// <code ShortcutMethod="ToString"></code>
        /// <code>CTIN_Transformation;</code>
        public static string zTo_Str<T>(this List<T> list, string delimiter = ",", int index = 0, int lastIndex = -1)
        {
            return LamedalCore_.Instance.Types.List.String.ToString<T>(list, delimiter, false, index, lastIndex);
        }

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
        ///// <code>CTIN_Transformation;</code>
        //public static bool zFind_All<T>(this List<T> searchList, string findStr, out List<T> result, bool caseSensitive = true)
        //{
        //    return LamedalCore_.Instance.Types.List.String.Find_StrValue<T>(searchList, findStr, out result, caseSensitive);
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
        ///// <code>CTIN_Transformation;</code>
        //public static bool zFind_All<T>(this List<T> searchList, string findStr, bool caseSensitive = true)
        //{
        //    return LamedalCore_.Instance.Types.List.String.Find_StrValue<T>(searchList, findStr, caseSensitive);
        //}

        /// <summary>
        /// Tests if two lists are equal.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list1">The list1.</param>
        /// <param name="list2">The list2.</param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        /// <code>CTIN_Transformation;</code>
        public static bool zIsContained<T>(this IList<T> list1, IList<T> list2, out string errorMsg)
        {
            return LamedalCore_.Instance.Types.List.Find.Contains<T>(list1, list2, out errorMsg);
        }

        /// <summary>
        /// Tests if two lists are equal.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list1">The list1.</param>
        /// <param name="list2">The list2.</param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        /// <code>CTIN_Transformation;</code>
        public static bool zIsEqual<T>(this IList<T> list1, IList<T> list2, out string errorMsg) where T : IComparable
        {
            return LamedalCore_.Instance.Types.List.Find.Identical(list1, list2, out errorMsg);
        }
    }
}