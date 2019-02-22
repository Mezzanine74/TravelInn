using System;

namespace TravelInn.Common
{
    public struct LocalTime
    {
        public static DateTime GetIstanbul()
        {
            var inTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Russian Standard Time");
            return TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, inTimeZone);
        }
    }
}