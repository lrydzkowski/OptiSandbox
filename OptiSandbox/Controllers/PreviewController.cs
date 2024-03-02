using EPiServer.Framework.DataAnnotations;
using EPiServer.Framework.Web;
using EPiServer.Framework.Web.Mvc;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using OptiSandbox.Business;
using OptiSandbox.Models;
using OptiSandbox.Models.Pages;
using OptiSandbox.Models.ViewModels;

namespace OptiSandbox.Controllers;

[TemplateDescriptor(
    Inherited = true,
    TemplateTypeCategory = TemplateTypeCategories.MvcController,
    Tags =
    [
        RenderingTags.Preview, RenderingTags.Edit
    ],
    AvailableWithoutTag = false
)]
[VisitorGroupImpersonation]
[RequireClientResources]
public class PreviewController : ActionControllerBase, IRenderTemplate<BlockData>, IModifyLayout
{
    private readonly IContentLoader _contentLoader;

    public PreviewController(IContentLoader contentLoader)
    {
        _contentLoader = contentLoader;
    }

    public IActionResult Index(IContent currentContent)
    {
        StartPage? startPage = _contentLoader.Get<StartPage>(SiteDefinition.Current.StartPage);
        PreviewModel model = new(startPage, currentContent);

        return View(model);
    }

    public void ModifyLayout(LayoutViewModel layoutModel)
    {
        layoutModel.HideHeader = true;
        layoutModel.HideFooter = true;
    }
}
