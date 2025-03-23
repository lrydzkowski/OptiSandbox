using EPiServer.Web.Routing;
using OptiSandbox.Web.Commerce.Catalog.Models.Categories;
using OptiSandbox.Web.Commerce.Catalog.Models.Products;
using OptiSandbox.Web.Commerce.Catalog.Models.ViewModels;
using OptiSandbox.Web.Content.Extensions;
using OptiSandbox.Web.Content.Models.ViewModels;
using OptiSandbox.Web.Content.Services;

namespace OptiSandbox.Web.Commerce.Catalog.Services;

public interface IEbookProductViewModelBuilder
{
    EbookProductViewModel Build(EbookProduct ebookProduct);
}

public class EbookProductViewModelBuilder : PageViewModelBuilder, IEbookProductViewModelBuilder
{
    private readonly IUrlResolver _urlResolver;

    public EbookProductViewModelBuilder(
        IContentLoader contentLoader,
        IHttpContextAccessor httpContextAccessor,
        IUrlResolver urlResolver,
        IPriceResolver priceResolver,
        ICartViewModelBuilder cartViewModelBuilder
    ) :
        base(contentLoader, httpContextAccessor, priceResolver, cartViewModelBuilder)
    {
        _urlResolver = urlResolver;
    }

    public EbookProductViewModel Build(EbookProduct ebookProduct)
    {
        IPageViewModel<EbookProduct> pageViewModel = Build<EbookProduct>(ebookProduct);
        StandardCategory? standardCategory = _contentLoader.GetAncestorOrSelf(
            ebookProduct,
            (content, _) => content is StandardCategory
        ) as StandardCategory;
        EbookProductViewModel viewModel = new(pageViewModel)
        {
            Price = _priceResolver.GetProductSalePrice(ebookProduct)?.UnitPrice.Amount,
            ImageUrl = _urlResolver.GetUrl(standardCategory?.PlaceholderImageProductPage),
            Type = "E-book"
        };

        return viewModel;
    }
}
