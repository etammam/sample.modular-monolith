namespace Samples.ModularMonolith.Domain.Shared.Exceptions.Common
{
    /// <summary>
    /// Phone Number Exception with default message 'Phone number not valid'
    /// </summary>
    public class PhoneNumberException : DomainException
    {
        private const string DefaultMessage = "Phone number not valid";
        private const string ErrorCode = "0108";

        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneNumberException"/> class.
        /// throw phone number exception with default message 'Phone number not valid'
        /// </summary>
        /// <param name="message"></param>
        /// <param name="errorCode"></param>
        public PhoneNumberException(string message = DefaultMessage, string errorCode = ErrorCode)
            : base(message)
        {
            ExceptionType = nameof(PhoneNumberException);
            Error.ExceptionType = nameof(PhoneNumberException);
            Error.Message = message;
            Error.ErrorCode = errorCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneNumberException"/> class.
        /// throw phone number exception with default message 'Phone number not valid'
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="message"></param>
        /// <param name="errorCode"></param>
        public PhoneNumberException(string parameterName, string message = DefaultMessage, string errorCode = ErrorCode)
            : base(parameterName, message)
        {
            ExceptionType = nameof(PhoneNumberException);
            Error.ExceptionType = nameof(PhoneNumberException);
            Error.Message = message;
            Error.ErrorCode = errorCode;
        }
    }
}
