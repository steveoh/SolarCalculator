using ESRI.ArcGIS.SOESupport;
using ESRI.ArcGIS.Server;
using ESRI.ArcGIS.esriSystem;

namespace SolarCalculator
{
    /// <summary>
    ///   Base class cruft for a server object extension
    /// </summary>
    public abstract class SoeBase
    {
        public IPropertySet ConfigProps;
        public IRESTRequestHandler ReqHandler;
        public IServerObjectHelper ServerObjectHelper;

        /// <summary>
        ///   Gets the schema.
        /// </summary>
        /// <returns> </returns>
        public string GetSchema()
        {
            return ReqHandler.GetSchema();
        }

        /// <summary>
        ///  This is where you put any expensive business logic that you don’t need to run on each request.
        ///  For example, if you know you’re always working with the same layer in the map, you can put the
        ///  code to get the layer here.
        /// </summary>
        /// <param name="props"> The props. </param>
        public virtual void Construct(IPropertySet props)
        {
            ConfigProps = props;
        }

        /// <summary>
        ///   stops the server object specified by the IServerObjectHelper reference.
        ///   Cleans up after itself before shutting down its parent mapservice etc.
        /// </summary>
        public virtual void Shutdown()
        {
            ServerObjectHelper = null;
        }

        /// <summary>
        /// Initializes and starts the server object specified by the IServerObjectHelper reference.
        /// If you have business logic that you want to run when the SOE first becomes enabled, don’t
        ///  put it in Init() or in your SOE class’s constructor; instead, use the following 
        /// IObjectConstruct.Construct() method
        /// </summary>
        /// <param name="serverObjectHelper"> The server object helper. </param>
        public virtual void Init(IServerObjectHelper serverObjectHelper)
        {
            ServerObjectHelper = serverObjectHelper;
        }

        /// <summary>
        /// Allows for REST requests and responses to come into the service. These methods create the schema 
        /// and handle the requests.
        /// </summary>
        /// <param name="capabilities">The capabilities.</param>
        /// <param name="resourceName">Name of the resource.</param>
        /// <param name="operationName">Name of the operation.</param>
        /// <param name="operationInput">The operation input.</param>
        /// <param name="outputFormat">The output format.</param>
        /// <param name="requestProperties">The request properties.</param>
        /// <param name="responseProperties">The response properties.</param>
        /// <returns>json as a byte array</returns>
        // ReSharper disable InconsistentNaming
        public byte[] HandleRESTRequest(string capabilities, string resourceName, string operationName,
                                        // ReSharper restore InconsistentNaming
                                        string operationInput, string outputFormat, string requestProperties,
                                        out string responseProperties)
        {
            return ReqHandler.HandleRESTRequest(capabilities, resourceName, operationName, operationInput, outputFormat,
                                                requestProperties, out responseProperties);
        }
    }
}