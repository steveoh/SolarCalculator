using System.Collections.Generic;
using Newtonsoft.Json;

namespace SolarCalculator.Models
{
    public class AreaOfInterest
    {
        [JsonProperty("polygon")]
        public List<decimal> Polygon { get; set; }

        public override string ToString()
        {
            return string.Join(", ", Polygon);
        }
    }
}