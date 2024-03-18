using System.Text.Json;
using FootballData.Data;
using FootballData.Data.Models;
using FootballData.Setting;

namespace FootballData.Api;

public class LocalRepository : IFootballRepository
{
    public async Task<IEnumerable<Match>> getMatches()
    {
        string reader = await ReadFileAsync("matches.json");
        return JsonSerializer.Deserialize<List<Match>>(reader) ?? throw new InvalidOperationException();
    }

    public async Task<IEnumerable<GroupResult>> getGroupResults()
    {
        string reader = await ReadFileAsync("group_results.json");
        return JsonSerializer.Deserialize<List<GroupResult>>(reader) ?? throw new InvalidOperationException();
    }

    public async Task<IEnumerable<Result>> getResults()
    {
        string reader = await ReadFileAsync("results.json");
        return JsonSerializer.Deserialize<List<Result>>(reader) ?? throw new InvalidOperationException();
    }

    public async Task<IEnumerable<Team>> getTeams()
    {
        string reader = await ReadFileAsync("teams.json");
        return JsonSerializer.Deserialize<List<Team>>(reader) ?? throw new InvalidOperationException();
    }

    private async Task<string> ReadFileAsync(string fileName)
    {
        Settings setting = Settings.GetSettings();
        string name = setting.Values.DataPath == null
            ? $"{setting.Values.LeagueGender}/{fileName}"
            : $"{setting.Values.DataPath}/{setting.Values.LeagueGender}/{fileName}";
        var streamReader = new StreamReader(name);
        return await streamReader.ReadToEndAsync();
    }
}