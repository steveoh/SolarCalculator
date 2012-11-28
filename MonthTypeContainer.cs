using System;
using SolarCalculator.Models.Enums;

namespace SolarCalculator
{
    public class MonthTypeContainer
    {
        public MonthTypeContainer(string month, string type)
        {
            CalendarMonth calendarMonth;
            SolarType solarType;

            if (!Enum.TryParse(month, out calendarMonth))
            {
                throw new ArgumentException("Month is not a calendar month");
            }

            if(!Enum.TryParse(type, out solarType))
            {
                throw new ArgumentException("Solar type is not duration or radiation"); 
            }

            Month = calendarMonth;
            SolarType = solarType;
        }

        public CalendarMonth Month { get; set; }
        public SolarType SolarType { get; set; }
    }
}