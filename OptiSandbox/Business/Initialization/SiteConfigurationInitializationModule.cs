using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using OptiSandbox.Business.Configuration;
using OptiSandbox.Models.Pages;

namespace OptiSandbox.Business.Initialization;

[InitializableModule]
public class SiteConfigurationInitializationModule : IConfigurableModule
{
    public void Initialize(InitializationEngine context)
    {
    }

    public void Uninitialize(InitializationEngine context)
    {
    }

    public void ConfigureContainer(ServiceConfigurationContext context)
    {
        context.Services.AddSingleton<IDynamicConfiguration>(CreateDynamicConfiguration);
    }

    private IDynamicConfiguration CreateDynamicConfiguration(IServiceProvider serviceProvider)
    {
        IContentLoader? contentLoader = serviceProvider.GetService<IContentLoader>();
        if (contentLoader == null)
        {
            throw new InvalidOperationException("It was impossible to initialize IContentLoader.");
        }

        DynamicConfiguration dynamicConfiguration = new();
        ConfigurationPage? configurationPage = contentLoader.GetChildren<ConfigurationPage>(ContentReference.RootPage)
            .FirstOrDefault();
        if (configurationPage == null)
        {
            return dynamicConfiguration;
        }

        dynamicConfiguration.OtherPagesRoot = configurationPage.OtherPagesRoot;

        return dynamicConfiguration;
    }
}
