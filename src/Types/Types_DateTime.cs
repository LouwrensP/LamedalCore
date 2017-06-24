using System;
using System.Globalization;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace LamedalCore.Types
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_Action)]
    public sealed class Types_DateTime
    {

        /// <summary>
        ///     A DateTime extension method that ages the given this.
        /// </summary>
        /// <param name="date">The @this to act on.</param>
        /// <returns>An int.</returns>
        public int Age(DateTime date)
        {
            if (DateTime.Today.Month < date.Month ||
                DateTime.Today.Month == date.Month &&
                DateTime.Today.Day < date.Day) return DateTime.Today.Year - date.Year - 1;

            return DateTime.Today.Year - date.Year;
        }


        #region Day
        /// <summary>
        ///     A DateTime extension method that return a DateTime with the time set to "23:59:59:999". The last moment of
        ///     the day. Use "DateTime2" column type in sql to keep the precision.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>A DateTime of the day with the time set to "23:59:59:999".</returns>
        public DateTime Day_EndOfDay(DateTime @this)
        {
            return new DateTime(@this.Year, @this.Month, @this.Day).AddDays(1).Subtract(new TimeSpan(0, 0, 0, 0, 1));
        }

        /// <summary>Go to day in the future. Negative values will go to the past</summary>
        /// <param name="this">The this.</param>
        /// <param name="days">The days.</param>
        /// <returns></returns>
        public DateTime Day_Future(DateTime @this, int days = 1)
        {
            return @this.AddDays(days);
        }

        /// <summary>Go to day in the past. Negative values will go to the future</summary>
        /// <param name="this">The this.</param>
        /// <param name="days">The days.</param>
        /// <returns></returns>
        public DateTime Day_Past(DateTime @this, int days = 1)
        {
            return Day_Future(@this, -days);
        }

        /// <summary>
        ///     A DateTime extension method that tomorrows the given this.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>Tomorrow date at same time.</returns>
        public DateTime Day_Tomorrow(DateTime @this)
        {
            return Day_Future(@this, 1);
        }

        /// <summary>
        ///     A DateTime extension method that yesterdays the given this.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>Yesterday date at same time.</returns>
        public DateTime Day_Yesterday(DateTime @this)
        {
            return Day_Future(@this, -1);
        }
        #endregion

        #region EndOf
        /// <summary>
        ///     A DateTime extension method that return a DateTime of the last day of the month with the time set to
        ///     "23:59:59:999". The last moment of the last day of the month.  Use "DateTime2" column type in sql to keep the
        ///     precision.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>A DateTime of the last day of the month with the time set to "23:59:59:999".</returns>
        [BlueprintRule_MethodAliasDef(MirrorMethodName = "Month_LastDay")]
        public DateTime End_OfMonth(DateTime @this)
        {
            return new DateTime(@this.Year, @this.Month, 1).AddMonths(1).Subtract(new TimeSpan(0, 0, 0, 0, 1));
        }

        /// <summary>
        ///     A System.DateTime extension method that ends of week.
        /// </summary>
        /// <param name="dt">Date/Time of the dt.</param>
        /// <param name="startDayOfWeek">(Optional) the start day of week.</param>
        /// <returns>A DateTime.</returns>
        [BlueprintRule_MethodAliasDef(MirrorMethodName = "Week_LastDay")]
        public DateTime End_OfWeek(DateTime dt, DayOfWeek startDayOfWeek = DayOfWeek.Sunday)
        {
            var end = dt;
            var endDayOfWeek = startDayOfWeek - 1;
            if (endDayOfWeek < 0)
            {
                endDayOfWeek = DayOfWeek.Saturday;
            }

            if (end.DayOfWeek != endDayOfWeek)
            {
                if (endDayOfWeek < end.DayOfWeek)
                {
                    end = end.AddDays(7 - (end.DayOfWeek - endDayOfWeek));
                }
                else
                {
                    end = end.AddDays(endDayOfWeek - end.DayOfWeek);
                }
            }

            return new DateTime(end.Year, end.Month, end.Day, 23, 59, 59, 999);
        }

        ///// <summary>
        /////     A DateTime extension method that last day of week.
        ///// </summary>
        ///// <param name="this">The @this to act on.</param>
        ///// <returns>A DateTime.</returns>
        //public DateTime End_OfWeek(DateTime @this)
        //{
        //    return new DateTime(@this.Year, @this.Month, @this.Day).AddDays(6 - (int)@this.DayOfWeek);
        //}

        /// <summary>
        ///     A DateTime extension method that return a DateTime of the last day of the year with the time set to
        ///     "23:59:59:999". The last moment of the last day of the year.  Use "DateTime2" column type in sql to keep the
        ///     precision.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>A DateTime of the last day of the year with the time set to "23:59:59:999".</returns>
        [BlueprintRule_MethodAliasDef(MirrorMethodName = "Year_LastDay")]
        public DateTime End_OfYear(DateTime @this)
        {
            return new DateTime(@this.Year, 1, 1).AddYears(1).Subtract(new TimeSpan(0, 0, 0, 0, 1));
        }
        #endregion

        #region First
        /// <summary>
        /// Gets a <see cref="DateTime"/> that represents the first day of 
        /// the month of this <see cref="DateTime"/>.
        /// </summary>
        [BlueprintRule_MethodAliasDef(MirrorMethodName = "Month_FirstDay")]
        public DateTime First_DayOfMonth(DateTime time)
        {
            return new DateTime(time.Year, time.Month, 1, time.Hour, time.Minute, time.Second, time.Millisecond,
                time.Kind);
        }

        /// <summary>
        /// Gets a <see cref="DateTime"/> that represents the first day of 
        /// the quarter of this <see cref="DateTime"/>.
        /// </summary>
        [BlueprintRule_MethodAliasDef(MirrorMethodName = "Quarter_FirstDay")]
        public DateTime First_DayOfQuarter(DateTime time)
        {
            return new DateTime(time.Year, (Quarter_Get(time) - 1) * 3 + 1, 1, time.Hour, time.Minute, time.Second,
                time.Millisecond, time.Kind);
        }

        /// <summary>
        /// Gets a <see cref="DateTime"/> that represents the first day of 
        /// the year of this <see cref="DateTime"/>.
        /// </summary>
        [BlueprintRule_MethodAliasDef(MirrorMethodName = "Year_FirstDay")]
        public DateTime First_DayOfYear(DateTime time)
        {
            return new DateTime(time.Year, 1, 1, time.Hour, time.Minute, time.Second, time.Millisecond, time.Kind);
        }
        #endregion

        #region Is
        /// <summary>
        ///     A DateTime extension method that query if '@this' is afternoon.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>true if afternoon, false if not.</returns>
        public bool IsAfternoon(DateTime @this)
        {
            return @this.TimeOfDay >= new DateTime(2000, 1, 1, 12, 0, 0).TimeOfDay;
        }

        /// <summary>
        /// A T extension method that check if the value is between inclusively the minValue and maxValue.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns>
        /// true if the value is between inclusively the minValue and maxValue, otherwise false.
        /// </returns>
        /// ###
        public bool IsInRange(DateTime @this, DateTime minValue, DateTime maxValue)
        {
            if (minValue.CompareTo(maxValue) <= 0)
                 return @this.CompareTo(minValue) >= 0 && @this.CompareTo(maxValue) <= 0;
            else return IsInRange(@this, maxValue, minValue);
        }

        /// <summary>
        ///     A DateTime extension method that query if '@this' is morning.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>true if morning, false if not.</returns>
        public bool IsMorning(DateTime @this)
        {
            return @this.TimeOfDay < new DateTime(2000, 1, 1, 12, 0, 0).TimeOfDay;
        }

        /// <summary>
        ///     A DateTime extension method that query if '@this' is today.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>true if today, false if not.</returns>
        public bool IsToday(DateTime @this)
        {
            return @this.Date == DateTime.Today;
        }

        /// <summary>
        ///     A DateTime extension method that query if '@this' is a week day.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>true if '@this' is a week day, false if not.</returns>
        public bool IsWeekDay(DateTime @this)
        {
            return !(@this.DayOfWeek == DayOfWeek.Saturday || @this.DayOfWeek == DayOfWeek.Sunday);
        }

        /// <summary>
        ///     A DateTime extension method that query if '@this' is a weekend day.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>true if '@this' is a weekend day, false if not.</returns>
        public bool IsWeekendDay(DateTime @this)
        {
            return (@this.DayOfWeek == DayOfWeek.Saturday || @this.DayOfWeek == DayOfWeek.Sunday);
        }
        #endregion

        /// <summary>
        /// Determines the quarter (from 1 to 4) to which the date belongs.
        /// </summary>
        public int Quarter_Get(DateTime date)
        {
            return ((date.Month - 1) / 3) + 1;
        }

        /// <summary>Convert date time to simple readable time.</summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public string To_StrReadableTime(DateTime value)
        {
            TimeSpan span = DateTime.Now.Subtract(value);
            const string plural = "s";

            //if (span.Days > 7) return value.ToShortDateString();
            if (span.Days > 7) return value.ToString("d");

            switch (span.Days)
            {
                case 0:
                    switch (span.Hours)
                    {
                        case 0:
                            if (span.Minutes == 0)
                            {
                                return span.Seconds <= 0
                                           ? "now"
                                           : string.Format("{0} second{1} ago", span.Seconds, span.Seconds != 1 ? plural : string.Empty);
                            }
                            return string.Format("{0} minute{1} ago", span.Minutes, span.Minutes != 1 ? plural : string.Empty);
                        default: return string.Format("{0} hour{1} ago", span.Hours, span.Hours != 1 ? plural : string.Empty);
                    }
                default: return string.Format("{0} day{1} ago", span.Days, span.Days != 1 ? plural : string.Empty);
            }
        }

        /// <summary>Conver date to string.</summary>
        /// <param name="date">The date.</param>
        /// <param name="dateOnly">if set to <c>true</c> [date only].</param>
        /// <param name="filenameFriendly">if set to <c>true</c> [file name friendly version].</param>
        /// <returns></returns>
        public string To_Str(DateTime date, bool dateOnly = false, bool filenameFriendly = false)
        {
            var formatStr = "yyyy-MM-dd";
            if (dateOnly == false) formatStr += " HH:mm:ss.fff";
            if (filenameFriendly)
            {
                formatStr = formatStr.Replace("-", "_").Replace(" ", "T").Replace(":", "_").Replace(".fff", "");
            }
            string result = date.ToString(formatStr, CultureInfo.InvariantCulture);
            return result;
        }

        /// <summary>Trims to the nearest milli-second.</summary>
        /// <param name="time">The date time</param>
        /// <param name="trim">The trim.</param>
        /// <returns>DateTime</returns>
        public DateTime Trim(DateTime time, enDateTimeTrim trim = enDateTimeTrim.Trim2Second)
        {
            switch (trim)
            {
               case enDateTimeTrim.Trim2Day:  return time.Date;
               case enDateTimeTrim.Trim2Hour: return Trim_Setup(time, TimeSpan.FromHours(1));
               case enDateTimeTrim.Trim2Minute: return Trim_Setup(time, TimeSpan.FromMinutes(1));
               case enDateTimeTrim.Trim2Second: return Trim_Setup(time, TimeSpan.FromSeconds(1));
               case enDateTimeTrim.Trim2MilliSecond: return Trim_Setup(time, TimeSpan.FromMilliseconds(1));
               default: throw new Exception($"Argument '{nameof(trim)}' error.");
            }
         }

        /// <summary>Trim the time to the specified timespan.</summary>
        /// <param name="dateTime">The date time.</param>
        /// <param name="timeSpan">The time span.</param>
        /// <returns></returns>
        private DateTime Trim_Setup(DateTime dateTime, TimeSpan? timeSpan = null)
        {
            var timespan1 = timeSpan ?? TimeSpan.Zero;
            // if (timespan1 == TimeSpan.Zero) return dateTime; // Or could throw an ArgumentException
            return dateTime.AddTicks(-(dateTime.Ticks % timespan1.Ticks));
        }

        /// <summary>Return the Null time value.</summary>
        /// <returns></returns>
        public DateTime null_ { get {return default(DateTime);} }
        
        /// <summary>Determines whether the specified time is null.</summary>
        /// <param name="time">The time.</param>
        /// <returns></returns>
        public bool IsNull(DateTime time)
        {
            return (time == null_);
        }

    }
}
