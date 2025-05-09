using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using OptiSandbox.Web.Content.Models.Pages;
using OptiSandbox.Web.Content.Services;

namespace OptiSandbox.Web.Content.Components;

public class ArticlePagePartialComponent : PartialContentComponent<ArticlePage>
{
    private readonly IPageViewModelBuilder _pageViewModelBuilder;

    public ArticlePagePartialComponent(IPageViewModelBuilder pageViewModelBuilder)
    {
        _pageViewModelBuilder = pageViewModelBuilder;
    }

    protected override IViewComponentResult InvokeComponent(ArticlePage currentPage)
    {
        return View(_pageViewModelBuilder.Build(currentPage));
    }
}
