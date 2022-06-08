using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using SkeletonApi.Auth;
using SkeletonApi.ServicesConfigs;
using SkeletonApi.Contexts;
using SkeletonApi.Middleware;
using SkeletonApi.Repositories.Interfaces;
using SkeletonApi.Repositories;

namespace SkeletonApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            StaticConfiguration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IConfiguration StaticConfiguration{get; private set;}

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.Configure<JWT>(Configuration.GetSection("JWT"));
            AuthConfig.ConfigureService(services);
            MapperConfig.RegisterMaps();
            services.AddDbContext<SkeletonContext>(opts => 
                opts.UseSqlServer(Configuration["ConnectionString:SkeletonDb"])
            );
            services.AddDbContext<ApplicationDbContext>(opts =>
                opts.UseSqlServer(Configuration["ConnectionString:SkeletonDb"])
            );
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            services.AddScoped<IProductsRepository, ProductsRepository>();
            SwaggerConfig.ConfigureService(services);
            services = HttpClientConfig.ConfigureService(services, Configuration);
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
            app.UseSerilogRequestLogging();
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
