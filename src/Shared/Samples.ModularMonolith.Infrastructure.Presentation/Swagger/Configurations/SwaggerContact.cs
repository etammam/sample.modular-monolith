namespace Samples.ModularMonolith.Infrastructure.Presentation.Swagger.Configurations
{
    /// <summary>
    /// contact object that's supply swagger ui with required information
    /// </summary>
    internal class SwaggerContact
    {
        /// <summary>
        /// The Name Of Contact
        /// </summary>
        public string Name { get; set; } = default!;

        /// <summary>
        /// The Email Of Contact
        /// </summary>
        public string Email { get; set; } = default!;

        /// <summary>
        /// The Url Of Contact
        /// </summary>
        public string Url { get; set; } = default!;
    }
}
