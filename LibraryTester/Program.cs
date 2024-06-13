using FootballData.Api;
using FootballData.Data;
using FootballData.Data.Enums;
using FootballData.ProjectSettings;

var settings = AppRepo.GetSettings();

settings.Values.Repository = 0;
Console.WriteLine(settings.Values);

IFootballRepository repo = FootballRepositoryFactory.GetRepository(AppRepo.GetSettings().Values.Repository);
var matches = repo.GetMatches();

Console.Write("Waiting for data");
while (!matches.IsCompleted)
{
    Console.Write(".");
    Thread.Sleep(10);
}
try
{
    Console.WriteLine("Data received");

    foreach (var VARIABLE in matches.Result)
    {
        Console.WriteLine(
            $"{VARIABLE.HomeTeamCountry} va {VARIABLE.AwayTeamCountry} in {VARIABLE.Venue} ({VARIABLE.Attendance})");
        foreach (var team in VARIABLE.HomeTeamEvents.Where(e => e.TypeOfEvent == TypeOfEvent.RedCard))
        {
            Console.WriteLine($"\t{team.TypeOfEvent} : {team.Player}");
        }
        foreach (var team in VARIABLE.AwayTeamEvents.Where(e => e.TypeOfEvent == TypeOfEvent.RedCard))
        {
            Console.WriteLine($"\t{team.TypeOfEvent} : {team.Player}");
        }
    }
}
catch (Exception e)
{
    Console.WriteLine(e);
}
finally
{
    var a = await settings.SaveSettingsAsync();
    Console.WriteLine(a);
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