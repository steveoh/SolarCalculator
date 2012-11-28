using System;
using SolarCalculator.Infastructure.Commands;
using SolarCalculator.Models.Date;

namespace SolarCalculator.Commands
{
    /// <summary>
    ///   converts teh ersi property syntax to concrete classes
    /// </summary>
    public class CreateEnumsFromPropertyStringsCommand : Command<MonthTypeContainer>
    {
        private readonly string _key;

        /// <summary>
        ///   Initializes a new instance of the <see cref="CreateEnumsFromPropertyStringsCommand" /> class.
        /// </summary>
        /// <param name="key"> The property key. </param>
        public CreateEnumsFromPropertyStringsCommand(string key)
        {
            _key = key;
        }

        /// <summary>
        ///   code to execute when command is run.
        /// </summary>
        /// <exception cref="System.ArgumentException">Custom Properties must have 'month type' format</exception>
        protected override void Execute()
        {
            var parts = _key.Split('.');

            if (parts.Length != 2)
                throw new ArgumentException("Custom Properties must have 'month type' format");

            Result = new MonthTypeContainer(parts[0], parts[1]);
        }

        public override string ToString()
        {
            return string.Format("{0}, Key: {1}", "CreateEnumsFromPropertyStringsCommand", _key);
        }
    }
}