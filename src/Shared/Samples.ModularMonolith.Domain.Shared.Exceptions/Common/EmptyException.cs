namespace Samples.ModularMonolith.Domain.Shared.Exceptions.Common
{
    /// <summary>
    /// Empty Exception With Default Message 'Value can't be Empty, please check it'
    /// </summary>
    public class EmptyException : DomainException
    {
        private const string DefaultMessage = "Value can't be Empty, please check it";
        private const string ErrorCode = "0104";

        /// <summary>
        /// Initializes a new instance of the <see cref="EmptyException"/> class.
        /// throw Empty Exception With Default Message 'Value can't be Empty, please check it'
        /// </summary>
        /// <param name="message"></param>
        /// <param name="errorCode"></param>
        public EmptyException(string message = DefaultMessage, string errorCode = ErrorCode)
            : base(message)
        {
            ExceptionType = nameof(EmptyException);
            Error.ExceptionType = nameof(EmptyException);
            Error.Message = message;
            Error.ErrorCode = errorCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmptyException"/> class.
        /// throw Empty Exception With Default Message 'Value can't be Empty, please check it'
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="message"></param>
        /// <param name="errorCode"></param>
        public EmptyException(string parameterName, string message = DefaultMessage, string errorCode = ErrorCode)
            : base(parameterName, message)
        {
            ExceptionType = nameof(EmptyException);
            Error.ExceptionType = nameof(EmptyException);
            Error.Message = message;
            Error.ErrorCode = errorCode;
        }
    }
}
