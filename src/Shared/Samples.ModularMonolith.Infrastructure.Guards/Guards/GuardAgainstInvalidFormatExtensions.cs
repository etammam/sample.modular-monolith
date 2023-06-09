using Samples.ModularMonolith.Domain.Shared.Exceptions.Common;
using Samples.ModularMonolith.Infrastructure.Guards.Guards.Abstractions;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using JetBrainsInvokerParameterNameAttribute = JetBrains.Annotations.InvokerParameterNameAttribute;
using JetBrainsRegexPattern = JetBrains.Annotations.RegexPatternAttribute;

namespace Samples.ModularMonolith.Infrastructure.Guards.Guards
{
    public static partial class GuardExtensions
    {
        /// <summary>
        ///     Throws an <see cref="InvalidArgumentException" /> if  <paramref name="input" /> doesn't match the
        ///     <paramref name="regexPattern" />.
        /// </summary>
        /// <param name="guard"></param>
        /// <param name="input"></param>
        /// <param name="parameterName"></param>
        /// <param name="regexPattern"></param>
        /// <param name="message">Optional. Custom error message</param>
        /// <param name="errorCode">Optional. Custom error code</param>
        /// <returns><paramref name="input" /> if the value is match the <paramref name="regexPattern" />.</returns>
        /// <exception cref="InvalidArgumentException"></exception>
        public static string IfInvalidFormat(this IGuard guard,
            string input,
            [JetBrainsInvokerParameterName] string parameterName,
            [JetBrainsRegexPattern] string regexPattern,
            string message = null,
            string errorCode = null)
        {
            var match = Regex.Match(input, regexPattern);
            if (!match.Success || input != match.Value)
            {
                if (string.IsNullOrEmpty(message))
                    throw new InvalidArgumentException();

                throw new InvalidArgumentException(parameterName, message, errorCode);
            }

            return input;
        }

        /// <summary>
        ///     Throws an <see cref="InvalidArgumentException" /> if  <paramref name="input" /> doesn't satisfy the
        ///     <paramref name="predicate" /> function.
        /// </summary>
        /// <param name="guard"></param>
        /// <param name="input"></param>
        /// <param name="parameterName"></param>
        /// <param name="predicate"></param>
        /// <param name="message">Optional. Custom error message</param>
        /// <param name="errorCode">Optional. Custom error code</param>
        /// <typeparam name="T"></typeparam>
        /// <returns><paramref name="input" /> if the value is satisfy the <paramref name="predicate" /> function.</returns>
        /// <exception cref="InvalidArgumentException"></exception>
        public static T IfInvalidInput<T>(this IGuard guard,
            [DisallowNull] T input,
            [JetBrainsInvokerParameterName] string parameterName,
            Func<T, bool> predicate,
            string message = null,
            string errorCode = null)
        {
            if (!predicate(input))
            {
                if (string.IsNullOrEmpty(message))
                    throw new InvalidArgumentException();

                throw new InvalidArgumentException(parameterName, message, errorCode);
            }

            return input;
        }
    }
}
