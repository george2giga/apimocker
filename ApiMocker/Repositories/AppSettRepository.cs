using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ApiMocker.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ApiMocker.Repositories
{
    public class AppSettRepository
    {
        private readonly IFileProvider _fileProvider;
        private readonly MockerStartupOptions _mockerStartupOptions;
        private readonly IConfiguration _configuration;


        AppSettRepository(IFileProvider fileProvider, MockerStartupOptions mockerStartupOptions, IConfiguration configuration)
        {
            _fileProvider = fileProvider;
            _mockerStartupOptions = mockerStartupOptions;
            _configuration = configuration;
        }

        private IAppStartupSettings Get()
        {
            var configFile = string.Empty;
            if (!string.IsNullOrEmpty(_mockerStartupOptions.ConfigFile))
                configFile = _mockerStartupOptions.ConfigFile;
            else if (!string.IsNullOrWhiteSpace(_configuration.GetValue<string>("startupConfig:configName")))
                configFile = _configuration.GetValue<string>("startupConfig:configName");
            else
                throw new Exception("Cannot find a valid config file. Ensure it is either passed as commandline argument (ie: -c: c:\\config.json) or added as a key in the configuration file.");

            var fileInfo = _fileProvider.GetFileInfo(configFile);
            if(!fileInfo.Exists)
                throw new FileNotFoundException(configFile);

            //JsonSerializerSettings serializerSettings = new JsonSerializerSettings
            //{
            //    MissingMemberHandling = MissingMemberHandling.Ignore,
            //    ContractResolver = new CamelCasePropertyNamesContractResolver(),
            //    NullValueHandling = NullValueHandling.Ignore
            //};

            //try
            //{
            //    JsonConvert.PopulateObject(fileContent, applicationSettings, serializerSettings);
            //}
            //catch (Exception ex)
            //{
            //    //_logger.LogError($"Invalid JSON in config file {fullFilePath}");
            //    //_logger.LogError($"Please add a valid file in the {ConfigsFolder} folder");
            //    //invalid json, killing the exception, try again with a valid file
            //    throw new Exception();
            //}

            using (var file = fileInfo.CreateReadStream())
            using (var reader = new StreamReader(file))
            {
                var serializer = new JsonSerializer
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

                var content = (AppSettingsSingleton)serializer.Deserialize(reader, typeof(AppSettingsSingleton));
                return content;
            }
        }

        private AppSettingsSingleton GetAppSettings(string configFile)
        {
            var fileInfo = _fileProvider.GetFileInfo(configFile);
            if (!fileInfo.Exists)
                throw new FileNotFoundException(configFile);

            using (var file = fileInfo.CreateReadStream())
            using (var reader = new StreamReader(file))
            {
                var serializer = new JsonSerializer
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

                var content = (AppSettingsSingleton)serializer.Deserialize(reader, typeof(AppSettingsSingleton));
                return content;
            }
        }
    }
}
