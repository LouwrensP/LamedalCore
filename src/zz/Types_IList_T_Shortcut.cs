using System.Collections.Generic;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace LamedalCore.zz
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Transformation_Extention)]
    [Test_IgnoreCoverage(enCode_TestIgnore.MethodIsShortCut)]
    public static class Types_IList_T_Shortcut
    {

        /// <summary>Return true if findValues is contained in list.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <param name="findValues">The find values.</param>
        /// <returns></returns>
        public static bool zContains<T>(this IList<T> list, params T[] findValues)
        {
            return LamedalCore_.Instance.Types.List.Find.In(list, findValues);
        }


        /// <summary>Return a unique list.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        /// <code>CTIN_Transformation;</code>
        public static IList<T> zUnique<T>(this IList<T> list)
        {
            return LamedalCore_.Instance.Types.List.Action.Unique<T>(list);
        }

        /// <summary>
        /// Return a unique list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        /// <code>CTIN_Transformation;</code>
        public static IEnumerable<T> zUnique2<T>(this IEnumerable<T> list)
        {
            return LamedalCore_.Instance.Types.List.Action.Unique<T>(list);
        }
    }
}