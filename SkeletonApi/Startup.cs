using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft;
using Serilog;
using SkeletonApi.Configs;
using SkeletonApi.Contexts;
using SkeletonApi.Middleware;
using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkeletonApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddDbContext<SkeletonContext>(opts => 
                opts.UseSqlServer(Configuration["ConnectionString:SkeletonDb"])
            );
            SwaggerConfig.ConfigureService(services);
            services.AddResponseCaching();
            IMapper mapper = MapperConfig.RegisterMaps().CreateMapper();
            services.AddSingleton(mapper);
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My skeleton API v1");
                c.RoutePrefix = string.Empty;
            });
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseResponseCaching();
            app.UseAuthorization();
            app.UseMiddleware<CorrelationId>();
            app.UseMiddleware<CacheResponses>();
            app.UseMiddleware<ErrorHandler>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
