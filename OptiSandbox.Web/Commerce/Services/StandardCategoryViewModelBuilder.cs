using EPiServer.Commerce.Catalog;
using EPiServer.Filters;
using EPiServer.Web.Routing;
using OptiSandbox.Web.Commerce.Models;
using OptiSandbox.Web.Commerce.Models.Categories;
using OptiSandbox.Web.Commerce.Models.Products;
using OptiSandbox.Web.Commerce.Models.ViewModels;
using OptiSandbox.Web.Content.Models.ViewModels;
using OptiSandbox.Web.Content.Services;

namespace OptiSandbox.Web.Commerce.Services;

public interface IStandardCategoryViewModelBuilder
{
    StandardCategoryViewModel Build(StandardCategory standardCategory);
}

public class StandardCategoryViewModelBuilder : PageViewModelBuilder, IStandardCategoryViewModelBuilder
{
    private readonly ThumbnailUrlResolver _thumbnailUrlResolver;

    private readonly IUrlResolver _urlResolver;

    public StandardCategoryViewModelBuilder(
        IContentLoader contentLoader,
        IHttpContextAccessor httpContextAccessor,
        ThumbnailUrlResolver thumbnailUrlResolver,
        IUrlResolver urlResolver,
        IPriceResolver priceResolver,
        ICartViewModelBuilder cartViewModelBuilder
    ) :
        base(contentLoader, httpContextAccessor, priceResolver, cartViewModelBuilder)
    {
        _thumbnailUrlResolver = thumbnailUrlResolver;
        _urlResolver = urlResolver;
    }

    public StandardCategoryViewModel Build(StandardCategory standardCategory)
    {
        IPageViewModel<StandardCategory> pageViewModel = Build<StandardCategory>(standardCategory);
        StandardCategoryViewModel viewModel = new(pageViewModel)
        {
            Products = BuildProducts(standardCategory)
        };

        return viewModel;
    }

    private IReadOnlyList<CategoryProduct> BuildProducts(StandardCategory standardCategory)
    {
        IEnumerable<EbookProduct> nodes = FilterForVisitor
            .Filter(_contentLoader.GetChildren<EbookProduct>(standardCategory.ContentLink))
            .Cast<EbookProduct>();
        List<CategoryProduct> products = [];
        foreach (EbookProduct node in nodes)
        {
            products.Add(
                new CategoryProduct
                {
                    ImageUrl = _thumbnailUrlResolver.GetThumbnailUrl(node, "Thumbnail")
                               ?? _urlResolver.GetUrl(standardCategory.PlaceholderImageCategoryPage),
                    Name = node.Name,
                    Type = "E-books",
                    Price = _priceResolver.GetProductSalePrice(node)?.UnitPrice.Amount,
                    ShortDescription = node.ShortDescription ?? "",
                    ProductUrl = _urlResolver.GetUrl(node.ContentLink)
                }
            );
        }

        return products;
    }
}
