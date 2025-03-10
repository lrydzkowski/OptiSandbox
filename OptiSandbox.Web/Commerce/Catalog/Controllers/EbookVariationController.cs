using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using OptiSandbox.Web.Commerce.Catalog.Models.Variations;

namespace OptiSandbox.Web.Commerce.Catalog.Controllers;

public class EbookVariationController : ContentController<EbookVariation>
{
    public IActionResult Index(EbookVariation currentContent)
    {
        return View(currentContent);
    }
}
