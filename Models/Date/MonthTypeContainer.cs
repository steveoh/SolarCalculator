using System;
using SolarCalculator.Models.Enums;

namespace SolarCalculator.Models.Date
{
    /// <summary>
    ///   A data transfer object for solidifying the month type and solar type
    /// </summary>
    public class MonthTypeContainer
    {
        public MonthTypeContainer(string monthString, string type)
        {
            Month month;
            SolarType solarType;

            if (!Enum.TryParse(monthString, out month))
            {
                throw new ArgumentException("Month is not a calendar month");
            }

            if (!Enum.TryParse(type, out solarType))
            {
                throw new ArgumentException("Solar type is not duration or radiation");
            }

            Month = month;
            SolarType = solarType;
        }

        public Month Month { get; set; }
        public SolarType SolarType { get; set; }
    }
}