using System.Text.Json.Serialization;

namespace backend.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ClotheType
    {
        Mask = 4,
        Top = 0,
        Pants = 1,
        Gloves = 2,
        Shoes = 3
    }
}
