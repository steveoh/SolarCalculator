using Newtonsoft.Json;
using SolarCalculator.Models.Date;

namespace SolarCalculator.Models
{
    /// <summary>
    ///   Container for solar potential
    /// </summary>
    public class SolarPotential
    {
        public SolarPotential()
        {
            Duration = new AnnualSolarPotential();
            Radiation = new AnnualSolarPotential();
        }

        /// <summary>
        ///   Gets or sets the duration.
        /// </summary>
        /// <value> The duration. </value>
        [JsonProperty("duration")]
        public AnnualSolarPotential Duration { get; set; }

        /// <summary>
        ///   Gets or sets the radiation.
        /// </summary>
        /// <value> The radiation. </value>
        [JsonProperty("radiation")]
        public AnnualSolarPotential Radiation { get; set; }

        /// <summary>
        ///   Gets or sets the input area.
        /// </summary>
        /// <value> The square meters of input area. </value>
        [JsonProperty("inputArea")]
        public int InputArea { get; set; }

        /// <summary>
        ///   Gets or sets the area used in calculation.
        /// </summary>
        /// <value> The square meters of solar analysis points used in the calculations. Where the duration amount was greater than the threshold.. </value>
        [JsonProperty("qualifyingArea")]
        public int AreaUsedInCalculation { get; set; }
    }
}