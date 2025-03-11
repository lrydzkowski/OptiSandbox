using System.ComponentModel.DataAnnotations;
using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Commerce.Catalog.DataAnnotations;
using OptiSandbox.Web.Content.Models.Pages;

namespace OptiSandbox.Web.Commerce.Catalog.Models.Categories;

[CatalogContentType(
    DisplayName = "Standard category",
    MetaClassName = "StandardCategory",
    GUID = "BA9E7B8C-26E7-4DEF-A8BD-29CDDECE7A15"
)]
public class StandardCategory : NodeContent, ISitePage
{
    [CultureSpecific]
    [Display(Name = "Main menu label", GroupName = SystemTabNames.Content, Order = 100)]
    public virtual string? MainMenuLabel { get; set; }

    [Display(Name = "Enable breadcrumbs", GroupName = SystemTabNames.Content, Order = 100)]
    [CultureSpecific]
    public virtual bool EnableBreadcrumbs { get; set; }
}
