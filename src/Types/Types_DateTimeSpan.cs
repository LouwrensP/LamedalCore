using System;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace LamedalCore.Types
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_Action, GroupName = "TimeSpan", IgnoreGroup = true)]
    public sealed class Types_DateTimeSpan
    {

        /// <summary>
        /// Function to return elapsed time span from the start date.
        /// </summary>
        /// <param name="startDate">The start date</param>
        /// <param name="endDate">The end date</param>
        /// <returns>TimeSpan</returns>
        public TimeSpan Elapsed(DateTime startDate, DateTime endDate)
        {
            var result = endDate.Subtract(startDate);
            return result;
        }

        /// <summary>
        /// Function to return elapsed time span from the start date.
        /// </summary>
        /// <param name="startDate">The start date</param>
        /// <returns>TimeSpan</returns>
        public TimeSpan Elapsed(DateTime startDate)
        {
            var now = DateTime.UtcNow;
            return Elapsed(startDate, now);
        }


    }
}
