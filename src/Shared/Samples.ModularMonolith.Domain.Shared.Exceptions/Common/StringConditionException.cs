namespace Samples.ModularMonolith.Domain.Shared.Exceptions.Common
{
    /// <summary>
    /// string condition exception it will be thrown if your input dose not match your condition.
    /// </summary>
    public class StringConditionException : DomainException
    {
        private const string DefaultMessage = "string not meet your condition";
        private const string ErrorCode = "0109";

        /// <summary>
        /// Initializes a new instance of the <see cref="StringConditionException"/> class.
        /// string condition exception it will be thrown if your input dose not match your condition.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="errorCode"></param>
        public StringConditionException(string message = DefaultMessage, string errorCode = ErrorCode)
            : base(message)
        {
            ExceptionType = nameof(StringConditionException);
            Error.ExceptionType = nameof(StringConditionException);
            Error.Message = message;
            Error.ErrorCode = errorCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringConditionException"/> class.
        /// string condition exception it will be thrown if your input dose not match your condition.
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="message"></param>
        /// <param name="errorCode"></param>
        public StringConditionException(string parameterName, string message = DefaultMessage, string errorCode = ErrorCode)
            : base(parameterName, message)
        {
            ExceptionType = nameof(StringConditionException);
            Error.ExceptionType = nameof(StringConditionException);
            Error.Message = message;
            Error.ErrorCode = errorCode;
        }
    }
}
