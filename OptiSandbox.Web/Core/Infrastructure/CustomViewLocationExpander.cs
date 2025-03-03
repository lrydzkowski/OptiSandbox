using Microsoft.AspNetCore.Mvc.Razor;

namespace OptiSandbox.Web.Core.Infrastructure;

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
            "/Core/Views/{1}/{0}.cshtml",
            "/Core/Views/Shared/{0}.cshtml"
        ];

        return customViewLocations.Concat(viewLocations);
    }
}
