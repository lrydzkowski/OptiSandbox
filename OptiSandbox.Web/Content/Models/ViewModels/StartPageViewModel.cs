using OptiSandbox.Web.Content.Models.Pages;

namespace OptiSandbox.Web.Content.Models.ViewModels;

public class StartPageViewModel : PageViewModel<StartPage>
{
    public StartPageViewModel(StartPage currentPage) : base(currentPage)
    {
    }

    public IReadOnlyList<Article> Articles { get; set; } = [];
}

public class Article
{
    public string Title { get; set; } = "";

    public DateTimeOffset CreatedAt { get; set; }

    public string Url { get; set; } = "";
}
