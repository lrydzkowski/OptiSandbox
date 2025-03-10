using EPiServer.Commerce.Routing;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using Microsoft.AspNetCore.Mvc.Razor;
using OptiSandbox.Web.Commerce.Catalog.Infrastructure;

namespace OptiSandbox.Web.Commerce;

[InitializableModule]
[ModuleDependency(typeof(EPiServer.Commerce.Initialization.InitializationModule))]
public class InitializationModule : IConfigurableModule
{
    public void Initialize(InitializationEngine context)
    {
        CatalogRouteHelper.MapDefaultHierarchialRouter(false);
    }

    public void Uninitialize(InitializationEngine context)
    {
    }

    public void ConfigureContainer(ServiceConfigurationContext context)
    {
        AddViewsCustomPath(context.Services);
    }

    private static void AddViewsCustomPath(IServiceCollection services)
    {
        services.Configure<RazorViewEngineOptions>(
            options => { options.ViewLocationExpanders.Add(new CustomViewLocationExpander()); }
        );
    }
}
