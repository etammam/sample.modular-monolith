using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Samples.ModularMonolith.Services.Generic.CurrentUser;
using System;
using System.Net.Mime;

namespace Samples.ModularMonolith.Infrastructure.Presentation.Defaults
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class DefaultController : ControllerBase
    {
        private ICurrentUserService _currentUserService;
        private IMediator _mediator;
        private IHttpContextAccessor _contextAccessor;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        protected ICurrentUserService CurrentUserService =>
            _currentUserService ??= HttpContext.RequestServices.GetRequiredService<ICurrentUserService>();

        protected IHttpContextAccessor HttpContextAccessor =>
            _contextAccessor ??= HttpContext.RequestServices.GetRequiredService<IHttpContextAccessor>();

        protected FileContentResult Excel(byte[] content, string fileName)
        {
            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            return File(content, contentType, $"{fileName}{DateTime.Now:dd-MM-yyyy}.xlsx");
        }
    }
}
