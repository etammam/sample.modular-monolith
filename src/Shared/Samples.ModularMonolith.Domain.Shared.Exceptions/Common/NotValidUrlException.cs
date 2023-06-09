namespace Samples.ModularMonolith.Domain.Shared.Exceptions.Common
{
    public class NotValidUrlException : DomainException
    {
        private const string DefaultMessage = "url is invalid.";

        public NotValidUrlException(string message = DefaultMessage)
            : base(message)
        {
            Error.Message = message;
            Error.ErrorCode = "0111";
            Error.ExceptionType = nameof(NotValidUrlException);
            ExceptionType = nameof(NotValidUrlException);
        }

        public NotValidUrlException(string parameterName, string message = DefaultMessage)
            : base(parameterName, message)
        {
            Error.Message = message;
            Error.ErrorCode = "0111";
            Error.ExceptionType = nameof(NotValidUrlException);
            ExceptionType = nameof(NotValidUrlException);
        }
    }
}
