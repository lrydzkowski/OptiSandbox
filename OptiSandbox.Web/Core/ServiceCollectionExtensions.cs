using Microsoft.AspNetCore.Mvc.Razor;
using OptiSandbox.Web.Core.Infrastructure;

namespace OptiSandbox.Web.Core;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCoreModule(this IServiceCollection services)
    {
        services.AddViewsCustomPath();

        return services;
    }

    private static IServiceCollection AddViewsCustomPath(this IServiceCollection services)
    {
        services.Configure<RazorViewEngineOptions>(
            options => { options.ViewLocationExpanders.Add(new CustomViewLocationExpander()); }
        );

        return services;
    }
}
