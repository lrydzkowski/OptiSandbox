using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Commerce.Catalog.Linking;
using Mediachase.Commerce;
using Mediachase.Commerce.Catalog;
using Mediachase.Commerce.Pricing;

namespace OptiSandbox.Web.Commerce.Catalog.Services;

public interface IPriceResolver
{
    IPriceValue? GetVariantSalePrice(VariationContent variationContent);

    IPriceValue? GetProductSalePrice(ProductContent productContent);
}

public class PriceResolver
    : IPriceResolver
{
    private readonly IContentLanguageAccessor _contentLanguageAccessor;

    private readonly IContentLoader _contentLoader;

    private readonly ICurrentMarket _currentMarket;

    private readonly IPriceService _priceService;

    private readonly IRelationRepository _relationRepository;

    public PriceResolver(
        ICurrentMarket currentMarket,
        IPriceService priceService,
        IContentLanguageAccessor contentLanguageAccessor,
        IContentLoader contentLoader,
        IRelationRepository relationRepository
    )
    {
        _currentMarket = currentMarket;
        _priceService = priceService;
        _contentLanguageAccessor = contentLanguageAccessor;
        _contentLoader = contentLoader;
        _relationRepository = relationRepository;
    }

    public IPriceValue? GetVariantSalePrice(VariationContent variationContent)
    {
        PriceFilter filter = new()
        {
            Currencies = new List<Currency> { GetCurrentCurrency() }
        };
        IEnumerable<IPriceValue>? prices = _priceService.GetPrices(
            GetCurrentMarket().MarketId,
            DateTime.UtcNow,
            new CatalogKey(variationContent.Code),
            filter
        );

        return prices.OrderBy(price => price.UnitPrice.Amount).FirstOrDefault();
    }

    public IPriceValue? GetProductSalePrice(ProductContent productContent)
    {
        IPriceValue? price = _contentLoader
            .GetItems(productContent.GetVariants(_relationRepository), _contentLanguageAccessor.Language)
            .OfType<VariationContent>()
            .Select(GetVariantSalePrice)
            .Where(price => price is not null)
            .Cast<IPriceValue>()
            .OrderBy(price => price.UnitPrice.Amount)
            .FirstOrDefault();

        return price;
    }

    private Currency GetCurrentCurrency()
    {
        return GetCurrentMarket().DefaultCurrency;
    }

    private IMarket GetCurrentMarket()
    {
        return _currentMarket.GetCurrentMarket();
    }
}
