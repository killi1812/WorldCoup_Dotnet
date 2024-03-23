using System.Text;

namespace FootballData.ProjectSettings
{
    public class SettingsValues
    {
        public string ConfigPath { get; set; }

        public string DataPath { get; set; }

        public string Language { get; set; }

        public string LeagueGender { get; set; }

        public int Repository { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new();

            foreach (var prop in GetType().GetProperties())
            {
                sb.AppendLine($"{prop.Name} = {prop.GetValue(this)}");
            }
            return sb.ToString();
        }
    }

    public class Settings
    {
        public SettingsValues Values { get; private set; }
        public bool IsNew { get; private set; } = false;

        private Settings()
        {
            Values = ParseSettings(ReadSettings());
        }

        static private readonly object _oLock = new();
        static private Settings? _settingsRepo = null;

        public static Settings GetSettings()
        {
            lock (_oLock)
            {
                _settingsRepo ??= new Settings();
                return _settingsRepo;
            }
        }

        private const string _fileName = "worldCup.conf";

        private string? ReadSettings()
        {
            var filename = FileName();
            if (!File.Exists(filename))
            {
                IsNew = true;
                return null;
            }
            using StreamReader reader = new(filename);
            return reader.ReadToEnd();
        }

        static private SettingsValues ParseSettings(string? content)
        {
            if (content == null)
                return new SettingsValues
                {
                    ConfigPath = "./",
                    DataPath = "RiderProjects/OOP_dotnet_praktikum_Fran_Cvok/worldcup.sfg.io",
                    Language = "en",
                    LeagueGender = "men",
                    Repository = 1,
                };
            string[] lines = content.Split('\n');
            SettingsValues settingsValues = new();
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
                    default:
                        throw new NotImplementedException();
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
            string? path = Values?.ConfigPath;
            if (path == null) return _fileName;
            if (path.Last() != '/') path += '/';
            return $"{path}{_fileName}";
        }
    }
}