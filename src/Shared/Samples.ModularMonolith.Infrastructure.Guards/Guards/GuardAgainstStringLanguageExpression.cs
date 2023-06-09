using JetBrains.Annotations;
using Samples.ModularMonolith.Domain.Shared.Exceptions.Common;
using Samples.ModularMonolith.Infrastructure.Guards.Guards.Abstractions;
using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Samples.ModularMonolith.Infrastructure.Guards.Guards
{
    public static partial class GuardExtensions
    {
        private const string SpecialCharacters = ".!@#$%^&*()_+'";
        private const string SpecialArabicLetters = $"\u0621-\u064A-{SpecialCharacters}";
        private const string SpecialEnglishLetters = $"a-zA-Z-{SpecialCharacters}";
        private const string NumbersRegex = "0-9";

        /// <summary>
        /// guard supported languages otherwise use your own regex expression.
        /// </summary>
        public enum SentenceLanguage
        {
            /// <summary>
            /// arabic language
            /// </summary>
            Arabic,

            /// <summary>
            /// english language
            /// </summary>
            English
        }

        /// <summary>
        /// check if the input value match a required language.
        /// </summary>
        /// <param name="guard"></param>
        /// <param name="input"></param>
        /// <param name="language"></param>
        /// <param name="allowSpaces"></param>
        /// <param name="allowNumbers"></param>
        /// <param name="parameterName"></param>
        /// <param name="message"></param>
        /// <param name="errorCode"></param>
        /// <returns><paramref name="input" /> if the value match a required language.</returns>
        /// <exception cref="LanguageException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static string IfNotMatchLanguage(this IGuard guard,
            [ValidatedNotNull] string input,
            [ValidatedNotNull] SentenceLanguage language,
            bool allowSpaces = true,
            bool allowNumbers = true,
            [InvokerParameterName][CallerArgumentExpression("input")]
            string parameterName = null,
            string message = null,
            string errorCode = null)
        {
            switch (language)
            {
                case SentenceLanguage.Arabic:
                    if (!IsArabicContent(input, allowSpaces, allowNumbers))
                    {
                        if (string.IsNullOrEmpty(message))
                            throw new LanguageException();

                        throw new LanguageException(parameterName, message, errorCode);
                    }

                    break;

                case SentenceLanguage.English:
                    if (!IsEnglishContent(input, allowSpaces, allowNumbers))
                    {
                        if (string.IsNullOrEmpty(message))
                            throw new LanguageException();

                        throw new LanguageException(parameterName, message, errorCode);
                    }

                    break;

                default:
                    if (string.IsNullOrEmpty(message))
                        throw new InvalidArgumentException(message: "language not support");

                    throw new InvalidArgumentException(message, errorCode);
            }

            return input;
        }

        private static bool IsEnglishContent(string input, bool allowSpaces, bool allowNumbers)
        {
            var numbers = allowNumbers ? NumbersRegex : "";

            var pattern = allowSpaces
                ? $"^[{SpecialEnglishLetters}{numbers} ]*$"
                : $"^[{SpecialEnglishLetters}{numbers}]*$";

            return Regex.IsMatch(input, pattern);
        }

        private static bool IsArabicContent(string input, bool allowSpaces, bool allowNumbers)
        {
            var numbers = allowNumbers ? NumbersRegex : "";

            var pattern = allowSpaces
                ? $"^[{SpecialArabicLetters}{numbers} ]*$"
                : $"^[{SpecialArabicLetters}{numbers}]*$";

            return Regex.IsMatch(input, pattern);
        }
    }
}
