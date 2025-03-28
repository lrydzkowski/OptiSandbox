using OptiSandbox.Web.Commerce.Models.ViewModels;
using OptiSandbox.Web.Content.Models.Pages;

namespace OptiSandbox.Web.Content.Models.ViewModels;

public interface IPageViewModel<out T> where T : IContent
{
    StartPage StartPage { get; init; }

    public IReadOnlyList<MenuPage> MenuPages { get; init; }

    IReadOnlyList<ContentReference> Ancestors { get; init; }

    bool EnableBreadcrumbs { get; init; }

    T CurrentContent { get; }

    MiniCartViewModel MiniCart { get; init; }
}

public class PageViewModel<T> : IPageViewModel<T> where T : IContent
{
    public PageViewModel()
    {
    }

    public PageViewModel(IPageViewModel<T> pageViewModel)
    {
        StartPage = pageViewModel.StartPage;
        MenuPages = pageViewModel.MenuPages;
        Ancestors = pageViewModel.Ancestors;
        CurrentContent = pageViewModel.CurrentContent;
        MiniCart = pageViewModel.MiniCart;
    }

    public StartPage StartPage { get; init; } = new();

    public IReadOnlyList<MenuPage> MenuPages { get; init; } = [];

    public IReadOnlyList<ContentReference> Ancestors { get; init; } = [];

    public bool EnableBreadcrumbs { get; init; }

    public T CurrentContent { get; init; } = default!;

    public MiniCartViewModel MiniCart { get; init; } = new();
}
