namespace LMS.Client.Source.Shared.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddKeyCloak(this IServiceCollection services)
    {
        services.AddOidcAuthentication(options =>
        {
            options.ProviderOptions.MetadataUrl = "http://services-keycloak-v8mwi6-558737-172-16-2-42.traefik.me/realms/kodkraft/.well-known/openid-configuration";
            options.ProviderOptions.Authority = "http://services-keycloak-v8mwi6-558737-172-16-2-42.traefik.me/realms/kodkraft";
            options.ProviderOptions.ClientId = "lms-client";
            options.ProviderOptions.ResponseType = "code";
            options.UserOptions.NameClaim = "preferred_username";
            options.UserOptions.RoleClaim = "roles";
            options.UserOptions.ScopeClaim = "scope";
            options.ProviderOptions.PostLogoutRedirectUri = "http://localhost:5066/";
        });
        return services;
    }
}