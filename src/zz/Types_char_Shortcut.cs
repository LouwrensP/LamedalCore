using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace LamedalCore.zz
{
    [Test_IgnoreCoverage(enCode_TestIgnore.MethodIsShortCut)]
    public static class Types_char_Shortcut
    {
        /// <summary>
        /// Function to return int  from the string value.
        /// </summary>
        /// <param name="charValue">The string value</param>
        /// <param name="nullValue">The null value setting. Default value = 0.</param>
        /// <returns>int</returns>
        /// <code>CTIN_Transformation;</code>
        public static int zTo_Int(this char charValue, int nullValue = 0)
        {
            return LamedalCore_.Instance.Types.Convert.Int_FromChar(charValue);
        }
    }
}
