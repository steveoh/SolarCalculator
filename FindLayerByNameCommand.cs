using System;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Server;
using SolarCalculator.Infastructure.Commands;

namespace SolarCalculator
{
    /// <summary>
    ///   Finds the layer in the soe host mxd
    /// </summary>
    public class FindLayerByNameCommand : Command<IFeatureClass>
    {
        private readonly string _layerName;
        private readonly IServerObjectHelper _serverObjectHelper;

        /// <summary>
        ///   Initializes a new instance of the <see cref="FindLayerByNameCommand" /> class.
        /// </summary>
        /// <param name="layerName"> Name of the layer. </param>
        /// <param name="serverObjectHelper"> The server object helper. </param>
        public FindLayerByNameCommand(string layerName, IServerObjectHelper serverObjectHelper)
        {
            _layerName = layerName;
            _serverObjectHelper = serverObjectHelper;
        }

        /// <summary>
        ///   code to execute when command is run. Searches through the host for the layer.
        /// </summary>
        /// <exception cref="System.NullReferenceException">Map service was not found.</exception>
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

            var c = layerInfos.Count;
            var layerIndex = 0;
            for (var i = 0; i < c; i++)
            {
                var layerInfo = layerInfos.Element[i];
                if (layerInfo.Name != _layerName) continue;

                layerIndex = i;
                break;
            }

            var dataAccess = (IMapServerDataAccess) mapServer;

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