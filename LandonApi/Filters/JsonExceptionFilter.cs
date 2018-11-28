using System;
using System.Runtime.InteropServices.ComTypes;
using LandonApi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace LandonApi.Filters
{
    public class JsonExceptionFilter : IExceptionFilter
    {
        private readonly IHostingEnvironment _environment;
        private readonly ILogger<JsonExceptionFilter> _logger;

        public JsonExceptionFilter(IHostingEnvironment environment, ILogger<JsonExceptionFilter> logger)
        {
            _environment = environment;
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception.Message + "\n" + context.Exception.StackTrace);
            ApiError error;
            if (_environment.IsDevelopment())
            {
                error = new ApiError
                {
                    Message = context.Exception.Message,
                    Detail = context.Exception.StackTrace
                };
            }
            else
            {
                error = new ApiError
                {
                    Message = "An error has occurred",
                    Detail = context.Exception.Message
                };
            }

            context.Result = new ObjectResult(error)
            {
                StatusCode = 500
            };
        }
    }
}
