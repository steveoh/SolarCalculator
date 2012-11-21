using System.Runtime.InteropServices;
using ESRI.ArcGIS.SOESupport;
using ESRI.ArcGIS.Server;
using ESRI.ArcGIS.esriSystem;
using SolarCalculator.Commands;
using SolarCalculator.Infastructure;

namespace SolarCalculator
{
    /// <summary>
    /// The main server object extension
    /// </summary>
    [ComVisible(true)]
    [Guid("a48951e3-a7a8-4d30-8331-a43ad0122a3c")]
    [ClassInterface(ClassInterfaceType.None)]
    [ServerObjectExtension("MapServer",
        AllCapabilities = "",
        //These create checkboxes to determine allowed functionality
        DefaultCapabilities = "",
        Description = "Query and aggregate solar potential for a given area.",
        //shows up in manager under capabilities
        DisplayName = "Solar Potential",
        //Properties that can be set on the capabilities tab in manager.
        Properties = "JanuaryDuration=;FebruaryDuration=;LayerName=SolarPoints",
        SupportsREST = true,
        SupportsSOAP = false)]
    public class SolarCalculatorSoe : SoeBase, IServerObjectExtension, IObjectConstruct, IRESTRequestHandler
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SolarCalculatorSoe" /> class.
        /// If you have business logic that you want to run when the SOE first becomes enabled, don’t
        /// here; instead, use the following IObjectConstruct.Construct() method found in SoeBase.cs
        /// </summary>
        public SolarCalculatorSoe()
        {
            ReqHandler = CommandExecutor.ExecuteCommand(
                new CreateRestImplementationCommand(typeof(FindAllEndpointsCommand).Assembly));
        }
    }
}