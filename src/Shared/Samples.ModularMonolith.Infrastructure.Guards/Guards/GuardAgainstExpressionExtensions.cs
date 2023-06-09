using Samples.ModularMonolith.Domain.Shared.Exceptions.Common;
using Samples.ModularMonolith.Infrastructure.Guards.Guards.Abstractions;
using System;

namespace Samples.ModularMonolith.Infrastructure.Guards.Guards
{
    public static partial class GuardExtensions
    {
        /// <summary>
        ///     Throws an <see cref="InvalidArgumentException" /> if <paramref name="func" /> evaluates to false for given
        ///     <paramref name="input" />
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="guard"></param>
        /// <param name="input"></param>
        /// <param name="func"></param>
        /// <param name="message"></param>
        /// <param name="errorCode"></param>
        /// <returns><paramref name="input" /> if the <paramref name="func" /> evaluates to true </returns>
        /// <exception cref="InvalidArgumentException"></exception>
        public static T IfAgainstExpression<T>(this IGuard guard,
            T input,
            Func<T, bool> func,
            string message = null,
            string errorCode = null)
        {
            if (!func(input))
            {
                if (string.IsNullOrEmpty(message))
                    throw new InvalidArgumentException();

                throw new InvalidArgumentException(message, errorCode);
            }

            return input;
        }
    }
}
