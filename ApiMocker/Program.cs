using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ApiMocker.Entities;
using CommandLine;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ApiMocker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Parser.Default.ParseArguments<MockerStartupOptions>(args)
                .WithParsed(options => UpdateAppSettings(options)).WithNotParsed(errors => HandleParseError(errors));
            CreateWebHostBuilder(args).Build().Run();
        }

        private void 

        private static void UpdateAppSettings(MockerStartupOptions options)
        {
            if (options.Https.HasValue)
                AppSettingsSingleton.Instance.Https = options.Https.Value;
            if (options.TcpPort.HasValue)
                AppSettingsSingleton.Instance.Port = options.TcpPort.Value;
            if (options.VerboseLogging.HasValue)
                AppSettingsSingleton.Instance.VerboseLogging = options.VerboseLogging.Value;
            if (!string.IsNullOrEmpty(options.ConfigFile))
                AppSettingsSingleton.Instance.ConfigName = options.ConfigFile;
        }
        private static void UpdateAppSettings(IConfiguration configuration)
        {
            AppSettingsSingleton.Instance.Https = configuration.GetValue<bool>("host:https");
            AppSettingsSingleton.Instance.VerboseLogging = configuration.GetValue<bool>("logging:verbose");
            if (configuration.GetValue<int>("host:port") != 0)
                AppSettingsSingleton.Instance.Port = configuration.GetValue<int>("host:port");
            if (!string.IsNullOrWhiteSpace(configuration.GetValue<string>("startupConfig:configName")))
            AppSettingsSingleton.Instance.ConfigName = configuration.GetValue<string>("startupConfig:configName");
            if (!string.IsNullOrWhiteSpace(configuration.GetValue<string>("startupConfig:configName")))
                AppSettingsSingleton.Instance.ConfigName = configuration.GetValue<string>("startupConfig:configName");
            if (!string.IsNullOrWhiteSpace(configuration.GetValue<string>("mocks:rootFolder")))
                AppSettingsSingleton.Instance.MockFolder= configuration.GetValue<string>("mocks:rootFolder");
        }

        private static void HandleParseError(IEnumerable<Error> errs)
        {
            Console.WriteLine("Command Line parameters provided were not valid!");
        }


        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            //var config = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json", optional: false)
            //    .Build();


            var url = ApplicationSettings.Instance.Https ? "https" : "http";
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                })
                //.UseSetting("https_port", ApplicationSettings.Instance.TcpPort.ToString());
                .UseUrls($"{url}://*:{ApplicationSettings.Instance.TcpPort}");
        }
    }
}
