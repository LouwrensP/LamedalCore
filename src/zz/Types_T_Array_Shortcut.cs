using System.Collections.Generic;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace LamedalCore.zz
{
    [Test_IgnoreCoverage(enTestIgnore.MethodIsShortCut)]
    public static class Types_T_Array_Shortcut
    {
        ///// <summary>
        ///// Word_FromAbbreviation an Array to string.
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="array">The array.</param>
        ///// <param name="delimiter">The delimiter.</param>
        ///// <param name="index">The index.</param>
        ///// <param name="lastIndex">The last index. if -1 then it will be up to the last item</param>
        ///// <returns>System.String.</returns>
        ///// <code ShortcutMethod="ToString"></code>
        ///// <code>CTIN_Transformation;</code>
        //public static string zTo_Str<T>(this List<T> array, string delimiter = "", int index = 0, int lastIndex = -1)
        //{
        //    return LamedalCore_.Instance.Types.List.Convert.ToString<T>(array, delimiter, index, lastIndex);
        //}
        /// <summary>
        /// Copies array to List.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fromArray">From array.</param>
        /// <param name="toList">To list.</param>
        /// <param name="clearList">if set to <c>true</c> [clear list].</param>
        /// <code ShortcutMethod="To_List"></code>
        /// <code>CTIN_Transformation;</code>
        public static void zTo_List<T>(this List<T> fromArray, List<T> toList, bool clearList = true)
        {
            LamedalCore_.Instance.Types.List.Action.Copy_To<T>(fromArray, toList, clearList);
        }

        
        ///// <summary>
        ///// Copies array to List.
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="fromArray">From array.</param>
        ///// <param name="toList">To list.</param>
        ///// <param name="clearList">if set to <c>true</c> [clear list].</param>
        ///// <code>CTIN_Transformation;</code>
        //public static void zFrom_Array<T>(this T[] fromArray, List<T> toList, bool clearList = true)
        //{
        //    LamedalCore_.Instance.Types.List.Action.Copy_FromArray<T>(toList, fromArray, clearList);
        //}

        ///// <summary>
        ///// Return the Unique values in an array.
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="array">The array.</param>
        ///// <returns></returns>
        ///// <code>CTIN_Transformation;</code>
        //public static T[] zUnique<T>(this T[] array)
        //{
        //    return LamedalCore_.Instance.Types.List.Array.Unique<T>(array);
        //}

        ///// <summary>
        ///// Sorts the specified array.
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="array">The array.</param>
        ///// <code>CTIN_Transformation;</code>
        //public static void zSort<T>(this T[] array)
        //{
        //    LamedalCore_.Instance.Types.List.Array.Sort<T>(array);
        //}

        /// <summary>
        /// Searches for a value in an array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">The array.</param>
        /// <param name="searchValue">The search value.</param>
        /// <param name="Index">The index.</param>
        /// <returns></returns>
        /// <code>CTIN_Transformation;</code>
        public static bool zSearchValue<T>(this T[] array, T searchValue, out int Index)
        {
            return LamedalCore_.Instance.Types.List.Find.Index_OfValue<T>(array, searchValue, out Index);
        }

        /// <summary>
        /// Move the elements in an array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">The array.</param>
        /// <param name="oldIndex">The old index.</param>
        /// <param name="newIndex">The new index.</param>
        /// <code>CTIN_Transformation;</code>
        public static void zMove_Elements<T>(this T[] array, int oldIndex, int newIndex)
        {
            LamedalCore_.Instance.Types.List.Action.MoveElements<T>(array, oldIndex, newIndex);
        }
      
    }
}