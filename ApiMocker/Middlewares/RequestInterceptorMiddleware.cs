using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMocker.Core;
using ApiMocker.Entities;
using ApiMocker.Repositories;
using Microsoft.AspNetCore.Http;

namespace ApiMocker.Middlewares
{
    public class RequestInterceptorMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IApiMockerConfigRepository _apiMockerConfigRepository;
        private ApplicationSettings _applicationSettings;
        private readonly RequestMocker _requestMocker;
        private readonly IFileRepository _fileRepository;

        public RequestInterceptorMiddleware(RequestDelegate next, IApiMockerConfigRepository apiMockerConfigRepository, IFileRepository fileRepository)
        {
            _next = next;
            _apiMockerConfigRepository = apiMockerConfigRepository;
            _requestMocker = new RequestMocker(fileRepository);
        }

        public async Task Invoke(HttpContext context)
        {
            if (_applicationSettings == null)
            {
                _applicationSettings = await _apiMockerConfigRepository.Get(ApplicationSettings.Instance);
            }

            await _requestMocker.ReplaceResponse(context, _applicationSettings);
        }

    }
}
