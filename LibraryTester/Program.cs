

using FootballData.Setting;

var settings = Settings.GetSettings();

Console.WriteLine(settings.Values);

Console.WriteLine(settings["LeagueGender"]);