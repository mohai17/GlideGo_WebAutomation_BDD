using System;
using System.Collections.Generic;
using System.Globalization;

namespace ProjectUtilityDateHelper;
public class DateHelper
{
    public static List<string> DateTimeSeparation(string date)
    {
        // Parse using exact format
        DateTime dt = DateTime.ParseExact(
            date,
            "dd-MMM-yyyy hh:mm:ss tt",
            CultureInfo.InvariantCulture
        );

        // Extract components
        int day = dt.Day;
        string month = dt.ToString("MMM", CultureInfo.InvariantCulture);
        int year = dt.Year;
        int hour24 = dt.Hour;   // 24-hour format
        int minute = dt.Minute;
        int second = dt.Second;

        //Convert to 12 - hour format
        int hour12 = dt.Hour % 12;
        if (hour12 == 0) hour12 = 12;

        string meridiem = dt.ToString("tt", CultureInfo.InvariantCulture);

        // Return all components in a list
        return new List<string>
        {
            day.ToString(),
            month.ToString(),
            year.ToString(),
            hour24.ToString(),
            hour12.ToString(),
            minute.ToString(),
            second.ToString(),
            meridiem
        };
    }
}