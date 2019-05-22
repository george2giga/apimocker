using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;

namespace ApiMocker.Entities
{
    public interface IAppStartupSettings
    {
        int Port { get; set; }
        bool Https { get; set; }
        bool VerboseLogging { get; set; }
        string MockFolder { get; set; }
        string ConfigFolder { get; set; }
        string ConfigName { get; set; }
        IEnumerable<IServiceMock> ServiceMocks { get; set; }
    }

    public class AppSettingsSingleton  : IAppStartupSettings
    {
        private readonly string _wwwRoot = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

        public int Port { get; set; }
        public bool Https { get; set; }
        public bool VerboseLogging { get; set; }
        public string MockFolder { get; set; }
        public string ConfigFolder { get; set; }
        public string ConfigName { get; set; }
        public IEnumerable<IServiceMock> ServiceMocks { get; set; }

        // singleton instance
        public static AppSettingsSingleton Instance { get; } = new AppSettingsSingleton();

        private AppSettingsSingleton()
        {
            Port = 5200;
            Https = false;
            VerboseLogging = false;
            MockFolder = "c\\temp\\mocks";
            ConfigName = "sample.config";
            ServiceMocks = new List<IServiceMock>();
        }
    }
}
