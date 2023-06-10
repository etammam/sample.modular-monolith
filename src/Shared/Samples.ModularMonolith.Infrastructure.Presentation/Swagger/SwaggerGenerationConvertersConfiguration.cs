using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Samples.ModularMonolith.Domain.Shared.Primitives;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;

namespace Samples.ModularMonolith.Infrastructure.Presentation.Swagger;

internal static class SwaggerGenerationConvertersConfiguration
{
    internal static void MapIds(this SwaggerGenOptions swaggerGenOptions)
    {
        swaggerGenOptions.MapType(typeof(CustomerId), () => new OpenApiSchema
        {
            Type = "string",
            Example = new OpenApiString(Guid.NewGuid().ToString())
        });
    }
}
