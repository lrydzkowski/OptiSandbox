using OptiSandbox.Web.Core.Models.Pages;

namespace OptiSandbox.Web.Core.Models.ViewModels;

public interface IPageViewModel<out T> where T : SitePageData
{
    T CurrentPage { get; }
}

public class PageViewModel<T> : IPageViewModel<T> where T : SitePageData
{
    public PageViewModel(T currentPage)
    {
        CurrentPage = currentPage;
    }

    public T CurrentPage { get; }
}
