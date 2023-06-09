using System;

namespace Samples.ModularMonolith.Infrastructure.Guards.Guards.Abstractions
{
    /// <summary>
    ///     Add to methods that check input for null and throw if the input is null.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
    public sealed class ValidatedNotNullAttribute : Attribute
    {
    }
}
