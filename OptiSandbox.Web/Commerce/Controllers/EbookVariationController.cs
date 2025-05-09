using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using OptiSandbox.Web.Commerce.Models.Products;
using OptiSandbox.Web.Commerce.Models.Variations;
using OptiSandbox.Web.Commerce.Services;

namespace OptiSandbox.Web.Commerce.Controllers;

public class EbookVariationController : ContentController<EbookVariation>
{
    private readonly IContentLoader _contentLoader;

    private readonly IEbookProductViewModelBuilder _ebookProductViewModelBuilder;

    public EbookVariationController(
        IContentLoader contentLoader,
        IEbookProductViewModelBuilder ebookProductViewModelBuilder
    )
    {
        _contentLoader = contentLoader;
        _ebookProductViewModelBuilder = ebookProductViewModelBuilder;
    }

    public IActionResult Index(EbookVariation currentContent)
    {
        ContentReference? contentReference = currentContent.GetParentProducts()?.FirstOrDefault();
        EbookProduct product = _contentLoader.Get<EbookProduct>(contentReference);

        return View("~/Commerce/Views/EbookProduct/Index.cshtml", _ebookProductViewModelBuilder.Build(product));
    }
}
