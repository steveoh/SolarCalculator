using System.Collections.Generic;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.SOESupport;
using ESRI.ArcGIS.Server;
using ESRI.ArcGIS.esriSystem;
using SolarCalculator.Commands;
using SolarCalculator.Infastructure;
using SolarCalculator.Models.Esri;

namespace SolarCalculator
{
    /// <summary>
    ///   The main server object extension
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
        Properties =
            "January.Duration=;February.Duration=;March.Duration=;April.Duration=;May.Duration=;June.Duration=;July.Duration=;August.Duration=;September.Duration=;October.Duration=;November.Duration=;December.Duration=;" +
            "January.Radiation=;February.Radiation=;March.Radiation=;April.Radiation=;May.Radiation=;June.Radiation=;July.Radiation=;August.Radiation=;September.Radiation=;October.Radiation=;November.Radiation=;December.Radiation=;" +
            "LayerName=",
        SupportsREST = true,
        SupportsSOAP = false)]
    public class SolarCalculatorSoe : SoeBase, IServerObjectExtension, IObjectConstruct, IRESTRequestHandler
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="SolarCalculatorSoe" /> class. If you have business logic that you want to run when the SOE first becomes enabled, don’t here; instead, use the following IObjectConstruct.Construct() method found in SoeBase.cs
        /// </summary>
        public SolarCalculatorSoe()
        {
            ReqHandler = CommandExecutor.ExecuteCommand(
                new CreateRestImplementationCommand(typeof (FindAllEndpointsCommand).Assembly));
        }

        #region IObjectConstruct Members

        public override void Construct(IPropertySet props)
        {
            base.Construct(props);

            const string properties =
                "January.Duration=DUR1;February.Duration=;March.Duration=;April.Duration=;May.Duration=;June.Duration=;July.Duration=;August.Duration=;September.Duration=;October.Duration=;November.Duration=;December.Duration=;" +
                "January.Radiation=;February.Radiation=;March.Radiation=;April.Radiation=;May.Radiation=;June.Radiation=;July.Radiation=;August.Radiation=;September.Radiation=;October.Radiation=;November.Radiation=;December.Radiation=";
#if DEBUG
            var propertyValueMap = new Dictionary<MonthTypeContainer, string>
                {
                    {new MonthTypeContainer("January", "Duration"), "DUR1"},
                    {new MonthTypeContainer("February", "Duration"), "DUR2"},
                    {new MonthTypeContainer("March", "Duration"), "DUR3"},
                    {new MonthTypeContainer("April", "Duration"), "DUR4"},
                    {new MonthTypeContainer("May", "Duration"), "DUR5"},
                    {new MonthTypeContainer("June", "Duration"), "DUR6"},
                    {new MonthTypeContainer("July", "Duration"), "DUR7"},
                    {new MonthTypeContainer("August", "Duration"), "DUR8"},
                    {new MonthTypeContainer("September", "Duration"), "DUR9"},
                    {new MonthTypeContainer("October", "Duration"), "DUR10"},
                    {new MonthTypeContainer("November", "Duration"), "DUR11"},
                    {new MonthTypeContainer("December", "Duration"), "DUR12"},
                    {new MonthTypeContainer("January", "Radiation"), "SOL1"},
                    {new MonthTypeContainer("February", "Radiation"), "SOL2"},
                    {new MonthTypeContainer("March", "Radiation"), "SOL3"},
                    {new MonthTypeContainer("April", "Radiation"), "SOL4"},
                    {new MonthTypeContainer("May", "Radiation"), "SOL5"},
                    {new MonthTypeContainer("June", "Radiation"), "SOL6"},
                    {new MonthTypeContainer("July", "Radiation"), "SOL7"},
                    {new MonthTypeContainer("August", "Radiation"), "SOL8"},
                    {new MonthTypeContainer("September", "Radiation"), "SOL9"},
                    {new MonthTypeContainer("October", "Radiation"), "SOL10"},
                    {new MonthTypeContainer("November", "Radiation"), "SOL11"},
                    {new MonthTypeContainer("December", "Radiation"), "SOL12"}
                };

            const string layerName = "SolarPoints";
#else
            var propertyValueMap = properties.Replace("=", "").Split(';')
                .ToDictionary(key => CommandExecutor.ExecuteCommand(new CreateEnumsFromPropertyStringsCommand(key)), value => props.GetValueAsString(value));

            const string layerName = props.GetValueAsString("LayerName", true);
#endif

            ApplicationCache.Layer =
                CommandExecutor.ExecuteCommand(new FindLayerByNameCommand(layerName,
                                                                          ServerObjectHelper));

            ApplicationCache.PropertyValueIndexMap =
                CommandExecutor.ExecuteCommand(new FindIndexByFieldNameCommand(ApplicationCache.Layer, propertyValueMap));
        }

        #endregion
    }
}