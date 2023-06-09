using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Sample.ModularMonolith.Shared.Module;

public class ModuleLoader
{
    public static IList<Assembly> LoadAssemblies()
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();

        var locations = assemblies.Where(x => x.IsDynamic == false).Select(x => x.Location).ToArray();

        var files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll")
            .Where(x => !locations.Contains(x, StringComparer.InvariantCultureIgnoreCase))
            .ToList();

        files.ForEach(x => assemblies.Add(AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(x))));

        return assemblies;
    }

    public static IList<IModule> LoadModules(Assembly[] assemblies)
    {
        if (assemblies.Any())
        {
            return assemblies.Where(c => c.FullName!.StartsWith(nameof(Sample), StringComparison.OrdinalIgnoreCase))
                .SelectMany(x => x.GetTypes())
                .Where(x => typeof(IModule).IsAssignableFrom(x) && !x.IsInterface)
                .OrderBy(x => x.Name)
                .Select(Activator.CreateInstance)
                .Cast<IModule>()
                .ToList();
        }

        return new List<IModule>();
    }
}