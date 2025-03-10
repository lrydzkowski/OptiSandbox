using Microsoft.AspNetCore.Mvc.Razor;

namespace OptiSandbox.Web.Commerce.Catalog.Infrastructure;

public class CustomViewLocationExpander : IViewLocationExpander
{
    public void PopulateValues(ViewLocationExpanderContext context)
    {
    }

    public IEnumerable<string> ExpandViewLocations(
        ViewLocationExpanderContext context,
        IEnumerable<string> viewLocations
    )
    {
        IEnumerable<string> customViewLocations =
        [
            "/Commerce/Catalog/Views/{1}/{0}.cshtml",
            "/Commerce/Catalog/Views/Shared/{0}.cshtml"
        ];

        return customViewLocations.Concat(viewLocations);
    }
}
