using Microsoft.AspNetCore.Mvc.Razor;

namespace OptiSandbox.Business.Rendering;

public class SiteViewEngineLocationExpander : IViewLocationExpander
{
    private static readonly string[] AdditionalPartialViewFormats =
    [
        TemplateCoordinator.PagePartialsFolder + "{0}.cshtml"
    ];

    public IEnumerable<string> ExpandViewLocations(
        ViewLocationExpanderContext context,
        IEnumerable<string> viewLocations
    )
    {
        foreach (string location in viewLocations)
        {
            yield return location;
        }

        for (int i = 0; i < AdditionalPartialViewFormats.Length; i++)
        {
            yield return AdditionalPartialViewFormats[i];
        }
    }

    public void PopulateValues(ViewLocationExpanderContext context)
    {
    }
}
