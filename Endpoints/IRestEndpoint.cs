using ESRI.ArcGIS.SOESupport;

namespace SolarCalculator.Endpoints
{
    /// <summary>
    /// Interface that defines a Rest endpoint
    /// </summary>
    public interface IRestEndpoint
    {
        /// <summary>
        /// Returns the rest operation with all the details
        /// about the rest operation.
        /// </summary>
        /// <returns></returns>
        RestOperation RestOperation();
    }
}