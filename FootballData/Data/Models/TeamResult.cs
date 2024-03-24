using System.Text.Json.Serialization;

namespace FootballData.Data.Models;

public class TeamResult
{
    [JsonPropertyName("country")]
    public string Country { get; set; }

    [JsonPropertyName("code")]
    public string FifaCode { get; set; }

    [JsonPropertyName("goals")]
    public int Goals { get; set; }

    [JsonPropertyName("penalties")]
    public int Penalties { get; set; }
}