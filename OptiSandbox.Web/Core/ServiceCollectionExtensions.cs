using Microsoft.AspNetCore.Mvc.Razor;
using OptiSandbox.Web.Core.Infrastructure;
using Serilog;

namespace OptiSandbox.Web.Core;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCoreModule(this IServiceCollection services)
    {
        services.AddViewsCustomPath();
        services.AddSerilog();

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
