using JetBrains.Annotations;
using Samples.ModularMonolith.Domain.Shared.Exceptions.Common;
using Samples.ModularMonolith.Infrastructure.Guards.Guards.Abstractions;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Samples.ModularMonolith.Infrastructure.Guards.Guards
{
    public static partial class GuardExtensions
    {
        /// <summary>
        /// check if the phone number match the egyptian phone sequence.
        /// </summary>
        /// <param name="guard"></param>
        /// <param name="input"></param>
        /// <param name="parameterName"></param>
        /// <param name="message"></param>
        /// <returns><paramref name="input" /> if the value is match the egyptian phone sequence.</returns>
        /// <exception cref="PhoneNumberException"></exception>
        public static string IfNotValidEgyptPhoneNumber(this IGuard guard,
            [ValidatedNotNull] string input,
            [InvokerParameterName] [CallerArgumentExpression("input")]
            string parameterName = null,
            string message = null)
        {
            if (!IsValidPhoneNumber(input))
                throw new PhoneNumberException();

            return input;
        }

        /// <summary>
        /// check if the phone number match the egyptian phone sequence.
        /// </summary>
        /// <param name="guard"></param>
        /// <param name="input"></param>
        /// <param name="parameterName"></param>
        /// <param name="message"></param>
        /// <returns><paramref name="input" /> if the value is match the egyptian phone sequence.</returns>
        /// <exception cref="PhoneNumberException"></exception>
        public static int IfNotValidEgyptPhoneNumber(this IGuard guard,
            [ValidatedNotNull] int input,
            [InvokerParameterName] [CallerArgumentExpression("input")]
            string parameterName = null,
            string message = null)
        {
            Guard.Check.IfZero(input);
            Guard.Check.IfNegative(input);
            if (!IsValidPhoneNumber(input))
                throw new PhoneNumberException();

            return input;
        }

        private static bool IsValidPhoneNumber(int phoneNumber)
        {
            return Regex.IsMatch(phoneNumber.ToString(), "^01[0125][0-9]{8}$");
        }

        private static bool IsValidPhoneNumber(string phoneNumber)
        {
            return Regex.IsMatch(phoneNumber, "^01[0125][0-9]{8}$");
        }
    }
}
