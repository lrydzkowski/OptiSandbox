using Microsoft.AspNetCore.Mvc.Razor;
using OptiSandbox.Web.Features.Articles.Infrastructure;

namespace OptiSandbox.Web.Features.Articles;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddArticleModule(this IServiceCollection services)
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
