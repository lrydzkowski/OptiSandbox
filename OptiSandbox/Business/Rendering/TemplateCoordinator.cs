using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;
using OptiSandbox.Models;

namespace OptiSandbox.Business.Rendering;

[ServiceConfiguration(typeof(IViewTemplateModelRegistrator))]
public class TemplateCoordinator : IViewTemplateModelRegistrator
{
    public const string PagePartialsFolder = "~/Views/Shared/PagePartials/";

    public void Register(TemplateModelCollection viewTemplateModelRegistrator)
    {
        viewTemplateModelRegistrator.Add(
            typeof(SitePageData),
            new TemplateModel
            {
                Name = "Page",
                Inherit = true,
                AvailableWithoutTag = true,
                Path = PagePartialPath("Page.cshtml")
            }
        );
    }

    private static string PagePartialPath(string fileName) => $"{PagePartialsFolder}{fileName}";
}
