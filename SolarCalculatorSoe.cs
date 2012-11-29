#region License

// 
// Copyright (C) 2012 AGRC
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software 
// and associated documentation files (the "Software"), to deal in the Software without restriction, 
// including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, 
// and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, 
// subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or substantial 
// portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT
// NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
// SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// 

#endregion

using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.SOESupport;
using ESRI.ArcGIS.Server;
using ESRI.ArcGIS.esriSystem;
using SolarCalculator.Commands;
using SolarCalculator.Extensions;
using SolarCalculator.Infastructure.Commands;
using SolarCalculator.Models.Date;
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
            "LayerName=;Annual.Duration=",
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

        /// <summary>
        ///   This is where you put any expensive business logic that you don’t need to run on each request. For example, if you know you’re always working with the same layer in the map, you can put the code to get the layer here.
        /// </summary>
        /// <param name="props"> The props. </param>
        public override void Construct(IPropertySet props)
        {
            base.Construct(props);

            const string properties =
                "January.Duration=;February.Duration=;March.Duration=;April.Duration=;May.Duration=;June.Duration=;July.Duration=;August.Duration=;September.Duration=;October.Duration=;November.Duration=;December.Duration=;" +
                "January.Radiation=;February.Radiation=;March.Radiation=;April.Radiation=;May.Radiation=;June.Radiation=;July.Radiation=;August.Radiation=;September.Radiation=;October.Radiation=;November.Radiation=;December.Radiation=;" +
                "Annual.Duration=";
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
                    {new MonthTypeContainer("December", "Radiation"), "SOL12"},
                    {new MonthTypeContainer("Annual", "Duration"), "DURANN"}
                };

            const string layerName = "SolarPoints";
#else
            var propertyValueMap = properties.Replace("=", "").Split(';')
                .ToDictionary(key => CommandExecutor.ExecuteCommand(new CreateEnumsFromPropertyStringsCommand(key)), value => props.GetValueAsString(value));

            var layerName = props.GetValueAsString("LayerName", true);
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