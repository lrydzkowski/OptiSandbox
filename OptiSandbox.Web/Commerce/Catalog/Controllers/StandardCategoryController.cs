using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using OptiSandbox.Web.Commerce.Catalog.Models.Categories;
using OptiSandbox.Web.Content.Services;

namespace OptiSandbox.Web.Commerce.Catalog.Controllers;

public class StandardCategoryController : ContentController<StandardCategory>
{
    private readonly IPageViewModelBuilder _pageViewModelBuilder;

    public StandardCategoryController(IPageViewModelBuilder pageViewModelBuilder)
    {
        _pageViewModelBuilder = pageViewModelBuilder;
    }

    public ActionResult Index(StandardCategory currentContent)
    {
        return View(_pageViewModelBuilder.Build(currentContent));
    }
}
