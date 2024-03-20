using FootballData.Api;
using FootballData.Data;
using FootballData.ProjectSettings;

var settings = Settings.GetSettings();

// settings["LeagueGender"] = "women";
settings.Values.Repository = 1;
Console.WriteLine(settings.Values);

IFootballRepository repo = FootballRepositoryFactory.GetRepository(Settings.GetSettings().Values.Repository);
 var matches = await repo.GetMatches();
// foreach (var VARIABLE in matches)
// {
//     foreach (var team in VARIABLE.OrderedTeams)
//     {
//         Console.WriteLine(team.Wins);
//     }
//     Console.WriteLine(VARIABLE.Letter);
// }
//
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