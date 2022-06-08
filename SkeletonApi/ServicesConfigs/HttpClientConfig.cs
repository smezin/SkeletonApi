using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;


namespace SkeletonApi.ServicesConfigs
{
    public static class HttpClientConfig
    {
        public static IServiceCollection ConfigureService (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient(
                configuration.GetSection("HttpClient:CatFactApi:Name").Value,
                httpClient =>
                httpClient.BaseAddress = new Uri(configuration.GetSection("HttpClient:CatFactApi:BaseAddress").Value)
            );
            return services;
        }
    }
}
