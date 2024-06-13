using System.Text.Json;
using FootballData.Data.Models;
using FootballData.ProjectSettings;

namespace FootballData.Api;

public class LocalRepository : IFootballRepository
{
    public async Task<IEnumerable<Match>> GetMatches()
    {
        string reader = await ReadFileAsync("matches.json");
        return JsonSerializer.Deserialize<IEnumerable<Match>>(reader) ?? throw new InvalidOperationException();
    }

    public async Task<IEnumerable<Match>> GetMatchesByCountry(string fifaCode)
    {
        string reader = await ReadFileAsync("matches.json");
        var matches = JsonSerializer.Deserialize<IEnumerable<Match>>(reader) ?? throw new InvalidOperationException();
        return matches.Where(m => m.WinnerFifaCode == fifaCode);
    }

    public async Task<IEnumerable<GroupResult>> GetGroupResults()
    {
        string reader = await ReadFileAsync("group_results.json");
        return JsonSerializer.Deserialize<IEnumerable<GroupResult>>(reader) ?? throw new InvalidOperationException();
    }

    public async Task<IEnumerable<Result>> GetResults()
    {
        string reader = await ReadFileAsync("results.json");
        return JsonSerializer.Deserialize<IEnumerable<Result>>(reader) ?? throw new InvalidOperationException();
    }

    public async Task<IEnumerable<Team>> GetTeams()
    {
        string reader = await ReadFileAsync("teams.json");
        return JsonSerializer.Deserialize<IEnumerable<Team>>(reader) ?? throw new InvalidOperationException();
    }

    private async Task<string> ReadFileAsync(string fileName)
    {
        AppRepo setting = AppRepo.GetSettings();
        string name = setting.Values.DataPath == null
            ? $"{setting.Values.LeagueGender}/{fileName}"
            : $"{setting.Values.DataPath}/{setting.Values.LeagueGender}/{fileName}";
        var streamReader = new StreamReader(name);
        return await streamReader.ReadToEndAsync();
    }
}