using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Icon.Middleware.Middlewares
{
    public class InformationMiddleware : IMiddleware
    {
        private readonly ILogger<InformationMiddleware> _logger;

        public InformationMiddleware(ILogger<InformationMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            Console.WriteLine("InformationMiddleware: Start");

            var a = 1;
            var b = 0;
            var c = a / b;

            await next(context);

            Console.WriteLine("InformationMiddleware: End");
        }
    }
}
