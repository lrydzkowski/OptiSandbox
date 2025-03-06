using OptiSandbox.Web.Content.Models.Pages;

namespace OptiSandbox.Web.Content.Models.ViewModels;

public interface IPageViewModel<out T> where T : ICurrentPageViewModel<SitePageData>
{
    public IReadOnlyList<MenuPage> MenuPages { get; set; }

    T CurrentPageViewModel { get; }

    StartPage StartPage { get; set; }
}

public class PageViewModel<T> : IPageViewModel<T> where T : ICurrentPageViewModel<SitePageData>
{
    public PageViewModel(T currentPage)
    {
        CurrentPageViewModel = currentPage;
    }

    public IReadOnlyList<MenuPage> MenuPages { get; set; } = [];

    public T CurrentPageViewModel { get; }

    public required StartPage StartPage { get; set; }
}

public class MenuPage
{
    public string Label { get; set; } = "";

    public PageReference? PageReference { get; set; }

    public bool IsSelected { get; set; }
}
