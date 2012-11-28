using System.Collections.Generic;

namespace SolarCalculator.Models.Geometry
{
    /// <summary>
    ///   A model of the input points drawn on the map
    /// </summary>
    public class AreaOfInterest
    {
        /// <summary>
        ///   Gets or sets the point collection.
        /// </summary>
        /// <value> The point collection representing a polygon. </value>
        public List<decimal> PointCollection { get; set; }

        public override string ToString()
        {
            return string.Join(", ", PointCollection);
        }
    }
}