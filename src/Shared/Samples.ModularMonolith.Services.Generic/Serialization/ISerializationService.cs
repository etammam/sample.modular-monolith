using System;

namespace Samples.ModularMonolith.Services.Generic.Serialization
{
    public interface ISerializationService
    {
        string Serialize<T>(T model);

        byte[] SerializeToArray<T>(T model);

        T Deserialize<T>(string source);

        object Deserialize(byte[] value, Type type);

        T Deserialize<T>(byte[] value);
    }
}
