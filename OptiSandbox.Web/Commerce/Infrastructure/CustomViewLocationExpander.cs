using Microsoft.AspNetCore.Mvc.Razor;

namespace OptiSandbox.Web.Commerce.Infrastructure;

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
            "/Commerce/Views/{1}/{0}.cshtml",
            "/Commerce/Views/Shared/{0}.cshtml"
        ];

        return customViewLocations.Concat(viewLocations);
    }
}
