using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using OptiSandbox.Web.Content.Models.Pages;
using OptiSandbox.Web.Content.Services;

namespace OptiSandbox.Web.Content.Controllers;

public class StartPageController : PageController<StartPage>
{
    private readonly IStartPageViewModelBuilder _startPageViewModelBuilder;

    public StartPageController(IStartPageViewModelBuilder startPageViewModelBuilder)
    {
        _startPageViewModelBuilder = startPageViewModelBuilder;
    }

    public ActionResult Index(StartPage currentPage, int page = 1)
    {
        return View(_startPageViewModelBuilder.Build(currentPage, page));
    }
}
