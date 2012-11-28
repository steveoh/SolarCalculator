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

namespace SolarCalculator.Models.Esri
{
    /// <summary>
    ///   The concrete class for json serialization of error responses
    /// </summary>
    public class ErrorModel
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="ErrorModel" /> class.
        /// </summary>
        /// <param name="code"> The http status code. </param>
        /// <param name="message"> The error message. </param>
        public ErrorModel(int code, string message)
        {
            Code = code;
            Message = message;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ErrorModel" /> class.
        /// </summary>
        /// <param name="code"> The http status code. </param>
        public ErrorModel(int code) : this(code, "")
        {
        }

        /// <summary>
        ///   Gets or sets the code.
        /// </summary>
        /// <value> The http status code. </value>
        [JsonProperty("code")]
        public int Code { get; set; }

        /// <summary>
        ///   Gets or sets the message.
        /// </summary>
        /// <value> The error message to display to the user. </value>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        ///   Gets a value indicating whether this instance has errors.
        /// </summary>
        /// <value> <c>true</c> if this instance has errors; otherwise, <c>false</c> . </value>
        [JsonIgnore]
        public bool HasErrors
        {
            get { return !string.IsNullOrEmpty(Message); }
        }
    }
}