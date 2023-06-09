namespace Samples.ModularMonolith.Domain.Shared.Exceptions.Common
{
    /// <summary>
    /// Duplication Exception with Default Message 'Data duplication occur, please check the exist'
    /// </summary>
    public class DuplicateException : DomainException
    {
        private const string DefaultMessage = "Data duplication occur, please check the exist";
        private const string ErrorCode = "0102";

        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateException"/> class.
        /// throw Duplication Exception With Default Message 'Data duplication occur, please check the exist'
        /// </summary>
        /// <param name="message"></param>
        /// <param name="errorCode"></param>
        public DuplicateException(string message = DefaultMessage, string errorCode = ErrorCode)
            : base(message)
        {
            ExceptionType = nameof(DuplicateException);
            Error.ExceptionType = nameof(DuplicateException);
            Error.Message = message;
            Error.ErrorCode = errorCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateException"/> class.
        /// throw Duplication Exception With Default Message 'Data duplication occur, please check the exist'
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="message"></param>
        /// <param name="errorCode"></param>
        public DuplicateException(string parameterName, string message = DefaultMessage, string errorCode = ErrorCode)
            : base(parameterName, message)
        {
            ExceptionType = nameof(DuplicateException);
            Error.ExceptionType = nameof(DuplicateException);
            Error.Message = message;
            Error.ErrorCode = errorCode;
        }
    }
}
