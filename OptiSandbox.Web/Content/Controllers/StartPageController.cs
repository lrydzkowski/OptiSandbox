using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using OptiSandbox.Web.Content.Models.Pages;
using OptiSandbox.Web.Content.Services;

namespace OptiSandbox.Web.Content.Controllers;

public class StartPageController : PageController<StartPage>
{
    private readonly IPageViewModelBuilder _pageViewModelBuilder;
    private readonly IStartPageViewModelBuilder _startPageViewModelBuilder;

    public StartPageController(
        IPageViewModelBuilder pageViewModelBuilder,
        IStartPageViewModelBuilder startPageViewModelBuilder
    )
    {
        _pageViewModelBuilder = pageViewModelBuilder;
        _startPageViewModelBuilder = startPageViewModelBuilder;
    }

    public ActionResult Index(StartPage currentPage, int page = 1)
    {
        return View(_pageViewModelBuilder.BuildPageViewModel(_startPageViewModelBuilder.Build(currentPage, page)));
    }
}
