using System.Collections.Generic;

namespace Samples.ModularMonolith.Domain.Shared.Exceptions.Models
{
    /// <summary>
    /// validation error
    /// </summary>
    public class ValidationError
    {
        /// <summary>
        /// initial new validation error object
        /// </summary>
        public ValidationError()
        {
        }

        /// <summary>
        /// initial new validation error object
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="validations"></param>
        public ValidationError(string propertyName, List<ErrorProperty> validations)
        {
            PropertyName = propertyName;
            Validations = validations;
        }

        /// <summary>
        /// the name of property which has a validation exception
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// list of validation errors
        /// </summary>
        public List<ErrorProperty> Validations { get; set; } = new List<ErrorProperty>();
    }
}
