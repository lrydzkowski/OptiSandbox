using OptiSandbox.Web.Content.Models.Pages;

namespace OptiSandbox.Web.Content.Models.ViewModels;

public interface IPageViewModel<out T> where T : SitePageData
{
    public IReadOnlyList<SitePageData> MenuPages { get; set; }

    T CurrentPage { get; }
}

public class PageViewModel<T> : IPageViewModel<T> where T : SitePageData
{
    public PageViewModel(T currentPage)
    {
        CurrentPage = currentPage;
    }

    public IReadOnlyList<SitePageData> MenuPages { get; set; } = [];

    public T CurrentPage { get; }
}
