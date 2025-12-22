using KK.LMS.Source.Shared.Auth;

namespace KK.LMS.Source.Shared.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddLmsClient(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddKeyCloak(configuration);
        return services;
    }
}