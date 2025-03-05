using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using OptiSandbox.Web.Content.Models.Pages;
using OptiSandbox.Web.Content.Models.ViewModels;

namespace OptiSandbox.Web.Content.Components;

public class ArticlePagePartialComponent : PartialContentComponent<ArticlePage>
{
    protected override IViewComponentResult InvokeComponent(ArticlePage currentContent)
    {
        return View(new PageViewModel<ArticlePage>(currentContent));
    }
}
