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
using ESRI.ArcGIS.esriSystem;
using SolarCalculator.Commands;
using SolarCalculator.Extensions;
using SolarCalculator.Infastructure;
using SolarCalculator.Infastructure.Commands;
using SolarCalculator.Models.Date;

namespace SolarCalculator.Cache
{
    /// <summary>
    ///   Gets the configuration from management studio
    /// </summary>
    public class UserConfiguration : IConfigurable
    {
        #region IConfigurable Members

        /// <summary>
        ///   Gets the name of the layer.
        /// </summary>
        /// <param name="props"> The props. </param>
        /// <returns> </returns>
        public string GetLayerName(IPropertySet props)
        {
            return props.GetValueAsString("LayerName", true);
        }

        /// <summary>
        ///   Creates the property value map.
        /// </summary>
        /// <param name="props"> The props. </param>
        /// <returns> </returns>
        public Dictionary<MonthTypeContainer, string> CreatePropertyValueMap(IPropertySet props)
        {
            const string properties =
                "January.Duration=;February.Duration=;March.Duration=;April.Duration=;May.Duration=;June.Duration=;July.Duration=;August.Duration=;September.Duration=;October.Duration=;November.Duration=;December.Duration=;" +
                "January.Radiation=;February.Radiation=;March.Radiation=;April.Radiation=;May.Radiation=;June.Radiation=;July.Radiation=;August.Radiation=;September.Radiation=;October.Radiation=;November.Radiation=;December.Radiation=;" +
                "Annual.Duration=";

            return properties.Replace("=", "").Split(';')
                .ToDictionary(key => CommandExecutor.ExecuteCommand(new CreateEnumsFromPropertyStringsCommand(key)),
                              value => props.GetValueAsString(value));
        }

        #endregion
    }
}