using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Samples.ModularMonolith.Infrastructure.Presentation.Defaults;

namespace Samples.ModularMonolith.Presentation.BootstrapperApi.Controllers
{
    /// <summary>
    /// an empty controller to present the status of application.
    /// </summary>
    [AllowAnonymous]
    public class FooController : DefaultController
    {
        /// <summary>
        /// mario knocking...
        /// </summary>
        /// <returns>system reaction.</returns>
        [HttpGet("foo")]
        public ActionResult<string> Foo() => Ok("Hello mario, your princess is in another castle.");
    }
}
