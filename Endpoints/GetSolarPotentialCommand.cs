using System;
using System.Collections.Generic;
using System.Reflection;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using SolarCalculator.DataStructures;
using SolarCalculator.Infastructure;
using SolarCalculator.Models.Enums;
using SolarCalculator.Models.Esri;

namespace SolarCalculator.Endpoints
{
    public class GetSolarPotentialCommand : Command<SolarPotential>
    {
        private readonly double _durationThreshhold;
        private readonly IPolygon4 _polygon;
        private readonly Dictionary<MonthTypeContainer, IndexFieldMap> _propertyValueIndexMap;

        public GetSolarPotentialCommand(IPolygon4 polygon,
                                        Dictionary<MonthTypeContainer, IndexFieldMap> propertyValueIndexMap,
                                        double durationThreshhold)
        {
            _polygon = polygon;
            _propertyValueIndexMap = propertyValueIndexMap;
            _durationThreshhold = durationThreshhold;
        }

        public override string ToString()
        {
            return string.Format("{0}, Duration Threshhold: {1}", "GetSolarPotentialCommand", _durationThreshhold);
        }

        protected override void Execute()
        {
            var spatialFilter = new SpatialFilter
                {
                    Geometry = _polygon,
                    SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects,
                    GeometryField = ApplicationCache.Layer.ShapeFieldName
                };

            var cursor = ApplicationCache.Layer.Search(spatialFilter, true);

            var solarPotential = new SolarPotential();

            IFeature feature;
            while ((feature = cursor.NextFeature()) != null)
            {
                foreach (var item in _propertyValueIndexMap)
                {
                    AddValueToSolarPotential(item, feature, solarPotential);
                }
            }

            Result = solarPotential;
        }

        private void AddValueToSolarPotential(KeyValuePair<MonthTypeContainer, IndexFieldMap> item,
                                              IFeature feature, SolarPotential solarPotential)
        {
            var solarValue = GetValue(item.Value.Index, feature);
            switch (item.Key.SolarType)
            {
                case SolarType.Duration:
                    if (solarValue > _durationThreshhold)
                        AddValueForMonth(solarPotential.Duration, item.Key.Month, solarValue);
                    break;
                case SolarType.Radiation:
                    AddValueForMonth(solarPotential.Radiation, item.Key.Month, solarValue);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static void AddValueForMonth(CalendarMonths instance, CalendarMonth month, int value)
        {
            var instanceType = instance.GetType();
            var property = instanceType.GetProperty(month.ToString(),
                                                    BindingFlags.Public | BindingFlags.Instance);

            var methodInfo = property.PropertyType.GetMethod("Add");

            methodInfo.Invoke(property.GetValue(instance, null), new object[] {value});
        }

        private static int GetValue(int index, IFeature feature)
        {
            return int.Parse(feature.Value[index].ToString());
        }
    }
}