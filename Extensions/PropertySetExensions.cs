using System;
using ESRI.ArcGIS.SOESupport;
using ESRI.ArcGIS.esriSystem;

namespace SolarCalculator.Extensions
{
    public static class PropertySetExensions
    {
        public static string GetValueAsString(this IPropertySet property, string key, bool errorOnNull = false)
        {
            var value = property.GetProperty(key) as string;

            if (string.IsNullOrEmpty(key))
            {
                var msg = "{0} is null or empty. Please add this value to the properties " +
                          "in the SOE capabilies section of the server manager application.".With(key);

                var logger = new ServerLogger();
                logger.LogMessage(ServerLogger.msgType.warning, "GetPropertyValue", 2472,
                                          msg);
                logger = null;

                if (errorOnNull)
                    throw new NullReferenceException(msg);
            }

            return value ?? "";
        }
    }
}