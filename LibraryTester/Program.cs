

using FootballData.Api;
using FootballData.Data;
using FootballData.Setting;

var settings = Settings.GetSettings();

// settings["LeagueGender"] = "women";

Console.WriteLine(settings.Values);

IFootballRepository repo = new LocalRepository();
var matches = await repo.getGroupResults();
foreach (var VARIABLE in matches)    
{
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