using System.Globalization;
using EPiServer.Find;
using EPiServer.Find.Cms;
using EPiServer.Find.Framework;
using OptiSandbox.Web.Content.Models;
using OptiSandbox.Web.Content.Models.Pages;
using OptiSandbox.Web.Content.Models.ViewModels;

namespace OptiSandbox.Web.Content.Services;

public interface IStartPageViewModelBuilder
{
    StartPageViewModel Build(StartPage currentPage, int page = 1);
}

public class StartPageViewModelBuilder
    : PageViewModelBuilder, IStartPageViewModelBuilder
{
    public StartPageViewModelBuilder(IContentLoader contentLoader, IHttpContextAccessor httpContextAccessor) : base(
        contentLoader,
        httpContextAccessor
    )
    {
    }

    public StartPageViewModel Build(StartPage currentPage, int page = 1)
    {
        IPageViewModel<StartPage> pageViewModel = Build<StartPage>(currentPage);
        StartPageViewModel viewModel = new(pageViewModel)
        {
            Articles = GetArticles(page),
            ArticlesCurrentPageIndex = page
        };

        return viewModel;
    }

    private PaginatedList<ArticlePage> GetArticles(int page = 1, int pageSize = 3)
    {
        ITypeSearch<ArticlePage> query = SearchClient.Instance
            .Search<ArticlePage>()
            .FilterForVisitor()
            .FilterOnCurrentSite()
            .FilterOnLanguages([CultureInfo.CurrentCulture.Name]);
        ITypeSearch<ArticlePage> paginatedQuery = query.Skip((page - 1) * pageSize)
            .Take(pageSize);
        IContentResult<ArticlePage> results = paginatedQuery.GetContentResult();
        int count = query.Count();

        PaginatedList<ArticlePage> paginatedList = new()
        {
            Data = results.ToList(),
            Count = count,
            PageSize = pageSize
        };

        return paginatedList;
    }
}
