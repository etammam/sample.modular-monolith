namespace Samples.ModularMonolith.Infrastructure.Guards.Guards.Abstractions
{
    /// <summary>
    /// the core implementation of IGuard Interface
    /// simply all guards should be called via the entry point
    /// </summary>
    public sealed class Guard : IGuard
    {
        private Guard()
        {
        }

        /// <summary>
        /// An entry point to a set of Guard.
        /// </summary>
        public static IGuard Check { get; } = new Guard();
    }
}
