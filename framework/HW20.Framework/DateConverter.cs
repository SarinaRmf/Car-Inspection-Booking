using System;
using System.Globalization;

namespace HW20.Framework
{
    public static class DateTimeExtensions
    {
        private static readonly PersianCalendar _pc = new PersianCalendar();

        /// <summary>
        /// تبدیل تاریخ شمسی (سال، ماه، روز) به میلادی
        /// توجه: ورودی باید واقعاً تاریخ شمسی باشد، یعنی از UI یا DTO گرفته شده.
        /// </summary>
        public static DateTime ToGregorian(int year, int month, int day, int hour = 0, int minute = 0, int second = 0)
        {
            return _pc.ToDateTime(year, month, day, hour, minute, second, 0);
        }

        /// <summary>
        /// تبدیل میلادی به شمسی (DateTimeKind.Unspecified)
        /// </summary>
        public static DateTime ToPersianDateTime(this DateTime miladiDate)
        {
            int year = _pc.GetYear(miladiDate);
            int month = _pc.GetMonth(miladiDate);
            int day = _pc.GetDayOfMonth(miladiDate);

            return new DateTime(year, month, day,
                miladiDate.Hour,
                miladiDate.Minute,
                miladiDate.Second,
                miladiDate.Millisecond,
                DateTimeKind.Unspecified);
        }

        /// <summary>
        /// تبدیل میلادی به رشته شمسی
        /// </summary>
        public static string ToShamsiString(this DateTime miladiDate)
        {
            int year = _pc.GetYear(miladiDate);
            int month = _pc.GetMonth(miladiDate);
            int day = _pc.GetDayOfMonth(miladiDate);

            return $"{year:0000}/{month:00}/{day:00}";
        }
    }
}
