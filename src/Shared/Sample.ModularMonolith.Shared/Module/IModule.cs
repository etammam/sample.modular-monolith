using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Sample.ModularMonolith.Shared.Module;

public interface IModule
{
    string Name { get; }

    void Add(IServiceCollection services);

    void Use(IApplicationBuilder app);

    void UseHubs(WebApplication app);
}