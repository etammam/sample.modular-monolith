namespace Samples.ModularMonolith.Domain.Shared.Exceptions.Common
{
    /// <summary>
    /// Null Exception With Default Message 'Your input is required and the received data is null, please check the provided value'
    /// </summary>
    public class NullException : DomainException
    {
        private const string DefaultMessage = "Your input is required and the received data is null, please check the provided value";
        private const string ErrorCode = "0100";

        /// <summary>
        /// Initializes a new instance of the <see cref="NullException"/> class.
        /// throw Null Exception with default message 'Your input is required and the received data is null, please check the provided value'
        /// </summary>
        /// <param name="message"></param>
        /// <param name="errorCode"></param>
        public NullException(string message = DefaultMessage, string errorCode = ErrorCode)
            : base(message)
        {
            ExceptionType = nameof(NullException);
            Error.ExceptionType = nameof(NullException);
            Error.Message = message;
            Error.ErrorCode = errorCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NullException"/> class.
        /// throw Null Exception with default message 'Your input is required and the received data is null, please check the provided value'
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="message"></param>
        /// <param name="errorCode"></param>
        public NullException(string parameterName, string message, string errorCode)
            : base(parameterName, message)
        {
            ExceptionType = nameof(NullException);
            Error.ExceptionType = nameof(NullException);
            Error.Message = message;
            Error.ErrorCode = errorCode;
        }
    }
}
