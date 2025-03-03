using EPiServer.Web.Mvc;
using OptiSandbox.Web.Core.Models.Pages;
using OptiSandbox.Web.Core.Models.ViewModels;

namespace OptiSandbox.Web.Core.Controllers;

public abstract class PageControllerBase<T> : PageController<T> where T : SitePageData
{
    protected readonly IContentLoader _loader;

    public PageControllerBase(IContentLoader loader)
    {
        _loader = loader;
    }

    protected IPageViewModel<TPage> CreatePageViewModel<TPage>(TPage currentPage) where TPage : SitePageData
    {
        IPageViewModel<TPage> viewModel = new PageViewModel<TPage>(currentPage);

        return viewModel;
    }
}
