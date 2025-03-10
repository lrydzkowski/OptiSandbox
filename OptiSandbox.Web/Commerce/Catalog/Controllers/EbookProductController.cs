using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using OptiSandbox.Web.Commerce.Catalog.Models.Products;

namespace OptiSandbox.Web.Commerce.Catalog.Controllers;

public class EbookProductController : ContentController<EbookProduct>
{
    public IActionResult Index(EbookProduct currentPage)
    {
        return View(currentPage);
    }
}
