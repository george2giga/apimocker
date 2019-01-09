using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ApiMocker.Entities
{
    public class ApplicationSettings
    {
        private readonly string _wwwRoot = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        public string MocksFolder { get; set; }
        public string ConfigsFolder { get; set; }
        [JsonIgnore]
        public string ConfigName { get; set; }
        [JsonIgnore]
        public string ConfigFullFilePath { get; set; }
        public bool ConsoleLoggingEnabled { get; set; }
        public int TcpPort { get; set; }
        public bool Https { get; set; }
        public IEnumerable<ServiceMock> ServiceMocks { get; set; }

        // singleton instance
        public static ApplicationSettings Instance { get; } = new ApplicationSettings();

        private ApplicationSettings()
        {
            MocksFolder = Path.Combine(_wwwRoot, "app-mocks");
            ConfigsFolder = Path.Combine(_wwwRoot, "app-configs");
            ConfigName = "sample.json";
            ConfigFullFilePath = Path.Combine(ConfigsFolder, ConfigName);
            ConsoleLoggingEnabled = false;
            TcpPort = 5000;
        }

        public async Task<string> GetFileContent(string fullFilePath)
        {
            string content;
            using (var reader = File.OpenText(fullFilePath))
            {
                content = await reader.ReadToEndAsync();
            }

            return content;
        }
    }
}
