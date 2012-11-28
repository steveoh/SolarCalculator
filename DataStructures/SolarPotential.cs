using System.Collections.ObjectModel;
using System.Linq;
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

    public class CalendarMonths
    {
        public CalendarMonths()
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

        [JsonProperty("january")]
        public double JanAverage
        {
            get { return January.Average(); }
        }

        [JsonProperty("february")]
        public double FebAverage
        {
            get { return February.Average(); }
        }

        [JsonProperty("march")]
        public double MarchAverage
        {
            get { return March.Average(); }
        }

        [JsonProperty("april")]
        public double AprilAverage
        {
            get { return April.Average(); }
        }

        [JsonProperty("may")]
        public double MayAverage
        {
            get { return May.Average(); }
        }

        [JsonProperty("june")]
        public double JuneAverage
        {
            get { return June.Average(); }
        }

        [JsonProperty("july")]
        public double JulyAverage
        {
            get { return July.Average(); }
        }

        [JsonProperty("august")]
        public double AugustAverage
        {
            get { return August.Average(); }
        }

        [JsonProperty("september")]
        public double SeptemberAverage
        {
            get { return September.Average(); }
        }

        [JsonProperty("october")]
        public double OctoberAverage
        {
            get { return October.Average(); }
        }

        [JsonProperty("november")]
        public double NovemberAverage
        {
            get { return November.Average(); }
        }

        [JsonProperty("december")]
        public double DecemberAverage
        {
            get { return December.Average(); }
        }

        [JsonIgnore]
        public Collection<int> January { get; set; }

        [JsonIgnore]
        public Collection<int> February { get; set; }

        [JsonIgnore]
        public Collection<int> March { get; set; }

        [JsonIgnore]
        public Collection<int> April { get; set; }

        [JsonIgnore]
        public Collection<int> May { get; set; }

        [JsonIgnore]
        public Collection<int> June { get; set; }

        [JsonIgnore]
        public Collection<int> July { get; set; }

        [JsonIgnore]
        public Collection<int> August { get; set; }

        [JsonIgnore]
        public Collection<int> September { get; set; }

        [JsonIgnore]
        public Collection<int> October { get; set; }

        [JsonIgnore]
        public Collection<int> November { get; set; }

        [JsonIgnore]
        public Collection<int> December { get; set; }
    }
}