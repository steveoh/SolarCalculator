using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json;

namespace SolarCalculator.Models.Date
{
    /// <summary>
    ///   A model for json serialization of teh solar results
    /// </summary>
    public class AnnualSolarPotential
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="AnnualSolarPotential" /> class.
        /// </summary>
        public AnnualSolarPotential()
        {
            January = new Collection<int>();
            February = new Collection<int>();
            March = new Collection<int>();
            April = new Collection<int>();
            May = new Collection<int>();
            June = new Collection<int>();
            July = new Collection<int>();
            August = new Collection<int>();
            September = new Collection<int>();
            October = new Collection<int>();
            November = new Collection<int>();
            December = new Collection<int>();
        }

        /// <summary>
        ///   Gets or sets the january.
        /// </summary>
        /// <value> The january values. </value>
        [JsonIgnore]
        public Collection<int> January { get; set; }

        /// <summary>
        ///   Gets or sets the february.
        /// </summary>
        /// <value> The february values. </value>
        [JsonIgnore]
        public Collection<int> February { get; set; }

        /// <summary>
        ///   Gets or sets the march.
        /// </summary>
        /// <value> The march values. </value>
        [JsonIgnore]
        public Collection<int> March { get; set; }

        /// <summary>
        ///   Gets or sets the april.
        /// </summary>
        /// <value> The april. </value>
        [JsonIgnore]
        public Collection<int> April { get; set; }

        /// <summary>
        ///   Gets or sets the may.
        /// </summary>
        /// <value> The may. </value>
        [JsonIgnore]
        public Collection<int> May { get; set; }

        /// <summary>
        ///   Gets or sets the june.
        /// </summary>
        /// <value> The june. </value>
        [JsonIgnore]
        public Collection<int> June { get; set; }

        /// <summary>
        ///   Gets or sets the july.
        /// </summary>
        /// <value> The july. </value>
        [JsonIgnore]
        public Collection<int> July { get; set; }

        /// <summary>
        ///   Gets or sets the august.
        /// </summary>
        /// <value> The august. </value>
        [JsonIgnore]
        public Collection<int> August { get; set; }

        /// <summary>
        ///   Gets or sets the september.
        /// </summary>
        /// <value> The september. </value>
        [JsonIgnore]
        public Collection<int> September { get; set; }

        /// <summary>
        ///   Gets or sets the october.
        /// </summary>
        /// <value> The october. </value>
        [JsonIgnore]
        public Collection<int> October { get; set; }

        /// <summary>
        ///   Gets or sets the november.
        /// </summary>
        /// <value> The november. </value>
        [JsonIgnore]
        public Collection<int> November { get; set; }

        /// <summary>
        ///   Gets or sets the december.
        /// </summary>
        /// <value> The december. </value>
        [JsonIgnore]
        public Collection<int> December { get; set; }

        /// <summary>
        ///   Gets the jan average.
        /// </summary>
        /// <value> The jan average. </value>
        [JsonProperty("january")]
        public double JanAverage
        {
            get { return January.Average(); }
        }

        /// <summary>
        ///   Gets the feb average.
        /// </summary>
        /// <value> The feb average. </value>
        [JsonProperty("february")]
        public double FebAverage
        {
            get { return February.Average(); }
        }

        /// <summary>
        ///   Gets the march average.
        /// </summary>
        /// <value> The march average. </value>
        [JsonProperty("march")]
        public double MarchAverage
        {
            get { return March.Average(); }
        }

        /// <summary>
        ///   Gets the april average.
        /// </summary>
        /// <value> The april average. </value>
        [JsonProperty("april")]
        public double AprilAverage
        {
            get { return April.Average(); }
        }

        /// <summary>
        ///   Gets the may average.
        /// </summary>
        /// <value> The may average. </value>
        [JsonProperty("may")]
        public double MayAverage
        {
            get { return May.Average(); }
        }

        /// <summary>
        ///   Gets the june average.
        /// </summary>
        /// <value> The june average. </value>
        [JsonProperty("june")]
        public double JuneAverage
        {
            get { return June.Average(); }
        }

        /// <summary>
        ///   Gets the july average.
        /// </summary>
        /// <value> The july average. </value>
        [JsonProperty("july")]
        public double JulyAverage
        {
            get { return July.Average(); }
        }

        /// <summary>
        ///   Gets the august average.
        /// </summary>
        /// <value> The august average. </value>
        [JsonProperty("august")]
        public double AugustAverage
        {
            get { return August.Average(); }
        }

        /// <summary>
        ///   Gets the september average.
        /// </summary>
        /// <value> The september average. </value>
        [JsonProperty("september")]
        public double SeptemberAverage
        {
            get { return September.Average(); }
        }

        /// <summary>
        ///   Gets the october average.
        /// </summary>
        /// <value> The october average. </value>
        [JsonProperty("october")]
        public double OctoberAverage
        {
            get { return October.Average(); }
        }

        /// <summary>
        ///   Gets the november average.
        /// </summary>
        /// <value> The november average. </value>
        [JsonProperty("november")]
        public double NovemberAverage
        {
            get { return November.Average(); }
        }

        /// <summary>
        ///   Gets the december average.
        /// </summary>
        /// <value> The december average. </value>
        [JsonProperty("december")]
        public double DecemberAverage
        {
            get { return December.Average(); }
        }
    }
}