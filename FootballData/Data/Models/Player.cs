using System.Text.Json.Serialization;
using FootballData.Data.Enums;

namespace FootballData.Data.Models;

public class Player
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("captain")]
    public bool Captain { get; set; }

    [JsonPropertyName("shirt_number")]
    public int ShirtNumber { get; set; }

    [JsonPropertyName("position")]
    public Position Position { get; set; }
}