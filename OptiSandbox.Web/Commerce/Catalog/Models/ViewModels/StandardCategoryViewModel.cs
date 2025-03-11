using OptiSandbox.Web.Commerce.Catalog.Models.Categories;
using OptiSandbox.Web.Content.Models.ViewModels;

namespace OptiSandbox.Web.Commerce.Catalog.Models.ViewModels;

public class StandardCategoryViewModel : PageViewModel<StandardCategory>
{
    public StandardCategoryViewModel(IPageViewModel<StandardCategory> pageViewModel) : base(pageViewModel)
    {
    }

    public IReadOnlyList<CategoryProduct> Products { get; init; } = [];
}
