using FootballData.Data.Models;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

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
            Values = ReadSettings();
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
        private Settings ReadSettings()
        {
            var filename = FileName();
            if (!File.Exists(filename))
            {
                Directory.CreateDirectory(path);
                IsNew = true;
                return new Settings
                {
                    Language = "en",
                    Repository = 1,
                    LeagueGender = "men",
                    DataPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\worldcup.sfg.io"))

                };
            }
            using StreamReader reader = new(filename);
            var settings = new Settings();
            var stream = reader.BaseStream;
            settings = JsonSerializer.DeserializeAsync<Settings>(stream).Result;
            return settings;
        }

        public async Task<bool> SaveSettingsAsync()
        {
            try
            {
                await using StreamWriter writer = new(FileName());
                var json = JsonSerializer.Serialize(Values);
                await writer.WriteAsync(json);
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