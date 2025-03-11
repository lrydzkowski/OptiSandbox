using System.ComponentModel.DataAnnotations;
using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Commerce.Catalog.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using OptiSandbox.Web.Commerce.Catalog.SelectionFactories;

namespace OptiSandbox.Web.Commerce.Catalog.Models.Variations;

[CatalogContentType(
    DisplayName = "E-book variation",
    GUID = "8804347E-67F4-49DB-ACB1-306C846B4BCA",
    MetaClassName = "EbookVariation"
)]
public class EbookVariation : VariationContent
{
}
