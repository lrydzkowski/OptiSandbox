using Mediachase.Commerce;

namespace OptiSandbox.Web.Commerce.Catalog.Models.ViewModels;

public class CartViewModel
{
    public IReadOnlyList<CartItemViewModel> Items { get; init; } = [];

    public Money Total { get; init; }
}
