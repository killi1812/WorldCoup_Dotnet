using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballData.Setting
{
    public class SettingsValues
    {
        public string ConfigPath { get; set; }

        public string DataPath { get; set; }

        public string Language { get; set; }

        public string LeagueGender { get; set; }

        public int RepositoryType { get; private set; }

        private string Repository
        {
            get { return RepositoryType.ToString(); }
            set { RepositoryType = int.Parse(value); }
        }

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

        private string ReadSettings()
        {
            var filename = FileName();
            if (!File.Exists(filename))
            {
                using (StreamWriter writer = new(filename))
                {
                    writer.WriteLine("#This is a settings file for the FootballData application");
                }
            }
            StreamReader reader = new(filename);
            StringBuilder sb = new();

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line == "" || line.Trim()[0] == '#') continue;
                sb.AppendLine(line);
            }

            return sb.ToString();
        }

        static private SettingsValues ParseSettings(string content)
        {
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
                prop.SetValue(settingsValues, settingsDict[prop.Name]);
            }
            return settingsValues;
        }

        public async Task<bool> SaveSettingsAsync()
        {
            try
            {
                StringBuilder content = new(ReadSettings());

                //TODO replace old values with new values
                //TODO add values if they are not empty

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

        public string? this[string key]
        {
            get
            {
                var prop = Values.GetType().GetProperties().FirstOrDefault(p => p.Name == key);
                if (prop == null) return "";
                var value = prop.GetValue(Values);
                if (value == null) return "";
                return value.ToString();
            }
            set
            {
                var prop = Values.GetType().GetProperties().FirstOrDefault(p => p.Name == key);
                if (prop == null) return;
                prop.SetValue(Values, value);
            }
        }
    }
}