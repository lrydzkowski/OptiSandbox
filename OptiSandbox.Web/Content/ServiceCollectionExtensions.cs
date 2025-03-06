using Microsoft.AspNetCore.Mvc.Razor;
using OptiSandbox.Web.Content.Infrastructure;
using OptiSandbox.Web.Content.Services;
using Serilog;

namespace OptiSandbox.Web.Content;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddContentModule(this IServiceCollection services)
    {
        services.AddViewsCustomPath();
        services.AddSerilog();
        services.AddHttpContextAccessor();
        services.AddServices();

        return services;
    }

    private static void AddViewsCustomPath(this IServiceCollection services)
    {
        services.Configure<RazorViewEngineOptions>(
            options => { options.ViewLocationExpanders.Add(new CustomViewLocationExpander()); }
        );
    }

    private static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IPageViewModelBuilder, PageViewModelBuilder>();
        services.AddScoped<IStartPageViewModelBuilder, StartPageViewModelBuilder>();
    }
}
