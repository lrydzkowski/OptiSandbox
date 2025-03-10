using System.ComponentModel.DataAnnotations;
using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Commerce.Catalog.DataAnnotations;

namespace OptiSandbox.Web.Commerce.Catalog.Models.Products;

[CatalogContentType(
    DisplayName = "E-book product",
    GUID = "280EA86A-EEC6-4038-85DE-F8FD6832BF45",
    MetaClassName = "EbookProduct"
)]
public class EbookProduct : ProductContent
{
    [CultureSpecific]
    [Display(Name = "Short description", GroupName = SystemTabNames.Content, Order = 10)]
    public virtual string? ShortDescription { get; set; }

    [CultureSpecific]
    [Display(Name = "Long description", GroupName = SystemTabNames.Content, Order = 20)]
    public virtual XhtmlString? LongDescription { get; set; }
}
