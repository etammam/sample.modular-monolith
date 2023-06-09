namespace Samples.ModularMonolith.Infrastructure.Presentation.Configurations
{
    public sealed class ExceptionConfiguration
    {
        public bool ShowExceptionStackTrace { get; set; } = true;

        public bool ShowExceptionInnerException { get; set; } = true;
    }
}
