using Newtonsoft.Json;

namespace SolarCalculator.Models.Esri
{
    /// <summary>
    ///   The class for json serialization of errors
    /// </summary>
    public class ErrorContainer
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="ErrorContainer" /> class.
        /// </summary>
        /// <param name="error"> The error. </param>
        public ErrorContainer(ErrorModel error)
        {
            Error = error;
        }

        /// <summary>
        ///   Gets or sets the error.
        /// </summary>
        /// <value> The error. </value>
        [JsonProperty("error")]
        public ErrorModel Error { get; set; }
    }
}