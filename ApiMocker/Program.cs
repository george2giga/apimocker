using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ApiMocker.Entities;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ApiMocker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var application = new CmdApplication();
            application.ExecuteCmdApplication(args);

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
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
