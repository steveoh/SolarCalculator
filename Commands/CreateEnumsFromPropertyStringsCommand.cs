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