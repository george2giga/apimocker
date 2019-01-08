using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ApiMocker.Entities;

namespace ApiMocker.Repositories
{
    public class ApiMockerConfigRepository
    {
        private ApplicationSettings _settings;
        public ApiMockerConfigRepository()
        {
            //_settings = settings;
        }

        public ApiMockerConfig Get(ApplicationSettings settings)
        {
            var fileContent = File.ReadAllText(settings.ConfigsFolder);
            throw new NotImplementedException();
        }
    }
}
