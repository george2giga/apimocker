using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMocker.Entities;
using Microsoft.Extensions.Configuration;

namespace ApiMocker
{
    public class StartupOptionsBootstrapper
    {
        public static void UpdateAppSettingsFromStartupOptions(MockerStartupOptions options, IAppStartupSettings settings)
        {
            if (options.Https.HasValue)
                settings.Https = options.Https.Value;
            if (options.TcpPort.HasValue)
                settings.Port = options.TcpPort.Value;
            if (options.VerboseLogging.HasValue)
                settings.VerboseLogging = options.VerboseLogging.Value;
            if (!string.IsNullOrEmpty(options.ConfigFile))
                settings.ConfigFile = options.ConfigFile;
        }

        //public static void UpdateAppSettingsFromAppConfig(IConfigurationRoot configurationRoot)
        //{
        //    AppSettingsSingleton.Instance.Https = configurationRoot.GetValue<bool>("host:https");
        //    AppSettingsSingleton.Instance.VerboseLogging = configurationRoot.GetValue<bool>("logging:verbose");
        //    if (configurationRoot.GetValue<int>("host:port") != 0)
        //        AppSettingsSingleton.Instance.Port = configurationRoot.GetValue<int>("host:port");
        //    if (!string.IsNullOrWhiteSpace(configurationRoot.GetValue<string>("startupConfig:configName")))
        //        AppSettingsSingleton.Instance.ConfigName = configurationRoot.GetValue<string>("startupConfig:configName");
        //}
    }
}
