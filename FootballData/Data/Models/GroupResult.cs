namespace FootballData.Data.Models

{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class GroupResult
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("letter")]
        public string Letter { get; set; }

        [JsonPropertyName("ordered_teams")]
        public List<TeamGroupStage> OrderedTeams { get; set; }
    }
}
