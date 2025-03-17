using System.ComponentModel.DataAnnotations;
using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Commerce.Catalog.DataAnnotations;
using OptiSandbox.Web.Content.Models.Pages;
using UIHint = EPiServer.Web.UIHint;

namespace OptiSandbox.Web.Commerce.Catalog.Models.Categories;

[CatalogContentType(
    DisplayName = "Standard category",
    MetaClassName = "StandardCategory",
    GUID = "BA9E7B8C-26E7-4DEF-A8BD-29CDDECE7A15"
)]
public class StandardCategory : NodeContent, ISitePage
{
    [Display(Name = "Title", GroupName = SystemTabNames.Content, Order = 100)]
    [CultureSpecific]
    public virtual string? Title { get; set; }

    [Display(Name = "Subtitle", GroupName = SystemTabNames.Content, Order = 200)]
    [CultureSpecific]
    public virtual string? Subtitle { get; set; }

    [CultureSpecific]
    [Display(Name = "Main menu label", GroupName = SystemTabNames.Content, Order = 100)]
    public virtual string? MainMenuLabel { get; set; }

    [Display(Name = "Placeholder image - category page", GroupName = CommerceTabNames.ImagePlaceholders, Order = 100)]
    [CultureSpecific]
    [UIHint(UIHint.Image)]
    public virtual ContentReference? PlaceholderImageCategoryPage { get; set; }

    [Display(Name = "Placeholder image - product page", GroupName = CommerceTabNames.ImagePlaceholders, Order = 200)]
    [CultureSpecific]
    [UIHint(UIHint.Image)]
    public virtual ContentReference? PlaceholderImageProductPage { get; set; }

    [Display(Name = "Enable breadcrumbs", GroupName = SystemTabNames.Content, Order = 100)]
    [CultureSpecific]
    public virtual bool EnableBreadcrumbs { get; set; }
}
