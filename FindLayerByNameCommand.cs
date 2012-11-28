using System;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.SOESupport;
using ESRI.ArcGIS.Server;
using SolarCalculator.Infastructure;

namespace SolarCalculator
{
    public class FindLayerByNameCommand : Command<IFeatureClass>
    {
        private readonly string _layerName;
        private readonly IServerObjectHelper _serverObjectHelper;

        public FindLayerByNameCommand(string layerName, IServerObjectHelper serverObjectHelper)
        {
            _layerName = layerName;
            _serverObjectHelper = serverObjectHelper;
        }

        protected override void Execute()
        {
                // Get the feature layer to be queried.
                // Since the layer is a property of the SOE, this only has to be done once.
                var mapServer = _serverObjectHelper.ServerObject as IMapServer3;

            if (mapServer == null)
            {
                throw new NullReferenceException("Map service was not found.");
            }

            var mapName = mapServer.DefaultMapName;
            var layerInfos = mapServer.GetServerInfo(mapName).MapLayerInfos;

            // Find the index position of the map layer to query.
            var c = layerInfos.Count;
            var layerIndex = 0;
            for (var i = 0; i < c; i++)
            {
                var layerInfo = layerInfos.Element[i];
                if (layerInfo.Name != _layerName) continue;

                layerIndex = i;
                break;
            }
            // Use IMapServerDataAccess to get the data
            var dataAccess = (IMapServerDataAccess) mapServer;
            // Get access to the source feature class.
            var featureClass = dataAccess.GetDataSource(mapName, layerIndex) as IFeatureClass;

            if (featureClass == null)
            {
                throw new NullReferenceException("FeatureClass cannot be null");
            }

            Result = featureClass;
        }

        public override string ToString()
        {
            return string.Format("{0}, LayerName: {1}", "FindLayerByNameCommand", _layerName);
        }
    }
}