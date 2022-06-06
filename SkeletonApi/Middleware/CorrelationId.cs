using Microsoft.AspNetCore.Http;
using Serilog.Context;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SkeletonApi.Middleware
{
    public class CorrelationId
    {
        private readonly RequestDelegate _next;
        private readonly string _correlationIdHeader = "X-Corrleation-Id";
        public CorrelationId(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }
        public Task Invoke (HttpContext context)
        {
            context.Request.Headers.TryGetValue(_correlationIdHeader, out var correlationHeader);            
            var correlationId = correlationHeader.FirstOrDefault() ?? context.TraceIdentifier;
            context.Response.Headers.Add(_correlationIdHeader, correlationId);
            using (LogContext.PushProperty(_correlationIdHeader, correlationId))
            {
                return _next.Invoke(context);
            }
        }
    }
}
