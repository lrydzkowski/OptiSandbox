using EPiServer.Commerce.Catalog;
using EPiServer.Filters;
using EPiServer.Web.Routing;
using OptiSandbox.Web.Commerce.Catalog.Models;
using OptiSandbox.Web.Commerce.Catalog.Models.Categories;
using OptiSandbox.Web.Commerce.Catalog.Models.Products;
using OptiSandbox.Web.Commerce.Catalog.Models.ViewModels;
using OptiSandbox.Web.Content.Models.ViewModels;
using OptiSandbox.Web.Content.Services;

namespace OptiSandbox.Web.Commerce.Catalog.Services;

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
        IUrlResolver urlResolver
    ) :
        base(contentLoader, httpContextAccessor)
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
                    Type = node.ContentType.ToString(),
                    Price = 1,
                    ShortDescription = node.ShortDescription ?? "",
                    ProductUrl = _urlResolver.GetUrl(node.ContentLink)
                }
            );
        }

        return products;
    }
}
