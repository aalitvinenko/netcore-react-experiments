using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace Backend.WebApi.Configuration
{
    public static class SwaggerConfigurationExtensions
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = $"{typeof(Startup).Assembly.GetName().Name} API",
                    Version = "v1",
                });

                const string securityDefinitionName = "jwt_auth";

                var securityDefinition = new OpenApiSecurityScheme()
                {
                    Name = "Bearer",
                    BearerFormat = "JWT",
                    Scheme = "bearer",
                    Description = "Specify the authorization token",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                };

                var securityScheme = new OpenApiSecurityScheme()
                {
                    Reference = new OpenApiReference()
                    {
                        Id = securityDefinitionName,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                var securityRequirements = new OpenApiSecurityRequirement
                    {
                    { securityScheme, System.Array.Empty<string>() }
                    };

                c.AddSecurityDefinition(securityDefinitionName, securityDefinition);
                c.AddSecurityRequirement(securityRequirements);

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        public static void UseConfiguredSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "api";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }
    }
}