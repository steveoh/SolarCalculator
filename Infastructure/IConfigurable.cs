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
using SolarCalculator.Models.Date;

namespace SolarCalculator.Infastructure
{
    /// <summary>
    ///   Interface for getting field names and other configurable stuff
    /// </summary>
    public interface IConfigurable
    {
        /// <summary>
        ///   Gets the name of the layer.
        /// </summary>
        /// <param name="props"> The props. </param>
        /// <returns> </returns>
        string GetLayerName(IPropertySet props);

        /// <summary>
        ///   Creates the property value map.
        /// </summary>
        /// <param name="props"> The props. </param>
        /// <returns> </returns>
        Dictionary<MonthTypeContainer, string> CreatePropertyValueMap(IPropertySet props);
    }
}