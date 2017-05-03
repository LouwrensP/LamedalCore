using System;
using System.Diagnostics;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace LamedalCore.zz
{
    [BlueprintRule_Class(enBlueprintClassNetworkType.Transformation_Connector)]
    [Test_IgnoreCoverage(enTestIgnore.MethodIsShortCut)]
    public static class zSystem
    {

        /// <summary>
        /// Add enters to line.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        public static string NL(this string line, int total = 1)
        {
            return LamedalCore_.Instance.Types.String.SpecialChar.Function_NL(line, total);
        }

        /// <summary>
        /// Add Tabs to the specified line.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        public static string TAB(this string line, int total = 1)
        {
            return LamedalCore_.Instance.Types.String.SpecialChar.Function_TAB(line, total);
        }

        /// <summary>
        /// Get the next variable from a line.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <param name="delimiter">The delimiter.</param>
        /// <param name="trim">if set to <c>true</c> [trim].</param>
        /// <returns></returns>
        public static string zVar_Next(this string delimiter, ref string line, bool trim = true)
        {
            return LamedalCore_.Instance.Types.String.Search.Var_Next(ref line, delimiter, trim);
        }

        /// <summary>
        /// Create string from format definition.
        /// </summary>
        /// <param name="stringFormat">The string format.</param>
        /// <param name="objects">The objects array.</param>
        /// <returns>string</returns>
        [DebuggerStepThrough]
        public static string zFormat(this string stringFormat, params object[] objects)
        {
            return string.Format((IFormatProvider)null, stringFormat, objects);
        }

        #region Exceptions

        /// <summary>Show Exception Message.</summary>
        /// <param name="ex">The ex.</param>
        /// <param name="errMsg">The error MSG.</param>
        /// <param name="action">The action.</param>
        [DebuggerStepThrough]
        public static void zException_Show(this Exception ex, string errMsg = "", enExceptionAction action = enExceptionAction.ThrowError)
        {
            LamedalCore_.Instance.Exceptions.Show(ex, errMsg, action);
        }

        /// <summary>Show Exception Message.</summary>
        /// <param name="errMsg">The error MSG.</param>
        /// <param name="action">The action.</param>
        /// <param name="innerException">The inner exception.</param>
        [DebuggerStepThrough]
        public static void zException_Show(this string errMsg,enExceptionAction action = enExceptionAction.ThrowError, Exception innerException = null)
        {
            LamedalCore_.Instance.Exceptions.Show(errMsg, action, innerException);
        }

        /// <summary>Creates new exception.</summary>
        /// <param name="errMsg">The error MSG.</param>
        /// <param name="innerException">The inner exception.</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static Exception zException_New(this string errMsg, Exception innerException = null)
        {
            return LamedalCore_.Instance.Exceptions.New(errMsg, innerException);
        }
        #endregion

        /// <summary>
        /// Determines whether the string is null or empty.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="orEqualTo">The or equal to setting. Default value = "".</param>
        /// <returns>
        /// bool
        /// </returns>
        public static bool zIsNullOrEmpty(this string str, string orEqualTo = "")
        {
            var result = String.IsNullOrEmpty(str);
            if (!result) result = (str == orEqualTo);
            return result;
        }

        /// <summary>
        /// Determines whether the string is null or white space.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>
        /// bool
        /// </returns>
        public static bool zIsNullOrWhiteSpace(this string str)
        {
            return String.IsNullOrWhiteSpace(str);
        }

    }
}
