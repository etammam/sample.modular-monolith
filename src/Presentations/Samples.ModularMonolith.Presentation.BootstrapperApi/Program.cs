using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sample.ModularMonolith.Shared;
using Sample.ModularMonolith.Shared.Module;
using Samples.ModularMonolith.Infrastructure.Presentation.Middleware.Exceptions;
using Samples.ModularMonolith.Infrastructure.Presentation.Swagger;
using System.Linq;
using System.Text.Json.Serialization;

namespace Samples.ModularMonolith.Presentation.BootstrapperApi;

/// <summary>
/// the entry point of bootstrapper application
/// </summary>
public class Program
{
    /// <summary>
    /// the main function of application.
    /// </summary>
    /// <param name="args"></param>
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Configuration.AddJsonFile("appsettings.local.json", true, true);

        builder.Services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });

        var configuration = builder.Configuration;
        builder.Services.AddShared(configuration);

        var assemblies = ModuleLoader.LoadAssemblies();
        var modules = ModuleLoader.LoadModules(assemblies.ToArray());

        modules.ToList().ForEach(m => m.Add(builder.Services));

        var app = builder.Build();

        app.UseExceptionMiddleware();
        app.UseShared(builder.Services);
        modules.ToList().ForEach(m => m.Use(app));
        app.UseSwaggerTool();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();

        assemblies.Clear();
        modules.Clear();

        app.Run();
    }
}

