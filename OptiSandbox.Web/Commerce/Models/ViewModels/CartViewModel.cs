using Mediachase.Commerce;

namespace OptiSandbox.Web.Commerce.Models.ViewModels;

public class CartViewModel
{
    public IReadOnlyList<CartItemViewModel> Items { get; init; } = [];

    public Money Total { get; init; }
}

public class CartItemViewModel
{
    public string Name { get; init; } = "";

    public string? ImageUrl { get; init; }

    public Money? Price { get; init; }

    public int Quantity { get; init; }
}
