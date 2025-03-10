using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Commerce.Catalog.DataAnnotations;

namespace OptiSandbox.Web.Commerce.Catalog.Models;

[CatalogContentType(
    DisplayName = "Standard category",
    MetaClassName = "StandardCategory",
    GUID = "BA9E7B8C-26E7-4DEF-A8BD-29CDDECE7A15"
)]
public class StandardCategory : NodeContent
{
}
