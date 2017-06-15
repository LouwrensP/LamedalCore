using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.lib.IO;
using LamedalCore.Types;
using LamedalCore.Types.List;

namespace LamedalCore.zz
{
    [Test_IgnoreCoverage(enCode_TestIgnore.MethodIsShortCut)]
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Transformation_Connector)]
    public static class aConnectors
    {
        /// <summary>
        /// Hook all IO methods to this setup point.
        /// </summary>
        /// <param name="emptyFloat">The empty float.</param>
        public static IO_ zIO(this float emptyFloat)
        {
            return LamedalCore_.Instance.lib.IO;
        }

        /// <summary>
        /// Hook all Type methods to this setup point.
        /// </summary>
        /// <param name="emptyFloat">The empty float.</param>
        public static Types_ zTypes(this float emptyFloat)
        {
            return LamedalCore_.Instance.Types;
        }

        /// <summary>
        /// Hook all list methods onta an empty string.
        /// </summary>
        /// <param name="emptyStr">The empty string.</param>
        /// <returns>Blueprint.Rules.Types.Types_.</returns>
        public static List_ zList(this float emptyStr)
        {
            return LamedalCore_.Instance.Types.List;
        }
    }


}
