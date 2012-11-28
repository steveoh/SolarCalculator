using System.Collections.Generic;
using ESRI.ArcGIS.Geodatabase;
using SolarCalculator.Models.Date;

namespace SolarCalculator.Models.Esri
{
    /// <summary>
    ///   The global cache for the application
    /// </summary>
    public static class ApplicationCache
    {
        /// <summary>
        ///   The property value index map
        /// </summary>
        public static Dictionary<MonthTypeContainer, IndexFieldMap> PropertyValueIndexMap;

        /// <summary>
        ///   Gets or sets the layer.
        /// </summary>
        /// <value> The solar analysis point layer. </value>
        public static IFeatureClass Layer { get; set; }
    }
}