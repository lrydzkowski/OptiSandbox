using System.Globalization;
using EPiServer.Find;
using EPiServer.Find.Cms;
using EPiServer.Find.Framework;
using EPiServer.Web.Routing;
using OptiSandbox.Web.Content.Models.Pages;
using OptiSandbox.Web.Content.Models.ViewModels;

namespace OptiSandbox.Web.Content.Services;

public interface IStartPageViewModelBuilder
{
    StartPageViewModel Build(StartPage currentPage, int page = 1);
}

public class StartPageViewModelBuilder
    : IStartPageViewModelBuilder
{
    private readonly IUrlResolver _urlResolver;

    public StartPageViewModelBuilder(IUrlResolver urlResolver)
    {
        _urlResolver = urlResolver;
    }

    public StartPageViewModel Build(StartPage currentPage, int page = 1)
    {
        StartPageViewModel viewModel = new(currentPage)
        {
            Articles = GetArticles(page)
        };

        return viewModel;
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
