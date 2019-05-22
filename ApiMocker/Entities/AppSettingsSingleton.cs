using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using Newtonsoft.Json;

namespace ApiMocker.Entities
{
    public interface IAppStartupSettings
    {
        int Port { get; set; }
        bool Https { get; set; }
        bool VerboseLogging { get; set; }
        string MockFolder { get; set; }
        string ConfigFile { get; set; }
        IEnumerable<IServiceMock> ServiceMocks { get; set; }
    }

    public class AppSettingsSingleton  : IAppStartupSettings
    {
        [JsonProperty("port", Required = Required.Default)]
        public int Port { get; set; }
        [JsonProperty("https", Required = Required.Default)]
        public bool Https { get; set; }
        [JsonProperty("verboseLogging", Required = Required.Default)]
        public bool VerboseLogging { get; set; }
        [JsonProperty("mocksFolder", Required = Required.Default)]
        public string MockFolder { get; set; }
        [JsonProperty("configFile", Required = Required.Default)]
        public string ConfigFile { get; set; }
        public IEnumerable<IServiceMock> ServiceMocks { get; set; }

        private AppSettingsSingleton()
        {
            Port = 5200;
            Https = false;
            VerboseLogging = false;
            MockFolder = "c\\temp\\mocks";
            ConfigFile = "sample.config";
            ServiceMocks = new List<IServiceMock>();
        }
    }
}
