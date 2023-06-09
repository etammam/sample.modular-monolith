using System;
using System.Linq;
using System.Reflection;
using Akka.Actor;
using Akka.Cluster;
using Akka.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Samples.ModularMonolith.Communications.Abstractions.Configurations;

namespace Samples.ModularMonolith.Communications.Abstractions;

public static class ActorSystemRegistration
{
    public static void RegisterActorSystem(this IServiceCollection services, string actorSystemName, Type[] actorTypes)
    {
        var serviceProvider = services.BuildServiceProvider().CreateScope();

        var actorConfigurations = new ActorConfigurations();
        var configuration = serviceProvider.ServiceProvider.GetRequiredService<IConfiguration>();
        configuration.Bind("Actors", actorConfigurations);
        services.AddSingleton(actorConfigurations);

        var actorSystemConfiguration = actorConfigurations.Modules.SingleOrDefault(module => module.Name == actorSystemName);
        if (actorSystemConfiguration == null)
            throw new ArgumentException(message: $"miss actor system configuration for {actorSystemName}");

        int port = actorSystemConfiguration.Port;
        string host = actorSystemConfiguration.Host;

        // Configure the actor system
        var config = ConfigurationFactory.ParseString($@"
            akka {{
                actor.provider = cluster
                remote {{
                    dot-netty.tcp {{
                        port = {port},
                        hostname = {host}
                    }}
                }}
            }}");

        var actorSystem = ActorSystem.Create(actorSystemName, config);
        var cluster = Cluster.Get(actorSystem);
        services.AddSingleton(actorSystem);
        services.AddSingleton(cluster);

        foreach (var actorType in actorTypes)
        {
            bool hasAttribute = actorType.GetCustomAttributes(typeof(ActorNameAttribute), true).Any();
            if (!hasAttribute)
                throw new ArgumentException(message: $"{actorType.Name} should has an {nameof(ActorNameAttribute)}");
            var actorName = actorType.GetCustomAttribute<ActorNameAttribute>()?.ActorName;
            var actorProps = Props.Create(actorType, serviceProvider);
            actorSystem.ActorOf(actorProps, actorName);
        }
    }
    public static void RegisterActorSystem(this IServiceCollection services, string actorSystemName, Type[] actorTypes, string configurationSectionName)
    {
        var serviceProvider = services.BuildServiceProvider().CreateScope();

        var actorConfigurations = new ActorConfigurations();
        var configuration = serviceProvider.ServiceProvider.GetRequiredService<IConfiguration>();
        configuration.Bind(configurationSectionName, actorConfigurations);
        services.AddSingleton(actorConfigurations);

        var actorSystemConfiguration = actorConfigurations.Modules.SingleOrDefault(module => module.Name == actorSystemName);
        if (actorSystemConfiguration == null)
            throw new ArgumentException(message: $"actor configuration missed for: {actorSystemName}");

        int port = actorSystemConfiguration.Port;
        string host = actorSystemConfiguration.Host;

        // Configure the actor system
        var config = ConfigurationFactory.ParseString($@"
            akka {{
                actor.provider = cluster
                remote {{
                    dot-netty.tcp {{
                        port = {port},
                        hostname = {host}
                    }}
                }}
            }}");

        var actorSystem = ActorSystem.Create(actorSystemName, config);
        var cluster = Cluster.Get(actorSystem);
        services.AddSingleton(actorSystem);
        services.AddSingleton(cluster);

        foreach (var actorType in actorTypes)
        {
            bool hasAttribute = actorType.GetCustomAttributes(typeof(ActorNameAttribute), true).Any();
            if (!hasAttribute)
                throw new ArgumentException(message: $"{actorType.Name} should has an {nameof(ActorNameAttribute)}");
            var actorName = actorType.GetCustomAttribute<ActorNameAttribute>()?.ActorName;
            var actorProps = Props.Create(actorType, serviceProvider);
            actorSystem.ActorOf(actorProps, actorName);
        }
    }
}