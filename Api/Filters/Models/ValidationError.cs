using Newtonsoft.Json;

namespace BishopTakeshi.Api.Filters.Models
{
    public class ValidationError
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Field { get; }
        public string Message { get; }

        public ValidationError(string field, string message)
        {
            Field = string.IsNullOrWhiteSpace(field) ? null : field;
            Message = string.IsNullOrWhiteSpace(message) ? null : message;
        }
    }
}
