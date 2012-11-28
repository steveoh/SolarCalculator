using Newtonsoft.Json;

namespace SolarCalculator.Models
{
    /// <summary>
    /// Container class for sending back statistics
    /// </summary>
    public class SolarContainer
    {
        public SolarContainer()
        {
            SolarPotential = new DataStructures.SolarPotential();
        }

        public SolarContainer(DataStructures.SolarPotential solarPotential)
        {
            SolarPotential = solarPotential;
        }

        /// <summary>
        /// Gets or sets the solar potential.
        /// </summary>
        /// <value>
        /// The solar potential.
        /// </value>
        [JsonProperty("solarPotential")]
        public DataStructures.SolarPotential SolarPotential { get; set; }
    }
}