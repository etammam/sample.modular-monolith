using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Samples.ModularMonolith.Services.Generic.Serialization
{
    public class SerializationService : ISerializationService
    {
        public static readonly JsonSerializerOptions Options = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true,
            Converters =
            {
                new JsonStringEnumConverter()
            }
        };

        public byte[] SerializeToArray<T>(T model)
        {
            return JsonSerializer.SerializeToUtf8Bytes(model, Options);
        }

        public T Deserialize<T>(string source)
        {
            return JsonSerializer.Deserialize<T>(source, Options)!;
        }

        public object Deserialize(byte[] value, Type type)
        {
            return JsonSerializer.Deserialize(value, type, Options);
        }

        public T Deserialize<T>(byte[] value)
        {
            return JsonSerializer.Deserialize<T>(value, Options);
        }

        public string Serialize<T>(T model)
        {
            return JsonSerializer.Serialize(model, Options);
        }
    }
}
