using BerlinClock.helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BerlinClock
{
	public class TimeConverter : ITimeConverter
	{
		public string convertTime(string aTime)
		{

			#region Validate and Extract numbers
			int hours = Helper.ExtractHour(aTime);
			int minutes = Helper.ExtractMinutes(aTime);
			int seconds = Helper.ExtractSeconds(aTime);
			#endregion

			string[] yellowLampSecond = GetYellowLampValue(seconds);

			string[] hoursRow = GetHoursRowValues(hours);

			string[] hourRow = GetHourRowValues(hours);

			string[] minutesRow = GetMinutesRowValues(minutes);

			string[] minuteRow = GetMinuteRowValues(minutes);

			List<string[]> rows = AddValuesToList(yellowLampSecond, hoursRow, hourRow, minutesRow, minuteRow);

			StringBuilder outputResult = GetStringOutputFromList(rows);

			return outputResult.ToString();
		}

		private static StringBuilder GetStringOutputFromList(List<string[]> rows)
		{
			var outputResult = new StringBuilder();
			var last = rows.Last();

			foreach (var item in rows)
			{
				outputResult.Append(String.Join("", item));
				if (item != last)
				{
					outputResult.AppendLine();
				}
			}

			return outputResult;
		}

		private static List<string[]> AddValuesToList(string[] yellowLampSecond, string[] hoursRow, string[] hourRow, string[] minutesRow, string[] minuteRow)
		{
			var rows = new List<string[]>();

			rows.Add(yellowLampSecond);
			rows.Add(hoursRow);
			rows.Add(hourRow);
			rows.Add(minutesRow);
			rows.Add(minuteRow);
			return rows;
		}

		private static string[] GetMinuteRowValues(int minutes)
		{
			return new string[4] {    minutes % 5 >= 1 ? "Y" : "O",
											   minutes % 5 >= 2 ? "Y" : "O",
											   minutes % 5 >= 3 ? "Y" : "O",
											   minutes % 5 >= 4 ? "Y" : "O" };
		}

		private static string[] GetMinutesRowValues(int minutes)
		{
			return new string[11] {  minutes >= 5  ? "Y" : "O",
											   minutes >= 10 ? "Y" : "O",
											   minutes >= 15 ? "R" : "O",
											   minutes >= 20 ? "Y" : "O",
											   minutes >= 25 ? "Y" : "O",
											   minutes >= 30 ? "R" : "O",
											   minutes >= 35 ? "Y" : "O",
											   minutes >= 40 ? "Y" : "O",
											   minutes >= 45 ? "R" : "O",
											   minutes >= 50 ? "Y" : "O",
											   minutes >= 55 ? "Y" : "O"};
		}

		private static string[] GetHourRowValues(int hours)
		{
			return new string[4] {      hours % 5 >= 1 ? "R" : "O",
											   hours % 5 >= 2 ? "R" : "O",
											   hours % 5 >= 3 ? "R" : "O",
											   hours % 5 >= 4 ? "R" : "O" };
		}

		private static string[] GetHoursRowValues(int hours)
		{
			return new string[4] {     hours >= 5?  "R" : "O",
											   hours >= 10? "R" : "O",
											   hours >= 15? "R" : "O",
											   hours >= 20? "R" : "O"};
		}

		private static string[] GetYellowLampValue(int seconds)
		{
			return new string[1] { seconds % 2 == 0 ? "Y" : "O" };
		}
	}
}
