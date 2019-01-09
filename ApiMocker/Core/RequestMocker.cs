using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ApiMocker.Entities;
using ApiMocker.Repositories;
using Microsoft.AspNetCore.Http;

namespace ApiMocker.Core
{
    public class RequestMocker
    {
        private readonly IFileRepository _fileRepository;

        public RequestMocker(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }
        public async Task ReplaceResponse(HttpContext context, ApplicationSettings applicationSettings)
        {
            //var serviceMock = _liteDbRepository.GetBy(mock => mock.Url == context.Request.Path && mock.Verb == context.Request.Method);
            var serviceMock = applicationSettings.ServiceMocks.Where(x => IsMatch(x.Url, context.Request.Path)).FirstOrDefault(y => y.Verb.Equals(context.Request.Method, StringComparison.InvariantCultureIgnoreCase));

            if (serviceMock != null)
            {
                //setting content
                serviceMock.Content = await _fileRepository.GetFileContent(Path.Combine(applicationSettings.MocksFolder, serviceMock.MockFile));

                context.Response.ContentType = serviceMock.ContentType;
                context.Response.StatusCode = serviceMock.HttpStatus;

                await context.Response.WriteAsync(serviceMock.Content);
            }
        }

        public bool IsMatch(string url, string match)
        {
            if (Regex.Match(url, Regex.Escape(match).Replace("\\*", "[a-zA-Z0-9]+")).Success)
                return true;

            return false;
        }
    }
}
