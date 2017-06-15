using System;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace LamedalCore.zz
{
    [Test_IgnoreCoverage(enCode_TestIgnore.MethodIsShortCut)]
    public static class Types_DateTime_Shortcut
    {
        ///// <summary>
        ///// Function to return elapsed time span from the start date.
        ///// </summary>
        ///// <param name="startDate">The start date</param>
        ///// <returns>TimeSpan</returns>
        ///// <code>CTIN_Transformation;</code>
        //public static TimeSpan zElapsed(this DateTime startDate)
        //{
        //    return LamedalCore_.Instance.Types.TimeSpan.Elapsed(startDate);
        //}
        ///// <summary>
        ///// Function to return elapsed time span from the start date.
        ///// </summary>
        ///// <param name="startDate">The start date</param>
        ///// <param name="endDate">The end date</param>
        ///// <returns>TimeSpan</returns>
        ///// <code>CTIN_Transformation;</code>
        //public static TimeSpan zElapsed(this DateTime startDate, DateTime endDate)
        //{
        //    return LamedalCore_.Instance.Types.TimeSpan.Elapsed(startDate, endDate);
        //}

        /// <summary>
        /// Function to add single quote string to the date inputStr.
        /// </summary>
        /// <param name="dateValue">The date inputStr</param>
        /// <returns>string</returns>
        /// <code>CTIN_Transformation;</code>
        public static string zStr_Q(this DateTime dateValue)
        {
            return LamedalCore_.Instance.Types.String.Quote.Q(dateValue);
        }
    }
}
