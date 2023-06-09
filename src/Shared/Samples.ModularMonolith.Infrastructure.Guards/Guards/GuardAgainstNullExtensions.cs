using Samples.ModularMonolith.Domain.Shared.Exceptions.Common;
using Samples.ModularMonolith.Infrastructure.Guards.Guards.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using JetBrainsInvokerParameterNameAttribute = JetBrains.Annotations.InvokerParameterNameAttribute;
using JetBrainsNoEnumerationAttribute = JetBrains.Annotations.NoEnumerationAttribute;

namespace Samples.ModularMonolith.Infrastructure.Guards.Guards
{
    /// <summary>
    ///     A collection of common guard clauses, implemented as extensions.
    /// </summary>
    /// <example>
    ///     Guard.Against.IfNull(input, nameof(input));
    /// </example>
    public static partial class GuardExtensions
    {
        /// <summary>
        ///     Throws an <see cref="NullException" /> if <paramref name="input" /> is null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="guard"></param>
        /// <param name="input"></param>
        /// <param name="parameterName"></param>
        /// <param name="message">Optional. Custom error message</param>
        /// <param name="errorCode">Optional. Custom error code</param>
        /// <returns><paramref name="input" /> if the value is not null.</returns>
        public static T IfNull<T>(this IGuard guard,
            [DisallowNull] [NotNull] [ValidatedNotNull] [JetBrainsNoEnumeration]
            T input,
            [JetBrainsInvokerParameterName] [CallerArgumentExpression("input")]
            string parameterName = null,
            string message = null,
            string errorCode = null)
        {
            if (input is null)
            {
                if (string.IsNullOrEmpty(message))
                    throw new NullException();

                throw new NullException(parameterName, message, errorCode);
            }

            return input;
        }

        /// <summary>
        ///     Throws an <see cref="NullException" /> if <paramref name="input" /> is null.
        ///     Throws an <see cref="EmptyException" /> if <paramref name="input" /> is an empty string.
        /// </summary>
        /// <param name="guard"></param>
        /// <param name="input"></param>
        /// <param name="parameterName"></param>
        /// <param name="message">Optional. Custom error message</param>
        /// <param name="errorCode">Optional. Custom error code</param>
        /// <returns><paramref name="input" /> if the value is not an empty string or null.</returns>
        /// <exception cref="EmptyException"></exception>
        public static string IfNullOrEmpty(this IGuard guard,
            [ValidatedNotNull] string input,
            [JetBrainsInvokerParameterName] [CallerArgumentExpression("input")]
            string parameterName = null,
            string message = null,
            string errorCode = null)
        {
            Guard.Check.IfNull(input, parameterName, message, errorCode);
            if (input == string.Empty)
            {
                if (string.IsNullOrEmpty(message))
                    throw new EmptyException();

                throw new EmptyException(parameterName, message, errorCode);
            }

            return input;
        }

        /// <summary>
        ///     Throws an <see cref="NullException" /> if <paramref name="input" /> is null.
        ///     Throws an <see cref="EmptyException" /> if <paramref name="input" /> is an empty enumerable.
        /// </summary>
        /// <param name="guard"></param>
        /// <param name="input"></param>
        /// <param name="parameterName"></param>
        /// <param name="message">Optional. Custom error message</param>
        /// <param name="errorCode">Optional. Custom error code</param>
        /// <returns><paramref name="input" /> if the value is not an empty enumerable or null.</returns>
        /// <exception cref="NullException"></exception>
        /// <exception cref="EmptyException"></exception>
        public static IEnumerable<T> IfNullOrEmpty<T>(this IGuard guard,
            [ValidatedNotNull] IEnumerable<T> input,
            [JetBrainsInvokerParameterName] [CallerArgumentExpression("input")]
            string parameterName = null,
            string message = null,
            string errorCode = null)
        {
            Guard.Check.IfNull(input, parameterName, message, errorCode);
            var nullOrEmpty = input as T[] ?? input.ToArray();
            if (!nullOrEmpty.Any())
            {
                if (string.IsNullOrEmpty(message))
                    throw new EmptyException();

                throw new EmptyException(parameterName, message, errorCode);
            }

            return nullOrEmpty;
        }

        /// <summary>
        ///     Throws an <see cref="NullException" /> if <paramref name="input" /> is null.
        ///     Throws an <see cref="EmptyException" /> if <paramref name="input" /> is an empty or white space string.
        /// </summary>
        /// <param name="guard"></param>
        /// <param name="input"></param>
        /// <param name="parameterName"></param>
        /// <param name="message">Optional. Custom error message</param>
        /// <param name="errorCode">Optional. Custom error code</param>
        /// <returns><paramref name="input" /> if the value is not an empty or whitespace string.</returns>
        /// <exception cref="EmptyException"></exception>
        public static string IfNullOrWhiteSpace(this IGuard guard,
            [ValidatedNotNull] string input,
            [JetBrainsInvokerParameterName] [CallerArgumentExpression("input")]
            string parameterName = null,
            string message = null,
            string errorCode = null)
        {
            Guard.Check.IfNullOrEmpty(input, parameterName, message, errorCode);
            if (string.IsNullOrWhiteSpace(input))
            {
                if (string.IsNullOrEmpty(message))
                    throw new EmptyException();

                throw new EmptyException(parameterName, message, errorCode);
            }

            return input;
        }

        /// <summary>
        ///     Throws an <see cref="InvalidArgumentException" /> if <paramref name="input" /> is default for that type.
        /// </summary>
        /// <param name="guard"></param>
        /// <param name="input"></param>
        /// <param name="parameterName"></param>
        /// <param name="message">Optional. Custom error message</param>
        /// <param name="errorCode">Optional. Custom error code</param>
        /// <returns><paramref name="input" /> if the value is not default for that type.</returns>
        /// <exception cref="InvalidArgumentException"></exception>
        public static T IfDefault<T>(this IGuard guard,
            [DisallowNull] [AllowNull] [NotNull] [JetBrainsNoEnumeration]
            T input,
            [JetBrainsInvokerParameterName] [CallerArgumentExpression("input")]
            string parameterName = null,
            string message = null,
            string errorCode = null)
        {
            if (EqualityComparer<T>.Default.Equals(input, default!) || input is null)
            {
                if (string.IsNullOrEmpty(message))
                    throw new InvalidArgumentException();

                throw new InvalidArgumentException(parameterName, message, errorCode);
            }

            return input;
        }

        /// <summary>
        ///     Throws an <see cref="NullException" /> if <paramref name="input" /> is null
        ///     Throws an <see cref="InvalidArgumentException" /> if <paramref name="input" /> doesn't satisfy the
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
        /// <exception cref="NullException"></exception>
        /// <exception cref="InvalidArgumentException"></exception>
        public static T IfNullOrInvalidInput<T>(this IGuard guard,
            [DisallowNull] T input,
            [JetBrainsInvokerParameterName] string parameterName,
            Func<T, bool> predicate,
            string message = null,
            string errorCode = null)
        {
            Guard.Check.IfNull(input, parameterName, message, errorCode);

            return Guard.Check.IfInvalidInput(input, parameterName, predicate, message, errorCode);
        }
    }
}
