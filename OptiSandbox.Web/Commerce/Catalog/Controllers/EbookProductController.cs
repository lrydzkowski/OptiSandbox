using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using OptiSandbox.Web.Commerce.Catalog.Models.Products;
using OptiSandbox.Web.Commerce.Catalog.Services;

namespace OptiSandbox.Web.Commerce.Catalog.Controllers;

public class EbookProductController : ContentController<EbookProduct>
{
    private readonly IEbookProductViewModelBuilder _ebookProductViewModelBuilder;

    public EbookProductController(IEbookProductViewModelBuilder ebookProductViewModelBuilder)
    {
        _ebookProductViewModelBuilder = ebookProductViewModelBuilder;
    }

    public IActionResult Index(EbookProduct currentPage)
    {
        return View(_ebookProductViewModelBuilder.Build(currentPage));
    }
}
