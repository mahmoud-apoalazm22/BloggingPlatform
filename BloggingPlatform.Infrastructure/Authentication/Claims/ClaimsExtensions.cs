using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BloggingPlatform.Infrastructure.Authentication.Claims;
public static class ClaimsExtensions
{
    public static List<Claim> AddIfValueNotNull(this List<Claim> claims, string type, string? value)
    {
        if (value is not null)
        {
            claims.Add(new Claim(type, value));
        }
        return claims;
    }
}
