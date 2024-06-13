using System.Net;
using System.Net.Http.Json;
using FootballData.Data.Models;
using FootballData.ProjectSettings;

namespace FootballData.Api;

public class CloudRepository : IFootballRepository
{
    private readonly AppRepo _settings = AppRepo.GetSettings();

    public async Task<IEnumerable<Match>> GetMatches()
    {
        using HttpClient client = new();
        var response =
            await client.GetAsync($"https://worldcup-vua.nullbit.hr/{_settings.Values.LeagueGender}/matches");

        if (response.StatusCode == HttpStatusCode.BadRequest)
            throw new HttpRequestException("Invalid league gender");
        
        return await response.Content.ReadFromJsonAsync<IEnumerable<Match>>()
               ?? throw new HttpRequestException();
    }

    public async Task<IEnumerable<Match>> GetMatchesByCountry(string fifaCode)
    {
        using HttpClient client = new();
        var response =
            await client.GetAsync(
                $"https://worldcup-vua.nullbit.hr/{_settings.Values.LeagueGender}/matches/country?fifa_code={fifaCode}");
        if (response.StatusCode == HttpStatusCode.BadRequest)
            throw new HttpRequestException("Invalid league gender");

        if (response.StatusCode == HttpStatusCode.BadRequest)
            throw new HttpRequestException("Invalid country code");

        return await response.Content.ReadFromJsonAsync<IEnumerable<Match>>()
               ?? throw new HttpRequestException();
    }

    public async Task<IEnumerable<GroupResult>> GetGroupResults()
    {
        using HttpClient client = new();
        var response =
            await client.GetAsync(
                $"https://worldcup-vua.nullbit.hr/{_settings.Values.LeagueGender}/teams/group_results");

        if (response.StatusCode == HttpStatusCode.BadRequest)
            throw new HttpRequestException("Invalid league gender");

        
        return await response.Content.ReadFromJsonAsync<IEnumerable<GroupResult>>()
               ?? throw new HttpRequestException();
    }


    public async Task<IEnumerable<Result>> GetResults()
    {
        using HttpClient client = new();
        var response =
            await client.GetAsync($"https://worldcup-vua.nullbit.hr/{_settings.Values.LeagueGender}/teams/results");

        if (response.StatusCode == HttpStatusCode.BadRequest)
            throw new HttpRequestException("Invalid league gender");

        
        return await response.Content.ReadFromJsonAsync<IEnumerable<Result>>() ?? throw new HttpRequestException();
    }

    public async Task<IEnumerable<Team>> GetTeams()
    {
        using HttpClient client = new();
        var response = await client.GetAsync($"https://worldcup-vua.nullbit.hr/{_settings.Values.LeagueGender}/teams");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            throw new HttpRequestException("Invalid league gender");

        
        return await response.Content.ReadFromJsonAsync<IEnumerable<Team>>() ?? throw new HttpRequestException();
    }
}