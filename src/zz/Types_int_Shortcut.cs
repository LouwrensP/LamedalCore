using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace LamedalCore.zz
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Transformation_Extention)]
    [Test_IgnoreCoverage(enCode_TestIgnore.MethodIsShortCut)]
    public static class Types_int_Shortcut
    {
        /// <summary>
        /// Ensure that number will always be betweens the specified number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="minNumber">The minimum number.</param>
        /// <param name="maxNumber">The maximum number.</param>
        /// <returns></returns>
        /// <code>CTIN_Transformation;</code>
        public static bool zIs_Between(this int number, int minNumber, int maxNumber)
        {
            return LamedalCore_.Instance.Types.Number.IsBetween(number, minNumber, maxNumber);
        }
        /// <summary>
        /// Function to return string  from the int value.
        /// </summary>
        /// <param name="intValue">The int value</param>
        /// <param name="minWidth">The minimum width setting. Default value = 0.</param>
        /// <param name="fillchar">The fillchar setting. Default value = &apos;0&apos;.</param>
        /// <param name="zeroValue">The ero value setting. Default value = &quot;0&quot;.</param>
        /// <returns>string</returns>
        /// <code>CTIN_Transformation;</code>
        public static string zTo_Str(this int intValue, int minWidth = 0, char fillchar = '0', string zeroValue = "0")
        {
            return LamedalCore_.Instance.Types.Convert.Str_FromInt(intValue, minWidth, fillchar, zeroValue);
        }
    }
}
