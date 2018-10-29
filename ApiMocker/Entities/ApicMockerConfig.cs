using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMocker.Entities
{
    public class ApiMockerConfig
    {
        public string MocksFolder { get; set; }
        public IEnumerable<ServiceMock> ServiceMocks { get; set; }
    }
}
