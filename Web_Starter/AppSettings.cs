using System;
using System.IO;
using System.Text.Json;

namespace Web_Starter
{
    public class AppSettings
    {
        private static AppSettings _instance;
        private static readonly string SettingsPath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, "settings.json");

        // DB 설정 (기본값)
        public string DbHost { get; set; } = "localhost";
        public int DbPort { get; set; } = 5432;
        public string DbName { get; set; } = "farmos";
        public string DbUsername { get; set; } = "postgres";
        public string DbPassword { get; set; } = "postgres";

        // 프로젝트 설정 (기본값)
        public string ProjectRoot { get; set; } = @"C:\Dev\FarmOS";

        public string ConnectionString =>
            $"Host={DbHost};Port={DbPort};Username={DbUsername};Password={DbPassword};Database={DbName}";

        public string PostgresConnectionString =>
            $"Host={DbHost};Port={DbPort};Username={DbUsername};Password={DbPassword};Database=postgres";

        public static AppSettings Instance
        {
            get
            {
                if (_instance == null)
                    _instance = Load();
                return _instance;
            }
        }

        public static AppSettings Load()
        {
            try
            {
                if (File.Exists(SettingsPath))
                {
                    string json = File.ReadAllText(SettingsPath);
                    var settings = JsonSerializer.Deserialize<AppSettings>(json);
                    if (settings != null)
                        return settings;
                }
            }
            catch { }

            // 파일 없거나 파싱 실패 시 기본값 사용
            return new AppSettings();
        }

        public void Save()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(this, options);
            File.WriteAllText(SettingsPath, json);
        }

        public static void Reload()
        {
            _instance = Load();
        }
    }
}
