using System.Collections.Generic;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace LamedalCore.zz
{
    [BlueprintRule_Class(enBlueprintClassNetworkType.Transformation_Extention)]
    [Test_IgnoreCoverage(enTestIgnore.MethodIsShortCut)]
    public static class Types_IEnumerable_string_Shortcut
    {

        /// <summary>
        /// String sorts the by length.
        /// </summary>
        /// <param name="array">The ienumerable&lt;string&gt;</param>
        /// <param name="sortType">sortType indicator. Default value = true.</param>
        /// <returns>IEnumerable<string/></returns>
        public static IEnumerable<string> zArray_SortByLength(this IEnumerable<string> array, enSort sortType = enSort.Ascending)
        {
            return LamedalCore_.Instance.Types.List.String.SortByStrLength(array, sortType);
        }

    }
}
