using OptiSandbox.Web.Commerce.Models.Products;
using OptiSandbox.Web.Content.Models.ViewModels;

namespace OptiSandbox.Web.Commerce.Models.ViewModels;

public class EbookProductViewModel : PageViewModel<EbookProduct>
{
    public EbookProductViewModel(IPageViewModel<EbookProduct> pageViewModel) : base(pageViewModel)
    {
    }

    public decimal? Price { get; set; }

    public string ImageUrl { get; set; } = "";

    public string Type { get; set; } = "";
}
