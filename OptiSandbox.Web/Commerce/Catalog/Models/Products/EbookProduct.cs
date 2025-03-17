using System.ComponentModel.DataAnnotations;
using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Commerce.Catalog.DataAnnotations;
using OptiSandbox.Web.Content.Models;
using OptiSandbox.Web.Content.Models.Pages;

namespace OptiSandbox.Web.Commerce.Catalog.Models.Products;

[CatalogContentType(
    DisplayName = "E-book product",
    GUID = "280EA86A-EEC6-4038-85DE-F8FD6832BF45",
    MetaClassName = "EbookProduct"
)]
public class EbookProduct : ProductContent, ISitePage
{
    [CultureSpecific]
    [Display(Name = "Short description", GroupName = SystemTabNames.Content, Order = 10)]
    public virtual string? ShortDescription { get; set; }

    [CultureSpecific]
    [Display(Name = "Long description", GroupName = SystemTabNames.Content, Order = 20)]
    public virtual XhtmlString? LongDescription { get; set; }

    [Display(Name = "Format", GroupName = SystemTabNames.Content, Order = 30)]
    public virtual string? Formats { get; set; }

    [Display(Name = "Pages", GroupName = SystemTabNames.Content, Order = 40)]
    public virtual int Pages { get; set; }

    [CultureSpecific]
    [Display(Name = "Details", GroupName = SystemTabNames.Content, Order = 50)]
    public virtual XhtmlString? Details { get; set; }

    [Display(Name = "Published at", Order = 60)]
    [CultureSpecific]
    [UIHint(SiteUiHints.DateOnly)]
    public virtual DateTime? PublishedAt { get; set; }

    [CultureSpecific]
    [Display(Name = "Enable breadcrumbs", GroupName = SystemTabNames.Content, Order = 70)]
    public virtual bool EnableBreadcrumbs { get; set; }
}
