using System.Text.Json.Serialization;

namespace FootballData.Models;

public class TeamGroupStage
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("country")]
    public string Country { get; set; }

    [JsonPropertyName("alternate_name")]
    public object AlternateName { get; set; }

    [JsonPropertyName("fifa_code")]
    public string FifaCode { get; set; }

    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }

    [JsonPropertyName("group_letter")]
    public string GroupLetter { get; set; }

    [JsonPropertyName("wins")]
    public long Wins { get; set; }

    [JsonPropertyName("draws")]
    public long Draws { get; set; }

    [JsonPropertyName("losses")]
    public long Losses { get; set; }

    [JsonPropertyName("games_played")]
    public long GamesPlayed { get; set; }

    [JsonPropertyName("points")]
    public long Points { get; set; }

    [JsonPropertyName("goals_for")]
    public long GoalsFor { get; set; }

    [JsonPropertyName("goals_against")]
    public long GoalsAgainst { get; set; }

    [JsonPropertyName("goal_differential")]
    public long GoalDifferential { get; set; }
}