using EPiServer.Filters;
using EPiServer.Web.Routing;
using OptiSandbox.Web.Commerce.Models.Categories;
using OptiSandbox.Web.Commerce.Services;
using OptiSandbox.Web.Content.Models;
using OptiSandbox.Web.Content.Models.Pages;
using OptiSandbox.Web.Content.Models.ViewModels;

namespace OptiSandbox.Web.Content.Services;

public interface IPageViewModelBuilder
{
    IPageViewModel<T> Build<T>(T currentContent) where T : IContent;
}

public class PageViewModelBuilder
    : IPageViewModelBuilder
{
    private readonly ICartViewModelBuilder _cartViewModelBuilder;

    protected readonly IContentLoader _contentLoader;

    private readonly IHttpContextAccessor _httpContextAccessor;

    protected readonly IPriceResolver _priceResolver;

    public PageViewModelBuilder(
        IContentLoader contentLoader,
        IHttpContextAccessor httpContextAccessor,
        IPriceResolver priceResolver,
        ICartViewModelBuilder cartViewModelBuilder
    )
    {
        _contentLoader = contentLoader;
        _httpContextAccessor = httpContextAccessor;
        _priceResolver = priceResolver;
        _cartViewModelBuilder = cartViewModelBuilder;
    }

    public IPageViewModel<T> Build<T>(T currentContent) where T : IContent
    {
        StartPage startPage = GetStartPage();
        IPageViewModel<T> viewModel = new PageViewModel<T>
        {
            StartPage = startPage,
            MenuPages = GetMainMenuPages(startPage),
            Ancestors = GetAncestors(),
            CurrentContent = currentContent,
            EnableBreadcrumbs = (currentContent as ISitePage)?.EnableBreadcrumbs ?? false,
            MiniCart = _cartViewModelBuilder.BuildMiniCartViewModel()
        };

        return viewModel;
    }

    private StartPage GetStartPage()
    {
        return _contentLoader.Get<StartPage>(ContentReference.StartPage);
    }

    private List<MenuPage> GetMainMenuPages(StartPage startPage)
    {
        ContentReference? currentPageContentLink = _httpContextAccessor.HttpContext.GetContentLink();
        List<MenuPage> menuPages = [];
        AddMainPage(menuPages, startPage, currentPageContentLink);
        AddPages(menuPages, currentPageContentLink);
        AddProductsPage(menuPages, startPage, currentPageContentLink);

        return menuPages;
    }

    private void AddMainPage(List<MenuPage> menuPages, StartPage startPage, ContentReference currentPageContentLink)
    {
        menuPages.Add(
            new MenuPage
            {
                Label = startPage.MainMenuLabel ?? startPage.Name,
                PageReference = startPage.PageLink,
                IsSelected = startPage.ContentLink.CompareToIgnoreWorkID(currentPageContentLink)
            }
        );
    }

    private void AddPages(List<MenuPage> menuPages, ContentReference currentPageContentLink)
    {
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
    }

    private void AddProductsPage(List<MenuPage> menuPages, StartPage startPage, ContentReference currentPageContentLink)
    {
        ContentReference? productsPageReference = startPage.ProductsCatalog;
        if (productsPageReference is null)
        {
            return;
        }

        StandardCategory? productsPage = _contentLoader.Get<IContent>(productsPageReference) as StandardCategory;
        if (productsPage is null)
        {
            return;
        }

        menuPages.Add(
            new MenuPage
            {
                Label = productsPage.MainMenuLabel ?? productsPage.Name,
                PageReference = productsPageReference,
                IsSelected = productsPageReference.CompareToIgnoreWorkID(currentPageContentLink)
            }
        );
    }

    private List<ContentReference> GetAncestors()
    {
        ContentReference? currentPageContentLink = _httpContextAccessor.HttpContext.GetContentLink();
        if (ContentReference.IsNullOrEmpty(currentPageContentLink))
        {
            return [];
        }

        List<ContentReference> ancestors = _contentLoader.GetAncestors(currentPageContentLink)
            .Select(ancestor => ancestor.ContentLink)
            .Reverse()
            .Skip(1)
            .ToList();
        ancestors.Add(currentPageContentLink);

        return ancestors;
    }
}
