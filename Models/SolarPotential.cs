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

using Newtonsoft.Json;
using SolarCalculator.Models.Date;

namespace SolarCalculator.Models
{
    /// <summary>
    ///   Container for solar potential
    /// </summary>
    public class SolarPotential
    {
        public SolarPotential()
        {
            Duration = new AnnualSolarPotential();
            Radiation = new AnnualSolarPotential();
        }

        /// <summary>
        ///   Gets or sets the duration.
        /// </summary>
        /// <value> The duration. </value>
        [JsonProperty("duration")]
        public AnnualSolarPotential Duration { get; set; }

        /// <summary>
        ///   Gets or sets the radiation.
        /// </summary>
        /// <value> The radiation. </value>
        [JsonProperty("radiation")]
        public AnnualSolarPotential Radiation { get; set; }

        /// <summary>
        ///   Gets or sets the input area.
        /// </summary>
        /// <value> The square meters of input area. </value>
        [JsonProperty("inputDurationArea")]
        public int InputArea { get; set; }

        /// <summary>
        ///   Gets or sets the area used in calculation.
        /// </summary>
        /// <value> The square meters of solar analysis points used in the calculations. Where the duration amount was greater than the threshold.. </value>
        [JsonProperty("qualifyingDurationArea")]
        public int AreaUsedInCalculation { get; set; }
    }
}