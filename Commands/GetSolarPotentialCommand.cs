using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using SolarCalculator.Extensions;
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
                solarPotential.InputArea++;
                solarPotential.Radiation.Points++;

                var annualDuration = GetValue(_propertyValueIndexMap
                                                  .SingleOrDefault(x => x.Key.Month == Month.Annual).Value.Index,
                                              feature);

                if (annualDuration > _durationThreshhold)
                {
                    solarPotential.AreaUsedInCalculation++;
                    solarPotential.Duration.Points++;

                    foreach (var item in _propertyValueIndexMap.Where(x => x.Key.Month != Month.Annual))
                    {
                        AddValueToSolarPotential(item, feature, solarPotential);
                    }

                    continue;
                }

                foreach (var item in _propertyValueIndexMap
                    .Where(x => x.Key.Month != Month.Annual && x.Key.SolarType == SolarType.Radiation))
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
        private void AddValueToSolarPotential(KeyValuePair<MonthTypeContainer, IndexFieldMap> item, IFeature feature,
                                              SolarPotential solarPotential)
        {
            var solarValue = GetValue(item.Value.Index, feature);
            switch (item.Key.SolarType)
            {
                case SolarType.Duration:
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
            var field = instanceType.GetField("_{0}Total".With(month.ToString().ToLower()),
                                              BindingFlags.NonPublic | BindingFlags.Instance);

            if(field == null)
                throw new ArgumentException("field is null {0}".With(month.ToString()));
            
            int currentValue;
            if (!int.TryParse(field.GetValue(instance).ToString(), out currentValue))
                throw new ArgumentException("Total value for {0} {1} would not parse to int.".With(field.Name,
                                                                                                   month.ToString()));

            field.SetValue(instance, currentValue + value);
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