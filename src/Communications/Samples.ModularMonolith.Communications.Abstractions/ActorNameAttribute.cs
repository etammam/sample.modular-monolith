using System;

namespace Samples.ModularMonolith.Communications.Abstractions;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public class ActorNameAttribute : Attribute
{
    public ActorNameAttribute(string actorName)
    {
        ActorName = actorName;
    }

    public string ActorName { get; set; }
}
