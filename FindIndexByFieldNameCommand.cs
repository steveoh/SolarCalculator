using System.Collections.Generic;
using ESRI.ArcGIS.Geodatabase;
using SolarCalculator.Infastructure;

namespace SolarCalculator
{
    public class FindIndexByFieldNameCommand : Command<Dictionary<MonthTypeContainer, IndexFieldMap>>
    {
        private readonly Dictionary<MonthTypeContainer, string> _properyValueMap;
        private readonly IFields _fields;
        private readonly Dictionary<MonthTypeContainer,IndexFieldMap> _propertyValueIndexMap; 

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

        protected override void Execute()
        {
            foreach(var item in _properyValueMap)
            {
                _propertyValueIndexMap.Add(item.Key, new IndexFieldMap(GetIndexForField(item.Value, _fields), item.Value));
            }

            Result = _propertyValueIndexMap;
        }

        private static int GetIndexForField(string x, IFields fields)
        {
            var findField = fields.FindField(x.Trim());
            
            return findField < 0 ? fields.FindFieldByAliasName(x.Trim()) : findField;
        }
    }
}