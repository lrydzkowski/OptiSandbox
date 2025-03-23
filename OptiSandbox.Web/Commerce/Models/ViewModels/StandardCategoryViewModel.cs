using OptiSandbox.Web.Commerce.Models.Categories;
using OptiSandbox.Web.Content.Models.ViewModels;

namespace OptiSandbox.Web.Commerce.Models.ViewModels;

public class StandardCategoryViewModel : PageViewModel<StandardCategory>
{
    public StandardCategoryViewModel(IPageViewModel<StandardCategory> pageViewModel) : base(pageViewModel)
    {
    }

    public IReadOnlyList<CategoryProduct> Products { get; init; } = [];
}
