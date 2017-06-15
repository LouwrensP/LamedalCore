using System.Collections.Generic;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace LamedalCore.zz
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Transformation_Extention)]
    [Test_IgnoreCoverage(enCode_TestIgnore.MethodIsShortCut)]
    public static class Types_string_Array_Shortcut
    {
        /// <summary>
        /// Trim left side of all the lines in the array.
        /// </summary>
        /// <param name="lines">The lines array</param>
        /// <returns>string[]</returns>
        /// <code>CTIN_Transformation;</code>
        public static string[] zTrimLeft(this string[] lines)
        {
            return LamedalCore_.Instance.Types.List.String.TrimLeftRegion(lines);
        }

        /// <summary>
        /// Word_FromAbbreviation all values in array is lower case.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns></returns>
        /// <code>CTIN_Transformation;</code>
        public static IList<string> zStr_ToLower(this IList<string> array)
        {
            return LamedalCore_.Instance.Types.List.String.ToLower(array);
        }

        ///// <summary>
        ///// Search for a value in a string array.
        ///// </summary>
        ///// <param name="array">The array.</param>
        ///// <param name="searchValue">The search value.</param>
        ///// <param name="Index">The index.</param>
        ///// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
        ///// <returns></returns>
        ///// <code>CTIN_Transformation;</code>
        //public static bool zStr_SearchValue(this string[] array, string searchValue, out int Index, bool ignoreCase = true)
        //{
        //    return LamedalCore_.Instance.Types.List.String.Find_(array, searchValue, out Index, ignoreCase);
        //}

        /// <summary>
        /// Replaces the values in the specified array.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="oldValue">The old value.</param>
        /// <param name="newValue">The new value.</param>
        /// <returns></returns>
        /// <code>CTIN_Transformation;</code>
        public static string[] zStr_Replace(this string[] array, string oldValue, string newValue)
        {
            return LamedalCore_.Instance.Types.List.String.Replace(array, oldValue, newValue);
        }

        
    }
}