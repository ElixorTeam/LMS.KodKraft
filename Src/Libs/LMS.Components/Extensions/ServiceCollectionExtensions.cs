using LMS.Components.Source.Helper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FluentUI.AspNetCore.Components;
using TailwindMerge.Extensions;

namespace LMS.Components.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddLmsComponents(this IServiceCollection services)
    {
        services.AddTailwindMerge();
        return services
            .AddFluentUIComponents(c => c.ValidateClassNames = false)
            .AddTransient<PageHelper>();
    }
}