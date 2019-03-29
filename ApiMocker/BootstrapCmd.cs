using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMocker.Entities;
using CommandLine;

namespace ApiMocker
{
    public class BootstrapCmd
    {
        public void Bootstrap(string[] args)
        {
            var mockerOptions = Parser.Default.ParseArguments<MockerStartupOptions>(args);
        }
    }
}
