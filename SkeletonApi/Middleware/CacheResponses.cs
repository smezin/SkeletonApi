using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using Serilog;
using Serilog.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace SkeletonApi.Middleware
{
    /// <summary>
    /// Middleware for caching (in memory) the responses for certain time.
    /// MUST be disabled for sensitive data responses
    /// </summary>
    public class CacheResponses
    {
        private readonly RequestDelegate _next;

        public CacheResponses(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next)); 
        }
        public async Task Invoke (HttpContext context)
        {
            context.Response.GetTypedHeaders().CacheControl =
                new CacheControlHeaderValue()
                {
                    Public = true,
                    MaxAge = TimeSpan.FromMinutes(1)
                };
            context.Response.Headers[HeaderNames.Vary] = new string[] { "Accept-Encoding" };
            await _next(context);
        } 
    }
}
