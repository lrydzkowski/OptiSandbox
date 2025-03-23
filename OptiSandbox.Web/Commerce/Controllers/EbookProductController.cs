using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Commerce.Order;
using EPiServer.Security;
using EPiServer.Web.Mvc;
using Mediachase.Commerce.Security;
using Microsoft.AspNetCore.Mvc;
using OptiSandbox.Web.Commerce.Models.Products;
using OptiSandbox.Web.Commerce.Models.Variations;
using OptiSandbox.Web.Commerce.Services;

namespace OptiSandbox.Web.Commerce.Controllers;

public class EbookProductController : ContentController<EbookProduct>
{
    private readonly IContentLoader _contentLoader;

    private readonly IEbookProductViewModelBuilder _ebookProductViewModelBuilder;

    private readonly IOrderGroupFactory _orderGroupFactory;

    private readonly IOrderRepository _orderRepository;

    public EbookProductController(
        IEbookProductViewModelBuilder ebookProductViewModelBuilder,
        IContentLoader contentLoader,
        IOrderRepository orderRepository,
        IOrderGroupFactory orderGroupFactory
    )
    {
        _ebookProductViewModelBuilder = ebookProductViewModelBuilder;
        _contentLoader = contentLoader;
        _orderRepository = orderRepository;
        _orderGroupFactory = orderGroupFactory;
    }

    public IActionResult Index(EbookProduct currentPage)
    {
        return View(_ebookProductViewModelBuilder.Build(currentPage));
    }

    [HttpPost]
    public IActionResult AddToCart(EbookProduct currentPage, int quantity)
    {
        EbookVariation variation = _contentLoader.Get<EbookVariation>(currentPage.GetVariants().FirstOrDefault());
        string code = variation.Code;

        ICart cart = _orderRepository.LoadOrCreateCart<ICart>(
            PrincipalInfo.CurrentPrincipal.GetContactId(),
            "Default"
        );
        ILineItem? lineItem = cart.GetAllLineItems().SingleOrDefault(x => x.Code == code);
        if (lineItem is null)
        {
            lineItem = _orderGroupFactory.CreateLineItem(code, cart);
            lineItem.Quantity = quantity;

            cart.AddLineItem(lineItem);
        }
        else
        {
            lineItem.Quantity += quantity;
        }

        _orderRepository.Save(cart);

        return View(
            "~/Commerce/Views/EbookProduct/Index.cshtml",
            _ebookProductViewModelBuilder.Build(currentPage)
        );
    }
}
