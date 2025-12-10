using LMS.Client.Source.Shared.Auth;

namespace LMS.Client.Source.Shared.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddLmsClient(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddKeyCloak(configuration);
        return services;
    }
}