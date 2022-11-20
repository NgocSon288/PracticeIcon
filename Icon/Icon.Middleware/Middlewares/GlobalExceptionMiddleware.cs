using Icon.Middleware.Infrastructor;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Icon.Middleware.Middlewares
{
    public class GlobalExceptionMiddleware : IMiddleware
    {
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(ILogger<GlobalExceptionMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        { 
            Console.WriteLine("GlobalExceptionMiddleware: Start");

            try
            {
                // Return exception with status 500 if we don't use try catch and the next middleware was thrown error
                await next(context);
            }
            catch (Exception ex)
            {
               await HandleAsync(context, ex);
            }

            Console.WriteLine("GlobalExceptionMiddleware: End");
        }

        private async Task HandleAsync(this HttpContext context, Exception exception)
        {
            // Log the exception to database

            // Custom respond to client
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(new ApiExceptionResult()
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message
            }.ToString());
            //var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
            //if (contextFeature != null)
            //{
            //}

            // Log console
            Console.WriteLine("GlobalExceptionMiddleware: Exception - " + exception.Message);
        }
    }
}
