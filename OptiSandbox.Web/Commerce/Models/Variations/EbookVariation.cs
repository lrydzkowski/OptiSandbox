using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Commerce.Catalog.DataAnnotations;

namespace OptiSandbox.Web.Commerce.Models.Variations;

[CatalogContentType(
    DisplayName = "E-book variation",
    GUID = "8804347E-67F4-49DB-ACB1-306C846B4BCA",
    MetaClassName = "EbookVariation"
)]
public class EbookVariation : VariationContent
{
}
