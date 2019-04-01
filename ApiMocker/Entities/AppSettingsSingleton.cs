using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMocker.Entities
{
    public class AppSettingsSingleton
    {
        public int Port { get; set; }
        public bool Https { get; set; }
        public bool QuietLogging { get; set; }
        public string MockFolder { get; set; }
    }
}
