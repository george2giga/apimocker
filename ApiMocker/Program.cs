using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            //var application = new CmdApplication();
            //application.ExecuteCmdApplication(args);
            MockerStartupOptions startupOptions;
            var s = Parser.Default.ParseArguments<MockerStartupOptions>(args)
                .MapResult(options =>
                {
                    startupOptions = options;
                    return 0;
                }, errors => 1);



            //var s = Parser.Default.ParseArguments<MockerStartupOptions>(args).MapResult(options => startupOptions = options,errors => 1);

            Parser.Default.ParseArguments<MockerStartupOptions>(args)
                .WithParsed<MockerStartupOptions>(o =>
                {
                    if (o.Trova.HasValue)
                    {
                        Console.WriteLine($"Verbose output enabled. Current Arguments: -v {o.VerboseLogging}");
                        Console.WriteLine("Quick Start Example! App is in Verbose mode!");
                    }
                    //if (o.Prova)
                    //{
                    //    Console.WriteLine($"Verbose output enabled. Current Arguments: -v {o.VerboseLogging}");
                    //    Console.WriteLine("Quick Start Example! App is in Verbose mode!");
                    //}
                    else
                    {
                        Console.WriteLine($"Current Arguments: -v {o.VerboseLogging}");
                        Console.WriteLine("Quick Start Example!");
                    }
                }).WithNotParsed(errors =>
                {
                    var err = errors;
                   
                });



            CreateWebHostBuilder(args).Build().Run();
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
