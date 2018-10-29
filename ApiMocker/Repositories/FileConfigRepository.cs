using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMocker.Entities;

namespace ApiMocker.Repositories
{
    public class FileConfigRepository
    {
        private const string ConfigsFolder = "app-configs";
        private const string MocksDefaultFolder = "app-mocks";

        private static ApiMockerConfig _apiMockerConfig;
        public FileConfigRepository(string fullFilePath)
        {

        }



        public IEnumerable<ServiceMock> GetAll()
        {

        }

        public ApiMockerConfig ApiMockerConfig
        {
            get
            {
                if (_apiMockerConfig == null)
                {

                }
            }
        }
    }
}
