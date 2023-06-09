using Samples.ModularMonolith.Domain.Shared.Exceptions.Common;
using Samples.ModularMonolith.Infrastructure.Guards.Guards.Abstractions;
using System;
using System.Runtime.CompilerServices;
using JetBrainsInvokerParameterNameAttribute = JetBrains.Annotations.InvokerParameterNameAttribute;

namespace Samples.ModularMonolith.Infrastructure.Guards.Guards
{
    public static partial class GuardExtensions
    {
        /// <summary>
        ///     Throws an <see cref="InvalidArgumentException" /> if <paramref name="input" /> is negative.
        /// </summary>
        /// <param name="guard"></param>
        /// <param name="input"></param>
        /// <param name="parameterName"></param>
        /// <param name="message">Optional. Custom error message</param>
        /// <param name="errorCode">Optional. Custom error code</param>
        /// <returns><paramref name="input" /> if the value is not negative.</returns>
        /// <exception cref="InvalidArgumentException"></exception>
        public static int IfNegative(this IGuard guard,
            int input,
            [JetBrainsInvokerParameterName] [CallerArgumentExpression("input")]
            string parameterName = null,
            string message = null,
            string errorCode = null)
        {
            return IfNegative(input, parameterName, message, errorCode);
        }

        /// <summary>
        ///     Throws an <see cref="InvalidArgumentException" /> if <paramref name="input" /> is negative.
        /// </summary>
        /// <param name="guard"></param>
        /// <param name="input"></param>
        /// <param name="parameterName"></param>
        /// <param name="message">Optional. Custom error message</param>
        /// <returns><paramref name="input" /> if the value is not negative.</returns>
        /// <exception cref="InvalidArgumentException"></exception>
        public static long IfNegative(this IGuard guard,
            long input,
            [JetBrainsInvokerParameterName] [CallerArgumentExpression("input")]
            string parameterName = null,
            string message = null)
        {
            return IfNegative(input, parameterName, message);
        }

        /// <summary>
        ///     Throws an <see cref="InvalidArgumentException" /> if <paramref name="input" /> is negative.
        /// </summary>
        /// <param name="guard"></param>
        /// <param name="input"></param>
        /// <param name="parameterName"></param>
        /// <param name="message">Optional. Custom error message</param>
        /// <returns><paramref name="input" /> if the value is not negative.</returns>
        /// <exception cref="InvalidArgumentException"></exception>
        public static decimal IfNegative(this IGuard guard,
            decimal input,
            [JetBrainsInvokerParameterName] [CallerArgumentExpression("input")]
            string parameterName = null,
            string message = null)
        {
            return IfNegative(input, parameterName, message);
        }

        /// <summary>
        ///     Throws an <see cref="InvalidArgumentException" /> if <paramref name="input" /> is negative.
        /// </summary>
        /// <param name="guard"></param>
        /// <param name="input"></param>
        /// <param name="parameterName"></param>
        /// <param name="message">Optional. Custom error message</param>
        /// <returns><paramref name="input" /> if the value is not negative.</returns>
        /// <exception cref="InvalidArgumentException"></exception>
        public static float IfNegative(this IGuard guard,
            float input,
            [JetBrainsInvokerParameterName] [CallerArgumentExpression("input")]
            string parameterName = null,
            string message = null)
        {
            return IfNegative(input, parameterName, message);
        }

        /// <summary>
        ///     Throws an <see cref="InvalidArgumentException" /> if <paramref name="input" /> is negative.
        /// </summary>
        /// <param name="guard"></param>
        /// <param name="input"></param>
        /// <param name="parameterName"></param>
        /// <param name="message">Optional. Custom error message</param>
        /// <returns><paramref name="input" /> if the value is not negative.</returns>
        /// <exception cref="InvalidArgumentException"></exception>
        public static double IfNegative(this IGuard guard,
            double input,
            [JetBrainsInvokerParameterName] [CallerArgumentExpression("input")]
            string parameterName = null,
            string message = null)
        {
            return IfNegative(input, parameterName, message);
        }

        /// <summary>
        ///     Throws an <see cref="InvalidArgumentException" /> if <paramref name="input" /> is negative.
        /// </summary>
        /// <param name="guard"></param>
        /// <param name="input"></param>
        /// <param name="parameterName"></param>
        /// <param name="message">Optional. Custom error message</param>
        /// <returns><paramref name="input" /> if the value is not negative.</returns>
        /// <exception cref="InvalidArgumentException"></exception>
        public static TimeSpan IfNegative(this IGuard guard,
            TimeSpan input,
            [JetBrainsInvokerParameterName] [CallerArgumentExpression("input")]
            string parameterName = null,
            string message = null)
        {
            return IfNegative(input, parameterName, message);
        }

        /// <summary>
        ///     Throws an <see cref="InvalidArgumentException" /> if <paramref name="input" /> is negative or zero.
        /// </summary>
        /// <param name="guard"></param>
        /// <param name="input"></param>
        /// <param name="parameterName"></param>
        /// <param name="message">Optional. Custom error message</param>
        /// <param name="errorCode">Optional. Custom error code</param>
        /// <returns><paramref name="input" /> if the value is not negative or zero.</returns>
        public static int NegativeOrZero(this IGuard guard,
            int input,
            [JetBrainsInvokerParameterName] [CallerArgumentExpression("input")]
            string parameterName = null,
            string message = null,
            string errorCode = null)
        {
            return NegativeOrZero(input, parameterName, message, errorCode);
        }

        /// <summary>
        ///     Throws an <see cref="InvalidArgumentException" /> if <paramref name="input" /> is negative or zero.
        /// </summary>
        /// <param name="guard"></param>
        /// <param name="input"></param>
        /// <param name="parameterName"></param>
        /// <param name="message">Optional. Custom error message</param>
        /// <returns><paramref name="input" /> if the value is not negative or zero.</returns>
        public static long NegativeOrZero(this IGuard guard,
            long input,
            [JetBrainsInvokerParameterName] [CallerArgumentExpression("input")]
            string parameterName = null,
            string message = null)
        {
            return NegativeOrZero(input, parameterName, message);
        }

        /// <summary>
        ///     Throws an <see cref="InvalidArgumentException" /> if <paramref name="input" /> is negative or zero.
        /// </summary>
        /// <param name="guard"></param>
        /// <param name="input"></param>
        /// <param name="parameterName"></param>
        /// <param name="message">Optional. Custom error message</param>
        /// <returns><paramref name="input" /> if the value is not negative or zero.</returns>
        public static decimal NegativeOrZero(this IGuard guard,
            decimal input,
            [JetBrainsInvokerParameterName] [CallerArgumentExpression("input")]
            string parameterName = null,
            string message = null)
        {
            return NegativeOrZero(input, parameterName, message);
        }

        /// <summary>
        ///     Throws an <see cref="InvalidArgumentException" /> if <paramref name="input" /> is negative or zero.
        /// </summary>
        /// <param name="guard"></param>
        /// <param name="input"></param>
        /// <param name="parameterName"></param>
        /// <param name="message">Optional. Custom error message</param>
        /// <returns><paramref name="input" /> if the value is not negative or zero.</returns>
        public static float NegativeOrZero(this IGuard guard,
            float input,
            [JetBrainsInvokerParameterName] [CallerArgumentExpression("input")]
            string parameterName = null,
            string message = null)
        {
            return NegativeOrZero(input, parameterName, message);
        }

        /// <summary>
        ///     Throws an <see cref="InvalidArgumentException" /> if <paramref name="input" /> is negative or zero.
        /// </summary>
        /// <param name="guard"></param>
        /// <param name="input"></param>
        /// <param name="parameterName"></param>
        /// <param name="message">Optional. Custom error message</param>
        /// <returns><paramref name="input" /> if the value is not negative or zero.</returns>
        public static double NegativeOrZero(this IGuard guard,
            double input,
            [JetBrainsInvokerParameterName] [CallerArgumentExpression("input")]
            string parameterName = null,
            string message = null)
        {
            return NegativeOrZero(input, parameterName, message);
        }

        /// <summary>
        ///     Throws an <see cref="InvalidArgumentException" /> if <paramref name="input" /> is negative or zero.
        /// </summary>
        /// <param name="guard"></param>
        /// <param name="input"></param>
        /// <param name="parameterName"></param>
        /// <param name="message">Optional. Custom error message</param>
        /// <returns><paramref name="input" /> if the value is not negative or zero.</returns>
        public static TimeSpan NegativeOrZero(this IGuard guard,
            TimeSpan input,
            [JetBrainsInvokerParameterName] [CallerArgumentExpression("input")]
            string parameterName = null,
            string message = null)
        {
            return NegativeOrZero(input, parameterName, message);
        }

        /// <summary>
        ///     Throws an <see cref="InvalidArgumentException" /> if <paramref name="input" /> is negative or zero.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <param name="parameterName"></param>
        /// <param name="message">Optional. Custom error message</param>
        /// <param name="errorCode">Optional. Custom error code</param>
        /// <returns><paramref name="input" /> if the value is not negative or zero.</returns>
        private static T NegativeOrZero<T>(T input,
            [JetBrainsInvokerParameterName] [CallerArgumentExpression("input")]
            string parameterName = null,
            string message = null,
            string errorCode = null)
            where T : struct, IComparable
        {
            if (input.CompareTo(default(T)) <= 0)
            {
                if (string.IsNullOrEmpty(message))
                    throw new InvalidArgumentException();

                throw new InvalidArgumentException(parameterName, message, errorCode);
            }

            return input;
        }

        /// <summary>
        ///     Throws an <see cref="InvalidArgumentException" /> if <paramref name="input" /> is negative.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="parameterName"></param>
        /// <param name="message">Optional. Custom error message</param>
        /// <param name="errorCode">Optional. Custom error code</param>
        /// <returns><paramref name="input" /> if the value is not negative.</returns>
        /// <exception cref="InvalidArgumentException"></exception>
        private static T IfNegative<T>(T input,
            [JetBrainsInvokerParameterName] [CallerArgumentExpression("input")]
            string parameterName = null,
            string message = null,
            string errorCode = null)
            where T : struct, IComparable
        {
            if (input.CompareTo(default(T)) < 0)
            {
                if (string.IsNullOrEmpty(message))
                    throw new InvalidArgumentException();

                throw new InvalidArgumentException(parameterName, message, errorCode);
            }

            return input;
        }
    }
}
