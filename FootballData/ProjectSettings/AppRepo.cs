using FootballData.Data.Models;
using System.Text;

namespace FootballData.ProjectSettings
{
    public class Settings
    {
        public string ConfigPath { get; set; }

        public string DataPath { get; set; }

        public string Language { get; set; }

        public string LeagueGender { get; set; }

        public List<string> FavoritePlayers { get; set; }

        public int Repository { get; set; }
        public (int, int) Rezolucija { get; set; }

        public string FavoritTimeFifaCode { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new();

            foreach (var prop in GetType().GetProperties())
            {
                //TODO add suport for lists 
                sb.AppendLine($"{prop.Name} = {prop.GetValue(this)}");
            }
            return sb.ToString();
        }
    }

    public class AppRepo
    {
        public Settings Values { get; private set; }
        public bool IsNew { get; private set; } = false;

        private AppRepo()
        {
            Values = ParseSettings(ReadSettings());
        }

        static private readonly object _oLock = new();
        static private AppRepo? _settingsRepo = null;

        public static AppRepo GetSettings()
        {
            lock (_oLock)
            {
                _settingsRepo ??= new AppRepo();
                return _settingsRepo;
            }
        }

        private const string _fileName = "worldCup.conf";
        private readonly string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WorldCupApp_FranCvok");
        //TODO rewrite to use json this method is to Stupide 
        private string? ReadSettings()
        {
            var filename = FileName();
            if (!File.Exists(filename))
            {
                Directory.CreateDirectory(path);
                IsNew = true;
                return null;
            }
            using StreamReader reader = new(filename);
            return reader.ReadToEnd();
        }

        static private Settings ParseSettings(string? content)
        {
            if (content == null)
                return new Settings
                {
                    ConfigPath = "./",
                    DataPath = "RiderProjects/OOP_dotnet_praktikum_Fran_Cvok/worldcup.sfg.io",
                    Language = "en",
                    LeagueGender = "men",
                    Repository = 1,
                };
            string[] lines = content.Split('\n');
            Settings settingsValues = new();
            Dictionary<string, string> settingsDict = new();

            foreach (string line in lines)
            {
                if (settingsDict.ContainsKey(line)) continue;
                string[] s = line.Split('=');
                if (s.Length != 2) continue;
                settingsDict.Add(s[0].Trim(), s[1].Trim());
            }

            foreach (var prop in settingsValues.GetType().GetProperties())
            {
                if (!settingsDict.ContainsKey(prop.Name)) continue;

                switch (prop.PropertyType.Name)
                {
                    case "Int32":
                        prop.SetValue(settingsValues, int.Parse(settingsDict[prop.Name]));
                        break;
                    case "String":
                        prop.SetValue(settingsValues, settingsDict[prop.Name]);
                        break;
                    case "List`1":
                        var a = 5;
                        break;
                    default:
                        var b = 5;
                        break;
                }
            }
            return settingsValues;
        }

        public async Task<bool> SaveSettingsAsync()
        {
            try
            {
                await using StreamWriter writer = new(FileName());
                await writer.WriteAsync(Values.ToString());
            }
            catch
            {
                return false;
            }
            return true;
        }

        private string FileName()
        {
            if (path == null) return _fileName;
            if (path.Last() != '/')
                return Path.Combine(path, _fileName);
            return $"{path}{_fileName}";
        }

        public static void SaveImage(string img_path, string playerName)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WorldCupApp_FranCvok");
            File.Copy(img_path, Path.Combine(path, playerName), true);
        }

        public static string? GetImagePath(string playerName)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WorldCupApp_FranCvok");
            if (!File.Exists(Path.Combine(path, playerName)))
                return null;
            return Path.Combine(path, playerName);
        }
    }
}