using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using OptiSandbox.Web.Commerce.Catalog.Models.Products;
using OptiSandbox.Web.Content.Services;

namespace OptiSandbox.Web.Commerce.Catalog.Controllers;

public class EbookProductController : ContentController<EbookProduct>
{
    private readonly IPageViewModelBuilder _pageViewModelBuilder;

    public EbookProductController(IPageViewModelBuilder pageViewModelBuilder)
    {
        _pageViewModelBuilder = pageViewModelBuilder;
    }

    public IActionResult Index(EbookProduct currentPage)
    {
        return View(_pageViewModelBuilder.Build(currentPage));
    }
}
