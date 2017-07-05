using System;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zz;
using Xunit;

namespace LamedalCore.Test.Tests.types.other
{
    public partial class xTypes_Other // Types_DateTime_Test 
    {
        [Fact]
        [Test_Method("zObject().AsStr()")]
        public void Date_2String()
        {
            var myDate = new DateTime(2016, 1, 22);
            var strDate = myDate.zObject().AsStr();
            Assert.Equal("2016-01-22", strDate);

            myDate = new DateTime(2016, 1, 22, 13,14,15);
            strDate = myDate.zObject().AsStr();
            Assert.Equal("2016-01-22 13:14:15 PM", strDate);
        }

        [Fact]
        [Test_Method("To_Str()")]
        public void To_Str()
        {
            var myDate = new DateTime(2016, 1, 22, 13,14,15,123);
            Assert.Equal("2016-01-22", _lamed.Types.DateTime.To_Str(myDate, true));
            Assert.Equal("2016-01-22 13:14:15.123", _lamed.Types.DateTime.To_Str(myDate));
            Assert.Equal("2016_01_22", _lamed.Types.DateTime.To_Str(myDate, true, true));
            Assert.Equal("2016_01_22T13_14_15", _lamed.Types.DateTime.To_Str(myDate, filenameFriendly:true));

        }

        [Fact]
        [Test_Method("To_StrReadableTime()")]
        public void To_StrReadableTime_Test()
        {
            var date1 = _lamed.Types.DateTime.Day_Yesterday(DateTime.Now);
            Assert.Equal("1 day ago", _lamed.Types.DateTime.To_StrReadableTime(date1));

            var date2 = DateTime.Now;
            Assert.Equal("2 hours ago", _lamed.Types.DateTime.To_StrReadableTime(date2.AddMinutes(-123)));
            Assert.Equal("12 minutes ago", _lamed.Types.DateTime.To_StrReadableTime(date2.AddMinutes(-12)));

            var date3 = _lamed.Types.DateTime.Day_Past(DateTime.Now,8);
            Assert.Equal(date3.ToString("d"), _lamed.Types.DateTime.To_StrReadableTime(date3));

            Assert.Equal("now", _lamed.Types.DateTime.To_StrReadableTime(DateTime.Now));
            Assert.Equal("5 seconds ago", _lamed.Types.DateTime.To_StrReadableTime(DateTime.Now.AddSeconds(-5)));
        }

        [Fact]
        [Test_Method("IsNull()")]
        public void IsNullDateTime_Test()
        {
            var time1 = _lamed.Types.DateTime.null_;
            Assert.Equal(true, _lamed.Types.DateTime.IsNull(time1));
        }

        [Fact]
        [Test_Method("Age()")]
        public void Age_Test()
        {
            Assert.Equal(48, _lamed.Types.DateTime.Age(new DateTime(1968, 7, 26)));    
            Assert.Equal(49, _lamed.Types.DateTime.Age(new DateTime(1968, 1, 1)));    
            Assert.Equal(24, _lamed.Types.DateTime.Age(new DateTime(1993,4,21)));    
        }

        [Fact]
        [Test_Method("Day_EndOfDay()")]
        public void Day_EndOfDay_Test()
        {
            var date = new DateTime(2013, 6,5,15,10,9);
            date = _lamed.Types.DateTime.Day_EndOfDay(date);
            Assert.Equal(date.Year, 2013);
            Assert.Equal(date.Month, 6);
            Assert.Equal(date.Day, 5);
            Assert.Equal(date.Hour, 23);
            Assert.Equal(date.Minute, 59);
            Assert.Equal(date.Second, 59);
        }

        [Fact]
        [Test_Method("Day_Future()")]
        [Test_Method("Day_Tomorrow()")]
        [Test_Method("Day_Yesterday()")]
        public void Day_Test()
        {
            #region  Day_Future
            var date = new DateTime(2013, 6, 5, 15, 10, 9);
            date = _lamed.Types.DateTime.Day_Future(date,3);
            Assert.Equal(date.Year, 2013);
            Assert.Equal(date.Month, 6);
            Assert.Equal(date.Day, 8);
            Assert.Equal(date.Hour, 15);
            Assert.Equal(date.Minute, 10);
            Assert.Equal(date.Second, 9);
            #endregion

            #region Day_Tomorrow
            date = _lamed.Types.DateTime.Day_Tomorrow(date);
            Assert.Equal(date.Year, 2013);
            Assert.Equal(date.Month, 6);
            Assert.Equal(date.Day, 9);
            Assert.Equal(date.Hour, 15);
            Assert.Equal(date.Minute, 10);
            Assert.Equal(date.Second, 9);
            #endregion

            #region Day_Yesterday
            date = _lamed.Types.DateTime.Day_Yesterday(date);
            Assert.Equal(date.Year, 2013);
            Assert.Equal(date.Month, 6);
            Assert.Equal(date.Day, 8);
            Assert.Equal(date.Hour, 15);
            Assert.Equal(date.Minute, 10);
            Assert.Equal(date.Second, 9);
            #endregion
        }

        [Fact]
        [Test_Method("End_OfMonth()")]
        [Test_Method("End_OfWeek()")]
        [Test_Method("End_OfYear()")]
        public void End_Of_Test()
        {
            #region  End_OfMonth
            var date = new DateTime(2013, 6, 5, 15, 10, 9);
            date = _lamed.Types.DateTime.End_OfMonth(date);
            Assert.Equal(date.Year, 2013);
            Assert.Equal(date.Month, 6);
            Assert.Equal(date.Day, 30);
            Assert.Equal(date.Hour, 23);
            Assert.Equal(date.Minute, 59);
            Assert.Equal(date.Second, 59);
            #endregion

            #region  End_OfWeek
            date = new DateTime(2013, 6, 5, 15, 10, 9);
            date = _lamed.Types.DateTime.End_OfWeek(date);
            Assert.Equal(date.Year, 2013);
            Assert.Equal(date.Month, 6);
            Assert.Equal(date.Day, 8);
            Assert.Equal(date.Hour, 23);
            Assert.Equal(date.Minute, 59);
            Assert.Equal(date.Second, 59);
            Assert.Equal(date.Millisecond, 999);

            date = new DateTime(2013, 6, 5, 15, 10, 9);
            date = _lamed.Types.DateTime.End_OfWeek(date,startDayOfWeek:DayOfWeek.Monday);
            Assert.Equal(date.Year, 2013);
            Assert.Equal(date.Month, 6);
            Assert.Equal(date.Day, 9);
            Assert.Equal(date.Hour, 23);
            Assert.Equal(date.Minute, 59);
            Assert.Equal(date.Second, 59);
            Assert.Equal(date.Millisecond, 999);
            #endregion

            #region  End_OfYear
            date = new DateTime(2013, 6, 5, 15, 10, 9);
            date = _lamed.Types.DateTime.End_OfYear(date);
            Assert.Equal(date.Year, 2013);
            Assert.Equal(date.Month, 12);
            Assert.Equal(date.Day, 31);
            Assert.Equal(date.Hour, 23);
            Assert.Equal(date.Minute, 59);
            Assert.Equal(date.Second, 59);
            #endregion
        }

        [Fact]
        [Test_Method("First_DayOfMonth()")]
        [Test_Method("First_DayOfQuarter()")]
        [Test_Method("First_DayOfYear()")]
        [Test_Method("First_DayOfYear()")]
        public void First_Test()
        {
            #region First_DayOfMonth
            var date = new DateTime(2013, 6, 5, 15, 10, 9);
            date = _lamed.Types.DateTime.First_DayOfMonth(date);
            Assert.Equal(date.Year, 2013);
            Assert.Equal(date.Month, 6);
            Assert.Equal(date.Day, 1);
            Assert.Equal(date.Hour, 15);
            Assert.Equal(date.Minute, 10);
            Assert.Equal(date.Second, 9);
            #endregion

            #region First_DayOfQuarter
            date = new DateTime(2013, 6, 5, 15, 10, 9);
            date = _lamed.Types.DateTime.First_DayOfQuarter(date);
            Assert.Equal(date.Year, 2013);
            Assert.Equal(date.Month, 4);
            Assert.Equal(date.Day, 1);
            Assert.Equal(date.Hour, 15);
            Assert.Equal(date.Minute, 10);
            Assert.Equal(date.Second, 9);
            #endregion

            #region First_DayOfYear
            date = new DateTime(2013, 6, 5, 15, 10, 9);
            date = _lamed.Types.DateTime.First_DayOfYear(date);
            Assert.Equal(date.Year, 2013);
            Assert.Equal(date.Month, 1);
            Assert.Equal(date.Day, 1);
            Assert.Equal(date.Hour, 15);
            Assert.Equal(date.Minute, 10);
            Assert.Equal(date.Second, 9);
            #endregion
        }

        [Fact]
        [Test_Method("IsAfternoon()")]
        [Test_Method("IsMorning()")]
        [Test_Method("IsToday()")]
        [Test_Method("IsWeekDay()")]
        [Test_Method("IsWeekendDay()")]
        [Test_Method("IsInRange()")]
        public void Is_Test()
        {
            #region IsAfternoon
            Assert.Equal(true, _lamed.Types.DateTime.IsAfternoon(new DateTime(2013, 6, 5, 15, 10, 9)));
            Assert.Equal(false, _lamed.Types.DateTime.IsAfternoon(new DateTime(2013, 6, 5, 11, 10, 9)));
            #endregion

            #region IsMorning
            Assert.Equal(false, _lamed.Types.DateTime.IsMorning(new DateTime(2013, 6, 5, 15, 10, 9)));
            Assert.Equal(true, _lamed.Types.DateTime.IsMorning(new DateTime(2013, 6, 5, 11, 10, 9)));
            #endregion

            #region IsToday
            Assert.Equal(true, _lamed.Types.DateTime.IsToday(DateTime.Now));
            Assert.Equal(false, _lamed.Types.DateTime.IsToday(new DateTime(2013, 6, 5, 11, 10, 9)));
            #endregion

            #region IsWeekDay
            Assert.Equal(true, _lamed.Types.DateTime.IsWeekDay(new DateTime(2013, 6, 5, 11, 10, 9)));
            Assert.Equal(false, _lamed.Types.DateTime.IsWeekDay(new DateTime(2016, 12, 25, 18, 10, 9)));
            #endregion

            #region IsWeekendDay
            Assert.Equal(false, _lamed.Types.DateTime.IsWeekendDay(new DateTime(2013, 6, 5, 11, 10, 9)));
            Assert.Equal(true, _lamed.Types.DateTime.IsWeekendDay(new DateTime(2016, 12, 25, 18, 10, 9)));
            #endregion

            #region IsInRange
            var startDate = new DateTime(2013, 1, 1);
            var endDate = new DateTime(2013, 12, 31);
            Assert.Equal(true, _lamed.Types.DateTime.IsInRange(new DateTime(2013, 6, 5, 11, 10, 9), startDate, endDate));
            Assert.Equal(true, _lamed.Types.DateTime.IsInRange(new DateTime(2013, 6, 5, 11, 10, 9), endDate, startDate));
            Assert.Equal(true, _lamed.Types.DateTime.IsInRange(new DateTime(2013, 6, 5, 11, 10, 9), new DateTime(2013, 6, 5, 11, 10, 9), new DateTime(2013, 6, 5, 11, 10, 9)));

            Assert.Equal(false, _lamed.Types.DateTime.IsInRange(new DateTime(2016, 12, 25), startDate, endDate));
            #endregion
        }

        [Fact]
        [Test_Method("Trim_ToDay()")]
        [Test_Method("Trim_ToHour()")]
        [Test_Method("Trim_ToMinute()")]
        [Test_Method("Trim_ToSecond()")]
        public void Trim_Test()
        {
            #region Trim_ToDay
            var date = new DateTime(2013, 6, 5, 15, 10, 9);
            date = _lamed.Types.DateTime.Trim(date,enDateTimeTrim.Trim2Day);
            Assert.Equal(date.Year, 2013);
            Assert.Equal(date.Month, 6);
            Assert.Equal(date.Day, 5);
            Assert.Equal(date.Hour, 0);
            Assert.Equal(date.Minute, 0);
            Assert.Equal(date.Second, 0);
            #endregion

            #region Trim_ToHour
            date = new DateTime(2013, 6, 5, 15, 10, 9);
            date = _lamed.Types.DateTime.Trim(date,enDateTimeTrim.Trim2Hour);
            Assert.Equal(date.Year, 2013);
            Assert.Equal(date.Month, 6);
            Assert.Equal(date.Day, 5);
            Assert.Equal(date.Hour, 15);
            Assert.Equal(date.Minute, 0);
            Assert.Equal(date.Second, 0);
            #endregion

            #region Trim_ToMinute
            date = new DateTime(2013, 6, 5, 15, 10, 9);
            date = _lamed.Types.DateTime.Trim(date,enDateTimeTrim.Trim2Minute);
            Assert.Equal(date.Year, 2013);
            Assert.Equal(date.Month, 6);
            Assert.Equal(date.Day, 5);
            Assert.Equal(date.Hour, 15);
            Assert.Equal(date.Minute, 10);
            Assert.Equal(date.Second, 0);
            #endregion

            #region Trim_ToSecond
            date = new DateTime(2013, 6, 5, 15, 10, 9);
            date = _lamed.Types.DateTime.Trim(date,enDateTimeTrim.Trim2Second);
            Assert.Equal(date.Year, 2013);
            Assert.Equal(date.Month, 6);
            Assert.Equal(date.Day, 5);
            Assert.Equal(date.Hour, 15);
            Assert.Equal(date.Minute, 10);
            Assert.Equal(date.Second, 9);
            Assert.Equal(date.Millisecond, 0);
            #endregion

            #region Trim_ToMilliSecond
            date = new DateTime(2013, 6, 5, 15, 10, 9);
            date = _lamed.Types.DateTime.Trim(date, enDateTimeTrim.Trim2MilliSecond);
            Assert.Equal(date.Year, 2013);
            Assert.Equal(date.Month, 6);
            Assert.Equal(date.Day, 5);
            Assert.Equal(date.Hour, 15);
            Assert.Equal(date.Minute, 10);
            Assert.Equal(date.Second, 9);
            Assert.Equal(date.Millisecond, 0);
            #endregion
        }
    }
}
