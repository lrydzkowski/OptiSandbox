using System.ComponentModel.DataAnnotations;
using OptiSandbox.Web.Content.Models.Pages;

namespace OptiSandbox.Web.Commerce.Models.Pages;

[ContentType(DisplayName = "Cart page", GUID = "80F71FD6-714C-4BB4-8D75-60ED109AC4AC")]
public class CartPage : PageData, ISitePage
{
    [CultureSpecific]
    [Display(Name = "Page title", GroupName = SystemTabNames.Content, Order = 100)]
    public virtual string? PageTitle { get; set; }

    [CultureSpecific]
    [Display(Name = "Title", GroupName = SystemTabNames.Content, Order = 200)]
    public virtual string? Title { get; set; }

    [CultureSpecific]
    [Display(Name = "Subtitle", GroupName = SystemTabNames.Content, Order = 500)]
    public virtual string? Subtitle { get; set; }

    [CultureSpecific]
    [Display(Name = "Enable breadcrumbs", GroupName = SystemTabNames.Content, Order = 70)]
    public virtual bool EnableBreadcrumbs { get; set; }
}
