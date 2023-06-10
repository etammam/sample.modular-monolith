namespace Samples.ModularMonolith.Infrastructure.Presentation.Swagger.Configurations
{
    /// <summary>
    /// License object that's supply swagger ui with required information
    /// </summary>
    public class SwaggerLicense
    {
        /// <summary>
        /// The Name Of License
        /// </summary>
        public string Name { get; set; } = default!;

        /// <summary>
        /// The Url Of License
        /// </summary>
        public string Url { get; set; } = default!;
    }
}
