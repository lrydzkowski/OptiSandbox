using Microsoft.AspNetCore.Mvc;
using OptiSandbox.Web.Core.Controllers;
using OptiSandbox.Web.Features.Articles.Models;

namespace OptiSandbox.Web.Features.Articles.Controllers;

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
