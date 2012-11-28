using System;
using System.Collections.Specialized;
using System.Linq;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.SOESupport;
using SolarCalculator.Attributes;
using SolarCalculator.Commands;
using SolarCalculator.DataStructures;
using SolarCalculator.Extensions;
using SolarCalculator.Infastructure;
using SolarCalculator.Models;
using SolarCalculator.Models.Esri;

namespace SolarCalculator.Endpoints
{
    /// <summary>
    ///   A rest endpoint. All endpoints are marked with the [Endpoint] attribute and dynamically added to the implmentation at registration time
    /// </summary>
    [Endpoint]
    public class SolarCalculatorRestEndpoint : JsonEndpoint, IRestEndpoint
    {
        /// <summary>
        ///   The resource name that displays for Supported Operations
        /// </summary>
        private const string ResourceName = "CalculateFor";

        #region IRestEndpoint Members

        /// <summary>
        ///   A method that the dynamic endpoint setup uses for registering the rest endpoing operation details.
        /// </summary>
        /// <returns> </returns>
        public RestOperation RestOperation()
        {
            return new RestOperation(ResourceName,
                                     new[] {"geometry", "durationThreshold"},
                                     new[] {"json"},
                                     Handler);
        }

        #endregion

        /// <summary>
        ///   Handles the incoming rest requests
        /// </summary>
        /// <param name="boundVariables"> The bound variables. </param>
        /// <param name="operationInput"> The operation input. </param>
        /// <param name="outputFormat"> The output format. </param>
        /// <param name="requestProperties"> The request properties. </param>
        /// <param name="responseProperties"> The response properties. </param>
        /// <returns> </returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        public static byte[] Handler(NameValueCollection boundVariables, JsonObject operationInput,
                                     string outputFormat, string requestProperties,
                                     out string responseProperties)
        {
            responseProperties = null;
            var errors = new ErrorModel(400);

            object[] geometryJson;
            var found = operationInput.TryGetArray("geometry", out geometryJson);
            if (!found || geometryJson.Length < 1)
                errors.Message += "Value cannot be null: {0}. ".With("geometry");

            double? durationThreshold;
            found = operationInput.TryGetAsDouble("durationThreshold", out durationThreshold);
            if (!found || !durationThreshold.HasValue)
                errors.Message += "Value cannot be null: {0} ".With("durationThreshhold");

            if (errors.HasErrors)
                return Json(new ErrorContainer(errors));

            var areaOfInterest = new AreaOfInterest
                {
                    Polygon = geometryJson.Cast<decimal>().ToList()
                };

            IPolygon4 polygon;

            try
            {
                polygon = CommandExecutor.ExecuteCommand(new BuildPolygonFromPointsCommand(areaOfInterest));
            }
            catch (Exception ex)
            {
                errors.Message += ex.Message;
                return Json(new ErrorContainer(errors));
            }

            SolarPotential solarValues = null;
            try
            {
                solarValues =
                    CommandExecutor.ExecuteCommand(new GetSolarPotentialCommand(polygon,
                                                                                ApplicationCache.PropertyValueIndexMap,
                                                                                durationThreshold.GetValueOrDefault(0)));
            }
            catch (Exception ex)
            {
                errors.Message += ex.Message;
            }

            return Json(new SolarContainer(solarValues));
        }
    }
}