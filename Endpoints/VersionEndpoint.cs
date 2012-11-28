using System.Collections.Specialized;
using System.Reflection;

namespace SolarCalculator.Endpoints
{
    /// <summary>
    ///   Displays the information about the soe.
    /// </summary>
    public class VersionEndpoint : JsonEndpoint
    {
        /// <summary>
        ///   Handlers the rest request for when the soe page is viewed.
        /// </summary>
        /// <param name="boundVariables"> The bound variables. </param>
        /// <param name="outputFormat"> The output format. </param>
        /// <param name="requestProperties"> The request properties. </param>
        /// <param name="responseProperties"> The response properties. </param>
        /// <returns> </returns>
        public static byte[] Handler(NameValueCollection boundVariables, string outputFormat, string requestProperties,
                                     out string responseProperties)
        {
            responseProperties = null;

            return Json(new
                {
                    Description = "Solar Potential Calculator",
                    CreatedBy = "AGRC - Steve Gourley @steveAGRC",
                    Version = Assembly.GetExecutingAssembly().GetName().Version.ToString()
                });
        }
    }
}