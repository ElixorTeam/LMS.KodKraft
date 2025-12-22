using KK.UIKit.Source.Helper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FluentUI.AspNetCore.Components;
using TailwindMerge.Extensions;

namespace KK.UIKit.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddElixorKit(this IServiceCollection services)
    {
        services.AddTailwindMerge();
        return services
            .AddFluentUIComponents(c => c.ValidateClassNames = false)
            .AddTransient<PageHelper>();
    }
}