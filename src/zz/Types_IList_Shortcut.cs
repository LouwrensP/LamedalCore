using System.Collections;
using System.Collections.Generic;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace LamedalCore.zz
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Transformation_Extention)]
    [Test_IgnoreCoverage(enCode_TestIgnore.MethodIsShortCut)]
    public static class Types_IList_Shortcut
    {
        /// <summary>
        /// Copies items from one list to the other list.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="fromList">From list.</param>
        /// <param name="clearList">if set to <c>true</c> [clear list].</param>
        /// <param name="iiStart">The ii start.</param>
        /// <param name="iiEnd">The ii end.</param>
        /// <code>CTIN_Transformation;</code>
        public static void zFrom_IList<T>(this IList<T> list, IList<T> fromList, bool clearList = true, int iiStart = 0, int iiEnd = -1)
        {
            LamedalCore_.Instance.Types.List.Action.Copy_From(list, fromList, clearList, iiStart, iiEnd);
        }
        /// <summary>
        /// Word_FromAbbreviation a List to a string.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="delimiter">The delimiter.</param>
        /// <param name="trim">if set to <c>true</c> [trim].</param>
        /// <returns></returns>
        /// <code>CTIN_Transformation;</code>
        public static string zTo_Str<T>(this IList<T> list, string delimiter = "♣", bool trim = false)
        {
            return LamedalCore_.Instance.Types.List.String.ToString(list, delimiter, trim);
        }

        /// <summary>
        /// Copies items from one list to the other list.
        /// </summary>
        /// <param name="fromList">From list.</param>
        /// <param name="toList">To list.</param>
        /// <param name="clearList">if set to <c>true</c> [clear list].</param>
        /// <param name="iiStart">The ii start.</param>
        /// <param name="iiEnd">The ii end.</param>
        /// <code>IgnoreName;</code>
        /// <code>CTIN_Transformation;</code>
        public static void zTo_IList<T>(this IList<T> fromList, IList<T> toList, bool clearList = true, int iiStart = 0, int iiEnd = -1)
        {
            LamedalCore_.Instance.Types.List.Action.Copy_To(fromList, toList, clearList, iiStart, iiEnd);
        }

    }
}