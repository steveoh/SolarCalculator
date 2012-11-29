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
using ESRI.ArcGIS.esriSystem;
using SolarCalculator.Infastructure;
using SolarCalculator.Models.Date;

namespace SolarCalculator.Cache
{
    /// <summary>
    ///   Debug configration. Preconfigured for debug environment
    /// </summary>
    public class DebugConfiguration : IConfigurable
    {
        #region IConfigurable Members

        /// <summary>
        ///   Gets the name of the layer.
        /// </summary>
        /// <param name="props"> The props. </param>
        /// <returns> </returns>
        public string GetLayerName(IPropertySet props)
        {
            return "SolarPoints";
        }

        /// <summary>
        ///   Creates the property value map.
        /// </summary>
        /// <param name="props"> The props. </param>
        /// <returns> </returns>
        public Dictionary<MonthTypeContainer, string> CreatePropertyValueMap(IPropertySet props)
        {
            return new Dictionary<MonthTypeContainer, string>
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
        }

        #endregion
    }
}