namespace FootballData.Models

{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class GroupResult
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("letter")]
        public string Letter { get; set; }

        [JsonPropertyName("ordered_teams")]
        public List<Team> OrderedTeams { get; set; }
    }
}
