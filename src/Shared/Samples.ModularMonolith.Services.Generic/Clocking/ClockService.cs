using System;

namespace Samples.ModularMonolith.Services.Generic.Clocking
{
    internal class ClockService : IClockService
    {
        public DateTime Get() => DateTime.UtcNow;

        public DateOnly Today() => DateOnly.FromDateTime(DateTime.UtcNow);

        public TimeOnly Now() => TimeOnly.FromDateTime(DateTime.UtcNow);
    }
}
