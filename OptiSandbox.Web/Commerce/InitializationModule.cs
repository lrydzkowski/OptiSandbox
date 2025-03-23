using EPiServer.Commerce.Routing;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using Microsoft.AspNetCore.Mvc.Razor;
using OptiSandbox.Web.Commerce.Infrastructure;
using OptiSandbox.Web.Commerce.Services;

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
        AddServices(context.Services);
        AddViewsCustomPath(context.Services);
    }

    private static void AddServices(IServiceCollection services)
    {
        services.AddScoped<IStandardCategoryViewModelBuilder, StandardCategoryViewModelBuilder>();
        services.AddScoped<IEbookProductViewModelBuilder, EbookProductViewModelBuilder>();
        services.AddScoped<IPriceResolver, PriceResolver>();
        services.AddScoped<ICartViewModelBuilder, CartViewModelBuilder>();
    }

    private static void AddViewsCustomPath(IServiceCollection services)
    {
        services.Configure<RazorViewEngineOptions>(
            options => { options.ViewLocationExpanders.Add(new CustomViewLocationExpander()); }
        );
    }
}
