using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using OptiSandbox.Web.Commerce.Catalog.Models;

namespace OptiSandbox.Web.Commerce.Catalog.Controllers;

public class StandardCategoryController : ContentController<StandardCategory>
{
    public ActionResult Index(StandardCategory currentContent)
    {
        return View(currentContent);
    }
}
