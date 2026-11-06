using System.Security.Claims;

namespace ECommerce.API.Infrastructure;

public static class ClaimsPrincipalExtensions
{
    public static int GetAdminId(this ClaimsPrincipal user) =>
        int.TryParse(user.FindFirstValue("sub"), out var id) ? id : 0;
}
