using System.Collections.Generic;
using Newtonsoft.Json;

namespace SolarCalculator.Models
{
    /// <summary>
    /// Solar Potential
    /// </summary>
    public class SolarPotential
    {
        public SolarPotential()
        {
            DurationForMonths = new List<int>();
            RadiationForMonths = new List<int>();
        }

        [JsonProperty("durationForMonths")]
        public List<int> DurationForMonths { get; set; }

        [JsonProperty("radiationForMonths")]
        public List<int> RadiationForMonths { get; set; }

        [JsonProperty("durationArea")]
        public int DurationArea { get; set; }
    }
}
