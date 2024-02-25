using Microsoft.AspNetCore.Mvc;
using OptiSandbox.Models;
using OptiSandbox.Models.Pages;

namespace OptiSandbox.Controllers;

public class StartPageController : PageControllerBase<StartPage>
{
    public ViewResult Index(StartPage currentPage)
    {
        PageViewModel<StartPage> model = PageViewModel.Create(currentPage);

        return View(model);
    }
}
