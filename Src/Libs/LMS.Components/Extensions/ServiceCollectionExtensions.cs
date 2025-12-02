using LMS.Components.Source.Helper;
using Microsoft.Extensions.DependencyInjection;
using TailwindMerge.Extensions;

namespace LMS.Components.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddLmsComponents(this IServiceCollection services)
    {
        services.AddTailwindMerge();
        services.AddTransient<PageHelper>();
        return services;
    }
}