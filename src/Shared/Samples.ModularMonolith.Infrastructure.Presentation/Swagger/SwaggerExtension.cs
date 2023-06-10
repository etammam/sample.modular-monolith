using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Samples.ModularMonolith.Infrastructure.Presentation.Swagger.Configurations;
using SwaggerHierarchySupport;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Samples.ModularMonolith.Infrastructure.Presentation.Swagger
{
    /// <summary>
    /// this extension support swagger implementation across project
    /// </summary>
    public static class SwaggerExtension
    {
        /// <summary>
        /// the service layer of swagger implementation
        /// </summary>
        /// <param name="services"></param>
        /// <param name="swaggerConfigurationSectionName">it's optional with a default value called 'Swagger'
        /// ,then it will load the default setting form appsettings.json</param>
        public static void AddSwagger(this IServiceCollection services, string swaggerConfigurationSectionName = "Swagger")
        {
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.ApiVersionReader = ApiVersionReader.Combine(
                    new UrlSegmentApiVersionReader(),
                    new HeaderApiVersionReader("x-api-version"));
            });

            services.AddVersionedApiExplorer(setup =>
            {
                setup.GroupNameFormat = "'v'VVV";
                setup.SubstituteApiVersionInUrl = true;
            });

            var serviceProvider = services.BuildServiceProvider();
            var configurations = serviceProvider.GetService<IConfiguration>();
            var swaggerConfiguration = configurations!.GetSection(swaggerConfigurationSectionName).Get<SwaggerConfiguration>();
            var apiVersionDescriptionProvider = serviceProvider.GetService<IApiVersionDescriptionProvider>();
            var webHostEnvironment = serviceProvider.GetService<IWebHostEnvironment>();

            if (swaggerConfiguration!.Enabled)
            {
                services.AddSwaggerGen(options =>
                {
                    foreach (var description in apiVersionDescriptionProvider!.ApiVersionDescriptions)
                    {
                        var version = string.Format(swaggerConfiguration.Version, description.ApiVersion);
                        options.SwaggerDoc(description.GroupName, CreateVersionInfo(description, swaggerConfiguration, version, webHostEnvironment));
                    }

                    var documentationFiles = GetApiXmlFiles();
                    if (documentationFiles.Any())
                    {
                        documentationFiles.ForEach(documentationFile => options.IncludeXmlComments(Combining(documentationFile)));
                    }

                    options.UseInlineDefinitionsForEnums();
                    options.UseDateOnlyTimeOnlyStringConverters();
                    options.EnableAnnotations();

                    options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
                    {
                        Description = "Jwt Authorization Header Using Bearer Scheme.\n" +
                                      "Enter 'Bearer' [space] and then your token in the text input below\n" +
                                      "Example: \"Bearer 1231861686016816518a6w1d68as1d86as4d\"",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = JwtBearerDefaults.AuthenticationScheme
                    });

                    options.MapIds();

                    options.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = JwtBearerDefaults.AuthenticationScheme
                                },
                                Scheme = "oauth2",
                                Name = JwtBearerDefaults.AuthenticationScheme,
                                In = ParameterLocation.Header
                            },
                            new List<string>()
                        }
                    });
                });
            }
        }

        /// <summary>
        /// the custom swagger middleware
        /// </summary>
        /// <param name="app"></param>
        /// <param name="swaggerConfigurationSectionName">it's optional with a default value called 'Swagger'
        /// ,then it will load the default setting form appsettings.json</param>
        public static void UseSwaggerTool(this IApplicationBuilder app, string swaggerConfigurationSectionName = "Swagger")
        {
            var serviceProvider = app.ApplicationServices.CreateScope().ServiceProvider;
            var configurations = serviceProvider.GetService<IConfiguration>();
            var swaggerConfiguration = configurations!.GetSection(swaggerConfigurationSectionName).Get<SwaggerConfiguration>();
            var apiVersionDescriptionProvider = serviceProvider.GetService<IApiVersionDescriptionProvider>();

            if (swaggerConfiguration!.Enabled)
            {
                app.UseSwagger();

                app.UseSwaggerUI(option =>
                {
                    option.DefaultModelsExpandDepth(-1);
                    option.EnableDeepLinking();
                    option.DocumentTitle = swaggerConfiguration.Title;

                    foreach (var description in apiVersionDescriptionProvider!.ApiVersionDescriptions)
                    {
                        var version = string.Format(swaggerConfiguration.Version, description.ApiVersion);
                        option.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", $"{swaggerConfiguration.Title} {version}");
                    }

                    option.AddHierarchySupport();
                });
            }

            if (swaggerConfiguration.EnableReDoc)
            {
                app.UseReDoc(c =>
                {
                    foreach (var description in apiVersionDescriptionProvider!.ApiVersionDescriptions)
                    {
                        var version = string.Format(swaggerConfiguration.Version, description.ApiVersion);

                        c.SpecUrl = $"/swagger/{description.GroupName}/swagger.json";
                        c.DocumentTitle = $"{swaggerConfiguration.Title} {version}";
                        c.RoutePrefix = $"{swaggerConfiguration.ReDocUrl}-{description.GroupName}";
                    }
                });
            }
        }

        private static string Combining(string xmlFileName)
        {
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
            return xmlPath;
        }

        /// <summary>
        /// Create information about the version of the API
        /// </summary>
        /// <param name="description"></param>
        /// <param name="swaggerConfiguration"></param>
        /// <param name="version"></param>
        /// <param name="environment"></param>
        /// <returns>Information about the API</returns>
        private static OpenApiInfo CreateVersionInfo(ApiVersionDescription description, SwaggerConfiguration swaggerConfiguration, string version, IWebHostEnvironment environment)
        {
            var info = new OpenApiInfo
            {
                Title = $"{swaggerConfiguration.Title} {version}",
                Version = $"v{description.ApiVersion}",
                Description = $"{swaggerConfiguration.Description} <br/><br/> <strong>Build Number</strong> {swaggerConfiguration.Build}. <br/><strong>Environment</strong> {environment.EnvironmentName}",
                TermsOfService = new Uri(swaggerConfiguration.TermsOfService),
                License = new OpenApiLicense
                {
                    Name = swaggerConfiguration.License.Name,
                    Url = new Uri(swaggerConfiguration.License.Url)
                },
                Contact = new OpenApiContact
                {
                    Name = swaggerConfiguration.Contact.Name,
                    Email = swaggerConfiguration.Contact.Email,
                    Url = new Uri(swaggerConfiguration.Contact.Url)
                }
            };

            if (description.IsDeprecated)
            {
                info.Description += " This API version has been deprecated. Please use one of the new APIs available from the explorer.";
            }

            return info;
        }

        private static List<string> GetApiXmlFiles()
        {
            var apiXmlFiles = new List<string>();

            try
            {
                string startupDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location);
                string[] files = Directory.GetFiles(startupDirectory!, "*.api.xml", SearchOption.AllDirectories);
                apiXmlFiles.AddRange(files);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the scanning process
                Console.WriteLine("An error occurred while scanning files: " + ex.Message);
            }

            return apiXmlFiles;
        }
    }
}
