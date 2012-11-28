using System;
using ESRI.ArcGIS.SOESupport;
using SolarCalculator.Infastructure;

namespace SolarCalculator.Commands
{
    public class CreateEnumsFromPropertyStringsCommand : Command<MonthTypeContainer>
    {
        private readonly string _key;

        public CreateEnumsFromPropertyStringsCommand(string key)
        {
            _key = key;
        }

        public override string ToString()
        {
            return string.Format("{0}, Key: {1}", "CreateEnumsFromPropertyStringsCommand", _key);
        }

        protected override void Execute()
        {
            var parts = _key.Split('.');

            if (parts.Length != 2)
                throw new ArgumentException("Custom Properties must have 'month type' format");

            Result = new MonthTypeContainer(parts[0], parts[1]);
        }
    }
}