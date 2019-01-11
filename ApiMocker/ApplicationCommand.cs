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
            cmdApplication.HelpOption("-d|-h|--help");
            var configFileOption = cmdApplication.Option("-c|--config", "supply a config file", CommandOptionType.SingleValue);
            var tcpPortOption = cmdApplication.Option("-p|--port", "supply a tcp port", CommandOptionType.SingleValue);
            var httpsOption = cmdApplication.Option("-h|--https", "use https", CommandOptionType.NoValue);
            var quietLoggingOption = cmdApplication.Option("-q|--quiet", "quiet logging (default is false, ie: verbose)", CommandOptionType.NoValue);

            
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
                    //ApplicationSettings.Instance.ConsoleLoggingEnabled = Convert.ToBoolean(quietLoggingOption.Value());
                    ApplicationSettings.Instance.ConsoleLoggingEnabled = true;
                }

                if (httpsOption.HasValue())
                {
                    //ApplicationSettings.Instance.Https = Convert.ToBoolean(httpsOption.Value());
                    ApplicationSettings.Instance.Https = true;
                }

                if (cmdApplication.)
                {
                    //ApplicationSettings.Instance.Https = Convert.ToBoolean(httpsOption.Value());
                    ApplicationSettings.Instance.Https = true;
                }

                return 0;
            });

            try
            {
                cmdApplication.Execute(args);
            }
            catch (Exception ex)
            {
                //TODO: add logging
                cmdApplication.Error.WriteLine(ex.Message);
                cmdApplication.ShowHelp();
                //cmdApplication.Error.WriteLine(ex.ToString());
            }
        }
    }
}
