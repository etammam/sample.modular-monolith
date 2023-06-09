using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace Samples.ModularMonolith.Infrastructure.Persistence.Extension;

public static class SequenceConventionExtension
{
    public static void UseSequenceConvention(this ModelBuilder modelBuilder, Type assemblyFromType)
    {
        var entities =
            Assembly.GetAssembly(assemblyFromType)
                ?.GetTypes().Where(type =>
                    type.IsClass && !type.IsAbstract && type.IsSubclassOf(typeof(BaseEntity)));
        var sequences = modelBuilder.Model.GetSequences().ToList();
        if (entities != null)
        {
            foreach (var entity in from entity in entities
                                   where !(sequences.Count > 0 && sequences.Any(d => d.Name == entity.Name.GetSequenceName()))
                                   select entity)
            {
                modelBuilder.HasSequence<int>(entity.Name.GetSequenceName(), "dbo")
                    .StartsAt(1)
                    .HasMin(1)
                    .IncrementsBy(1);
                modelBuilder.Entity(entity).Property("SerialNumber")
                    .HasDefaultValueSql($"NEXT VALUE FOR dbo.{entity.Name.GetSequenceName()}");
            }
        }
    }

    private static string GetSequenceName(this string entity)
    {
        return $"Serial_{entity}";
    }
}