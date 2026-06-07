using System;
using System.IO;
using System.Text.Json;

namespace specflow_table_generator
{
    internal sealed class UserSettings
    {
        private static readonly JsonSerializerOptions SerializerOptions = new()
        {
            WriteIndented = true
        };

        public string ServerOrConnectionString { get; set; }

        public string Database { get; set; }

        public string SqlQuery { get; set; }

        public static string FilePath
        {
            get
            {
                var directory = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "SpecFlowTableGenerator");

                return Path.Combine(directory, "settings.json");
            }
        }

        public static UserSettings Load()
        {
            if (!File.Exists(FilePath))
            {
                return null;
            }

            try
            {
                var json = File.ReadAllText(FilePath);
                return JsonSerializer.Deserialize<UserSettings>(json, SerializerOptions);
            }
            catch
            {
                return null;
            }
        }

        public void Save()
        {
            var directory = Path.GetDirectoryName(FilePath);
            if (!string.IsNullOrWhiteSpace(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var json = JsonSerializer.Serialize(this, SerializerOptions);
            File.WriteAllText(FilePath, json);
        }
    }
}
