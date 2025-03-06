using OptiSandbox.Web.Content.Models.Pages;

namespace OptiSandbox.Web.Content.Models.ViewModels;

public interface ICurrentPageViewModel<out T> where T : SitePageData
{
    T CurrentPage { get; }
}

public class CurrentPageViewModel<T> : ICurrentPageViewModel<T> where T : SitePageData
{
    public CurrentPageViewModel(T currentPage)
    {
        CurrentPage = currentPage;
    }

    public T CurrentPage { get; }
}
