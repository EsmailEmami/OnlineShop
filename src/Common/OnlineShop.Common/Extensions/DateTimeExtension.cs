using PersianDate.Standard;
using System.Globalization;

namespace OnlineShop.Common.Extensions
{
    public static class DateTimeExtension
    {
        public static string ToFa(this DateTime d)
        {
            return ConvertDate.ToFa(d);
        }

        public static string ToFa(this DateTime? d)
        {
            if (!d.HasValue)
            {
                return string.Empty;
            }

            return ConvertDate.ToFa(d.Value);
        }

        public static string ToFa(this DateTime d, string format)
        {
            return ConvertDate.ToFa(d, format);
        }

        public static string ToFa(this DateTime? d, string format)
        {
            if (!d.HasValue)
            {
                return string.Empty;
            }

            return ConvertDate.ToFa(d, format);
        }

        public static DateTime ToEn(this string d)
        {
            return ConvertDate.ToEn(d);
        }

        public static DateTime? PersianYearToEn(this string persianYear)
        {
            if (string.IsNullOrEmpty(persianYear) || persianYear.Length < 8)
            {
                return null;
            }

            try
            {
                var fullYearString = string.Empty;
                var fullMonthString = string.Empty;
                var fullDayString = string.Empty;

                var firstYearString = persianYear.Substring(0, 2);

                if (!firstYearString.Equals("13"))
                {
                    return null;
                }

                fullYearString = persianYear.Substring(0, 4);

                if (persianYear.Length > 5)
                {
                    fullMonthString = persianYear.Substring(4, 2);
                }

                if (persianYear.Length > 6)
                {
                    fullDayString = persianYear.Substring(6, 2);
                }


                int year;
                if (!int.TryParse(fullYearString, out year))
                {
                    return null;
                }


                int month;
                if (!int.TryParse(fullMonthString, out month))
                {
                    month = 1;
                }
                else
                {
                    if (month <= 0 || month > 12)
                    {
                        month = 1;
                    }
                }


                int day;
                if (!int.TryParse(fullDayString, out day))
                {
                    day = 1;
                }
                else
                {
                    if (day <= 0 || day >= 31)
                    {
                        day = 1;
                    }
                }

                return new DateTime(year, month, day, new PersianCalendar());
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static DateTime UTCToFa(this DateTime d)
        {
            var tz = TimeZoneInfo.FindSystemTimeZoneById("Iran Standard Time");
            return TimeZoneInfo.ConvertTime(d, TimeZoneInfo.Utc, tz);
        }

        public static long ToUnixTimestamp(this DateTime d)
        {
            try
            {
                var tz = TimeZoneInfo.FindSystemTimeZoneById("Iran Standard Time");

                var dateTime = d;
                if (TimeZoneInfo.Local.Id != tz.Id)
                {
                    dateTime = TimeZoneInfo.ConvertTime(d, TimeZoneInfo.Local, tz);
                }

                var epoch = dateTime.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0);
                return (long)epoch.TotalSeconds;
            }
            catch
            {
                return 0;
            }
        }

        public static long ToUnixTimestamp(this DateTime? d)
        {
            return d?.ToUnixTimestamp() ?? 0;
        }

        public static DateTime FromUnixTimeStamp(this string unixDateTime)
        {
            var utcTime = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(unixDateTime)).DateTime;
            return TimeZoneInfo.ConvertTimeFromUtc(utcTime, TimeZoneInfo.Local);
        }

        public static DateTime FromUnixTimeMillisecondsStamp(this long unixDateTime)
        {
            var utcTime = DateTimeOffset.FromUnixTimeMilliseconds(unixDateTime).DateTime;
            return TimeZoneInfo.ConvertTimeFromUtc(utcTime, TimeZoneInfo.Local);
        }

        public static int CurrentFarsiSalNum() => DateAndTimeH.CurrentFarsiSalNum;
    }
}
