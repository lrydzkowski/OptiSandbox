namespace OptiSandbox.Web.Commerce.Catalog.Models;

public class CategoryProduct
{
    public string ImageUrl { get; set; } = "";

    public string Name { get; set; } = "";

    public string Type { get; set; } = "";

    public string ShortDescription { get; set; } = "";

    public decimal? Price { get; set; }

    public string ProductUrl { get; set; } = "";
}
