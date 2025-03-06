using OptiSandbox.Web.Content.Models.Pages;

namespace OptiSandbox.Web.Content.Models.ViewModels;

public class StartPageViewModel : ICurrentPageViewModel<StartPage>
{
    public StartPageViewModel(StartPage currentPage)
    {
        CurrentPage = currentPage;
    }

    public IReadOnlyList<Article> Articles { get; set; } = [];

    public StartPage CurrentPage { get; }
}

public class Article
{
    public string Title { get; set; } = "";

    public DateTimeOffset CreatedAt { get; set; }

    public string Url { get; set; } = "";
}
