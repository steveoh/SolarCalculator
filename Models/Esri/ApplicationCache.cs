using System.Collections.Generic;
using ESRI.ArcGIS.Geodatabase;

namespace SolarCalculator.Models.Esri
{
    /// <summary The cached objects for the services
    /// </summary>
    public static class ApplicationCache
    {
        public static Dictionary<MonthTypeContainer, IndexFieldMap> PropertyValueIndexMap;
        public static IFeatureClass Layer { get; set; }
    }
}