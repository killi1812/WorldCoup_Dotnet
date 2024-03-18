

using FootballData.Api;
using FootballData.Data;
using FootballData.Setting;

var settings = Settings.GetSettings();

// settings["LeagueGender"] = "women";

Console.WriteLine(settings.Values);

IFootballRepository repo = FootballRepositoryFactory.GetRepository(Settings.GetSettings().Values.RepositoryType);
var matches = await repo.getGroupResults();
foreach (var VARIABLE in matches)    
{
    foreach (var team in VARIABLE.OrderedTeams)
    {
        Console.WriteLine(team.Wins);
    }
    Console.WriteLine(VARIABLE.Letter);
}

foreach (var VARIABLE in await repo.getTeams())    
{
    Console.WriteLine(VARIABLE.Country);
}
foreach (var VARIABLE in await repo.getGroupResults())    
{

    Console.WriteLine(VARIABLE.Letter);
}    
foreach (var VARIABLE in await repo.getResults())    
{

    Console.WriteLine(VARIABLE.Points);
}