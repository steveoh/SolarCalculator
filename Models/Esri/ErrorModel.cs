using Newtonsoft.Json;

namespace SolarCalculator.Models.Esri
{
    public class ErrorModel
    {
        public ErrorModel(int code, string message)
        {
            Code = code;
            Message = message;
        }

        public ErrorModel(int code) : this(code, "")
        {
        }

        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonIgnore]
        public bool HasErrors
        {
            get { return !string.IsNullOrEmpty(Message); }
        }
    }
}