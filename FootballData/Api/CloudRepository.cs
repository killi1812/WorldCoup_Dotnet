using System.Net.Http.Json;
using FootballData.Data.Models;
using FootballData.ProjectSettings;

namespace FootballData.Api;

public class CloudRepository : IFootballRepository
{
    Settings _settings = Settings.GetSettings();

    public async Task<IEnumerable<Match>> GetMatches()
    {
        using HttpClient client = new();
        var response =
            await client.GetAsync($"https://worldcup-vua.nullbit.hr/{_settings.Values.LeagueGender}/matches");
        return await response.Content.ReadFromJsonAsync<IEnumerable<Match>>()
               ?? throw new HttpRequestException();
    }

    public async Task<IEnumerable<Match>> GetMatchesByCountry(string fifaCode)
    {
        using HttpClient client = new();
        var response =
            await client.GetAsync(
                $"https://worldcup-vua.nullbit.hr/{_settings.Values.LeagueGender}/matches/fifa_code={fifaCode}");
        return await response.Content.ReadFromJsonAsync<IEnumerable<Match>>()
               ?? throw new HttpRequestException();
    }

    public async Task<IEnumerable<GroupResult>> GetGroupResults()
    {
        using HttpClient client = new();
        var response =
            await client.GetAsync(
                $"https://worldcup-vua.nullbit.hr/{_settings.Values.LeagueGender}/teams/group_results");
        return await response.Content.ReadFromJsonAsync<IEnumerable<GroupResult>>()
               ?? throw new HttpRequestException();
    }


    public async Task<IEnumerable<Result>> GetResults()
    {
        using HttpClient client = new();
        var response =
            await client.GetAsync($"https://worldcup-vua.nullbit.hr/{_settings.Values.LeagueGender}/teams/results");
        return await response.Content.ReadFromJsonAsync<IEnumerable<Result>>() ?? throw new HttpRequestException();
    }

    public async Task<IEnumerable<Team>> GetTeams()
    {
        using HttpClient client = new();
        var response = await client.GetAsync($"https://worldcup-vua.nullbit.hr/{_settings.Values.LeagueGender}/teams");
        return await response.Content.ReadFromJsonAsync<IEnumerable<Team>>() ?? throw new HttpRequestException();
    }
}