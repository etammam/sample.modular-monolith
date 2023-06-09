namespace Samples.ModularMonolith.Domain.Shared.Exceptions.Common
{
    /// <summary>
    /// Language Exception with default message 'Your input not match target language'
    /// </summary>
    public class LanguageException : DomainException
    {
        private const string DefaultMessage = "Your input not match target language";
        private const string ErrorCode = "0106";

        /// <summary>
        /// Initializes a new instance of the <see cref="LanguageException"/> class.
        /// throw Language Exception with default message 'Your input not match target language'
        /// </summary>
        /// <param name="message"></param>
        /// <param name="errorCode"></param>
        public LanguageException(string message = DefaultMessage, string errorCode = ErrorCode)
            : base(message)
        {
            ExceptionType = nameof(LanguageException);
            Error.ExceptionType = nameof(LanguageException);
            Error.Message = message;
            Error.ErrorCode = errorCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LanguageException"/> class.
        /// throw Language Exception with default message 'Your input not match target language'
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="message"></param>
        /// <param name="errorCode"></param>
        public LanguageException(string parameterName, string message = DefaultMessage, string errorCode = ErrorCode)
            : base(parameterName, message)
        {
            ExceptionType = nameof(LanguageException);
            Error.ExceptionType = nameof(LanguageException);
            Error.Message = message;
            Error.ErrorCode = errorCode;
        }
    }
}
