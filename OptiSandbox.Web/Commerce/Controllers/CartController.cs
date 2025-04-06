using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using OptiSandbox.Web.Commerce.Models.Pages;
using OptiSandbox.Web.Commerce.Services;

namespace OptiSandbox.Web.Commerce.Controllers;

public class CartController : PageController<CartPage>
{
    private readonly ICartViewModelBuilder _cartViewModelBuilder;

    public CartController(ICartViewModelBuilder cartViewModelBuilder)
    {
        _cartViewModelBuilder = cartViewModelBuilder;
    }

    public ActionResult Index(CartPage currentPage)
    {
        return View(_cartViewModelBuilder.BuildCartViewModel(currentPage));
    }
}
