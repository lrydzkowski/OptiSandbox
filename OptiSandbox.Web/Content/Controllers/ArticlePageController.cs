using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using OptiSandbox.Web.Content.Models.Pages;
using OptiSandbox.Web.Content.Services;

namespace OptiSandbox.Web.Content.Controllers;

public class ArticlePageController : PageController<ArticlePage>
{
    private readonly IPageViewModelBuilder _pageViewModelBuilder;

    public ArticlePageController(IPageViewModelBuilder pageViewModelBuilder)
    {
        _pageViewModelBuilder = pageViewModelBuilder;
    }

    public ActionResult Index(ArticlePage currentPage)
    {
        return View(_pageViewModelBuilder.Build(currentPage));
    }
}
