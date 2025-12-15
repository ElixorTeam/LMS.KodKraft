using LMS.Client.Models.Auth;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace LMS.Client.Source.Shared.Auth;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddKeyCloak(this IServiceCollection services, IConfiguration configuration)
    {
        // builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new(builder.HostEnvironment.BaseAddress) });
        OidcSettings settings = configuration.GetSection("OidcSettings").Get<OidcSettings>() ?? throw new InvalidOperationException();
        string appDomain = configuration["Domain"] ?? throw new InvalidOperationException();

        services
            .AddAuthorizationCore(PolicyAuthUtils.RegisterAuthorization)
            .AddOidcAuthentication<RemoteAuthenticationState, RemoteUserAccount>(options => {
                options.ProviderOptions.MetadataUrl = $"{settings.Authority}/.well-known/openid-configuration";
                options.ProviderOptions.Authority = settings.Authority;
                options.ProviderOptions.ClientId = settings.ClientId;
                options.ProviderOptions.ResponseType = "code";
                options.UserOptions.NameClaim = "preferred_username";
                options.UserOptions.RoleClaim = "roles";
                options.UserOptions.ScopeClaim = "scope";
                options.ProviderOptions.PostLogoutRedirectUri = appDomain;
            })
            .AddAccountClaimsPrincipalFactory<LmsClaimsPrincipalFactory<RemoteUserAccount>>();
        return services;
    }
}