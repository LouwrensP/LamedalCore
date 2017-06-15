using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.lib.IO;

namespace LamedalCore.lib
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Transformation_Connector)]
    [Test_IgnoreCoverage(enCode_TestIgnore.MethodIsShortCut)]
    public static class lib_zzConnectors
    {
        /// <summary>
        /// Hook all IO methods to this setup point.
        /// </summary>
        /// <param name="emptyFloat">The empty float.</param>
        public static IO_ zIO(this float emptyFloat)
        {
            return LamedalCore_.Instance.lib.IO;
        }
    }
}
