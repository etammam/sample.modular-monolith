using Samples.ModularMonolith.Domain.Shared.Exceptions.Models;
using System;
using System.Collections.Generic;

namespace Samples.ModularMonolith.Domain.Shared.Exceptions
{
    /// <summary>
    /// the base domain exception
    /// </summary>
    public abstract class DomainException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DomainException"/> class.
        /// the ctor that's requires to define error message only
        /// </summary>
        /// <param name="message"></param>
        protected DomainException(string message)
            : base(message)
        {
            Message = message;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DomainException"/> class.
        /// the ctor that's requires to define the error message and parameterName
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="message"></param>
        protected DomainException(string parameterName, string message)
            : base(message)
        {
            Message = message;
            Initial(parameterName, message, string.Empty, string.Empty, Severity.Undefined);
        }

        /// <summary>
        /// the error model
        /// </summary>
        public ErrorModel Error { get; set; } = new ErrorModel();

        /// <summary>
        /// the exceptionType normally you can  define it as the nameof(YourExceptionName)
        /// </summary>
        public string ExceptionType { get; set; } = string.Empty;

        /// <summary>
        /// the error message it self, should filled with the object initialization
        /// </summary>
        public override string Message { get; }

        private void Initial(string parameterName, string message, object value, string errorCode, Severity severity)
        {
            SetError(parameterName, message, value, errorCode, severity);
        }

        private void SetError(string parameterName,
            string message,
            object value,
            string errorCode,
            Severity severity)
        {
            Error.Errors.Add(new ValidationError(parameterName, new List<ErrorProperty>
            {
                new ErrorProperty(value, errorCode, message, severity.ToString())
            }));
        }
    }
}
