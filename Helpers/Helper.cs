using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.helpers
{
    public static class Helper
    {
        public static int ExtractHour(string inputTime)
        {
            if (string.IsNullOrEmpty(inputTime))
                throw new ArgumentNullException(nameof(inputTime));

            string[] time = inputTime.Split(':');

			if (int.TryParse(time[0], out int hours))
			{
				if (hours < 0 || hours > 24)
					throw new ArgumentOutOfRangeException(nameof(hours), hours, "Not valid hours range (0 - 24)");
			}
			else { throw new ArgumentException("Not valid hours time value", nameof(hours)); }

			return hours;
        }

        public static int ExtractMinutes(string inputTime)
        {
            string[] time = inputTime.Split(':');

			if (int.TryParse(time[1], out int minutes))
			{
				if (minutes < 0 || minutes > 59)
					throw new ArgumentOutOfRangeException(nameof(minutes), minutes, "Not valid minutes range range (0 - 59)");
			}
			else { throw new ArgumentException("Not valid minutes value", nameof(minutes)); }

			return minutes;
        }
        public static int ExtractSeconds(string inputTime)
        {
            string[] time = inputTime.Split(':');

			if (int.TryParse(time[2], out int seconds))
			{
				if (seconds < 0 || seconds > 59)
					throw new ArgumentOutOfRangeException(nameof(seconds), seconds, "Not valid seconds range (0 - 59)");
			}
			else { throw new ArgumentException("Not valid seconds value", nameof(seconds)); }

			return seconds;
        }

		
	}
}
