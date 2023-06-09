namespace Samples.ModularMonolith.Domain.Shared.Exceptions.Common
{
    /// <summary>
    /// Not Found Exception, formally this exception should throw if you are going to query with an object
    /// with a default exception message "Queried object was not found"
    /// </summary>
    public class NotFoundException : DomainException
    {
        private const string ErrorMessage = "Queried object was not found";
        private const string ErrorCode = "0107";

        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundException"/> class.
        /// Not Found Exception, formally this exception should throw if you are going to query with an object
        /// with a default exception message "Queried object was not found"
        /// </summary>
        /// <param name="message">the error message</param>
        /// <param name="errorCode">the error code</param>
        public NotFoundException(string message = ErrorMessage, string errorCode = ErrorCode)
            : base(message)
        {
            ExceptionType = nameof(NotFoundException);
            Error.ExceptionType = nameof(NotFoundException);
            Error.Message = message;
            Error.ErrorCode = errorCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundException"/> class.
        /// Not Found Exception, formally this exception should throw if you are going to query with an object
        /// with a default exception message "Queried object was not found"
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="message">the error message</param>
        /// <param name="errorCode">the error code</param>
        public NotFoundException(string parameterName, string message = ErrorMessage, string errorCode = ErrorCode)
            : base(parameterName, message)
        {
            ExceptionType = nameof(NotFoundException);
            Error.ExceptionType = nameof(NotFoundException);
            Error.Message = message;
            Error.ErrorCode = errorCode;
        }
    }
}
