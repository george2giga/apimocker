using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;

namespace ApiMocker.Entities
{
    public interface IAppStartupSettings
    {
        int Port { get; }
        bool Https { get; }
        bool QuietLogging { get; }
        string MockFolder { get; }
        string ConfigFolder { get; }
        string ConfigName { get; }
    }

    public class AppSettingsSingleton 
    {
        public int Port { get; set; }
        public bool Https { get; set; }
        public bool VerboseLogging { get; set; }
        public string MockFolder { get; set; }
        public string ConfigName { get; set; }

        //private static AppSettingsSingleton _instance;
        // singleton instance
        public static AppSettingsSingleton Instance { get; } = new AppSettingsSingleton();

        //private AppSettingsSingleton(IConfiguration configuration)
        //{
        //    Port = configuration.GetValue<int>("host:port") == 0 ?  5200 : configuration.GetValue<int>("host:port");
        //    Https = configuration.GetValue<bool>("host:https") != false && configuration.GetValue<bool>("host:https");
        //    QuietLogging = configuration.GetValue<bool>("logging:quiet") != false && configuration.GetValue<bool>("host:quiet");
        //    MockFolder = configuration.GetValue<string>("mocks:rootfolder") ?? "c:\\temp\\mocks";
        //    ConfigName = configuration.GetValue<string>("startupConfig:configName") ?? "sample.config";
        //}

        private AppSettingsSingleton()
        {
            Port = 5200;
            Https = false;
            VerboseLogging = false;
            MockFolder = "c\\temp\\mocks";
            ConfigName = "sample.config";
        }

        //public static void Create(IConfiguration configuration)
        //{
        //    if(_instance == null)
        //        _instance = new AppSettingsSingleton(configuration);
        //}

        private void UpdateSettings(IAppStartupSettings startupSettings)
        {
            //Port = startupSettings.Port
        }
    }
}
