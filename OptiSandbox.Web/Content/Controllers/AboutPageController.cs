using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using OptiSandbox.Web.Content.Models.Pages;
using OptiSandbox.Web.Content.Services;

namespace OptiSandbox.Web.Content.Controllers;

public class AboutPageController : PageController<AboutPage>
{
    private readonly IPageViewModelBuilder _pageViewModelBuilder;

    public AboutPageController(IPageViewModelBuilder pageViewModelBuilder)
    {
        _pageViewModelBuilder = pageViewModelBuilder;
    }

    public ActionResult Index(AboutPage currentPage)
    {
        return View(_pageViewModelBuilder.Build(currentPage));
    }
}
