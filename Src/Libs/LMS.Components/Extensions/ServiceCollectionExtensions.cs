using Microsoft.Extensions.DependencyInjection;
using TailwindMerge.Extensions;

namespace LMS.Components.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddLmsComponents(this IServiceCollection services)
    {
        services.AddTailwindMerge();
        return services;
    }
}