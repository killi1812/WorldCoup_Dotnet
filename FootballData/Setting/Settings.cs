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
        public string Language { get; set; }
        public string LeagueGender { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new();

            foreach (var prop in GetType().GetProperties())
            {
                sb.AppendLine($"{prop.Name}:{prop.GetValue(this)}");
            }
            return sb.ToString();
        }

    }

    public class Settings
    {
        public SettingsValues? Values { get; private set; } = null;
        private Settings()
        {
            //TODO remove mock data
            string mockData = "Language = hr\n";
            Values = ParseSettings(mockData);
            //SettingsValues = ParseSettings(ReadSettingsAsync().Result);
        }
        private static readonly object _oLock = new();
        private static Settings? _settingsRepo = null;
        public static Settings GetSettings()
        {
            lock (_oLock)
            {
                _settingsRepo ??= new Settings();
                return _settingsRepo;
            }
        }

        private readonly string _fileName = "worldCup.conf";

        private async Task<string> ReadSettingsAsync()
        {
            //TODO mby add support fo r comments with #
            using StreamReader reader = new(FileName());
            return await reader.ReadToEndAsync();
        }
        private static SettingsValues ParseSettings(string content)
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
                string content = await ReadSettingsAsync();

                //TODO replace old values with new values

                using StreamWriter writer = new(FileName());
                await writer.WriteAsync(content);
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
                key = key.ToLower();
                var prop = Values.GetType().GetProperties().FirstOrDefault(p => p.Name.ToLower() == key);
                if (prop == null) return "";
                var value = prop.GetValue(Values);
                if (value == null) return "";
                return value.ToString();
            }
            set
            {
                var prop = Values.GetType().GetProperties().FirstOrDefault(p => p.Name.ToLower() == key);
                if (prop == null) return;
                prop.SetValue(Values, key);
            }
        }
    }
}
