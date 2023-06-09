namespace Samples.ModularMonolith.Domain.Shared.Exceptions.Common
{
    /// <summary>
    /// Invalid Argument Exception With Default Message 'Some argument is invalid, check the value and make sure that's match requirements'
    /// </summary>
    public class InvalidArgumentException : DomainException
    {
        private const string DefaultMessage = "Some argument is invalid, check the value and make sure that's match requirements";
        private const string ErrorCode = "0105";

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidArgumentException"/> class.
        /// throw Invalid Argument Exception With Default Message 'Some argument is invalid, check the value and make sure that's match requirements'
        /// </summary>
        /// <param name="message"></param>
        /// <param name="errorCode"></param>
        public InvalidArgumentException(string message = DefaultMessage, string errorCode = ErrorCode)
            : base(message)
        {
            ExceptionType = nameof(InvalidArgumentException);
            Error.ExceptionType = nameof(InvalidArgumentException);
            Error.Message = message;
            Error.ErrorCode = errorCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidArgumentException"/> class.
        /// throw Invalid Argument Exception With Default Message 'Some argument is invalid, check the value and make sure that's match requirements'
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="message"></param>
        /// <param name="errorCode"></param>
        public InvalidArgumentException(string parameterName, string message = DefaultMessage, string errorCode = ErrorCode)
            : base(parameterName, message)
        {
            ExceptionType = nameof(InvalidArgumentException);
            Error.ExceptionType = nameof(InvalidArgumentException);
            Error.Message = message;
            Error.ErrorCode = errorCode;
        }
    }
}
