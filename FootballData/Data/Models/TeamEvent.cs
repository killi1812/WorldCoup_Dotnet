using System.Text.Json.Serialization;
using FootballData.Data.Enums;

namespace FootballData.Data.Models;

public class TeamEvent
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("type_of_event")]
    [JsonConverter(typeof(TypeOfEventConverter))]
    public TypeOfEvent TypeOfEvent { get; set; }

    [JsonPropertyName("player")]
    public string Player { get; set; }

    [JsonPropertyName("time")]
    public string Time { get; set; }
}