namespace Samples.ModularMonolith.Domain.Shared.Exceptions.Common
{
    /// <summary>
    /// Bad Request Exception With Default Message 'Bad Request Exception Occur'
    /// </summary>
    public class BadRequestException : DomainException
    {
        private const string DefaultMessage = "Bad Request Exception Occur";
        private const string ErrorCode = "0101";

        /// <summary>
        /// Initializes a new instance of the <see cref="BadRequestException"/> class.
        /// throw Bad Request Exception With Default Message 'Bad Request Exception Occur'
        /// </summary>
        /// <param name="message"></param>
        /// <param name="errorCode"></param>
        public BadRequestException(string message = DefaultMessage, string errorCode = ErrorCode)
            : base(message)
        {
            ExceptionType = nameof(BadRequestException);
            Error.ExceptionType = nameof(BadRequestException);
            Error.Message = message;
            Error.ErrorCode = errorCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BadRequestException"/> class.
        /// throw Bad Request Exception With Default Message 'Bad Request Exception Occur'
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="message"></param>
        /// <param name="errorCode"></param>
        public BadRequestException(string parameterName, string message = DefaultMessage, string errorCode = ErrorCode)
            : base(parameterName, message)
        {
            ExceptionType = nameof(BadRequestException);
            Error.ExceptionType = nameof(BadRequestException);
            Error.Message = message;
            Error.ErrorCode = errorCode;
        }
    }
}
