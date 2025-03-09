using EPiServer.Commerce.Routing;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;

namespace OptiSandbox.Web.Commerce;

[InitializableModule]
[ModuleDependency(typeof(EPiServer.Commerce.Initialization.InitializationModule))]
public class InitializationModule : IInitializableModule
{
    public void Initialize(InitializationEngine context)
    {
        CatalogRouteHelper.MapDefaultHierarchialRouter(false);
    }

    public void Uninitialize(InitializationEngine context)
    {
    }
}
