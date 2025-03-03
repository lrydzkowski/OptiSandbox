using Microsoft.AspNetCore.Mvc;
using OptiSandbox.Web.Core.Models.Pages;

namespace OptiSandbox.Web.Core.Controllers;

public class StandardPageController : PageControllerBase<StandardPage>
{
    public StandardPageController(IContentLoader loader) : base(loader)
    {
    }

    public ActionResult Index(StandardPage currentPage)
    {
        return View(CreatePageViewModel(currentPage));
    }
}
