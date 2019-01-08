using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ApiMocker.Core
{
    public class RequestMocker
    {
        public async Task ReplaceResponse(HttpContext context)
        {
            //var serviceMock = _liteDbRepository.GetBy(mock => mock.Url == context.Request.Path && mock.Verb == context.Request.Method);
            var serviceMock = new {};

            if (serviceMock != null)
            {
                //context.Response.ContentType = serviceMock.ContentType;
                //context.Response.StatusCode = serviceMock.HttpStatus;

                //await context.Response.WriteAsync(serviceMock.Content);
            }
        }
    }
}
