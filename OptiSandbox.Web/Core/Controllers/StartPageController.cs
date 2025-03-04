using System.Globalization;
using EPiServer.Filters;
using EPiServer.Find;
using EPiServer.Find.Cms;
using EPiServer.Find.Framework;
using EPiServer.Web.Routing;
using Microsoft.AspNetCore.Mvc;
using OptiSandbox.Web.Core.Models.Pages;
using OptiSandbox.Web.Core.Models.ViewModels;
using OptiSandbox.Web.Features.Articles.Models;

namespace OptiSandbox.Web.Core.Controllers;

public class StartPageController : PageControllerBase<StartPage>
{
    private readonly IUrlResolver _urlResolver;

    public StartPageController(IContentLoader loader, IUrlResolver urlResolver) : base(loader)
    {
        _urlResolver = urlResolver;
    }

    public ActionResult Index(StartPage currentPage, int page = 1)
    {
        return View(CreatePageViewModel(currentPage, page));
    }

    private StartPageViewModel CreatePageViewModel(StartPage currentPage, int page = 1)
    {
        StartPageViewModel viewModel = new(currentPage)
        {
            MenuPages = GetMenuPages(),
            Articles = GetArticles(page)
        };

        return viewModel;
    }

    private List<SitePageData> GetMenuPages()
    {
        return FilterForVisitor.Filter(
                _loader.GetChildren<SitePageData>(ContentReference.StartPage)
            )
            .Cast<SitePageData>()
            .Where(page => page.VisibleInMenu)
            .ToList();
    }

    private List<Article> GetArticles(int page = 1, int pageSize = 2)
    {
        ITypeSearch<ArticlePage> query = SearchClient.Instance
            .Search<ArticlePage>()
            .FilterForVisitor()
            .FilterOnCurrentSite()
            .FilterOnLanguages([CultureInfo.CurrentCulture.Name])
            .Skip((page - 1) * pageSize)
            .Take(10);

        IContentResult<SitePageData> results = query.GetContentResult();
        List<Article> articles = results.Select(
                result => new Article
                {
                    Title = result.Name,
                    CreatedAt = new DateTimeOffset(result.Created),
                    Url = _urlResolver.GetUrl(result.ContentLink)
                }
            )
            .ToList();

        return articles;
    }
}
