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
            Console.WriteLine("Start - Custom Middleware"); 
             
            await next(context);

            Console.WriteLine("End - Custom Middleware"); 
        }
    }
}
