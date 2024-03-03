using EPiServer.Framework.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OptiSandbox.Models;

namespace OptiSandbox.Controllers;

[TemplateDescriptor(Inherited = true)]
public class DefaultPageController : PageControllerBase<SitePageData>
{
    public ViewResult Index(SitePageData currentPage)
    {
        IPageViewModel<SitePageData>? model = CreateModel(currentPage);

        return View($"~/Views/{currentPage.GetOriginalType().Name}/Index.cshtml", model);
    }

    private static IPageViewModel<SitePageData>? CreateModel(SitePageData page)
    {
        Type type = typeof(PageViewModel<>).MakeGenericType(page.GetOriginalType());
        object? instance = Activator.CreateInstance(type, page);

        return instance as IPageViewModel<SitePageData>;
    }
}
