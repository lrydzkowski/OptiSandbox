using EPiServer.Core.Routing;
using EPiServer.Core.Routing.Pipeline;
using OptiSandbox.Web.Content.Models.Pages;

namespace OptiSandbox.Web.Content.Routers;

public class CustomPartialRouter : IPartialRouter<CustomPage, TabContext>
{
    public object RoutePartial(CustomPage customPage, UrlResolverContext urlResolverContext)
    {
        EPiServer.Core.Routing.Pipeline.Segment nextSegment = urlResolverContext.GetNextSegment();
        string tabName = nextSegment.Next.ToString();
        TabContext tabContext = new()
        {
            TabName = tabName,
            CustomPage = customPage
        };
        urlResolverContext.RemainingSegments = nextSegment.Remaining;

        return tabContext;
    }

    public PartialRouteData GetPartialVirtualPath(TabContext tabContext, UrlGeneratorContext urlGeneratorContext)
    {
        return new PartialRouteData
        {
            BasePathRoot = urlGeneratorContext.ContentLink,
            PartialVirtualPath = tabContext.TabName
        };
    }
}

public class TabContext
{
    public string? TabName { get; set; }

    public CustomPage? CustomPage { get; set; }
}
