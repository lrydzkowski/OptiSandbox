using System.ComponentModel.DataAnnotations;
using OptiSandbox.Web.Commerce.Models.Categories;

namespace OptiSandbox.Web.Content.Models.Pages;

[ContentType(DisplayName = "Start page", GUID = "2DBB49EF-446C-43DD-AC23-9932D0BFF9A0")]
public class StartPage : MainPageData
{
    [CultureSpecific]
    [Display(Name = "Page title", GroupName = SystemTabNames.Content, Order = 100)]
    public virtual string? PageTitle { get; set; }

    [CultureSpecific]
    [Display(Name = "Title", GroupName = SystemTabNames.Content, Order = 400)]
    public virtual string? Title { get; set; }

    [CultureSpecific]
    [Display(Name = "Subtitle", GroupName = SystemTabNames.Content, Order = 500)]
    public virtual string? Subtitle { get; set; }

    [CultureSpecific]
    [Display(Name = "Footer text", GroupName = SystemTabNames.Content, Order = 300)]
    public virtual string? FooterText { get; set; }

    [Display(Name = "Products catalog", GroupName = SystemTabNames.Content, Order = 600)]
    [AllowedTypes(typeof(StandardCategory))]
    public virtual ContentReference? ProductsCatalog { get; set; }
}
