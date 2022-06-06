using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace SkeletonApi.Middleware
{
    public class ErrorHandler
    {
        private readonly RequestDelegate _next;

        public ErrorHandler(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next)); 
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = ex switch
                {
                    KeyNotFoundException _ => (int)HttpStatusCode.NotFound,
                    _ => (int)HttpStatusCode.InternalServerError,
                };
            }
        }
    }
}
