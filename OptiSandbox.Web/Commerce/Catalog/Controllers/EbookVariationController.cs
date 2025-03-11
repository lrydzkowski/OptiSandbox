using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using OptiSandbox.Web.Commerce.Catalog.Models.Variations;
using OptiSandbox.Web.Content.Services;

namespace OptiSandbox.Web.Commerce.Catalog.Controllers;

public class EbookVariationController : ContentController<EbookVariation>
{
    private readonly IPageViewModelBuilder _pageViewModelBuilder;

    public EbookVariationController(IPageViewModelBuilder pageViewModelBuilder)
    {
        _pageViewModelBuilder = pageViewModelBuilder;
    }

    public IActionResult Index(EbookVariation currentContent)
    {
        return View(_pageViewModelBuilder.Build(currentContent));
    }
}
