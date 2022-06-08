using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SkeletonApi.Auth;
using SkeletonApi.Contexts;
using SkeletonApi.Models.Entities;
using SkeletonApi.Services;
using SkeletonApi.Services.Interfaces;
using System;
using System.Text;

namespace SkeletonApi.ServicesConfigs
{
    public class AuthConfig
    {
        public AuthConfig(IConfiguration configuration)
        {
            Configuration = configuration;
            StaticConfig = configuration;
        }
        public static IConfiguration StaticConfig { get; private set; }
        public IConfiguration Configuration { get; }

        public static void ConfigureService(IServiceCollection service)
        {
            service.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
            service.AddScoped<IUserService, UserService>();
            service.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(o =>
                {
                    o.RequireHttpsMetadata = false;
                    o.SaveToken = false;
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidIssuer = StaticConfig["JWT:Issuer"],
                        ValidAudience = StaticConfig["JWT:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(StaticConfig["JWT:Key"]))
                    };
                });
        }
    }
}
