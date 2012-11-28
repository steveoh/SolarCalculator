using Newtonsoft.Json;

namespace SolarCalculator.DataStructures
{
    public class SolarPotential
    {
        public SolarPotential()
        {
            Duration = new CalendarMonths();
            Radiation = new CalendarMonths();
        }

        [JsonProperty("duration")]
        public CalendarMonths Duration { get; set; }

        [JsonProperty("radiation")]
        public CalendarMonths Radiation { get; set; }
    }
}