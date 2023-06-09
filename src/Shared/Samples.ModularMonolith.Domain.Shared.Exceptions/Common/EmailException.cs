namespace Samples.ModularMonolith.Domain.Shared.Exceptions.Common
{
    /// <summary>
    /// Invalid Email Address Exception with default message 'Email address not valid, please check it'
    /// </summary>
    public class EmailException : DomainException
    {
        private const string DefaultMessage = "Email Address not valid, please check it";
        private const string ErrorCode = "0103";

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailException"/> class.
        /// throw Invalid Email Address Exception with default message 'Email address not valid, please check it'
        /// </summary>
        /// <param name="message"></param>
        /// <param name="errorCode"></param>
        public EmailException(string message = DefaultMessage, string errorCode = ErrorCode)
            : base(message)
        {
            ExceptionType = nameof(EmailException);
            Error.ExceptionType = nameof(EmailException);
            Error.Message = message;
            Error.ErrorCode = errorCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailException"/> class.
        /// throw Invalid Email Address Exception with default message 'Email address not valid, please check it'
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="message"></param>
        /// <param name="errorCode"></param>
        public EmailException(string parameterName, string message = DefaultMessage, string errorCode = ErrorCode)
            : base(parameterName, message)
        {
            ExceptionType = nameof(EmailException);
            Error.ExceptionType = nameof(EmailException);
            Error.Message = message;
            Error.ErrorCode = errorCode;
        }
    }
}
