using Microsoft.AspNetCore.Authorization;

namespace LMS.Client.Models.Auth;

public static class PolicyAuthUtils
{
    public static void RegisterAuthorization(AuthorizationOptions options)
    {
        options.AddPolicy(Policy.Admin, builder =>
            builder.RequireAssertion(x =>
                x.User.HasRole(Role.Admin)
            )
        );

        options.AddPolicy(Policy.Teacher, builder =>
            builder.RequireAssertion(x =>
                x.User.HasRole(Role.Teacher)
            )
        );

        options.AddPolicy(Policy.Parent, builder =>
            builder.RequireAssertion(x =>
                x.User.HasRole(Role.Parent)
            )
        );

        options.AddPolicy(Policy.Pupil, builder =>
            builder.RequireAssertion(x =>
                x.User.HasRole(Role.Pupil)
            )
        );
    }

    private static bool HasRole(this ClaimsPrincipal user, params string[] roles) =>
        roles.Any(role => user.HasClaim(ClaimTypes.Role, role));
}