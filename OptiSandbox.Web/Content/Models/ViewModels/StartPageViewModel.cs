using OptiSandbox.Web.Content.Models.Pages;

namespace OptiSandbox.Web.Content.Models.ViewModels;

public class StartPageViewModel : PageViewModel<StartPage>
{
    public StartPageViewModel(IPageViewModel<StartPage> pageViewModel) : base(pageViewModel)
    {
    }

    public PaginatedList<ArticlePage> Articles { get; init; } = new();

    public int ArticlesCurrentPageIndex { get; init; } = 1;
}
