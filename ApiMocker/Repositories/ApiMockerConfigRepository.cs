using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ApiMocker.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ApiMocker.Repositories
{
    public class ApiMockerConfigRepository : IApiMockerConfigRepository
    {
        private readonly IFileRepository _fileRepository;
        private readonly IAppStartupSettings _appStartupSettings;

        public ApiMockerConfigRepository(IFileRepository fileRepository,IAppStartupSettings appStartupSettings)
        {
            //_settings = settings;
            _fileRepository = fileRepository;
            _appStartupSettings = appStartupSettings;
        }

        //public async Task<ApplicationSettings> Get(ApplicationSettings applicationSettings)
        //{
        //    var fileContent = await _fileRepository.GetFileContent(applicationSettings.ConfigFullFilePath);
        //    JsonSerializerSettings serializerSettings = new JsonSerializerSettings
        //    {
        //        MissingMemberHandling = MissingMemberHandling.Ignore,
        //        ContractResolver = new CamelCasePropertyNamesContractResolver(),
        //        NullValueHandling = NullValueHandling.Ignore
        //    };

        //    try
        //    {
        //        JsonConvert.PopulateObject(fileContent, applicationSettings, serializerSettings);
        //    }
        //    catch(Exception ex)
        //    {
        //        //_logger.LogError($"Invalid JSON in config file {fullFilePath}");
        //        //_logger.LogError($"Please add a valid file in the {ConfigsFolder} folder");
        //        //invalid json, killing the exception, try again with a valid file
        //        throw new Exception();
        //    }

        //    return applicationSettings;
        //}

        public async Task<IServiceMock> Get()
        {
            var fileContent = await _fileRepository.GetFileContent(applicationSettings.ConfigFullFilePath);
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            };

            try
            {
                JsonConvert.PopulateObject(fileContent, applicationSettings, serializerSettings);
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Invalid JSON in config file {fullFilePath}");
                //_logger.LogError($"Please add a valid file in the {ConfigsFolder} folder");
                //invalid json, killing the exception, try again with a valid file
                throw new Exception();
            }

            return applicationSettings;
        }


    }
}
