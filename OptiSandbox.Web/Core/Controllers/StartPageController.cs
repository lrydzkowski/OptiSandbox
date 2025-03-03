using Microsoft.AspNetCore.Mvc;
using OptiSandbox.Web.Core.Models.Pages;

namespace OptiSandbox.Web.Core.Controllers;

public class StartPageController : PageControllerBase<StartPage>
{
    public StartPageController(IContentLoader loader) : base(loader)
    {
    }

    public ActionResult Index(StartPage currentPage)
    {
        return View(CreatePageViewModel(currentPage));
    }
}
