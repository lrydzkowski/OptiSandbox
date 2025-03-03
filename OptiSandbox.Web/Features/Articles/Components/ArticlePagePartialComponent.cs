using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using OptiSandbox.Web.Core.Models.ViewModels;
using OptiSandbox.Web.Features.Articles.Models;

namespace OptiSandbox.Web.Features.Articles.Components;

public class ArticlePagePartialComponent : PartialContentComponent<ArticlePage>
{
    protected override IViewComponentResult InvokeComponent(ArticlePage currentContent)
    {
        return View(new PageViewModel<ArticlePage>(currentContent));
    }
}
