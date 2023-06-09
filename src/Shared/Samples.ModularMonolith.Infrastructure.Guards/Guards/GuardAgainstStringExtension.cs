using JetBrains.Annotations;
using Samples.ModularMonolith.Domain.Shared.Exceptions.Common;
using Samples.ModularMonolith.Infrastructure.Guards.Guards.Abstractions;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Samples.ModularMonolith.Infrastructure.Guards.Guards
{
    public static partial class GuardExtensions
    {
        private const string NumbersOnlyRegex = "^[0-9]*$";

        /// <summary>
        /// check if this string contains only numbers.
        /// </summary>
        /// <param name="guard"></param>
        /// <param name="input"></param>
        /// <param name="parameterName"></param>
        /// <param name="message"></param>
        /// <param name="errorCode"></param>
        /// <returns><paramref name="input" /> if the value contains only numbers.</returns>
        /// <exception cref="StringConditionException"></exception>
        public static string IfNumbersOnly(this IGuard guard,
            [ValidatedNotNull] string input,
            [InvokerParameterName] [CallerArgumentExpression("input")]
            string parameterName = null,
            string message = null,
            string errorCode = null)
        {
            Guard.Check.IfNullOrEmpty(input, parameterName, message, errorCode);
            Guard.Check.IfNullOrWhiteSpace(input, parameterName, message, errorCode);

            var containsOnlyNumbers = ContainsNumberOnly(input);
            if (!containsOnlyNumbers)
            {
                if (string.IsNullOrEmpty(message))
                    throw new StringConditionException();

                throw new StringConditionException(parameterName, message, errorCode);
            }

            return input;
        }

        private static bool ContainsNumberOnly(this string input)
        {
            var regex = new Regex(NumbersOnlyRegex);
            return regex.IsMatch(input);
        }
    }
}
