using Newtonsoft.Json;
using SolarCalculator.DataStructures;

namespace SolarCalculator.Models
{
    /// <summary>
    ///   Container class for sending back statistics
    /// </summary>
    public class SolarContainer
    {
        public SolarContainer()
        {
            SolarPotential = new SolarPotential();
        }

        public SolarContainer(SolarPotential solarPotential)
        {
            SolarPotential = solarPotential;
        }

        /// <summary>
        ///   Gets or sets the solar potential.
        /// </summary>
        /// <value> The solar potential. </value>
        [JsonProperty("solarPotential")]
        public SolarPotential SolarPotential { get; set; }
    }
}