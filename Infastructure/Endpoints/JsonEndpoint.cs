using System.Text;
using Newtonsoft.Json;

namespace SolarCalculator.Infastructure.Endpoints
{
    /// <summary>
    ///   A class that allows for json responses
    /// </summary>
    public abstract class JsonEndpoint
    {
        /// <summary>
        ///   Simplified method for returning esri json
        /// </summary>
        /// <param name="response"> The response parsed to json by json.net and converted to a byte array. </param>
        /// <returns> </returns>
        internal static byte[] Json(object response)
        {
            return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(response));
        }
    }
}