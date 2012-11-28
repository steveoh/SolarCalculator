using Newtonsoft.Json;

namespace SolarCalculator.Models.Date
{
    /// <summary>
    ///   A model for json serialization of teh solar results
    /// </summary>
    public class AnnualSolarPotential
    {
        private double _aprilTotal;

        private double _augustTotal;

        private double _decemberTotal;
        private double _februaryTotal;
        private double _januaryTotal;

        private double _julyTotal,
                       _juneTotal;

        private double _marchTotal;
        private double _mayTotal;
        private double _novemberTotal;
        private double _octoberTotal;
        private double _septemberTotal;

        [JsonIgnore]
        public int Points { get; set; }

        /// <summary>
        ///   Gets the jan average.
        /// </summary>
        /// <value> The jan average. </value>
        [JsonProperty("january")]
        public double January
        {
            get { return Average(_januaryTotal); }
            set { _januaryTotal = value; }
        }

        /// <summary>
        ///   Gets the feb average.
        /// </summary>
        /// <value> The feb average. </value>
        [JsonProperty("february")]
        public double February
        {
            get { return Average(_februaryTotal); }
            set { _februaryTotal = value; }
        }

        /// <summary>
        ///   Gets the march average.
        /// </summary>
        /// <value> The march average. </value>
        [JsonProperty("march")]
        public double March
        {
            get { return Average(_marchTotal); }
            set { _marchTotal = value; }
        }

        /// <summary>
        ///   Gets the april average.
        /// </summary>
        /// <value> The april average. </value>
        [JsonProperty("april")]
        public double April
        {
            get { return Average(_aprilTotal); }
            set { _aprilTotal = value; }
        }

        /// <summary>
        ///   Gets the may average.
        /// </summary>
        /// <value> The may average. </value>
        [JsonProperty("may")]
        public double May
        {
            get { return Average(_mayTotal); }
            set { _mayTotal = value; }
        }

        /// <summary>
        ///   Gets the june average.
        /// </summary>
        /// <value> The june average. </value>
        [JsonProperty("june")]
        public double June
        {
            get { return Average(_juneTotal); }
            set { _juneTotal = value; }
        }

        /// <summary>
        ///   Gets the july average.
        /// </summary>
        /// <value> The july average. </value>
        [JsonProperty("july")]
        public double July
        {
            get { return Average(_julyTotal); }
            set { _julyTotal = value; }
        }

        /// <summary>
        ///   Gets the august average.
        /// </summary>
        /// <value> The august average. </value>
        [JsonProperty("august")]
        public double August
        {
            get { return Average(_augustTotal); }
            set { _augustTotal = value; }
        }

        /// <summary>
        ///   Gets the september average.
        /// </summary>
        /// <value> The september average. </value>
        [JsonProperty("september")]
        public double September
        {
            get { return Average(_septemberTotal); }
            set { _septemberTotal = value; }
        }

        /// <summary>
        ///   Gets the october average.
        /// </summary>
        /// <value> The october average. </value>
        [JsonProperty("october")]
        public double October
        {
            get { return Average(_octoberTotal); }
            set { _octoberTotal = value; }
        }

        /// <summary>
        ///   Gets the november average.
        /// </summary>
        /// <value> The november average. </value>
        [JsonProperty("november")]
        public double November
        {
            get { return Average(_novemberTotal); }

            set { _novemberTotal = value; }
        }

        /// <summary>
        ///   Gets the december average.
        /// </summary>
        /// <value> The december average. </value>
        [JsonProperty("december")]
        public double December
        {
            get { return Average(_decemberTotal); }
            set { _decemberTotal = value; }
        }

        private double Average(double value)
        {
            if (Points == 0)
                return 0;

            return value/Points;
        }
    }
}