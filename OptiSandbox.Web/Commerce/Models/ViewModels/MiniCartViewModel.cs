using Mediachase.Commerce;

namespace OptiSandbox.Web.Commerce.Models.ViewModels;

public class MiniCartViewModel
{
    public IReadOnlyList<MiniCartItemViewModel> Items { get; init; } = [];

    public Money Total { get; init; }
}

public class MiniCartItemViewModel
{
    public string Name { get; init; } = "";

    public string? ImageUrl { get; init; }

    public Money? Price { get; init; }

    public int Quantity { get; init; }
}
