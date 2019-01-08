using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ApiMocker.Entities;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ApiMocker.Repositories
{
    public class FileConfigRepository
    {
        private readonly ILogger _logger;
        private readonly ApplicationSettings _applicationSettings;

        public FileConfigRepository(ILogger<FileConfigRepository> logger)
        {
            _logger = logger;
        }

        public async Task<ApiMockerConfig> GetApiMockerConfig(ApplicationSettings applicationSettings)
        {
            ApiMockerConfig apiMockerConfig = null;
            var fileContent = await File.ReadAllTextAsync(applicationSettings.ConfigFullFilePath);

            JsonSerializerSettings serializerSettings = new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Error,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            try
            {
                apiMockerConfig = JsonConvert.DeserializeObject<ApiMockerConfig>(fileContent, serializerSettings);
            }
            catch
            {
                _logger.LogError($"Invalid JSON in config file {applicationSettings.ConfigFullFilePath}");
                _logger.LogError($"Please add a valid file in the {applicationSettings.ConfigsFolder} folder");
                //invalid json, killing the exception, try again with a valid file
            }

            return apiMockerConfig;
        }

        public async Task<string> GetMockedResponse(string fullFileName)
        {
            if (!File.Exists(fullFileName)) { }
                // log missing file

            return await File.ReadAllTextAsync(fullFileName);
        }
    }
}
