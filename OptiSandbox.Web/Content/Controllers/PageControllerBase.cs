using EPiServer.Filters;
using EPiServer.Web.Mvc;
using OptiSandbox.Web.Content.Models.Pages;
using OptiSandbox.Web.Content.Models.ViewModels;

namespace OptiSandbox.Web.Content.Controllers;

public abstract class PageControllerBase<T> : PageController<T> where T : SitePageData
{
    protected readonly IContentLoader _loader;

    public PageControllerBase(IContentLoader loader)
    {
        _loader = loader;
    }

    protected virtual IPageViewModel<TPage> CreatePageViewModel<TPage>(TPage currentPage) where TPage : SitePageData
    {
        IPageViewModel<TPage> viewModel = new PageViewModel<TPage>(currentPage);
        viewModel.MenuPages = FilterForVisitor.Filter(
                _loader.GetChildren<SitePageData>(ContentReference.StartPage)
            )
            .Cast<SitePageData>()
            .Where(page => page.VisibleInMenu)
            .ToList();

        return viewModel;
    }
}
