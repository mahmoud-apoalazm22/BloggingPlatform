
using BloggingPlatform.Application.Common.Interfaces;
using BloggingPlatform.Application.Common.Models;
using Throw;
namespace BloggingPlatform.Api.Services;

public class CurrentUserProvider(IHttpContextAccessor _httpContextAccessor) : ICurrentUserProvider
{
    public CurrentUser GetCurrentUser()
    {
        _httpContextAccessor.HttpContext.ThrowIfNull();

        Guid id = GetClaimValues("id")
            .Select(Guid.Parse)
            .First();

        return new CurrentUser(Id: id,null,null);
    }

    private List<string> GetClaimValues(string claimType)
    {
        return _httpContextAccessor.HttpContext!.User.Claims
            .Where(claim => claim.Type == claimType)
            .Select(claim => claim.Value)
            .ToList();
    }
}
