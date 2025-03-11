using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using OptiSandbox.Web.Commerce.Catalog.Models.Categories;
using OptiSandbox.Web.Commerce.Catalog.Services;

namespace OptiSandbox.Web.Commerce.Catalog.Controllers;

public class StandardCategoryController : ContentController<StandardCategory>
{
    private readonly IStandardCategoryViewModelBuilder _standardCategoryViewModelBuilder;

    public StandardCategoryController(IStandardCategoryViewModelBuilder standardCategoryViewModelBuilder)
    {
        _standardCategoryViewModelBuilder = standardCategoryViewModelBuilder;
    }

    public ActionResult Index(StandardCategory currentContent)
    {
        return View(_standardCategoryViewModelBuilder.Build(currentContent));
    }
}
