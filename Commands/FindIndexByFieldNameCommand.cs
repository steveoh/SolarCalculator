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
using ESRI.ArcGIS.Geodatabase;
using SolarCalculator.Infastructure.Commands;
using SolarCalculator.Models.Date;

namespace SolarCalculator.Commands
{
    /// <summary>
    ///   Command to find the index for each attribute name for all month/types
    /// </summary>
    public class FindIndexByFieldNameCommand : Command<Dictionary<MonthTypeContainer, IndexFieldMap>>
    {
        private readonly IFields _fields;
        private readonly Dictionary<MonthTypeContainer, IndexFieldMap> _propertyValueIndexMap;
        private readonly Dictionary<MonthTypeContainer, string> _properyValueMap;

        /// <summary>
        ///   Initializes a new instance of the <see cref="FindIndexByFieldNameCommand" /> class.
        /// </summary>
        /// <param name="layer"> The layer. </param>
        /// <param name="properyValueMap"> The propery value map. </param>
        public FindIndexByFieldNameCommand(IFeatureClass layer, Dictionary<MonthTypeContainer, string> properyValueMap)
        {
            _properyValueMap = properyValueMap;
            _fields = layer.Fields;
            _propertyValueIndexMap = new Dictionary<MonthTypeContainer, IndexFieldMap>();
        }

        public override string ToString()
        {
            return string.Format("{0}", "FindIndexByFieldNameCommand");
        }

        /// <summary>
        ///   code to execute when command is run. Iterates over every month and finds the index for the field in teh feature class
        /// </summary>
        protected override void Execute()
        {
            foreach (var item in _properyValueMap)
            {
                _propertyValueIndexMap.Add(item.Key,
                                           new IndexFieldMap(GetIndexForField(item.Value, _fields), item.Value));
            }

            Result = _propertyValueIndexMap;
        }

        /// <summary>
        ///   Gets the index for field.
        /// </summary>
        /// <param name="attributeName"> The attribute name. </param>
        /// <param name="fields"> The fields. </param>
        /// <returns> </returns>
        private static int GetIndexForField(string attributeName, IFields fields)
        {
            var findField = fields.FindField(attributeName.Trim());

            return findField < 0 ? fields.FindFieldByAliasName(attributeName.Trim()) : findField;
        }
    }
}