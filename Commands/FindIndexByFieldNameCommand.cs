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