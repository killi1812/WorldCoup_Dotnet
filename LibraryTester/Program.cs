using FootballData.Api;
using FootballData.Data;
using FootballData.ProjectSettings;

var settings = Settings.GetSettings();

settings.Values.Repository = 1;
Console.WriteLine(settings.Values);

IFootballRepository repo = FootballRepositoryFactory.GetRepository(Settings.GetSettings().Values.Repository);
var matches = repo.GetMatches();

Console.Write("Waiting for data");
while (!matches.IsCompleted)
{
    Console.Write(".");
    Thread.Sleep(10);
}
Console.WriteLine("Data received");

foreach (var VARIABLE in matches.Result)
{
    Console.WriteLine(
        $"{VARIABLE.HomeTeamCountry} va {VARIABLE.AwayTeamCountry} in {VARIABLE.Venue} on {VARIABLE.Datetime}");
    foreach (var team in VARIABLE.HomeTeamEvents)
    {
        Console.WriteLine($"\t{team.TypeOfEvent} : {team.Player}");
    }
    foreach (var team in VARIABLE.AwayTeamEvents)
    {
        Console.WriteLine($"\t{team.TypeOfEvent} : {team.Player}");
    }
}

// foreach (var VARIABLE in await repo.GetTeams())
// {
//     Console.WriteLine(VARIABLE.Country);
// }
// foreach (var VARIABLE in await repo.GetGroupResults())
// {
//     Console.WriteLine(VARIABLE.Letter);
// }
// foreach (var VARIABLE in await repo.GetResults())
// {
//     Console.WriteLine(VARIABLE.Points);
// }
// foreach (var VARIABLE in await repo.GetMatchesByCountry("CRO"))
// {
//     Console.WriteLine(VARIABLE.Attendance);
// }