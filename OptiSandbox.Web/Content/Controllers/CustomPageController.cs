using EPiServer.Web;
using EPiServer.Web.Mvc;
using EPiServer.Web.Routing.Matching;
using Microsoft.AspNetCore.Mvc;
using OptiSandbox.Web.Content.Models.Pages;
using OptiSandbox.Web.Content.Routers;
using OptiSandbox.Web.Content.Services;

namespace OptiSandbox.Web.Content.Controllers;

public class CustomPageController : PageController<CustomPage>
{
    private readonly IPageViewModelBuilder _pageViewModelBuilder;

    public CustomPageController(IPageViewModelBuilder pageViewModelBuilder)
    {
        _pageViewModelBuilder = pageViewModelBuilder;
    }

    public ActionResult Index(CustomPage currentPage)
    {
        TabContext? tabContext =
            HttpContext.Features.Get<IContentRouteFeature>()?.RoutedContentData.PartialRoutedObject as TabContext;

        return View(_pageViewModelBuilder.Build(currentPage));
    }
}

public class CustomPageTabController : Controller, IRenderTemplate<TabContext>
{
    private readonly IPageViewModelBuilder _pageViewModelBuilder;

    public CustomPageTabController(IPageViewModelBuilder pageViewModelBuilder)
    {
        _pageViewModelBuilder = pageViewModelBuilder;
    }

    public ActionResult Index()
    {
        TabContext? tabContext =
            HttpContext.Features.Get<IContentRouteFeature>()?.RoutedContentData.PartialRoutedObject as TabContext;

        return View(
            "/Content/Views/CustomPage/Index.cshtml",
            _pageViewModelBuilder.Build(tabContext?.CustomPage ?? new CustomPage())
        );
    }
}
