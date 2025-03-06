using EPiServer.Filters;
using EPiServer.Web.Routing;
using OptiSandbox.Web.Content.Models.Pages;
using OptiSandbox.Web.Content.Models.ViewModels;

namespace OptiSandbox.Web.Content.Services;

public interface IPageViewModelBuilder
{
    IPageViewModel<ICurrentPageViewModel<T>> Build<T>(T page) where T : SitePageData;
    IPageViewModel<T> BuildPageViewModel<T>(T pageViewModel) where T : ICurrentPageViewModel<SitePageData>;
}

public class PageViewModelBuilder
    : IPageViewModelBuilder
{
    private readonly IContentLoader _contentLoader;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public PageViewModelBuilder(IContentLoader contentLoader, IHttpContextAccessor httpContextAccessor)
    {
        _contentLoader = contentLoader;
        _httpContextAccessor = httpContextAccessor;
    }

    public IPageViewModel<ICurrentPageViewModel<T>> Build<T>(T page) where T : SitePageData
    {
        return BuildPageViewModel(BuildCurrentPageViewModel(page));
    }

    public IPageViewModel<T> BuildPageViewModel<T>(T pageViewModel) where T : ICurrentPageViewModel<SitePageData>
    {
        StartPage startPage = GetStartPage();
        IPageViewModel<T> viewModel = new PageViewModel<T>(pageViewModel)
        {
            StartPage = startPage,
            MenuPages = GetMainMenuPages(startPage)
        };

        return viewModel;
    }

    private ICurrentPageViewModel<T> BuildCurrentPageViewModel<T>(T currentPage) where T : SitePageData
    {
        return new CurrentPageViewModel<T>(currentPage);
    }

    private StartPage GetStartPage()
    {
        return _contentLoader.Get<StartPage>(ContentReference.StartPage);
    }

    private List<MenuPage> GetMainMenuPages(StartPage startPage)
    {
        ContentReference? currentPageContentLink = _httpContextAccessor.HttpContext.GetContentLink();
        List<MenuPage> menuPages =
        [
            new()
            {
                Label = startPage.MainMenuLabel ?? startPage.Name,
                PageReference = startPage.PageLink,
                IsSelected = startPage.ContentLink.CompareToIgnoreWorkID(currentPageContentLink)
            }
        ];
        menuPages.AddRange(
            FilterForVisitor.Filter(
                    _contentLoader.GetChildren<MainPageData>(ContentReference.StartPage)
                )
                .Cast<MainPageData>()
                .Where(page => page.VisibleInMenu)
                .Select(
                    page => new MenuPage
                    {
                        Label = page.MainMenuLabel ?? page.Name,
                        PageReference = page.PageLink,
                        IsSelected = page.ContentLink.CompareToIgnoreWorkID(currentPageContentLink)
                    }
                )
        );

        return menuPages;
    }
}
