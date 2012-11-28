using System.Text;
using ESRI.ArcGIS.SOESupport;
using Newtonsoft.Json;

namespace SolarCalculator.Endpoints
{
    public abstract class JsonEndpoint
    {
        internal static byte[] Json(object response)
        {
            return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(response));
        }
    }
}