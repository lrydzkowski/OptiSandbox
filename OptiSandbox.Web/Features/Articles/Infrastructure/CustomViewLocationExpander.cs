using Microsoft.AspNetCore.Mvc.Razor;

namespace OptiSandbox.Web.Features.Articles.Infrastructure;

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
            "/Features/Articles/Views/{1}/{0}.cshtml",
            "/Features/Articles/Views/Shared/{0}.cshtml"
        ];

        return customViewLocations.Concat(viewLocations);
    }
}
