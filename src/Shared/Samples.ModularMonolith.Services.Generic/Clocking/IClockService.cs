using System;

namespace Samples.ModularMonolith.Services.Generic.Clocking
{
    public interface IClockService
    {
        DateTime Get();
        DateOnly Today();
        TimeOnly Now();
    }
}
