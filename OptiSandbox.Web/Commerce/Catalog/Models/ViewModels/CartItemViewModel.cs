using Mediachase.Commerce;

namespace OptiSandbox.Web.Commerce.Catalog.Models.ViewModels;

public class CartItemViewModel
{
    public string Name { get; init; } = "";

    public string? ImageUrl { get; init; }

    public Money? Price { get; init; }

    public int Quantity { get; init; }
}
