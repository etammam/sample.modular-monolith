using System.Collections.Generic;
using System.Linq;

namespace Samples.ModularMonolith.Infrastructure.Persistence
{
    /// <summary>
    /// the base abstraction implementation of value object
    /// in order to use it, please inherit from this abstraction and start implement the GetEqualityComponents()
    /// in order to implement the value object please use the Own implementation
    /// </summary>
    public abstract class ValueObject
    {
        /// <summary>
        /// check object equality
        /// </summary>
        /// <param name="obj"></param>
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
                return false;

            var other = (ValueObject)obj;

            return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        /// <summary>
        /// GetHashCode
        /// </summary>
        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Select(x => x.GetHashCode())
                .Aggregate((x, y) => x ^ y);
        }

        /// <summary>
        /// Check the equality between two value objects
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        protected static bool EqualOperator(ValueObject left, ValueObject right)
        {
            if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
                return false;
            return ReferenceEquals(left, null) || left.Equals(right);
        }

        /// <summary>
        /// Check if two value objects is not equals
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        protected static bool NotEqualOperator(ValueObject left, ValueObject right)
        {
            return !EqualOperator(left, right);
        }

        /// <summary>
        /// Get equality mapping components
        /// </summary>
        protected abstract IEnumerable<object> GetEqualityComponents();
    }
}
