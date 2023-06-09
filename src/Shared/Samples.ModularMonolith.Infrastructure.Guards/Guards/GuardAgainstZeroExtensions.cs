using Samples.ModularMonolith.Domain.Shared.Exceptions.Common;
using Samples.ModularMonolith.Infrastructure.Guards.Guards.Abstractions;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrainsInvokerParameterNameAttribute = JetBrains.Annotations.InvokerParameterNameAttribute;

namespace Samples.ModularMonolith.Infrastructure.Guards.Guards
{
    public static partial class GuardExtensions
    {
        /// <summary>
        ///     Throws an <see cref="ArgumentException" /> if <paramref name="input" /> is zero.
        /// </summary>
        /// <param name="guard"></param>
        /// <param name="input"></param>
        /// <param name="parameterName"></param>
        /// <param name="message">Optional. Custom error message</param>
        /// <param name="errorCode">Optional. Custom error code</param>
        /// <returns><paramref name="input" /> if the value is not zero.</returns>
        /// <exception cref="ArgumentException"></exception>
        public static int IfZero(this IGuard guard,
            int input,
            [JetBrainsInvokerParameterName] [CallerArgumentExpression("input")]
            string parameterName = null,
            string message = null,
            string errorCode = null)
        {
            return Zero(input, parameterName, message, errorCode);
        }

        /// <summary>
        ///     Throws an <see cref="ArgumentException" /> if <paramref name="input" /> is zero.
        /// </summary>
        /// <param name="guard"></param>
        /// <param name="input"></param>
        /// <param name="parameterName"></param>
        /// <param name="message">Optional. Custom error message</param>
        /// <returns><paramref name="input" /> if the value is not zero.</returns>
        /// <exception cref="ArgumentException"></exception>
        public static long IfZero(this IGuard guard,
            long input,
            [JetBrainsInvokerParameterName] [CallerArgumentExpression("input")]
            string parameterName = null,
            string message = null)
        {
            return Zero(input, parameterName!, message);
        }

        /// <summary>
        ///     Throws an <see cref="ArgumentException" /> if <paramref name="input" /> is zero.
        /// </summary>
        /// <param name="guard"></param>
        /// <param name="input"></param>
        /// <param name="parameterName"></param>
        /// <param name="message">Optional. Custom error message</param>
        /// <returns><paramref name="input" /> if the value is not zero.</returns>
        /// <exception cref="ArgumentException"></exception>
        public static decimal IfZero(this IGuard guard,
            decimal input,
            [JetBrainsInvokerParameterName] [CallerArgumentExpression("input")]
            string parameterName = null,
            string message = null)
        {
            return Zero(input, parameterName!, message);
        }

        /// <summary>
        ///     Throws an <see cref="ArgumentException" /> if <paramref name="input" /> is zero.
        /// </summary>
        /// <param name="guard"></param>
        /// <param name="input"></param>
        /// <param name="parameterName"></param>
        /// <param name="message">Optional. Custom error message</param>
        /// <returns><paramref name="input" /> if the value is not zero.</returns>
        /// <exception cref="ArgumentException"></exception>
        public static float IfZero(this IGuard guard,
            float input,
            [JetBrainsInvokerParameterName] [CallerArgumentExpression("input")]
            string parameterName = null,
            string message = null)
        {
            return Zero(input, parameterName!, message);
        }

        /// <summary>
        ///     Throws an <see cref="ArgumentException" /> if <paramref name="input" /> is zero.
        /// </summary>
        /// <param name="guard"></param>
        /// <param name="input"></param>
        /// <param name="parameterName"></param>
        /// <param name="message">Optional. Custom error message</param>
        /// <returns><paramref name="input" /> if the value is not zero.</returns>
        /// <exception cref="ArgumentException"></exception>
        public static double IfZero(this IGuard guard,
            double input,
            [JetBrainsInvokerParameterName] [CallerArgumentExpression("input")]
            string parameterName = null,
            string message = null)
        {
            return Zero(input, parameterName!, message);
        }

        /// <summary>
        ///     Throws an <see cref="ArgumentException" /> if <paramref name="input" /> is zero.
        /// </summary>
        /// <param name="guard"></param>
        /// <param name="input"></param>
        /// <param name="parameterName"></param>
        /// <returns><paramref name="input" /> if the value is not zero.</returns>
        /// <exception cref="ArgumentException"></exception>
        public static TimeSpan IfZero(this IGuard guard,
            TimeSpan input,
            [JetBrainsInvokerParameterName] [CallerArgumentExpression("input")]
            string parameterName = null)
        {
            return Zero(input, parameterName!);
        }

        /// <summary>
        ///     Throws an <see cref="ArgumentException" /> if <paramref name="input" /> is zero.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="parameterName"></param>
        /// <param name="message">Optional. Custom error message</param>
        /// <param name="errorCode">Optional. Custom error code</param>
        /// <returns><paramref name="input" /> if the value is not zero.</returns>
        /// <exception cref="ArgumentException"></exception>
        private static T Zero<T>(T input,
            [JetBrainsInvokerParameterName] string parameterName,
            string message = null,
            string errorCode = null)
            where T : struct
        {
            if (EqualityComparer<T>.Default.Equals(input, default))
            {
                if (string.IsNullOrEmpty(message))
                    throw new InvalidArgumentException();

                throw new InvalidArgumentException(parameterName, message, errorCode);
            }

            return input;
        }
    }
}
