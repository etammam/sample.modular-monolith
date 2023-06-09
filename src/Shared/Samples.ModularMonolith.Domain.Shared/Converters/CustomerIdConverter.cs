using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Samples.ModularMonolith.Domain.Shared.Primitives;

namespace Samples.ModularMonolith.Domain.Shared.Converters
{
    internal sealed class CustomerIdConverter : JsonConverter<CustomerId>
    {
        public override CustomerId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var result = Guid.Parse(reader.GetString()!);
            return new CustomerId(result);
        }

        public override void Write(Utf8JsonWriter writer, CustomerId value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.Id);
        }
    }
}
