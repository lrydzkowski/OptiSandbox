using Microsoft.AspNetCore.Mvc;
using OptiSandbox.Web.Content.Models.Pages;

namespace OptiSandbox.Web.Content.Controllers;

public class ArticlePageController : PageControllerBase<ArticlePage>
{
    public ArticlePageController(IContentLoader loader) : base(loader)
    {
    }

    public ActionResult Index(ArticlePage currentPage)
    {
        return View(CreatePageViewModel(currentPage));
    }
}
