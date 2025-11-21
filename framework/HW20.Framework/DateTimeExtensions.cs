using System;
using System.Globalization;

namespace HW20.Domain.Core.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// تبدیل تاریخ شمسی (string) به DateTime میلادی
        /// فرمت ورودی: "yyyy/MM/dd" یا "yyyy-MM-dd"
        /// </summary>
        /// 

        public static string ToShamsi(this DateTime date)
        {
            var pc = new PersianCalendar();

            int year = pc.GetYear(date);
            int month = pc.GetMonth(date);
            int day = pc.GetDayOfMonth(date);

            return $"{year:0000}/{month:00}/{day:00}";
        }
        public static DateTime ToGregorianDateTime(this string persianDate)
        {
            if (string.IsNullOrWhiteSpace(persianDate))
                throw new ArgumentNullException(nameof(persianDate));

            // جایگزین کردن اعداد فارسی با انگلیسی
            persianDate = persianDate
                .Replace("۰", "0").Replace("۱", "1").Replace("۲", "2")
                .Replace("۳", "3").Replace("۴", "4").Replace("۵", "5")
                .Replace("۶", "6").Replace("۷", "7").Replace("۸", "8")
                .Replace("۹", "9");

            // جایگزین کردن خط تیره با اسلش در صورت وجود
            persianDate = persianDate.Replace("-", "/");

            var parts = persianDate.Split('/');
            if (parts.Length != 3)
                throw new FormatException("فرمت تاریخ شمسی باید yyyy/MM/dd باشد.");

            int year = int.Parse(parts[0]);
            int month = int.Parse(parts[1]);
            int day = int.Parse(parts[2]);

            var pc = new PersianCalendar();
            return pc.ToDateTime(year, month, day, 0, 0, 0, 0);
        }

    }
}
