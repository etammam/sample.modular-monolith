using JetBrains.Annotations;
using Samples.ModularMonolith.Domain.Shared.Exceptions.Common;
using Samples.ModularMonolith.Infrastructure.Guards.Guards.Abstractions;
using System.Net.Mail;
using System.Runtime.CompilerServices;

namespace Samples.ModularMonolith.Infrastructure.Guards.Guards
{
    public static partial class GuardExtensions
    {
        /// <summary>
        /// check if the email in correct format
        /// </summary>
        /// <param name="guard"></param>
        /// <param name="input"></param>
        /// <param name="parameterName"></param>
        /// <param name="message"></param>
        /// <param name="errorCode"></param>
        /// <returns><paramref name="input" /> if the value is valid email address.</returns>
        /// <exception cref="EmptyException"></exception>
        /// <exception cref="EmailException"></exception>
        public static string IfNotValidEmailAddress(this IGuard guard,
            [ValidatedNotNull] string input,
            [InvokerParameterName] [CallerArgumentExpression("input")]
            string parameterName = null,
            string message = null,
            string errorCode = null)
        {
            Guard.Check.IfNull(input, parameterName, message);

            if (input == string.Empty)
            {
                if (string.IsNullOrEmpty(message))
                    throw new EmptyException();

                throw new EmptyException(parameterName, message, errorCode);
            }

            if (!input.IsValidEmail())
            {
                if (string.IsNullOrEmpty(message))
                    throw new EmailException();

                throw new EmailException(parameterName, message, errorCode);
            }

            return input;
        }

        private static bool IsValidEmail(this string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
                return false;

            try
            {
                var mailAddress = new MailAddress(email);
                return mailAddress.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
    }
}
