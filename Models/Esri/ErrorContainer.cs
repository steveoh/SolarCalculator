using Newtonsoft.Json;

namespace SolarCalculator.Models.Esri
{
    public class ErrorContainer
    {
        public ErrorContainer(ErrorModel error)
        {
            Error = error;
        }

        [JsonProperty("error")]
        public ErrorModel Error { get; set; }
    }
}