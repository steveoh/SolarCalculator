using System;
using System.Collections.Specialized;
using System.Text;
using ESRI.ArcGIS.SOESupport;
using SolarCalculator.Attributes;

namespace SolarCalculator.Endpoints
{
    /// <summary>
    /// A rest endpoint. All endpoints are marked with the [Endpoint] attribute 
    /// and dynamically added to the implmentation at registration time
    /// </summary>
    [Endpoint]
    public class SolarCalculatorRestEndpoint : IRestEndpoint
    {
        /// <summary>
        /// The resource name that displays for Supported Operations
        /// </summary>
        private const string ResourceName = "CalculateFor";

        /// <summary>
        /// Handles the incoming rest requests
        /// </summary>
        /// <param name="boundVariables">The bound variables.</param>
        /// <param name="operationInput">The operation input.</param>
        /// <param name="outputFormat">The output format.</param>
        /// <param name="requestProperties">The request properties.</param>
        /// <param name="responseProperties">The response properties.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        public static byte[] Handler(NameValueCollection boundVariables, JsonObject operationInput,
                                         string outputFormat, string requestProperties, 
                                         out string responseProperties)
        {
            responseProperties = null;

            string geometryJson;
            var found = operationInput.TryGetString("geometry", out geometryJson);
            if (!found || string.IsNullOrEmpty(geometryJson))
                throw new ArgumentNullException(geometryJson);

            string durationThreshold;
            found = operationInput.TryGetString("durationThreshold", out durationThreshold);
            if (!found || string.IsNullOrEmpty(durationThreshold))
                throw new ArgumentNullException(durationThreshold);

            return Encoding.UTF8.GetBytes("");
        }

        /// <summary>
        /// A method that the dynamic endpoint setup uses for registering the rest
        /// endpoing operation details.
        /// </summary>
        /// <returns></returns>
        public RestOperation RestOperation()
        {
            return new RestOperation(ResourceName,
                                                new[] { "geometry", "durationThreshold" },
                                                new[] { "json" },
                                                Handler);
        }
    }
}
