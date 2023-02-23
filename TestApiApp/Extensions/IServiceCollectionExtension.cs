using Microsoft.OpenApi.Models;
using TestApiApp.Repositories.UnitOfWork;
using TestApiApp.Services.Token;

namespace TestApiApp.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo { Title = "Test API", Version = "v1" });
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    // TODO: Delete comment
                    // Http - Token without Bearer prefix
                    // ApiKey - Token with Bearer prefix
                    Type = SecuritySchemeType.Http,
                    Name = "Authorization",
                    BearerFormat = "JWT",
                    Scheme = "Bearer",
                    Description = @"JWT Authorization header using the Bearer sheme.
                        Please enter a valid token without Bearer prefix.",
                });
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
                swagger.EnableAnnotations();
            });

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddTransient<ITokenService, TokenService>();

            return services;
        }
    }
}
