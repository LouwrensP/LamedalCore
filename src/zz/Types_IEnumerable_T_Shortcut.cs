using System.Collections.Generic;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace LamedalCore.zz
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Transformation_Extention)]
    [Test_IgnoreCoverage(enCode_TestIgnore.MethodIsShortCut)]
    public static class Types_IEnumerable_T_Shortcut
    {
        /// <summary>
        /// Return a unique list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        /// <code>CTIN_Transformation;</code>
        public static IList<T> zUnique<T>(this IList<T> list)
        {
            return LamedalCore_.Instance.Types.List.Action.Unique<T>(list);
        }
        
    }
}
