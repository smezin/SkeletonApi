using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.IO;

namespace SkeletonApi.Configs
{
    /// <summary>
    /// Class used to store SwashBuckle configs
    /// </summary>
    public class SwaggerConfig
    {
        /// <summary>
        /// Adding swagger service to startup services
        /// </summary>
        /// <param name="service">Startup IServiceCollection object</param>
        public static void ConfigureService(IServiceCollection service)
        {
            service.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Skeleton API",
                    Version = "v1",
                    Description = "Skeleton API architecture",
                    Contact = new OpenApiContact
                    {
                        Name = "Shahaf Mezin",
                        Email = "smezin@gmail.com"
                    }
                });
                var filePath = Path.Combine(System.AppContext.BaseDirectory, "SkeletonApi.xml");
                c.IncludeXmlComments(filePath);
            });
        }
    }
}
