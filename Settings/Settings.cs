using System;
using System.IO;
using System.Text.Json;

namespace Lucid.Settings
{
    public class Settings
    {
        private static readonly string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        private static readonly string filename = path + "/LucidCLISettings.json";

        public static void GenerateFile()
        {
            Console.WriteLine("[Lucid] Generating settings file...");

            SettingsParams defaultSettings = new SettingsParams()
            {
                Username = "",
                PIN = "",
                Init = false
            };

            var jsonString = JsonSerializer.Serialize(defaultSettings);

            File.WriteAllText(filename, jsonString);
        }

        public static SettingsParams ReturnData()
        {
            SettingsParams settings;

            var rawData = File.ReadAllText(filename);
            settings = JsonSerializer.Deserialize<SettingsParams>(rawData);

            return settings;
        }

        public static void SetSettings(SettingsParams par)
        {
            var settings = ReturnData();

            settings.Username = par.Username;
            settings.PIN = par.PIN;
            settings.Init = par.Init;

            var jsonString = JsonSerializer.Serialize(settings);

            File.WriteAllText(filename, jsonString);
        }

        public static void FileCheck()
        {
            if (!File.Exists(filename))
            {
                GenerateFile();
            }
        }
    }
    public class SettingsParams
    {
        public string Username { get; set; }
        public string PIN { get; set; }
        public bool Init { get; set; }
    }
}
