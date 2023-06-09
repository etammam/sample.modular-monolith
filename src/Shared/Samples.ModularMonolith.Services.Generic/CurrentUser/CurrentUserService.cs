using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Security.Claims;

namespace Samples.ModularMonolith.Services.Generic.CurrentUser
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid UserId()
        {
            if (IsAuthenticated())
                return Guid.Parse(_httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? string.Empty);
            throw new UnauthorizedAccessException("no valid user claims found");
        }

        public Guid UserId(Guid defaultValue)
        {
            if (IsAuthenticated())
                return Guid.Parse(_httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? string.Empty);
            return defaultValue;
        }

        public string UserName()
        {
            if (IsAuthenticated())
                return _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value ?? string.Empty;
            throw new UnauthorizedAccessException("no valid user claims found");
        }

        public string UserName(string defaultValue)
        {
            if (IsAuthenticated())
                return _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value ?? string.Empty;
            return defaultValue;
        }

        public string Name()
        {
            if (IsAuthenticated())
                return _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value ?? string.Empty;
            throw new UnauthorizedAccessException("no valid user claims found");
        }

        public string PasswordResetToken()
        {
            if (IsAuthenticated())
                return _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Hash)?.Value ?? string.Empty;
            throw new UnauthorizedAccessException("no valid user claims found");
        }

        private bool IsAuthenticated()
        {
            return _httpContextAccessor.HttpContext?.User.Identity is { IsAuthenticated: true };
        }
    }
}
