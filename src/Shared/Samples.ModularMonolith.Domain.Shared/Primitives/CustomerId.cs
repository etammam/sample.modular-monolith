using System;
using System.Text.Json.Serialization;
using Samples.ModularMonolith.Domain.Shared.Converters;

namespace Samples.ModularMonolith.Domain.Shared.Primitives
{
    [JsonConverter(typeof(CustomerIdConverter))]
    public struct CustomerId : IEquatable<CustomerId>
    {
        public CustomerId(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }

        public static bool operator ==(CustomerId first, CustomerId second) => Equals(first, second);

        public static bool operator !=(CustomerId first, CustomerId second) => !(first == second);

        public static CustomerId New() => new CustomerId(Guid.NewGuid());

        public static bool TryParse(string value, out CustomerId returnValue)
        {
            var result = Guid.TryParse(value, out var departmentId);
            returnValue = new CustomerId(departmentId);
            return result;
        }

        public bool Equals(CustomerId other) => Id.Equals(other.Id);

        public override int GetHashCode() => Id.GetHashCode();

        public override bool Equals(object obj)
        {
            return obj is CustomerId id && Equals(id);
        }
    }
}
