using System.Reflection;

namespace Samples.ModularMonolith.Infrastructure.Presentation.Swagger.Configurations
{
    /// <summary>
    /// swagger configuration that's supply swagger ui with required information
    /// </summary>
    internal class SwaggerConfiguration
    {
        /// <summary>
        /// Is Swagger Ui Enabled
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Is ReDoc documentation ui enabled
        /// </summary>
        public bool EnableReDoc { get; set; }

        /// <summary>
        /// ReDoc route
        /// </summary>
        public string ReDocUrl { get; set; }

        /// <summary>
        /// The Name Of Swagger Document
        /// </summary>
        public string Name { get; set; } = default!;

        /// <summary>
        /// The Name Of The Build Version
        /// </summary>
        public string Build { get; set; } = Assembly.GetExecutingAssembly().GetName().Version?.ToString();

        /// <summary>
        /// Swagger Ui Title
        /// </summary>
        public string Title { get; set; } = default!;

        /// <summary>
        /// Swagger Ui Version
        /// </summary>
        public string Version { get; set; } = default!;

        /// <summary>
        /// Swagger Ui Description
        /// </summary>
        public string Description { get; set; } = default!;

        /// <summary>
        /// Swagger Ui Terms Of Service Url
        /// </summary>
        public string TermsOfService { get; set; } = default!;

        /// <summary>
        /// Swagger Ui License
        /// </summary>
        public SwaggerLicense License { get; set; } = new SwaggerLicense();

        /// <summary>
        /// Swagger Ui Contact
        /// </summary>
        public SwaggerContact Contact { get; set; } = new SwaggerContact();
    }
}
