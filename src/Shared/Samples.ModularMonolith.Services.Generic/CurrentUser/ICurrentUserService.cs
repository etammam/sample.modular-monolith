using System;

namespace Samples.ModularMonolith.Services.Generic.CurrentUser
{
    public interface ICurrentUserService
    {
        Guid UserId();

        Guid UserId(Guid defaultValue);

        string UserName();

        string UserName(string defaultValue);

        string Name();
    }
}
