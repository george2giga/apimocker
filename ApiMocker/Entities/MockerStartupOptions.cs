using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandLine;

namespace ApiMocker.Entities
{
    [Verb("mockeroptions", HelpText = "Fake https server returning mocked responses")]
    public class MockerStartupOptions
    {
        [Option('c', "config", HelpText = "Json configuration file, e.g. <name>c:\\sampleconfig.json")]
        public string ConfigFile { get; set; }

        [Option('p', "port", HelpText = "Tcp Port used by ApiMocker")]
        public int TcpPort { get; set; }

        [Option('h', "https", HelpText = "Set to true if listener should be using secure connection (HTTPS)")]
        public bool Https { get; set; }

        [Option('l', "logging", HelpText = "Set to true to enable verbose console logging")]
        public bool VerboseLogging { get; set; }
    }
}
