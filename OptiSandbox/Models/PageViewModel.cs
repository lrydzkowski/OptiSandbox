namespace OptiSandbox.Models;

public interface IPageViewModel<out T> where T : SitePageData
{
    T CurrentPage { get; }

    LayoutViewModel? Layout { get; set; }
}

public class PageViewModel<T> : IPageViewModel<T> where T : SitePageData
{
    public PageViewModel(T currentPage)
    {
        CurrentPage = currentPage;
    }

    public T CurrentPage { get; }

    public LayoutViewModel? Layout { get; set; }
}

public static class PageViewModel
{
    public static PageViewModel<T> Create<T>(T page) where T : SitePageData => new(page);
}
