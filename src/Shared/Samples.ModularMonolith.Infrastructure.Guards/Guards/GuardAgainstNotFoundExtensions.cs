using Samples.ModularMonolith.Domain.Shared.Exceptions.Common;
using Samples.ModularMonolith.Infrastructure.Guards.Guards.Abstractions;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using JetBrainsNoEnumerationAttribute = JetBrains.Annotations.NoEnumerationAttribute;

namespace Samples.ModularMonolith.Infrastructure.Guards.Guards
{
    public static partial class GuardExtensions
    {
        /// <summary>
        /// Throws an <see cref="NotFoundException" /> if <paramref name="input" /> is not found.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="guard"></param>
        /// <param name="input"></param>
        /// <param name="parameterName"></param>
        /// <param name="message"></param>
        /// <param name="errorCode"></param>
        /// <returns><paramref name="input" /> if the value is not null.</returns>
        /// <exception cref="NotFoundException"></exception>
        public static T IfNotFound<T>(this IGuard guard,
            [DisallowNull] [NotNull] [ValidatedNotNull] [JetBrainsNoEnumeration]
            T input,
            [CallerArgumentExpression("input")]
            string parameterName = null,
            string message = null,
            string errorCode = null)
        {
            if (input is null)
            {
                if (string.IsNullOrEmpty(message))
                    throw new NotFoundException();

                throw new NotFoundException(parameterName, message, errorCode);
            }

            return input;
        }
    }
}
