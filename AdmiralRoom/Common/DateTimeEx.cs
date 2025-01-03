﻿using System;

namespace Huoyaoyuan.AdmiralRoom
{
    static class DateTimeEx
    {
        public static TimeSpan Remain(this DateTimeOffset time) => time.ToLocalTime() > DateTimeOffset.Now ? time - DateTimeOffset.Now : new TimeSpan(0);
        public static TimeSpan During(this DateTimeOffset time) => time.ToLocalTime() < DateTimeOffset.Now ? DateTimeOffset.Now - time : new TimeSpan(0);
        public static string ToDisplayString(this TimeSpan time)
            => $"{time.Days * 24 + time.Hours:00}:{time.Minutes:00}:{time.Seconds:00}";
        public static DateTimeOffset WeekStart(this DateTimeOffset time)
        {
            try
            {
                int dayofweek = (int)time.DayOfWeek - 1;
                if (dayofweek < 0) dayofweek += 7;
                return time.Date.AddDays(-dayofweek);
            }
            catch { return DateTimeOffset.MinValue; }
        }
        public static DateTime WeekStart(this DateTime time)
        {
            int dayofweek = (int)time.DayOfWeek - 1;
            if (dayofweek < 0) dayofweek += 7;
            return time.Date.AddDays(-dayofweek);
        }
        public static DateTime MonthStart(this DateTime time) => time.Date.AddDays(time.Day - 1);
        public static bool InASecond(this TimeSpan time, double adjust = 0)
        {
            double seconds = time.TotalSeconds;
            return seconds > adjust && seconds <= adjust + 1;
        }
        public static bool InASecond(this DateTimeOffset time, double adjust = 0) => (time - DateTimeOffset.UtcNow).InASecond(adjust);
    }
}
