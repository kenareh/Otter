using System;
using System.Globalization;

namespace Otter.Common.Tools
{
    public static class JalaliCalendar
    {
        public static string ToJalali(this DateTime dateTime, string template = "{3}:{4} {0}/{1}/{2}")
        {
            PersianCalendar pc = new PersianCalendar();
            int year = pc.GetYear(dateTime);
            int month = pc.GetMonth(dateTime);
            int day = pc.GetDayOfMonth(dateTime);
            int hour = pc.GetHour(dateTime);
            int min = pc.GetMinute(dateTime);
            int sec = pc.GetSecond(dateTime);

            string strMount = month.ToString();
            string strDay = day.ToString();
            string strHour = hour.ToString();
            string strMin = min.ToString();
            if (month < 10) { strMount = "0" + strMount; }
            if (day < 10) { strDay = "0" + strDay; }
            if (hour < 10) { strHour = "0" + strHour; }
            if (min < 10) { strMin = "0" + strMin; }

            return string.Format(template, year, strMount, strDay, strHour, strMin);
        }

        public static string ToJalaliDate(this DateTime dateTime, string template = "{0}/{1}/{2}")
        {
            PersianCalendar pc = new PersianCalendar();
            int year = pc.GetYear(dateTime);
            int month = pc.GetMonth(dateTime);
            int day = pc.GetDayOfMonth(dateTime);
            int hour = pc.GetHour(dateTime);
            int min = pc.GetMinute(dateTime);
            int sec = pc.GetSecond(dateTime);

            string strMount = month.ToString();
            string strDay = day.ToString();
            string strHour = hour.ToString();
            string strMin = min.ToString();
            if (month < 10) { strMount = "0" + strMount; }
            if (day < 10) { strDay = "0" + strDay; }
            if (hour < 10) { strHour = "0" + strHour; }
            if (min < 10) { strMin = "0" + strMin; }

            return string.Format(template, year, strMount, strDay);
        }

        public static DateTime ToMiladi(this string dateTime)
        {
            System.Globalization.CultureInfo pr = new System.Globalization.CultureInfo("fa-ir");
            return DateTime.ParseExact(dateTime, "yyyy-MM-dd", pr);
        }

        public static string GetJalaliDay(this DateTime dateTime)
        {
            var value = dateTime.ToJalaliDate().Substring(8, 2);

            return value;
        }

        public static string GetJalaliMonth(this DateTime dateTime)
        {
            var value = dateTime.ToJalaliDate().Substring(5, 2);

            return value;
        }

        public static string GetJalaliYear(this DateTime dateTime)
        {
            var value = dateTime.ToJalaliDate().Substring(0, 4);

            return value;
        }
    }
}