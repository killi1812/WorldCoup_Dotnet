using System.Text.Json.Serialization;

namespace FootballData.Models;

public class TeamResult
{
    [JsonPropertyName("country")] public string Country { get; set; }

    [JsonPropertyName("code")] public string Code { get; set; }

    [JsonPropertyName("goals")] public long Goals { get; set; }

    [JsonPropertyName("penalties")] public long Penalties { get; set; }
}