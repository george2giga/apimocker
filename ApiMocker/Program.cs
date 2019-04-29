using System;
using System.Collections.Generic;
using System.IO;
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
            UpdateAppSettingsFromAppConfig();

            Parser.Default.ParseArguments<MockerStartupOptions>(args)
                .WithParsed(options => StartupOptionsBootstrapper.UpdateAppSettingsFromStartupOptions(options)).WithNotParsed(errors => HandleParseError(errors));
            CreateWebHostBuilder(args).Build().Run();
        }
      
        private static void UpdateAppSettingsFromAppConfig()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            StartupOptionsBootstrapper.UpdateAppSettingsFromAppConfig(configuration);
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


            var url = AppSettingsSingleton.Instance.Https ? "https" : "http";
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                })
                //.UseSetting("https_port", ApplicationSettings.Instance.TcpPort.ToString());
                .UseUrls($"{url}://*:{AppSettingsSingleton.Instance.Port}");
        }
    }
}
