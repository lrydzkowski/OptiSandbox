using Microsoft.AspNetCore.Mvc.Razor;

namespace OptiSandbox.Web.Content.Infrastructure;

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
            "/Content/Views/{1}/{0}.cshtml",
            "/Content/Views/Shared/{0}.cshtml"
        ];

        return customViewLocations.Concat(viewLocations);
    }
}
