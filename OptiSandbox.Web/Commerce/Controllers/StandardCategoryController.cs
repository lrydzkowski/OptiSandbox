using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using OptiSandbox.Web.Commerce.Models.Categories;
using OptiSandbox.Web.Commerce.Services;

namespace OptiSandbox.Web.Commerce.Controllers;

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
