using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ApiMocker.Entities;
using ApiMocker.Repositories;
using Xunit;

namespace ApiMocker.Tests.Repositories
{
    public class ApplicationSettingsRepositoryTests
    {
        private readonly string _configsDirectory;
        private readonly string _mocksDirectory;
        private readonly IApiMockerConfigRepository _apiMockerConfigRepository;

        public ApplicationSettingsRepositoryTests()
        {
            var wwwrootDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wwwroot");
            _configsDirectory = Path.Combine(wwwrootDirectory, "app-configs");
            _mocksDirectory = Path.Combine(wwwrootDirectory, "app-mocks");
            _apiMockerConfigRepository = new ApiMockerConfigRepository(new FileRepository());
        }

        [Fact]
        public async void EnsureConfgIsDeserializedCorrectly()
        {
            // Arrange 
            var appInstance = ApplicationSettings.Instance;
            ApplicationSettings.Instance.ConfigFullFilePath = Path.Combine(_configsDirectory, "sample-config.json");

            // Act
            var appSettings = await _apiMockerConfigRepository.Get(appInstance);

            // Assert
            Assert.NotNull(appSettings);
        }

    }
}
