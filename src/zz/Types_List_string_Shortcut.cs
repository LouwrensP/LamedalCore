using System;
using System.Collections.Generic;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace LamedalCore.zz
{    
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Transformation_Extention)]
    [Test_IgnoreCoverage(enCode_TestIgnore.MethodIsShortCut)]
    public static class Types_List_string_Shortcut
    {

        /// <summary>Filters the specified list.</summary>
        /// <param name="list">The project names.</param>
        /// <param name="searchStr">The search string.</param>
        /// <param name="Contains">if set to <c>true</c> [contains].</param>
        /// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
        /// <returns>List&lt;System.String&gt;.</returns>
        /// <code>CTIN_Transformation;</code>
        public static List<string> zFind_All(this IList<string> list, string searchStr, bool Contains = true, bool ignoreCase = true)
        {
            return LamedalCore_.Instance.Types.List.String.Find_All(list, searchStr, Contains, ignoreCase);
        }

        /// <summary>Filters the specified list.</summary>
        /// <param name="list">The project names.</param>
        /// <param name="searchStr">The search string.</param>
        /// <param name="result">The result.</param>
        /// <param name="Contains">if set to <c>true</c> [contains].</param>
        /// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
        /// <returns>List&lt;System.String&gt;.</returns>
        public static bool zFind_All(this IList<string> list, string searchStr, out List<string> result, bool Contains = true, bool ignoreCase = true)
        {
            return LamedalCore_.Instance.Types.List.String.Find_All(list, searchStr, out result, Contains, ignoreCase);
        }

        /// <summary>Returns the first occurance of an item in a list.</summary>
        /// <param name="list">The project names.</param>
        /// <param name="searchStr">The search string.</param>
        /// <param name="Contains">if set to <c>true</c> [contains].</param>
        /// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
        /// <returns>List&lt;System.String&gt;.</returns>
        public static string zFind_FirstStr(this IList<string> list, string searchStr, bool Contains = true, bool ignoreCase = true)
        {
            return LamedalCore_.Instance.Types.List.String.Find_FirstStr(list, searchStr, Contains, ignoreCase);
        }

        /// <summary>Returns the first occurance of an item in a list.</summary>
        /// <param name="list">The project names.</param>
        /// <param name="searchStr">The search string.</param>
        /// <param name="result">The result.</param>
        /// <param name="Contains">if set to <c>true</c> [contains].</param>
        /// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
        /// <returns>List&lt;System.String&gt;.</returns>
        public static bool zFind_First(this IList<string> list, string searchStr, out string result, bool Contains = true, bool ignoreCase = true)
        {
            return LamedalCore_.Instance.Types.List.String.Find_First(list, searchStr, out result, Contains, ignoreCase);
        }

        /// <summary>Returns the first occurance of an item in a list.</summary>
        /// <param name="list">The project names.</param>
        /// <param name="searchStr">The search string.</param>
        /// <param name="Contains">if set to <c>true</c> [contains].</param>
        /// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
        /// <returns>List&lt;System.String&gt;.</returns>
        public static bool zFind_First(this IList<string> list, string searchStr, bool Contains = true, bool ignoreCase = true)
        {
            return LamedalCore_.Instance.Types.List.String.Find_First(list, searchStr, Contains, ignoreCase);
        }
    }
}
