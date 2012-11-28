using System;
using System.Collections.Generic;
using System.Reflection;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using SolarCalculator.Infastructure.Commands;
using SolarCalculator.Models;
using SolarCalculator.Models.Date;
using SolarCalculator.Models.Enums;
using SolarCalculator.Models.Esri;

namespace SolarCalculator.Commands
{
    /// <summary>
    ///   Command to calculeate the solar potential
    /// </summary>
    public class GetSolarPotentialCommand : Command<SolarPotential>
    {
        private readonly double _durationThreshhold;
        private readonly IPolygon4 _polygon;
        private readonly Dictionary<MonthTypeContainer, IndexFieldMap> _propertyValueIndexMap;

        /// <summary>
        ///   Initializes a new instance of the <see cref="GetSolarPotentialCommand" /> class.
        /// </summary>
        /// <param name="polygon"> The polygon. </param>
        /// <param name="propertyValueIndexMap"> The property value index map. </param>
        /// <param name="durationThreshhold"> The duration threshhold. </param>
        public GetSolarPotentialCommand(IPolygon4 polygon,
                                        Dictionary<MonthTypeContainer, IndexFieldMap> propertyValueIndexMap,
                                        double durationThreshhold)
        {
            _polygon = polygon;
            _propertyValueIndexMap = propertyValueIndexMap;
            _durationThreshhold = durationThreshhold;
        }

        /// <summary>
        ///   code to execute when command is run. Looops over all features and adds their value to the container
        /// </summary>
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

        /// <summary>
        ///   Adds the value to the solar potential container.
        /// </summary>
        /// <param name="item"> The item. </param>
        /// <param name="feature"> The feature. </param>
        /// <param name="solarPotential"> The solar potential. </param>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
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

        /// <summary>
        ///   Adds the value for specified month.
        /// </summary>
        /// <param name="instance"> The instance. </param>
        /// <param name="month"> The month. </param>
        /// <param name="value"> The value. </param>
        private static void AddValueForMonth(AnnualSolarPotential instance, Month month, int value)
        {
            var instanceType = instance.GetType();
            var property = instanceType.GetProperty(month.ToString(),
                                                    BindingFlags.Public | BindingFlags.Instance);

            var methodInfo = property.PropertyType.GetMethod("Add");

            methodInfo.Invoke(property.GetValue(instance, null), new object[] {value});
        }

        /// <summary>
        ///   Gets the value from the feature.
        /// </summary>
        /// <param name="index"> The index. </param>
        /// <param name="feature"> The feature. </param>
        /// <returns> </returns>
        private static int GetValue(int index, IFeature feature)
        {
            return int.Parse(feature.Value[index].ToString());
        }

        public override string ToString()
        {
            return string.Format("{0}, Duration Threshhold: {1}", "GetSolarPotentialCommand", _durationThreshhold);
        }
    }
}