﻿using Newtonsoft.Json;

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