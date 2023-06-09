namespace Samples.ModularMonolith.Domain.Shared.Exceptions.Models
{
    /// <summary>
    /// the error property object
    /// </summary>
    public class ErrorProperty
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorProperty"/> class.
        /// initial new error property
        /// </summary>
        public ErrorProperty()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorProperty"/> class.
        /// initial new error property
        /// </summary>
        /// <param name="value"></param>
        /// <param name="errorCode"></param>
        /// <param name="message"></param>
        /// <param name="severity"></param>
        public ErrorProperty(object value, string errorCode, string message, string severity)
        {
            Value = value;
            ErrorCode = errorCode;
            Message = message;
            Severity = severity;
        }

        /// <summary>
        /// the current property value
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// the property error code
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// the message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// property severity
        /// </summary>
        public string Severity { get; set; }
    }
}
