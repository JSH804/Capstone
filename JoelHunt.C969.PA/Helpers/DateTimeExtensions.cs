using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoelHunt.C969.PA.Helpers
{
    public static class DateTimeExtensions
    {
        public static DateTime StartOfWeek(this DateTime datetime)
        {
            return datetime.AddDays(-(int)datetime.DayOfWeek + 1).Date;
        }

        public static DateTime GetNextWeekday(this DateTime datetime, DayOfWeek dayOfWeek)
        {
            DateTime nextday = datetime.AddDays(1);

            int currentDay = (int)datetime.DayOfWeek;
            int difference = (int)dayOfWeek - (int)currentDay;

            if (difference <= 0)
                nextday.AddDays(7);

            while (nextday.DayOfWeek != dayOfWeek)
                nextday = nextday.AddDays(1);
            return nextday;
        }
    }
}
