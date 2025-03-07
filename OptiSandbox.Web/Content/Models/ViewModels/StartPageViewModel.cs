using OptiSandbox.Web.Content.Models.Pages;

namespace OptiSandbox.Web.Content.Models.ViewModels;

public class StartPageViewModel : ICurrentPageViewModel<StartPage>
{
    public StartPageViewModel(StartPage currentPage)
    {
        CurrentPage = currentPage;
    }

    public PaginatedList<ArticlePage> Articles { get; set; } = new();

    public int ArticlesCurrentPageIndex { get; set; } = 1;

    public StartPage CurrentPage { get; }
}

public class Article
{
    public string Title { get; set; } = "";

    public DateTimeOffset CreatedAt { get; set; }

    public string Url { get; set; } = "";
}
