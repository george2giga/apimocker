using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMocker.Entities;
using Microsoft.Extensions.CommandLineUtils;

namespace ApiMocker
{
    public class CmdApplication
    {
        public void ExecuteCmdApplication(string[] args)
        {

            var cmdApplication = new CommandLineApplication()
            {
                Name = ".Net ApiMocker",
                Description = "Mock your API calls.",
            };
            cmdApplication.HelpOption("-?|-h|--help");
            var configFileOption = cmdApplication.Option("-c|--config", "supply a config file", CommandOptionType.SingleValue);
            var tcpPortOption = cmdApplication.Option("-p|--port", "supply a tcp port", CommandOptionType.SingleValue);
            var httpsOption = cmdApplication.Option("-h|--https", "use https", CommandOptionType.SingleValue);
            var quietLoggingOption = cmdApplication.Option("-q|--quiet", "quiet logging (default is false, ie: verbose)", CommandOptionType.SingleValue);

            // on execution
            cmdApplication.OnExecute(() =>
            {
                // override default application settings if cmd arguments are supplied
                if (configFileOption.HasValue())
                {
                    ApplicationSettings.Instance.ConfigFullFilePath = configFileOption.Value();
                }

                if (tcpPortOption.HasValue())
                {
                    ApplicationSettings.Instance.TcpPort = Convert.ToInt32(tcpPortOption.Value());
                }

                if (quietLoggingOption.HasValue())
                {
                    ApplicationSettings.Instance.ConsoleLoggingEnabled = Convert.ToBoolean(quietLoggingOption.Value());
                }

                if (httpsOption.HasValue())
                {
                    ApplicationSettings.Instance.Https = Convert.ToBoolean(httpsOption.Value());
                }

                return 0;
            });

            cmdApplication.Execute(args);
        }
    }
}
