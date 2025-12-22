using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;

namespace KK.LMS.Source.Shared.Auth;

public class LmsClaimsPrincipalFactory<TAccount>(IAccessTokenProviderAccessor accessor) : AccountClaimsPrincipalFactory<TAccount>(accessor) where TAccount : RemoteUserAccount
{
    public override async ValueTask<ClaimsPrincipal> CreateUserAsync(TAccount account, RemoteAuthenticationUserOptions options)
    {
        ClaimsPrincipal user = await base.CreateUserAsync(account, options);

        if (user.Identity is { IsAuthenticated: false } || options.RoleClaim == null)
            return user;

        ClaimsIdentity identity = (ClaimsIdentity)user.Identity!;
        IEnumerable<Claim> roleClaims = identity.FindAll(identity.RoleClaimType);

        if (!roleClaims.Any())
            return user;

        object rolesElem = account.AdditionalProperties[identity.RoleClaimType];

        if (rolesElem is not JsonElement { ValueKind: JsonValueKind.Array } roles)
            return user;

        identity.RemoveClaim(identity.FindFirst(options.RoleClaim));
        foreach (JsonElement role in roles.EnumerateArray())
        {
            string? roleValue = role.GetString();
            if (!string.IsNullOrEmpty(roleValue))
                identity.AddClaim(new(options.RoleClaim, roleValue));
        }
        return user;
    }
}