using EPiServer.Commerce.Order;
using EPiServer.Security;
using EPiServer.Web.Routing;
using Mediachase.Commerce.Catalog;
using Mediachase.Commerce.Pricing;
using Mediachase.Commerce.Security;
using OptiSandbox.Web.Commerce.Models.Categories;
using OptiSandbox.Web.Commerce.Models.Pages;
using OptiSandbox.Web.Commerce.Models.Variations;
using OptiSandbox.Web.Commerce.Models.ViewModels;
using OptiSandbox.Web.Content.Extensions;

namespace OptiSandbox.Web.Commerce.Services;

public interface ICartViewModelBuilder
{
    MiniCartViewModel BuildMiniCartViewModel();

    CartViewModel BuildCartViewModel(CartPage cartPage);
}

public class CartViewModelBuilder
    : ICartViewModelBuilder
{
    private readonly IContentLoader _contentLoader;

    private readonly IOrderRepository _orderRepository;

    private readonly IPriceResolver _priceResolver;

    private readonly ReferenceConverter _referenceConverter;

    private readonly IUrlResolver _urlResolver;

    public CartViewModelBuilder(
        IOrderRepository orderRepository,
        IPriceResolver priceResolver,
        IContentLoader contentLoader,
        ReferenceConverter referenceConverter,
        IUrlResolver urlResolver
    )
    {
        _orderRepository = orderRepository;
        _priceResolver = priceResolver;
        _contentLoader = contentLoader;
        _referenceConverter = referenceConverter;
        _urlResolver = urlResolver;
    }

    public MiniCartViewModel BuildMiniCartViewModel()
    {
        ICart cart = _orderRepository.LoadOrCreateCart<ICart>(
            PrincipalInfo.CurrentPrincipal.GetContactId(),
            "Default"
        );

        return new MiniCartViewModel
        {
            Items = cart.GetAllLineItems()
                .Select(
                    lineItem =>
                    {
                        IPriceValue? price = _priceResolver.GetVariantSalePrice(lineItem.Code);

                        ContentReference variationReference = _referenceConverter.GetContentLink(lineItem.Code);
                        EbookVariation variation = _contentLoader.Get<EbookVariation>(variationReference);
                        StandardCategory? standardCategory = _contentLoader.GetAncestorOrSelf(
                            variation,
                            (content, _) => content is StandardCategory
                        ) as StandardCategory;

                        MiniCartItemViewModel viewModel = new()
                        {
                            Name = lineItem.DisplayName,
                            Quantity = Convert.ToInt32(lineItem.Quantity),
                            Price = price?.UnitPrice,
                            ImageUrl = _urlResolver.GetUrl(standardCategory?.PlaceholderImageCart)
                        };

                        return viewModel;
                    }
                )
                .ToList(),
            Total = cart.GetTotal()
        };
    }

    public CartViewModel BuildCartViewModel(CartPage cartPage)
    {
        ICart cart = _orderRepository.LoadOrCreateCart<ICart>(
            PrincipalInfo.CurrentPrincipal.GetContactId(),
            "Default"
        );

        return new CartViewModel
        {
            Items = cart.GetAllLineItems()
                .Select(
                    lineItem =>
                    {
                        IPriceValue? price = _priceResolver.GetVariantSalePrice(lineItem.Code);

                        ContentReference variationReference = _referenceConverter.GetContentLink(lineItem.Code);
                        EbookVariation variation = _contentLoader.Get<EbookVariation>(variationReference);
                        StandardCategory? standardCategory = _contentLoader.GetAncestorOrSelf(
                            variation,
                            (content, _) => content is StandardCategory
                        ) as StandardCategory;

                        CartItemViewModel viewModel = new()
                        {
                            Name = lineItem.DisplayName,
                            Quantity = Convert.ToInt32(lineItem.Quantity),
                            Price = price?.UnitPrice,
                            ImageUrl = _urlResolver.GetUrl(standardCategory?.PlaceholderImageCart)
                        };

                        return viewModel;
                    }
                )
                .ToList(),
            Total = cart.GetTotal()
        };
    }
}
