using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ESRI.ArcGIS.Geometry;
using SolarCalculator.Extensions;
using SolarCalculator.Infastructure;
using SolarCalculator.Models;

namespace SolarCalculator.Commands
{
    /// <summary>
    ///   Builds a polygon from a point array
    /// </summary>
    public class BuildPolygonFromPointsCommand : Command<IPolygon4>
    {
        private readonly AreaOfInterest _geometryJson;
        private readonly IPointCollection4 _points = new PolygonClass();

        /// <summary>
        ///   Initializes a new instance of the <see cref="BuildPolygonFromPointsCommand" /> class.
        /// </summary>
        /// <param name="geometryJson"> The geometry json. </param>
        /// <exception cref="System.ArgumentException">No coordinate pairs in area of interest polygon</exception>
        public BuildPolygonFromPointsCommand(AreaOfInterest geometryJson)
        {
            _geometryJson = geometryJson;
            if (_geometryJson.Polygon.Count < 1)
            {
                throw new ArgumentException("No coordinate pairs in area of interest polygon");
            }

            if (_geometryJson.Polygon.Count%2 != 0)
            {
                throw new ArgumentException("Coordinate pairs do not match. Must be even number.");
            }
        }

        /// <summary>
        ///   code to execute when command is run. Loops over array and adds points to a point collection
        /// </summary>
        /// <exception cref="System.NullReferenceException">Topological Operator cannot be null. Invalid geometry</exception>
        protected override void Execute()
        {
            var successes = _geometryJson.Polygon.Batch(2, AddPointToPolygon);
            if (successes.Any(x => x == false))
                throw new Exception("Error converting coordinates to points.");

            var topologicalOperator = _points as ITopologicalOperator4;

            if (topologicalOperator == null)
            {
                throw new NullReferenceException("Topological Operator cannot be null. Invalid geometry");
            }

            topologicalOperator.Simplify();

            var polygon = _points as IPolygon4;

            var factory = new SpatialReferenceEnvironmentClass();

            if (polygon == null)
                throw new NullReferenceException("Polygon cannot be null. Invalid geometry");

            polygon.SpatialReference = factory.CreateProjectedCoordinateSystem(26912);

            Result = polygon;
        }

        /// <summary>
        ///   Adds the point to polygon point collection.
        /// </summary>
        /// <param name="coordinatePairs"> The coordinate pairs. </param>
        /// <returns> </returns>
        private bool AddPointToPolygon(IEnumerable<decimal> coordinatePairs)
        {
            coordinatePairs = coordinatePairs.ToList();

            double x,y;

            if(!double.TryParse(coordinatePairs.FirstOrDefault().ToString(CultureInfo.InvariantCulture), out x))
                throw new ArgumentException("x coordinate cannot be cast to a double {0}".With(coordinatePairs.FirstOrDefault()));

            if(!double.TryParse(coordinatePairs.LastOrDefault().ToString(CultureInfo.InvariantCulture), out y))
                throw new ArgumentException("x coordinate cannot be cast to a double {0}".With(coordinatePairs.FirstOrDefault()));

            _points.AddPoint(new PointClass
                {
                    X = x,
                    Y = y
                });

            return true;
        }

        public override string ToString()
        {
            return string.Format("{0}, GeometryJson: {1}", "BuildPolygonFromPointsCommand", _geometryJson);
        }
    }
}