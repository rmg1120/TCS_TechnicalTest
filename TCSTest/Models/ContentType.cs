using System.Text.Json.Serialization;

namespace TCSTest.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ContentType
    {
        Movie,
        Show
    }
}
