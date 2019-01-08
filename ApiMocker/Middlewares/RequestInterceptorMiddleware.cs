using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ApiMocker.Middlewares
{
    public class RequestInterceptorMiddleware
    {
        private readonly RequestDelegate _next;
    }
}
