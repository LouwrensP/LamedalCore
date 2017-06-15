using System;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace LamedalCore.zz
{
    [Test_IgnoreCoverage(enCode_TestIgnore.MethodIsShortCut)]
    public static class Types_Guid_Shortcut
    {
        /// <summary>
        /// Function to add single quote string to the global unique identifier.
        /// </summary>
        /// <param name="guid">The global unique identifier</param>
        /// <returns>string</returns>
        /// <code>CTIN_Transformation;</code>
        public static string zStr_Q(this Guid guid)
        {
            return LamedalCore_.Instance.Types.String.Quote.Q(guid);
        }
    }
}
